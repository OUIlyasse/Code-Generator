using BL.PropertyGrid;
using BL.Configs;
using BL.Helper;
using Code_Generator.Main.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using UTIL;

namespace Code_Generator.Sub.SQL
{
    public partial class frmAddTable : Form
    {
        #region Variables

        private string collationColumn;
        private int rowIndex;

        #endregion Variables

        #region Propertie

        public Dictionary<int, Column> Columns { get; set; }
        public dbInfo dbInfo { get; set; }
        public BL.iSQL.SQL SQL { get; set; }
        public SQL_frmMain myForm { get; set; }

        #endregion Propertie

        #region Codes

        private bool isExistName(string name, int index)
        {
            bool valueExists = false;

            // Loop through each row in the specified column
            foreach (DataGridViewRow row in dgvCreation.Rows)
            {
                if (row.Cells[colColumn.Name].Value != null && row.Cells[colColumn.Name].Value.ToString() == name && row.Index != index)
                {
                    valueExists = true;
                    break;
                }
            }
            return valueExists;
        }

        private void fillCombox()
        {
            //DataType
            colDataType.Items.Clear();
            foreach (string dt in Data.DataTypeSQLServer())
            {
                colDataType.Items.Add(dt);
            }

            //Collation
            colCollation.Items.Clear();
            var rs = Data.CollationSQLServer();
            foreach (string dt in rs)
            {
                colCollation.Items.Add(dt);
            }
        }

        private void getCollation()
        {
        }

        #endregion Codes

        public frmAddTable(SQL_frmMain myForm)
        {
            InitializeComponent();
            this.myForm = myForm;
            dbInfo = HDbInfo.LoadConfiguration();
            SQL = new BL.iSQL.SQL(dbInfo.conString, dbInfo.DatabaseName);
            Columns = new Dictionary<int, Column>();
            fillCombox();
        }

        public frmAddTable(SQL_frmMain myForm, string collationColumn) : this(myForm)
        {
            this.collationColumn = collationColumn;
        }

        private void dgvTable_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            //e.Row.Cells[dgvCreation.Columns[colSize.Name].Index].Value = "";
            //e.Row.Cells[dgvCreation.Columns[colCollation.Name].Index].Value = collationColumn;
            //if (e.Row.Index == 0)
            //{
            //    e.Row.Cells[dgvCreation.Columns[colSize.Name].Index].ReadOnly = true;
            //    e.Row.Cells[dgvCreation.Columns[colMax.Name].Index].ReadOnly = true;
            //    e.Row.Cells[dgvCreation.Columns[colPrimaryKey.Name].Index].ReadOnly = true;
            //    e.Row.Cells[dgvCreation.Columns[colIdentity.Name].Index].ReadOnly = true;
            //    e.Row.Cells[dgvCreation.Columns[colNull.Name].Index].ReadOnly = true;
            //    e.Row.Cells[dgvCreation.Columns[colUnique.Name].Index].ReadOnly = true;
            //    e.Row.Cells[dgvCreation.Columns[colDefaultValue.Name].Index].ReadOnly = true;

            //    e.Row.Cells[dgvCreation.Columns[colPrimaryKey.Name].Index].Value = true;
            //    e.Row.Cells[dgvCreation.Columns[colNull.Name].Index].Value = false;
            //}
            //else
            //{
            //    e.Row.Cells[dgvCreation.Columns[colSize.Name].Index].ReadOnly = false;
            //    e.Row.Cells[dgvCreation.Columns[colMax.Name].Index].ReadOnly = false;
            //    e.Row.Cells[dgvCreation.Columns[colPrimaryKey.Name].Index].ReadOnly = false;
            //    e.Row.Cells[dgvCreation.Columns[colIdentity.Name].Index].ReadOnly = false;
            //    e.Row.Cells[dgvCreation.Columns[colNull.Name].Index].ReadOnly = false;
            //    e.Row.Cells[dgvCreation.Columns[colUnique.Name].Index].ReadOnly = false;
            //    e.Row.Cells[dgvCreation.Columns[colDefaultValue.Name].Index].ReadOnly = false;

