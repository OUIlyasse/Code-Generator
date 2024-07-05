using BL.PropertyGrid;
using Microsoft.SqlServer.Management.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using UTIL;

namespace BL.iSQL
{
    public partial class SQL
    {
        public int CountTables()
        {
            int count = 0;
            string query = @"
            SELECT COUNT(*)
            FROM INFORMATION_SCHEMA.TABLES
            WHERE TABLE_TYPE = 'BASE TABLE'";

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

        public void SearchTableName(DataGridView DgTable, string text)
        {
            try
            {
                connection = new SqlConnection(ConnectionString);
                command = new SqlCommand("select name as 'Name_Table' from dbo.sysobjects where xtype = 'u' and  name like '%" + text + "%' order by name", connection);
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

        public void GetData(DataGridView DgData, string strTable)
        {
            try
            {
                DgData.DataSource = null;
                connection = new SqlConnection(ConnectionString);
                command = new SqlCommand($"select * from {strTable}", connection);
                da = new SqlDataAdapter(command);
                dt = new DataTable();
                da.Fill(dt);
                DgData.DataSource = dt;
                state = true;
            }
            catch
            {
                state = false;
            }
        }

        public List<string> GetTable()
        {
            List<string> rs = new List<string>();
            try
            {
                connection = new SqlConnection(ConnectionString);
                command = new SqlCommand("select name as 'Name_Table' from dbo.sysobjects where xtype = 'u' order by name", connection);
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

        public void Create_Table(string table, Dictionary<int, Column> Columns, out string message)
        {
            message = string.Empty;

            script = new StringBuilder();
            try
            {
                script.AppendLine($"CREATE TABLE {table}(");

                foreach (var item in Columns)
                {
                    script.Append($"{item.Value.Name} ");
                    script.Append($"{item.Value.DataType.ToList()}");

                    if (Data.DataTypeSQLServerStrings().Contains(item.Value.DataType.ToList()))
                        script.Append($"({item.Value.Size}) ");
                    else if (Data.DataTypeSQLServerNumeric().Contains(item.Value.DataType.ToList()) && item.Value.IsIdentity)
                        script.Append($" IDENTITY({item.Value.IdentityIncrement},{item.Value.IdentitySpeed}) ");

                    script.Append(item.Value.AllowNull == true ? "NULL," : "NOT NULL,");
                }
                script.Length -= 1;

                foreach (var item in Columns)
                {
                    if (item.Value.IsPrimaryKey)
                    {
                        script.AppendLine(",");
                        script.AppendLine($"PRIMARY KEY ({item.Value.Name}), ");
                    }
                }

                script.Length -= 4;

                script.AppendLine($")");

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand createCommand = new SqlCommand(script.ToString(), connection))
                    {
                        createCommand.ExecuteNonQuery();
                        message = "Table added successfully";
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

        public void Delete_Table(string table, out string message)
        {
            message = string.Empty;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string deleteTableQuery = $"DROP TABLE {table}";
                    using (SqlCommand command = new SqlCommand(deleteTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        message = "Table deleted successfully";
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

        public void Rename_Table(string oldTableName, string newTableName, out string message)
        {
            message = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string renameQuery = $"EXEC sp_rename '{oldTableName}', '{newTableName}';";

                    using (SqlCommand command = new SqlCommand(renameQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    message = $"Table '{oldTableName}' renamed to '{newTableName}' successfully";
                    state = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                state = false;
            }
        }

        #region Scripts

        public string Create_Table(string table, out string message)
        {
            message = string.Empty;
            script = new StringBuilder();
            try
            {
                connection = new SqlConnection(ConnectionString);
                statusConnection();
                // Retrieve schema information for the specified table
                string schemaQuery = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' ORDER BY ORDINAL_POSITION";
                string pkQuery = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME ='{table}'";
                string fkQuery = $@"
            SELECT
                FK.TABLE_NAME AS FK_Table,
                CU.COLUMN_NAME AS FK_Column,
                PK.TABLE_NAME AS PK_Table,
                PT.COLUMN_NAME AS PK_Column,
                C.CONSTRAINT_NAME AS Constraint_Name,
                C.UPDATE_RULE,
                C.DELETE_RULE
            FROM
                INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C
                INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
                INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
                INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME
                INNER JOIN (
                            SELECT
                                i1.TABLE_NAME,
                                i2.COLUMN_NAME
                            FROM
                                INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
                                INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
                            WHERE
                                i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
                           ) PT ON PT.TABLE_NAME = PK.TABLE_NAME
            WHERE FK.TABLE_NAME = '{table}'";

                script.AppendLine($"/{Tools.Tools.Insert('*', 8)} Object:  Table [dbo].[{table}]    Script Date: {DateTime.Now} {Tools.Tools.Insert('*', 8)}/ ");
                script.AppendLine($"SET ANSI_NULLS ON");
                script.AppendLine($"GO\n");
                script.AppendLine($"SET QUOTED_IDENTIFIER ON");
                script.AppendLine($"GO\n");

                script.AppendLine($"CREATE TABLE [dbo].[{table}] \n(");

                command = new SqlCommand(schemaQuery, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();
                    string dataType = reader["DATA_TYPE"].ToString();
                    bool isNullable = reader["IS_NULLABLE"].ToString() == "YES";
                    int? maxLength = reader["CHARACTER_MAXIMUM_LENGTH"] as int?;
                    byte? numericPrecision = reader["NUMERIC_PRECISION"] as byte?;
                    int? numericScale = reader["NUMERIC_SCALE"] as int?;

                    string columnDefinition = GetColumnDefinition(dataType, maxLength, numericPrecision, numericScale, isNullable);
                    script.AppendLine($"{Tools.Tools.InsertTabs(1)}{columnName} {columnDefinition},");
                }

                script.Length -= 3; // Remove the trailing comma and newline

                //get PRIMARY KEY
                statusCommand();
                command = new SqlCommand(pkQuery, connection);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    script.AppendLine(",");
                    script.Append($"{Tools.Tools.InsertTabs(1)}PRIMARY KEY (");

                    while (reader.Read())
                    {
                        script.Append(reader["COLUMN_NAME"].ToString() + ", ");
                    }

                    script.Length -= 2;
                    script.AppendLine(")");
                }

                //get FOREIGN  KEY
                statusCommand();
                command = new SqlCommand(fkQuery, connection);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    script.Length -= 2;
                    script.AppendLine(",");
                    while (reader.Read())
                    {
                        string fkColumn = reader["FK_Column"].ToString();
                        string pkTable = reader["PK_Table"].ToString();
                        string pkColumn = reader["PK_Column"].ToString();
                        string constraintName = reader["Constraint_Name"].ToString();
                        string updateRule = reader["UPDATE_RULE"].ToString();
                        string deleteRule = reader["DELETE_RULE"].ToString();

                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}CONSTRAINT {constraintName} FOREIGN KEY ({fkColumn}) REFERENCES {pkTable}({pkColumn}) ON DELETE {deleteRule} ON UPDATE {updateRule},");
                    }
                }

                script.Length -= 3;
                script.AppendLine();
                script.AppendLine(")");
                script.AppendLine("GO");

                statusCommand();
                statusConnection();

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

        public string Drop_Table(string table, out string message)
        {
            message = string.Empty;
            script = new StringBuilder();
            try
            {
                script.AppendLine($"/{Tools.Tools.Insert('*', 8)} Object:  Table [dbo].[{table}]    Script Date: {DateTime.Now} {Tools.Tools.Insert('*', 8)}/");
                script.AppendLine($"DROP TABLE [dbo].[{table}]");
                script.AppendLine("GO");
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

        public string DropAndCreate_Table(string table, out string message)
        {
            message = string.Empty;
            StringBuilder script = new StringBuilder();
            try
            {
                string schemaQuery = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' ORDER BY ORDINAL_POSITION";
                string pkQuery = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME ='{table}'";
                string fkQuery = $@"
            SELECT
                FK.TABLE_NAME AS FK_Table,
                CU.COLUMN_NAME AS FK_Column,
                PK.TABLE_NAME AS PK_Table,
                PT.COLUMN_NAME AS PK_Column,
                C.CONSTRAINT_NAME AS Constraint_Name,
                C.UPDATE_RULE,
                C.DELETE_RULE
            FROM
                INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C
                INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
                INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
                INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME
                INNER JOIN (
                            SELECT
                                i1.TABLE_NAME,
                                i2.COLUMN_NAME
                            FROM
                                INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
                                INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
                            WHERE
                                i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
                           ) PT ON PT.TABLE_NAME = PK.TABLE_NAME
            WHERE FK.TABLE_NAME = '{table}'";
                connection = new SqlConnection(ConnectionString);
                statusConnection();

                //Drop All FOREIGN  KEY
                command = new SqlCommand(fkQuery, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string constraintName = reader["Constraint_Name"].ToString();
                    //ALTER TABLE [dbo].[Categorie] DROP CONSTRAINT [FK_Categorie_Users]
                    //GO
                    script.AppendLine($"ALTER TABLE {table} DROP CONSTRAINT {constraintName}");
                    script.AppendLine($"GO");
                    script.AppendLine();
                }

                script.AppendLine();

                //Drop
                script.AppendLine($"/{Tools.Tools.Insert('*', 8)} Object:  Table [dbo].[{table}]    Script Date: {DateTime.Now} {Tools.Tools.Insert('*', 8)}/");
                script.AppendLine($"DROP TABLE [dbo].[{table}]");
                script.AppendLine("GO");

                script.AppendLine();

                //Create

                // Retrieve schema information for the specified table

                script.AppendLine($"/{Tools.Tools.Insert('*', 8)} Object:  Table [dbo].[{table}]    Script Date: {DateTime.Now} {Tools.Tools.Insert('*', 8)}/ ");
                script.AppendLine($"SET ANSI_NULLS ON");
                script.AppendLine($"GO\n");
                script.AppendLine($"SET QUOTED_IDENTIFIER ON");
                script.AppendLine($"GO\n");

                script.AppendLine($"CREATE TABLE [dbo].[{table}] \n(");

                statusCommand();
                command = new SqlCommand(schemaQuery, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();
                    string dataType = reader["DATA_TYPE"].ToString();
                    bool isNullable = reader["IS_NULLABLE"].ToString() == "YES";
                    int? maxLength = reader["CHARACTER_MAXIMUM_LENGTH"] as int?;
                    byte? numericPrecision = reader["NUMERIC_PRECISION"] as byte?;
                    int? numericScale = reader["NUMERIC_SCALE"] as int?;

                    string columnDefinition = GetColumnDefinition(dataType, maxLength, numericPrecision, numericScale, isNullable);
                    script.AppendLine($"{Tools.Tools.InsertTabs(1)}{columnName} {columnDefinition},");
                }

                script.Length -= 3; // Remove the trailing comma and newline

                //get PRIMARY KEY
                statusCommand();
                command = new SqlCommand(pkQuery, connection);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    script.AppendLine(",");
                    script.Append($"{Tools.Tools.InsertTabs(1)}PRIMARY KEY (");

                    while (reader.Read())
                    {
                        script.Append(reader["COLUMN_NAME"].ToString() + ", ");
                    }

                    script.Length -= 2;
                    script.AppendLine(")");
                }

                //get FOREIGN  KEY
                statusCommand();
                command = new SqlCommand(fkQuery, connection);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    script.Length -= 2;
                    script.AppendLine(",");
                    while (reader.Read())
                    {
                        string fkColumn = reader["FK_Column"].ToString();
                        string pkTable = reader["PK_Table"].ToString();
                        string pkColumn = reader["PK_Column"].ToString();
                        string constraintName = reader["Constraint_Name"].ToString();
                        string updateRule = reader["UPDATE_RULE"].ToString();
                        string deleteRule = reader["DELETE_RULE"].ToString();

                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}CONSTRAINT {constraintName} FOREIGN KEY ({fkColumn}) REFERENCES {pkTable}({pkColumn}) ON DELETE {deleteRule} ON UPDATE {updateRule},");
                    }
                }

                script.Length -= 3;
                script.AppendLine();
                script.AppendLine(")");
                script.AppendLine("GO");

                statusCommand();
                statusConnection();

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