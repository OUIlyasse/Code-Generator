using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL
{
    public class DatabaseInfo
    {
        public DatabaseInfo()
        {
            DatabaseName = "";
            Owner = "";
            DateCreated = null;
            Collation = "";
            CompatibilityLevel = "";
            RestrictAccess = "";
            Files = new List<DatabaseFileInfo>();
        }

        public string DatabaseName { get; set; }
        public string Owner { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Collation { get; set; }
        public string CompatibilityLevel { get; set; }
        public string RestrictAccess { get; set; }
        public List<DatabaseFileInfo> Files { get; set; } = new List<DatabaseFileInfo>();
    }
}