            //    e.Row.Cells[dgvCreation.Columns[colPrimaryKey.Name].Index].Value = false;
            //    e.Row.Cells[dgvCreation.Columns[colNull.Name].Index].Value = true;
            //}
        }

        private void dgvTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCreation.Columns[e.ColumnIndex].Name == colImage.Name)
            {
                if (e.RowIndex != dgvCreation.NewRowIndex)
                {
                    //bool rs = Convert.ToBoolean(dgvCreation.Rows[e.RowIndex].Cells[colPrimaryKey.Name].Value);
                    //if (rs == true)
                    //    e.Value = Properties.Resources.Primary_Key_24;
                    //else
                    //    e.Value = new Bitmap(24, 24);
                }
                if (dgvCreation.Columns[e.ColumnIndex].Name == colDefaultValue.Name)
                {
                    string rs = $"{dgvCreation.Rows[e.RowIndex].Cells[colDefaultValue.Name].Value}";
                    if (!string.IsNullOrEmpty(rs))
                    {
                        string r;
                        if (rs.Contains("N'"))
                            r = rs.Substring(2, rs.Length - 3);
                        else
                            r = rs;

                        e.Value = $"N'{r}'";
                    }
                    else
                        e.Value = "";
                }
            }
        }

        private void dgvTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != dgvCreation.NewRowIndex)
            {
                dgvCreation.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;

                //Column DataType
                if (e.ColumnIndex == dgvCreation.Columns[colDataType.Name].Index)
                {
                    string dt = dgvCreation.Rows[e.RowIndex].Cells[colDataType.Name].Value.ToString();
                    if (dt != null)
                    {
                        if (Data.DataTypeSQLServerStrings().Contains(dt))
                        {
                            dgvCreation.Rows[e.RowIndex].Cells[colSize.Name].ReadOnly = false;
                            const string s1 = "10";
                            const string s2 = "50";
                            if (dt.Equals("char") || dt.Equals("nchar"))
                            {
                                dgvCreation.Rows[e.RowIndex].Cells[colMax.Name].ReadOnly = true;
                                dgvCreation.Rows[e.RowIndex].Cells[colSize.Name].Value = s1;
                            }
                            else
                            {
                                dgvCreation.Rows[e.RowIndex].Cells[colMax.Name].ReadOnly = false;
                                dgvCreation.Rows[e.RowIndex].Cells[colSize.Name].Value = s2;
                            }
                        }
                        else
                        {
                            dgvCreation.Rows[e.RowIndex].Cells[colSize.Name].ReadOnly = true;
                            dgvCreation.Rows[e.RowIndex].Cells[colMax.Name].ReadOnly = true;
                            dgvCreation.Rows[e.RowIndex].Cells[colSize.Name].Value = "";
                        }

                        if (Data.DataTypeSQLServerNumeric().Contains(dt))
                        {
                            dgvCreation.Rows[e.RowIndex].Cells[colIdentity.Name].ReadOnly = false;
                            dgvCreation.Rows[e.RowIndex].Cells[colIdentity.Name].Value = false;
                        }
                        else
                        {
                            dgvCreation.Rows[e.RowIndex].Cells[colIdentity.Name].ReadOnly = true;
                            dgvCreation.Rows[e.RowIndex].Cells[colIdentity.Name].Value = false;
                        }
                    }
                }

                //PropertyGrid
                Column col = new Column();
                try
                {
                    if (dgvCreation.SelectedRows.Count > 0)
                    {
                        DataGridViewRow clickedRow = dgvCreation.SelectedRows[0];

                        string colName;
                        if (clickedRow.Cells[colColumn.Name].Value == null || string.IsNullOrEmpty(clickedRow.Cells[colColumn.Name].Value.ToString()))
                            colName = "";
                        else
                            colName = clickedRow.Cells[colColumn.Name].Value.ToString();

                        bool colAllowNull;
                        if (clickedRow.Cells[colNull.Name].Value == null || Convert.ToBoolean(clickedRow.Cells[colNull.Name].Value) == false)
                            colAllowNull = false;
                        else
                            colAllowNull = true;

                        string dataType;
                        if (clickedRow.Cells[colDataType.Name].Value == null || string.IsNullOrEmpty(clickedRow.Cells[colDataType.Name].Value.ToString()))
                            dataType = "";
                        else
                            dataType = clickedRow.Cells[colDataType.Name].Value.ToString();

                        string defaultValue;
                        if (clickedRow.Cells[colDefaultValue.Name].Value == null || string.IsNullOrEmpty(clickedRow.Cells[colDefaultValue.Name].Value.ToString()))
                            defaultValue = "";
                        else
                            defaultValue = clickedRow.Cells[colDefaultValue.Name].Value.ToString();

                        bool isIdentity;
                        if (clickedRow.Cells[colIdentity.Name].Value == null || Convert.ToBoolean(clickedRow.Cells[colIdentity.Name].Value) == false)
                            isIdentity = false;
                        else
                            isIdentity = true;

                        string size;
                        if (clickedRow.Cells[colSize.Name].Value == null || string.IsNullOrEmpty(clickedRow.Cells[colSize.Name].Value.ToString()))
                            size = "";
                        else
                            size = clickedRow.Cells[colSize.Name].Value.ToString();

                        string tt = "";
                        if (string.IsNullOrEmpty(dataType))
                            tt = "";
                        else
                        {
                            if (Data.DataTypeSQLServerNumeric().Contains(dataType))
                                tt = "1";
                            else if (Data.DataTypeSQLServerStrings().Contains(dataType))
                                tt = "";
                        }

                        col = new Column
                        {
                            Name = colName,
                            AllowNull = colAllowNull,
                            DataType = (DataTypeForSQLServer)Enum.Parse(typeof(DataTypeForSQLServer), dataType.ToUpper()),
                            DefaultValue = defaultValue,
                            Collation = (Data.CollationSQL)Enum.Parse(typeof(Data.CollationSQL), collationColumn),
                            Formule = "",
                            Description = "",
                            IsIdentity = isIdentity,
                            IdentityIncrement = tt,
                            IdentitySpeed = tt,
                            Size = size
                        };
                        pgColumnsInfo.SelectedObject = col;
                    }
                    else
                        pgColumnsInfo.SelectedObject = col;
                }
                catch (Exception)
                {
                    pgColumnsInfo.SelectedObject = col;
                }
            }
        }

        private void dgvTable_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex != dgvCreation.NewRowIndex)
            {
                foreach (DataGridViewColumn item in dgvCreation.Columns)
                {
                    if (item.Index == dgvCreation.Columns[colColumn.Name].Index)
                    {
                        var cellData = dgvCreation.Rows[e.RowIndex].Cells[item.Index].Value;

                        if (cellData == null || string.IsNullOrWhiteSpace(cellData.ToString()))
                        {
                            dgvCreation.Rows[e.RowIndex].Cells[item.Index].ErrorText = "Please fill in the specific cell.";
                            e.Cancel = true;
                            return;
                        }
                    }

                    if (item.Index == dgvCreation.Columns[colDataType.Name].Index)
                    {
                        var cellData = dgvCreation.Rows[e.RowIndex].Cells[item.Index].Value;

                        if (cellData == null || string.IsNullOrWhiteSpace(cellData.ToString()))
                        {
                            dgvCreation.Rows[e.RowIndex].Cells[item.Index].ErrorText = "Please fill in the specific cell.";
                            e.Cancel = true;
                            return;
                        }
                        //else
                        //    col.DataType = (Utils.Utils.DataTypeForSQLServer)Enum.Parse(typeof(Utils.Utils.DataTypeForSQLServer), cellData.ToString().ToUpper());
                    }

                    if (item.Index == dgvCreation.Columns[colSize.Name].Index)
                    {
                        var cellData = dgvCreation.Rows[e.RowIndex].Cells[item.Index].Value;
                        string cellDataType = dgvCreation.Rows[e.RowIndex].Cells[colDataType.Name].Value.ToString();

                        if (Data.DataTypeSQLServerStrings().Contains(cellDataType))
                        {
                            if (cellData == null || string.IsNullOrWhiteSpace(cellData.ToString()))
                            {
                                dgvCreation.Rows[e.RowIndex].Cells[item.Index].ErrorText = "Please fill in the specific cell.";
                                e.Cancel = true;
                                return;
                            }
                        }
                    }
                }

                //Field Name
                string coll = dgvCreation.Rows[e.RowIndex].Cells[colColumn.Name].Value.ToString();
                if (isExistName(coll, e.RowIndex))
                {
                    dgvCreation.Rows[e.RowIndex].Cells[colColumn.Name].ErrorText = "Change Column name.";
                    e.Cancel = true;
                    return;
                }
                DataGridViewRow row = dgvCreation.Rows[e.RowIndex];
                rowIndex = row.Index;
                bool anull;
                if (row.Cells[colNull.Name].Value == null || Convert.ToBoolean(row.Cells[colNull.Name].Value.ToString()) == false)
                    anull = false;
                else
                    anull = true;

                string dv;
                if (row.Cells[colDefaultValue.Name].Value == null || string.IsNullOrWhiteSpace(row.Cells[colDefaultValue.Name].Value.ToString()))
                    dv = "";
                else
                    dv = row.Cells[colDefaultValue.Name].Value.ToString();
                string v = row.Cells[colColumn.Name].Value.ToString();
                DataTypeForSQLServer dataTypeForSQLServer = (DataTypeForSQLServer)Enum.Parse(typeof(DataTypeForSQLServer), row.Cells[colDataType.Name].Value.ToString().ToUpper());

                string c = SQL.GetDatabaseInfo(dbInfo.conStringMaster).Collation;
                Data.CollationSQL collationSQL;

                if (row.Cells[colCollation.Name].Value == null || string.IsNullOrWhiteSpace(row.Cells[colCollation.Name].Value.ToString()))
                    collationSQL = (Data.CollationSQL)Enum.Parse(typeof(Data.CollationSQL), c);
                else
                    collationSQL = (Data.CollationSQL)Enum.Parse(typeof(Data.CollationSQL), row.Cells[colCollation.Name].Value.ToString());

                Column col1 = (Column)pgColumnsInfo.SelectedObject;
                Column col = new Column()
                {
                    Name = v,
                    AllowNull = anull,
                    DataType = dataTypeForSQLServer,
                    DefaultValue = dv,
                    Collation = collationSQL
                };

                if (Columns.ContainsKey(rowIndex))
                {
                    Columns.Remove(rowIndex);
                    Columns.Add(rowIndex, col1);
                }
                else
                    Columns.Add(rowIndex, col1);
            }
        }

        private void dgvTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvTable_SelectionChanged(object sender, EventArgs e)
        {
            //PropertyGrid
            Column col = new Column();
            try
            {
                if (dgvCreation.SelectedRows.Count > 0)
                {
                    DataGridViewRow clickedRow = dgvCreation.SelectedRows[0];

                    string colName;
                    if (clickedRow.Cells[colColumn.Name].Value == null || string.IsNullOrEmpty(clickedRow.Cells[colColumn.Name].Value.ToString()))
                        colName = "";
                    else
                        colName = clickedRow.Cells[colColumn.Name].Value.ToString();

                    bool colAllowNull;
                    if (clickedRow.Cells[colNull.Name].Value == null || Convert.ToBoolean(clickedRow.Cells[colNull.Name].Value) == false)
                        colAllowNull = false;
                    else
                        colAllowNull = true;

                    string dataType;
                    if (clickedRow.Cells[colDataType.Name].Value == null || string.IsNullOrEmpty(clickedRow.Cells[colDataType.Name].Value.ToString()))
                        dataType = "";
                    else
                        dataType = clickedRow.Cells[colDataType.Name].Value.ToString();

                    string defaultValue;
                    if (clickedRow.Cells[colDefaultValue.Name].Value == null || string.IsNullOrEmpty(clickedRow.Cells[colDefaultValue.Name].Value.ToString()))
                        defaultValue = "";
                    else
                        defaultValue = clickedRow.Cells[colDefaultValue.Name].Value.ToString();

                    bool isIdentity;
                    if (clickedRow.Cells[colIdentity.Name].Value == null || Convert.ToBoolean(clickedRow.Cells[colIdentity.Name].Value) == false)
                        isIdentity = false;
                    else
                        isIdentity = true;

                    string size;
                    if (clickedRow.Cells[colSize.Name].Value == null || string.IsNullOrEmpty(clickedRow.Cells[colSize.Name].Value.ToString()))
                        size = "";
                    else
                        size = clickedRow.Cells[colSize.Name].Value.ToString();

                    string tt = "";
                    if (string.IsNullOrEmpty(dataType))
                        tt = "";
                    else
                    {
                        if (Data.DataTypeSQLServerNumeric().Contains(dataType))
                            tt = "1";
                        else if (Data.DataTypeSQLServerStrings().Contains(dataType))
                            tt = "";
                    }

                    col = new Column
                    {
                        Name = colName,
                        AllowNull = colAllowNull,
                        DataType = (DataTypeForSQLServer)Enum.Parse(typeof(DataTypeForSQLServer), dataType.ToUpper()),
                        DefaultValue = defaultValue,
                        Collation = (Data.CollationSQL)Enum.Parse(typeof(Data.CollationSQL), collationColumn),
                        Formule = "",
                        Description = "",
                        IsIdentity = isIdentity,
                        IdentityIncrement = tt,
                        IdentitySpeed = tt,
                        Size = size
                    };
                    pgColumnsInfo.SelectedObject = col;
                }
                else
                    pgColumnsInfo.SelectedObject = col;
            }
            catch (Exception)
            {
                pgColumnsInfo.SelectedObject = col;
            }
        }

        private void pgColumnsInfo_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            Column rs = (Column)pgColumnsInfo.SelectedObject;

            DataGridViewRow row = dgvCreation.SelectedRows[0];

            row.Cells[colColumn.Name].Value = rs.Name;
            row.Cells[colDataType.Name].Value = rs.DataType.ToList();
            row.Cells[colSize.Name].Value = rs.Size;

            DataGridViewCheckBoxCell cellPrimaryKey = dgvCreation.Rows[dgvCreation.CurrentRow.Index].Cells[colPrimaryKey.Name] as DataGridViewCheckBoxCell;
            if (cellPrimaryKey != null)
                cellPrimaryKey.Value = rs.IsPrimaryKey;

            DataGridViewCheckBoxCell cellIdentity = dgvCreation.Rows[dgvCreation.CurrentRow.Index].Cells[colIdentity.Name] as DataGridViewCheckBoxCell;
            if (cellIdentity != null)
                cellIdentity.Value = rs.IsIdentity;

            DataGridViewCheckBoxCell cellNull = dgvCreation.Rows[dgvCreation.CurrentRow.Index].Cells[colNull.Name] as DataGridViewCheckBoxCell;
            if (cellNull != null)
                cellNull.Value = rs.AllowNull;

            row.Cells[colDefaultValue.Name].Value = rs.DefaultValue;
            row.Cells[colCollation.Name].Value = rs.Collation;
        }

        private void dgvCreation_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void frmAddTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                string msg = "";
                frmSave frm = new frmSave("Save table", "Table1");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    SQL.Create_Table(frm.TextChange, Columns, out msg);
                    if (SQL.state)
                        myForm.showStatus(msg);
                    e.SuppressKeyPress = true; // Prevent the key event from being passed to the focused control
                }
            }
        }

        private void frmAddTable_Load(object sender, EventArgs e)
        {
        }
    }
}