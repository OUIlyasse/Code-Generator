namespace Code_Generator.UC
{
    partial class uc_AddTable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvTable = new System.Windows.Forms.DataGridView();
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
            this.pgColumnsInfo = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.dgvTable);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pgColumnsInfo);
            this.splitContainer1.Size = new System.Drawing.Size(630, 450);
            this.splitContainer1.SplitterDistance = 297;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvTable
            // 
            this.dgvTable.AllowUserToOrderColumns = true;
            this.dgvTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dgvTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTable.GridColor = System.Drawing.SystemColors.Control;
            this.dgvTable.Location = new System.Drawing.Point(0, 0);
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTable.RowHeadersVisible = false;
            this.dgvTable.RowHeadersWidth = 51;
            this.dgvTable.RowTemplate.Height = 24;
            this.dgvTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTable.Size = new System.Drawing.Size(630, 297);
            this.dgvTable.TabIndex = 8;
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
            // pgColumnsInfo
            // 
            this.pgColumnsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgColumnsInfo.HelpVisible = false;
            this.pgColumnsInfo.LineColor = System.Drawing.Color.WhiteSmoke;
            this.pgColumnsInfo.Location = new System.Drawing.Point(0, 0);
            this.pgColumnsInfo.Name = "pgColumnsInfo";
            this.pgColumnsInfo.Size = new System.Drawing.Size(630, 149);
            this.pgColumnsInfo.TabIndex = 9;
            // 
            // uc_AddTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Roboto", 10.2F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "uc_AddTable";
            this.Size = new System.Drawing.Size(630, 450);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvTable;
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
        private System.Windows.Forms.PropertyGrid pgColumnsInfo;
    }
}
