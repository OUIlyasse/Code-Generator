using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTIL;

namespace Tools
{
    public static class Tools
    {
        public static string ControlName(string input)
        {
            string[] parts = input.Split('_');

            // Initialize the result with the first part unchanged
            string result = parts[0];

            // Iterate through the remaining parts and convert them to uppercase
            for (int i = 1; i < parts.Length; i++)
            {
                // Convert the first character of each part to uppercase
                char firstChar = char.ToUpper(parts[i][0]);
                // Concatenate the uppercase first character with the rest of the part
                result += firstChar + parts[i].Substring(1);
            }

            return result;
        }

        public static List<string> GetAllControlEvents(string control)
        {
            List<string> rs = new List<string>();
            Type controlType = null;
            switch (control)
            {
                case "CheckBox":
                    controlType = typeof(CheckBox);
                    break;

                case "ComboBox":
                    controlType = typeof(ComboBox);
                    break;

                case "DateTimePicker":
                    controlType = typeof(DateTimePicker);
                    break;

                case "Label":
                    controlType = typeof(Label);
                    break;

                case "PictureBox":
                    controlType = typeof(PictureBox);
                    break;

                case "RadioButton":
                    controlType = typeof(RadioButton);
                    break;

                case "TextBox":
                    controlType = typeof(TextBox);
                    break;

                case "RichTextBox":
                    controlType = typeof(RichTextBox);
                    break;

                case "DataGridView":
                    controlType = typeof(DataGridView);
                    break;
            }

            dynamic controls = Activator.CreateInstance(controlType);
            EventInfo[] events = controlType.GetEvents();
            foreach (EventInfo e in events)
                rs.Add(e.Name);
            return rs;
        }

        public static string GetTypeEvents(string control, string eventName)
        {
            string rs = "";
            Type controlType = null;
            switch (control)
            {
                case "CheckBox":
                    controlType = typeof(CheckBox);
                    break;

                case "ComboBox":
                    controlType = typeof(ComboBox);
                    break;

                case "DateTimePicker":
                    controlType = typeof(DateTimePicker);
                    break;

                case "Label":
                    controlType = typeof(Label);
                    break;

                case "PictureBox":
                    controlType = typeof(PictureBox);
                    break;

                case "RadioButton":
                    controlType = typeof(RadioButton);
                    break;

                case "TextBox":
                    controlType = typeof(TextBox);
                    break;

                case "RichTextBox":
                    controlType = typeof(RichTextBox);
                    break;

                case "DataGridView":
                    controlType = typeof(DataGridView);
                    break;
            }

            dynamic controls = Activator.CreateInstance(controlType);
            EventInfo[] events = controlType.GetEvents();
            foreach (EventInfo e in events)
            {
                if (e.Name.Equals(eventName))
                {
                    rs = e.EventHandlerType.Name;

                    break;
                }
            }

            return rs;
        }

        public static EventInfo GetInfoEventsForDatagridView(string eventName)
        {
            return typeof(DataGridView).GetEvent(eventName);
        }

        public static string InsertTabs(string text, int tabCount)
        {
            string tabs = new string('\t', tabCount);
            return tabs + text;
        }

        public static string InsertTabs(int tabCount, int speed = 0)
        {
            string tabs = new string('\t', tabCount + speed);
            return tabs;
        }

        public static string Insert(char c, int tabCount)
        {
            string tabs = new string(c, tabCount);
            return tabs;
        }

        public static void OrganizeColumns(DataGridView dgv, List<string> columnName)
        {
            int i = 0;
            foreach (var column in columnName)
            {
                if (dgv.Columns.Contains(column))
                {
                    dgv.Columns[column].DisplayIndex = i;
                }
                i++;
            }
        }

        public static void Write(string text, string path)
        {
        }

        public static string ToList(this DataTypeForSQLServer prop)
        {
            List<string> rss = new List<string>()
            {
"int","bigint","smallint","tinyint","numeric","decimal","float","real","datetime","datetime2","date","time","char","varchar","text","nchar","nvarchar","ntext","binary","varbinary","image","bit","uniqueidentifier","xml","sql_variant","timestamp","geography","geometry"            };

            string rs = rss.FirstOrDefault(s => s.Equals(prop.ToString(), StringComparison.OrdinalIgnoreCase));

            return rs;
        }

        public static string ToText(this Procedure prop)
        {
            return prop.ToString().ToLower();
        }

        public static string ToText(this Variable prop)
        {
            return prop.ToString().ToLower();
        }

        public static void SaveFile(string path, string text)
        {
            File.WriteAllText(path, text);
        }
    }
}