using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Database;

namespace BL.iSQL
{
    public class SQL_Server
    {
        public static List<string> GetInstanceNames()
        {
            List<string> rs = new List<string>();
            try
            {
                //32 bit
                using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
                {
                    RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Microsoft SQL Server\Instance Names\SQL\", false);
                    if (instanceKey != null)
                    {
                        foreach (string instanceName in instanceKey.GetValueNames())
                            rs.Add(Environment.MachineName + @"\" + instanceName);
                    }
                }

                //64 bit
                using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                {
                    RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL\", false);
                    if (instanceKey != null)
                    {
                        foreach (string instanceName in instanceKey.GetValueNames())
                            rs.Add(Environment.MachineName + @"\" + instanceName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + Environment.NewLine + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rs = new List<string>();
            }
            return rs;
        }

        public static List<string> GetDatabaseList(string serverName)
        {
            List<string> list = new List<string>();
            if (string.IsNullOrEmpty(serverName))
                return list;
            try
            {
                string conString = "Server = " + serverName + "; Database = master; Integrated Security = true;";

                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                    {
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                                list.Add(dr[0].ToString());
                        }
                    }
                }
            }
            catch (Exception)
            {
                list = new List<string>();
            }
            return list;
        }

        public static void TestConnection(string serverName, string user, string pass, string db)
        {
            string conString = "";
            SqlConnection Con;

            if (string.IsNullOrEmpty(serverName) || string.IsNullOrEmpty(db))
                return;
            try
            {
                if (user == string.Empty)
                    conString = "Server = " + serverName + "; Database = " + db + "; Integrated Security = True;";
                else
                    conString = "Server = " + serverName + "; Database = " + db + "; User ID = " + user + "; Password = " + pass + ";";
                Con = new SqlConnection(conString);
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                    MessageBox.Show("Connection Success .... ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                }
            }
            catch
            {
                MessageBox.Show("Sorry ... Connection Failed", "Attension", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool Connect_SQL(string serverName, string user, string pass, string db, out string conString)
        {
            string con = "";
            conString = "";

            if (string.IsNullOrEmpty(serverName) || string.IsNullOrEmpty(db))
                return false;

            try
            {
                if (user == string.Empty)
                {
                    con = "Server = " + serverName + "; Database = " + db + "; Integrated Security = True;";
                }
                else
                {
                    con = "Server = " + serverName + "; Database = " + db + "; User ID = " + user + "; Password = " + pass + ";";
                }
                if (iConnection.TestConnection(con))
                {
                    conString = con;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry ... Connecton Failed" + Environment.NewLine + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static string Connect_SQL_Master(string serverName, string user, string pass)
        {
            string con = "";

            if (string.IsNullOrEmpty(serverName))
                con = "";

            try
            {
                if (user == string.Empty)
                {
                    con = "Server = " + serverName + "; Database = master; Integrated Security = True;";
                }
                else
                {
                    con = "Server = " + serverName + "; Database = master; User ID = " + user + "; Password = " + pass + ";";
                }
                if (!iConnection.TestConnection(con))
                {
                    con = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry ... Connecton Failed" + Environment.NewLine + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con = "";
            }

            return con;
        }
    }
}