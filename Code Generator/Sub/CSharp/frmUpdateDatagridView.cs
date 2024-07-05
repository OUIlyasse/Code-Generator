using BL;
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

namespace Code_Generator.Sub.CSharp
{
    public partial class frmUpdateDatagridView : Form
    {
        private string templateName;

        #region codes

        private void setData(string name)
        {
            var r = HTemplates.LoadConfiguration();
            var rs = r.Templates.FirstOrDefault(x => x.Properties.NameTemplate == name).Properties;
            propDatagridview prop = new propDatagridview();
            rs.ToPropDatagridview(prop);
            pgGrid.SelectedObject = prop;
            txtName.Text = name;
        }

        #endregion codes

        public frmUpdateDatagridView(string templateName)
        {
            InitializeComponent();
            this.templateName = templateName;
            lblTemplate.Text = $"Template: {templateName}";
            setData(templateName);
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            var r = HTemplates.LoadConfiguration();
            var pr = (propDatagridview)pgGrid.SelectedObject;
            var s = r.Templates.FirstOrDefault(x => x.Properties.NameTemplate == templateName).Properties;

            var rs = r.Templates.Any(x => x.Properties.NameTemplate == txtName.Text);
            if (rs == true)
            {
                MessageBox.Show("This template already exists", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtName.Focus();
                DialogResult = DialogResult.None;
                return;
            }

            pr.ToTemplateDatagridview(s);
            s.NameTemplate = txtName.Text;
            HTemplates.SaveConfiguration(r);
            DialogResult = DialogResult.OK;
        }
    }
}