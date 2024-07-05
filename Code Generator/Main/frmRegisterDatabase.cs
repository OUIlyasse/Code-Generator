using BL.iSQL;
using BL.Configs;
using BL.Helper;
using Code_Generator.Main.SQL;
using Code_Generator.UC.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTIL;

namespace Code_Generator.Main
{
    public partial class frmRegisterDatabase : Form
    {
        #region Daclaration

        private TypeDatabase typeDatabase;
        private ucSQL_Login ucSQL_Login_P;

        #endregion Daclaration

        #region Codes

        private void LoadTypes()
        {
            string[] list = new string[] { "Microsoft SQL Server", "MySQL", "Microsoft Access", "Oracle", "LocalSQL" };
            cmbxType.Items.Clear();
            cmbxType.Items.AddRange(list);
        }

        private void OpenUC(UserControl userControl)
        {
            pnlUC.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            pnlUC.Controls.Add(userControl);
        }

        private void Login_SQLServer(ucSQL_Login uc)
        {
            if (string.IsNullOrEmpty(uc.cmbxServer.Text))
            {
                MessageBox.Show("Server name is empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                uc.cmbxServer.Focus();
                return;
            }
            if (string.IsNullOrEmpty(uc.cmbxDatabase.Text))
            {
                MessageBox.Show("Database name is empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                uc.cmbxDatabase.Focus();
                return;
            }
            string conString;
            bool rs = SQL_Server.Connect_SQL(uc.cmbxServer.Text, uc.txtUser.Text.Trim(), uc.txtPassword.Text.Trim(), uc.cmbxDatabase.Text, out conString);
            string rsC = SQL_Server.Connect_SQL_Master(uc.cmbxServer.Text, uc.txtUser.Text.Trim(), uc.txtPassword.Text.Trim());
            if (rs == true)
            {
                dbInfo db = new dbInfo()
                {
                    TypeDatabase = typeDatabase,
                    ServerName = uc.cmbxServer.Text,
                    Username = uc.txtUser.Text.Trim(),
                    Password = uc.txtPassword.Text,
                    DatabaseName = uc.cmbxDatabase.Text,
                    isRemember = uc.ckbRemember.Checked,
                    conString = conString,
                    conStringMaster = rsC
                };

                HDbInfo.SaveConfiguration(db);

                Hide();
                SQL_frmMain frm = new SQL_frmMain();
                frm.ShowDialog();
                if (frm.IsClosed == true)
                {
                    Application.Exit();
                }
                //frmMain.statusControls(true);
                //frmMain.OpenForm(frm);
                //frmMain.frm = frm;
            }
        }

        #endregion Codes

        #region Constractors

        public frmRegisterDatabase()
        {
            InitializeComponent();
        }

        #endregion Constractors

        #region Events

        #endregion Events

        private void cmbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbxType.Text)
            {
                case "Microsoft SQL Server"://Sql server
                    typeDatabase = TypeDatabase.Microsoft_SQL_Server;
                    ucSQL_Login uc = new ucSQL_Login();
                    ucSQL_Login_P = uc;
                    OpenUC(uc);
                    break;

                default:
                    pnlUC.Controls.Clear();
                    break;
            }
        }

        private void frmRegisterDatabase_Load(object sender, EventArgs e)
        {
            LoadTypes();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            switch (typeDatabase)
            {
                case TypeDatabase.Microsoft_SQL_Server:
                    Login_SQLServer(ucSQL_Login_P);
                    break;

                case TypeDatabase.MySQL:
                    break;

                case TypeDatabase.Microsoft_Access:
                    break;

                case TypeDatabase.Oracle:
                    break;

                case TypeDatabase.LocalSQL:
                    break;

                default:
                    break;
            }
        }
    }
}