using BL.Configs;
using BL.Helper;
using Code_Generator.Main.SQL;
using Code_Generator.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTIL;

namespace Code_Generator.Sub
{
    public partial class frmCodeSnippet : Form
    {
        #region variables

        private SQL_frmMain frm;
        private DataTable dt;

        #endregion variables

        #region codes

        private string NormalText(string rtfText)
        {
            using (RichTextBox rich = new RichTextBox())
            {
                rich.Rtf = rtfText;
                return rich.Text;
            }
        }

        private ucEditor GetEditorFromTab(TabPage tabPage)
        {
            ucEditor rs = new ucEditor(frm);
            foreach (Control ctr in tabPage.Controls)
            {
                // Check if the control is a RichTextBox
                if (ctr is ucEditor)
                {
                    rs = (ucEditor)ctr;
                    break;
                }
            }
            return rs;
        }

        private void setData()
        {
            dt = new DataTable();
            dt.Columns.Add("Snippet", typeof(string));

            var config = HSnippets.LoadConfiguration();
            foreach (var tm in config.Snippets)
                dt.Rows.Add(tm.Name);

            dgvSnippet.DataSource = dt;
        }

        private void addLangEditor(Language lang, string content)
        {
            frm.ucEditor1.Editor.Rtf = content;
            frm.ucEditor1.Syntaxe = lang;
            frm.tcResult.SelectedTab = frm.tpResult;
        }

        #endregion codes

        public frmCodeSnippet(SQL_frmMain frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSnippet frm = new frmSnippet();
            var dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                setData();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (dgvSnippet.SelectedRows.Count == 1)
            {
                string temp = dgvSnippet.CurrentRow.Cells[colName.Name].Value.ToString();
                var r = HSnippets.LoadConfiguration();
                var rs = r.Snippets.FirstOrDefault(x => x.Name == temp);

                addLangEditor(rs.Synatxe, rs.Text);
                //frm.infoSP.SpName = "Snippet";
                //frm.setGridSP();
                //frm.pgInfo.Refresh();
                Close();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSnippet.SelectedRows.Count == 1)
            {
                string temp = dgvSnippet.CurrentRow.Cells[colName.Name].Value.ToString();
                var r = HSnippets.LoadConfiguration();
                var rs = r.Snippets.FirstOrDefault(x => x.Name == temp);
                frmSnippet addEntry = new frmSnippet(rs);

                if (addEntry.ShowDialog() == DialogResult.OK)
                {
                    setData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSnippet.SelectedRows.Count == 1)
            {
                string snp = dgvSnippet.CurrentRow.Cells[colName.Name].Value.ToString();
                var rs = MessageBox.Show($"Are you sure you want to delete the snippet:\n{snp}", "Snippets", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    var r = HSnippets.LoadConfiguration();
                    var rss = r.Snippets.FirstOrDefault(x => x.Name == snp);
                    r.Snippets.Remove(rss);
                    HSnippets.SaveConfiguration(r);
                    setData();
                }
            }
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            if (dgvSnippet.SelectedRows.Count == 1)
            {
                string snp = dgvSnippet.CurrentRow.Cells[colName.Name].Value.ToString();
                var r = HSnippets.LoadConfiguration();
                var rss = r.Snippets.FirstOrDefault(x => x.Name == snp);

                string name = $"{snp} - dup";

                bool rs = r.Snippets.Any(x => x.Name == name);
                if (rs == true)
                {
                    MessageBox.Show("This snippet already exists", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //DialogResult = DialogResult.None;
                    return;
                }

                var ns = new CodeSnippet(Guid.NewGuid().ToString(), name, rss.Text, rss.Synatxe);
                r.Snippets.Add(ns);
                HSnippets.SaveConfiguration(r);
                setData();
            }
        }

        private void btnAddFromSelection_Click(object sender, EventArgs e)
        {
            var uc = GetEditorFromTab(frm.tpResult);
            if (uc != null)
            {
                string clip = uc.Editor.SelectedText;
                if (!string.IsNullOrEmpty(clip))
                {
                    frmSnippet frm = new frmSnippet(clip, uc.Syntaxe.ToString());
                    var dr = frm.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        setData();
                    }
                }
            }
        }

        private void btnAddFromClipboard_Click(object sender, EventArgs e)
        {
            string clip = Clipboard.GetText();
            if (!string.IsNullOrEmpty(clip))
            {
                frmSnippet frm = new frmSnippet(clip, "Custom");
                var dr = frm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    setData();
                }
            }
        }

        private void frmCodeSnippet_Load(object sender, EventArgs e)
        {
            setData();
        }

        private void dgvSnippet_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            e.ContextMenuStrip = menu;

            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                btnInsert.Visible = false;
                toolStripSeparator1.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnDuplicate.Visible = false;
                toolStripSeparator3.Visible = false;
                btnExport.Visible = false;
            }
            else
            {
                btnInsert.Visible = true;
                toolStripSeparator1.Visible = true;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                btnDuplicate.Visible = true;
                toolStripSeparator3.Visible = true;
                btnExport.Visible = true;
            }
        }

        private void txtSerach_TextChanged(object sender, EventArgs e)
        {
            var config = HSnippets.LoadConfiguration();
            string searchQuery = ((TextBox)sender).Text.ToLower();

            dt = new DataTable();
            dt.Columns.Add("Snippet", typeof(string));

            foreach (var item in config.Snippets)
            {
                if (item.Name.ToLower().Contains(searchQuery))
                    dt.Rows.Add(item.Name);
            }

            dgvSnippet.DataSource = dt;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvSnippet.SelectedRows.Count == 1)
            {
                string temp = dgvSnippet.CurrentRow.Cells[colName.Name].Value.ToString();
                var r = HSnippets.LoadConfiguration();
                var rs = r.Snippets.FirstOrDefault(x => x.Name == temp);

                int ind = -1;
                using (SaveFileDialog sv = new SaveFileDialog())
                {
                    sv.AddExtension = false;
                    sv.FileName = rs.Name;
                    sv.Title = "Save file";
                    sv.Filter = "SQL files (*.sql)|*.sql|C# files (*.cs)|*.cs|VB.Net files (*.vb)|*.vb|Normal Text (*.txt)|*.txt";
                    switch (rs.Synatxe)
                    {
                        case Language.Custom:
                            ind = 4;
                            break;

                        case Language.SQL:
                            ind = 1;
                            break;

                        case Language.CSharp:
                            ind = 2;
                            break;

                        case Language.VBNET:
                            ind = 3;
                            break;

                        default:
                            ind = 4;
                            break;
                    }
                    sv.FilterIndex = ind;
                    if (sv.ShowDialog() == DialogResult.OK)
                    {
                        Tools.Tools.SaveFile(sv.FileName, NormalText(rs.Text));
                        frm.showStatus("this snippet code exported successfully");
                    }
                }
            }
        }

        private void dgvSnippet_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            if (e.Button == MouseButtons.Right)
            {
                dgvSnippet.CurrentCell = dgvSnippet[e.ColumnIndex, e.RowIndex];
            }
        }
    }
}