using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL.iSQL
{
    public partial class SQL
    {
        public int CountSP()
        {
            int count = 0;
            string script = @"
            SELECT COUNT(*)
            FROM sys.objects
            WHERE type = 'P'";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(script, connection))
                    {
                        count = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception)
            {
                count = 0;
            }
            return count;
        }

        public void SearchSP(DataGridView DgTable, string text)
        {
            try
            {
                connection = new SqlConnection(ConnectionString);
                command = new SqlCommand("select o.[name] as 'StoredProcedure', c.[Text] As 'Text' from dbo.sysObjects o inner join dbo.sysComments c ON o.id = c.id Where o.Xtype = 'p' and name like '%" + text + "%' ORDER BY o.[Name]", connection);
                da = new SqlDataAdapter(command);
                dt = new DataTable();
                da.Fill(dt);
                DgTable.DataSource = dt;
                state = true;
            }
            catch
            {
                state = false;
            }
        }

        public List<string> getSP()
        {
            List<string> list = new List<string>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Retrieve schema information for the specified table
                string schemascript = $"select o.[name] as 'StoredProcedure', c.[Text] As 'Text' from dbo.sysObjects o inner join dbo.sysComments c ON o.id = c.id Where o.Xtype = 'p' ORDER BY o.[Name]";

                using (SqlCommand command = new SqlCommand(schemascript, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string columnName = reader["StoredProcedure"].ToString();
                            list.Add(columnName);
                        }
                        reader.Close();
                        command.Dispose();
                    }
                }
            }
            return list;
        }

        public string New_SP(string spName, out string message)
        {
            message = string.Empty;
            script = new StringBuilder();
            script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
            script.AppendLine($"-- Author:{Tools.Tools.InsertTabs(1)}<{ser.Name}>");
            script.AppendLine($"-- Date:{Tools.Tools.InsertTabs(1)}<{DateTime.Now}>");
            script.AppendLine($"-- Description:{Tools.Tools.InsertTabs(1)}<Description>");
            script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
            script.AppendLine("CREATE PROCEDURE <Procedure_Name>");
            script.AppendLine($"{Tools.Tools.InsertTabs(1)}-- Add the parameters for the stored procedure here");
            script.AppendLine($"{Tools.Tools.InsertTabs(1)}<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>,");
            script.AppendLine($"{Tools.Tools.InsertTabs(1)}<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>,");
            script.AppendLine("AS");
            script.AppendLine("BEGIN");
            script.AppendLine($"{Tools.Tools.InsertTabs(1)}-- Insert statements for procedure here");
            script.AppendLine($"{Tools.Tools.InsertTabs(1)}");
            script.AppendLine("END");
            script.AppendLine("GO");

            return script.ToString();
        }

        public string Create_SP(string spName, out string message)
        {
            message = string.Empty;
            script = new StringBuilder();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string spDefinitionscript = $"SELECT OBJECT_DEFINITION(OBJECT_ID('{spName}')) AS SPDefinition";
                    using (SqlCommand command = new SqlCommand(spDefinitionscript, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string spDefinition = reader["SPDefinition"].ToString();
                                //string alterProcedureScript = Regex.Replace(spDefinition, "CREATE PROC", "ALTER PROC", RegexOptions.IgnoreCase);
                                script.AppendLine(spDefinition);
                            }
                        }
                    }
                    state = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    state = false;
                }
            }
            return script.ToString();
        }

        public string Alter_SP(string sp, out string message)
        {
            message = string.Empty;
            StringBuilder script = new StringBuilder();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string spDefinitionscript = "SELECT OBJECT_DEFINITION(OBJECT_ID(@StoredProcedureName)) AS SPDefinition";
                    using (SqlCommand command = new SqlCommand(spDefinitionscript, connection))
                    {
                        command.Parameters.AddWithValue("@StoredProcedureName", sp);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string spDefinition = reader["SPDefinition"].ToString();
                                string alterProcedureScript = Regex.Replace(spDefinition, "CREATE PROC", "ALTER PROC", RegexOptions.IgnoreCase);
                                script.AppendLine(alterProcedureScript);
                                script.AppendLine($"GO");
                            }
                        }
                    }
                    state = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    state = false;
                }
            }
            return script.ToString();
        }

        public void Delete_SP(string sp, out string message)
        {
            message = string.Empty;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string deleteTablescript = $"DROP PROCEDURE {sp}";
                    using (SqlCommand command = new SqlCommand(deleteTablescript, connection))
                    {
                        command.ExecuteNonQuery();
                        message = $"Stored procedure name [{sp}] has deleted successfully .....";
                        state = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    state = false;
                }
            }
        }

        public void Rename_SP(string oldSPName, string newSPName, out string message)
        {
            message = string.Empty;
            string createViewScript = $@"
            DECLARE @ViewDefinition NVARCHAR(MAX);

            SELECT @ViewDefinition = definition
            FROM sys.sql_modules
            WHERE object_id = OBJECT_ID('{oldSPName}');

            -- Replace the old view name with the new view name
            SET @ViewDefinition = REPLACE(@ViewDefinition, '{oldSPName}', '{newSPName}');

            -- Create the new view
            EXEC sp_executesql @ViewDefinition;
        ";
            string dropViewScript = $@"
            DROP PROCEDURE {oldSPName};
        ";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand createCommand = new SqlCommand(createViewScript, connection))
                    {
                        createCommand.ExecuteNonQuery();
                    }
                    // Execute the drop view command
                    using (SqlCommand dropCommand = new SqlCommand(dropViewScript, connection))
                    {
                        dropCommand.ExecuteNonQuery();
                        message = $"Stored Procedure '{newSPName}' renamed to '{newSPName}' successfully";
                        state = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                state = false;
            }
        }

        public string Drop_SP(string spName, out string message)
        {
            message = string.Empty;
            script = new StringBuilder();
            try
            {
                script.AppendLine($"/{Tools.Tools.Insert('*', 8)} Object:  Table [dbo].[{spName}]    Script Date: {DateTime.Now} {Tools.Tools.Insert('*', 8)}/");
                script.AppendLine($"DROP PROCEDURE {spName}");
                script.AppendLine("GO");
                state = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                state = false;
            }

            return script.ToString();
        }

        public string DropAndCreate_SP(string spName, out string message)
        {
            message = string.Empty;
            script = new StringBuilder();
            try
            {
                //Drop
                script.AppendLine($"/{Tools.Tools.Insert('*', 8)} Object:  Table [dbo].[{spName}]    Script Date: {DateTime.Now} {Tools.Tools.Insert('*', 8)}/");
                script.AppendLine($"DROP PROCEDURE {spName}");
                script.AppendLine("GO");
                script.AppendLine();

                //Create
                script.AppendLine($"/{Tools.Tools.Insert('*', 8)} Object:  Table [dbo].[{spName}]    Script Date: {DateTime.Now} {Tools.Tools.Insert('*', 8)}/");

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string spDefinitionscript = $"SELECT OBJECT_DEFINITION(OBJECT_ID('{spName}')) AS SPDefinition";
                    using (SqlCommand command = new SqlCommand(spDefinitionscript, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string spDefinition = reader["SPDefinition"].ToString();
                                script.AppendLine(spDefinition);
                            }
                        }
                    }
                    state = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                state = false;
            }

            return script.ToString();
        }
    }
}