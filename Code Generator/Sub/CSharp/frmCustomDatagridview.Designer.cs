namespace Code_Generator.Sub.CSharp
{
    partial class frmCustomDatagridview
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNameDatagridView = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvColumn = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pgGrid = new System.Windows.Forms.PropertyGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnEvents = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTemplate = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnValidate = new System.Windows.Forms.Button();
            this.colColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColumnType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colAutoSizeMode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDataPropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeaderText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReadOnly = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colVisible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumn)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNameDatagridView
            // 
            this.lblNameDatagridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNameDatagridView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNameDatagridView.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameDatagridView.Location = new System.Drawing.Point(78, 9);
            this.lblNameDatagridView.Name = "lblNameDatagridView";
            this.lblNameDatagridView.Size = new System.Drawing.Size(726, 52);
            this.lblNameDatagridView.TabIndex = 2;
            this.lblNameDatagridView.Text = "Datagridview:";
            this.lblNameDatagridView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvColumn);
            this.groupBox2.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(679, 226);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Columns";
            // 
            // dgvColumn
            // 
            this.dgvColumn.AllowUserToAddRows = false;
            this.dgvColumn.AllowUserToDeleteRows = false;
            this.dgvColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvColumn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvColumn.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvColumn.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvColumn.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvColumn.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvColumn.ColumnHeadersHeight = 29;
            this.dgvColumn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colColumn,
            this.colName,
            this.colColumnType,
            this.colAutoSizeMode,
            this.colDataPropertyName,
            this.colHeaderText,
            this.colReadOnly,
            this.colVisible});
            this.dgvColumn.GridColor = System.Drawing.SystemColors.Control;
            this.dgvColumn.Location = new System.Drawing.Point(6, 26);
            this.dgvColumn.MultiSelect = false;
            this.dgvColumn.Name = "dgvColumn";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColumn.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvColumn.RowHeadersVisible = false;
            this.dgvColumn.RowHeadersWidth = 51;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvColumn.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvColumn.RowTemplate.Height = 24;
            this.dgvColumn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColumn.Size = new System.Drawing.Size(667, 194);
            this.dgvColumn.TabIndex = 27;
            this.dgvColumn.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColumn_CellEndEdit);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.pgGrid);
            this.groupBox1.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 314);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 297);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DatagridView";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(403, 23);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(84, 20);
            this.lblName.TabIndex = 18;
            this.lblName.Text = "Template:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pgGrid
            // 
            this.pgGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgGrid.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pgGrid.HelpVisible = false;
            this.pgGrid.Location = new System.Drawing.Point(6, 46);
            this.pgGrid.Name = "pgGrid";
            this.pgGrid.Size = new System.Drawing.Size(663, 245);
            this.pgGrid.TabIndex = 17;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnEvents);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.btnTemplate);
            this.groupBox3.Controls.Add(this.btnPreview);
            this.groupBox3.Location = new System.Drawing.Point(697, 82);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(173, 226);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            // 
            // btnEvents
            // 
            this.btnEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEvents.Location = new System.Drawing.Point(8, 71);
            this.btnEvents.Name = "btnEvents";
            this.btnEvents.Size = new System.Drawing.Size(157, 41);
            this.btnEvents.TabIndex = 10;
            this.btnEvents.Text = "Events";
            this.btnEvents.UseVisualStyleBackColor = true;
            this.btnEvents.Click += new System.EventHandler(this.btnEvents_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(8, 175);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(157, 41);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTemplate
            // 
            this.btnTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTemplate.Location = new System.Drawing.Point(8, 123);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(157, 41);
            this.btnTemplate.TabIndex = 8;
            this.btnTemplate.Text = "Template";
            this.btnTemplate.UseVisualStyleBackColor = true;
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(8, 19);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(157, 41);
            this.btnPreview.TabIndex = 7;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnValidate
            // 
            this.btnValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnValidate.Location = new System.Drawing.Point(713, 562);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(157, 49);
            this.btnValidate.TabIndex = 29;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // colColumn
            // 
            this.colColumn.DataPropertyName = "Column";
            this.colColumn.FillWeight = 513.369F;
            this.colColumn.HeaderText = "Column";
            this.colColumn.MinimumWidth = 120;
            this.colColumn.Name = "colColumn";
            this.colColumn.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "ColumnName";
            this.colName.FillWeight = 40.94729F;
            this.colName.HeaderText = "Column Name";
            this.colName.MinimumWidth = 120;
            this.colName.Name = "colName";
            // 
            // colColumnType
            // 
            this.colColumnType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colColumnType.DataPropertyName = "ColumnType";
            this.colColumnType.FillWeight = 40.94729F;
            this.colColumnType.HeaderText = "Type Column";
            this.colColumnType.MinimumWidth = 150;
            this.colColumnType.Name = "colColumnType";
            this.colColumnType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colColumnType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colColumnType.Width = 150;
            // 
            // colAutoSizeMode
            // 
            this.colAutoSizeMode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAutoSizeMode.DataPropertyName = "AutoSizeMode";
            this.colAutoSizeMode.FillWeight = 40.94729F;
            this.colAutoSizeMode.HeaderText = "Auto Size Mode";
            this.colAutoSizeMode.MinimumWidth = 150;
            this.colAutoSizeMode.Name = "colAutoSizeMode";
            this.colAutoSizeMode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAutoSizeMode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colAutoSizeMode.Width = 160;
            // 
            // colDataPropertyName
            // 
            this.colDataPropertyName.DataPropertyName = "DataPropertyName";
            this.colDataPropertyName.FillWeight = 40.94729F;
            this.colDataPropertyName.HeaderText = "DataPropertyName";
            this.colDataPropertyName.MinimumWidth = 120;
            this.colDataPropertyName.Name = "colDataPropertyName";
            // 
            // colHeaderText
            // 
            this.colHeaderText.DataPropertyName = "HeaderText";
            this.colHeaderText.FillWeight = 40.94729F;
            this.colHeaderText.HeaderText = "HeaderText";
            this.colHeaderText.MinimumWidth = 120;
            this.colHeaderText.Name = "colHeaderText";
            // 
            // colReadOnly
            // 
            this.colReadOnly.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colReadOnly.DataPropertyName = "ReadOnly";
            this.colReadOnly.FillWeight = 40.94729F;
            this.colReadOnly.HeaderText = "ReadOnly";
            this.colReadOnly.MinimumWidth = 6;
            this.colReadOnly.Name = "colReadOnly";
            this.colReadOnly.Width = 90;
            // 
            // colVisible
            // 
            this.colVisible.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colVisible.DataPropertyName = "Visible";
            this.colVisible.FillWeight = 40.94729F;
            this.colVisible.HeaderText = "Visible";
            this.colVisible.MinimumWidth = 6;
            this.colVisible.Name = "colVisible";
            this.colVisible.Width = 69;
            // 
            // frmCustomDatagridview
            // 
            this.AcceptButton = this.btnValidate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(882, 623);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblNameDatagridView);
            this.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "frmCustomDatagridview";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Custom Datagridview";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumn)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNameDatagridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.DataGridView dgvColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PropertyGrid pgGrid;
        private System.Windows.Forms.Button btnEvents;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTemplate;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colColumnType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colAutoSizeMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataPropertyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeaderText;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colReadOnly;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colVisible;
    }
}