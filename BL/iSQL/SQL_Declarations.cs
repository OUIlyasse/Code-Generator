using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
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
        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader;
        private string conString;
        private SqlConnection connection;
        private string db;
        private StringBuilder script;
        private SqlDataAdapter da = new SqlDataAdapter();
        private DataTable dt = new DataTable();
        private ServerConnection ServerCon;
        private Server ser;
        public bool state = false;
        private string tx = string.Empty;

        public string ConnectionString { get => conString; set => conString = value; }

        public SQL(string conString, string database)
        {
            this.conString = conString;
            connection = new SqlConnection(conString);
            ServerCon = new ServerConnection(connection);
            ser = new Server(ServerCon);
            db = database;
        }

        private void statusConnection()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            else if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        private void statusCommand()
        {
            reader.Close();
            command.Dispose();
        }
    }
}