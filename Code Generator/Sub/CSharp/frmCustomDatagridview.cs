using BL;
using BL.Configs;
using BL.Helper;
using Code_Generator.Sub.CSharp;
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

namespace Code_Generator.Sub.CSharp
{
    public partial class frmCustomDatagridview : Form
    {
        #region variables

        private propDatagridview propDatagridview;
        private List<Events> evs;
        private List<cColumns> columns;
        private DataGridView grid;
        private string table;

        public propDatagridview PropDatagridview { get => (propDatagridview)pgGrid.SelectedObject; set => pgGrid.SelectedObject = value; }
        public List<Events> Evs { get => evs; set => evs = value; }
        public List<cColumns> Columns { get => columns; set => columns = value; }
        public BL.iCSharp.CSharp CSharp { get; set; }
        public dbInfo dbInfo { get; set; }

        public string TemplateName
        {
            get
            {
                return lblName.Text.Substring(0, 10);
            }
            set
            {
                lblName.Text = $"Template: {value}";
            }
        }

        #endregion variables

        #region Code

        private void setPropGrid(string table)
        {
            var conf = HTemplates.LoadConfiguration();
            var r = conf.Templates.FirstOrDefault(x => x.Properties.Selected == true);
            if (r != null)
            {
                var rr = r.Properties;
                if (conf != null)
                {
                    rr.ToPropDatagridview(PropDatagridview);
                    PropDatagridview.Name = $"dgv{table}";
                    lblName.Text = $"Template: {r.Properties.NameTemplate}";
                }
                else
                {
                    PropDatagridview = new propDatagridview();
                    PropDatagridview.Name = $"dgv{table}";
                    lblName.Text = $"Template: temp";
                }
            }
            else
            {
                PropDatagridview = new propDatagridview();
                PropDatagridview.Name = $"dgv{table}";
                lblName.Text = $"Template: temp";
            }

            //PropDatagridview.Name = $"dgv{table}";
            //pgGrid.SelectedObject = PropDatagridview;
        }

        private void setColumns()
        {
            dgvColumn.DataSource = CSharp.CustomColumnsInGrid(grid);
            Columns = CSharp.CustomColumnsInGrid(grid);
        }

        private void fieldItems()
        {
            foreach (var item in Data.ColumnType())
                colColumnType.Items.Add(item);

            foreach (var item in Data.AutoSizeMode())
                colAutoSizeMode.Items.Add(item);
        }

        #endregion Code

        public frmCustomDatagridview(string table, DataGridView grid)
        {
            InitializeComponent();
            dbInfo = HDbInfo.LoadConfiguration();
            CSharp = new BL.iCSharp.CSharp(dbInfo.conString, dbInfo.DatabaseName);

            Evs = new List<Events>();
            this.grid = grid;
            this.table = table;
            fieldItems();
            lblNameDatagridView.Text = $"Datagridview: dgv{table}";
            PropDatagridview = new propDatagridview();
            setPropGrid(table);
            setColumns();
        }

        private void dgvColumn_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvColumn.Rows)
            {
                string column = row.Cells[colColumn.Name].Value.ToString();
                string Name = row.Cells[colName.Name].Value.ToString();
                string Type = row.Cells[colColumnType.Name].Value.ToString();
                string DataPropertyName = row.Cells[colDataPropertyName.Name].Value.ToString();
                string AutoSizeMode = row.Cells[colAutoSizeMode.Name].Value.ToString();
                string HeaderText = row.Cells[colHeaderText.Name].Value.ToString();

                bool Visible = (bool)row.Cells[colVisible.Name].Value;
                bool ReadOnly = (bool)row.Cells[colReadOnly.Name].Value;

                var rs = Columns.FirstOrDefault(x => x.Column.Equals(column));
                rs.ColumnName = Name;
                rs.ColumnType = Type;
                rs.AutoSizeMode = AutoSizeMode;
                rs.DataPropertyName = DataPropertyName;
                rs.HeaderText = HeaderText;
                rs.ReadOnly = ReadOnly;
                rs.Visible = Visible;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            var dgv = ((propDatagridview)pgGrid.SelectedObject).ToDataGridView();

            foreach (var item in Columns)
            {
                dgv.Columns.Add(item.ToDataGridViewColumn());
            }

            frmPreviewDgv frm = new frmPreviewDgv(dgv, table);
            frm.ShowDialog();
        }

        private void btnEvents_Click(object sender, EventArgs e)
        {
            frmEvents frm;
            Events ev = Evs.FirstOrDefault(item => item.Field == PropDatagridview.Name);
            if (ev != null)
                frm = new frmEvents("DataGridView", PropDatagridview.Name, Evs, ev);
            else
                frm = new frmEvents("DataGridView", PropDatagridview.Name, Evs);

            frm.ShowDialog();
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            frmListTemplates frm = new frmListTemplates();
            DialogResult rs = frm.ShowDialog();
            if (rs == DialogResult.OK)
            {
                pgGrid.SelectedObject = frm.prop;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            configTemplate config = HTemplates.LoadConfiguration();

            var rss = config.Templates.FirstOrDefault(item => item.Properties.NameTemplate == TemplateName);
            var prop = (propDatagridview)pgGrid.SelectedObject;

            if (rss == null)
            {
                TemplateDatagridview tp = iConvert.GetTemplate(TemplateName);
                prop.ToTemplateDatagridview(tp);
                //HTemplates.SaveConfiguration(config);
            }
            else
            {
                frmSaveTemplate frm = new frmSaveTemplate(config);
                DialogResult rs = frm.ShowDialog();

                if (rs == DialogResult.OK)
                {
                    foreach (var item in config.Templates)
                        item.Properties.Selected = false;

                    TemplateDatagridview tp = new TemplateDatagridview(frm.TemplateName, true);
                    tp.Language = "C#";
                    prop.ToTemplateDatagridview(tp);
                    config.Templates.Add(new Template
                    {
                        //TemplateName = frm.TemplateName,
                        Properties = tp
                    });
                    TemplateName = frm.TemplateName;
                }
            }
            HTemplates.SaveConfiguration(config);
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}