namespace Code_Generator.UC.SQL
{
    partial class ucSQL_Login
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
            this.gbSQL = new System.Windows.Forms.GroupBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.ckbRemember = new System.Windows.Forms.CheckBox();
            this.ckbShow = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.cmbxDatabase = new System.Windows.Forms.ComboBox();
            this.cmbxAuthentification = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbxServer = new System.Windows.Forms.ComboBox();
            this.gbSQL.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSQL
            // 
            this.gbSQL.Controls.Add(this.btnTestConnection);
            this.gbSQL.Controls.Add(this.ckbRemember);
            this.gbSQL.Controls.Add(this.ckbShow);
            this.gbSQL.Controls.Add(this.txtPassword);
            this.gbSQL.Controls.Add(this.txtUser);
            this.gbSQL.Controls.Add(this.cmbxDatabase);
            this.gbSQL.Controls.Add(this.cmbxAuthentification);
            this.gbSQL.Controls.Add(this.label5);
            this.gbSQL.Controls.Add(this.label4);
            this.gbSQL.Controls.Add(this.label3);
            this.gbSQL.Controls.Add(this.label2);
            this.gbSQL.Controls.Add(this.label1);
            this.gbSQL.Controls.Add(this.cmbxServer);
            this.gbSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSQL.Font = new System.Drawing.Font("Roboto Condensed", 10.2F, System.Drawing.FontStyle.Bold);
            this.gbSQL.Location = new System.Drawing.Point(0, 0);
            this.gbSQL.Name = "gbSQL";
            this.gbSQL.Size = new System.Drawing.Size(458, 447);
            this.gbSQL.TabIndex = 2;
            this.gbSQL.TabStop = false;
            this.gbSQL.Text = "Information about the SQL Server";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Font = new System.Drawing.Font("Roboto Condensed", 10.2F);
            this.btnTestConnection.Location = new System.Drawing.Point(251, 397);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(199, 44);
            this.btnTestConnection.TabIndex = 7;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // ckbRemember
            // 
            this.ckbRemember.AutoSize = true;
            this.ckbRemember.Font = new System.Drawing.Font("Roboto Condensed", 10.2F);
            this.ckbRemember.Location = new System.Drawing.Point(150, 350);
            this.ckbRemember.Name = "ckbRemember";
            this.ckbRemember.Size = new System.Drawing.Size(128, 24);
            this.ckbRemember.TabIndex = 6;
            this.ckbRemember.Text = "Remember me";
            this.ckbRemember.UseVisualStyleBackColor = true;
            // 
            // ckbShow
            // 
            this.ckbShow.AutoSize = true;
            this.ckbShow.Font = new System.Drawing.Font("Roboto Condensed", 10.2F);
            this.ckbShow.Location = new System.Drawing.Point(150, 260);
            this.ckbShow.Name = "ckbShow";
            this.ckbShow.Size = new System.Drawing.Size(137, 24);
            this.ckbShow.TabIndex = 4;
            this.ckbShow.Text = "Show password";
            this.ckbShow.UseVisualStyleBackColor = true;
            this.ckbShow.CheckedChanged += new System.EventHandler(this.ckbShow_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Roboto Condensed", 10.2F);
            this.txtPassword.Location = new System.Drawing.Point(150, 226);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(300, 28);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Roboto Condensed", 10.2F);
            this.txtUser.Location = new System.Drawing.Point(150, 168);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(300, 28);
            this.txtUser.TabIndex = 2;
            // 
            // cmbxDatabase
            // 
            this.cmbxDatabase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbxDatabase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbxDatabase.Font = new System.Drawing.Font("Roboto Condensed", 10.2F);
            this.cmbxDatabase.FormattingEnabled = true;
            this.cmbxDatabase.Location = new System.Drawing.Point(150, 316);
            this.cmbxDatabase.Name = "cmbxDatabase";
            this.cmbxDatabase.Size = new System.Drawing.Size(300, 28);
            this.cmbxDatabase.TabIndex = 5;
            this.cmbxDatabase.Enter += new System.EventHandler(this.cmbxDatabase_Enter);
            // 
            // cmbxAuthentification
            // 
            this.cmbxAuthentification.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbxAuthentification.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbxAuthentification.Font = new System.Drawing.Font("Roboto Condensed", 10.2F);
            this.cmbxAuthentification.FormattingEnabled = true;
            this.cmbxAuthentification.Items.AddRange(new object[] {
            "Windows Autentification",
            "SQL Server Autentification"});
            this.cmbxAuthentification.Location = new System.Drawing.Point(150, 110);
            this.cmbxAuthentification.Name = "cmbxAuthentification";
            this.cmbxAuthentification.Size = new System.Drawing.Size(300, 28);
            this.cmbxAuthentification.TabIndex = 1;
            this.cmbxAuthentification.SelectedIndexChanged += new System.EventHandler(this.cmbxAuthentification_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto Condensed", 10.2F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(9, 320);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Database:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto Condensed", 10.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(9, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto Condensed", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(9, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto Condensed", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(9, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Authentification:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(9, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server name:";
            // 
            // cmbxServer
            // 
            this.cmbxServer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbxServer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbxServer.Font = new System.Drawing.Font("Roboto Condensed", 10.2F);
            this.cmbxServer.FormattingEnabled = true;
            this.cmbxServer.Location = new System.Drawing.Point(150, 52);
            this.cmbxServer.Name = "cmbxServer";
            this.cmbxServer.Size = new System.Drawing.Size(300, 28);
            this.cmbxServer.TabIndex = 0;
            // 
            // ucSQL_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbSQL);
            this.Font = new System.Drawing.Font("Roboto Condensed", 10.2F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucSQL_Login";
            this.Size = new System.Drawing.Size(458, 447);
            this.Load += new System.EventHandler(this.ucSQL_Login_Load);
            this.gbSQL.ResumeLayout(false);
            this.gbSQL.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSQL;
        private System.Windows.Forms.CheckBox ckbShow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTestConnection;
        public System.Windows.Forms.CheckBox ckbRemember;
        public System.Windows.Forms.TextBox txtPassword;
        public System.Windows.Forms.TextBox txtUser;
        public System.Windows.Forms.ComboBox cmbxDatabase;
        public System.Windows.Forms.ComboBox cmbxAuthentification;
        public System.Windows.Forms.ComboBox cmbxServer;
    }
}
