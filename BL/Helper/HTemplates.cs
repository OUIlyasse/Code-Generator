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
    public class HTemplates
    {
        private static readonly string configDirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Code Generator");
        private static readonly string configFileName = "dgvTemplate.json";
        private static readonly string configFilePath = Path.Combine(configDirPath, configFileName);

        public static void SaveConfiguration(configTemplate template)
        {
            var rs = Serializer<configTemplate>.SerializeToJSON(template);
            if (!Directory.Exists(configDirPath))
                Directory.CreateDirectory(configDirPath);

            File.WriteAllText(configFilePath, rs);
        }

        public static configTemplate LoadConfiguration()
        {
            var configuration = new configTemplate();

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

            return Serializer<configTemplate>.DeserializeToJSON(json);
        }
    }
}