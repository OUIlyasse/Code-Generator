using BL.Configs;
using BL.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTIL;

namespace BL.iCSharp
{
    public partial class CSharp
    {
        #region Codes

        public int countSelected(DataGridView grid)
        {
            int count = 0;

            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (System.Convert.ToBoolean(grid.Rows[i].Cells["colSelected"].Value) == true)
                    count++;
            }

            return count;
        }

        public int countOrderBy(DataGridView grid)
        {
            int count = 0;

            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (System.Convert.ToBoolean(grid.Rows[i].Cells["colOrderBy"].Value) == true)
                    count++;
            }

            return count;
        }

        public int countWhere(DataGridView grid)
        {
            int count = 0;

            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (System.Convert.ToBoolean(grid.Rows[i].Cells["colWhere"].Value) == true)
                    count++;
            }

            return count;
        }

        public int countWhereAndDate(DataGridView grid)
        {
            int count = 0;

            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (System.Convert.ToBoolean(grid.Rows[i].Cells["colWhere"].Value) == true && grid.Rows[i].Cells["colDataType"].Value.ToString().Contains("date"))
                    count++;
            }

            return count;
        }

        public int countDate(DataGridView grid)
        {
            int count = 0;

            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].Cells["colDataType"].Value.ToString().Contains("date"))
                    count++;
            }

            return count;
        }

        public int countGrouprBy(DataGridView grid)
        {
            int count = 0;

            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (System.Convert.ToBoolean(grid.Rows[i].Cells["colGroupBy"].Value) == true)
                    count++;
            }

            return count;
        }

        public int countCheckReccord(DataGridView grid)
        {
            int count = 0;

            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (System.Convert.ToBoolean(grid.Rows[i].Cells["colCheckReccord"].Value) == true)
                    count++;
            }

            return count;
        }

        public int countCheckReccord(DataGridView grid, string columnName)
        {
            int count = 0;

            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(grid.Rows[i].Cells["colCheckReccord"].Value) == true)
                {
                    if (grid.Rows[i].Cells["colColumnName"].Value.ToString() == columnName)
                    {
                        count++;
                        break;
                    }
                    count++;
                }
            }

            return count;
        }

        private bool isFieldOrderBy(DataGridView grid, string columnName)
        {
            bool rs = false;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].Cells["colColumnName"].Value.ToString() == columnName)
                {
                    if (System.Convert.ToBoolean(grid.Rows[i].Cells["colOrderBy"].Value) == true)
                    {
                        rs = true;
                    }
                }
            }

            return rs;
        }

        private string getOrderByField(DataGridView grid, string columnName)
        {
            string rs = string.Empty;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].Cells["colColumnName"].Value.ToString() == columnName)
                {
                    if (System.Convert.ToBoolean(grid.Rows[i].Cells["colOrderBy"].Value) == true)
                    {
                        rs = $"{grid.Rows[i].Cells["colOrder"].Value}";
                    }
                }
            }

            return rs == "" ? "ASC" : rs;
        }

        private bool isFieldGroupBy(DataGridView grid, string columnName)
        {
            bool rs = false;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].Cells["colColumnName"].Value.ToString() == columnName)
                {
                    if (System.Convert.ToBoolean(grid.Rows[i].Cells["colGroupBy"].Value) == true)
                    {
                        rs = true;
                    }
                }
            }

            return rs;
        }

        private bool isFieldWhere(DataGridView grid, string columnName)
        {
            bool rs = false;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].Cells["colColumnName"].Value.ToString() == columnName)
                {
                    if (System.Convert.ToBoolean(grid.Rows[i].Cells["colWhere"].Value) == true)
                    {
                        rs = true;
                    }
                }
            }

            return rs;
        }

        private string getFieldDefaultValue(DataGridView grid, string columnName)
        {
            string rs = string.Empty;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].Cells["colColumnName"].Value.ToString() == columnName)
                {
                    if (System.Convert.ToBoolean(grid.Rows[i].Cells["colWhere"].Value) == true)
                    {
                        rs = $"{grid.Rows[i].Cells["colAlias"].Value}";
                    }
                }
            }

            return rs;
        }

        private bool isFieldCheckReccord(DataGridView grid, string columnName)
        {
            bool rs = false;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].Cells["colColumnName"].Value.ToString() == columnName)
                {
                    if (System.Convert.ToBoolean(grid.Rows[i].Cells["colCheckReccord"].Value) == true)
                    {
                        rs = true;
                    }
                }
            }

            return rs;
        }

        private string getCheckReccord(DataGridView grid, string columnName)
        {
            string rs = string.Empty;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].Cells["colColumnName"].Value.ToString() == columnName)
                {
                    if (System.Convert.ToBoolean(grid.Rows[i].Cells["colCheckReccord"].Value) == true)
                    {
                        rs = $"{grid.Rows[i].Cells["colOperator"].Value}";
                    }
                }
            }

            return rs == "" ? "=" : rs;
        }

        private string getCheckReccordOperator(DataGridView grid, string columnName)
        {
            string rs = string.Empty;

            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].Cells["colColumnName"].Value.ToString() == columnName)
                {
                    if (Convert.ToBoolean(grid.Rows[i].Cells["colCheckReccord"].Value) == true)
                    {
                        rs = $"{grid.Rows[i].Cells["colOperatorCheck"].Value}";
                    }
                }
            }

            return rs == "" ? "AND" : rs;
        }

        private bool isFieldIdentity(DataGridView grid, string columnName)
        {
            bool rs = false;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].Cells["colColumnName"].Value.ToString() == columnName)
                {
                    if (System.Convert.ToBoolean(grid.Rows[i].Cells["colIdentity"].Value) == true)
                    {
                        rs = true;
                    }
                }
            }

            return rs;
        }

        private bool isFieldPrimaryKey(DataGridView grid, string columnName)
        {
            bool rs = false;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].Cells["colColumnName"].Value.ToString() == columnName)
                {
                    if (System.Convert.ToBoolean(grid.Rows[i].Cells["colPrimaryKey"].Value) == true)
                    {
                        rs = true;
                    }
                }
            }

            return rs;
        }

        private bool isImageExist(DataGridView grid)
        {
            bool rs = false;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (System.Convert.ToBoolean(grid.Rows[i].Cells["colSelected"].Value) == true && grid.Rows[i].Cells["colDataType"].Value.ToString() == "image")
                {
                    rs = true;
                }
            }
            return rs;
        }

        private List<string> getControlNameByImage(DataGridView grid)
        {
            var rs = new List<string>();
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (System.Convert.ToBoolean(grid.Rows[i].Cells["colSelected"].Value) == true && grid.Rows[i].Cells["colDataType"].Value.ToString() == "image")
                {
                    string ctr = $"{grid.Rows[i].Cells["colControlName"].Value}";
                    rs.Add(ctr);
                }
            }
            return rs;
        }

        private bool isFieldDateExist(DataGridView grid, string columnName)
        {
            bool rs = false;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].Cells["colColumnName"].Value.ToString() == columnName)
                {
                    if (grid.Rows[i].Cells["colDataType"].Value.ToString().Contains("date"))
                    {
                        rs = true;
                    }
                }
            }

            return rs;
        }

        private bool isFieldSelected(DataGridView grid, string field)
        {
            bool rs = false;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].Cells["colColumnName"].Value.ToString() == field)
                {
                    if (System.Convert.ToBoolean(grid.Rows[i].Cells["colSelected"].Value) == true)
                    {
                        rs = true;
                    }
                }
            }

            return rs;
        }

        private bool isFieldSWC(DataGridView grid, string field)
        {
            bool rs = false;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].Cells["colColumnName"].Value.ToString() == field)
                {
                    if (Convert.ToBoolean(grid.Rows[i].Cells["colSelected"].Value) == true || Convert.ToBoolean(grid.Rows[i].Cells["colWhere"].Value) == true || Convert.ToBoolean(grid.Rows[i].Cells["colCheckReccord"].Value) == true)
                    {
                        rs = true;
                    }
                }
            }

            return rs;
        }

        private string generateSearchString(string columnName, string dataType, int type)
        {
            string rs = string.Empty;

            switch (type)
            {
                case 0:
                    if (dataType.Contains("char"))
                    {
                        rs = $"({columnName} LIKE '%' + @Search + '%')";
                    }
                    else
                    {
                        rs = $"(CAST({columnName} as nvarchar) LIKE '%' + @Search + '%')";
                    }
                    break;

                case 1:
                    if (dataType.Contains("char"))
                    {
                        rs = $"[{columnName}]";
                    }
                    else
                    {
                        rs = $"CAST([{columnName}] as nvarchar)";
                    }
                    break;

                case 2:
                    rs = $"{columnName} >= @Date1 AND {columnName} <= @Date2";
                    break;
            }

            return rs;
        }

        private bool isFieldAggregation(DataGridView grid, string columnName, out string aggregation)
        {
            aggregation = string.Empty;
            bool rs = false;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].Cells["colColumnName"].Value.ToString() == columnName)
                {
                    switch ($"{grid.Rows[i].Cells["colFunction"].Value}")
                    {
                        case "UPPER":
                            aggregation = $"UPPER('{columnName}') as {columnName}";
                            rs = true;
                            break;

                        case "LTRIM":
                            aggregation = $"LTRIM('{columnName}') as {columnName}";
                            rs = true;
                            break;

                        case "LOWER":
                            aggregation = $"LOWER('{columnName}') as {columnName}";
                            rs = true;
                            break;

                        case "AVG":
                            aggregation = $"COALESCE(AVG({columnName}), 0) as avg_{columnName}";
                            rs = true;
                            break;

                        case "COUNT":
                            aggregation = $"COUNT({columnName}) as count_{columnName}";
                            rs = true;
                            break;

                        case "MAX":
                            aggregation = $"ISNULL (Max({columnName}), 0) as max_{columnName}";
                            rs = true;
                            break;

                        case "MIN":
                            aggregation = $"ISNULL (MIN({columnName}), 0) as min_{columnName}";
                            rs = true;
                            break;

                        case "SUM":
                            aggregation = $"SUM({columnName}) as sum_{columnName}";
                            rs = true;
                            break;

                        default:
                            aggregation = $"{columnName}";
                            rs = false;
                            break;
                    }
                }
            }
            return rs;
        }

        private string ToDataType(string dataType, string value)
        {
            string rs = string.Empty;
            if (dataType.Contains("char"))
                rs = $"'{value}'";
            else if (dataType.Contains("int"))
                rs = $"{value}";
            else if (dataType.Contains("bit"))
            {
                if (value == "1" || value.Contains("true"))
                    rs = "1";
                else if (value == "0" || value.Contains("false"))
                    rs = "0";
            }
            else if (dataType.Contains("float"))
                rs = $"{value}";
            else if (dataType.Contains("money"))
                rs = $"{value}";
            else if (dataType.Contains("date"))
                rs = $"'{value}'";

            return rs;
        }

        public string GetColumnDefinition(string dataType, int? maxLength, byte? numericPrecision, int? numericScale, bool isNullable)
        {
            string nullableString = isNullable ? "NULL" : "NOT NULL";
            string rs = string.Empty;
            switch (dataType.ToLower())
            {
                case "nvarchar":
                    if (maxLength == -1)
                        rs = $"{dataType}({"max"}) {nullableString}";
                    else
                        rs = $"{dataType}({maxLength}) {nullableString}";
                    break;

                case "varchar":
                    if (maxLength == -1)
                        rs = $"{dataType}({"max"}) {nullableString}";
                    else
                        rs = $"{dataType}({maxLength}) {nullableString}";
                    break;

                case "nchar":
                    rs = $"{dataType}({maxLength}) {nullableString}";
                    break;

                case "char":
                    rs = $"{dataType}({maxLength}) {nullableString}";
                    break;

                case "decimal":
                    if (numericPrecision.HasValue && numericScale.HasValue)
                        rs = $"{dataType}({numericPrecision}, {numericScale}) {nullableString}";
                    break;

                default:
                    rs = $"{dataType} {nullableString}";
                    break;
            }
            return rs;
            //if (dataType.Equals("nvarchar", StringComparison.OrdinalIgnoreCase) && maxLength.HasValue)
            //{
            //    if (maxLength == -1)
            //        return $"{dataType}({"max"}) {nullableString}";
            //    else
            //        return $"{dataType}({maxLength}) {nullableString}";
            //}
            //else if (dataType.Equals("char", StringComparison.OrdinalIgnoreCase) && maxLength.HasValue)
            //{
            //    return $"{dataType}({maxLength}) {nullableString}";
            //}
            //else if (dataType.Equals("decimal", StringComparison.OrdinalIgnoreCase) && numericPrecision.HasValue && numericScale.HasValue)
            //{
            //    return $"{dataType.ToLower()}({numericPrecision}, {numericScale}) {nullableString}";
            //}
            //else
            //{
            //    return $"{dataType.ToLower()} {nullableString}";
            //}
        }

        public string GetColumnDefinition(string dataType, int? maxLength, byte? numericPrecision, int? numericScale)
        {
            string rs = string.Empty;
            switch (dataType.ToLower())
            {
                case "nvarchar":
                    if (maxLength == -1)
                        rs = $"{dataType}({"max"})";
                    else
                        rs = $"{dataType}({maxLength})";
                    break;

                case "varchar":
                    if (maxLength == -1)
                        rs = $"{dataType}({"max"})";
                    else
                        rs = $"{dataType}({maxLength})";
                    break;

                case "nchar":
                    rs = $"{dataType}({maxLength})";
                    break;

                case "char":
                    rs = $"{dataType}({maxLength})";
                    break;

                case "decimal":
                    if (numericPrecision.HasValue & numericScale.HasValue)
                        rs = $"{dataType}({numericPrecision}, {numericScale})";
                    break;

                default:
                    rs = $"{dataType}";
                    break;
            }
            return rs;
        }

        private static string getDataTypeCSharp(string typeName)
        {
            string rs = "";
            switch (typeName)
            {
                case "nvarchar":
                    rs = "string";
                    break;

                case "varchar":
                    rs = "string";
                    break;

                case "ntext":
                    rs = "string";
                    break;

                case "text":
                    rs = "string";
                    break;

                case "nchar":
                    rs = "string";
                    break;

                case "char":
                    rs = "string";
                    break;

                case "float":
                    rs = "double";
                    break;

                case "money":
                    rs = "double";
                    break;

                case "decimal":
                    rs = "double";
                    break;

                case "smallmoney":
                    rs = "double";
                    break;

                case "int":
                    rs = "int";
                    break;

                case "numeric":
                    rs = "int";
                    break;

                case "bit":
                    rs = "bool";
                    break;

                case "image":
                    rs = "byte[]";
                    break;

                case "datetime":
                    rs = "DateTime";
                    break;

                case "date":
                    rs = "DateTime";
                    break;

                case "smallint":
                    rs = "uint";
                    break;

                case "bigint":
                    rs = "long";
                    break;
            }
            return rs;
        }

        private static string getDataTypeSQL(string typeName)
        {
            string rs = "";
            switch (typeName)
            {
                case "nvarchar":
                    rs = "NVarChar";
                    break;

                case "varchar":
                    rs = "VarChar";
                    break;

                case "ntext":
                    rs = "NText";
                    break;

                case "text":
                    rs = "Text";
                    break;

                case "nchar":
                    rs = "NChar";
                    break;

                case "char":
                    rs = "Char";
                    break;

                case "float":
                    rs = "Float";
                    break;

                case "money":
                    rs = "Money";
                    break;

                case "decimal":
                    rs = "double";
                    break;

                case "smallmoney":
                    rs = "SmallMoney";
                    break;

                case "int":
                    rs = "Int";
                    break;

                case "smallint":
                    rs = "SmallInt";
                    break;

                case "numeric":
                    rs = "Decimal";
                    break;

                case "bit":
                    rs = "Bit";
                    break;

                case "image":
                    rs = "Image";
                    break;

                case "datetime":
                    rs = "DateTime";
                    break;

                case "date":
                    rs = "Date";
                    break;

                case "bigint":
                    rs = "BigInt";
                    break;
            }
            return rs;
        }

        public static int countSelectedWithoutIdentity(DataGridView grid)
        {
            int count = 0;

            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (System.Convert.ToBoolean(grid.Rows[i].Cells["colSelected"].Value) == true && System.Convert.ToBoolean(grid.Rows[i].Cells["colIdentity"].Value) == false)
                    count++;
            }

            return count;
        }

        public static int countSelectedOrWhere(DataGridView grid)
        {
            int count = 0;

            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (System.Convert.ToBoolean(grid.Rows[i].Cells["colSelected"].Value) == true || System.Convert.ToBoolean(grid.Rows[i].Cells["colWhere"].Value) == true)
                    count++;
            }

            return count;
        }

        public static int countSWC(DataGridView grid)
        {
            int count = 0;

            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(grid.Rows[i].Cells["colSelected"].Value) == true || Convert.ToBoolean(grid.Rows[i].Cells["colWhere"].Value) == true || Convert.ToBoolean(grid.Rows[i].Cells["colCheckReccord"].Value) == true)
                    count++;
            }

            return count;
        }

        private static bool isIdentityExist(DataGridView grid)
        {
            bool rs = false;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (System.Convert.ToBoolean(grid.Rows[i].Cells["colSelected"].Value) == true && System.Convert.ToBoolean(grid.Rows[i].Cells["colIdentity"].Value) == true)
                {
                    rs = true;
                }
            }
            return rs;
        }

        private static string getToolsBoxName(DataGridView grid, string field)
        {
            string rs = string.Empty;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].Cells["colColumnName"].Value.ToString() == field)
                {
                    if (grid.Rows[i].Cells["colToolbox"].Value != null)
                    {
                        var r = grid.Rows[i].Cells["colToolBox"].Value.ToString();
                        rs = r;
                    }
                    else
                        rs = string.Empty;
                    //rs = (string)grid.Rows[i].Cells["colToolBox"].Value;
                }
            }

            return rs;
        }

        private static string getToolsBoxNamespace(string nameToolbox)
        {
            var config = HConfigs.LoadConfiguration();
            var rs = config.Toolboxs;
            string r = "";
            if (rs != null)
                r = rs.Find(x => x.NameToolbox == nameToolbox).Namespace;

            return r;
        }

        private static string getToolBoxValue(string nameToolbox)
        {
            var config = HConfigs.LoadConfiguration();
            var rs = config.Toolboxs.FirstOrDefault(x => x.NameToolbox.Equals(nameToolbox));
            return rs.Value;
        }

        private static string getControlName(DataGridView grid, string field)
        {
            var rs = string.Empty;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].Cells["colColumnName"].Value.ToString() == field)
                {
                    if (grid.Rows[i].Cells["colControlName"].Value != null)
                        rs = grid.Rows[i].Cells["colControlName"].Value.ToString();
                    else
                        rs = string.Empty;
                    break;
                }
            }

            return rs;
        }

        private static string getControlText(DataGridView grid, string field)
        {
            var rs = string.Empty;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].Cells["colColumnName"].Value.ToString() == field)
                {
                    rs = (string)grid.Rows[i].Cells["colControlText"].Value;
                    break;
                }
            }

            return rs;
        }

        #endregion Codes

        #region CRUD

        public string Insert(DataGridView grid, string table, string modeProcedure, out string message)
        {
            try
            {
                script = new StringBuilder();
                message = string.Empty;
                connection = new SqlConnection(conString);
                statusConnection();
                // Retrieve schema information for the specified table
                string schemaQuery = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' ORDER BY ORDINAL_POSITION";

                script.AppendLine($"//{Tools.Tools.Insert('=', 30)} Create Function [Insert_{table}] {Tools.Tools.Insert('=', 30)}");
                script.Append($"{Tools.Tools.InsertTabs(0)}{modeProcedure} bool Insert_{table}(");

                int count = countSelected(grid);

                int i = 0;
                bool img = false;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    bool rsF = isFieldIdentity(grid, $"{row.Cells["colColumnName"].Value}");

                    if (System.Convert.ToBoolean(row.Cells["colSelected"].Value) == true && rsF != true)
                    {
                        script.Append($"{getDataTypeCSharp(row.Cells["colDataType"].Value.ToString())} ");
                        script.Append($"{row.Cells["colColumnName"].Value}");
                        if (i < count - 1)
                            script.Append($", ");
                    }
                    i++;
                }
                if (isImageExist(grid))
                {
                    script.Append($", string ImageState");
                    img = true;
                }
                script.AppendLine($")");
                script.AppendLine($"{Tools.Tools.InsertTabs(0)}{{");

                //start function
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}bool rs = false;");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}try");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}{{");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}OpenConnection();");

                int rsI = countSelectedWithoutIdentity(grid);

                if (img)
                    script.AppendLine($"{Tools.Tools.InsertTabs(2)}parameter = new SqlParameter[{ rsI + 1}];");
                else
                    script.AppendLine($"{Tools.Tools.InsertTabs(2)}parameter = new SqlParameter[{ rsI }];");

                //string schemaQuery1 = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' ORDER BY ORDINAL_POSITION";

                //Get parametres
                int x = 0;

                //statusCommand();
                command = new SqlCommand(schemaQuery, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();
                    string dataType = reader["DATA_TYPE"].ToString();
                    int? maxLength = reader["CHARACTER_MAXIMUM_LENGTH"] as int?;
                    byte? numericPrecision = reader["NUMERIC_PRECISION"] as byte?;
                    int? numericScale = reader["NUMERIC_SCALE"] as int?;
                    bool rs = isFieldSelected(grid, columnName);
                    bool rs2 = isFieldIdentity(grid, columnName);
                    if (rs == true && rs2 != true)
                    {
                        script.Append($"{Tools.Tools.InsertTabs(2)}parameter[{x}] = new SqlParameter(\"@{columnName}\", SqlDbType.{getDataTypeSQL(dataType)}");

                        if (dataType.ToUpper().Contains("CHAR"))
                            script.Append($", {maxLength}");

                        script.AppendLine($");");

                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}parameter[{x}].Value = {columnName};");
                    }

                    if (!rs2)
                        x++;
                }
                bool rs1 = isImageExist(grid);
                if (rs1)
                {
                    script.AppendLine($"{Tools.Tools.InsertTabs(2)}parameter[{x}] = new SqlParameter(\"@ImageSate\", SqlDbType.NVarChar, 50); //yes_image, no_image");
                    script.AppendLine($"{Tools.Tools.InsertTabs(2)}parameter[{x}].Value = ImageState;");
                    script.AppendLine();
                }
                script.AppendLine();
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}command = new SqlCommand();");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}command.CommandType = CommandType.StoredProcedure;");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}command.CommandText = \"Insert_{table}\";");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}command.Connection = connection;");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}command.Parameters.AddRange(parameter);");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}command.ExecuteNonQuery();");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}CloseConnection();");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}rs = true;");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}catch(Exception ex)");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "{");
                script.AppendLine(Tools.Tools.InsertTabs(2) + "MessageBox.Show(ex.Message, \"Error\", MessageBoxButtons.OK, MessageBoxIcon.Error);");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"CloseConnection();");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}rs = false;");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "return rs;");
                script.Append(Tools.Tools.InsertTabs(0) + "}");
                //
                statusCommand();
                statusConnection();
                state = true;
            }
            catch (Exception ex)
            {
                message = "An error occurred: " + ex.Message;
                state = false;
            }

            return script.ToString();
        }

        public string Update(DataGridView grid, string table, string modeProcedure, out string message)
        {
            try
            {
                script = new StringBuilder();
                message = string.Empty;
                connection = new SqlConnection(conString);
                statusConnection();
                // Retrieve schema information for the specified table
                string schemaQuery = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' ORDER BY ORDINAL_POSITION";

                script.AppendLine($"//{Tools.Tools.Insert('=', 30)} Create Function [Update_{table}] {Tools.Tools.Insert('=', 30)}");
                script.Append($"{Tools.Tools.InsertTabs(0)}{modeProcedure} bool Update_{table}(");

                int count = countSWC(grid);

                int i = 0;
                bool img = false;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    bool rsF = isFieldSWC(grid, $"{row.Cells["colColumnName"].Value}");

                    if (rsF == true)
                    {
                        script.Append($"{getDataTypeCSharp(row.Cells["colDataType"].Value.ToString())} ");
                        script.Append($"{row.Cells["colColumnName"].Value}");
                        if (i < count - 1)
                            script.Append($", ");
                        i++;
                    }
                }
                if (isImageExist(grid))
                {
                    script.Append($", string ImageState");
                    img = true;
                }
                script.AppendLine($")");
                script.AppendLine($"{Tools.Tools.InsertTabs(0)}{{");

                //start function
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}bool rs = false;");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}try");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}{{");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}OpenConnection();");

                //int rsI = countSelectedWithoutIdentity(grid);

                if (img)
                    script.AppendLine($"{Tools.Tools.InsertTabs(2)}parameter = new SqlParameter[{ count + 1}];");
                else
                    script.AppendLine($"{Tools.Tools.InsertTabs(2)}parameter = new SqlParameter[{ count }];");

                //string schemaQuery1 = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' ORDER BY ORDINAL_POSITION";

                //Get parametres
                int x = 0;

                //statusCommand();
                command = new SqlCommand(schemaQuery, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();
                    string dataType = reader["DATA_TYPE"].ToString();
                    int? maxLength = reader["CHARACTER_MAXIMUM_LENGTH"] as int?;
                    byte? numericPrecision = reader["NUMERIC_PRECISION"] as byte?;
                    int? numericScale = reader["NUMERIC_SCALE"] as int?;
                    bool rs = isFieldSWC(grid, columnName);
                    //bool rs2 = isFieldIdentity(grid, columnName);
                    if (rs == true /*&& rs2 != true*/)
                    {
                        script.Append($"{Tools.Tools.InsertTabs(2)}parameter[{x}] = new SqlParameter(\"@{columnName}\", SqlDbType.{getDataTypeSQL(dataType)}");

                        if (dataType.ToUpper().Contains("CHAR"))
                            script.Append($", {maxLength}");

                        script.AppendLine($");");

                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}parameter[{x}].Value = {columnName};");
                        x++;
                    }

                    //if (!rs2)
                }
                bool rs1 = isImageExist(grid);
                if (rs1)
                {
                    script.AppendLine($"{Tools.Tools.InsertTabs(2)}parameter[{x}] = new SqlParameter(\"@ImageSate\", SqlDbType.NVarChar, 50); //yes_image, no_image");
                    script.AppendLine($"{Tools.Tools.InsertTabs(2)}parameter[{x}].Value = ImageState;");
                    script.AppendLine();
                }
                script.AppendLine();
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}command = new SqlCommand();");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}command.CommandType = CommandType.StoredProcedure;");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}command.CommandText = \"Update_{table}\";");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}command.Connection = connection;");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}command.Parameters.AddRange(parameter);");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}command.ExecuteNonQuery();");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}CloseConnection();");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}rs = true;");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}catch(Exception ex)");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "{");
                script.AppendLine(Tools.Tools.InsertTabs(2) + "MessageBox.Show(ex.Message, \"Error\", MessageBoxButtons.OK, MessageBoxIcon.Error);");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"CloseConnection();");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}rs = false;");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "return rs;");
                script.Append(Tools.Tools.InsertTabs(0) + "}");
                //
                statusCommand();
                statusConnection();
                state = true;
            }
            catch (Exception ex)
            {
                message = "An error occurred: " + ex.Message;
                state = false;
            }

            return script.ToString();
        }

        public string Delete(DataGridView grid, string table, string modeProcedure, out string message)
        {
            try
            {
                script = new StringBuilder();
                message = string.Empty;
                connection = new SqlConnection(conString);
                statusConnection();
                // Retrieve schema information for the specified table
                string schemaQuery = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' ORDER BY ORDINAL_POSITION";

                script.AppendLine($"//{Tools.Tools.Insert('=', 30)} Create Function [Delete_{table}] {Tools.Tools.Insert('=', 30)}");
                script.Append($"{Tools.Tools.InsertTabs(0)}{modeProcedure} bool Delete_{table}(");

                int count = countWhere(grid);

                int i = 0;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    bool rsF = isFieldWhere(grid, $"{row.Cells["colColumnName"].Value}");

                    if (rsF == true)
                    {
                        script.Append($"{getDataTypeCSharp(row.Cells["colDataType"].Value.ToString())} ");
                        script.Append($"{row.Cells["colColumnName"].Value}");
                        if (i < count - 1)
                            script.Append($", ");
                        i++;
                    }
                }

                script.AppendLine($")");
                script.AppendLine($"{Tools.Tools.InsertTabs(0)}{{");

                //start function
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}bool rs = false;");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}try");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}{{");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}OpenConnection();");

                script.AppendLine($"{Tools.Tools.InsertTabs(2)}parameter = new SqlParameter[{ count }];");

                //Get parametres
                int x = 0;

                //statusCommand();
                command = new SqlCommand(schemaQuery, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();
                    string dataType = reader["DATA_TYPE"].ToString();
                    int? maxLength = reader["CHARACTER_MAXIMUM_LENGTH"] as int?;
                    byte? numericPrecision = reader["NUMERIC_PRECISION"] as byte?;
                    int? numericScale = reader["NUMERIC_SCALE"] as int?;
                    bool rs = isFieldWhere(grid, columnName);
                    if (rs == true)
                    {
                        script.Append($"{Tools.Tools.InsertTabs(2)}parameter[{x}] = new SqlParameter(\"@{columnName}\", SqlDbType.{getDataTypeSQL(dataType)}");

                        if (dataType.ToUpper().Contains("CHAR"))
                            script.Append($", {maxLength}");

                        script.AppendLine($");");

                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}parameter[{x}].Value = {columnName};");
                        x++;
                    }
                }

                script.AppendLine();
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}command = new SqlCommand();");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}command.CommandType = CommandType.StoredProcedure;");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}command.CommandText = \"Delete_{table}\";");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}command.Connection = connection;");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}command.Parameters.AddRange(parameter);");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}command.ExecuteNonQuery();");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}CloseConnection();");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}rs = true;");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}catch(Exception ex)");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "{");
                script.AppendLine(Tools.Tools.InsertTabs(2) + "MessageBox.Show(ex.Message, \"Error\", MessageBoxButtons.OK, MessageBoxIcon.Error);");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"CloseConnection();");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}rs = false;");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "return rs;");
                script.Append(Tools.Tools.InsertTabs(0) + "}");
                //
                statusCommand();
                statusConnection();
                state = true;
            }
            catch (Exception ex)
            {
                message = "An error occurred: " + ex.Message;
                state = false;
            }

            return script.ToString();
        }

        public string Select(DataGridView grid, string table, string modeProcedure, out string message)
        {
            try
            {
                script = new StringBuilder();
                message = string.Empty;

                script.AppendLine($"//{Tools.Tools.Insert('=', 30)} Create Function [Select_{table}] {Tools.Tools.Insert('=', 30)}");
                script.AppendLine($"{Tools.Tools.InsertTabs(0)}{modeProcedure} DataTable Select_{table}()");
                script.AppendLine($"{Tools.Tools.InsertTabs(0)}{{");

                //start function
                script.AppendLine(Tools.Tools.InsertTabs(1) + $"try");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "{");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"dt = new DataTable();");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"OpenConnection();");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"command = new SqlCommand();");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.CommandType = CommandType.StoredProcedure;");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.CommandText = \"Select_{table}\";");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.Connection = connection;");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"adapter = new SqlDataAdapter(command);");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"adapter.Fill(dt);");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"CloseConnection();");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                script.AppendLine(Tools.Tools.InsertTabs(1) + $"catch");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "{");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"dt = new DataTable();");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"CloseConnection();");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "return dt;");
                script.Append(Tools.Tools.InsertTabs(0) + "}");
                //

                state = true;
            }
            catch (Exception ex)
            {
                message = "An error occurred: " + ex.Message;
                state = false;
            }

            return script.ToString();
        }

        #endregion CRUD

        #region Aggregation

        public string AVG(DataGridView grid, string table, string modeProcedure, out string message)
        {
            message = string.Empty;
            StringBuilder script = new StringBuilder();
            try
            {
                script.AppendLine($"//{Tools.Tools.Insert('=', 30)} Create Function [Avg_{table}] {Tools.Tools.Insert('=', 30)}");

                int count = countSelected(grid);

                if (count > 1)
                    script.AppendLine($"{Tools.Tools.InsertTabs(0)}{modeProcedure} DataTable Avg_{table}()");
                else
                    script.AppendLine($"{Tools.Tools.InsertTabs(0)}{modeProcedure} string Avg_{table}()");

                script.AppendLine($"{Tools.Tools.InsertTabs(0)}{{");

                //start function
                if (count > 1)
                {
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"try");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "{");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"dt = new DataTable();");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"OpenConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"command = new SqlCommand();");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.CommandType = CommandType.StoredProcedure;");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.CommandText = \"AVG_{table}\";");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.Connection = connection;");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"adapter = new SqlDataAdapter(command);");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"adapter.Fill(dt);");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"CloseConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"catch");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "{");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"dt = new DataTable();");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"CloseConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "return dt;");
                    script.Append(Tools.Tools.InsertTabs(0) + "}");
                }
                else
                {
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"OpenConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"command = new SqlCommand();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"command.CommandType = CommandType.StoredProcedure;");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"command.CommandText = \"AVG_{table}\";");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"command.Connection = connection;");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"string avgValue = (string)command.ExecuteScalar();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"CloseConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "return avgValue;");
                    script.Append(Tools.Tools.InsertTabs(0) + "}");
                }

                state = true;
            }
            catch (Exception ex)
            {
                message = "An error occurred: " + ex.Message;
                state = false;
            }

            return script.ToString();
        }

        public string MAX(DataGridView grid, string table, string modeProcedure, out string message)
        {
            message = string.Empty;
            StringBuilder script = new StringBuilder();
            try
            {
                script.AppendLine($"//{Tools.Tools.Insert('=', 30)} Create Function [Max_{table}] {Tools.Tools.Insert('=', 30)}");

                int count = countSelected(grid);

                if (count > 1)
                    script.AppendLine($"{Tools.Tools.InsertTabs(0)}{modeProcedure} DataTable Max_{table}()");
                else
                    script.AppendLine($"{Tools.Tools.InsertTabs(0)}{modeProcedure} string Max_{table}()");

                script.AppendLine($"{Tools.Tools.InsertTabs(0)}{{");

                //start function
                if (count > 1)
                {
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"try");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "{");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"dt = new DataTable();");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"OpenConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"command = new SqlCommand();");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.CommandType = CommandType.StoredProcedure;");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.CommandText = \"MAX_{table}\";");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.Connection = connection;");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"adapter = new SqlDataAdapter(command);");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"adapter.Fill(dt);");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"CloseConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"catch");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "{");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"dt = new DataTable();");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"CloseConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "return dt;");
                    script.Append(Tools.Tools.InsertTabs(0) + "}");
                }
                else
                {
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"OpenConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"command = new SqlCommand();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"command.CommandType = CommandType.StoredProcedure;");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"command.CommandText = \"MAX_{table}\";");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"command.Connection = connection;");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"string avgValue = (string)command.ExecuteScalar();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"CloseConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "return avgValue;");
                    script.Append(Tools.Tools.InsertTabs(0) + "}");
                }

                state = true;
            }
            catch (Exception ex)
            {
                message = "An error occurred: " + ex.Message;
                state = false;
            }

            return script.ToString();
        }

        public string MIN(DataGridView grid, string table, string modeProcedure, out string message)
        {
            message = string.Empty;
            StringBuilder script = new StringBuilder();
            try
            {
                script.AppendLine($"//{Tools.Tools.Insert('=', 30)} Create Function [Min_{table}] {Tools.Tools.Insert('=', 30)}");

                int count = countSelected(grid);

                if (count > 1)
                    script.AppendLine($"{Tools.Tools.InsertTabs(0)}{modeProcedure} DataTable Min_{table}()");
                else
                    script.AppendLine($"{Tools.Tools.InsertTabs(0)}{modeProcedure} string Min_{table}()");

                script.AppendLine($"{Tools.Tools.InsertTabs(0)}{{");

                //start function
                if (count > 1)
                {
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"try");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "{");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"dt = new DataTable();");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"OpenConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"command = new SqlCommand();");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.CommandType = CommandType.StoredProcedure;");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.CommandText = \"MIN_{table}\";");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.Connection = connection;");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"adapter = new SqlDataAdapter(command);");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"adapter.Fill(dt);");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"CloseConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"catch");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "{");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"dt = new DataTable();");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"CloseConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "return dt;");
                    script.Append(Tools.Tools.InsertTabs(0) + "}");
                }
                else
                {
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"OpenConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"command = new SqlCommand();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"command.CommandType = CommandType.StoredProcedure;");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"command.CommandText = \"MIN_{table}\";");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"command.Connection = connection;");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"string avgValue = (string)command.ExecuteScalar();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"CloseConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "return avgValue;");
                    script.Append(Tools.Tools.InsertTabs(0) + "}");
                }

                state = true;
            }
            catch (Exception ex)
            {
                message = "An error occurred: " + ex.Message;
                state = false;
            }

            return script.ToString();
        }

        public string COUNT(DataGridView grid, string table, string modeProcedure, out string message)
        {
            message = string.Empty;
            StringBuilder script = new StringBuilder();
            try
            {
                script.AppendLine($"//{Tools.Tools.Insert('=', 30)} Create Function [Count_{table}] {Tools.Tools.Insert('=', 30)}");

                int count = countSelected(grid);

                if (count > 1)
                    script.AppendLine($"{Tools.Tools.InsertTabs(0)}{modeProcedure} DataTable Count_{table}()");
                else
                    script.AppendLine($"{Tools.Tools.InsertTabs(0)}{modeProcedure} string Count_{table}()");

                script.AppendLine($"{Tools.Tools.InsertTabs(0)}{{");

                //start function
                if (count > 1)
                {
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"try");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "{");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"dt = new DataTable();");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"OpenConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"command = new SqlCommand();");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.CommandType = CommandType.StoredProcedure;");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.CommandText = \"COUNT_{table}\";");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.Connection = connection;");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"adapter = new SqlDataAdapter(command);");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"adapter.Fill(dt);");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"CloseConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"catch");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "{");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"dt = new DataTable();");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"CloseConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "return dt;");
                    script.Append(Tools.Tools.InsertTabs(0) + "}");
                }
                else
                {
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"OpenConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"command = new SqlCommand();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"command.CommandType = CommandType.StoredProcedure;");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"command.CommandText = \"COUNT_{table}\";");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"command.Connection = connection;");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"string avgValue = (string)command.ExecuteScalar();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"CloseConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "return avgValue;");
                    script.Append(Tools.Tools.InsertTabs(0) + "}");
                }

                state = true;
            }
            catch (Exception ex)
            {
                message = "An error occurred: " + ex.Message;
                state = false;
            }

            return script.ToString();
        }

        public string SUM(DataGridView grid, string table, string modeProcedure, out string message)
        {
            message = string.Empty;
            StringBuilder script = new StringBuilder();
            try
            {
                script.AppendLine($"//{Tools.Tools.Insert('=', 30)} Create Function [Sum_{table}] {Tools.Tools.Insert('=', 30)}");

                int count = countSelected(grid);

                if (count > 1)
                    script.AppendLine($"{Tools.Tools.InsertTabs(0)}{modeProcedure} DataTable Sum_{table}()");
                else
                    script.AppendLine($"{Tools.Tools.InsertTabs(0)}{modeProcedure} string Sum_{table}()");

                script.AppendLine($"{Tools.Tools.InsertTabs(0)}{{");

                //start function
                if (count > 1)
                {
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"try");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "{");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"dt = new DataTable();");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"OpenConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"command = new SqlCommand();");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.CommandType = CommandType.StoredProcedure;");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.CommandText = \"SUM_{table}\";");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.Connection = connection;");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"adapter = new SqlDataAdapter(command);");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"adapter.Fill(dt);");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"CloseConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"catch");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "{");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"dt = new DataTable();");
                    script.AppendLine(Tools.Tools.InsertTabs(2) + $"CloseConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "return dt;");
                    script.Append(Tools.Tools.InsertTabs(0) + "}");
                }
                else
                {
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"OpenConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"command = new SqlCommand();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"command.CommandType = CommandType.StoredProcedure;");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"command.CommandText = \"SUM_{table}\";");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"command.Connection = connection;");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"string avgValue = (string)command.ExecuteScalar();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + $"CloseConnection();");
                    script.AppendLine(Tools.Tools.InsertTabs(1) + "return avgValue;");
                    script.Append(Tools.Tools.InsertTabs(0) + "}");
                }

                state = true;
            }
            catch (Exception ex)
            {
                message = "An error occurred: " + ex.Message;
                state = false;
            }

            return script.ToString();
        }

        #endregion Aggregation

        #region Search

        public string Search(DataGridView grid, string table, string modeProcedure, out string message)
        {
            message = string.Empty;
            StringBuilder script = new StringBuilder();
            try
            {
                script.AppendLine($"//{Tools.Tools.Insert('=', 30)} Create Function [Search_{table}] {Tools.Tools.Insert('=', 30)}");

                script.AppendLine(Tools.Tools.InsertTabs(0) + $"{modeProcedure} DataTable Search_{table}(string Search)");
                script.AppendLine(Tools.Tools.InsertTabs(0) + "{");

                //start function
                script.AppendLine(Tools.Tools.InsertTabs(1) + $"try");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "{");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"OpenConnection();");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"parameter = new SqlParameter[1];");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"parameter[0] = new SqlParameter(\"@Search\", SqlDbType.NVarChar, -1);");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"parameter[0].Value = Search;");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"dt = new DataTable();");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"command = new SqlCommand();");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.CommandType = CommandType.StoredProcedure;");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.CommandText = \"Search_{table}\";");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.Connection = connection;");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"adapter = new SqlDataAdapter(command);");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"adapter.Fill(dt);");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"CloseConnection();");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                script.AppendLine(Tools.Tools.InsertTabs(1) + $"catch");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "{");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"dt = new DataTable();");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"CloseConnection();");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "return dt;");
                script.Append(Tools.Tools.InsertTabs(0) + "}");
                state = true;
            }
            catch (Exception ex)
            {
                message = "An error occurred: " + ex.Message;
                state = false;
            }
            return script.ToString();
        }

        public string SearchAll(DataGridView grid, string table, string modeProcedure, out string message)
        {
            message = string.Empty;
            script = new StringBuilder();
            try
            {
                script.AppendLine($"//{Tools.Tools.Insert('=', 30)} Create Function [Search_{table}] {Tools.Tools.Insert('=', 30)}");

                script.AppendLine(Tools.Tools.InsertTabs(0) + $"{modeProcedure} DataTable Search_{table}(string Search)");
                script.AppendLine(Tools.Tools.InsertTabs(0) + "{");

                //start function
                script.AppendLine(Tools.Tools.InsertTabs(1) + $"try");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "{");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"OpenConnection();");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"parameter = new SqlParameter[1];");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"parameter[0] = new SqlParameter(\"@Search\", SqlDbType.NVarChar, -1);");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"parameter[0].Value = Search;");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"dt = new DataTable();");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"command = new SqlCommand();");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.CommandType = CommandType.StoredProcedure;");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.CommandText = \"Search_{table}\";");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.Connection = connection;");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"adapter = new SqlDataAdapter(command);");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"adapter.Fill(dt);");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"CloseConnection();");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                script.AppendLine(Tools.Tools.InsertTabs(1) + $"catch");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "{");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"dt = new DataTable();");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"CloseConnection();");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "return dt;");
                script.Append(Tools.Tools.InsertTabs(0) + "}");
                state = true;
            }
            catch (Exception ex)
            {
                message = "An error occurred: " + ex.Message;
                state = false;
            }
            return script.ToString();
        }

        public string SearchBetweenDate(DataGridView grid, string table, string modeProcedure, out string message)
        {
            message = string.Empty;
            StringBuilder script = new StringBuilder();
            string schemaQuery = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' ORDER BY ORDINAL_POSITION";

            try
            {
                connection = new SqlConnection(conString);
                statusConnection();

                script.AppendLine($"//{Tools.Tools.Insert('=', 30)} Create Function [Search_{table}] {Tools.Tools.Insert('=', 30)}");
                script.Append(Tools.Tools.InsertTabs(0) + $"{modeProcedure} DataTable Search_{table}(");

                int c = 0;
                command = new SqlCommand(schemaQuery, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();

                    bool rs = isFieldDateExist(grid, columnName);
                    if (rs)
                    {
                        script.Append($"DateTime @FirstDate_{columnName}, ");
                        script.Append($"DateTime @LastDate_{columnName}");
                        if (c < countDate(grid) - 1)
                            script.Append(", ");
                        //else
                        //    script.AppendLine("");
                        c++;
                    }
                }
                script.AppendLine(")");

                script.AppendLine(Tools.Tools.InsertTabs(0) + "{");

                //start function
                script.AppendLine(Tools.Tools.InsertTabs(1) + $"try");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "{");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"OpenConnection();");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"parameter = new SqlParameter[{countDate(grid) * 2}];");

                int x = 0;

                statusCommand();
                command = new SqlCommand(schemaQuery, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();
                    string dataType = reader["DATA_TYPE"].ToString();
                    ///////////
                    bool rs = isFieldDateExist(grid, columnName);
                    if (rs)
                    {
                        script.AppendLine(Tools.Tools.InsertTabs(2) + $"parameter[{x}] = new SqlParameter(\"@FirstDate_{columnName}\", SqlDbType.{getDataTypeSQL(dataType)});");
                        script.AppendLine(Tools.Tools.InsertTabs(2) + $"parameter[{x}].Value = FirstDate_{columnName};");
                        x++;
                        script.AppendLine(Tools.Tools.InsertTabs(2) + $"parameter[{x}] = new SqlParameter(\"@LastDate_{columnName}\", SqlDbType.{getDataTypeSQL(dataType)});");
                        script.AppendLine(Tools.Tools.InsertTabs(2) + $"parameter[{x}].Value = LastDate_{columnName};");
                        x++;
                    }
                }

                script.AppendLine(Tools.Tools.InsertTabs(2) + $"dt = new DataTable();");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"command = new SqlCommand();");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.CommandType = CommandType.StoredProcedure;");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.CommandText = \"Search_{table}\";");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"command.Connection = connection;");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"adapter = new SqlDataAdapter(command);");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"adapter.Fill(dt);");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"CloseConnection();");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                script.AppendLine(Tools.Tools.InsertTabs(1) + $"catch");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "{");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"dt = new DataTable();");
                script.AppendLine(Tools.Tools.InsertTabs(2) + $"CloseConnection();");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "}");
                script.AppendLine(Tools.Tools.InsertTabs(1) + "return dt;");
                script.Append(Tools.Tools.InsertTabs(0) + "}");

                state = true;
            }
            catch (Exception ex)
            {
                message = "An error occurred: " + ex.Message;
                state = false;
            }
            return script.ToString();
        }

        #endregion Search

        #region Controls

        public List<cColumns> CustomColumnsInGrid(DataGridView grid)
        {
            List<cColumns> columns = new List<cColumns>();
            try
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    string field = $"{row.Cells["colColumnName"].Value}";
                    bool isSelected = isFieldSelected(grid, field);
                    if (isSelected == true)
                    {
                        columns.Add(new cColumns
                        {
                            Column = field,
                            ColumnName = $"col{field}",
                            Visible = true,
                            ReadOnly = false,
                            ColumnType = "DataGridViewTextBoxColumn",
                            AutoSizeMode = "NotSet",
                            DataPropertyName = field,
                            HeaderText = field
                        });
                    }
                }
            }
            catch
            {
                columns = new List<cColumns>();
            }
            return columns;
        }

        public string CreateControls(DataGridView grid, out string message)
        {
            //try
            //{
            script = new StringBuilder();
            message = string.Empty;

            int x = 1;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                string columnName = grid.Rows[i].Cells["colColumnName"].Value.ToString();
                bool rs = isFieldSelected(grid, columnName);
                bool rs2 = isFieldIdentity(grid, columnName);

                if (rs == true && rs2 == false)
                {
                    //string toolbox = grid.Rows[i].Cells["colToolBox"].Value.ToString();

                    string toolsBoxName = getToolsBoxName(grid, columnName);
                    string nspace = getToolsBoxNamespace(toolsBoxName);
                    string controlName = getControlName(grid, columnName);

                    script.AppendLine($"private System.Windows.Forms.Label label{x};");
                    script.AppendLine($"private {nspace}.{toolsBoxName} {controlName};");
                    x++;
                }
            }

            script.AppendLine();
            script.AppendLine($"//{Tools.Tools.Insert('*', 51)}");
            script.AppendLine($"//{Tools.Tools.Insert('*', 15)} InitializeComponent {Tools.Tools.Insert('*', 15)}");

            x = 1;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                string columnName = grid.Rows[i].Cells["colColumnName"].Value.ToString();
                bool rs = isFieldSelected(grid, columnName);
                if (rs == true && !isFieldIdentity(grid, columnName))
                {
                    string toolsBoxName = getToolsBoxName(grid, columnName);
                    string nspace = getToolsBoxNamespace(toolsBoxName);
                    string controlName = getControlName(grid, columnName);

                    script.AppendLine($"this.label{x} = new System.Windows.Forms.Label();");
                    script.AppendLine($"this.{controlName} = new {nspace}.{toolsBoxName}();");
                    x++;
                }
            }

            script.AppendLine();
            script.AppendLine($"//{Tools.Tools.Insert('*', 51)}");
            script.AppendLine($"//{Tools.Tools.Insert('*', 18)} SuspendLayout {Tools.Tools.Insert('*', 18)}");

            x = 1;
            int px = 13;
            int py = 16;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                string columnName = grid.Rows[i].Cells["colColumnName"].Value.ToString();
                bool rs = isFieldSelected(grid, columnName);
                string toolsBoxName = getToolsBoxName(grid, columnName);
                string controlName = getControlName(grid, columnName);
                string controlText = getControlText(grid, columnName);

                if (rs == true && !isFieldIdentity(grid, columnName))
                {
                    script.AppendLine($"//");
                    script.AppendLine($"// label{x}");
                    script.AppendLine($"//");
                    script.AppendLine($"this.label{x}.AutoSize = true;");
                    script.AppendLine($"this.label{x}.Location = new System.Drawing.Point({px}, {py});");
                    script.AppendLine($"this.label{x}.Name = \"label{x}\";");
                    //script.AppendLine($"this.label{x + 1}.Size = new System.Drawing.Size(89, 20);");
                    script.AppendLine($"this.label{x}.Text = \"{controlText}\";");
                    script.AppendLine($"this.Controls.Add(this.label{x});");

                    //
                    script.AppendLine($"//");
                    script.AppendLine($"// {controlName}");
                    script.AppendLine($"//");
                    script.AppendLine($"this.{controlName}.Location = new System.Drawing.Point({px + 60}, {py});");
                    script.AppendLine($"this.{controlName}.Name = \"{controlName}\";");
                    script.AppendLine($"this.{controlName}.Size = new System.Drawing.Size(150, 27);");
                    script.AppendLine($"this.Controls.Add(this.{controlName});");
                    x++;
                }
                px = 13;
                py = py + 33;
            }

            state = true;
            //}
            //catch (Exception ex)
            //{
            //    message = "An error occurred: " + ex.Message;
            //    state = false;
            //}

            return script.ToString();
        }

        public string CreateCustomDatagridview(DataGridView grid, propDatagridview prop, List<Events> evs, out string message)
        {
            try
            {
                script = new StringBuilder();
                message = string.Empty;

                script.AppendLine($"//{Tools.Tools.Insert('*', 15)} Declaration {Tools.Tools.Insert('*', 15)}");
                script.AppendLine($"private System.Windows.Forms.DataGridView {prop.Name};");

                int x = 1;
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    //string columnName = grid.Rows[i].Cells["colColumn"].Value.ToString();
                    //bool rs = isFieldSelected(grid, columnName);
                    string columnType = grid.Rows[i].Cells["colColumnType"].Value.ToString();
                    string controlName = grid.Rows[i].Cells["colName"].Value.ToString();

                    script.AppendLine($"private System.Windows.Forms.{columnType} {controlName};");
                    x++;
                }

                script.AppendLine();
                script.AppendLine($"//{Tools.Tools.Insert('*', 51)}");
                script.AppendLine($"//{Tools.Tools.Insert('*', 15)} InitializeComponent {Tools.Tools.Insert('*', 15)}");
                script.AppendLine($"this.{prop.Name} = new System.Windows.Forms.DataGridView();");

                x = 1;
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    string columnName = grid.Rows[i].Cells["colColumn"].Value.ToString();
                    //bool rs = isFieldSelected(grid, columnName);
                    string columnType = grid.Rows[i].Cells["colColumnType"].Value.ToString();
                    string controlName = grid.Rows[i].Cells["colName"].Value.ToString();

                    script.AppendLine($"this.{controlName} = new System.Windows.Forms.{columnType}();");
                    x++;
                }

                script.AppendLine();
                script.AppendLine($"//{Tools.Tools.Insert('*', 51)}");
                script.AppendLine($"//{Tools.Tools.Insert('*', 18)} SuspendLayout {Tools.Tools.Insert('*', 18)}");

                //suspend layout for datagridview
                script.AppendLine($"//");
                script.AppendLine($"// {prop.Name}");
                script.AppendLine($"//");
                script.AppendLine($"this.{prop.Name}.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.{prop.ColumnHeadersHeightSizeMode};");
                script.AppendLine($"this.{prop.Name}.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {{");

                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    string controlName = grid.Rows[i].Cells["colName"].Value.ToString();
                    script.Append($"this.{controlName}");
                    if (i < grid.Rows.Count - 1)
                        script.AppendLine(",");
                    else
                        script.AppendLine("});");
                }
                script.AppendLine($"this.{prop.Name}.Location = new System.Drawing.Point(12, 12);");
                script.AppendLine($"this.{prop.Name}.Name = \"{prop.Name}\";");
                script.AppendLine($"this.{prop.Name}.RowHeadersWidth = {prop.RowHeadersWidth};");
                script.AppendLine($"this.{prop.Name}.RowTemplate.Height = {prop.RowTemplate.Height};");
                script.AppendLine($"this.{prop.Name}.Size = new System.Drawing.Size({prop.Size.Width}, {prop.Size.Height});");

                /////////////////
                script.AppendLine($"this.{prop.Name}.AllowUserToAddRows = {prop.AllowUserToAddRows.ToString().ToLower()};");
                script.AppendLine($"this.{prop.Name}.AllowUserToDeleteRows = {prop.AllowUserToDeleteRows.ToString().ToLower()};");
                script.AppendLine($"this.{prop.Name}.AllowUserToOrderColumns = {prop.AllowUserToOrderColumns.ToString().ToLower()};");
                script.AppendLine($"this.{prop.Name}.AllowUserToResizeColumns = {prop.AllowUserToResizeColumns.ToString().ToLower()};");
                script.AppendLine($"this.{prop.Name}.AllowUserToResizeRows = {prop.AllowUserToResizeRows.ToString().ToLower()};");
                script.AppendLine($"this.{prop.Name}.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.{prop.AutoSizeColumnsMode};");
                script.AppendLine($"this.{prop.Name}.AutoSizeRowsMode =  System.Windows.Forms.DataGridViewAutoSizeRowsMode.{prop.AutoSizeRowsMode};");
                script.AppendLine($"this.{prop.Name}.BorderStyle = System.Windows.Forms.BorderStyle.{prop.BorderStyle};");
                script.AppendLine($"this.{prop.Name}.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.{prop.CellBorderStyle};");
                script.AppendLine($"this.{prop.Name}.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.{prop.ColumnHeadersBorderStyle};");
                script.AppendLine($"this.{prop.Name}.ColumnHeadersHeight = {prop.ColumnHeadersHeight};");
                script.AppendLine($"this.{prop.Name}.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.{prop.ColumnHeadersHeightSizeMode};");
                script.AppendLine($"this.{prop.Name}.ColumnHeadersVisible = {prop.ColumnHeadersVisible.ToString().ToLower()};");
                script.AppendLine($"this.{prop.Name}.MultiSelect = {prop.MultiSelect.ToString().ToLower()};");
                script.AppendLine($"this.{prop.Name}.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.{prop.RowHeadersBorderStyle};");
                script.AppendLine($"this.{prop.Name}.RowHeadersVisible = {prop.RowHeadersVisible.ToString().ToLower()};");
                script.AppendLine($"this.{prop.Name}.RowHeadersWidth = {prop.RowHeadersWidth};");
                script.AppendLine($"this.{prop.Name}.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.{prop.RowHeadersWidthSizeMode};");
                script.AppendLine($"this.{prop.Name}.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.{prop.SelectionMode};");

                /*
                 *
                 * Events
                 *
                 *
                 */
                var r = evs.FirstOrDefault(xs => xs.Field.Equals(prop.Name));
                if (r != null)
                {
                    var ev = r.EventsName.ToList();
                    foreach (string e in ev)
                    {
                        var info = Tools.Tools.GetInfoEventsForDatagridView(e);
                        script.AppendLine($"this.{prop.Name}.{e} += new {info.EventHandlerType.FullName}(this.{prop.Name}_{e});");
                    }
                }

                //////////////
                script.AppendLine($"this.Controls.Add({prop.Name});");

                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    string controlName = grid.Rows[i].Cells["colName"].Value.ToString();
                    string controlHeaderText = grid.Rows[i].Cells["colHeaderText"].Value.ToString();
                    string controlAutoSizeMode = grid.Rows[i].Cells["colAutoSizeMode"].Value.ToString();
                    string controlDataPropertyName = grid.Rows[i].Cells["colDataPropertyName"].Value.ToString();
                    //string controlWidth = grid.Rows[i].Cells["colWidth"].Value.ToString();

                    bool visible;
                    if (grid.Rows[i].Cells["colVisible"].Value == null || grid.Rows[i].Cells["colVisible"].Value == DBNull.Value || System.Convert.ToBoolean(grid.Rows[i].Cells["colVisible"].Value) == false)
                        visible = false;
                    else
                        visible = true;
                    bool readOnly;

                    if (grid.Rows[i].Cells["colReadOnly"].Value == null || grid.Rows[i].Cells["colReadOnly"].Value == DBNull.Value || System.Convert.ToBoolean(grid.Rows[i].Cells["colReadOnly"].Value) == false)
                        readOnly = false;
                    else
                        readOnly = true;

                    script.AppendLine($"//");
                    script.AppendLine($"// {controlName}");
                    script.AppendLine($"//");
                    script.AppendLine($"this.{controlName}.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.{controlAutoSizeMode};");
                    script.AppendLine($"this.{controlName}.DataPropertyName = \"{controlDataPropertyName}\";");
                    script.AppendLine($"this.{controlName}.HeaderText = \"{controlHeaderText}\";");
                    script.AppendLine($"this.{controlName}.MinimumWidth = 6;");
                    script.AppendLine($"this.{controlName}.Name = \"{controlName}\";");
                    script.AppendLine($"this.{controlName}.ReadOnly = {readOnly.ToString().ToLower()};");
                    script.AppendLine($"this.{controlName}.Visible = {visible.ToString().ToLower()};");
                    //script.AppendLine($"this.{controlName}.Width = {controlWidth};");
                }

                var re = evs.FirstOrDefault(xs => xs.Field.Equals(prop.Name));
                if (re != null)
                {
                    script.AppendLine();
                    script.AppendLine($"//{Tools.Tools.Insert('*', 51)}");
                    script.AppendLine($"//{Tools.Tools.Insert('*', 18)} Events For DatagridView {Tools.Tools.Insert('*', 18)}");

                    var ev = re.EventsName.ToList();
                    foreach (string e in ev)
                    {
                        //var info = Tools.GetInfoEventsForDatagridView(e);
                        //script.AppendLine($"this.{prop.Name}.{e} += new {info.EventHandlerType.FullName}(this.{prop.Name}_{e});");
                        var d = Tools.Tools.GetInfoEventsForDatagridView(e).EventHandlerType.Name.Replace("Handler", "Args");
                        script.AppendLine($"{Tools.Tools.InsertTabs(0)}private void {prop.Name}_{e}(object sender, {d} e)");
                        script.AppendLine($"{Tools.Tools.InsertTabs(0)}{{");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}//Insert code C#");
                        script.AppendLine($"{Tools.Tools.InsertTabs(0)}}}");
                        script.AppendLine();
                    }
                }

                state = true;
            }
            catch (Exception ex)
            {
                message = "An error occurred: " + ex.Message;
                state = false;
            }

            return script.ToString();
        }

        #endregion Controls

        public string GenerateVariables(string modeVariable, out string message)
        {
            try
            {
                script = new StringBuilder();
                message = string.Empty;

                script.AppendLine($"{Tools.Tools.InsertTabs(0)}{modeVariable} SqlConnection connection = new SqlConnection(@\"{conString}\");");
                script.AppendLine($"{Tools.Tools.InsertTabs(0)}{modeVariable} SqlCommand command;");
                script.AppendLine($"{Tools.Tools.InsertTabs(0)}{modeVariable} SqlDataAdapter adapter;");
                script.AppendLine($"{Tools.Tools.InsertTabs(0)}{modeVariable} SqlDataReader reader;");
                script.AppendLine($"{Tools.Tools.InsertTabs(0)}{modeVariable} DataTable dt;");
                script.AppendLine($"{Tools.Tools.InsertTabs(0)}{modeVariable} SqlParameter[] parameter;");

                state = true;
            }
            catch (Exception ex)
            {
                message = "An error occurred: " + ex.Message;
                state = false;
            }

            return script.ToString();
        }

        public string GenerateFunctions(DataGridView grid, string table, string modeProcedure, string modeVariable, out string message)
        {
            message = string.Empty;
            StringBuilder script = new StringBuilder();
            string rs = "";
            try
            {
                rs += Insert(grid, table, modeProcedure, out message);
                rs += Environment.NewLine;
                rs += Update(grid, table, modeProcedure, out message);
                rs += Environment.NewLine;
                rs += Delete(grid, table, modeProcedure, out message);
                rs += Environment.NewLine;
                rs += Select(grid, table, modeProcedure, out message);
                rs += Environment.NewLine;
                rs += Search(grid, table, modeProcedure, out message);
                state = true;
            }
            catch (Exception ex)
            {
                message = "An error occurred: " + ex.Message;
                state = false;
            }
            return rs;
        }

        public string OpenConnection(string modeProcedure, out string message)
        {
            try
            {
                script = new StringBuilder();
                message = string.Empty;

                script.AppendLine($"{Tools.Tools.InsertTabs(0)}{modeProcedure} void OpenConnection()");
                script.AppendLine($"{Tools.Tools.InsertTabs(0)}{{");

                //start function
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}try");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}{{");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}if (connection.State != ConnectionState.Open)");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}{{");
                script.AppendLine($"{Tools.Tools.InsertTabs(3)}connection.Open();");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}}}");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}}}");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}catch(Exception ex)");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}{{");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}MessageBox.Show(ex.Message, \"Error\", MessageBoxButtons.OK, MessageBoxIcon.Error);");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}}}");
                script.Append($"{Tools.Tools.InsertTabs(0)}}}");

                state = true;
            }
            catch (Exception ex)
            {
                message = "An error occurred: " + ex.Message;
                state = false;
            }

            return script.ToString();
        }

        public string CloseConnection(string modeProcedure, out string message)
        {
            try
            {
                script = new StringBuilder();
                message = string.Empty;

                script.AppendLine($"{Tools.Tools.InsertTabs(0)}{modeProcedure} void CloseConnection()");
                script.AppendLine($"{Tools.Tools.InsertTabs(0)}{{");

                //start function
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}try");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}{{");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}if (connection.State != ConnectionState.Closed)");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}{{");
                script.AppendLine($"{Tools.Tools.InsertTabs(3)}connection.Close();");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}}}");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}}}");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}catch(Exception ex)");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}{{");
                script.AppendLine($"{Tools.Tools.InsertTabs(2)}MessageBox.Show(ex.Message, \"Error\", MessageBoxButtons.OK, MessageBoxIcon.Error);");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}}}");
                script.Append($"{Tools.Tools.InsertTabs(0)}}}");

                state = true;
            }
            catch (Exception ex)
            {
                message = "An error occurred: " + ex.Message;
                state = false;
            }

            return script.ToString();
        }

        public string FillCombo(DataGridView grid, string modeProcedure, out string message)
        {
            try
            {
                script = new StringBuilder();
                message = string.Empty;

                foreach (DataGridViewRow row in grid.Rows)
                {
                    string toolBox = $"{row.Cells["colToolBox"].Value}";
                    if (Data.ControlAcceptDatasource().Contains(toolBox))
                    {
                        string controlName = $"{row.Cells["colControlName"].Value}";
                        string tbl = $"{row.Cells["colDatasource"].Value}";
                        string valueMemebr = $"{row.Cells["colValueMember"].Value}";
                        string displayMember = $"{row.Cells["colDisplayMember"].Value}";

                        script.AppendLine($"/* {Tools.Tools.Insert('=', 15)} FillCombo {Tools.Tools.Insert('=', 15)} */");

                        script.AppendLine($"{modeProcedure} void FillCombo_{row.Cells["colControlName"].Value}()");
                        script.AppendLine("{");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}try");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}{{");
                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}DataTable dt = new DataTable();");
                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}OpenConnection();");
                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}SqlCommand cmd = new SqlCommand();");
                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}cmd.CommandType = CommandType.StoredProcedure;");
                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}cmd.CommandText = \"Select_{tbl}\";");
                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}cmd.Connection = connection;");
                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}adapter = new SqlDataAdapter(cmd);");
                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}adapter.Fill(dt);");
                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}CloseConnection();");
                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}{row.Cells["colControlName"].Value}.DataSource = dt;");
                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}{row.Cells["colControlName"].Value}.DisplayMember = \"{displayMember}\";");
                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}{row.Cells["colControlName"].Value}.ValueMember = \"{valueMemebr}\";");
                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}{row.Cells["colControlName"].Value}.SelectedIndex = -1;");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}}}");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}catch");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}{{");
                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}{row.Cells["colControlName"].Value}.DataSource = new DataTable();");
                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}CloseConnection();");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}}}");
                        script.AppendLine($"}}");
                        script.AppendLine();
                    }
                }

                state = true;
            }
            catch (Exception ex)
            {
                message = "An error occurred: " + ex.Message;
                state = false;
            }

            return script.ToString();
        }
    }
}