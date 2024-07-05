using BL.Configs;
using BL.Helper;
using Code_Generator.Main;
using Code_Generator.Main.SQL;
using Code_Generator.Sub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_Generator
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            dbInfo db = HDbInfo.LoadConfiguration();
            if (db.isRemember == false)
                Application.Run(new frmRegisterDatabase());
            else
            {
                switch (db.TypeDatabase)
                {
                    case UTIL.TypeDatabase.None:
                        Application.Run(new frmRegisterDatabase());
                        break;

                    case UTIL.TypeDatabase.Microsoft_SQL_Server:
                        Application.Run(new SQL_frmMain());
                        break;

                    case UTIL.TypeDatabase.MySQL:
                        break;

                    case UTIL.TypeDatabase.Microsoft_Access:
                        break;

                    case UTIL.TypeDatabase.Oracle:
                        break;

                    case UTIL.TypeDatabase.LocalSQL:
                        break;

                    default:
                        break;
                }
            }
        }
    }
}