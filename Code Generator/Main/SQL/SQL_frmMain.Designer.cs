namespace Code_Generator.Main.SQL
{
    partial class SQL_frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQL_frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            BL.Configs.dbInfo dbInfo1 = new BL.Configs.dbInfo();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            BL.Configs.dbInfo dbInfo2 = new BL.Configs.dbInfo();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.databaseConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGetConnectionString = new System.Windows.Forms.ToolStripMenuItem();
            this.snippetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSnippets = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseFunctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTryCatch = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTransaction = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.aggregateFunctionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDMin = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDMax = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDCount = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDSum = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDAvg = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.searchAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchBetweenDatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageFunctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cRUDStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnParameters = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPPrivate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPPublic = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPInternal = new System.Windows.Forms.ToolStripMenuItem();
            this.privateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVPrivate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVPublic = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVInternal = new System.Windows.Forms.ToolStripMenuItem();
            this.generatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLFVariables = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLFProcedures = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLFEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.autherProceduresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLFOpenConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLFCloseConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLFFillCombo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLFInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLFUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLFDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLFSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLFMin = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLFMax = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLFCount = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLFSum = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLFAvg = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLFSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLFSearchAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLFSearchBetweenDate = new System.Windows.Forms.ToolStripMenuItem();
            this.designerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDControls = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDDataGridView = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allLanguageFunctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblGenerateInformation = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDatabase = new System.Windows.Forms.ToolStripSplitButton();
            this.btnDatabaseInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTable = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuSP = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnSPCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSPUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSPDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSPRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSPScript = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSPScriptCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSPScriptAlter = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSPScriptDrop = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSPScriptDropAndCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSPRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnVCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnVScript = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVScriptCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVScriptAlter = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVScriptDrop = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVScriptDropAndCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnVRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnTCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTEditData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTScript = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTScriptCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTScriptDrop = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTScriptDropAndCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpTables = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.colTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTSearch = new System.Windows.Forms.TextBox();
            this.tpViews = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.colView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViewText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtVSearch = new System.Windows.Forms.TextBox();
            this.tpSP = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvSP = new System.Windows.Forms.DataGridView();
            this.colStoredProcedure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSPSearch = new System.Windows.Forms.TextBox();
            this.tcResult = new System.Windows.Forms.TabControl();
            this.tpCreating = new System.Windows.Forms.TabPage();
            this.uc_Creating1 = new Code_Generator.UC.uc_Creating();
            this.tpResult = new System.Windows.Forms.TabPage();
            this.ucEditor1 = new Code_Generator.UC.ucEditor();
            this.tpShowData = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvShowData = new System.Windows.Forms.DataGridView();
            this.uc_ShowData1 = new Code_Generator.UC.uc_ShowData();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuSP.SuspendLayout();
            this.menuView.SuspendLayout();
            this.menuTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpTables.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.tpViews.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.tpSP.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).BeginInit();
            this.tcResult.SuspendLayout();
            this.tpCreating.SuspendLayout();
            this.tpResult.SuspendLayout();
            this.tpShowData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowData)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseConnectionToolStripMenuItem,
            this.snippetsToolStripMenuItem,
            this.databaseFunctionsToolStripMenuItem,
            this.languageFunctionsToolStripMenuItem,
            this.designerToolStripMenuItem,
            this.generateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // databaseConnectionToolStripMenuItem
            // 
            this.databaseConnectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewConnection,
            this.btnGetConnectionString});
            this.databaseConnectionToolStripMenuItem.Name = "databaseConnectionToolStripMenuItem";
            this.databaseConnectionToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.databaseConnectionToolStripMenuItem.Text = "Connection";
            // 
            // btnNewConnection
            // 
            this.btnNewConnection.Name = "btnNewConnection";
            this.btnNewConnection.Size = new System.Drawing.Size(228, 26);
            this.btnNewConnection.Text = "New Connection";
            this.btnNewConnection.Click += new System.EventHandler(this.btnNewConnection_Click);
            // 
            // btnGetConnectionString
            // 
            this.btnGetConnectionString.Name = "btnGetConnectionString";
            this.btnGetConnectionString.Size = new System.Drawing.Size(228, 26);
            this.btnGetConnectionString.Text = "Get Connection String";
            this.btnGetConnectionString.Click += new System.EventHandler(this.btnGetConnectionString_Click);
            // 
            // snippetsToolStripMenuItem
            // 
            this.snippetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSnippets});
            this.snippetsToolStripMenuItem.Name = "snippetsToolStripMenuItem";
            this.snippetsToolStripMenuItem.Size = new System.Drawing.Size(77, 22);
            this.snippetsToolStripMenuItem.Text = "Snippets";
            // 
            // btnSnippets
            // 
            this.btnSnippets.Name = "btnSnippets";
            this.btnSnippets.Size = new System.Drawing.Size(139, 26);
            this.btnSnippets.Text = "Snippets";
            this.btnSnippets.Click += new System.EventHandler(this.btnSnippets_Click);
            // 
            // databaseFunctionsToolStripMenuItem
            // 
            this.databaseFunctionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modeToolStripMenuItem1,
            this.btnDInsert,
            this.btnDUpdate,
            this.btnDDelete,
            this.btnDSelect,
            this.aggregateFunctionToolStripMenuItem,
            this.searchToolStripMenuItem});
            this.databaseFunctionsToolStripMenuItem.Name = "databaseFunctionsToolStripMenuItem";
            this.databaseFunctionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.databaseFunctionsToolStripMenuItem.Text = "Database Functions";
            // 
            // modeToolStripMenuItem1
            // 
            this.modeToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTryCatch,
            this.btnTransaction});
            this.modeToolStripMenuItem1.Name = "modeToolStripMenuItem1";
            this.modeToolStripMenuItem1.Size = new System.Drawing.Size(209, 26);
            this.modeToolStripMenuItem1.Text = "Mode";
            this.modeToolStripMenuItem1.Visible = false;
            // 
            // btnTryCatch
            // 
            this.btnTryCatch.CheckOnClick = true;
            this.btnTryCatch.Name = "btnTryCatch";
            this.btnTryCatch.Size = new System.Drawing.Size(160, 26);
            this.btnTryCatch.Text = "Try-Catch";
            // 
            // btnTransaction
            // 
            this.btnTransaction.CheckOnClick = true;
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(160, 26);
            this.btnTransaction.Text = "Transaction";
            // 
            // btnDInsert
            // 
            this.btnDInsert.Name = "btnDInsert";
            this.btnDInsert.Size = new System.Drawing.Size(209, 26);
            this.btnDInsert.Text = "Insert";
            this.btnDInsert.Click += new System.EventHandler(this.btnDInsert_Click);
            // 
            // btnDUpdate
            // 
            this.btnDUpdate.Name = "btnDUpdate";
            this.btnDUpdate.Size = new System.Drawing.Size(209, 26);
            this.btnDUpdate.Text = "Update";
            this.btnDUpdate.Click += new System.EventHandler(this.btnDUpdate_Click);
            // 
            // btnDDelete
            // 
            this.btnDDelete.Name = "btnDDelete";
            this.btnDDelete.Size = new System.Drawing.Size(209, 26);
            this.btnDDelete.Text = "Delete";
            this.btnDDelete.Click += new System.EventHandler(this.btnDDelete_Click);
            // 
            // btnDSelect
            // 
            this.btnDSelect.Name = "btnDSelect";
            this.btnDSelect.Size = new System.Drawing.Size(209, 26);
            this.btnDSelect.Text = "Select";
            this.btnDSelect.Click += new System.EventHandler(this.btnDSelect_Click);
            // 
            // aggregateFunctionToolStripMenuItem
            // 
            this.aggregateFunctionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDMin,
            this.btnDMax,
            this.btnDCount,
            this.btnDSum,
            this.btnDAvg});
            this.aggregateFunctionToolStripMenuItem.Name = "aggregateFunctionToolStripMenuItem";
            this.aggregateFunctionToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.aggregateFunctionToolStripMenuItem.Text = "Aggregate Function";
            // 
            // btnDMin
            // 
            this.btnDMin.Name = "btnDMin";
            this.btnDMin.Size = new System.Drawing.Size(136, 26);
            this.btnDMin.Text = "MIN";
            this.btnDMin.Click += new System.EventHandler(this.btnDMin_Click);
            // 
            // btnDMax
            // 
            this.btnDMax.Name = "btnDMax";
            this.btnDMax.Size = new System.Drawing.Size(136, 26);
            this.btnDMax.Text = "MAX";
            this.btnDMax.Click += new System.EventHandler(this.btnDMax_Click);
            // 
            // btnDCount
            // 
            this.btnDCount.Name = "btnDCount";
            this.btnDCount.Size = new System.Drawing.Size(136, 26);
            this.btnDCount.Text = "COUNT";
            this.btnDCount.Click += new System.EventHandler(this.btnDCount_Click);
            // 
            // btnDSum
            // 
            this.btnDSum.Name = "btnDSum";
            this.btnDSum.Size = new System.Drawing.Size(136, 26);
            this.btnDSum.Text = "SUM";
            this.btnDSum.Click += new System.EventHandler(this.btnDSum_Click);
            // 
            // btnDAvg
            // 
            this.btnDAvg.Name = "btnDAvg";
            this.btnDAvg.Size = new System.Drawing.Size(136, 26);
            this.btnDAvg.Text = "AVG";
            this.btnDAvg.Click += new System.EventHandler(this.btnDAvg_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem1,
            this.searchAllToolStripMenuItem,
            this.searchBetweenDatesToolStripMenuItem});
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.searchToolStripMenuItem.Text = "Search";
            // 
            // searchToolStripMenuItem1
            // 
            this.searchToolStripMenuItem1.Name = "searchToolStripMenuItem1";
            this.searchToolStripMenuItem1.Size = new System.Drawing.Size(233, 26);
            this.searchToolStripMenuItem1.Text = "Search";
            this.searchToolStripMenuItem1.Click += new System.EventHandler(this.searchToolStripMenuItem1_Click);
            // 
            // searchAllToolStripMenuItem
            // 
            this.searchAllToolStripMenuItem.Name = "searchAllToolStripMenuItem";
            this.searchAllToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.searchAllToolStripMenuItem.Text = "Search All";
            this.searchAllToolStripMenuItem.Click += new System.EventHandler(this.searchAllToolStripMenuItem_Click);
            // 
            // searchBetweenDatesToolStripMenuItem
            // 
            this.searchBetweenDatesToolStripMenuItem.Name = "searchBetweenDatesToolStripMenuItem";
            this.searchBetweenDatesToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.searchBetweenDatesToolStripMenuItem.Text = "Search Between Dates";
            this.searchBetweenDatesToolStripMenuItem.Click += new System.EventHandler(this.searchBetweenDatesToolStripMenuItem_Click);
            // 
            // languageFunctionsToolStripMenuItem
            // 
            this.languageFunctionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modeToolStripMenuItem,
            this.generatorToolStripMenuItem,
            this.toolStripSeparator1,
            this.autherProceduresToolStripMenuItem,
            this.toolStripSeparator2,
            this.btnLFInsert,
            this.btnLFUpdate,
            this.btnLFDelete,
            this.btnLFSelect,
            this.toolStripMenuItem1,
            this.toolStripMenuItem7});
            this.languageFunctionsToolStripMenuItem.Name = "languageFunctionsToolStripMenuItem";
            this.languageFunctionsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.languageFunctionsToolStripMenuItem.Text = "Language Functions";
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cRUDStatementToolStripMenuItem,
            this.toolStripMenuItem13,
            this.privateToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // cRUDStatementToolStripMenuItem
            // 
            this.cRUDStatementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnParameters});
            this.cRUDStatementToolStripMenuItem.Name = "cRUDStatementToolStripMenuItem";
            this.cRUDStatementToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.cRUDStatementToolStripMenuItem.Text = "CRUD Statement";
            // 
            // btnParameters
            // 
            this.btnParameters.CheckOnClick = true;
            this.btnParameters.Name = "btnParameters";
            this.btnParameters.Size = new System.Drawing.Size(159, 26);
            this.btnParameters.Text = "Parameters";
            this.btnParameters.CheckedChanged += new System.EventHandler(this.btnParameters_CheckedChanged);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPPrivate,
            this.btnPPublic,
            this.btnPInternal});
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(197, 26);
            this.toolStripMenuItem13.Text = "Procedures";
            // 
            // btnPPrivate
            // 
            this.btnPPrivate.CheckOnClick = true;
            this.btnPPrivate.Name = "btnPPrivate";
            this.btnPPrivate.Size = new System.Drawing.Size(129, 26);
            this.btnPPrivate.Text = "private";
            this.btnPPrivate.CheckedChanged += new System.EventHandler(this.btnPPrivate_CheckedChanged);
            // 
            // btnPPublic
            // 
            this.btnPPublic.CheckOnClick = true;
            this.btnPPublic.Name = "btnPPublic";
            this.btnPPublic.Size = new System.Drawing.Size(129, 26);
            this.btnPPublic.Text = "public";
            this.btnPPublic.CheckedChanged += new System.EventHandler(this.btnPPublic_CheckedChanged);
            // 
            // btnPInternal
            // 
            this.btnPInternal.CheckOnClick = true;
            this.btnPInternal.Name = "btnPInternal";
            this.btnPInternal.Size = new System.Drawing.Size(129, 26);
            this.btnPInternal.Text = "internal";
            this.btnPInternal.CheckedChanged += new System.EventHandler(this.btnPInternal_CheckedChanged);
            // 
            // privateToolStripMenuItem
            // 
            this.privateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnVPrivate,
            this.btnVPublic,
            this.btnVInternal});
            this.privateToolStripMenuItem.Name = "privateToolStripMenuItem";
            this.privateToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.privateToolStripMenuItem.Text = "Variables";
            // 
            // btnVPrivate
            // 
            this.btnVPrivate.CheckOnClick = true;
            this.btnVPrivate.Name = "btnVPrivate";
            this.btnVPrivate.Size = new System.Drawing.Size(129, 26);
            this.btnVPrivate.Text = "private";
            this.btnVPrivate.CheckedChanged += new System.EventHandler(this.btnVPrivate_CheckedChanged);
            // 
            // btnVPublic
            // 
            this.btnVPublic.CheckOnClick = true;
            this.btnVPublic.Name = "btnVPublic";
            this.btnVPublic.Size = new System.Drawing.Size(129, 26);
            this.btnVPublic.Text = "public";
            this.btnVPublic.CheckedChanged += new System.EventHandler(this.btnVPublic_CheckedChanged);
            // 
            // btnVInternal
            // 
            this.btnVInternal.CheckOnClick = true;
            this.btnVInternal.Name = "btnVInternal";
            this.btnVInternal.Size = new System.Drawing.Size(129, 26);
            this.btnVInternal.Text = "internal";
            this.btnVInternal.CheckedChanged += new System.EventHandler(this.btnVInternal_CheckedChanged);
            // 
            // generatorToolStripMenuItem
            // 
            this.generatorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLFVariables,
            this.btnLFProcedures,
            this.btnLFEvents});
            this.generatorToolStripMenuItem.Name = "generatorToolStripMenuItem";
            this.generatorToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.generatorToolStripMenuItem.Text = "Generator";
            // 
            // btnLFVariables
            // 
            this.btnLFVariables.Name = "btnLFVariables";
            this.btnLFVariables.Size = new System.Drawing.Size(159, 26);
            this.btnLFVariables.Text = "Variables";
            this.btnLFVariables.Click += new System.EventHandler(this.btnLFVariables_Click);
            // 
            // btnLFProcedures
            // 
            this.btnLFProcedures.Name = "btnLFProcedures";
            this.btnLFProcedures.Size = new System.Drawing.Size(159, 26);
            this.btnLFProcedures.Text = "Procedures";
            this.btnLFProcedures.Click += new System.EventHandler(this.btnLFProcedures_Click);
            // 
            // btnLFEvents
            // 
            this.btnLFEvents.Name = "btnLFEvents";
            this.btnLFEvents.Size = new System.Drawing.Size(159, 26);
            this.btnLFEvents.Text = "Events";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
            // 
            // autherProceduresToolStripMenuItem
            // 
            this.autherProceduresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLFOpenConnection,
            this.btnLFCloseConnection,
            this.btnLFFillCombo});
            this.autherProceduresToolStripMenuItem.Name = "autherProceduresToolStripMenuItem";
            this.autherProceduresToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.autherProceduresToolStripMenuItem.Text = "Auther Procedures";
            // 
            // btnLFOpenConnection
            // 
            this.btnLFOpenConnection.Name = "btnLFOpenConnection";
            this.btnLFOpenConnection.Size = new System.Drawing.Size(198, 26);
            this.btnLFOpenConnection.Text = "Open connection";
            this.btnLFOpenConnection.Click += new System.EventHandler(this.btnLFOpenConnection_Click);
            // 
            // btnLFCloseConnection
            // 
            this.btnLFCloseConnection.Name = "btnLFCloseConnection";
            this.btnLFCloseConnection.Size = new System.Drawing.Size(198, 26);
            this.btnLFCloseConnection.Text = "Close connection";
            this.btnLFCloseConnection.Click += new System.EventHandler(this.btnLFCloseConnection_Click);
            // 
            // btnLFFillCombo
            // 
            this.btnLFFillCombo.Name = "btnLFFillCombo";
            this.btnLFFillCombo.Size = new System.Drawing.Size(198, 26);
            this.btnLFFillCombo.Text = "Fill Combo";
            this.btnLFFillCombo.Click += new System.EventHandler(this.btnLFFillCombo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(206, 6);
            // 
            // btnLFInsert
            // 
            this.btnLFInsert.Name = "btnLFInsert";
            this.btnLFInsert.Size = new System.Drawing.Size(209, 26);
            this.btnLFInsert.Text = "Insert";
            this.btnLFInsert.Click += new System.EventHandler(this.btnLFInsert_Click);
            // 
            // btnLFUpdate
            // 
            this.btnLFUpdate.Name = "btnLFUpdate";
            this.btnLFUpdate.Size = new System.Drawing.Size(209, 26);
            this.btnLFUpdate.Text = "Update";
            this.btnLFUpdate.Click += new System.EventHandler(this.btnLFUpdate_Click);
            // 
            // btnLFDelete
            // 
            this.btnLFDelete.Name = "btnLFDelete";
            this.btnLFDelete.Size = new System.Drawing.Size(209, 26);
            this.btnLFDelete.Text = "Delete";
            this.btnLFDelete.Click += new System.EventHandler(this.btnLFDelete_Click);
            // 
            // btnLFSelect
            // 
            this.btnLFSelect.Name = "btnLFSelect";
            this.btnLFSelect.Size = new System.Drawing.Size(209, 26);
            this.btnLFSelect.Text = "Select";
            this.btnLFSelect.Click += new System.EventHandler(this.btnLFSelect_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLFMin,
            this.btnLFMax,
            this.btnLFCount,
            this.btnLFSum,
            this.btnLFAvg});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(209, 26);
            this.toolStripMenuItem1.Text = "Aggregate Function";
            // 
            // btnLFMin
            // 
            this.btnLFMin.Name = "btnLFMin";
            this.btnLFMin.Size = new System.Drawing.Size(136, 26);
            this.btnLFMin.Text = "MIN";
            this.btnLFMin.Click += new System.EventHandler(this.btnLFMin_Click);
            // 
            // btnLFMax
            // 
            this.btnLFMax.Name = "btnLFMax";
            this.btnLFMax.Size = new System.Drawing.Size(136, 26);
            this.btnLFMax.Text = "MAX";
            this.btnLFMax.Click += new System.EventHandler(this.btnLFMax_Click);
            // 
            // btnLFCount
            // 
            this.btnLFCount.Name = "btnLFCount";
            this.btnLFCount.Size = new System.Drawing.Size(136, 26);
            this.btnLFCount.Text = "COUNT";
            this.btnLFCount.Click += new System.EventHandler(this.btnLFCount_Click);
            // 
            // btnLFSum
            // 
            this.btnLFSum.Name = "btnLFSum";
            this.btnLFSum.Size = new System.Drawing.Size(136, 26);
            this.btnLFSum.Text = "SUM";
            this.btnLFSum.Click += new System.EventHandler(this.btnLFSum_Click);
            // 
            // btnLFAvg
            // 
            this.btnLFAvg.Name = "btnLFAvg";
            this.btnLFAvg.Size = new System.Drawing.Size(136, 26);
            this.btnLFAvg.Text = "AVG";
            this.btnLFAvg.Click += new System.EventHandler(this.btnLFAvg_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLFSearch,
            this.btnLFSearchAll,
            this.btnLFSearchBetweenDate});
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(209, 26);
            this.toolStripMenuItem7.Text = "Search";
            // 
            // btnLFSearch
            // 
            this.btnLFSearch.Name = "btnLFSearch";
            this.btnLFSearch.Size = new System.Drawing.Size(233, 26);
            this.btnLFSearch.Text = "Search";
            this.btnLFSearch.Click += new System.EventHandler(this.btnLFSearch_Click);
            // 
            // btnLFSearchAll
            // 
            this.btnLFSearchAll.Name = "btnLFSearchAll";
            this.btnLFSearchAll.Size = new System.Drawing.Size(233, 26);
            this.btnLFSearchAll.Text = "Search All";
            this.btnLFSearchAll.Click += new System.EventHandler(this.btnLFSearchAll_Click);
            // 
            // btnLFSearchBetweenDate
            // 
            this.btnLFSearchBetweenDate.Name = "btnLFSearchBetweenDate";
            this.btnLFSearchBetweenDate.Size = new System.Drawing.Size(233, 26);
            this.btnLFSearchBetweenDate.Text = "Search Between Dates";
            this.btnLFSearchBetweenDate.Click += new System.EventHandler(this.btnLFSearchBetweenDate_Click);
            // 
            // designerToolStripMenuItem
            // 
            this.designerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDControls,
            this.btnDDataGridView});
            this.designerToolStripMenuItem.Name = "designerToolStripMenuItem";
            this.designerToolStripMenuItem.Size = new System.Drawing.Size(79, 22);
            this.designerToolStripMenuItem.Text = "Designer";
            // 
            // btnDControls
            // 
            this.btnDControls.Name = "btnDControls";
            this.btnDControls.Size = new System.Drawing.Size(172, 26);
            this.btnDControls.Text = "Controls";
            this.btnDControls.Click += new System.EventHandler(this.btnDControls_Click);
            // 
            // btnDDataGridView
            // 
            this.btnDDataGridView.Name = "btnDDataGridView";
            this.btnDDataGridView.Size = new System.Drawing.Size(172, 26);
            this.btnDDataGridView.Text = "DataGridView";
            this.btnDDataGridView.Click += new System.EventHandler(this.btnDDataGridView_Click);
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem,
            this.formsToolStripMenuItem,
            this.allLanguageFunctionsToolStripMenuItem});
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(81, 22);
            this.generateToolStripMenuItem.Text = "Generate";
            this.generateToolStripMenuItem.Visible = false;
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // formsToolStripMenuItem
            // 
            this.formsToolStripMenuItem.Name = "formsToolStripMenuItem";
            this.formsToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.formsToolStripMenuItem.Text = "Forms";
            // 
            // allLanguageFunctionsToolStripMenuItem
            // 
            this.allLanguageFunctionsToolStripMenuItem.Name = "allLanguageFunctionsToolStripMenuItem";
            this.allLanguageFunctionsToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.allLanguageFunctionsToolStripMenuItem.Text = "All Language Functions";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblGenerateInformation,
            this.lblDatabase,
            this.lblTable,
            this.lblCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 519);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(882, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblGenerateInformation
            // 
            this.lblGenerateInformation.DoubleClickEnabled = true;
            this.lblGenerateInformation.Name = "lblGenerateInformation";
            this.lblGenerateInformation.Size = new System.Drawing.Size(147, 19);
            this.lblGenerateInformation.Text = "Generate Information";
            this.lblGenerateInformation.DoubleClick += new System.EventHandler(this.lblGenerateInformation_DoubleClick);
            // 
            // lblDatabase
            // 
            this.lblDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblDatabase.DoubleClickEnabled = true;
            this.lblDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDatabaseInfo,
            this.btnLogOut});
            this.lblDatabase.Image = ((System.Drawing.Image)(resources.GetObject("lblDatabase.Image")));
            this.lblDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(90, 22);
            this.lblDatabase.Text = "Database";
            this.lblDatabase.ButtonDoubleClick += new System.EventHandler(this.lblDatabase_ButtonDoubleClick);
            // 
            // btnDatabaseInfo
            // 
            this.btnDatabaseInfo.Name = "btnDatabaseInfo";
            this.btnDatabaseInfo.Size = new System.Drawing.Size(156, 26);
            this.btnDatabaseInfo.Text = "Information";
            this.btnDatabaseInfo.Click += new System.EventHandler(this.btnDatabaseInfo_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(156, 26);
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // lblTable
            // 
            this.lblTable.DoubleClickEnabled = true;
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(44, 19);
            this.lblTable.Text = "Table";
            this.lblTable.DoubleClick += new System.EventHandler(this.lblTable_DoubleClick);
            // 
            // lblCount
            // 
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(586, 19);
            this.lblCount.Spring = true;
            this.lblCount.Text = "Counts";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuSP
            // 
            this.menuSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.menuSP.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuSP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSPCreate,
            this.btnSPUpdate,
            this.btnSPDelete,
            this.btnSPRename,
            this.toolStripSeparator8,
            this.btnSPScript,
            this.toolStripSeparator9,
            this.btnSPRefresh});
            this.menuSP.Name = "contextMenuStrip1";
            this.menuSP.Size = new System.Drawing.Size(157, 148);
            // 
            // btnSPCreate
            // 
            this.btnSPCreate.Name = "btnSPCreate";
            this.btnSPCreate.Size = new System.Drawing.Size(156, 22);
            this.btnSPCreate.Text = "Create SP";
            this.btnSPCreate.Click += new System.EventHandler(this.btnSPCreate_Click);
            // 
            // btnSPUpdate
            // 
            this.btnSPUpdate.Name = "btnSPUpdate";
            this.btnSPUpdate.Size = new System.Drawing.Size(156, 22);
            this.btnSPUpdate.Text = "Update SP";
            this.btnSPUpdate.Click += new System.EventHandler(this.btnSPUpdate_Click);
            // 
            // btnSPDelete
            // 
            this.btnSPDelete.Name = "btnSPDelete";
            this.btnSPDelete.Size = new System.Drawing.Size(156, 22);
            this.btnSPDelete.Text = "Delete SP";
            this.btnSPDelete.Click += new System.EventHandler(this.btnSPDelete_Click);
            // 
            // btnSPRename
            // 
            this.btnSPRename.Name = "btnSPRename";
            this.btnSPRename.Size = new System.Drawing.Size(156, 22);
            this.btnSPRename.Text = "Rename SP";
            this.btnSPRename.Click += new System.EventHandler(this.btnSPRename_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(153, 6);
            // 
            // btnSPScript
            // 
            this.btnSPScript.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSPScriptCreate,
            this.btnSPScriptAlter,
            this.btnSPScriptDrop,
            this.btnSPScriptDropAndCreate});
            this.btnSPScript.Name = "btnSPScript";
            this.btnSPScript.Size = new System.Drawing.Size(156, 22);
            this.btnSPScript.Text = "Script SP";
            // 
            // btnSPScriptCreate
            // 
            this.btnSPScriptCreate.Name = "btnSPScriptCreate";
            this.btnSPScriptCreate.Size = new System.Drawing.Size(219, 26);
            this.btnSPScriptCreate.Text = "CREATE";
            this.btnSPScriptCreate.Click += new System.EventHandler(this.btnSPScriptCreate_Click);
            // 
            // btnSPScriptAlter
            // 
            this.btnSPScriptAlter.Name = "btnSPScriptAlter";
            this.btnSPScriptAlter.Size = new System.Drawing.Size(219, 26);
            this.btnSPScriptAlter.Text = "ALTER";
            this.btnSPScriptAlter.Click += new System.EventHandler(this.btnSPScriptAlter_Click);
            // 
            // btnSPScriptDrop
            // 
            this.btnSPScriptDrop.Name = "btnSPScriptDrop";
            this.btnSPScriptDrop.Size = new System.Drawing.Size(219, 26);
            this.btnSPScriptDrop.Text = "DROP";
            this.btnSPScriptDrop.Click += new System.EventHandler(this.btnSPScriptDrop_Click);
            // 
            // btnSPScriptDropAndCreate
            // 
            this.btnSPScriptDropAndCreate.Name = "btnSPScriptDropAndCreate";
            this.btnSPScriptDropAndCreate.Size = new System.Drawing.Size(219, 26);
            this.btnSPScriptDropAndCreate.Text = "DROP And CREATE";
            this.btnSPScriptDropAndCreate.Click += new System.EventHandler(this.btnSPScriptDropAndCreate_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(153, 6);
            // 
            // btnSPRefresh
            // 
            this.btnSPRefresh.Name = "btnSPRefresh";
            this.btnSPRefresh.Size = new System.Drawing.Size(156, 22);
            this.btnSPRefresh.Text = "Refresh";
            this.btnSPRefresh.Click += new System.EventHandler(this.btnSPRefresh_Click);
            // 
            // menuView
            // 
            this.menuView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.menuView.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnVCreate,
            this.btnVUpdate,
            this.btnVDelete,
            this.btnVRename,
            this.toolStripSeparator6,
            this.btnVScript,
            this.toolStripSeparator7,
            this.btnVRefresh});
            this.menuView.Name = "contextMenuStrip1";
            this.menuView.Size = new System.Drawing.Size(168, 148);
            // 
            // btnVCreate
            // 
            this.btnVCreate.Name = "btnVCreate";
            this.btnVCreate.Size = new System.Drawing.Size(167, 22);
            this.btnVCreate.Text = "Create View";
            this.btnVCreate.Click += new System.EventHandler(this.btnVCreate_Click);
            // 
            // btnVUpdate
            // 
            this.btnVUpdate.Name = "btnVUpdate";
            this.btnVUpdate.Size = new System.Drawing.Size(167, 22);
            this.btnVUpdate.Text = "Update View";
            this.btnVUpdate.Click += new System.EventHandler(this.btnVUpdate_Click);
            // 
            // btnVDelete
            // 
            this.btnVDelete.Name = "btnVDelete";
            this.btnVDelete.Size = new System.Drawing.Size(167, 22);
            this.btnVDelete.Text = "Delete View";
            this.btnVDelete.Click += new System.EventHandler(this.btnVDelete_Click);
            // 
            // btnVRename
            // 
            this.btnVRename.Name = "btnVRename";
            this.btnVRename.Size = new System.Drawing.Size(167, 22);
            this.btnVRename.Text = "Rename View";
            this.btnVRename.Click += new System.EventHandler(this.btnVRename_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(164, 6);
            // 
            // btnVScript
            // 
            this.btnVScript.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnVScriptCreate,
            this.btnVScriptAlter,
            this.btnVScriptDrop,
            this.btnVScriptDropAndCreate});
            this.btnVScript.Name = "btnVScript";
            this.btnVScript.Size = new System.Drawing.Size(167, 22);
            this.btnVScript.Text = "Script View";
            // 
            // btnVScriptCreate
            // 
            this.btnVScriptCreate.Name = "btnVScriptCreate";
            this.btnVScriptCreate.Size = new System.Drawing.Size(219, 26);
            this.btnVScriptCreate.Text = "CREATE";
            this.btnVScriptCreate.Click += new System.EventHandler(this.btnVScriptCreate_Click);
            // 
            // btnVScriptAlter
            // 
            this.btnVScriptAlter.Name = "btnVScriptAlter";
            this.btnVScriptAlter.Size = new System.Drawing.Size(219, 26);
            this.btnVScriptAlter.Text = "ALTER";
            this.btnVScriptAlter.Click += new System.EventHandler(this.btnVScriptAlter_Click);
            // 
            // btnVScriptDrop
            // 
            this.btnVScriptDrop.Name = "btnVScriptDrop";
            this.btnVScriptDrop.Size = new System.Drawing.Size(219, 26);
            this.btnVScriptDrop.Text = "DROP";
            this.btnVScriptDrop.Click += new System.EventHandler(this.btnVScriptDrop_Click);
            // 
            // btnVScriptDropAndCreate
            // 
            this.btnVScriptDropAndCreate.Name = "btnVScriptDropAndCreate";
            this.btnVScriptDropAndCreate.Size = new System.Drawing.Size(219, 26);
            this.btnVScriptDropAndCreate.Text = "DROP And CREATE";
            this.btnVScriptDropAndCreate.Click += new System.EventHandler(this.btnVScriptDropAndCreate_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(164, 6);
            // 
            // btnVRefresh
            // 
            this.btnVRefresh.Name = "btnVRefresh";
            this.btnVRefresh.Size = new System.Drawing.Size(167, 22);
            this.btnVRefresh.Text = "Refresh";
            this.btnVRefresh.Click += new System.EventHandler(this.btnVRefresh_Click);
            // 
            // menuTable
            // 
            this.menuTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.menuTable.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTCreate,
            this.btnTUpdate,
            this.btnTDelete,
            this.btnTRename,
            this.toolStripSeparator4,
            this.btnTEditData,
            this.toolStripSeparator3,
            this.btnTScript,
            this.toolStripSeparator5,
            this.btnTRefresh});
            this.menuTable.Name = "menuTable";
            this.menuTable.Size = new System.Drawing.Size(173, 176);
            // 
            // btnTCreate
            // 
            this.btnTCreate.Name = "btnTCreate";
            this.btnTCreate.Size = new System.Drawing.Size(172, 22);
            this.btnTCreate.Text = "Create Table";
            this.btnTCreate.Click += new System.EventHandler(this.btnTCreate_Click);
            // 
            // btnTUpdate
            // 
            this.btnTUpdate.Name = "btnTUpdate";
            this.btnTUpdate.Size = new System.Drawing.Size(172, 22);
            this.btnTUpdate.Text = "Update Table";
            this.btnTUpdate.Click += new System.EventHandler(this.btnTUpdate_Click);
            // 
            // btnTDelete
            // 
            this.btnTDelete.Name = "btnTDelete";
            this.btnTDelete.Size = new System.Drawing.Size(172, 22);
            this.btnTDelete.Text = "Delete Table";
            this.btnTDelete.Click += new System.EventHandler(this.btnTDelete_Click);
            // 
            // btnTRename
            // 
            this.btnTRename.Name = "btnTRename";
            this.btnTRename.Size = new System.Drawing.Size(172, 22);
            this.btnTRename.Text = "Rename Table";
            this.btnTRename.Click += new System.EventHandler(this.btnTRename_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(169, 6);
            // 
            // btnTEditData
            // 
            this.btnTEditData.Name = "btnTEditData";
            this.btnTEditData.Size = new System.Drawing.Size(172, 22);
            this.btnTEditData.Text = "Edit Data";
            this.btnTEditData.Click += new System.EventHandler(this.btnTEditData_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
            // 
            // btnTScript
            // 
            this.btnTScript.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTScriptCreate,
            this.btnTScriptDrop,
            this.btnTScriptDropAndCreate});
            this.btnTScript.Name = "btnTScript";
            this.btnTScript.Size = new System.Drawing.Size(172, 22);
            this.btnTScript.Text = "Script Table";
            // 
            // btnTScriptCreate
            // 
            this.btnTScriptCreate.Name = "btnTScriptCreate";
            this.btnTScriptCreate.Size = new System.Drawing.Size(219, 26);
            this.btnTScriptCreate.Text = "CREATE";
            this.btnTScriptCreate.Click += new System.EventHandler(this.btnTScriptCreate_Click);
            // 
            // btnTScriptDrop
            // 
            this.btnTScriptDrop.Name = "btnTScriptDrop";
            this.btnTScriptDrop.Size = new System.Drawing.Size(219, 26);
            this.btnTScriptDrop.Text = "DROP";
            this.btnTScriptDrop.Click += new System.EventHandler(this.btnTScriptDrop_Click);
            // 
            // btnTScriptDropAndCreate
            // 
            this.btnTScriptDropAndCreate.Name = "btnTScriptDropAndCreate";
            this.btnTScriptDropAndCreate.Size = new System.Drawing.Size(219, 26);
            this.btnTScriptDropAndCreate.Text = "DROP And CREATE";
            this.btnTScriptDropAndCreate.Click += new System.EventHandler(this.btnTScriptDropAndCreate_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(169, 6);
            // 
            // btnTRefresh
            // 
            this.btnTRefresh.Name = "btnTRefresh";
            this.btnTRefresh.Size = new System.Drawing.Size(172, 22);
            this.btnTRefresh.Text = "Refresh";
            this.btnTRefresh.Click += new System.EventHandler(this.btnTRefresh_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 26);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tcResult);
            this.splitContainer1.Size = new System.Drawing.Size(882, 493);
            this.splitContainer1.SplitterDistance = 233;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpTables);
            this.tabControl1.Controls.Add(this.tpViews);
            this.tabControl1.Controls.Add(this.tpSP);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(233, 493);
            this.tabControl1.TabIndex = 0;
            // 
            // tpTables
            // 
            this.tpTables.BackColor = System.Drawing.SystemColors.Control;
            this.tpTables.Controls.Add(this.tableLayoutPanel1);
            this.tpTables.Location = new System.Drawing.Point(4, 29);
            this.tpTables.Name = "tpTables";
            this.tpTables.Padding = new System.Windows.Forms.Padding(3);
            this.tpTables.Size = new System.Drawing.Size(225, 460);
            this.tpTables.TabIndex = 0;
            this.tpTables.Text = "Tables";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvTable, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTSearch, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(219, 454);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvTable
            // 
            this.dgvTable.AllowUserToAddRows = false;
            this.dgvTable.AllowUserToDeleteRows = false;
            this.dgvTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTable});
            this.dgvTable.GridColor = System.Drawing.SystemColors.Control;
            this.dgvTable.Location = new System.Drawing.Point(3, 43);
            this.dgvTable.MultiSelect = false;
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 10.2F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTable.RowHeadersVisible = false;
            this.dgvTable.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvTable.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTable.RowTemplate.Height = 24;
            this.dgvTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTable.Size = new System.Drawing.Size(213, 408);
            this.dgvTable.TabIndex = 27;
            this.dgvTable.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dgvTable_CellContextMenuStripNeeded);
            this.dgvTable.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTable_CellMouseDown);
            // 
            // colTable
            // 
            this.colTable.DataPropertyName = "Name_Table";
            this.colTable.HeaderText = "Table";
            this.colTable.MinimumWidth = 6;
            this.colTable.Name = "colTable";
            this.colTable.ReadOnly = true;
            // 
            // txtTSearch
            // 
            this.txtTSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTSearch.Location = new System.Drawing.Point(3, 6);
            this.txtTSearch.Name = "txtTSearch";
            this.txtTSearch.Size = new System.Drawing.Size(213, 28);
            this.txtTSearch.TabIndex = 0;
            this.txtTSearch.TextChanged += new System.EventHandler(this.txtTSearch_TextChanged);
            // 
            // tpViews
            // 
            this.tpViews.BackColor = System.Drawing.SystemColors.Control;
            this.tpViews.Controls.Add(this.tableLayoutPanel2);
            this.tpViews.Location = new System.Drawing.Point(4, 25);
            this.tpViews.Name = "tpViews";
            this.tpViews.Padding = new System.Windows.Forms.Padding(3);
            this.tpViews.Size = new System.Drawing.Size(225, 464);
            this.tpViews.TabIndex = 1;
            this.tpViews.Text = "Views";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dgvView, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtVSearch, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(219, 458);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // dgvView
            // 
            this.dgvView.AllowUserToAddRows = false;
            this.dgvView.AllowUserToDeleteRows = false;
            this.dgvView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colView,
            this.colViewText});
            this.dgvView.GridColor = System.Drawing.SystemColors.Control;
            this.dgvView.Location = new System.Drawing.Point(3, 43);
            this.dgvView.MultiSelect = false;
            this.dgvView.Name = "dgvView";
            this.dgvView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 10.2F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvView.RowHeadersVisible = false;
            this.dgvView.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvView.RowTemplate.Height = 24;
            this.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvView.Size = new System.Drawing.Size(213, 412);
            this.dgvView.TabIndex = 28;
            this.dgvView.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dgvView_CellContextMenuStripNeeded);
            this.dgvView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvView_CellMouseDown);
            // 
            // colView
            // 
            this.colView.DataPropertyName = "View";
            this.colView.HeaderText = "View";
            this.colView.MinimumWidth = 6;
            this.colView.Name = "colView";
            this.colView.ReadOnly = true;
            // 
            // colViewText
            // 
            this.colViewText.DataPropertyName = "Text";
            this.colViewText.HeaderText = "Text";
            this.colViewText.MinimumWidth = 6;
            this.colViewText.Name = "colViewText";
            this.colViewText.ReadOnly = true;
            this.colViewText.Visible = false;
            // 
            // txtVSearch
            // 
            this.txtVSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVSearch.Location = new System.Drawing.Point(3, 6);
            this.txtVSearch.Name = "txtVSearch";
            this.txtVSearch.Size = new System.Drawing.Size(213, 28);
            this.txtVSearch.TabIndex = 0;
            this.txtVSearch.TextChanged += new System.EventHandler(this.txtVSearch_TextChanged);
            // 
            // tpSP
            // 
            this.tpSP.BackColor = System.Drawing.SystemColors.Control;
            this.tpSP.Controls.Add(this.tableLayoutPanel3);
            this.tpSP.Location = new System.Drawing.Point(4, 25);
            this.tpSP.Name = "tpSP";
            this.tpSP.Padding = new System.Windows.Forms.Padding(3);
            this.tpSP.Size = new System.Drawing.Size(225, 464);
            this.tpSP.TabIndex = 2;
            this.tpSP.Text = "S.P.";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.dgvSP, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtSPSearch, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(219, 458);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // dgvSP
            // 
            this.dgvSP.AllowUserToAddRows = false;
            this.dgvSP.AllowUserToDeleteRows = false;
            this.dgvSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSP.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSP.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStoredProcedure,
            this.colSpText});
            this.dgvSP.GridColor = System.Drawing.SystemColors.Control;
            this.dgvSP.Location = new System.Drawing.Point(3, 43);
            this.dgvSP.MultiSelect = false;
            this.dgvSP.Name = "dgvSP";
            this.dgvSP.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Roboto", 10.2F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSP.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSP.RowHeadersVisible = false;
            this.dgvSP.RowHeadersWidth = 51;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvSP.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSP.RowTemplate.Height = 24;
            this.dgvSP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSP.Size = new System.Drawing.Size(213, 412);
            this.dgvSP.TabIndex = 29;
            this.dgvSP.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dgvSP_CellContextMenuStripNeeded);
            this.dgvSP.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSP_CellMouseDown);
            // 
            // colStoredProcedure
            // 
            this.colStoredProcedure.DataPropertyName = "StoredProcedure";
            this.colStoredProcedure.HeaderText = "Stored Procedure";
            this.colStoredProcedure.MinimumWidth = 6;
            this.colStoredProcedure.Name = "colStoredProcedure";
            this.colStoredProcedure.ReadOnly = true;
            // 
            // colSpText
            // 
            this.colSpText.DataPropertyName = "Text";
            this.colSpText.HeaderText = "Text";
            this.colSpText.MinimumWidth = 6;
            this.colSpText.Name = "colSpText";
            this.colSpText.ReadOnly = true;
            this.colSpText.Visible = false;
            // 
            // txtSPSearch
            // 
            this.txtSPSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSPSearch.Location = new System.Drawing.Point(3, 6);
            this.txtSPSearch.Name = "txtSPSearch";
            this.txtSPSearch.Size = new System.Drawing.Size(213, 28);
            this.txtSPSearch.TabIndex = 0;
            this.txtSPSearch.TextChanged += new System.EventHandler(this.txtSPSearch_TextChanged);
            // 
            // tcResult
            // 
            this.tcResult.Controls.Add(this.tpCreating);
            this.tcResult.Controls.Add(this.tpResult);
            this.tcResult.Controls.Add(this.tpShowData);
            this.tcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcResult.Location = new System.Drawing.Point(0, 0);
            this.tcResult.Name = "tcResult";
            this.tcResult.SelectedIndex = 0;
            this.tcResult.Size = new System.Drawing.Size(645, 493);
            this.tcResult.TabIndex = 1;
            // 
            // tpCreating
            // 
            this.tpCreating.BackColor = System.Drawing.SystemColors.Control;
            this.tpCreating.Controls.Add(this.uc_Creating1);
            this.tpCreating.Location = new System.Drawing.Point(4, 29);
            this.tpCreating.Name = "tpCreating";
            this.tpCreating.Padding = new System.Windows.Forms.Padding(3);
            this.tpCreating.Size = new System.Drawing.Size(637, 460);
            this.tpCreating.TabIndex = 0;
            this.tpCreating.Text = "Creating";
            // 
            // uc_Creating1
            // 
            this.uc_Creating1.BackColor = System.Drawing.SystemColors.Window;
            this.uc_Creating1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uc_Creating1.DataSource = null;
            this.uc_Creating1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_Creating1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.uc_Creating1.isCheckReccord = false;
            this.uc_Creating1.Location = new System.Drawing.Point(3, 3);
            this.uc_Creating1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uc_Creating1.Name = "uc_Creating1";
            this.uc_Creating1.Size = new System.Drawing.Size(631, 454);
            this.uc_Creating1.SQL = null;
            this.uc_Creating1.TabIndex = 0;
            // 
            // tpResult
            // 
            this.tpResult.BackColor = System.Drawing.SystemColors.Control;
            this.tpResult.Controls.Add(this.ucEditor1);
            this.tpResult.Location = new System.Drawing.Point(4, 25);
            this.tpResult.Name = "tpResult";
            this.tpResult.Padding = new System.Windows.Forms.Padding(3);
            this.tpResult.Size = new System.Drawing.Size(637, 464);
            this.tpResult.TabIndex = 1;
            this.tpResult.Text = "Result";
            // 
            // ucEditor1
            // 
            this.ucEditor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dbInfo1.Collation = "";
            dbInfo1.conString = "Server = ILYASSE-PC\\SQL14; Database = GesPhotos; Integrated Security = True; Trus" +
    "tServerCertificate=True;";
            dbInfo1.conStringMaster = "Server = ILYASSE-PC\\SQL14; Database = master; Integrated Security = True; TrustSe" +
    "rverCertificate=True;";
            dbInfo1.DatabaseName = "GesPhotos";
            dbInfo1.isRemember = true;
            dbInfo1.Password = "";
            dbInfo1.ServerName = "ILYASSE-PC\\SQL14";
            dbInfo1.TypeDatabase = UTIL.TypeDatabase.Microsoft_SQL_Server;
            dbInfo1.Username = "";
            this.ucEditor1.dbInfo = dbInfo1;
            this.ucEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEditor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucEditor1.ForeColorLine = System.Drawing.Color.Black;
            this.ucEditor1.FrmSQL = null;
            this.ucEditor1.Location = new System.Drawing.Point(3, 3);
            this.ucEditor1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucEditor1.Name = "ucEditor1";
            this.ucEditor1.ShowLineNumbering = true;
            this.ucEditor1.Size = new System.Drawing.Size(631, 458);
            this.ucEditor1.Syntaxe = UTIL.Language.SQL;
            this.ucEditor1.TabIndex = 0;
            this.ucEditor1.Titre = null;
            // 
            // tpShowData
            // 
            this.tpShowData.Controls.Add(this.splitContainer2);
            this.tpShowData.Location = new System.Drawing.Point(4, 25);
            this.tpShowData.Name = "tpShowData";
            this.tpShowData.Padding = new System.Windows.Forms.Padding(3);
            this.tpShowData.Size = new System.Drawing.Size(637, 464);
            this.tpShowData.TabIndex = 2;
            this.tpShowData.Text = "Show Data";
            this.tpShowData.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvShowData);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.uc_ShowData1);
            this.splitContainer2.Size = new System.Drawing.Size(631, 458);
            this.splitContainer2.SplitterDistance = 302;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvShowData
            // 
            this.dgvShowData.AllowUserToAddRows = false;
            this.dgvShowData.AllowUserToDeleteRows = false;
            this.dgvShowData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvShowData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvShowData.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvShowData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvShowData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShowData.GridColor = System.Drawing.SystemColors.Control;
            this.dgvShowData.Location = new System.Drawing.Point(0, 0);
            this.dgvShowData.MultiSelect = false;
            this.dgvShowData.Name = "dgvShowData";
            this.dgvShowData.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Roboto", 10.2F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShowData.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvShowData.RowHeadersVisible = false;
            this.dgvShowData.RowHeadersWidth = 51;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvShowData.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvShowData.RowTemplate.Height = 24;
            this.dgvShowData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShowData.Size = new System.Drawing.Size(631, 302);
            this.dgvShowData.TabIndex = 28;
            // 
            // uc_ShowData1
            // 
            this.uc_ShowData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dbInfo2.Collation = "";
            dbInfo2.conString = "Server = ILYASSE-PC\\SQL14; Database = GesPhotos; Integrated Security = True; Trus" +
    "tServerCertificate=True;";
            dbInfo2.conStringMaster = "Server = ILYASSE-PC\\SQL14; Database = master; Integrated Security = True; TrustSe" +
    "rverCertificate=True;";
            dbInfo2.DatabaseName = "GesPhotos";
            dbInfo2.isRemember = true;
            dbInfo2.Password = "";
            dbInfo2.ServerName = "ILYASSE-PC\\SQL14";
            dbInfo2.TypeDatabase = UTIL.TypeDatabase.Microsoft_SQL_Server;
            dbInfo2.Username = "";
            this.uc_ShowData1.dbInfo = dbInfo2;
            this.uc_ShowData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_ShowData1.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uc_ShowData1.Location = new System.Drawing.Point(0, 0);
            this.uc_ShowData1.Margin = new System.Windows.Forms.Padding(4);
            this.uc_ShowData1.MyGrid = null;
            this.uc_ShowData1.Name = "uc_ShowData1";
            this.uc_ShowData1.Size = new System.Drawing.Size(631, 152);
            this.uc_ShowData1.TabIndex = 0;
            // 
            // SQL_frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 543);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Roboto", 10.2F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SQL_frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Server";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SQL_frmMain_FormClosing);
            this.Load += new System.EventHandler(this.SQL_frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuSP.ResumeLayout(false);
            this.menuView.ResumeLayout(false);
            this.menuTable.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpTables.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.tpViews.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.tpSP.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).EndInit();
            this.tcResult.ResumeLayout(false);
            this.tpCreating.ResumeLayout(false);
            this.tpResult.ResumeLayout(false);
            this.tpShowData.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem databaseConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnNewConnection;
        private System.Windows.Forms.ToolStripMenuItem btnGetConnectionString;
        private System.Windows.Forms.ToolStripMenuItem databaseFunctionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnDInsert;
        private System.Windows.Forms.ToolStripMenuItem btnDUpdate;
        private System.Windows.Forms.ToolStripMenuItem btnDDelete;
        private System.Windows.Forms.ToolStripMenuItem btnDSelect;
        private System.Windows.Forms.ToolStripMenuItem aggregateFunctionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnDMin;
        private System.Windows.Forms.ToolStripMenuItem btnDMax;
        private System.Windows.Forms.ToolStripMenuItem btnDCount;
        private System.Windows.Forms.ToolStripMenuItem btnDSum;
        private System.Windows.Forms.ToolStripMenuItem btnDAvg;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem searchAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchBetweenDatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageFunctionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnLFInsert;
        private System.Windows.Forms.ToolStripMenuItem btnLFUpdate;
        private System.Windows.Forms.ToolStripMenuItem btnLFDelete;
        private System.Windows.Forms.ToolStripMenuItem btnLFSelect;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btnLFMin;
        private System.Windows.Forms.ToolStripMenuItem btnLFMax;
        private System.Windows.Forms.ToolStripMenuItem btnLFCount;
        private System.Windows.Forms.ToolStripMenuItem btnLFSum;
        private System.Windows.Forms.ToolStripMenuItem btnLFAvg;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem btnLFSearch;
        private System.Windows.Forms.ToolStripMenuItem btnLFSearchAll;
        private System.Windows.Forms.ToolStripMenuItem btnLFSearchBetweenDate;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblGenerateInformation;
        private System.Windows.Forms.ToolStripStatusLabel lblTable;
        private System.Windows.Forms.ToolStripStatusLabel lblCount;
        private System.Windows.Forms.ToolStripMenuItem designerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnDControls;
        private System.Windows.Forms.ToolStripSplitButton lblDatabase;
        private System.Windows.Forms.ToolStripMenuItem btnDatabaseInfo;
        private System.Windows.Forms.ToolStripMenuItem btnLogOut;
        private System.Windows.Forms.ToolStripMenuItem btnDDataGridView;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allLanguageFunctionsToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpTables;
        private System.Windows.Forms.TabPage tpViews;
        private System.Windows.Forms.TabPage tpSP;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtTSearch;
        public System.Windows.Forms.DataGridView dgvTable;
        public System.Windows.Forms.DataGridViewTextBoxColumn colTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtVSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtSPSearch;
        private System.Windows.Forms.TabPage tpCreating;
        public System.Windows.Forms.DataGridView dgvView;
        public System.Windows.Forms.DataGridViewTextBoxColumn colView;
        public System.Windows.Forms.DataGridViewTextBoxColumn colViewText;
        public System.Windows.Forms.DataGridView dgvSP;
        public System.Windows.Forms.DataGridViewTextBoxColumn colStoredProcedure;
        public System.Windows.Forms.DataGridViewTextBoxColumn colSpText;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cRUDStatementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnParameters;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem btnPPrivate;
        private System.Windows.Forms.ToolStripMenuItem btnPPublic;
        private System.Windows.Forms.ToolStripMenuItem btnPInternal;
        private System.Windows.Forms.ToolStripMenuItem privateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnVPrivate;
        private System.Windows.Forms.ToolStripMenuItem btnVPublic;
        private System.Windows.Forms.ToolStripMenuItem btnVInternal;
        private System.Windows.Forms.ToolStripMenuItem btnTryCatch;
        private System.Windows.Forms.ToolStripMenuItem btnTransaction;
        private System.Windows.Forms.ContextMenuStrip menuSP;
        private System.Windows.Forms.ToolStripMenuItem btnSPCreate;
        private System.Windows.Forms.ToolStripMenuItem btnSPUpdate;
        private System.Windows.Forms.ToolStripMenuItem btnSPDelete;
        private System.Windows.Forms.ToolStripMenuItem btnSPRename;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem btnSPScript;
        private System.Windows.Forms.ToolStripMenuItem btnSPScriptCreate;
        private System.Windows.Forms.ToolStripMenuItem btnSPScriptAlter;
        private System.Windows.Forms.ToolStripMenuItem btnSPScriptDrop;
        private System.Windows.Forms.ToolStripMenuItem btnSPScriptDropAndCreate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem btnSPRefresh;
        private System.Windows.Forms.ContextMenuStrip menuView;
        private System.Windows.Forms.ToolStripMenuItem btnVCreate;
        private System.Windows.Forms.ToolStripMenuItem btnVUpdate;
        private System.Windows.Forms.ToolStripMenuItem btnVDelete;
        private System.Windows.Forms.ToolStripMenuItem btnVRename;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem btnVScript;
        private System.Windows.Forms.ToolStripMenuItem btnVScriptCreate;
        private System.Windows.Forms.ToolStripMenuItem btnVScriptAlter;
        private System.Windows.Forms.ToolStripMenuItem btnVScriptDrop;
        private System.Windows.Forms.ToolStripMenuItem btnVScriptDropAndCreate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem btnVRefresh;
        private System.Windows.Forms.ContextMenuStrip menuTable;
        private System.Windows.Forms.ToolStripMenuItem btnTCreate;
        private System.Windows.Forms.ToolStripMenuItem btnTUpdate;
        private System.Windows.Forms.ToolStripMenuItem btnTDelete;
        private System.Windows.Forms.ToolStripMenuItem btnTRename;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem btnTEditData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem btnTScript;
        private System.Windows.Forms.ToolStripMenuItem btnTScriptCreate;
        private System.Windows.Forms.ToolStripMenuItem btnTScriptDrop;
        private System.Windows.Forms.ToolStripMenuItem btnTScriptDropAndCreate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem btnTRefresh;
        private UC.uc_Creating uc_Creating1;
        private System.Windows.Forms.TabPage tpShowData;
        private System.Windows.Forms.SplitContainer splitContainer2;
        public System.Windows.Forms.DataGridView dgvShowData;
        private UC.uc_ShowData uc_ShowData1;
        private System.Windows.Forms.ToolStripMenuItem generatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnLFVariables;
        private System.Windows.Forms.ToolStripMenuItem btnLFProcedures;
        private System.Windows.Forms.ToolStripMenuItem btnLFEvents;
        private System.Windows.Forms.ToolStripMenuItem autherProceduresToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnLFOpenConnection;
        private System.Windows.Forms.ToolStripMenuItem btnLFCloseConnection;
        private System.Windows.Forms.ToolStripMenuItem btnLFFillCombo;
        private System.Windows.Forms.ToolStripMenuItem snippetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnSnippets;
        public UC.ucEditor ucEditor1;
        public System.Windows.Forms.TabControl tcResult;
        public System.Windows.Forms.TabPage tpResult;
    }
}