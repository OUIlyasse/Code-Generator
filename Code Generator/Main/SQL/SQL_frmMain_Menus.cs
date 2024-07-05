using Code_Generator.Sub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTIL;

namespace Code_Generator.Main.SQL
{
    public partial class SQL_frmMain
    {
        #region Tables

        private void Delete_Table()
        {
            if (dgvTable.CurrentCell != null)
            {
                DataGridViewCell currentCell = dgvTable.CurrentCell;
                string table = $"{currentCell.Value}";
                var rs = MessageBox.Show($"Do you want to delete this table\n\n-{table}", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    string msg;
                    SQL.Delete_Table(table, out msg);
                    LoadTables();
                    if (SQL.state == true)
                        showStatus(msg);
                }
            }
        }

        private void Rename_Table()
        {
            if (dgvTable.CurrentCell != null)
            {
                DataGridViewCell currentCell = dgvTable.CurrentCell;
                string table = $"{currentCell.Value}";
                using (frmChange frm = new frmChange("Change Table", table))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        string msg;
                        SQL.Rename_Table(table, frm.TextChange, out msg);
                        LoadTables();
                        if (SQL.state == true)
                            showStatus(msg);
                    }
                }
            }
        }

        private void Create_Table()
        {
            if (dgvTable.CurrentCell != null)
            {
                DataGridViewCell currentCell = dgvTable.CurrentCell;
                string table = $"{currentCell.Value}";
                Cursor = Cursors.WaitCursor;
                string msg;
                string query = SQL.Create_Table(table, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");

                Cursor = Cursors.Default;
            }
        }

        private void Drop_Table()
        {
            if (dgvTable.CurrentCell != null)
            {
                DataGridViewCell currentCell = dgvTable.CurrentCell;
                string table = $"{currentCell.Value}";
                Cursor = Cursors.WaitCursor;
                string msg;
                string query = SQL.Drop_Table(table, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");

                Cursor = Cursors.Default;
            }
        }

        private void DropAndCreate_Table()
        {
            if (dgvTable.CurrentCell != null)
            {
                DataGridViewCell currentCell = dgvTable.CurrentCell;
                string table = $"{currentCell.Value}";
                Cursor = Cursors.WaitCursor;
                string msg;
                string query = SQL.DropAndCreate_Table(table, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");

                Cursor = Cursors.Default;
            }
        }

        #endregion Tables

        #region Views

        private void Delete_View()
        {
            if (dgvView.CurrentCell != null)
            {
                DataGridViewCell currentCell = dgvView.CurrentCell;
                string table = $"{currentCell.Value}";

                var rs = MessageBox.Show($"Do you want to delete this view\n\n-{table}", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    string msg;
                    SQL.Delete_View(table, out msg);
                    LoadViews();
                    if (SQL.state == true)
                        showStatus(msg);
                }
            }
        }

        private void Rename_View()
        {
            if (dgvView.CurrentCell != null)
            {
                DataGridViewCell currentCell = dgvView.CurrentCell;
                string table = $"{currentCell.Value}";

                using (frmChange frm = new frmChange("Change View", table))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        string msg;
                        SQL.Rename_View(table, frm.TextChange, out msg);
                        LoadViews();
                        if (SQL.state == true)
                            showStatus(msg);
                    }
                }
            }
        }

        private void Create_View()
        {
            if (dgvView.CurrentCell != null)
            {
                DataGridViewCell currentCell = dgvView.CurrentCell;
                string table = $"{currentCell.Value}";
                Cursor = Cursors.WaitCursor;
                string msg;
                string query = SQL.Create_View(table, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");

                Cursor = Cursors.Default;
            }
        }

        private void Alter_View()
        {
            if (dgvView.CurrentCell != null)
            {
                DataGridViewCell currentCell = dgvView.CurrentCell;
                string table = $"{currentCell.Value}";
                Cursor = Cursors.WaitCursor;
                string msg;
                string query = SQL.Alter_View(table, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");

                Cursor = Cursors.Default;
            }
        }

        private void Drop_View()
        {
            if (dgvView.CurrentCell != null)
            {
                DataGridViewCell currentCell = dgvView.CurrentCell;
                string table = $"{currentCell.Value}";
                Cursor = Cursors.WaitCursor;
                string msg;
                string query = SQL.Drop_View(table, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");

                Cursor = Cursors.Default;
            }
        }

        private void DropAndCreate_View()
        {
            if (dgvView.CurrentCell != null)
            {
                DataGridViewCell currentCell = dgvView.CurrentCell;
                string table = $"{currentCell.Value}";
                Cursor = Cursors.WaitCursor;
                string msg;
                string query = SQL.DropAndCreate_View(table, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");

                Cursor = Cursors.Default;
            }
        }

        #endregion Views

        #region SP

        private void New_SP()
        {
            if (dgvSP.CurrentCell != null)
            {
                DataGridViewCell currentCell = dgvSP.CurrentCell;
                string table = $"{currentCell.Value}";
                Cursor = Cursors.WaitCursor;
                string msg;
                string query = SQL.New_SP(table, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");

                Cursor = Cursors.Default;
            }
        }

        private void Create_SP()
        {
            if (dgvSP.CurrentCell != null)
            {
                DataGridViewCell currentCell = dgvSP.CurrentCell;
                string table = $"{currentCell.Value}";
                Cursor = Cursors.WaitCursor;
                string msg;
                string query = SQL.Create_SP(table, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");

                Cursor = Cursors.Default;
            }
        }

        private void Update_SP()
        {
            if (dgvSP.CurrentCell != null)
            {
                DataGridViewCell currentCell = dgvSP.CurrentCell;
                string table = $"{currentCell.Value}";
                Cursor = Cursors.WaitCursor;
                string msg;
                string query = SQL.Alter_SP(table, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");

                Cursor = Cursors.Default;
            }
        }

        private void Rename_SP()
        {
            if (dgvSP.CurrentCell != null)
            {
                DataGridViewCell currentCell = dgvSP.CurrentCell;
                string table = $"{currentCell.Value}";
                using (frmChange frm = new frmChange("Change procedure name", table))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        string msg;
                        SQL.Rename_SP(table, frm.TextChange, out msg);
                        LoadSP();
                        if (SQL.state == true)
                            showStatus(msg);
                    }
                }
            }
        }

        private void Delete_SP()
        {
            if (dgvSP.CurrentCell != null)
            {
                DataGridViewCell currentCell = dgvSP.CurrentCell;
                string table = $"{currentCell.Value}";

                var rs = MessageBox.Show($"Do you want to delete this procedure\n\n-{table}", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    string msg;
                    SQL.Delete_SP(table, out msg);
                    LoadSP();
                    if (SQL.state == true)
                        showStatus(msg);
                }
            }
        }

        private void Drop_SP()
        {
            if (dgvSP.CurrentCell != null)
            {
                DataGridViewCell currentCell = dgvSP.CurrentCell;
                string table = $"{currentCell.Value}";
                Cursor = Cursors.WaitCursor;
                string msg;
                string query = SQL.Drop_SP(table, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");

                Cursor = Cursors.Default;
            }
        }

        private void DropAndCreate_SP()
        {
            if (dgvSP.CurrentCell != null)
            {
                DataGridViewCell currentCell = dgvSP.CurrentCell;
                string table = $"{currentCell.Value}";
                Cursor = Cursors.WaitCursor;
                string msg;
                string query = SQL.DropAndCreate_SP(table, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");

                Cursor = Cursors.Default;
            }
        }

        #endregion SP
    }
}