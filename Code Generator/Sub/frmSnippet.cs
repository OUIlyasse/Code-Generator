using BL.Configs;
using BL.Helper;
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

namespace Code_Generator.Sub
{
    public partial class frmSnippet : Form
    {
        #region variable

        private string id;
        private CodeSnippet snippet;

        #endregion variable

        #region code

        private void loadSyntax()
        {
            foreach (Language value in Enum.GetValues(typeof(Language)))
            {
                cmbxSyntax.Items.Add(value);
                cmbxSyntax.SelectedIndex = 0;
            }
        }

        private void setData(CodeSnippet rs)
        {
            id = rs.GUID;
            txtTitle.Text = rs.Name;
            rtbCode.Rtf = rs.Text;
            cmbxSyntax.SelectedItem = rs.Synatxe;
        }

        #endregion code

        public frmSnippet()
        {
            InitializeComponent();
            loadSyntax();
            btnOK.Text = "Add";
        }

        public frmSnippet(string text, string lang) : this()
        {
            rtbCode.Text = text;
            btnOK.Text = "Add";
            cmbxSyntax.Text = lang;
        }

        public frmSnippet(CodeSnippet snippet) : this()
        {
            this.snippet = snippet;
            setData(snippet);
            btnOK.Text = "Edit";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Language lang;
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("The field is empty, please fill it in", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTitle.Focus();
                DialogResult = DialogResult.None;
                return;
            }

            var config = HSnippets.LoadConfiguration();

            if (cmbxSyntax.SelectedIndex == -1)
                lang = Language.Custom;
            else
                lang = (Language)cmbxSyntax.SelectedItem;

            if (string.IsNullOrWhiteSpace(rtbCode.Text))
            {
                MessageBox.Show("The field is empty, please fill it in", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rtbCode.Focus();
                DialogResult = DialogResult.None;
                return;
            }

            bool rs;
            switch (btnOK.Text)
            {
                case "Add":
                    rs = config.Snippets.Any(x => x.Name == txtTitle.Text);
                    if (rs == true)
                    {
                        MessageBox.Show("This snippet already exists", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtTitle.Focus();
                        DialogResult = DialogResult.None;
                        return;
                    }
                    snippet = new CodeSnippet(Guid.NewGuid().ToString(), txtTitle.Text, rtbCode.Rtf, lang);

                    config.Snippets.Add(snippet);
                    HSnippets.SaveConfiguration(config);
                    break;

                case "Edit":

                    var r = HSnippets.LoadConfiguration();
                    var s = r.Snippets.FirstOrDefault(x => x.GUID == id);

                    rs = config.Snippets.Any(x => x.GUID != id && x.Name == txtTitle.Text);
                    if (rs == true)
                    {
                        MessageBox.Show("This snippet already exists", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtTitle.Focus();
                        DialogResult = DialogResult.None;
                        return;
                    }

                    //snippet = config.Snippets.FirstOrDefault(x => x.GUID == id);
                    s.GUID = snippet.GUID;
                    s.Name = txtTitle.Text;
                    s.Text = rtbCode.Rtf;
                    s.Synatxe = lang;
                    HSnippets.SaveConfiguration(r);

                    break;
            }

            DialogResult = DialogResult.OK;
        }
    }
}