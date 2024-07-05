using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Code_Generator.Sub.SQL;
using BL.Configs;
using BL.Helper;
using Code_Generator.Sub.CSharp;

namespace Code_Generator.UC
{
    public partial class uc_Creating : UserControl
    {
        #region Daclaration

        private string tableName;
        private DataGridView gridView;
        private List<Events> evs;
        private BL.iSQL.SQL sql;

        #endregion Daclaration

        #region Property

        public BL.iSQL.SQL SQL
        {
            get { return sql; }
            set
            {
                sql = value;
                if (value != null)
                {
                    fieldItems();
                    dgvCreation.Invalidate();
                }
            }
        }

        public DataGridView MyGrid { get { return dgvCreation; } set { dgvCreation = value; AdjustColumnOrder(); ColoredColumns(); dgvCreation.Invalidate(); } }

        public Object DataSource
        {
            get
            { return dgvCreation.DataSource; }
            set
            {
                dgvCreation.DataSource = value;
                AdjustColumnOrder();
                ColoredColumns();
                dgvCreation.Invalidate();
                lblCount.Text = $"Count: {dgvCreation.Rows.Count:00}";
                ResetControls();
            }
        }

        public string TableName
        { get { return tableName; } }

        public List<Events> Event
        { get { return evs; } }

        public bool isCheckReccord { get; set; }

        public DataGridView GridView
        {
            get { return gridView; }
        }

        #endregion Property

        #region Codes

        private void ResetControls()
        {
            ckbSelectedAll.Checked = false;
            ckbWhereAll.Checked = false;
            ckbOrderAll.Checked = false;
            ckbGroupAll.Checked = false;
            ckbCheckReccord.Checked = false;
            txtTools.Text = string.Empty;
        }

        private void AdjustColumnOrder()
        {
            List<string> Columns = new List<string>
            {
              colColumnName.Name,
                colDataType.Name,
                colSize.Name,
                colPrimaryKey.Name,
                colIdentity.Name,
                colNullable.Name,
                colAlias.Name,
                colSelected.Name,
                colWhere.Name,
                colCheckReccord.Name,
                colOperator.Name,
                colOperatorCheck.Name,
                colGroupBy.Name,
                colOrderBy.Name,
                colOrder.Name,
                colFunction.Name,
                colToolbox.Name,
                colControlName.Name,
                colControlText.Name,
                colValue.Name,
                colDatasource.Name,
                colValueMember.Name,
                colDisplayMember.Name,
                colEvents.Name
            };

            Tools.Tools.OrganizeColumns(dgvCreation, Columns);
            colColumnName.Frozen = true;
            colDataType.Frozen = true;
        }

        private void ColoredColumns()
        {
            //dgvCreation.Columns[colColumnName.Name].DefaultCellStyle.BackColor = Color.Salmon;
            //dgvCreation.Columns[colDataType.Name].DefaultCellStyle.BackColor = Color.Salmon;
            //dgvCreation.Columns[colSize.Name].DefaultCellStyle.BackColor = Color.Salmon;
            //dgvCreation.Columns[colPrimaryKey.Name].DefaultCellStyle.BackColor = Color.Salmon;
            //dgvCreation.Columns[colIdentity.Name].DefaultCellStyle.BackColor = Color.Salmon;
            //dgvCreation.Columns[colNullable.Name].DefaultCellStyle.BackColor = Color.Salmon;
        }

