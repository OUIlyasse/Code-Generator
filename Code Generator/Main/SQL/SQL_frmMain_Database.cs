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
        #region CRUD

        private void Insert_SQL()
        {
            if (SQL.countSelected(uc_Creating1.dgvCreation) > 0)
            {
                Cursor = Cursors.WaitCursor;

                string msg;
                string query = SQL.Insert(uc_Creating1.dgvCreation, TableName, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");
                else
                {
                    //Cursor = Cursors.Default;
                    //showStatus("Cannot to generate stored procedure .....");
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Cursor = Cursors.Default;
            }
            else
                MessageBox.Show($"You have not select any field yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Cursor = Cursors.Default;
        }

        private void Update_SQL()
        {
            if (SQL.countSelected(uc_Creating1.dgvCreation) > 0)
            {
                Cursor = Cursors.WaitCursor;

                string msg;
                string query = SQL.Update(uc_Creating1.dgvCreation, TableName, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");
                else
                {
                    //Cursor = Cursors.Default;
                    //showStatus("Cannot to generate stored procedure .....");
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Cursor = Cursors.Default;
            }
            else
                MessageBox.Show($"You have not select any field yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Cursor = Cursors.Default;
        }

        private void Delete_SQL()
        {
            if (SQL.countWhere(uc_Creating1.dgvCreation) > 0)
            {
                Cursor = Cursors.WaitCursor;

                string msg;
                string query = SQL.Delete(uc_Creating1.dgvCreation, TableName, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");
                else
                {
                    //Cursor = Cursors.Default;
                    //showStatus("Cannot to generate stored procedure .....");
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Cursor = Cursors.Default;
            }
            else
                MessageBox.Show($"You have not select any field yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Cursor = Cursors.Default;
        }

        private void Select_SQL()
        {
            if (SQL.countSelected(uc_Creating1.dgvCreation) > 0)
            {
                Cursor = Cursors.WaitCursor;

                string msg;
                string query = SQL.Select(uc_Creating1.dgvCreation, TableName, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");
                else
                {
                    //Cursor = Cursors.Default;
                    //showStatus("Cannot to generate stored procedure .....");
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Cursor = Cursors.Default;
            }
            else
                MessageBox.Show($"You have not select any field yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Cursor = Cursors.Default;
        }

        #endregion CRUD

        #region Aggregation

        private void AVG_SQL()
        {
            if (SQL.countSelected(uc_Creating1.dgvCreation) > 0)
            {
                Cursor = Cursors.WaitCursor;

                string msg;
                string query = SQL.AVG(uc_Creating1.dgvCreation, TableName, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");
                else
                {
                    //Cursor = Cursors.Default;
                    //showStatus("Cannot to generate stored procedure .....");
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Cursor = Cursors.Default;
            }
            else
                MessageBox.Show($"You have not select any field yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Cursor = Cursors.Default;
        }

        private void MAX_SQL()
        {
            if (SQL.countSelected(uc_Creating1.dgvCreation) > 0)
            {
                Cursor = Cursors.WaitCursor;

                string msg;
                string query = SQL.MAX(uc_Creating1.dgvCreation, TableName, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");
                else
                {
                    //Cursor = Cursors.Default;
                    //showStatus("Cannot to generate stored procedure .....");
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Cursor = Cursors.Default;
            }
            else
                MessageBox.Show($"You have not select any field yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Cursor = Cursors.Default;
        }

        private void MIN_SQL()
        {
            if (SQL.countSelected(uc_Creating1.dgvCreation) > 0)
            {
                Cursor = Cursors.WaitCursor;

                string msg;
                string query = SQL.MIN(uc_Creating1.dgvCreation, TableName, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");
                else
                {
                    //Cursor = Cursors.Default;
                    //showStatus("Cannot to generate stored procedure .....");
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Cursor = Cursors.Default;
            }
            else
                MessageBox.Show($"You have not select any field yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Cursor = Cursors.Default;
        }

        private void COUNT_SQL()
        {
            if (SQL.countSelected(uc_Creating1.dgvCreation) > 0)
            {
                Cursor = Cursors.WaitCursor;

                string msg;
                string query = SQL.COUNT(uc_Creating1.dgvCreation, TableName, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");
                else
                {
                    //Cursor = Cursors.Default;
                    //showStatus("Cannot to generate stored procedure .....");
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Cursor = Cursors.Default;
            }
            else
                MessageBox.Show($"You have not select any field yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Cursor = Cursors.Default;
        }

        private void SUM_SQL()
        {
            if (SQL.countSelected(uc_Creating1.dgvCreation) > 0)
            {
                Cursor = Cursors.WaitCursor;

                string msg;
                string query = SQL.SUM(uc_Creating1.dgvCreation, TableName, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");
                else
                {
                    //Cursor = Cursors.Default;
                    //showStatus("Cannot to generate stored procedure .....");
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Cursor = Cursors.Default;
            }
            else
                MessageBox.Show($"You have not select any field yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Cursor = Cursors.Default;
        }

        #endregion Aggregation

        #region Search

        private void Search_SQL()
        {
            if (SQL.countSelected(uc_Creating1.dgvCreation) > 0)
            {
                Cursor = Cursors.WaitCursor;

                string msg;
                string query = SQL.Search(uc_Creating1.dgvCreation, TableName, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");
                else
                {
                    //Cursor = Cursors.Default;
                    //showStatus("Cannot to generate stored procedure .....");
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Cursor = Cursors.Default;
            }
            else
                MessageBox.Show($"You have not select any field yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Cursor = Cursors.Default;
        }

        private void SearchAll_SQL()
        {
            if (SQL.countSelected(uc_Creating1.dgvCreation) > 0)
            {
                Cursor = Cursors.WaitCursor;

                string msg;
                string query = SQL.SearchAll(uc_Creating1.dgvCreation, TableName, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");
                else
                {
                    //Cursor = Cursors.Default;
                    //showStatus("Cannot to generate stored procedure .....");
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Cursor = Cursors.Default;
            }
            else
                MessageBox.Show($"You have not select any field yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Cursor = Cursors.Default;
        }

        private void SearchBetweenDate_SQL()
        {
            if (SQL.countSelected(uc_Creating1.dgvCreation) > 0 && SQL.countWhereAndDate(uc_Creating1.dgvCreation) > 0)
            {
                Cursor = Cursors.WaitCursor;

                string msg;
                string query = SQL.SearchBetweenDate(uc_Creating1.dgvCreation, TableName, out msg);
                FillEditor(query, Language.SQL);

                if (SQL.state)
                    showStatus($"Stored procedure has generate successfully .....");
                else
                {
                    //Cursor = Cursors.Default;
                    //showStatus("Cannot to generate stored procedure .....");
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Cursor = Cursors.Default;
            }
            else
                MessageBox.Show($"You have not select any field yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Cursor = Cursors.Default;
        }

        #endregion Search
    }
}