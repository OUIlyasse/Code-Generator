namespace Code_Generator.UC
{
    partial class ucEditor
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucEditor));
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExecute = new System.Windows.Forms.ToolStripMenuItem();
            this.btnComment = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUncomment = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCut = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPast = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSelectAllAndCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTypeFile = new System.Windows.Forms.ToolStripSplitButton();
            this.btnNormalText = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSQL = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCSharp = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVBNET = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSelection = new System.Windows.Forms.ToolStripStatusLabel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pnlIndicator = new System.Windows.Forms.Panel();
            this.picLines = new System.Windows.Forms.Panel();
            this.btnAddInSnippets = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnAddInSnippets,
            this.toolStripSeparator5,
            this.btnClear,
            this.toolStripSeparator2,
            this.btnExecute,
            this.btnComment,
            this.btnUncomment,
            this.toolStripSeparator1,
            this.btnUndo,
            this.btnRedo,
            this.toolStripSeparator3,
            this.btnCut,
            this.btnCopy,
            this.btnPast,
            this.toolStripSeparator4,
            this.btnSelectAllAndCopy});
            this.menu.Name = "contextMenuStrip2";
            this.menu.Size = new System.Drawing.Size(253, 298);
            this.menu.Opening += new System.ComponentModel.CancelEventHandler(this.menu_Opening);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Roboto", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Name = "btnSave";
            this.btnSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.btnSave.Size = new System.Drawing.Size(252, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(249, 6);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Roboto", 9F);
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(252, 22);
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(249, 6);
            // 
            // btnExecute
            // 
            this.btnExecute.Font = new System.Drawing.Font("Roboto", 9F);
            this.btnExecute.ForeColor = System.Drawing.Color.Black;
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(252, 22);
            this.btnExecute.Text = "Execute";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnComment
            // 
            this.btnComment.Font = new System.Drawing.Font("Roboto", 9F);
            this.btnComment.ForeColor = System.Drawing.Color.Black;
            this.btnComment.Name = "btnComment";
            this.btnComment.Size = new System.Drawing.Size(252, 22);
            this.btnComment.Text = "Comment Selected Line";
            this.btnComment.Click += new System.EventHandler(this.btnComment_Click);
            // 
            // btnUncomment
            // 
            this.btnUncomment.Font = new System.Drawing.Font("Roboto", 9F);
            this.btnUncomment.ForeColor = System.Drawing.Color.Black;
            this.btnUncomment.Name = "btnUncomment";
            this.btnUncomment.Size = new System.Drawing.Size(252, 22);
            this.btnUncomment.Text = "Uncomment Selected Line";
            this.btnUncomment.Click += new System.EventHandler(this.btnUncomment_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(249, 6);
            this.toolStripSeparator1.Visible = false;
            // 
            // btnUndo
            // 
            this.btnUndo.Font = new System.Drawing.Font("Roboto", 9F);
            this.btnUndo.ForeColor = System.Drawing.Color.Black;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.btnUndo.Size = new System.Drawing.Size(252, 22);
            this.btnUndo.Text = "Undo";
            this.btnUndo.Visible = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Font = new System.Drawing.Font("Roboto", 9F);
            this.btnRedo.ForeColor = System.Drawing.Color.Black;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.btnRedo.Size = new System.Drawing.Size(252, 22);
            this.btnRedo.Text = "Redo";
            this.btnRedo.Visible = false;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(249, 6);
            this.toolStripSeparator3.Visible = false;
            // 
            // btnCut
            // 
            this.btnCut.Font = new System.Drawing.Font("Roboto", 9F);
            this.btnCut.ForeColor = System.Drawing.Color.Black;
            this.btnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCut.Name = "btnCut";
            this.btnCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.btnCut.Size = new System.Drawing.Size(252, 22);
            this.btnCut.Text = "Cut";
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("Roboto", 9F);
            this.btnCopy.ForeColor = System.Drawing.Color.Black;
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.btnCopy.Size = new System.Drawing.Size(252, 22);
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPast
            // 
            this.btnPast.Font = new System.Drawing.Font("Roboto", 9F);
            this.btnPast.ForeColor = System.Drawing.Color.Black;
            this.btnPast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPast.Name = "btnPast";
            this.btnPast.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.btnPast.Size = new System.Drawing.Size(252, 22);
            this.btnPast.Text = "Past";
            this.btnPast.Click += new System.EventHandler(this.btnPast_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(249, 6);
            // 
            // btnSelectAllAndCopy
            // 
            this.btnSelectAllAndCopy.Font = new System.Drawing.Font("Roboto", 9F);
            this.btnSelectAllAndCopy.ForeColor = System.Drawing.Color.Black;
            this.btnSelectAllAndCopy.Name = "btnSelectAllAndCopy";
            this.btnSelectAllAndCopy.Size = new System.Drawing.Size(252, 22);
            this.btnSelectAllAndCopy.Text = "Select All And Copy";
            this.btnSelectAllAndCopy.Click += new System.EventHandler(this.btnSelectAllAndCopy_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTypeFile,
            this.lblTotal,
            this.lblSelection});
            this.statusStrip1.Location = new System.Drawing.Point(0, 171);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(398, 27);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTypeFile
            // 
            this.lblTypeFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblTypeFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNormalText,
            this.btnSQL,
            this.btnCSharp,
            this.btnVBNET});
            this.lblTypeFile.Image = ((System.Drawing.Image)(resources.GetObject("lblTypeFile.Image")));
            this.lblTypeFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lblTypeFile.Name = "lblTypeFile";
            this.lblTypeFile.Size = new System.Drawing.Size(54, 25);
            this.lblTypeFile.Text = "type";
            // 
            // btnNormalText
            // 
            this.btnNormalText.Name = "btnNormalText";
            this.btnNormalText.Size = new System.Drawing.Size(262, 26);
            this.btnNormalText.Text = "Normal text";
            this.btnNormalText.Click += new System.EventHandler(this.btnNormalText_Click);
            // 
            // btnSQL
            // 
            this.btnSQL.Name = "btnSQL";
            this.btnSQL.Size = new System.Drawing.Size(262, 26);
            this.btnSQL.Text = "Structured Query Language";
            this.btnSQL.Click += new System.EventHandler(this.btnSQL_Click);
            // 
            // btnCSharp
            // 
            this.btnCSharp.Name = "btnCSharp";
            this.btnCSharp.Size = new System.Drawing.Size(262, 26);
            this.btnCSharp.Text = "C# source";
            this.btnCSharp.Click += new System.EventHandler(this.btnCSharp_Click);
            // 
            // btnVBNET
            // 
            this.btnVBNET.Name = "btnVBNET";
            this.btnVBNET.Size = new System.Drawing.Size(262, 26);
            this.btnVBNET.Text = "Visual Basic source";
            this.btnVBNET.Click += new System.EventHandler(this.btnVBNET_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblTotal.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.lblTotal.Font = new System.Drawing.Font("Roboto", 9F);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(164, 22);
            this.lblTotal.Spring = true;
            this.lblTotal.Text = "total";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSelection
            // 
            this.lblSelection.Font = new System.Drawing.Font("Roboto", 9F);
            this.lblSelection.Name = "lblSelection";
            this.lblSelection.Size = new System.Drawing.Size(164, 22);
            this.lblSelection.Spring = true;
            this.lblSelection.Text = "selection";
            this.lblSelection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ContextMenuStrip = this.menu;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(75, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(323, 171);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            this.richTextBox1.SelectionChanged += new System.EventHandler(this.richTextBox1_SelectionChanged);
            this.richTextBox1.VScroll += new System.EventHandler(this.richTextBox1_VScroll);
            this.richTextBox1.FontChanged += new System.EventHandler(this.richTextBox1_FontChanged);
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            this.richTextBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseDoubleClick);
            // 
            // pnlIndicator
            // 
            this.pnlIndicator.BackColor = System.Drawing.SystemColors.Menu;
            this.pnlIndicator.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIndicator.Location = new System.Drawing.Point(65, 0);
            this.pnlIndicator.Name = "pnlIndicator";
            this.pnlIndicator.Size = new System.Drawing.Size(10, 171);
            this.pnlIndicator.TabIndex = 5;
            // 
            // picLines
            // 
            this.picLines.BackColor = System.Drawing.SystemColors.Menu;
            this.picLines.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLines.Location = new System.Drawing.Point(0, 0);
            this.picLines.Name = "picLines";
            this.picLines.Size = new System.Drawing.Size(65, 171);
            this.picLines.TabIndex = 4;
            // 
            // btnAddInSnippets
            // 
            this.btnAddInSnippets.Name = "btnAddInSnippets";
            this.btnAddInSnippets.Size = new System.Drawing.Size(252, 22);
            this.btnAddInSnippets.Text = "Add in Snippets";
            this.btnAddInSnippets.Click += new System.EventHandler(this.btnAddInSnippets_Click);
            // 
            // ucEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pnlIndicator);
            this.Controls.Add(this.picLines);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucEditor";
            this.Size = new System.Drawing.Size(398, 198);
            this.menu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem btnExecute;
        private System.Windows.Forms.ToolStripMenuItem btnComment;
        private System.Windows.Forms.ToolStripMenuItem btnUncomment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnUndo;
        private System.Windows.Forms.ToolStripMenuItem btnRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem btnCut;
        private System.Windows.Forms.ToolStripMenuItem btnCopy;
        private System.Windows.Forms.ToolStripMenuItem btnPast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem btnSelectAllAndCopy;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel pnlIndicator;
        private System.Windows.Forms.Panel picLines;
        private System.Windows.Forms.ToolStripStatusLabel lblTotal;
        private System.Windows.Forms.ToolStripStatusLabel lblSelection;
        private System.Windows.Forms.ToolStripMenuItem btnClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSplitButton lblTypeFile;
        private System.Windows.Forms.ToolStripMenuItem btnNormalText;
        private System.Windows.Forms.ToolStripMenuItem btnSQL;
        private System.Windows.Forms.ToolStripMenuItem btnCSharp;
        private System.Windows.Forms.ToolStripMenuItem btnVBNET;
        private System.Windows.Forms.ToolStripMenuItem btnAddInSnippets;
    }
}
