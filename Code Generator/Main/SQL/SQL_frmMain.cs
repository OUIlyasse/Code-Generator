using BL.Configs;
using BL.Helper;
using Code_Generator.Sub.SQL;
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
using UTIL;

namespace Code_Generator.Main.SQL
{
    public partial class SQL_frmMain : Form
    {
        #region Daclaration

        private string closeState;
        public bool IsClosed { get; set; } = false;

        public string CloseState
        {
            get { return closeState; }
            set
            {
                closeState = value;
                if (closeState == "NotClosed")
                    IsClosed = false;
                else
                    IsClosed = true;
            }
        }

        public dbInfo dbInfo { get; set; }
        public BL.iSQL.SQL SQL { get; set; }
        public BL.iCSharp.CSharp CSharp { get; set; }

        #endregion Daclaration

        #region Property

        public string TableName
        {
            get
            {
                return lblTable.Text.Substring(12);
            }
            set
            {
                lblTable.Text = $"Table/View: {value}";
            }
        }

        #endregion Property

        #region Codes

        private void setCheckBox()
        {
            configApp config = HConfigs.LoadConfiguration();
            switch (config.Crud)
            {
                case Crud.Parametre:
                    btnParameters.Checked = true;
                    break;

                default:
                    btnParameters.Checked = true;
                    break;
            }

            switch (config.Procedure)
            {
                case Procedure.Private:
                    btnPPrivate.Checked = true;
                    break;

                case Procedure.Public:
                    btnPPublic.Checked = true;
                    break;

                case Procedure.Internal:
                    btnPInternal.Checked = true;
                    break;

                default:
                    btnPPrivate.Checked = true;
                    break;
            }

            switch (config.Variable)
            {
                case Variable.Private:
                    btnVPrivate.Checked = true;
                    break;

                case Variable.Public:
                    btnVPublic.Checked = true;
                    break;

                case Variable.Internal:
                    btnVInternal.Checked = true;
                    break;

                default:
                    btnVPrivate.Checked = true;
                    break;
            }
        }

        private void FillEditor(string query, Language language)
        {
            ucEditor1.Editor.Text = query;
            ucEditor1.Syntaxe = language;
            tcResult.SelectedTab = tpResult;
        }

        private void newConnection()
        {
            frmRegisterDatabase frm = new frmRegisterDatabase();
            dbInfo = new dbInfo();
            HDbInfo.SaveConfiguration(dbInfo);
            CloseState = "";
            if (IsClosed)
            {
                Hide();
                frm.ShowDialog();
            }
        }

        private void setData()
        {
            lblDatabase.Text = $"Database: {dbInfo.DatabaseName}";
            lblTable.Text = "";

            LoadTables();
            LoadViews();
            LoadSP();

            LoadCount();
        }

        private void setTableOrView(string tbl)
        {
            lblTable.Text = $"Table/View: {tbl}";
        }

        private void LoadCount()
        {
            lblCount.Text = $"Table Count:{SQL.CountTables():00} | View Count:{SQL.CountViews():00} | SP Count:{SQL.CountSP():00}";
        }

        public void LoadSP()
        {
            SQL.SearchSP(dgvSP, txtSPSearch.Text);
            LoadCount();
        }

        public void LoadViews()
        {
            SQL.SearchView(dgvView, txtVSearch.Text);
            LoadCount();
        }

        public void LoadTables()
        {
            SQL.SearchTableName(dgvTable, txtTSearch.Text);
            LoadCount();
        }

        private void LoadFields(string table)
        {
            uc_Creating1.DataSource = SQL.getFields(table);
        }

        private void sMenuTable(bool status)
        {
            //btnTCreate.Visible = status;
            btnTUpdate.Visible = status;
            btnTDelete.Visible = status;
            btnTRename.Visible = status;
            toolStripSeparator4.Visible = status;
            btnTEditData.Visible = status;
            toolStripSeparator3.Visible = status;
            btnTScript.Visible = status;
            //toolStripSeparator5.Visible = status;
            //btnTRefresh.Visible = status;
        }

