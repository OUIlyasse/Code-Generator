using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Configs
{
    public class Columns
    {
        public CellStyle DefaultCellStyle { get; set; }
        public string HeaderText { get; set; }
        public string ToolTipText { get; set; }
        public bool Visible { get; set; }
        public bool ReadOnly { get; set; }
        public string Resizable { get; set; }
        public string DataPropertyName { get; set; }
        public string Name { get; set; }
        public string ColumnType { get; set; }
        public string AutoSizeMode { get; set; }
        public float FillWeight { get; set; }
        public bool Frozen { get; set; }
        public int MinimumWidht { get; set; }
        public int Width { get; set; }
    }
}