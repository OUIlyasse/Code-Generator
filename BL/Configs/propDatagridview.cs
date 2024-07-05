using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL.Configs
{
    [Serializable]
    public class propDatagridview
    {
        //[DisplayName("SelectionMode"), Category("Datagridview information"), ReadOnly(false)]

        private bool allowUserToAddRows = true;
        private bool allowUserToDeleteRows = true;
        private bool allowUserToOrderColumns = true;
        private bool allowUserToResizeColumns = true;
        private bool allowUserToResizeRows = false;
        private DataGridViewCellStyle alternatingRowsDefaultCellStyle = new DataGridViewCellStyle();
        private bool autoGenerateColumns = false;
        private bool autoSize = false;
        private DataGridViewAutoSizeColumnsMode autoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
        private DataGridViewAutoSizeRowsMode autoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        private Color backColor;
        private Color backgroundColor = SystemColors.Control;
        private Image backgroundImage = null;
        private ImageLayout backgroundImageLayout;
        private BorderStyle borderStyle = BorderStyle.FixedSingle;
        private DataGridViewCellBorderStyle cellBorderStyle = DataGridViewCellBorderStyle.None;
        private DataGridViewClipboardCopyMode clipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
        private DataGridViewHeaderBorderStyle columnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        private DataGridViewCellStyle columnHeadersDefaultCellStyle = new DataGridViewCellStyle();
        private int columnHeadersHeight = 29;
        private DataGridViewColumnHeadersHeightSizeMode columnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        private bool columnHeadersVisible = true;

        //private DataGridViewColumnCollection columns;
        //private string dataMember = "";

        //private object dataSource = null;
        private DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle();

        private DataGridViewCell firstDisplayedCell;
        private Color foreColor;
        private Font font = new Font("Calibri", 10, FontStyle.Regular);
        private Color gridColor = SystemColors.Control;
        private bool multiSelect = false;
        private DataGridViewHeaderBorderStyle rowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        private DataGridViewCellStyle rowHeadersDefaultCellStyle = new DataGridViewCellStyle();
        private bool rowHeadersVisible = false;
        private int rowHeadersWidth = 50;
        private DataGridViewRowHeadersWidthSizeMode rowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
        private DataGridViewCellStyle rowsDefaultCellStyle = new DataGridViewCellStyle();
        private DataGridViewRow rowTemplate = new DataGridViewRow();
        private DataGridViewSelectionMode selectionMode = DataGridViewSelectionMode.CellSelect;
        private DockStyle dock;
        private int height;
        private int left;
        private string name;
        private Size size = new Size(300, 300);
        private bool visible = true;
        private int width;

        public propDatagridview()
        {
            allowUserToAddRows = true;
            allowUserToDeleteRows = true;
            allowUserToOrderColumns = true;
            allowUserToResizeColumns = true;
            allowUserToResizeRows = false;
            alternatingRowsDefaultCellStyle = new DataGridViewCellStyle();
            autoGenerateColumns = false;
            autoSize = false;
            autoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            autoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            backColor = Color.White;
            backgroundColor = SystemColors.Control;
            backgroundImage = null;
            font = new Font("Calibri", 10, FontStyle.Regular);
            borderStyle = BorderStyle.FixedSingle;
            cellBorderStyle = DataGridViewCellBorderStyle.None;
            clipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            columnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            columnHeadersDefaultCellStyle = new DataGridViewCellStyle();
            columnHeadersHeight = 29;
            columnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            columnHeadersVisible = true;
            //Columns = new DataGridViewColumnCollection();
            //dataMember = "";
            //dataSource = null;
            defaultCellStyle = new DataGridViewCellStyle();
            //FirstDisplayedCell
            foreColor = Color.Black;
            gridColor = SystemColors.Control;
            multiSelect = false;
            rowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            rowHeadersDefaultCellStyle = new DataGridViewCellStyle();
            rowHeadersVisible = false;
            rowHeadersWidth = 50;
            rowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            rowsDefaultCellStyle = new DataGridViewCellStyle();
            rowTemplate = new DataGridViewRow();
            selectionMode = DataGridViewSelectionMode.CellSelect;
            //Dock
            //      Height
            //Left
            name = "";
            size = new Size(300, 300);
            visible = true;
            //Width
        }

        public propDatagridview(string table)
        {
            name = $"dgv{char.ToUpper(table[0])}{table.Substring(1)}";
        }

        [DisplayName("AllowUserToAddRows"), Category("Datagridview information"), ReadOnly(false)]
        public bool AllowUserToAddRows
        {
            get { return allowUserToAddRows; }
            set { allowUserToAddRows = value; }
        }

        [DisplayName("AllowUserToDeleteRows"), Category("Datagridview information"), ReadOnly(false)]
        public bool AllowUserToDeleteRows

        {
            get { return allowUserToDeleteRows; }
            set { allowUserToDeleteRows = value; }
        }

        [DisplayName("AllowUserToOrderColumns"), Category("Datagridview information"), ReadOnly(false)]
        public bool AllowUserToOrderColumns

        {
            get { return allowUserToOrderColumns; }
            set { allowUserToOrderColumns = value; }
        }

        [DisplayName("AllowUserToResizeColumns"), Category("Datagridview information"), ReadOnly(false)]
        public bool AllowUserToResizeColumns

        {
            get { return allowUserToResizeColumns; }
            set { allowUserToResizeColumns = value; }
        }

        [DisplayName("AllowUserToResizeRows"), Category("Datagridview information"), ReadOnly(false)]
        public bool AllowUserToResizeRows

        {
            get { return allowUserToResizeRows; }
            set { allowUserToResizeRows = value; }
        }

        [DisplayName("AlternatingRowsDefaultCellStyle"), Category("Datagridview information"), ReadOnly(false)]
        public DataGridViewCellStyle AlternatingRowsDefaultCellStyle
        {
            get { return alternatingRowsDefaultCellStyle; }
            set { alternatingRowsDefaultCellStyle = value; }
        }

        [DisplayName("AutoGenerateColumns"), Category("Datagridview information"), ReadOnly(false)]
        public bool AutoGenerateColumns

        {
            get { return autoGenerateColumns; }
            set { autoGenerateColumns = value; }
        }

        [DisplayName("AutoSize"), Category("Datagridview information"), ReadOnly(false)]
        public bool AutoSize

        {
            get { return autoSize; }
            set { autoSize = value; }
        }

        [DisplayName("AutoSizeColumnsMode"), Category("Datagridview information"), ReadOnly(false)]
        public DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode
        {
            get { return autoSizeColumnsMode; }
            set { autoSizeColumnsMode = value; }
        }

        [DisplayName("AutoSizeRowsMode"), Category("Datagridview information"), ReadOnly(false)]
        public DataGridViewAutoSizeRowsMode AutoSizeRowsMode
        { get { return autoSizeRowsMode; } set { autoSizeRowsMode = value; } }

        [DisplayName("BackColor"), Category("Datagridview information"), ReadOnly(false)]
        public Color BackColor
        {
            get { return backColor; }
            set { backColor = value; }
        }

        [DisplayName("BackgroundColor"), Category("Datagridview information"), ReadOnly(false)]
        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; }
        }

        [DisplayName("BackgroundImage"), Category("Datagridview information"), ReadOnly(false)]
        public Image BackgroundImage
        {
            get { return backgroundImage; }
            set { backgroundImage = value; }
        }

        [DisplayName("BackgroundImageLayout"), Category("Datagridview information"), ReadOnly(false)]
        public ImageLayout BackgroundImageLayout
        {
            get { return backgroundImageLayout; }
            set { backgroundImageLayout = value; }
        }

        [DisplayName("BorderStyle"), Category("Datagridview information"), ReadOnly(false)]
        public BorderStyle BorderStyle
        {
            get { return borderStyle; }
            set { borderStyle = value; }
        }

        [DisplayName("CellBorderStyle"), Category("Datagridview information"), ReadOnly(false)]
        public DataGridViewCellBorderStyle CellBorderStyle
        {
            get { return cellBorderStyle; }
            set { cellBorderStyle = value; }
        }

        [DisplayName("ClipboardCopyMode"), Category("Datagridview information"), ReadOnly(false)]
        public DataGridViewClipboardCopyMode ClipboardCopyMode
        {
            get { return clipboardCopyMode; }
            set { clipboardCopyMode = value; }
        }

        [DisplayName("ColumnHeadersBorderStyle"), Category("Datagridview information"), ReadOnly(false)]
        public DataGridViewHeaderBorderStyle ColumnHeadersBorderStyle
        {
            get { return columnHeadersBorderStyle; }
            set { columnHeadersBorderStyle = value; }
        }

        [DisplayName("ColumnHeadersDefaultCellStyle"), Category("Datagridview information"), ReadOnly(false)]
        public DataGridViewCellStyle ColumnHeadersDefaultCellStyle
        {
            get { return columnHeadersDefaultCellStyle; }
            set { columnHeadersDefaultCellStyle = value; }
        }

        [DisplayName("ColumnHeadersHeight"), Category("Datagridview information"), ReadOnly(false)]
        public int ColumnHeadersHeight
        {
            get { return columnHeadersHeight; }
            set { columnHeadersHeight = value; }
        }

        [DisplayName("ColumnHeadersHeightSizeMode"), Category("Datagridview information"), ReadOnly(false)]
        public DataGridViewColumnHeadersHeightSizeMode ColumnHeadersHeightSizeMode
        {
            get { return columnHeadersHeightSizeMode; }
            set { columnHeadersHeightSizeMode = value; }
        }

        [DisplayName("ColumnHeadersVisible"), Category("Datagridview information"), ReadOnly(false)]
        public bool ColumnHeadersVisible
        {
            get { return columnHeadersVisible; }
            set { columnHeadersVisible = value; }
        }

        //[DisplayName("Columns"), Category("Datagridview information"), ReadOnly(true), Browsable(false)]
        //public DataGridViewColumnCollection Columns
        //{
        //    get { return columns; }
        //    set { columns = value; }
        //}

        //[DisplayName("DataMember"), Category("Datagridview information"), ReadOnly(false)]
        //public string DataMember
        //{
        //    get { return dataMember; }
        //    set { dataMember = value; }
        //}

        //[DisplayName("DataSource"), Category("Datagridview information"), ReadOnly(true), Browsable(false)]
        //public object DataSource
        //{
        //    get { return dataSource; }
        //    set { dataSource = value; }
        //}

        [DisplayName("DefaultCellStyle"), Category("Datagridview information"), ReadOnly(false)]
        public DataGridViewCellStyle DefaultCellStyle
        {
            get { return defaultCellStyle; }
            set { defaultCellStyle = value; }
        }

        [DisplayName("FirstDisplayedCell"), Category("Datagridview information"), ReadOnly(false)]
        public DataGridViewCell FirstDisplayedCell
        {
            get { return firstDisplayedCell; }
            set { firstDisplayedCell = value; }
        }

        [DisplayName("ForeColor"), Category("Datagridview information"), ReadOnly(false)]
        public Color ForeColor
        {
            get { return foreColor; }
            set { foreColor = value; }
        }

        [DisplayName("Font"), Category("Datagridview information"), ReadOnly(false)]
        public Font Font
        {
            get { return font; }
            set { font = value; }
        }

        [DisplayName("GridColor"), Category("Datagridview information"), ReadOnly(false)]
        public Color GridColor
        {
            get { return gridColor; }
            set { gridColor = value; }
        }

        [DisplayName("MultiSelect"), Category("Datagridview information"), ReadOnly(false)]
        public bool MultiSelect

        {
            get { return multiSelect; }
            set { multiSelect = value; }
        }

        [DisplayName("RowHeadersBorderStyle"), Category("Datagridview information"), ReadOnly(false)]
        public DataGridViewHeaderBorderStyle RowHeadersBorderStyle
        {
            get { return rowHeadersBorderStyle; }
            set { rowHeadersBorderStyle = value; }
        }

        [DisplayName("RowHeadersDefaultCellStyle"), Category("Datagridview information"), ReadOnly(false)]
        public DataGridViewCellStyle RowHeadersDefaultCellStyle
        {
            get { return rowHeadersDefaultCellStyle; }
            set { rowHeadersDefaultCellStyle = value; }
        }

        [DisplayName("RowHeadersVisible"), Category("Datagridview information"), ReadOnly(false)]
        public bool RowHeadersVisible

        {
            get { return rowHeadersVisible; }
            set { rowHeadersVisible = value; }
        }

        [DisplayName("RowHeadersWidth"), Category("Datagridview information"), ReadOnly(false)]
        public int RowHeadersWidth

        {
            get { return rowHeadersWidth; }
            set { rowHeadersWidth = value; }
        }

        [DisplayName("RowHeadersWidthSizeMode"), Category("Datagridview information"), ReadOnly(false)]
        public DataGridViewRowHeadersWidthSizeMode RowHeadersWidthSizeMode
        {
            get { return rowHeadersWidthSizeMode; }
            set { rowHeadersWidthSizeMode = value; }
        }

        [DisplayName("RowsDefaultCellStyle"), Category("Datagridview information"), ReadOnly(false)]
        public DataGridViewCellStyle RowsDefaultCellStyle
        {
            get { return rowsDefaultCellStyle; }
            set { rowsDefaultCellStyle = value; }
        }

        [DisplayName("RowTemplate"), Category("Datagridview information"), ReadOnly(false)]
        public DataGridViewRow RowTemplate
        {
            get { return rowTemplate; }
            set { rowTemplate = value; }
        }

        [DisplayName("SelectionMode"), Category("Datagridview information"), ReadOnly(false)]
        public DataGridViewSelectionMode SelectionMode
        {
            get { return selectionMode; }
            set { selectionMode = value; }
        }

        [DisplayName("Dock"), Category("Datagridview information"), ReadOnly(false)]
        public DockStyle Dock
        {
            get { return dock; }
            set { dock = value; }
        }

        [DisplayName("Height"), Category("Datagridview information"), ReadOnly(false)]
        public int Height

        {
            get { return height; }
            set { height = value; }
        }

        [DisplayName("Left"), Category("Datagridview information"), ReadOnly(false)]
        public int Left

        {
            get { return left; }
            set { left = value; }
        }

        [DisplayName("Name"), Category("Datagridview information"), ReadOnly(false)]
        public string Name

        {
            get { return name; }
            set { name = value; }
        }

        [DisplayName("Size"), Category("Datagridview information"), ReadOnly(false)]
        public Size Size
        {
            get { return size; }
            set { size = value; }
        }

        [DisplayName("Visible"), Category("Datagridview information"), ReadOnly(false)]
        public bool Visible

        {
            get { return visible; }
            set { visible = value; }
        }

        [DisplayName("Width"), Category("Datagridview information"), ReadOnly(false), Browsable(false)]
        public int Width

        {
            get { return width; }
            set { width = value; }
        }
    }
}