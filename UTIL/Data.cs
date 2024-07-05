using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTIL
{
    public enum DataTypeForSQLServer
    {
        INT,
        BIGINT,
        SMALLINT,
        TINYINT,
        NUMERIC,
        DECIMAL,
        FLOAT,
        REAL,
        DATETIME,
        DATETIME2,
        DATE,
        TIME,
        CHAR,
        VARCHAR,
        TEXT,
        NCHAR,
        NVARCHAR,
        NTEXT,
        BINARY,
        VARBINARY,
        IMAGE,
        BIT,
        UNIQUEIDENTIFIER,
        XML,
        SQLVARIANT,
        TIMESTAMP,
        GEOGRAPHY,
        GEOMETRY
    }

    public enum TypeDatabase
    {
        None, Microsoft_SQL_Server, MySQL, Microsoft_Access, Oracle, LocalSQL
    }

    public enum Language
    {
        Custom = 0, SQL = 1, CSharp = 2, VBNET = 3
    }

    public enum Crud
    {
        Normal, Parametre
    }

    public enum Procedure
    {
        Private, Public, Internal
    }

    public enum Variable
    {
        Private, Public, Internal
    }

    public partial class Data
    {
        public static List<string> LoadType()
        {
            return new List<string>
            {
                "Microsoft SQL Server", "MySQL", "Microsoft Access", "Oracle", "LocalSQL"
            };
        }

        public static readonly Dictionary<string, string> CompatibilityLevelMap = new Dictionary<string, string>
    {
        { "80", "SQL Server 2000 (80)" },
        { "90", "SQL Server 2005 (90)" },
        { "100", "SQL Server 2008 (100)" },
        { "110", "SQL Server 2012 (110)" },
        { "120", "SQL Server 2014 (120)" },
        { "130", "SQL Server 2016 (130)" },
        { "140", "SQL Server 2017 (140)" },
        { "150", "SQL Server 2019 (150)" },
        { "160", "SQL Server 2022 (160)" }
    };

        //  None, Microsoft_SQL_Server, MySQL, Microsoft_Access, Oracle, LocalSQL
        public static readonly Dictionary<string, string> CompatibilityTypeDatabase = new Dictionary<string, string>
    {
        { "None", "None" },
        { "Microsoft_SQL_Server", "Microsoft SQL Server" },
        { "MySQL", "MySQL" },
        { "Microsoft_Access", "Microsoft Access" },
        { "Oracle", "Oracle" },
        { "LocalSQL", "Local SQL" }
    };

        public static List<string> DataTypeSQLServer()
        {
            List<string> rs = new List<string>()
            {
"int","bigint","smallint","tinyint","numeric","decimal","float","real","datetime","datetime2","date","time","char","varchar","text","nchar","nvarchar","ntext","binary","varbinary","image","bit","uniqueidentifier","xml","sql_variant","timestamp","geography","geometry"            };
            return rs;
        }

        public static List<string> DataTypeSQLServerStrings()
        {
            List<string> rs = new List<string>()
            {
"char","varchar","nchar","nvarchar"
            };
            return rs;
        }

        public static List<string> DataTypeSQLServerNumeric()
        {
            List<string> rs = new List<string>()
            {
"tinyint", "smallint", "int", "bigint", "decimal", "numeric"
            };
            return rs;
        }

        public static List<string> ControlAcceptDatasource()
        {
            List<string> rs = new List<string>()
            {
                    "ComboBox"
            };
            return rs;
        }

        public static List<string> ColumnType()
        {
            List<string> rs = new List<string>
            {
                "DataGridViewTextBoxColumn","DataGridViewCheckBoxColumn", "DataGridViewImageColumn", "DataGridViewButtonColumn", "DataGridViewComboBoxColumn", "DataGridViewLinkColumn"
            };
            return rs;
        }

        public static List<string> AutoSizeMode()
        {
            List<string> rs = new List<string>
            {
              "NotSet","None","ColumnHeader","AllCellsExceptHeader","AllCells","DisplayedCellsExceptHeader","DisplayedCells","Fill"
            };
            return rs;
        }
    }
}