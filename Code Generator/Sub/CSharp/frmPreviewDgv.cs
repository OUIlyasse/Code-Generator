using BL;
using BL.Configs;
using BL.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_Generator.Sub.CSharp
{
    public partial class frmPreviewDgv : Form
    {
        public dbInfo dbInfo { get; set; }
        public BL.iSQL.SQL SQL { get; set; }

        private void CopyColumns(DataGridView source, DataGridView destination)
        {
            foreach (DataGridViewColumn sourceColumn in source.Columns)
            {
                DataGridViewColumn newColumn = (DataGridViewColumn)Activator.CreateInstance(sourceColumn.GetType());
                newColumn.HeaderText = sourceColumn.HeaderText;
                newColumn.Name = sourceColumn.Name;
                newColumn.AutoSizeMode = sourceColumn.AutoSizeMode;
                newColumn.DataPropertyName = sourceColumn.DataPropertyName;
                //newColumn.ReadOnly = sourceColumn.ReadOnly;
                //newColumn.Visible = sourceColumn.Visible;

                destination.Columns.Add(newColumn);
                newColumn.ReadOnly = sourceColumn.ReadOnly;
                newColumn.Visible = sourceColumn.Visible;
            }
            //destination = source;
        }

        public frmPreviewDgv(DataGridView dgv, string tableName)
        {
            InitializeComponent();
            dbInfo = HDbInfo.LoadConfiguration();
            SQL = new BL.iSQL.SQL(dbInfo.conString, dbInfo.DatabaseName);
            //dataGridView1 = dgv;
            dgv.CopyTo(dataGridView1);
            CopyColumns(dgv, dataGridView1);
            SQL.GetData(dataGridView1, tableName);
        }
    }
}