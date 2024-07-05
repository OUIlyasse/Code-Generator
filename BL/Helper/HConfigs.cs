using BL.Configs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace BL.Helper
{
    public static class HConfigs
    {
        private static readonly string configDirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Code Generator");
        private static readonly string configFileName = "config.json";
        private static readonly string configFilePath = Path.Combine(configDirPath, configFileName);

        public static void SaveConfiguration(configApp configuration)
        {
            var rs = Serializer<configApp>.SerializeToJSON(configuration);
            if (!Directory.Exists(configDirPath))
                Directory.CreateDirectory(configDirPath);

            File.WriteAllText(configFilePath, rs);
        }

        public static configApp LoadConfiguration()
        {
            var configuration = new configApp();
            configuration.Toolboxs.Add(new Toolbox { NameToolbox = "CheckBox", Value = "Checked", Prefix = "ckb", Namespace = "System.Windows.Forms" });
            configuration.Toolboxs.Add(new Toolbox { NameToolbox = "ComboBox", Value = "Text", Prefix = "cmbx", Namespace = "System.Windows.Forms" });
            configuration.Toolboxs.Add(new Toolbox { NameToolbox = "DateTimePicker", Value = "Value", Prefix = "dtp", Namespace = "System.Windows.Forms" });
            configuration.Toolboxs.Add(new Toolbox { NameToolbox = "Label", Value = "Text", Prefix = "lbl", Namespace = "System.Windows.Forms" });
            configuration.Toolboxs.Add(new Toolbox { NameToolbox = "PictureBox", Value = "Image", Prefix = "pic", Namespace = "System.Windows.Forms" });
            configuration.Toolboxs.Add(new Toolbox { NameToolbox = "RadioButton", Value = "Checked", Prefix = "rdo", Namespace = "System.Windows.Forms" });
            configuration.Toolboxs.Add(new Toolbox { NameToolbox = "TextBox", Value = "Text", Prefix = "txt", Namespace = "System.Windows.Forms" });
            configuration.Toolboxs.Add(new Toolbox { NameToolbox = "RichTextBox", Value = "Text", Prefix = "rtb", Namespace = "System.Windows.Forms" });

            //configuration.TemplatesDatagridview.Add(new TemplateDatagridview("Template 1", true));

            if (!Directory.Exists(configDirPath))
            {
                Directory.CreateDirectory(configDirPath);
                SaveConfiguration(configuration);
                return configuration;
            }
            if (!File.Exists(configFilePath))
            {
                SaveConfiguration(configuration);
                return configuration;
            }
            var json = File.ReadAllText(configFilePath);

            return Serializer<configApp>.DeserializeToJSON(json);
        }
    }
}