        private void sMenuView(bool status)
        {
            btnVUpdate.Visible = status;
            btnVDelete.Visible = status;
            btnVRename.Visible = status;
            toolStripSeparator6.Visible = status;
            btnVScript.Visible = status;
        }

        private void sMenuSP(bool status)
        {
            btnSPUpdate.Visible = status;
            btnSPDelete.Visible = status;
            btnSPRename.Visible = status;
            toolStripSeparator8.Visible = status;
            btnSPScript.Visible = status;
        }

        private void setResult(string titre, string result, Language type)
        {
            ucEditor1.Titre = titre;
            ucEditor1.Text = result;
            ucEditor1.Syntaxe = type;
        }

        public void showStatus(string text)
        {
            iMessage.infoMsg("", text);
        }

        #endregion Codes

        #region Constractors

        public SQL_frmMain()
        {
            InitializeComponent();
            dbInfo = HDbInfo.LoadConfiguration();
            SQL = new BL.iSQL.SQL(dbInfo.conString, dbInfo.DatabaseName);
            CSharp = new BL.iCSharp.CSharp(dbInfo.conString, dbInfo.DatabaseName);
            setCheckBox();
            CloseState = "";
        }

        #endregion Constractors

        #region Events

        #endregion Events

        private void SQL_frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseState == "NotClosed")
                IsClosed = false;
            else
                IsClosed = true;
        }

        private void SQL_frmMain_Load(object sender, EventArgs e)
        {
            setData();
            uc_Creating1.SQL = SQL;
            ucEditor1.FrmSQL = this;
            ucEditor1.Syntaxe = Language.Custom;
            uc_ShowData1.MyGrid = dgvShowData;
        }

        private void txtTSearch_TextChanged(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void txtVSearch_TextChanged(object sender, EventArgs e)
        {
            LoadViews();
        }

        private void txtSPSearch_TextChanged(object sender, EventArgs e)
        {
            LoadSP();
        }

        private void lblDatabase_ButtonDoubleClick(object sender, EventArgs e)
        {
            string str = lblDatabase.Text.Substring(10);
            if (!string.IsNullOrEmpty(str))
            {
                Clipboard.SetText(str);
                iMessage.infoMsg("Copied!", "");
            }
        }

        private void dgvTable_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            e.ContextMenuStrip = menuTable;
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                sMenuTable(false);
            else
                sMenuTable(true);
        }

        private void dgvView_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            e.ContextMenuStrip = menuView;
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                sMenuView(false);
            else
                sMenuView(true);
        }

        private void dgvSP_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            e.ContextMenuStrip = menuSP;
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                sMenuSP(false);
            else
                sMenuSP(true);
        }

        private void dgvTable_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2)
                {
                    string tbl = $"{dgvTable.Rows[e.RowIndex].Cells[colTable.Name].Value}";
                    LoadFields(tbl);
                    setTableOrView(tbl);
                    tcResult.SelectedTab = tpCreating;
                }
                if (e.Button == MouseButtons.Left && e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    var selectedCell = dgvTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    dgvTable.DoDragDrop(selectedCell, DragDropEffects.Move);
                }
                if (e.Button == MouseButtons.Right)
                {
                    dgvTable.CurrentCell = dgvTable[e.ColumnIndex, e.RowIndex];
                }
            }
        }

        private void dgvView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2)
                {
                    string tbl = $"{dgvView.Rows[e.RowIndex].Cells[colView.Name].Value}";
                    LoadFields(tbl);
                    setTableOrView(tbl);
                    tcResult.SelectedTab = tpCreating;
                }
                if (e.Button == MouseButtons.Left && e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    var selectedCell = dgvView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    dgvView.DoDragDrop(selectedCell, DragDropEffects.Move);
                }
                if (e.Button == MouseButtons.Right)
                {
                    dgvView.CurrentCell = dgvView[e.ColumnIndex, e.RowIndex];
                }
            }
        }

        private void dgvSP_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2)
                {
                    string tbl = $"{dgvSP.Rows[e.RowIndex].Cells[colStoredProcedure.Name].Value}";
                    string msg;
                    setResult($"{tbl}", SQL.Alter_SP(tbl, out msg), Language.SQL);
                    tcResult.SelectedTab = tpResult;
                    if (SQL.state == false)
                        showStatus(msg);
                }
                if (e.Button == MouseButtons.Left && e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    var selectedCell = dgvSP.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    dgvSP.DoDragDrop(selectedCell, DragDropEffects.Move);
                }
                if (e.Button == MouseButtons.Right)
                {
                    dgvSP.CurrentCell = dgvSP[e.ColumnIndex, e.RowIndex];
                }
            }
        }

        private void btnGetConnectionString_Click(object sender, EventArgs e)
        {
            frmGetConString frm = new frmGetConString();
            frm.Constring = dbInfo.conString;
            frm.ShowDialog();
        }

        private void btnNewConnection_Click(object sender, EventArgs e)
        {
            newConnection();
        }

        private void lblGenerateInformation_DoubleClick(object sender, EventArgs e)
        {
            frmGenerateInformation frm = new frmGenerateInformation();
            frm.TypeDatabase = Data.CompatibilityTypeDatabase[$"{dbInfo.TypeDatabase}"];
            frm.ServerName = dbInfo.ServerName;
            frm.Username = dbInfo.Username;
            frm.Password = dbInfo.Password;
            frm.Database = dbInfo.DatabaseName;
            frm.ShowDialog();
        }

        private void lblTable_DoubleClick(object sender, EventArgs e)
        {
            string str = lblTable.Text.Substring(12);
            if (!string.IsNullOrEmpty(str))
            {
                Clipboard.SetText(str);
                iMessage.infoMsg("Copied!", "");
            }
        }

        private void btnDatabaseInfo_Click(object sender, EventArgs e)
        {
            var rs = SQL.GetDatabaseInfo(dbInfo.conStringMaster);
            frmDatabaseInfo frm = new frmDatabaseInfo();
            frm.DatabaseName = rs.DatabaseName;
            frm.Owner_DB = rs.Owner;
            frm.DateCreated = $"{rs.DateCreated:dd/MM/yyyy}";
            frm.Collation = rs.Collation;
            frm.CompatibilityLevel = $"{rs.CompatibilityLevel}";
            frm.RestrictAccess = rs.RestrictAccess.ToString();
            frm.Files = rs.Files;
            frm.ShowDialog();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            newConnection();
        }

        private void btnDInsert_Click(object sender, EventArgs e)
        {
            Insert_SQL();
        }

        private void btnDUpdate_Click(object sender, EventArgs e)
        {
            Update_SQL();
        }

        private void btnDDelete_Click(object sender, EventArgs e)
        {
            Delete_SQL();
        }

        private void btnDSelect_Click(object sender, EventArgs e)
        {
            Select_SQL();
        }

        private void btnDMin_Click(object sender, EventArgs e)
        {
            MIN_SQL();
        }

        private void btnDMax_Click(object sender, EventArgs e)
        {
            MAX_SQL();
        }

        private void btnDCount_Click(object sender, EventArgs e)
        {
            COUNT_SQL();
        }

        private void btnDSum_Click(object sender, EventArgs e)
        {
            SUM_SQL();
        }

        private void btnDAvg_Click(object sender, EventArgs e)
        {
            AVG_SQL();
        }

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Search_SQL();
        }

        private void searchAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchAll_SQL();
        }

        private void searchBetweenDatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBetweenDate_SQL();
        }

        #region Menus

        #region Tables

        private void btnTCreate_Click(object sender, EventArgs e)
        {
            frmAddTable frm = new frmAddTable(this);
            frm.ShowDialog();
        }

        private void btnTUpdate_Click(object sender, EventArgs e)
        {
        }

        private void btnTDelete_Click(object sender, EventArgs e)
        {
            Delete_Table();
        }

        private void btnTRename_Click(object sender, EventArgs e)
        {
            Rename_Table();
        }

        private void btnTEditData_Click(object sender, EventArgs e)
        {
        }

        private void btnTScriptCreate_Click(object sender, EventArgs e)
        {
            Create_Table();
        }

        private void btnTScriptDrop_Click(object sender, EventArgs e)
        {
            Drop_Table();
        }

        private void btnTScriptDropAndCreate_Click(object sender, EventArgs e)
        {
            DropAndCreate_Table();
        }

        private void btnTRefresh_Click(object sender, EventArgs e)
        {
            LoadTables();
        }

        #endregion Tables

        #region Views

        private void btnVCreate_Click(object sender, EventArgs e)
        {
        }

        private void btnVUpdate_Click(object sender, EventArgs e)
        {
        }

        private void btnVDelete_Click(object sender, EventArgs e)
        {
            Delete_View();
        }

        private void btnVRename_Click(object sender, EventArgs e)
        {
            Rename_View();
        }

        private void btnVScriptCreate_Click(object sender, EventArgs e)
        {
            Create_View();
        }

        private void btnVScriptAlter_Click(object sender, EventArgs e)
        {
            Alter_View();
        }

        private void btnVScriptDrop_Click(object sender, EventArgs e)
        {
            Drop_View();
        }

        private void btnVScriptDropAndCreate_Click(object sender, EventArgs e)
        {
            DropAndCreate_View();
        }

        private void btnVRefresh_Click(object sender, EventArgs e)
        {
            LoadViews();
        }

        #endregion Views

        #region SP

        private void btnSPCreate_Click(object sender, EventArgs e)
        {
            New_SP();
        }

        private void btnSPUpdate_Click(object sender, EventArgs e)
        {
            Update_SP();
        }

        private void btnSPDelete_Click(object sender, EventArgs e)
        {
            Delete_SP();
        }

        private void btnSPRename_Click(object sender, EventArgs e)
        {
            Rename_SP();
        }

        private void btnSPScriptCreate_Click(object sender, EventArgs e)
        {
            Create_SP();
        }

        private void btnSPScriptAlter_Click(object sender, EventArgs e)
        {
            Update_SP();
        }

        private void btnSPScriptDrop_Click(object sender, EventArgs e)
        {
            Drop_SP();
        }

        private void btnSPScriptDropAndCreate_Click(object sender, EventArgs e)
        {
            DropAndCreate_SP();
        }

        private void btnSPRefresh_Click(object sender, EventArgs e)
        {
            LoadSP();
        }

        #endregion SP

        #endregion Menus

        private void btnParameters_CheckedChanged(object sender, EventArgs e)
        {
            var co = HConfigs.LoadConfiguration();
            if (btnParameters.Checked)
            {
                co.Crud = Crud.Parametre;
                btnParameters.Checked = true;
            }

            HConfigs.SaveConfiguration(co);
        }

        private void btnPPrivate_CheckedChanged(object sender, EventArgs e)
        {
            var co = HConfigs.LoadConfiguration();
            if (btnPPrivate.Checked)
            {
                co.Procedure = Procedure.Private;
                btnPPrivate.Checked = true;
                btnPPublic.Checked = false;
                btnPInternal.Checked = false;
            }
            //else if (btnPPublic.Checked)
            //{
            //    co.Procedure = Procedure.Public;
            //    btnPPrivate.Checked = false;
            //    btnPPublic.Checked = true;
            //    btnPInternal.Checked = false;
            //}
            //else if (btnPInternal.Checked)
            //{
            //    co.Procedure = Procedure.Internal;
            //    btnPPrivate.Checked = false;
            //    btnPPublic.Checked = false;
            //    btnPInternal.Checked = true;
            //}

            HConfigs.SaveConfiguration(co);
        }

        private void btnPPublic_CheckedChanged(object sender, EventArgs e)
        {
            var co = HConfigs.LoadConfiguration();

            if (btnPPublic.Checked)
            {
                co.Procedure = Procedure.Public;
                btnPPrivate.Checked = false;
                btnPPublic.Checked = true;
                btnPInternal.Checked = false;
            }

            HConfigs.SaveConfiguration(co);
        }

        private void btnPInternal_CheckedChanged(object sender, EventArgs e)
        {
            var co = HConfigs.LoadConfiguration();

            if (btnPInternal.Checked)
            {
                co.Procedure = Procedure.Internal;
                btnPPrivate.Checked = false;
                btnPPublic.Checked = false;
                btnPInternal.Checked = true;
            }

            HConfigs.SaveConfiguration(co);
        }

        private void btnVPrivate_CheckedChanged(object sender, EventArgs e)
        {
            var co = HConfigs.LoadConfiguration();
            if (btnVPrivate.Checked == true)
            {
                co.Variable = Variable.Private;
                btnVPrivate.Checked = true;
                btnVPublic.Checked = false;
                btnVInternal.Checked = false;
            }

            HConfigs.SaveConfiguration(co);
        }

        private void btnVPublic_CheckedChanged(object sender, EventArgs e)
        {
            var co = HConfigs.LoadConfiguration();

            if (btnVPublic.Checked == true)
            {
                co.Variable = Variable.Public;
                btnVPrivate.Checked = false;
                btnVPublic.Checked = true;
                btnVInternal.Checked = false;
            }

            HConfigs.SaveConfiguration(co);
        }

        private void btnVInternal_CheckedChanged(object sender, EventArgs e)
        {
            var co = HConfigs.LoadConfiguration();

            if (btnVInternal.Checked == true)
            {
                co.Variable = Variable.Internal;
                btnVPrivate.Checked = false;
                btnVPublic.Checked = false;
                btnVInternal.Checked = true;
            }

            HConfigs.SaveConfiguration(co);
        }

        #region Language Functions

        private void btnLFInsert_Click(object sender, EventArgs e)
        {
            Insert_LF();
        }

        private void btnLFUpdate_Click(object sender, EventArgs e)
        {
            Update_LF();
        }

        private void btnLFDelete_Click(object sender, EventArgs e)
        {
            Delete_LF();
        }

        private void btnLFSelect_Click(object sender, EventArgs e)
        {
            Select_LF();
        }

        private void btnLFMin_Click(object sender, EventArgs e)
        {
            MIN_LF();
        }

        private void btnLFMax_Click(object sender, EventArgs e)
        {
            MAX_LF();
        }

        private void btnLFCount_Click(object sender, EventArgs e)
        {
            COUNT_LF();
        }

        private void btnLFSum_Click(object sender, EventArgs e)
        {
            SUM_LF();
        }

        private void btnLFAvg_Click(object sender, EventArgs e)
        {
            AVG_LF();
        }

        private void btnLFSearch_Click(object sender, EventArgs e)
        {
            Search_LF();
        }

        private void btnLFSearchAll_Click(object sender, EventArgs e)
        {
            SearchAll_LF();
        }

        private void btnLFSearchBetweenDate_Click(object sender, EventArgs e)
        {
            SearchBetweenDate_LF();
        }

        private void btnLFVariables_Click(object sender, EventArgs e)
        {
            GenerateVariables();
        }

        private void btnLFProcedures_Click(object sender, EventArgs e)
        {
            GenerateFunctions();
        }

        #endregion Language Functions

        private void btnLFOpenConnection_Click(object sender, EventArgs e)
        {
            OpenConnection();
        }

        private void btnLFCloseConnection_Click(object sender, EventArgs e)
        {
            CloseConnection();
        }

        private void btnLFFillCombo_Click(object sender, EventArgs e)
        {
            FillCombo();
        }

        private void btnDControls_Click(object sender, EventArgs e)
        {
            CreateControls();
        }

        private void btnDDataGridView_Click(object sender, EventArgs e)
        {
            CreateDataGridView();
        }

        private void btnSnippets_Click(object sender, EventArgs e)
        {
            Snippets();
        }
    }
}