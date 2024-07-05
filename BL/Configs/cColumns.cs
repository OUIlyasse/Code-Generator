using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL.Configs
{
    [Serializable]
    public class cColumns
    {
        private string column;
        private string columnName;
        private string columnType;
        private string autoSizeMode;
        private string dataPropertyName;
        private string headerText;
        private bool readOnly;
        private bool visible;

        public cColumns()
        {
            Column = "";
            ColumnName = "";
            ColumnType = "";
            AutoSizeMode = "";
            DataPropertyName = "";
            HeaderText = "";
            ReadOnly = false;
            Visible = true;
        }

        public string Column { get => column; set => column = value; }
        public string ColumnName { get => columnName; set => columnName = value; }
        public string ColumnType { get => columnType; set => columnType = value; }
        public string AutoSizeMode { get => autoSizeMode; set => autoSizeMode = value; }
        public string DataPropertyName { get => dataPropertyName; set => dataPropertyName = value; }
        public string HeaderText { get => headerText; set => headerText = value; }
        public bool ReadOnly { get => readOnly; set => readOnly = value; }
        public bool Visible { get => visible; set => visible = value; }
    }
}