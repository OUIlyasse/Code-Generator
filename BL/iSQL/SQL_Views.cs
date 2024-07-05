using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL.iSQL
{
    public partial class SQL
    {
        public int CountViews()
        {
            int count = 0;
            string query = @"
            SELECT COUNT(*)
            FROM INFORMATION_SCHEMA.VIEWS";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
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

        public void SearchView(DataGridView DgTable, string text)
        {
            try
            {
                connection = new SqlConnection(ConnectionString);
                command = new SqlCommand("select o.[name] as 'View', c.[Text] As 'Text' from dbo.sysObjects o inner join dbo.sysComments c ON o.id = c.id Where o.Xtype = 'v' and name like '%" + text + "%' ORDER BY o.[Name]", connection);
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

        public DataTable getFieldFromView()
        {
            dt = new DataTable();
            try
            {
                connection = new SqlConnection(ConnectionString);
                command = new SqlCommand("select o.[name] as 'View', c.[Text] As 'Text' from dbo.sysObjects o inner join dbo.sysComments c ON o.id = c.id Where o.Xtype = 'v' ORDER BY o.[Name]", connection);
                da = new SqlDataAdapter(command);

                da.Fill(dt);
                state = true;
            }
            catch
            {
                dt = new DataTable();
                state = false;
            }
            return dt;
        }

        public List<string> GetView()
        {
            List<string> rs = new List<string>();
            try
            {
                connection = new SqlConnection(ConnectionString);
                command = new SqlCommand("select o.[name] as 'View', c.[Text] As 'Text' from dbo.sysObjects o inner join dbo.sysComments c ON o.id = c.id Where o.Xtype = 'v' order by name", connection);
                da = new SqlDataAdapter(command);
                dt = new DataTable();
                da.Fill(dt);
                rs = dt.AsEnumerable().Select(n => n.Field<string>(0)).ToList();
                state = true;
            }
            catch
            {
                rs = new List<string>();
                state = false;
            }
            return rs;
        }

        public void Delete_View(string view, out string message)
        {
            message = string.Empty;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                try
                {
                    connection.Open();
                    string deleteTableQuery = $"DROP VIEW [{view}]";
                    using (SqlCommand command = new SqlCommand(deleteTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        message = "View deleted successfully";
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

        public void Rename_View(string oldView, string newView, out string message)
        {
            message = string.Empty;
            string createViewScript = $@"
            DECLARE @ViewDefinition NVARCHAR(MAX);

            SELECT @ViewDefinition = definition
            FROM sys.sql_modules
            WHERE object_id = OBJECT_ID('{oldView}');

            -- Replace the old view name with the new view name
            SET @ViewDefinition = REPLACE(@ViewDefinition, '{oldView}', '{newView}');

            -- Create the new view
            EXEC sp_executesql @ViewDefinition;
        ";
            string dropViewScript = $@"
            DROP VIEW {oldView};
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
                        message = $"View '{oldView}' renamed to '{newView}' successfully";
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

        #region Scripts

        public string Create_View(string view, out string message)
        {
            message = string.Empty;
            script = new StringBuilder();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string viewName = $"{view}";
                    string viewQuery = "SELECT OBJECT_DEFINITION(OBJECT_ID(@ViewName)) AS ViewDefinition";
                    using (SqlCommand command = new SqlCommand(viewQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ViewName", viewName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            script.AppendLine($"/{Tools.Tools.Insert('*', 8)} Object:  View [dbo].[{view}]    Script Date: {DateTime.Now} {Tools.Tools.Insert('*', 8)}/");
                            if (reader.Read())
                            {
                                string viewDefinition = reader["ViewDefinition"].ToString();
                                script.AppendLine(viewDefinition);
                                script.AppendLine($"GO");
                            }
                        }
                    }
                    message = "Stored procedure has generate successfully .....";
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

        public string Alter_View(string view, out string message)
        {
            message = string.Empty;
            script = new StringBuilder();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string viewQuery = "SELECT OBJECT_DEFINITION(OBJECT_ID(@ViewName)) AS ViewDefinition";
                    using (SqlCommand command = new SqlCommand(viewQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ViewName", view);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            script.AppendLine($"/{Tools.Tools.Insert('*', 8)} Object:  View [dbo].[{view}]    Script Date: {DateTime.Now} {Tools.Tools.Insert('*', 8)}/");
                            if (reader.Read())
                            {
                                string viewDefinition = reader["ViewDefinition"].ToString();
                                string alterViewScript = viewDefinition.Replace("CREATE VIEW", "ALTER VIEW");
                                //string alterViewScript = $"ALTER VIEW {view} AS {viewDefinition}";
                                script.AppendLine(alterViewScript);
                                script.AppendLine("GO");
                            }
                        }
                    }
                    message = "Stored procedure has generate successfully .....";
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

        public string Drop_View(string view, out string message)
        {
            message = string.Empty;
            StringBuilder createScript = new StringBuilder();
            try
            {
                createScript.AppendLine($"/{Tools.Tools.Insert('*', 8)} Object:  View [dbo].[{view}]    Script Date: {DateTime.Now} {Tools.Tools.Insert('*', 8)}/");
                createScript.AppendLine($"DROP VIEW [dbo].[{view}]");
                createScript.AppendLine("GO");
                message = "Stored procedure has generate successfully .....";
                state = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                state = false;
            }

            return createScript.ToString();
        }

        public string DropAndCreate_View(string view, out string message)
        {
            message = string.Empty;
            script = new StringBuilder();
            try
            {
                //Drop
                script.AppendLine($"/{Tools.Tools.Insert('*', 8)} Object:  View [dbo].[{view}]    Script Date: {DateTime.Now} {Tools.Tools.Insert('*', 8)}/");
                script.AppendLine($"DROP View [dbo].[{view}]");
                script.AppendLine("GO");

                script.AppendLine();

                //Create
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string viewName = $"{view}";
                    string viewQuery = "SELECT OBJECT_DEFINITION(OBJECT_ID(@ViewName)) AS ViewDefinition";
                    using (SqlCommand command = new SqlCommand(viewQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ViewName", viewName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            script.AppendLine($"/{Tools.Tools.Insert('*', 8)} Object:  View [dbo].[{view}]    Script Date: {DateTime.Now} {Tools.Tools.Insert('*', 8)}/");
                            if (reader.Read())
                            {
                                string viewDefinition = reader["ViewDefinition"].ToString();
                                script.AppendLine(viewDefinition);
                                script.AppendLine($"GO");
                            }
                        }
                    }
                }
                message = "Stored procedure has generate successfully .....";
                state = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                state = false;
            }

            return script.ToString();
        }

        #endregion Scripts
    }
}