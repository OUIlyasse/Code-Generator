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
    public partial class frmListTemplates : Form
    {
        #region variables

        private configTemplate configTemplate;
        public propDatagridview prop = new propDatagridview();

        #endregion variables

        #region code

        private void setData()
        {
            configTemplate = HTemplates.LoadConfiguration();
            DataTable dt = new DataTable();
            dt.Columns.Add("Template", typeof(string));
            dt.Columns.Add("Selected", typeof(bool));

            foreach (Template tm in configTemplate.Templates)
                dt.Rows.Add(tm.Properties.NameTemplate, tm.Properties.Selected);

            dgvTemplate.DataSource = dt;
        }

        private int countSelected()
        {
            int count = 0;

            for (int i = 0; i < dgvTemplate.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvTemplate.Rows[i].Cells[colSelected.Name].Value) == true)
                    count++;
            }

            return count;
        }

        #endregion code

        public frmListTemplates()
        {
            InitializeComponent();
            setData();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            int s = countSelected();
            if (s > 0)
            {
                var r = HTemplates.LoadConfiguration();
                var rr = r.Templates.FirstOrDefault(x => x.Properties.Selected == true).Properties;
                rr.ToPropDatagridview(prop);
                HTemplates.SaveConfiguration(r);
                DialogResult = DialogResult.OK;
            }
            else
                DialogResult = DialogResult.None;
        }

        private void dgvTemplate_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
                e.ContextMenuStrip = contextMenuStrip1;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvTemplate.SelectedRows.Count == 1)
            {
                string temp = dgvTemplate.CurrentRow.Cells[colTemplate.Name].Value.ToString();
                frmUpdateDatagridView addEntry = new frmUpdateDatagridView(temp);

                if (addEntry.ShowDialog() == DialogResult.OK)
                {
                    setData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTemplate.SelectedRows.Count == 1)
            {
                string temp = dgvTemplate.CurrentRow.Cells[colTemplate.Name].Value.ToString();
                var r = HTemplates.LoadConfiguration();

                r.Templates.Remove(r.Templates.FirstOrDefault(x => x.Properties.NameTemplate == temp));

                HTemplates.SaveConfiguration(r);
                setData();
            }
        }
    }
}