using BL.Helper;
using System.Drawing;
using System.Linq;

namespace BL.Configs
{
    public class TemplateDatagridview
    {
        public TemplateDatagridview()
        {
            NameTemplate = string.Empty;
            Language = string.Empty;
            Selected = false;
            AllowUserToAddRows = true;
            AllowUserToDeleteRows = true;
            AllowUserToOrderColumns = true;
            AllowUserToResizeColumns = true;
            AllowUserToResizeRows = false;
            AlternatingRowsDefaultCellStyle = new CellStyle();
            AutoGenerateColumns = false;
            AutoSize = false;
            AutoSizeColumnsMode = "";
            AutoSizeRowsMode = "AllCells";
            BackgroundColor = SystemColors.Control;
            BorderStyle = "";
            CellBorderStyle = "";
            ClipboardCopyMode = "";
            ColumnHeadersBorderStyle = "";
            ColumnHeadersDefaultCellStyle = new CellStyle();
            ColumnHeadersHeight = 29;
            ColumnHeadersHeightSizeMode = "";
            ColumnHeadersVisible = true;
            //Columns = new List<Columns>();
            DataMember = "";
            DefaultCellStyle = new CellStyle();
            GridColor = SystemColors.Control;
            MultiSelect = false;
            RowHeadersBorderStyle = "";
            RowHeadersDefaultCellStyle = new CellStyle();
            RowHeadersVisible = false;
            RowHeadersWidth = 50;
            RowHeadersWidthSizeMode = "";
            RowsDefaultCellStyle = new CellStyle();
            SelectionMode = "";
            Name = "";
            SizeWidth = 240;
            SizeHeight = 150;
            Visible = true;
        }

        public TemplateDatagridview(string nameTemplate, bool selected) : this()
        {
            NameTemplate = nameTemplate;
            Selected = selected;
        }

        public string NameTemplate { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public bool Selected { get; set; } = false;
        public bool AllowUserToAddRows { get; set; } = true;
        public bool AllowUserToDeleteRows { get; set; } = true;
        public bool AllowUserToOrderColumns { get; set; } = true;
        public bool AllowUserToResizeColumns { get; set; } = true;
        public bool AllowUserToResizeRows { get; set; } = false;
        public CellStyle AlternatingRowsDefaultCellStyle { get; set; } /*= new CellStyle();*/
        public bool AutoGenerateColumns { get; set; } = false;
        public bool AutoSize { get; set; } = false;
        public string AutoSizeColumnsMode { get; set; }/* = "ColumnHeader";*//*DataGridViewAutoSizeColumnsMode.ColumnHeader;*/
        public string AutoSizeRowsMode { get; set; } /*= "AllCells";*//* DataGridViewAutoSizeRowsMode.AllCells;*/
        public Color BackgroundColor { get; set; } /*= SystemColors.Control;*/
        public string BorderStyle { get; set; } /*= "";*//*BorderStyle.FixedSingle;*/
        public string CellBorderStyle { get; set; } = "";/*DataGridViewCellBorderStyle.None;*/
        public string ClipboardCopyMode { get; set; } = ""; /*DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;*/
        public string ColumnHeadersBorderStyle { get; set; } = ""; /*DataGridViewHeaderBorderStyle.Raised;*/
        public CellStyle ColumnHeadersDefaultCellStyle { get; set; } = new CellStyle();
        public int ColumnHeadersHeight { get; set; } = 29;
        public string ColumnHeadersHeightSizeMode { get; set; } = ""; /*DataGridViewColumnHeadersHeightSizeMode.EnableResizing;*/
        public bool ColumnHeadersVisible { get; set; } = true;

        //public List<Columns> Columns { get; set; } = new List<Columns>();
        public string DataMember { get; set; } = "";

        public CellStyle DefaultCellStyle { get; set; } = new CellStyle();
        public Color GridColor { get; set; } = SystemColors.Control;
        public bool MultiSelect { get; set; } = false;
        public string RowHeadersBorderStyle { get; set; } = ""; /*DataGridViewHeaderBorderStyle.Raised;*/
        public CellStyle RowHeadersDefaultCellStyle { get; set; } = new CellStyle();
        public bool RowHeadersVisible { get; set; } = false;
        public int RowHeadersWidth { get; set; } = 50;
        public string RowHeadersWidthSizeMode { get; set; } = ""; /*DataGridViewRowHeadersWidthSizeMode.EnableResizing;*/
        public CellStyle RowsDefaultCellStyle { get; set; } = new CellStyle();
        public string SelectionMode { get; set; } = ""; /*DataGridViewSelectionMode.CellSelect;*/
        public string Name { get; set; }
        public int SizeWidth { get; set; } = 240;
        public int SizeHeight { get; set; } = 150;
        public bool Visible { get; set; } = true;
    }
}