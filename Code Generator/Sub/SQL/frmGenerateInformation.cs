using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_Generator.Sub.SQL
{
    public partial class frmGenerateInformation : Form
    {
        public string TypeDatabase { get { return lblTypeDatabase.Text; } set { lblTypeDatabase.Text = value; } }
        public string ServerName { get { return lblServerName.Text; } set { lblServerName.Text = value; } }

        public string Username
        {
            get
            {
                string rs = lblUsername.Text == "-" ? "" : lblUsername.Text;
                return rs;
            }
            set
            {
                string rs = string.IsNullOrEmpty(value) ? "-" : value;
                lblUsername.Text = rs;
            }
        }

        public string Password
        {
            get
            {
                string rs = lblPassword.Text == "-" ? "" : lblPassword.Text;
                return rs;
            }
            set
            {
                string rs = string.IsNullOrEmpty(value) ? "-" : value;
                lblPassword.Text = rs;
            }
        }

        public string Database
        {
            get { return lblDatabase.Text; }
            set { lblDatabase.Text = value; }
        }

        public frmGenerateInformation()
        {
            InitializeComponent();
        }
    }
}