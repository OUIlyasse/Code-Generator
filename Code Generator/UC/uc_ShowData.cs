using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.Configs;
using BL.Helper;
using System.Text.RegularExpressions;

namespace Code_Generator.UC
{
    public partial class uc_ShowData : UserControl
    {
        public dbInfo dbInfo { get; set; }
        public BL.iSQL.SQL SQL { get; set; }
        public DataGridView MyGrid { get; set; }

        #region codes

        private void FillMenuSQL()
        {
            List<string> words = new List<string>() { "ABSOLUTE", "ACTION", "ADD", "ADMIN", "AFTER", "AGGREGATE", "ALTER", "AS", "ASC", "AUDIT", "AUTHORIZATION", "BACKUP", "BEGIN", "BREAK", "BROWSE", "BULK", "BY", "CALL", "CASCADE", "CASE", "CATALOG", "BREAK", "BROWSE", "BULK", "BY", "CALL", "CASCADE", "CASE", "CATALOG", "BREAK", "BROWSE", "BULK", "BY", "CALL", "CASCADE", "CASE", "CATALOG", "BREAK", "BROWSE", "BULK", "BY", "CALL", "CASCADE", "CASE", "CATALOG", "BREAK", "BROWSE", "BULK", "BY", "CALL", "CASCADE", "CASE", "CATALOG", "CHARACTER", "CHECK", "CHECKPOINT", "CLOSE", "CLUSTERED", "COMMIT", "COMPUTE", "CONNECT", "CONSTRAINT", "CONTAINSTABLE", "CONTINUE", "CREATE", "CUBE", "CURRENT", "CURRENT_DATE", "DATABASE", "DBCC", "DEALLOCATE", "DECLARE", "DEFAULT", "DELETE", "DENY", "DESC", "DISK", "DISTINCT", "DISTRIBUTED", "DROP", "DUMP", "DYNAMIC", "ELSE", "END", "END-EXEC", "ERRLVL", "ESCAPE", "EXCEPT", "EXEC", "EXECUTE", "EXIT", "EXTERNAL", "FETCH", "FILE", "FILLFACTOR", "FIRST", "FOR", "FOREIGN", "FREETEXT", "FREETEXTTABLE", "FROM", "FULL", "FUNCTION", "GET", "GLOBAL", "GO", "GOTO", "GRANT", "GROUP", "HAVING", "HOLDLOCK", "IDENTITY", "IDENTITY_INSERT", "IDENTITYCOL", "IF", "IMMEDIATE", "INCLUDE", "INDEX", "INSERT", "INTERSECT", "INTO", "ISOLATION", "KEY", "KILL", "LANGUAGE", "LAST", "LENGTH", "LEVEL", "LINENO", "LOAD", "LOCAL", "LOOP", "MERGE", "MODIFY", "NATIONAL", "NEXT", "NO", "NONCLUSTERED", "NONE", "NOWAIT", "OBJECT", "OF", "OFF", "OFFLINE", "OFFSETS", "ON", "ONLINE", "OPEN", "OPENDATASOURCE", "OPENQUERY", "OPENROWSET", "OPENXML", "OPTION", "ORDER", "OUT", "OUTPUT", "OVER", "PARTIAL", "PARTITION", "PATH", "PERCENT", "PLAN", "PRIMARY", "PRINT", "PRIOR", "PROC", "PROCEDURE", "PUBLIC", "RAISERROR", "RANGE", "READ", "READTEXT", "RECONFIGURE", "RECURSIVE", "REFERENCES", "RELATIVE", "REPEAT", "REPLICATION", "RESOURCE", "RESTORE", "RESTRICT", "RETURN", "RETURNS", "REVOKE", "ROLLBACK", "ROLLUP", "ROW", "ROWCOUNT", "ROWGUIDCOL", "ROWS", "RULE", "SAVE", "SCHEMA", "SCROLL", "SELECT", "SEQUENCE", "SESSION", "SET", "SETS", "SETUSER", "SHUTDOWN", "SQL", "STATE", "STATEMENT", "STATIC", "STATISTICS", "SYNONYM", "TABLE", "TABLESAMPLE", "TEXTSIZE", "THEN", "TO", "TOP", "TRAN", "TRANSACTION", "TRIGGER", "TRUNCATE", "TYPE", "UID", "UNION", "UNIQUE", "UPDATETEXT", "USE", "USER", "USING", "VALUES", "VARYING", "WITHOUT", "WRITETEXT", "VIEW", "WAITFOR", "WHEN", "WHERE", "WHILE", "WITH", "ASYMMETRIC", "ATOMIC", "BIGINT", "BINARY", "BIT", "DATE", "DATETIME", "CHAR", "DEC", "DECIMAL", "CURSOR", "DOUBLE", "FLOAT", "INT", "INTEGER", "NCHAR", "NUMERIC", "PRECISION", "RAW", "REAL", "SMALLINT", "TEXT", "TIME", "TIMESTAMP", "TINYINT", "VARBINARY", "VARCHAR", "NVARCHAR", "COMMITTED", "DISABLE", "ENABLE", "FOLLOWING", "FORCE", "FULLTEXT", "INSENSITIVE", "INSTEAD", "LOGIN", "MOVE", "OWNER", "PASSWORD", "PRECEDING", "REPEATABLE", "RESET", "RESTART", "ROLE", "SECURITY", "SELF", "SERIALIZABLE", "SIMPLE", "SPATIAL", "SSL", "STATUS", "SYMMETRIC", "SYSTEM", "UNBOUNDED", "UNCOMMITTED", "UNLOCK", "VERBOSE", "WITHIN", "ANSI_NULLS", "QUOTED_IDENTIFIER", "PARAMETERS", "COLUMNS", "DATABASES", "SCHEMAS", "TABLES", "ALL", "AND", "ANY", "BETWEEN", "CROSS", "EXISTS", "IN", "INNER", "IS", "JOIN", "LEFT", "LIKE", "NOT", "NULL", "OR", "OUTER", "RIGHT", "SOME", "MATCHED", "SOURCE", "ABS", "AVG", "CAST", "CEILING", "CAST", "CEILING", "CAST", "CEILING", "CAST", "CHECKSUM", "COALESCE", "COLLATE", "CONTAINS", "CONVERT", "COUNT", "CURRENT_TIME", "CURRENT_TIMESTAMP", "CURRENT_USER", "DENSE_RANK", "EXP", "EXTRACT", "FLOOR", "GROUPING", "HOUR", "ISNULL", "LOWER", "MAX", "MIN", "MINUTE", "MOD", "MONTH", "NULLIF", "POWER", "RANK", "REPLACE", "ROW_NUMBER", "SCHEMA_NAME", "SECOND", "SESSION_USER", "SPACE", "UPPER", "SQRT", "SUBSTRING", "SUM", "SYSTEM_USER", "TSEQUAL", "UPDATE", "DAY", "BIT_LENGTH", "YEAR", "DAYOFMONTH", "DAYOFWEEK", "DAYOFYEAR", "MONTHNAME", "NORMALIZE", "OCTET_LENGTH" };
            foreach (string item in words)
                menuSQL.AddItem(new AutocompleteMenuNS.AutocompleteItem
                {
                    Text = item,
                    ImageIndex = 2
                });

            foreach (string item in SQL.GetTable())
                menuSQL.AddItem(new AutocompleteMenuNS.AutocompleteItem
                {
                    Text = item,
                    ImageIndex = 0
                });
            foreach (string item in SQL.GetView())
                menuSQL.AddItem(new AutocompleteMenuNS.AutocompleteItem
                {
                    Text = item,
                    ImageIndex = 0
                });
            foreach (string item in SQL.getField())
                menuSQL.AddItem(new AutocompleteMenuNS.AutocompleteItem
                {
                    Text = item,
                    ImageIndex = 1
                });
            foreach (string item in SQL.getSP())
                menuSQL.AddItem(new AutocompleteMenuNS.AutocompleteItem
                {
                    Text = item,
                    ImageIndex = 0
                });
        }

