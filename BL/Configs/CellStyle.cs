using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Configs
{
    public class CellStyle
    {
        public CellStyle()
        {
            Alignment = "";
            //BackColor = 0;
            FontName = "";
            FontSize = 0;
            FontStyle = "";
            GraphicsUnit = "";
            //ForeColor = 0;
            //SelectionBackColor = 0;
            //SelectionForeColor = 0;
        }

        public CellStyle(Font font)
        {
            Alignment = "";
            //BackColor = 0;
            FontName = font.Name;
            FontSize = font.Size;
            FontStyle = font.Style.ToString();
            GraphicsUnit = font.Unit.ToString();
            //ForeColor = 0;
            //SelectionBackColor = 0;
            //SelectionForeColor = 0;
        }

        public string Alignment { get; set; } = "";
        public Color BackColor { get; set; }
        public string FontName { get; set; } = "";
        public float FontSize { get; set; } = 0;
        public string FontStyle { get; set; } = "";
        public string GraphicsUnit { get; set; } = "";
        public Color ForeColor { get; set; }
        public Color SelectionBackColor { get; set; }
        public Color SelectionForeColor { get; set; }
    }
}