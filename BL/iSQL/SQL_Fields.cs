using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.iSQL
{
    public partial class SQL
    {
        private bool ConvertToBool(string value)
        {
            bool rs = false;
            if (value == "1" || value.ToLower() == "true")
                rs = true;
            else
                rs = false;
            return rs;
        }

        public int CountFieldsTable(string tblName)
        {
            int count = 0;
            string query = @"
            SELECT COUNT(*)
            FROM INFORMATION_SCHEMA.COLUMNS
            WHERE TABLE_NAME = @TableName";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TableName", tblName);
                        int columnCount = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception)
            {
                count = 0;
            }

            return count;
        }

        public int CountFieldsView(string viewName)
        {
            int count = 0;
            string query = @"
            SELECT COUNT(*)
            FROM INFORMATION_SCHEMA.COLUMNS
            WHERE TABLE_NAME = @ViewName AND TABLE_SCHEMA = 'dbo'";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ViewName", viewName);
                        int columnCount = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception)
            {
                count = 0;
            }

            return count;
        }

        public DataTable getFields(string table)
        {
            try
            {
                connection = new SqlConnection(ConnectionString);
                dt = new DataTable();
                var str = string.Format("SELECT col.COLUMN_NAME, IIF(col.IS_NULLABLE ='Yes',1,0) as IS_NULLABLE, lower(col.DATA_TYPE) as DATA_TYPE, IIF(col.CHARACTER_MAXIMUM_LENGTH =-1,'max',Convert(nvarchar,col.CHARACTER_MAXIMUM_LENGTH)) as CHARACTER_MAXIMUM_LENGTH, " +
                    "COLUMNPROPERTY(OBJECT_ID('[' + col.TABLE_SCHEMA + '].[' + col.TABLE_NAME + ']'), col.COLUMN_NAME, 'IsIdentity')AS IS_IDENTITY, " +
                    "CAST(ISNULL(pk.is_primary_key, 0)AS bit) AS IsPrimaryKey FROM INFORMATION_SCHEMA.COLUMNS AS col LEFT JOIN(SELECT SCHEMA_NAME" +
                    "(o.schema_id)AS TABLE_SCHEMA, o.name AS TABLE_NAME, c.name AS COLUMN_NAME, i.is_primary_key FROM sys.indexes AS i JOIN " +
                    "sys.index_columns AS ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id JOIN sys.objects AS o ON i.object_id = o.object_id LEFT JOIN " +
                    "sys.columns AS c ON ic.object_id = c.object_id AND c.column_id = ic.column_id WHERE i.is_primary_key = 1)AS pk ON col.TABLE_NAME = " +
                    "pk.TABLE_NAME AND col.TABLE_SCHEMA = pk.TABLE_SCHEMA AND  col.COLUMN_NAME = pk.COLUMN_NAME  WHERE col.TABLE_NAME = " +
                    "'{0}' ORDER BY col.TABLE_NAME, col.ORDINAL_POSITION;", table);
                command = new SqlCommand(str, connection);
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

        public List<string> getField(string table)
        {
            List<string> list = new List<string>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Retrieve schema information for the specified table
                string schemaQuery = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' ORDER BY ORDINAL_POSITION";

                using (SqlCommand command = new SqlCommand(schemaQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string columnName = reader["COLUMN_NAME"].ToString();
                            list.Add(columnName);
                        }
                        reader.Close();
                        command.Dispose();
                    }
                }
            }
            return list;
        }

        public List<string> getField()
        {
            List<string> list = new List<string>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Retrieve schema information for the specified table
                string schemaQuery = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS ORDER BY ORDINAL_POSITION";

                using (SqlCommand command = new SqlCommand(schemaQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string columnName = reader["COLUMN_NAME"].ToString();
                            list.Add(columnName);
                        }
                        reader.Close();
                        command.Dispose();
                    }
                }
            }
            return list;
        }

        public bool isIdentity(string field, string table)
        {
            bool rs = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var schemaQuery = string.Format("SELECT col.COLUMN_NAME, col.ORDINAL_POSITION, IIF(col.IS_NULLABLE ='Yes',1,0) as IS_NULLABLE, lower(col.DATA_TYPE) as DATA_TYPE, IIF(col.CHARACTER_MAXIMUM_LENGTH =-1,'max',Convert(nvarchar,col.CHARACTER_MAXIMUM_LENGTH)) as CHARACTER_MAXIMUM_LENGTH, " +
                                            "COLUMNPROPERTY(OBJECT_ID('[' + col.TABLE_SCHEMA + '].[' + col.TABLE_NAME + ']'), col.COLUMN_NAME, 'IsIdentity')AS IS_IDENTITY, " +
                                            "CAST(ISNULL(pk.is_primary_key, 0)AS bit) AS IsPrimaryKey FROM INFORMATION_SCHEMA.COLUMNS AS col LEFT JOIN(SELECT SCHEMA_NAME" +
                                            "(o.schema_id)AS TABLE_SCHEMA, o.name AS TABLE_NAME, c.name AS COLUMN_NAME, i.is_primary_key FROM sys.indexes AS i JOIN " +
                                            "sys.index_columns AS ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id JOIN sys.objects AS o ON i.object_id = o.object_id LEFT JOIN " +
                                            "sys.columns AS c ON ic.object_id = c.object_id AND c.column_id = ic.column_id WHERE i.is_primary_key = 1)AS pk ON col.TABLE_NAME = " +
                                            "pk.TABLE_NAME AND col.TABLE_SCHEMA = pk.TABLE_SCHEMA AND  col.COLUMN_NAME = pk.COLUMN_NAME  WHERE col.TABLE_NAME = " +
                                            "'{0}' ORDER BY col.TABLE_NAME, col.ORDINAL_POSITION;", table);

                //Columns
                using (SqlCommand command1 = new SqlCommand(schemaQuery, connection))
                {
                    using (SqlDataReader reader1 = command1.ExecuteReader())
                    {
                        while (reader1.Read())
                        {
                            string columnName = reader1["COLUMN_NAME"].ToString();
                            bool rs2 = ConvertToBool(reader1["IS_IDENTITY"].ToString());
                            if (columnName == field)
                            {
                                if (rs2 == true)
                                    rs = true;
                                else
                                    rs = false;
                            }
                        }
                    }
                }
            }
            return rs;
        }
    }
}