        private void SyntaxeSQL()
        {
            rtbSQLQuery.SuspendLayout();
            // getting keywords/functions
            string keywords1 = @"\b(ABSOLUTE|ACTION|ADD|ADMIN|AFTER|AGGREGATE|ALTER|AS|ASC|AUDIT|AUTHORIZATION|BACKUP|BEGIN|BREAK|
                                                BROWSE|BULK|BY|CALL|CASCADE|CASE|CATALOG|BREAK|BROWSE|BULK|BY|CALL|CASCADE|CASE|CATALOG|BREAK|BROWSE|
                                                BULK|BY|CALL|CASCADE|CASE|CATALOG|BREAK|BROWSE|BULK|BY|CALL|CASCADE|CASE|CATALOG|BREAK|BROWSE|BULK|BY|
                                                CALL|CASCADE|CASE|CATALOG|CHARACTER|CHECK|CHECKPOINT|CLOSE|CLUSTERED|COMMIT|COMPUTE|CONNECT|
                                                CONSTRAINT|CONTAINSTABLE|CONTINUE|CREATE|CUBE|CURRENT|CURRENT_DATE|DATABASE|DBCC|DEALLOCATE|DECLARE|
                                                DEFAULT|DELETE|DENY|DESC|DISK|DISTINCT|DISTRIBUTED|DROP|DUMP|DYNAMIC|ELSE|END|END-EXEC|ERRLVL|ESCAPE|
                                                EXCEPT|EXEC|EXECUTE|EXIT|EXTERNAL|FETCH|FILE|FILLFACTOR|FIRST|FOR|FOREIGN|FREETEXT|FREETEXTTABLE|FROM|FULL|
                                                FUNCTION|GET|GLOBAL|GO|GOTO|GRANT|GROUP|HAVING|HOLDLOCK|IDENTITY|IDENTITY_INSERT|IDENTITYCOL|IF|
                                                IMMEDIATE|INCLUDE|INDEX|INSERT|INTERSECT|INTO|ISOLATION|KEY|KILL|LANGUAGE|LAST|LENGTH|LEVEL|LINENO|LOAD|
                                                LOCAL|LOOP|MERGE|MODIFY|NATIONAL|NEXT|NO|NONCLUSTERED|NONE|NOWAIT|OBJECT|OF|OFF|OFFLINE|OFFSETS|ON|
                                                ONLINE|OPEN|OPENDATASOURCE|OPENQUERY|OPENROWSET|OPENXML|OPTION|ORDER|OUT|OUTPUT|OVER|PARTIAL|
                                                PARTITION|PATH|PERCENT|PLAN|PRIMARY|PRINT|PRIOR|PROC|PROCEDURE|PUBLIC|RAISERROR|RANGE|READ|READTEXT|
                                                RECONFIGURE|RECURSIVE|REFERENCES|RELATIVE|REPEAT|REPLICATION|RESOURCE|RESTORE|RESTRICT|RETURN|RETURNS|
                                                REVOKE|ROLLBACK|ROLLUP|ROW|ROWCOUNT|ROWGUIDCOL|ROWS|RULE|SAVE|SCHEMA|SCROLL|SELECT|SEQUENCE|
                                                SESSION|SET|SETS|SETUSER|SHUTDOWN|SQL|STATE|STATEMENT|STATIC|STATISTICS|SYNONYM|TABLE|TABLESAMPLE|TEXTSIZE|
                                                THEN|TO|TOP|TRAN|TRANSACTION|TRIGGER|TRUNCATE|TYPE|UID|UNION|UNIQUE|UPDATETEXT|USE|USER|USING|VALUES|
                                                VARYING|WITHOUT|WRITETEXT|VIEW|WAITFOR|WHEN|WHERE|WHILE|WITH|ASYMMETRIC|ATOMIC|BIGINT|BINARY|BIT|
                                                DATE|DATETIME|CHAR|DEC|DECIMAL|CURSOR|DOUBLE|FLOAT|INT|INTEGER|NCHAR|NUMERIC|PRECISION|RAW|REAL|
                                                SMALLINT|TEXT|TIME|TIMESTAMP|TINYINT|VARBINARY|VARCHAR|NVARCHAR|COMMITTED|DISABLE|ENABLE|FOLLOWING|
                                                FORCE|FULLTEXT|INSENSITIVE|INSTEAD|LOGIN|MOVE|OWNER|PASSWORD|PRECEDING|REPEATABLE|RESET|RESTART|ROLE|
                                                SECURITY|SELF|SERIALIZABLE|SIMPLE|SPATIAL|SSL|STATUS|SYMMETRIC|SYSTEM|UNBOUNDED|UNCOMMITTED|UNLOCK|
                                                VERBOSE|WITHIN|ANSI_NULLS|QUOTED_IDENTIFIER)\b";

