using iTools;
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
    public partial class frmGetConString : Form
    {
        public string Constring { get { return lblConstring.Text; } set { lblConstring.Text = value; } }

        public frmGetConString()
        {
            InitializeComponent();
        }

        private void lblConstring_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblConstring.Text))
            {
                Clipboard.SetText(Constring);
                iMessage.infoMsg("Copied!", "");
            }
        }
    }
}