        private void fieldItems()
        {
            //List<string> strFunction = new List<string>() { "None", "AGV", "CONCAT", "COUNT", "LCASE", "LOWER", "LTRIM", "MAX", "MIN", "REPLACE", "REVERSE", "SPACE", "SUBSTRING", "SUBSTRING_INDEX", "SUM", "UCASE", "UPPER" };
            List<string> strFunction = new List<string>() { "None", "COUNT", "LOWER", "LTRIM", "MAX", "MIN", "SUM", "UPPER" };
            List<string> strOrder = new List<string>() { "ASC", "DESC" };
            var config = HConfigs.LoadConfiguration();
            var list = config.Toolboxs;
            List<string> strings = new List<string>() { "=", "!=" };
            AutoCompleteStringCollection sourceName = new AutoCompleteStringCollection();
            foreach (Toolbox item in list)
            {
                sourceName.Add(item.NameToolbox);
                colToolbox.Items.Add(item.NameToolbox);
            }
            txtTools.AutoCompleteCustomSource = sourceName;

            //Load colDatasource
            foreach (string item in SQL.GetTable())
            {
                colDatasource.Items.Add(item);
            }
            //Load colOperatorCheck
            foreach (string item in strings)
            {
                colOperator.Items.Add(item);
            }
            //Load colAggregation
            foreach (string item in strFunction)
            {
                colFunction.Items.Add(item);
            }
            //Load colOrder
            foreach (string item in strOrder)
            {
                colOrder.Items.Add(item);
            }
        }

        private void fieldDisplayMember(string table)
        {
            colDisplayMember.Items.Clear();
            //Load colDisplayMember
            foreach (string item in SQL.getField(table))
            {
                colDisplayMember.Items.Add(item);
            }
        }

        private void fieldValueMember(string table)
        {
            colValueMember.Items.Clear();
            //Load colValueMember
            foreach (string item in SQL.getField(table))
            {
                colValueMember.Items.Add(item);
            }
        }

        private string returnControls(string ctrl, out bool result)
        {
            result = false;
            string rs = "";
            List<string> list = HConfigs.LoadConfiguration().Toolboxs.Select(p => p.NameToolbox).ToList();

            foreach (string str in list)
            {
                if (string.Equals(str, ctrl, StringComparison.OrdinalIgnoreCase))
                {
                    rs = str;
                    result = true;
                    break;
                }
            }

            return rs;
        }

        #endregion Codes

        #region Constractors

        public uc_Creating()
        {
            InitializeComponent();
            evs = new List<Events>();
        }

        public uc_Creating(BL.iSQL.SQL sQL) : this()
        {
            SQL = sQL;
            AdjustColumnOrder();

            string[] dataGridViewColumns = new string[7];
            dataGridViewColumns[0] = colColumnName.Name;
            dataGridViewColumns[1] = colDataType.Name;
            dataGridViewColumns[2] = colSize.Name;
            dataGridViewColumns[3] = colPrimaryKey.Name;
            dataGridViewColumns[4] = colIdentity.Name;
            dataGridViewColumns[5] = colNullable.Name;

            ColoredColumns();

            //Tools.ColorGrid(dgvCreation, dataGridViewColumns);
            //fieldItems();
        }

        #endregion Constractors

        #region Events

        #endregion Events