            MatchCollection typeMatches1 = Regex.Matches(rtbSQLQuery.Text.ToUpper(), keywords1);

            // getting types/classes from the text
            string keywords2 = @"\b(PARAMETERS|COLUMNS|DATABASES|SCHEMAS|TABLES)\b";
            MatchCollection typeMatches2 = Regex.Matches(rtbSQLQuery.Text.ToUpper(), keywords2);

            string keywords3 = @"\b(ALL|AND|ANY|BETWEEN|CROSS|EXISTS|IN|INNER|IS|JOIN|LEFT|LIKE|NOT|NULL|OR|OUTER|RIGHT|SOME|
                                                   MATCHED|SOURCE)\b";
            MatchCollection typeMatches3 = Regex.Matches(rtbSQLQuery.Text.ToUpper(), keywords3);

            string keywords4 = @"\b(ABS|AVG|CAST|CEILING|CAST|CEILING|CAST|CEILING|CAST|CHECKSUM|COALESCE|COLLATE|CONTAINS|CONVERT|
                                                   COUNT|CURRENT_TIME|CURRENT_TIMESTAMP|CURRENT_USER|DENSE_RANK|EXP|EXTRACT|FLOOR|GROUPING|HOUR|
                                                   ISNULL|LOWER|MAX|MIN|MINUTE|MOD|MONTH|NULLIF|POWER|RANK|REPLACE|ROW_NUMBER|SCHEMA_NAME|
                                                   SECOND|SESSION_USER|SPACE|UPPER|SQRT|SUBSTRING|SUM|SYSTEM_USER|TSEQUAL|UPDATE|DAY|BIT_LENGTH|YEAR|
                                                   DAYOFMONTH|DAYOFWEEK|DAYOFYEAR|MONTHNAME|NORMALIZE|OCTET_LENGTH)\b";
            MatchCollection typeMatches4 = Regex.Matches(rtbSQLQuery.Text.ToUpper(), keywords4);

            // getting comments (inline or multiline)
            //string comments = @"(\/\/.+?$|\/\*.+?\*\/)";
            string comments = @"(--.+?$|\/\*.+?\*\/)";
            MatchCollection commentMatches = Regex.Matches(rtbSQLQuery.Text, comments, RegexOptions.Multiline);

            // getting strings
            string strings = @"(@\S+)";
            MatchCollection stringMatches = Regex.Matches(rtbSQLQuery.Text, strings);

            // getting strings
            string strings2 = "\'.+?\'";
            MatchCollection stringMatches2 = Regex.Matches(rtbSQLQuery.Text, strings2);

            // saving the original caret position + forecolor
            int originalIndex = rtbSQLQuery.SelectionStart;
            int originalLength = rtbSQLQuery.SelectionLength;
            Color originalColor = Color.Black;

            //picLines.Focus();

            // removes any previous highlighting (so modified words won't remain highlighted)
            rtbSQLQuery.SelectionStart = 0;
            rtbSQLQuery.SelectionLength = rtbSQLQuery.Text.Length;
            rtbSQLQuery.SelectionColor = originalColor;

            // scanning...
            foreach (Match m in typeMatches1)
            {
                rtbSQLQuery.SelectionStart = m.Index;
                rtbSQLQuery.SelectionLength = m.Length;
                rtbSQLQuery.SelectionColor = Color.FromArgb(0, 0, 255); //Bleu
                rtbSQLQuery.SelectedText = Regex.Replace(m.Value,
                  @"\b[A-Z]",
                  s => s.ToString().ToUpper(),
                  RegexOptions.IgnoreCase);
            }

            foreach (Match m in typeMatches2)
            {
                rtbSQLQuery.SelectionStart = m.Index;
                rtbSQLQuery.SelectionLength = m.Length;
                rtbSQLQuery.SelectionColor = Color.FromArgb(52, 255, 52); //Vert
                rtbSQLQuery.SelectedText = Regex.Replace(m.Value,
                  @"\b[A-Z]",
                  s => s.ToString().ToUpper(),
                  RegexOptions.IgnoreCase);
            }

            foreach (Match m in typeMatches3)
            {
                rtbSQLQuery.SelectionStart = m.Index;
                rtbSQLQuery.SelectionLength = m.Length;
                rtbSQLQuery.SelectionColor = Color.FromArgb(128, 128, 150); //Gris
                rtbSQLQuery.SelectedText = Regex.Replace(m.Value,
                  @"\b[A-Z]",
                  s => s.ToString().ToUpper(),
                  RegexOptions.IgnoreCase);
            }

            foreach (Match m in typeMatches4)
            {
                rtbSQLQuery.SelectionStart = m.Index;
                rtbSQLQuery.SelectionLength = m.Length;
                rtbSQLQuery.SelectionColor = Color.FromArgb(255, 0, 255);//Rose
                rtbSQLQuery.SelectedText = Regex.Replace(m.Value,
                  @"\b[A-Z]",
                  s => s.ToString().ToUpper(),
                  RegexOptions.IgnoreCase);
            }

            foreach (Match m in commentMatches)
            {
                rtbSQLQuery.SelectionStart = m.Index;
                rtbSQLQuery.SelectionLength = m.Length;
                rtbSQLQuery.SelectionColor = Color.Green;
            }

            foreach (Match m in stringMatches)
            {
                rtbSQLQuery.SelectionStart = m.Index;
                rtbSQLQuery.SelectionLength = m.Length;
                rtbSQLQuery.SelectionColor = Color.FromArgb(173, 0, 173); //Violet
            }

            foreach (Match m in stringMatches2)
            {
                rtbSQLQuery.SelectionStart = m.Index;
                rtbSQLQuery.SelectionLength = m.Length;
                rtbSQLQuery.SelectionColor = Color.FromArgb(255, 0, 0); //Rouge
            }

            // restoring the original colors, for further writing
            rtbSQLQuery.SelectionStart = originalIndex;
            rtbSQLQuery.SelectionLength = originalLength;
            rtbSQLQuery.SelectionColor = originalColor;
            // giving back the focus

            rtbSQLQuery.Focus();
            rtbSQLQuery.ResumeLayout();
        }

        private void HighlightSyntax()
        {
            SyntaxeSQL();
        }

        #endregion codes

        public uc_ShowData()
        {
            InitializeComponent();
            dbInfo = HDbInfo.LoadConfiguration();
            SQL = new BL.iSQL.SQL(dbInfo.conString, dbInfo.DatabaseName);
            FillMenuSQL();
        }

        private void rtbSQLQuery_TextChanged(object sender, EventArgs e)
        {
            HighlightSyntax();
            timer1.Stop();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            MyGrid.DataSource = SQL.ExecuteQuery(rtbSQLQuery.Text, SQL.ConnectionString);
        }
    }
}