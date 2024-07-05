using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTIL;

namespace Code_Generator.Sub.SQL
{
    public partial class frmDatabaseInfo : Form
    {
        #region Property

        public string DatabaseName
        {
            get { return lblDatabaseName.Text; }
            set { lblDatabaseName.Text = value; }
        }

        public string Owner_DB { get { return lblOwner.Text; } set { lblOwner.Text = value; } }
        public string DateCreated { get { return lblDateCreated.Text; } set { lblDateCreated.Text = value; } }
        public string Collation { get { return lblCollation.Text; } set { lblCollation.Text = value; } }
        public string CompatibilityLevel { get { return lblCompatibilityLevel.Text; } set { lblCompatibilityLevel.Text = value; } }
        public string RestrictAccess { get { return lblRestrictAccess.Text; } set { lblRestrictAccess.Text = value; } }

        public List<DatabaseFileInfo> Files
        {
            get
            {
                List<DatabaseFileInfo> list = dgvFiles.DataSource as List<DatabaseFileInfo>;

                if (list != null)
                {
                    foreach (var item in list)
                        list.Add(new DatabaseFileInfo()
                        {
                            FileName = item.FileName,
                            FileLocation = item.FileLocation
                        });
                }

                return list;
            }
            set
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("FileName"));
                dt.Columns.Add(new DataColumn("FileLocation"));

                foreach (var item in value)
                {
                    var row = dt.NewRow();
                    row["FileName"] = item.FileName;
                    row["FileLocation"] = item.FileLocation;
                    dt.Rows.Add(row);
                }

                dgvFiles.DataSource = dt;
            }
        }

        #endregion Property

        public frmDatabaseInfo()
        {
            InitializeComponent();
        }

        private void dgvFiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click is on the LinkColumn
            if (e.ColumnIndex == dgvFiles.Columns[colFileLocation.Name].Index && e.RowIndex >= 0)
            {
                // Get the path from the clicked row
                string path = dgvFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                try
                {
                    // Open the path
                    Process.Start(Path.GetDirectoryName(path));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open the path: {ex.Message}");
                }
            }
        }
    }
}