        private void ckbSelectedAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCreation.Rows)
                row.Cells[colSelected.Name].Value = ckbSelectedAll.CheckState;
        }

        private void ckbWhereAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCreation.Rows)
                row.Cells[colWhere.Name].Value = ckbWhereAll.Checked;
        }

        private void ckbGroupAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCreation.Rows)
                row.Cells[colGroupBy.Name].Value = ckbGroupAll.Checked;
        }

        private void ckbOrderAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCreation.Rows)
                row.Cells[colOrderBy.Name].Value = ckbOrderAll.Checked;
        }

        private void ckbCheckReccord_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCreation.Rows)
                row.Cells[colCheckReccord.Name].Value = ckbCheckReccord.Checked;
        }

        private void uc_Creating_Load(object sender, EventArgs e)
        {
        }

        private void txtTools_Validating(object sender, CancelEventArgs e)
        {
            bool rs;
            string val = returnControls(txtTools.Text, out rs);
            if (!string.IsNullOrWhiteSpace(txtTools.Text) && rs == true)
            {
                foreach (DataGridViewRow row in dgvCreation.Rows)
                    row.Cells[colToolbox.Name].Value = val;
            }
        }

        private void dgvCreation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvCreation.Columns[colEvents.Name].Index && dgvCreation[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                string control = Convert.ToString(dgvCreation[colToolbox.Name, e.RowIndex].Value);
                string field = Convert.ToString(dgvCreation[colColumnName.Name, e.RowIndex].Value);
                if (string.IsNullOrEmpty(control))
                {
                    MessageBox.Show("Please choose a control", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frmEvents frm;
                Events ev = evs.FirstOrDefault(item => item.Field == field);
                if (ev != null)
                    frm = new frmEvents(control, field, evs, ev);
                else
                    frm = new frmEvents(control, field, evs);

                frm.ShowDialog();
            }
        }

        private void dgvCreation_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvCreation.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;
            //Column DataSource
            if (e.ColumnIndex == dgvCreation.Columns[colDatasource.Name].Index)
            {
                if (dgvCreation.Rows[e.RowIndex].Cells[colDatasource.Name].Value == null || string.IsNullOrEmpty(dgvCreation.Rows[e.RowIndex].Cells[colDatasource.Name].Value.ToString()))
                    return;
                fieldValueMember(dgvCreation.Rows[e.RowIndex].Cells[colDatasource.Name].Value.ToString());
                fieldDisplayMember(dgvCreation.Rows[e.RowIndex].Cells[colDatasource.Name].Value.ToString());
            }
            if (e.ColumnIndex == dgvCreation.Columns[colToolbox.Name].Index)
            {
                if (dgvCreation.Rows[e.RowIndex].Cells[colToolbox.Name].Value == null || string.IsNullOrEmpty(dgvCreation.Rows[e.RowIndex].Cells[colToolbox.Name].Value.ToString()))
                    return;
                string cntrl = dgvCreation.Rows[e.RowIndex].Cells[colToolbox.Name].Value.ToString();
                string str = dgvCreation.Rows[e.RowIndex].Cells[colColumnName.Name].Value.ToString();

                var config = HConfigs.LoadConfiguration().Toolboxs.FirstOrDefault(x => x.NameToolbox.Equals(cntrl));

                dgvCreation.Rows[e.RowIndex].Cells[colControlName.Name].Value = Tools.Tools.ControlName($"{config.Prefix}_{str}");
                dgvCreation.Rows[e.RowIndex].Cells[colControlText.Name].Value = $"{str}";
                dgvCreation.Rows[e.RowIndex].Cells[colValue.Name].Value = $"{config.Value}";
            }
        }

        private void dgvCreation_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvCreation.Rows[e.RowIndex];
                if (selectedRow != null)
                {
                    //selectedRow.Cells[colCheckReccord.Name].ReadOnly = !ckbCheckReccord.Checked;

                    bool isEmptyColControlName;
                    if (selectedRow.Cells[colToolbox.Name].Value == null || string.IsNullOrEmpty(selectedRow.Cells[colToolbox.Name].Value.ToString()) || selectedRow.Cells[colToolbox.Name].Value.ToString() != "ComboBox")
                    {
                        isEmptyColControlName = false;
                    }
                    else
                        isEmptyColControlName = true;

                    selectedRow.Cells[colDatasource.Name].ReadOnly = !isEmptyColControlName;
                    //selectedRow.Cells[colEvents.Name].ReadOnly = !isEmptyColControlName;

                    bool isEmptyColDataSource;
                    if (selectedRow.Cells[colDatasource.Name].Value == null || string.IsNullOrEmpty(selectedRow.Cells[colDatasource.Name].Value.ToString()))
                        isEmptyColDataSource = false;
                    else
                        isEmptyColDataSource = true;

                    selectedRow.Cells[colDisplayMember.Name].ReadOnly = !isEmptyColDataSource;
                    selectedRow.Cells[colValueMember.Name].ReadOnly = !isEmptyColDataSource;

                    if (isEmptyColDataSource)
                    {
                        fieldValueMember(dgvCreation.Rows[e.RowIndex].Cells[colDatasource.Name].Value.ToString());
                        fieldDisplayMember(dgvCreation.Rows[e.RowIndex].Cells[colDatasource.Name].Value.ToString());
                    }
                }
            }
        }

        private void dgvCreation_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void dgvCreation_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void dgvCreation_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
        }
    }
}