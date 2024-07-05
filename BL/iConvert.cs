using BL.Configs;
using BL.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL
{
    public static class iConvert
    {
        public static TemplateDatagridview GetTemplate(string nameTemplate)
        {
            var rs = HTemplates.LoadConfiguration();
            return rs.Templates.FirstOrDefault(x => x.Properties.NameTemplate == nameTemplate).Properties;
        }

        public static DataGridView ToDataGridView(this propDatagridview prop)
        {
            DataGridView rs = new DataGridView();

            rs.AllowUserToDeleteRows = prop.AllowUserToDeleteRows;
            rs.AllowUserToOrderColumns = prop.AllowUserToOrderColumns;
            rs.AllowUserToResizeColumns = prop.AllowUserToResizeColumns;
            rs.AllowUserToResizeRows = prop.AllowUserToResizeRows;
            rs.AlternatingRowsDefaultCellStyle = prop.AlternatingRowsDefaultCellStyle;
            rs.AutoGenerateColumns = prop.AutoGenerateColumns;
            rs.AutoSize = prop.AutoSize;
            rs.AutoSizeColumnsMode = prop.AutoSizeColumnsMode;
            rs.AutoSizeRowsMode = prop.AutoSizeRowsMode;
            rs.BackColor = prop.BackColor;
            rs.BackgroundColor = prop.BackgroundColor;
            rs.BackgroundImage = prop.BackgroundImage;
            rs.BorderStyle = prop.BorderStyle;
            rs.CellBorderStyle = prop.CellBorderStyle;
            rs.ClipboardCopyMode = prop.ClipboardCopyMode;
            rs.ColumnHeadersBorderStyle = prop.ColumnHeadersBorderStyle;
            rs.ColumnHeadersDefaultCellStyle = prop.ColumnHeadersDefaultCellStyle;
            rs.ColumnHeadersHeight = prop.ColumnHeadersHeight;
            rs.ColumnHeadersHeightSizeMode = prop.ColumnHeadersHeightSizeMode;
            rs.ColumnHeadersVisible = prop.ColumnHeadersVisible;
            //rs.DataMember = prop.DataMember;
            //rs.DataSource = prop.DataSource;
            rs.DefaultCellStyle = prop.DefaultCellStyle;
            rs.ForeColor = prop.ForeColor;
            rs.GridColor = prop.GridColor;
            rs.MultiSelect = prop.MultiSelect;
            rs.RowHeadersBorderStyle = prop.RowHeadersBorderStyle;
            rs.RowHeadersDefaultCellStyle = prop.RowHeadersDefaultCellStyle;
            rs.RowHeadersVisible = prop.RowHeadersVisible;
            rs.RowHeadersWidth = prop.RowHeadersWidth;
            rs.RowHeadersWidthSizeMode = prop.RowHeadersWidthSizeMode;
            rs.RowsDefaultCellStyle = prop.RowsDefaultCellStyle;
            rs.RowTemplate = prop.RowTemplate;
            rs.SelectionMode = prop.SelectionMode;
            rs.Name = prop.Name;
            rs.Size = prop.Size;
            rs.Visible = prop.Visible;

            return rs;
        }

        public static void CopyTo(this DataGridView source, DataGridView destinataire)
        {
            destinataire.AllowUserToDeleteRows = source.AllowUserToDeleteRows;
            destinataire.AllowUserToAddRows = source.AllowUserToAddRows;
            destinataire.AllowUserToOrderColumns = source.AllowUserToOrderColumns;
            destinataire.AllowUserToResizeColumns = source.AllowUserToResizeColumns;
            destinataire.AllowUserToResizeRows = source.AllowUserToResizeRows;
            destinataire.AlternatingRowsDefaultCellStyle = source.AlternatingRowsDefaultCellStyle;
            destinataire.AutoGenerateColumns = source.AutoGenerateColumns;
            destinataire.AutoSize = source.AutoSize;
            destinataire.AutoSizeColumnsMode = source.AutoSizeColumnsMode;
            destinataire.AutoSizeRowsMode = source.AutoSizeRowsMode;
            destinataire.BackColor = source.BackColor;
            destinataire.BackgroundColor = source.BackgroundColor;
            destinataire.BackgroundImage = source.BackgroundImage;
            destinataire.BorderStyle = source.BorderStyle;
            destinataire.CellBorderStyle = source.CellBorderStyle;
            destinataire.ClipboardCopyMode = source.ClipboardCopyMode;
            destinataire.ColumnHeadersBorderStyle = source.ColumnHeadersBorderStyle;
            destinataire.ColumnHeadersDefaultCellStyle = source.ColumnHeadersDefaultCellStyle;
            destinataire.ColumnHeadersHeight = source.ColumnHeadersHeight;
            destinataire.ColumnHeadersHeightSizeMode = source.ColumnHeadersHeightSizeMode;
            destinataire.ColumnHeadersVisible = source.ColumnHeadersVisible;
            destinataire.DataMember = source.DataMember;
            destinataire.DataSource = source.DataSource;
            destinataire.DefaultCellStyle = source.DefaultCellStyle;
            destinataire.ForeColor = source.ForeColor;
            destinataire.GridColor = source.GridColor;
            destinataire.MultiSelect = source.MultiSelect;
            destinataire.RowHeadersBorderStyle = source.RowHeadersBorderStyle;
            destinataire.RowHeadersDefaultCellStyle = source.RowHeadersDefaultCellStyle;
            destinataire.RowHeadersVisible = source.RowHeadersVisible;
            destinataire.RowHeadersWidth = source.RowHeadersWidth;
            destinataire.RowHeadersWidthSizeMode = source.RowHeadersWidthSizeMode;
            destinataire.RowsDefaultCellStyle = source.RowsDefaultCellStyle;
            destinataire.RowTemplate = source.RowTemplate;
            destinataire.SelectionMode = source.SelectionMode;
            destinataire.Name = source.Name;
            destinataire.Size = source.Size;
            destinataire.Visible = source.Visible;
        }

        public static DataGridViewAutoSizeColumnMode ToAutoSizeMode(this string modeString)
        {
            if (Enum.TryParse(modeString, out DataGridViewAutoSizeColumnMode mode))
            {
                return mode;
            }
            else
            {
                return DataGridViewAutoSizeColumnMode.NotSet;
            }
        }

        public static DataGridViewColumn ToDataGridViewColumn(string columnName)
        {
            // Get the DataGridViewColumn type using reflection
            Type columnType = typeof(DataGridViewColumn).Assembly.GetType("System.Windows.Forms." + columnName);

            if (columnType != null && columnType.IsSubclassOf(typeof(DataGridViewColumn)))
            {
                // Create an instance of the specified DataGridViewColumn type
                return (DataGridViewColumn)Activator.CreateInstance(columnType);
            }
            else
            {
                return null;
            }
        }

        public static DataGridViewColumn ToDataGridViewColumn(this cColumns columns)
        {
            DataGridViewColumn ty = ToDataGridViewColumn(columns.ColumnType);
            ty.HeaderText = columns.HeaderText;
            ty.Name = columns.ColumnName;
            ty.AutoSizeMode = columns.AutoSizeMode.ToAutoSizeMode();
            ty.DataPropertyName = columns.DataPropertyName;
            ty.ReadOnly = columns.ReadOnly;
            ty.Visible = columns.Visible;

            return ty;
        }

        //public static CellStyle ToCellStyle(this DataGridViewCellStyle cell)
        //{
        //    if (cell != null)
        //    {
        //        return new CellStyle
        //        {
        //            Alignment = cell.Alignment.ToString(),
        //            BackColor = cell.BackColor.ToArgb(),
        //            FontName = cell.Font.Name,
        //            FontSize = cell.Font.Size,
        //            FontStyle = cell.Font.Style.ToString(),
        //            ForeColor = cell.ForeColor.ToArgb(),
        //            GraphicsUnit = cell.Font.Unit.ToString(),
        //            SelectionBackColor = cell.SelectionBackColor.ToArgb(),
        //            SelectionForeColor = cell.SelectionForeColor.ToArgb()
        //        };
        //    }
        //    else
        //        return new CellStyle();
        //}

        public static CellStyle ToCellStyle(this DataGridViewCellStyle cell, Font font)
        {
            CellStyle s = new CellStyle();
            if (cell != null)
            {
                s.Alignment = cell.Alignment.ToString();
                s.BackColor = cell.BackColor;
                s.ForeColor = cell.ForeColor;
                s.SelectionBackColor = cell.SelectionBackColor;
                s.SelectionForeColor = cell.SelectionForeColor;
                if (cell.Font != null)
                {
                    s.FontName = cell.Font.Name;
                    s.FontSize = cell.Font.Size;
                    s.FontStyle = cell.Font.Style.ToString();
                    s.GraphicsUnit = cell.Font.Unit.ToString();
                }
                else
                {
                    s.FontName = font.Name;
                    s.FontSize = font.Size;
                    s.FontStyle = font.Style.ToString();
                    s.GraphicsUnit = font.Unit.ToString();
                }
            }
            return s;
        }

        public static List<Columns> ToList(this DataGridViewColumnCollection cols)
        {
            List<Columns> rs = new List<Columns>();
            foreach (DataGridViewColumn col in cols)
            {
                //Columns c = new Columns
                //{
                //    Name = col.Name,
                //    HeaderText = col.HeaderText,
                //    MinimumWidht = col.MinimumWidth,
                //    AutoSizeMode = col.AutoSizeMode.ToString(),
                //    ColumnType = col.ValueType.ToString(),
                //    DataPropertyName = col.DataPropertyName,
                //    DefaultCellStyle = col.DefaultCellStyle.ToCellStyle(),
                //    FillWeight = col.FillWeight,
                //    Frozen = col.Frozen,
                //    ReadOnly = col.ReadOnly,
                //    Resizable = col.Resizable.ToString(),
                //    ToolTipText = col.ToolTipText,
                //    Visible = col.Visible,
                //    Width = col.Width
                //};
                //rs.Add(c);
            }
            return rs;
        }

        public static void ToTemplateDatagridview(this propDatagridview source, TemplateDatagridview dec)
        {
            dec.AllowUserToAddRows = source.AllowUserToAddRows;
            dec.AllowUserToDeleteRows = source.AllowUserToDeleteRows;
            dec.AllowUserToOrderColumns = source.AllowUserToOrderColumns;
            dec.AllowUserToResizeColumns = source.AllowUserToResizeColumns;
            dec.AllowUserToResizeRows = source.AllowUserToResizeRows;
            dec.AlternatingRowsDefaultCellStyle = source.AlternatingRowsDefaultCellStyle.ToCellStyle(source.Font);
            dec.AutoGenerateColumns = source.AutoGenerateColumns;
            dec.AutoSize = source.AutoSize;
            dec.AutoSizeColumnsMode = source.AutoSizeColumnsMode.ToString();
            dec.AutoSizeRowsMode = source.AutoSizeRowsMode.ToString();
            dec.BackgroundColor = source.BackgroundColor;
            dec.BorderStyle = source.BorderStyle.ToString();
            dec.CellBorderStyle = source.CellBorderStyle.ToString();
            dec.ClipboardCopyMode = source.ClipboardCopyMode.ToString();
            dec.ColumnHeadersBorderStyle = source.ColumnHeadersBorderStyle.ToString();
            dec.ColumnHeadersDefaultCellStyle = source.ColumnHeadersDefaultCellStyle.ToCellStyle(source.Font);
            dec.ColumnHeadersHeight = source.ColumnHeadersHeight;
            dec.ColumnHeadersHeightSizeMode = source.ColumnHeadersHeightSizeMode.ToString();
            dec.ColumnHeadersVisible = source.ColumnHeadersVisible;
            //dec.Columns = source.Columns.ToList();
            //dec.DataMember = source.DataMember;
            dec.DefaultCellStyle = source.DefaultCellStyle.ToCellStyle(source.Font);
            dec.GridColor = source.GridColor;
            dec.MultiSelect = source.MultiSelect;
            dec.RowHeadersBorderStyle = source.RowHeadersBorderStyle.ToString();
            dec.RowHeadersDefaultCellStyle = source.RowHeadersDefaultCellStyle.ToCellStyle(source.Font);
            dec.RowHeadersVisible = source.RowHeadersVisible;
            dec.RowHeadersWidth = source.RowHeadersWidth;
            dec.RowHeadersWidthSizeMode = source.RowHeadersWidthSizeMode.ToString();
            dec.RowsDefaultCellStyle = source.RowsDefaultCellStyle.ToCellStyle(source.Font);
            dec.SelectionMode = source.SelectionMode.ToString();
            dec.Name = source.Name;
            dec.SizeWidth = source.Width;
            dec.SizeHeight = source.Height;
            dec.Visible = source.Visible;
        }

        public static DataGridViewContentAlignment ToAlignement(this string alignement)
        {
            DataGridViewContentAlignment rs;
            switch (alignement)
            {
                case "NotSet":
                    rs = DataGridViewContentAlignment.NotSet;
                    break;

                case "TopLeft":
                    rs = DataGridViewContentAlignment.TopLeft;
                    break;

                case "TopCenter":
                    rs = DataGridViewContentAlignment.TopCenter;
                    break;

                case "TopRight":
                    rs = DataGridViewContentAlignment.TopRight;
                    break;

                case "MiddleLeft":
                    rs = DataGridViewContentAlignment.MiddleLeft;
                    break;

                case "MiddleCenter":
                    rs = DataGridViewContentAlignment.MiddleCenter;
                    break;

                case "MiddleRight":
                    rs = DataGridViewContentAlignment.MiddleRight;
                    break;

                case "BottomLeft":
                    rs = DataGridViewContentAlignment.BottomLeft;
                    break;

                case "BottomCenter":
                    rs = DataGridViewContentAlignment.BottomCenter;
                    break;

                case "BottomRight":
                    rs = DataGridViewContentAlignment.BottomRight;
                    break;

                default:
                    rs = DataGridViewContentAlignment.NotSet;
                    break;
            }
            return rs;
        }

        public static FontFamily ToFontName(this string fontName)
        {
            return new FontFamily(fontName);
        }

        public static FontStyle ToFontStyle(this string style)
        {
            FontStyle rs;

            switch (style)
            {
                case "Regular":
                    rs = FontStyle.Regular;
                    break;

                case "Bold":
                    rs = FontStyle.Bold;
                    break;

                case "Italic":
                    rs = FontStyle.Italic;
                    break;

                case "Underline":
                    rs = FontStyle.Underline;
                    break;

                case "Strikeout":
                    rs = FontStyle.Strikeout;
                    break;

                default:
                    rs = FontStyle.Regular;
                    break;
            }
            return rs;
        }

        public static GraphicsUnit ToUnit(this string unit)
        {
            GraphicsUnit rs;

            switch (unit)
            {
                case "World":
                    rs = GraphicsUnit.World;
                    break;

                case "Display":
                    rs = GraphicsUnit.Display;
                    break;

                case "Pixel":
                    rs = GraphicsUnit.Pixel;
                    break;

                case "Point":
                    rs = GraphicsUnit.Point;
                    break;

                case "Inch":
                    rs = GraphicsUnit.Inch;
                    break;

                case "Document":
                    rs = GraphicsUnit.Document;
                    break;

                case "Millimeter":
                    rs = GraphicsUnit.Millimeter;
                    break;

                default:
                    rs = GraphicsUnit.Point;
                    break;
            }
            return rs;
        }

        public static DataGridViewAutoSizeColumnMode ToAutoSizeColumn(this string mode)
        {
            DataGridViewAutoSizeColumnMode rs;

            switch (mode)
            {
                case "NotSet":
                    rs = DataGridViewAutoSizeColumnMode.NotSet;
                    break;

                case "None":
                    rs = DataGridViewAutoSizeColumnMode.None;
                    break;

                case "AllCells":
                    rs = DataGridViewAutoSizeColumnMode.AllCells;
                    break;

                case "AllCellsExceptHeader":
                    rs = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                    break;

                case "DisplayedCells":
                    rs = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    break;

                case "DisplayedCellsExceptHeader":
                    rs = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                    break;

                case "ColumnHeader":
                    rs = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    break;

                case "Fill":
                    rs = DataGridViewAutoSizeColumnMode.Fill;
                    break;

                default:
                    rs = DataGridViewAutoSizeColumnMode.NotSet;
                    break;
            }
            return rs;
        }

        public static DataGridViewAutoSizeRowMode ToAutoSizeRow(this string mode)
        {
            DataGridViewAutoSizeRowMode rs;

            //if (Enum.TryParse(mode, out DataGridViewAutoSizeRowMode modei))
            //{
            //    rs = modei;
            //}
            //else
            //{
            //    rs = DataGridViewAutoSizeRowMode.AllCells;
            //}
            switch (mode)
            {
                case "AllCells":
                    rs = DataGridViewAutoSizeRowMode.AllCells;
                    break;

                case "AllCellsExceptHeader":
                    rs = DataGridViewAutoSizeRowMode.AllCellsExceptHeader;
                    break;

                case "RowHeader":
                    rs = DataGridViewAutoSizeRowMode.RowHeader;
                    break;

                default:
                    rs = DataGridViewAutoSizeRowMode.AllCells;
                    break;
            }
            return rs;
        }

        public static BorderStyle ToBorderStyle(this string mode)
        {
            BorderStyle rs;

            switch (mode)
            {
                case "None":
                    rs = BorderStyle.None;
                    break;

                case "FixedSingle":
                    rs = BorderStyle.FixedSingle;
                    break;

                case "Fixed3D":
                    rs = BorderStyle.Fixed3D;
                    break;

                default:
                    rs = BorderStyle.FixedSingle;
                    break;
            }
            return rs;
        }

        public static DataGridViewCellBorderStyle ToCellBorderStyle(this string mode)
        {
            DataGridViewCellBorderStyle rs;

            switch (mode)
            {
                case "Custom":
                    rs = DataGridViewCellBorderStyle.Custom;
                    break;

                case "Single":
                    rs = DataGridViewCellBorderStyle.Single;
                    break;

                case "Raised":
                    rs = DataGridViewCellBorderStyle.Raised;
                    break;

                case "Sunken":
                    rs = DataGridViewCellBorderStyle.Sunken;
                    break;

                case "None":
                    rs = DataGridViewCellBorderStyle.None;
                    break;

                case "SingleVertical":
                    rs = DataGridViewCellBorderStyle.SingleVertical;
                    break;

                case "RaisedVertical":
                    rs = DataGridViewCellBorderStyle.RaisedVertical;
                    break;

                case "SunkenVertical":
                    rs = DataGridViewCellBorderStyle.SunkenVertical;
                    break;

                case "SingleHorizontal":
                    rs = DataGridViewCellBorderStyle.SingleHorizontal;
                    break;

                case "RaisedHorizontal":
                    rs = DataGridViewCellBorderStyle.RaisedHorizontal;
                    break;

                case "SunkenHorizontal":
                    rs = DataGridViewCellBorderStyle.SunkenHorizontal;
                    break;

                default:
                    rs = DataGridViewCellBorderStyle.Raised;
                    break;
            }
            return rs;
        }

        public static DataGridViewClipboardCopyMode ToCopyMode(this string mode)
        {
            DataGridViewClipboardCopyMode rs;

            if (Enum.TryParse(mode, out DataGridViewClipboardCopyMode modei))
            {
                rs = modei;
            }
            else
            {
                rs = DataGridViewClipboardCopyMode.Disable;
            }

            return rs;
        }

        public static DataGridViewHeaderBorderStyle ToBorderStyleHeader(this string mode)
        {
            DataGridViewHeaderBorderStyle rs;

            if (Enum.TryParse(mode, out DataGridViewHeaderBorderStyle modei))
            {
                rs = modei;
            }
            else
            {
                rs = DataGridViewHeaderBorderStyle.None;
            }

            return rs;
        }

        public static DataGridViewColumnHeadersHeightSizeMode ToHeightSizeMode(this string mode)
        {
            DataGridViewColumnHeadersHeightSizeMode rs;

            if (Enum.TryParse(mode, out DataGridViewColumnHeadersHeightSizeMode modei))
            {
                rs = modei;
            }
            else
            {
                rs = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            }

            return rs;
        }

        public static DataGridViewRowHeadersWidthSizeMode ToHeadersWidthSizeMode(this string mode)
        {
            DataGridViewRowHeadersWidthSizeMode rs;

            if (Enum.TryParse(mode, out DataGridViewRowHeadersWidthSizeMode modei))
            {
                rs = modei;
            }
            else
            {
                rs = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            }

            return rs;
        }

        public static DataGridViewSelectionMode ToSelectionMode(this string mode)
        {
            DataGridViewSelectionMode rs;

            if (Enum.TryParse(mode, out DataGridViewSelectionMode modei))
            {
                rs = modei;
            }
            else
            {
                rs = DataGridViewSelectionMode.FullRowSelect;
            }

            return rs;
        }

        public static void ToPropDatagridview(this TemplateDatagridview source, propDatagridview dec)
        {
            dec.AllowUserToAddRows = source.AllowUserToAddRows;
            dec.AllowUserToDeleteRows = source.AllowUserToDeleteRows;
            dec.AllowUserToOrderColumns = source.AllowUserToOrderColumns;
            dec.AllowUserToResizeColumns = source.AllowUserToResizeColumns;
            dec.AllowUserToResizeRows = source.AllowUserToResizeRows;
            dec.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = source.AlternatingRowsDefaultCellStyle.Alignment.ToAlignement(),
                BackColor = source.AlternatingRowsDefaultCellStyle.BackColor,
                Font = new Font(source.AlternatingRowsDefaultCellStyle.FontName.ToFontName(), source.AlternatingRowsDefaultCellStyle.FontSize,
                source.AlternatingRowsDefaultCellStyle.FontStyle.ToFontStyle(), source.AlternatingRowsDefaultCellStyle.GraphicsUnit.ToUnit()),
                ForeColor = source.AlternatingRowsDefaultCellStyle.ForeColor,
                SelectionBackColor = source.AlternatingRowsDefaultCellStyle.SelectionBackColor,
                SelectionForeColor = source.AlternatingRowsDefaultCellStyle.SelectionForeColor
            }; /*source.AlternatingRowsDefaultCellStyle;*/
            dec.AutoGenerateColumns = source.AutoGenerateColumns;
            dec.AutoSize = source.AutoSize;
            dec.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)source.AutoSizeColumnsMode.ToAutoSizeColumn();
            dec.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)source.AutoSizeRowsMode.ToAutoSizeRow();
            dec.BackgroundColor = source.BackgroundColor;
            dec.BorderStyle = source.BorderStyle.ToBorderStyle();
            dec.CellBorderStyle = source.CellBorderStyle.ToCellBorderStyle();
            dec.ClipboardCopyMode = source.ClipboardCopyMode.ToCopyMode();
            dec.ColumnHeadersBorderStyle = source.ColumnHeadersBorderStyle.ToBorderStyleHeader();

            dec.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = source.ColumnHeadersDefaultCellStyle.Alignment.ToAlignement(),
                BackColor = source.ColumnHeadersDefaultCellStyle.BackColor,
                Font = new Font(source.ColumnHeadersDefaultCellStyle.FontName.ToFontName(), source.ColumnHeadersDefaultCellStyle.FontSize,
                source.ColumnHeadersDefaultCellStyle.FontStyle.ToFontStyle(), source.ColumnHeadersDefaultCellStyle.GraphicsUnit.ToUnit()),
                ForeColor = source.ColumnHeadersDefaultCellStyle.ForeColor,
                SelectionBackColor = source.ColumnHeadersDefaultCellStyle.SelectionBackColor,
                SelectionForeColor = source.ColumnHeadersDefaultCellStyle.SelectionForeColor
            };

            dec.ColumnHeadersHeight = source.ColumnHeadersHeight;
            dec.ColumnHeadersHeightSizeMode = source.ColumnHeadersHeightSizeMode.ToHeightSizeMode();
            dec.ColumnHeadersVisible = source.ColumnHeadersVisible;

            dec.DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = source.DefaultCellStyle.Alignment.ToAlignement(),
                BackColor = source.DefaultCellStyle.BackColor,
                Font = new Font(source.DefaultCellStyle.FontName.ToFontName(), source.DefaultCellStyle.FontSize,
               source.DefaultCellStyle.FontStyle.ToFontStyle(), source.DefaultCellStyle.GraphicsUnit.ToUnit()),
                ForeColor = source.DefaultCellStyle.ForeColor,
                SelectionBackColor = source.DefaultCellStyle.SelectionBackColor,
                SelectionForeColor = source.DefaultCellStyle.SelectionForeColor
            };

            dec.GridColor = source.GridColor;
            dec.MultiSelect = source.MultiSelect;
            dec.RowHeadersBorderStyle = source.RowHeadersBorderStyle.ToBorderStyleHeader();

            dec.RowHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = source.RowHeadersDefaultCellStyle.Alignment.ToAlignement(),
                BackColor = source.RowHeadersDefaultCellStyle.BackColor,
                Font = new Font(source.RowHeadersDefaultCellStyle.FontName.ToFontName(), source.RowHeadersDefaultCellStyle.FontSize,
              source.RowHeadersDefaultCellStyle.FontStyle.ToFontStyle(), source.RowHeadersDefaultCellStyle.GraphicsUnit.ToUnit()),
                ForeColor = source.RowHeadersDefaultCellStyle.ForeColor,
                SelectionBackColor = source.RowHeadersDefaultCellStyle.SelectionBackColor,
                SelectionForeColor = source.RowHeadersDefaultCellStyle.SelectionForeColor
            };

            dec.RowHeadersVisible = source.RowHeadersVisible;
            dec.RowHeadersWidth = source.RowHeadersWidth;
            dec.RowHeadersWidthSizeMode = source.RowHeadersWidthSizeMode.ToHeadersWidthSizeMode();

            dec.RowsDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = source.RowsDefaultCellStyle.Alignment.ToAlignement(),
                BackColor = source.RowsDefaultCellStyle.BackColor,
                Font = new Font(source.RowsDefaultCellStyle.FontName.ToFontName(), source.RowsDefaultCellStyle.FontSize,
              source.RowsDefaultCellStyle.FontStyle.ToFontStyle(), source.RowsDefaultCellStyle.GraphicsUnit.ToUnit()),
                ForeColor = source.RowsDefaultCellStyle.ForeColor,
                SelectionBackColor = source.RowsDefaultCellStyle.SelectionBackColor,
                SelectionForeColor = source.RowsDefaultCellStyle.SelectionForeColor
            };

            dec.SelectionMode = source.SelectionMode.ToSelectionMode();
            dec.Name = source.Name;
            dec.Width = source.SizeWidth;
            dec.Height = source.SizeHeight;
            dec.Visible = source.Visible;
        }

        public static propDatagridview ToPropDatagridview(this TemplateDatagridview source)
        {
            propDatagridview dec = new propDatagridview();
            dec.AllowUserToAddRows = source.AllowUserToAddRows;
            dec.AllowUserToDeleteRows = source.AllowUserToDeleteRows;
            dec.AllowUserToOrderColumns = source.AllowUserToOrderColumns;
            dec.AllowUserToResizeColumns = source.AllowUserToResizeColumns;
            dec.AllowUserToResizeRows = source.AllowUserToResizeRows;
            dec.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = source.AlternatingRowsDefaultCellStyle.Alignment.ToAlignement(),
                BackColor = source.AlternatingRowsDefaultCellStyle.BackColor,
                Font = new Font(source.AlternatingRowsDefaultCellStyle.FontName.ToFontName(), source.AlternatingRowsDefaultCellStyle.FontSize,
                source.AlternatingRowsDefaultCellStyle.FontStyle.ToFontStyle(), source.AlternatingRowsDefaultCellStyle.GraphicsUnit.ToUnit()),
                ForeColor = source.AlternatingRowsDefaultCellStyle.ForeColor,
                SelectionBackColor = source.AlternatingRowsDefaultCellStyle.SelectionBackColor,
                SelectionForeColor = source.AlternatingRowsDefaultCellStyle.SelectionForeColor
            }; /*source.AlternatingRowsDefaultCellStyle;*/
            dec.AutoGenerateColumns = source.AutoGenerateColumns;
            dec.AutoSize = source.AutoSize;
            dec.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)source.AutoSizeColumnsMode.ToAutoSizeColumn();
            dec.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)source.AutoSizeRowsMode.ToAutoSizeRow();
            dec.BackgroundColor = source.BackgroundColor;
            dec.BorderStyle = source.BorderStyle.ToBorderStyle();
            dec.CellBorderStyle = source.CellBorderStyle.ToCellBorderStyle();
            dec.ClipboardCopyMode = source.ClipboardCopyMode.ToCopyMode();
            dec.ColumnHeadersBorderStyle = source.ColumnHeadersBorderStyle.ToBorderStyleHeader();

            dec.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = source.ColumnHeadersDefaultCellStyle.Alignment.ToAlignement(),
                BackColor = source.ColumnHeadersDefaultCellStyle.BackColor,
                Font = new Font(source.ColumnHeadersDefaultCellStyle.FontName.ToFontName(), source.ColumnHeadersDefaultCellStyle.FontSize,
                source.ColumnHeadersDefaultCellStyle.FontStyle.ToFontStyle(), source.ColumnHeadersDefaultCellStyle.GraphicsUnit.ToUnit()),
                ForeColor = source.ColumnHeadersDefaultCellStyle.ForeColor,
                SelectionBackColor = source.ColumnHeadersDefaultCellStyle.SelectionBackColor,
                SelectionForeColor = source.ColumnHeadersDefaultCellStyle.SelectionForeColor
            };

            dec.ColumnHeadersHeight = source.ColumnHeadersHeight;
            dec.ColumnHeadersHeightSizeMode = source.ColumnHeadersHeightSizeMode.ToHeightSizeMode();
            dec.ColumnHeadersVisible = source.ColumnHeadersVisible;

            dec.DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = source.DefaultCellStyle.Alignment.ToAlignement(),
                BackColor = source.DefaultCellStyle.BackColor,
                Font = new Font(source.DefaultCellStyle.FontName.ToFontName(), source.DefaultCellStyle.FontSize,
               source.DefaultCellStyle.FontStyle.ToFontStyle(), source.DefaultCellStyle.GraphicsUnit.ToUnit()),
                ForeColor = source.DefaultCellStyle.ForeColor,
                SelectionBackColor = source.DefaultCellStyle.SelectionBackColor,
                SelectionForeColor = source.DefaultCellStyle.SelectionForeColor
            };

            dec.GridColor = source.GridColor;
            dec.MultiSelect = source.MultiSelect;
            dec.RowHeadersBorderStyle = source.RowHeadersBorderStyle.ToBorderStyleHeader();

            dec.RowHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = source.RowHeadersDefaultCellStyle.Alignment.ToAlignement(),
                BackColor = source.RowHeadersDefaultCellStyle.BackColor,
                Font = new Font(source.RowHeadersDefaultCellStyle.FontName.ToFontName(), source.RowHeadersDefaultCellStyle.FontSize,
              source.RowHeadersDefaultCellStyle.FontStyle.ToFontStyle(), source.RowHeadersDefaultCellStyle.GraphicsUnit.ToUnit()),
                ForeColor = source.RowHeadersDefaultCellStyle.ForeColor,
                SelectionBackColor = source.RowHeadersDefaultCellStyle.SelectionBackColor,
                SelectionForeColor = source.RowHeadersDefaultCellStyle.SelectionForeColor
            };

            dec.RowHeadersVisible = source.RowHeadersVisible;
            dec.RowHeadersWidth = source.RowHeadersWidth;
            dec.RowHeadersWidthSizeMode = source.RowHeadersWidthSizeMode.ToHeadersWidthSizeMode();

            dec.RowsDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = source.RowsDefaultCellStyle.Alignment.ToAlignement(),
                BackColor = source.RowsDefaultCellStyle.BackColor,
                Font = new Font(source.RowsDefaultCellStyle.FontName.ToFontName(), source.RowsDefaultCellStyle.FontSize,
              source.RowsDefaultCellStyle.FontStyle.ToFontStyle(), source.RowsDefaultCellStyle.GraphicsUnit.ToUnit()),
                ForeColor = source.RowsDefaultCellStyle.ForeColor,
                SelectionBackColor = source.RowsDefaultCellStyle.SelectionBackColor,
                SelectionForeColor = source.RowsDefaultCellStyle.SelectionForeColor
            };

            dec.SelectionMode = source.SelectionMode.ToSelectionMode();
            dec.Name = source.Name;
            dec.Width = source.SizeWidth;
            dec.Height = source.SizeHeight;
            dec.Visible = source.Visible;

            return dec;
        }

        public static string ToColumnType(this string dataType)
        {
            string rs;
            switch (dataType)
            {
                case "bit":
                    rs = "DataGridViewCheckBoxColumn";
                    break;

                case "image":
                    rs = "DataGridViewImageColumn";
                    break;

                default:
                    rs = "DataGridViewTextBoxColumn";
                    break;
            }
            return rs;
        }
    }
}