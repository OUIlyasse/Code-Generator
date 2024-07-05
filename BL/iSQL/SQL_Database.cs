using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTIL;

namespace BL.iSQL
{
    public partial class SQL
    {
        public DatabaseInfo GetDatabaseInfo(string conStringMaster)
        {
            //string connectionString = $"Server={serverName};Database=master;Integrated Security=True;";
            DatabaseInfo databases = new DatabaseInfo();

            using (SqlConnection connection = new SqlConnection(conStringMaster))
            {
                connection.Open();

                // Query to get database information
                string query = $@"
                SELECT
                    d.name AS [Database Name],
                    suser_sname(d.owner_sid) AS [Owner],
                    d.create_date AS [Date Created],
                    d.collation_name AS [Collation],
                    CAST(d.compatibility_level AS NVARCHAR) AS [Compatibility Level],
                    d.user_access_desc AS [Restrict Access]
                FROM
                    sys.databases d
                LEFT JOIN
                    sys.database_permissions sp ON d.database_id = sp.class
                WHERE
                    d.state_desc = 'ONLINE' and d.name = '{db}'
            ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            databases.DatabaseName = reader.GetString(reader.GetOrdinal("Database Name"));
                            databases.Owner = reader.GetString(reader.GetOrdinal("Owner"));
                            databases.DateCreated = reader.GetDateTime(reader.GetOrdinal("Date Created"));
                            databases.Collation = reader.GetString(reader.GetOrdinal("Collation"));
                            databases.CompatibilityLevel = Data.CompatibilityLevelMap.ContainsKey(reader.GetString(reader.GetOrdinal("Compatibility Level")))
                                                        ? Data.CompatibilityLevelMap[reader.GetString(reader.GetOrdinal("Compatibility Level"))]
                                                        : $"Unknown ({reader.GetString(reader.GetOrdinal("Compatibility Level"))})";
                            databases.RestrictAccess = reader.GetString(reader.GetOrdinal("Restrict Access"));
                        }
                    }
                }

                // Query to get database files information
                query = $@"
                SELECT
                    mf.name AS [File Name],
                    mf.physical_name AS [File Location]
                FROM
                    sys.master_files mf
                INNER JOIN
                    sys.databases db ON mf.database_id = db.database_id and db.name = '{db}'
            ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var fileInfo = new DatabaseFileInfo
                            {
                                FileName = reader.GetString(reader.GetOrdinal("File Name")),
                                FileLocation = reader.GetString(reader.GetOrdinal("File Location"))
                            };

                            databases.Files.Add(fileInfo);
                        }
                    }
                }
            }

            return databases;
        }

        public void ExecuteScript(string script, out string message)
        {
            string sqlBatch = string.Empty;
            message = string.Empty;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                //script += "\nGO";   // make sure last batch is executed.
                try
                {
                    string[] batches = script.Split(new[] { "\r\nGO\r\n", "\nGO\n", "\rGO\r", ";", "GO" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string batch in batches)
                    {
                        using (SqlCommand command = new SqlCommand(batch, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    message = $"The query was executed with success";
                    state = true;
                }
                catch (Exception ex)
                {
                    state = false;
                    //message = ex.Message;
                    MessageBox.Show($"Error {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void ExecuteQuery(string query, out string message)
        {
            message = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                //using (SqlConnection connection = new SqlConnection(conString))
                //{
                //    Server server = new Server(new ServerConnection(connection));
                //    server.ConnectionContext.ExecuteNonQuery(query);
                //}
                message = $"Stored Procedures Are Saved Successfully in Database";
                state = true;
            }
            catch (Exception ex)
            {
                message = $"Error: {ex.Message}";
                state = false;
            }
        }

        public DataTable ExecuteQuery(string query, string conString)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }
                }
            }
            catch (Exception)
            {
                dataTable = new DataTable();
            }
            return dataTable;
        }
    }
}