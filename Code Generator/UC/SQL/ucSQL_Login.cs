using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.iSQL;

namespace Code_Generator.UC.SQL
{
    public partial class ucSQL_Login : UserControl
    {
        #region Daclaration

        #endregion Daclaration

        #region Codes

        private void LoadInstinceName()
        {
            cmbxServer.DataSource = SQL_Server.GetInstanceNames();
        }

        private void GetDatabases()
        {
            cmbxDatabase.DataSource = SQL_Server.GetDatabaseList(cmbxServer.Text);
        }

        #endregion Codes

        #region Constractors

        public ucSQL_Login()
        {
            InitializeComponent();
            cmbxAuthentification.SelectedIndex = 0;
            cmbxAuthentification_SelectedIndexChanged(null, null);
        }

        #endregion Constractors

        #region Events

        private void ucSQL_Login_Load(object sender, EventArgs e)
        {
            LoadInstinceName();
        }

        private void ckbShow_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !ckbShow.Checked;
        }

        private void cmbxAuthentification_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxAuthentification.SelectedIndex != -1)
            {
                switch (cmbxAuthentification.SelectedIndex)
                {
                    case 0:
                        txtUser.Enabled = false;
                        txtPassword.Enabled = false;
                        txtUser.Text = "";
                        txtPassword.Text = "";
                        ckbShow.Enabled = false;
                        break;

                    case 1:
                        txtUser.Enabled = true;
                        txtPassword.Enabled = true;
                        ckbShow.Enabled = true;
                        txtUser.Focus();
                        break;
                }
            }
        }

        private void cmbxDatabase_Enter(object sender, EventArgs e)
        {
            GetDatabases();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SQL_Server.TestConnection(cmbxServer.Text, txtUser.Text, txtPassword.Text, cmbxDatabase.Text);
            Cursor = Cursors.Default;
        }

        #endregion Events
    }
}