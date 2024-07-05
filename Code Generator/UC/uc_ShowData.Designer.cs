namespace Code_Generator.UC
{
    partial class uc_ShowData
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_ShowData));
            this.imgSQL = new System.Windows.Forms.ImageList(this.components);
            this.menuSQL = new AutocompleteMenuNS.AutocompleteMenu();
            this.rtbSQLQuery = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // imgSQL
            // 
            this.imgSQL.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgSQL.ImageStream")));
            this.imgSQL.TransparentColor = System.Drawing.Color.Transparent;
            this.imgSQL.Images.SetKeyName(0, "Tables_16.png");
            this.imgSQL.Images.SetKeyName(1, "Colonnes_16.png");
            this.imgSQL.Images.SetKeyName(2, "Sys_16.png");
            // 
            // menuSQL
            // 
            this.menuSQL.AppearInterval = 2;
            this.menuSQL.Colors = ((AutocompleteMenuNS.Colors)(resources.GetObject("menuSQL.Colors")));
            this.menuSQL.Font = new System.Drawing.Font("Roboto", 9F);
            this.menuSQL.ImageList = this.imgSQL;
            this.menuSQL.Items = new string[0];
            this.menuSQL.MaximumSize = new System.Drawing.Size(250, 200);
            this.menuSQL.TargetControlWrapper = null;
            // 
            // rtbSQLQuery
            // 
            this.menuSQL.SetAutocompleteMenu(this.rtbSQLQuery, this.menuSQL);
            this.rtbSQLQuery.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSQLQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSQLQuery.Location = new System.Drawing.Point(0, 0);
            this.rtbSQLQuery.Name = "rtbSQLQuery";
            this.rtbSQLQuery.Size = new System.Drawing.Size(248, 148);
            this.rtbSQLQuery.TabIndex = 1;
            this.rtbSQLQuery.Text = "";
            this.rtbSQLQuery.TextChanged += new System.EventHandler(this.rtbSQLQuery_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // uc_ShowData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.rtbSQLQuery);
            this.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "uc_ShowData";
            this.Size = new System.Drawing.Size(248, 148);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgSQL;
        private AutocompleteMenuNS.AutocompleteMenu menuSQL;
        private System.Windows.Forms.RichTextBox rtbSQLQuery;
        private System.Windows.Forms.Timer timer1;
    }
}
