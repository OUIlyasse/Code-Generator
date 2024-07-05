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
    public class HDbInfo
    {
        private static readonly string configDirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Code Generator");
        private static readonly string configFileName = "dbInfo.json";
        private static readonly string configFilePath = Path.Combine(configDirPath, configFileName);

        public static void SaveConfiguration(dbInfo db)
        {
            var rs = Serializer<dbInfo>.SerializeToJSON(db);
            if (!Directory.Exists(configDirPath))
                Directory.CreateDirectory(configDirPath);

            File.WriteAllText(configFilePath, rs);
        }

        public static dbInfo LoadConfiguration()
        {
            var configuration = new dbInfo();

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

            return Serializer<dbInfo>.DeserializeToJSON(json);
        }
    }
}