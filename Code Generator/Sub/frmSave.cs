using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_Generator.Sub
{
    public partial class frmSave : Form
    {
        public string TextChange { get; set; }

        public frmSave(string titre, string text)
        {
            InitializeComponent();
            Text = titre;
            txtTitre.Text = text;
            txtTitre.Select();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitre.Text))
            {
                MessageBox.Show("The field is empty, please fill it in", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTitre.Focus();
                return;
            }
            TextChange = txtTitre.Text;
            DialogResult = DialogResult.OK;
        }
    }
}