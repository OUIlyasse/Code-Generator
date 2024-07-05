using BL.Helper;
using Code_Generator.Sub.CSharp;
using Code_Generator.Sub.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using UTIL;

namespace Code_Generator.Main.SQL
{
    public partial class SQL_frmMain
    {
        #region CRUD

        private void Insert_LF()
        {
            if (CSharp.countSelected(uc_Creating1.dgvCreation) > 0)
            {
                Cursor = Cursors.WaitCursor;

                string msg;

                var rs = HConfigs.LoadConfiguration();
                string query = CSharp.Insert(uc_Creating1.dgvCreation, TableName, rs.Procedure.ToText(), out msg);
                FillEditor(query, Language.CSharp);

                if (CSharp.state)
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

        private void Update_LF()
        {
            if (CSharp.countSelected(uc_Creating1.dgvCreation) > 0)
            {
                Cursor = Cursors.WaitCursor;

                string msg;

                var rs = HConfigs.LoadConfiguration();
                string query = CSharp.Update(uc_Creating1.dgvCreation, TableName, rs.Procedure.ToText(), out msg);
                FillEditor(query, Language.CSharp);

                if (CSharp.state)
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

        private void Delete_LF()
        {
            if (CSharp.countWhere(uc_Creating1.dgvCreation) > 0)
            {
                Cursor = Cursors.WaitCursor;

                string msg;

                var rs = HConfigs.LoadConfiguration();
                string query = CSharp.Delete(uc_Creating1.dgvCreation, TableName, rs.Procedure.ToText(), out msg);
                FillEditor(query, Language.CSharp);

                if (CSharp.state)
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

        private void Select_LF()
        {
            Cursor = Cursors.WaitCursor;

            string msg;

            var rs = HConfigs.LoadConfiguration();
            string query = CSharp.Select(uc_Creating1.dgvCreation, TableName, rs.Procedure.ToText(), out msg);
            FillEditor(query, Language.CSharp);

            if (CSharp.state)
                showStatus($"Stored procedure has generate successfully .....");
            else
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Cursor = Cursors.Default;
        }

        #endregion CRUD

        #region Aggregation

        public void AVG_LF()
        {
            Cursor = Cursors.WaitCursor;

            string msg;

            var rs = HConfigs.LoadConfiguration();
            string query = CSharp.AVG(uc_Creating1.dgvCreation, TableName, rs.Procedure.ToText(), out msg);
            FillEditor(query, Language.CSharp);

            if (CSharp.state)
                showStatus($"Stored procedure has generate successfully .....");
            else
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Cursor = Cursors.Default;
        }

        public void MAX_LF()
        {
            Cursor = Cursors.WaitCursor;

            string msg;

            var rs = HConfigs.LoadConfiguration();
            string query = CSharp.MAX(uc_Creating1.dgvCreation, TableName, rs.Procedure.ToText(), out msg);
            FillEditor(query, Language.CSharp);

            if (CSharp.state)
                showStatus($"Stored procedure has generate successfully .....");
            else
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Cursor = Cursors.Default;
        }

        public void MIN_LF()
        {
            Cursor = Cursors.WaitCursor;

            string msg;

            var rs = HConfigs.LoadConfiguration();
            string query = CSharp.MIN(uc_Creating1.dgvCreation, TableName, rs.Procedure.ToText(), out msg);
            FillEditor(query, Language.CSharp);

            if (CSharp.state)
                showStatus($"Stored procedure has generate successfully .....");
            else
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Cursor = Cursors.Default;
        }

        public void COUNT_LF()
        {
            Cursor = Cursors.WaitCursor;

            string msg;

            var rs = HConfigs.LoadConfiguration();
            string query = CSharp.COUNT(uc_Creating1.dgvCreation, TableName, rs.Procedure.ToText(), out msg);
            FillEditor(query, Language.CSharp);

            if (CSharp.state)
                showStatus($"Stored procedure has generate successfully .....");
            else
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Cursor = Cursors.Default;
        }

        public void SUM_LF()
        {
            Cursor = Cursors.WaitCursor;

            string msg;

            var rs = HConfigs.LoadConfiguration();
            string query = CSharp.SUM(uc_Creating1.dgvCreation, TableName, rs.Procedure.ToText(), out msg);
            FillEditor(query, Language.CSharp);

            if (CSharp.state)
                showStatus($"Stored procedure has generate successfully .....");
            else
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Cursor = Cursors.Default;
        }

        #endregion Aggregation

        #region Search

        public void Search_LF()
        {
            if (CSharp.countSelected(uc_Creating1.dgvCreation) > 0)
            {
                Cursor = Cursors.WaitCursor;

                string msg;

                var rs = HConfigs.LoadConfiguration();
                string query = CSharp.Search(uc_Creating1.dgvCreation, TableName, rs.Procedure.ToText(), out msg);
                FillEditor(query, Language.CSharp);

                if (CSharp.state)
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

        public void SearchAll_LF()
        {
            if (CSharp.countSelected(uc_Creating1.dgvCreation) > 0)
            {
                Cursor = Cursors.WaitCursor;

                string msg;

                var rs = HConfigs.LoadConfiguration();
                string query = CSharp.SearchAll(uc_Creating1.dgvCreation, TableName, rs.Procedure.ToText(), out msg);
                FillEditor(query, Language.CSharp);

                if (CSharp.state)
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

        public void SearchBetweenDate_LF()
        {
            if (CSharp.countSelected(uc_Creating1.dgvCreation) > 0)
            {
                Cursor = Cursors.WaitCursor;

                string msg;

                var rs = HConfigs.LoadConfiguration();
                string query = CSharp.SearchBetweenDate(uc_Creating1.dgvCreation, TableName, rs.Procedure.ToText(), out msg);
                FillEditor(query, Language.CSharp);

                if (CSharp.state)
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

        #region Controls

        private void CreateControls()
        {
            if (CSharp.countSelected(uc_Creating1.dgvCreation) > 0)
            {
                Cursor = Cursors.WaitCursor;

                string msg;

                string query = CSharp.CreateControls(uc_Creating1.dgvCreation, out msg);
                FillEditor(query, Language.CSharp);

                if (CSharp.state)
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

        private void CreateDataGridView()
        {
            Cursor = Cursors.WaitCursor;

            if (CSharp.countSelected(uc_Creating1.dgvCreation) > 0)
            {
                frmCustomDatagridview frm = new frmCustomDatagridview(TableName, uc_Creating1.MyGrid);
                string msg = "";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string query = CSharp.CreateCustomDatagridview(frm.dgvColumn, frm.PropDatagridview, frm.Evs, out msg);
                    FillEditor(query, Language.CSharp);
                    if (CSharp.state)
                        showStatus($"Create DatagridView Controls function has generate successfully .....");
                    else
                    {
                        //showStatus("Cannot to generate Create DatagridView Controls function .....");
                        MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show($"You have not select any field yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Cursor = Cursors.Default;
        }

        #endregion Controls

        private void GenerateVariables()
        {
            Cursor = Cursors.WaitCursor;
            string msg;
            var rs = HConfigs.LoadConfiguration();
            string query = CSharp.GenerateVariables(rs.Variable.ToText(), out msg);
            FillEditor(query, Language.CSharp);
            if (SQL.state)
                showStatus("Function [Generate variables] has generate successfully .....");
            else
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Cursor = Cursors.Default;
        }

        private void OpenConnection()
        {
            Cursor = Cursors.WaitCursor;
            string msg;
            var rs = HConfigs.LoadConfiguration();
            string query = CSharp.OpenConnection(rs.Procedure.ToText(), out msg);
            FillEditor(query, Language.CSharp);
            if (SQL.state)
                showStatus("Function has generate successfully .....");
            else
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Cursor = Cursors.Default;
        }

        private void CloseConnection()
        {
            Cursor = Cursors.WaitCursor;
            string msg;
            var rs = HConfigs.LoadConfiguration();
            string query = CSharp.CloseConnection(rs.Procedure.ToText(), out msg);
            FillEditor(query, Language.CSharp);
            if (SQL.state)
                showStatus("Function has generate successfully .....");
            else
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Cursor = Cursors.Default;
        }

        private void FillCombo()
        {
            Cursor = Cursors.WaitCursor;
            string msg;
            var rs = HConfigs.LoadConfiguration();
            string query = CSharp.FillCombo(uc_Creating1.MyGrid, rs.Procedure.ToText(), out msg);
            FillEditor(query, Language.CSharp);
            if (SQL.state)
                showStatus("Function has generate successfully .....");
            else
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Cursor = Cursors.Default;
        }

        private void GenerateFunctions()
        {
            if (CSharp.countSelected(uc_Creating1.dgvCreation) > 0 && CSharp.countWhere(uc_Creating1.dgvCreation) > 0)
            {
                Cursor = Cursors.WaitCursor;
                string msg;
                var rs = HConfigs.LoadConfiguration();
                string query = CSharp.GenerateFunctions(uc_Creating1.dgvCreation, TableName, rs.Procedure.ToText(), rs.Variable.ToText(), out msg);
                FillEditor(query, Language.CSharp);
                if (SQL.state)
                    showStatus("Function [Generate All Functions] has generate successfully .....");
                else
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Cursor = Cursors.Default;
            }
        }
    }
}