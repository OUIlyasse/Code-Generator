namespace Code_Generator.Sub.SQL
{
    partial class frmAddTable
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
            this.dgvCreation = new System.Windows.Forms.DataGridView();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMax = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPrimaryKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIdentity = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUnique = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCollation = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pgColumnsInfo = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCreation
            // 
            this.dgvCreation.AllowUserToOrderColumns = true;
            this.dgvCreation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvCreation.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCreation.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCreation.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCreation.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvCreation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCreation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPosition,
            this.colImage,
            this.colColumn,
            this.colDataType,
            this.colSize,
            this.colMax,
            this.colPrimaryKey,
            this.colIdentity,
            this.colNull,
            this.colUnique,
            this.colDefaultValue,
            this.colCollation});
            this.dgvCreation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCreation.GridColor = System.Drawing.SystemColors.Control;
            this.dgvCreation.Location = new System.Drawing.Point(0, 0);
            this.dgvCreation.Name = "dgvCreation";
            this.dgvCreation.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCreation.RowHeadersWidth = 30;
            this.dgvCreation.RowTemplate.Height = 24;
            this.dgvCreation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCreation.Size = new System.Drawing.Size(782, 331);
            this.dgvCreation.TabIndex = 8;
            this.dgvCreation.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTable_CellDoubleClick);
            this.dgvCreation.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTable_CellEndEdit);
            this.dgvCreation.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTable_CellFormatting);
            this.dgvCreation.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvCreation_DataError);
            this.dgvCreation.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvTable_DefaultValuesNeeded);
            this.dgvCreation.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvTable_RowValidating);
            this.dgvCreation.SelectionChanged += new System.EventHandler(this.dgvTable_SelectionChanged);
            // 
            // colPosition
            // 
            this.colPosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colPosition.DataPropertyName = "ORDINAL_POSITION";
            this.colPosition.HeaderText = "Position";
            this.colPosition.MinimumWidth = 6;
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            this.colPosition.Visible = false;
            // 
            // colImage
            // 
            this.colImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colImage.FillWeight = 130F;
            this.colImage.HeaderText = "";
            this.colImage.MinimumWidth = 6;
            this.colImage.Name = "colImage";
            this.colImage.Width = 23;
            // 
            // colColumn
            // 
            this.colColumn.DataPropertyName = "COLUMN_NAME";
            this.colColumn.HeaderText = "Column";
            this.colColumn.MinimumWidth = 120;
            this.colColumn.Name = "colColumn";
            this.colColumn.Width = 120;
            // 
            // colDataType
            // 
            this.colDataType.DataPropertyName = "DATA_TYPE";
            this.colDataType.HeaderText = "Data Type";
            this.colDataType.MinimumWidth = 80;
            this.colDataType.Name = "colDataType";
            this.colDataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDataType.Width = 113;
            // 
            // colSize
            // 
            this.colSize.DataPropertyName = "CHARACTER_MAXIMUM_LENGTH";
            this.colSize.HeaderText = "Size";
            this.colSize.MinimumWidth = 70;
            this.colSize.Name = "colSize";
            this.colSize.Width = 70;
            // 
            // colMax
            // 
            this.colMax.HeaderText = "Max";
            this.colMax.MinimumWidth = 6;
            this.colMax.Name = "colMax";
            this.colMax.Width = 47;
            // 
            // colPrimaryKey
            // 
            this.colPrimaryKey.DataPropertyName = "IsPrimaryKey";
            this.colPrimaryKey.HeaderText = "Primary Key";
            this.colPrimaryKey.MinimumWidth = 95;
            this.colPrimaryKey.Name = "colPrimaryKey";
            this.colPrimaryKey.Width = 106;
            // 
            // colIdentity
            // 
            this.colIdentity.DataPropertyName = "IS_IDENTITY";
            this.colIdentity.HeaderText = "Identity";
            this.colIdentity.MinimumWidth = 75;
            this.colIdentity.Name = "colIdentity";
            this.colIdentity.Width = 75;
            // 
            // colNull
            // 
            this.colNull.DataPropertyName = "IS_NULLABLE";
            this.colNull.HeaderText = "Nullable";
            this.colNull.MinimumWidth = 50;
            this.colNull.Name = "colNull";
            this.colNull.Width = 76;
            // 
            // colUnique
            // 
            this.colUnique.HeaderText = "Unique";
            this.colUnique.MinimumWidth = 6;
            this.colUnique.Name = "colUnique";
            this.colUnique.Width = 67;
            // 
            // colDefaultValue
            // 
            this.colDefaultValue.HeaderText = "Default Value";
            this.colDefaultValue.MinimumWidth = 6;
            this.colDefaultValue.Name = "colDefaultValue";
            this.colDefaultValue.Width = 138;
            // 
            // colCollation
            // 
            this.colCollation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCollation.FillWeight = 120F;
            this.colCollation.HeaderText = "Collation";
            this.colCollation.MinimumWidth = 6;
            this.colCollation.Name = "colCollation";
            this.colCollation.Width = 82;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvCreation);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pgColumnsInfo);
            this.splitContainer1.Size = new System.Drawing.Size(782, 503);
            this.splitContainer1.SplitterDistance = 331;
            this.splitContainer1.TabIndex = 1;
            // 
            // pgColumnsInfo
            // 
            this.pgColumnsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgColumnsInfo.HelpVisible = false;
            this.pgColumnsInfo.LineColor = System.Drawing.Color.WhiteSmoke;
            this.pgColumnsInfo.Location = new System.Drawing.Point(0, 0);
            this.pgColumnsInfo.Name = "pgColumnsInfo";
            this.pgColumnsInfo.Size = new System.Drawing.Size(782, 168);
            this.pgColumnsInfo.TabIndex = 9;
            this.pgColumnsInfo.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgColumnsInfo_PropertyValueChanged);
            // 
            // frmAddTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 503);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddTable";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Table";
            this.Load += new System.EventHandler(this.frmAddTable_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAddTable_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreation)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCreation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMax;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPrimaryKey;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIdentity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colNull;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUnique;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefaultValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCollation;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PropertyGrid pgColumnsInfo;
    }
}