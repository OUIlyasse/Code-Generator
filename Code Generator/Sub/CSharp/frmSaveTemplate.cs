using BL.Configs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_Generator.Sub.CSharp
{
    public partial class frmSaveTemplate : Form
    {
        private configTemplate config;

        public string TemplateName { get; set; }

        public frmSaveTemplate(configTemplate config)
        {
            InitializeComponent();
            this.config = config;
            txtTitre.Text = "Template1";
            txtTitre.Select();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitre.Text))
            {
                MessageBox.Show("The field is empty, please fill it in", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTitre.Focus();
                DialogResult = DialogResult.None;
                return;
            }
            var rs = config.Templates.Any(x => x.Properties.NameTemplate == txtTitre.Text);
            if (rs == true)
            {
                MessageBox.Show("This template already exists", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTitre.Focus();
                DialogResult = DialogResult.None;
                return;
            }
            TemplateName = txtTitre.Text;
            DialogResult = DialogResult.OK;
        }
    }
}