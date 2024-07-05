using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL.iSQL
{
    public partial class SQL
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
                    rs = $"{columnName} >= @FirstDate_{columnName} AND {columnName} <= @LastDate_{columnName}";
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

        #endregion Codes

        #region CRUD

        public string Insert(DataGridView grid, string table, out string message)
        {
            message = string.Empty;
            script = new StringBuilder();
            try
            {
                //script.AppendLine($"USE [{db}]");
                //script.AppendLine();

                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine($"-- Author:{Tools.Tools.InsertTabs(1)}<{ser.Name}>");
                script.AppendLine($"-- Date:{Tools.Tools.InsertTabs(1)}<{DateTime.Now}>");
                script.AppendLine($"-- Description:{Tools.Tools.InsertTabs(1)}<Create Procedure for Insert_{table}>");
                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine();

                script.AppendLine($"CREATE PROCEDURE Insert_{table}");
                connection = new SqlConnection(ConnectionString);
                statusConnection();

                string schemaQuery = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' ORDER BY ORDINAL_POSITION";
                command = new SqlCommand(schemaQuery, connection);
                reader = command.ExecuteReader();

                //Get parametres
                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();
                    string dataType = reader["DATA_TYPE"].ToString();
                    int? maxLength = reader["CHARACTER_MAXIMUM_LENGTH"] as int?;
                    byte? numericPrecision = reader["NUMERIC_PRECISION"] as byte?;
                    int? numericScale = reader["NUMERIC_SCALE"] as int?;
                    bool rs = isFieldSWC(grid, columnName);
                    if (rs == true)
                    {
                        //if (!string.IsNullOrEmpty(getFieldDefaultValue(grid, columnName)))
                        //{
                        string columnDefinition = GetColumnDefinition(dataType, maxLength, numericPrecision, numericScale);
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}@{columnName} {columnDefinition},");
                        //}
                    }
                }

                bool rsImage = isImageExist(grid);
                int cc = countCheckReccord(grid) > 0 ? 1 : 0;
                if (rsImage == true)
                {
                    //yes image
                    script.AppendLine($"{Tools.Tools.InsertTabs(1)}@imageState nvarchar(50)");
                    script.AppendLine();
                    script.AppendLine("AS");
                    script.AppendLine("BEGIN");

                    if (countCheckReccord(grid) > 0)
                    {
                        script.Append($"{Tools.Tools.InsertTabs(1)}IF EXISTS (SELECT * FROM {table} ");
                        script.Append("WHERE ");

                        //get field for check reccord

                        statusCommand();
                        command = new SqlCommand(schemaQuery, connection);
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string columnName = reader["COLUMN_NAME"].ToString();

                            bool rsCheckReccord = isFieldCheckReccord(grid, columnName);
                            int count = countCheckReccord(grid, columnName);
                            if (rsCheckReccord == true)
                            {
                                if (count > 1)
                                    script.Append($"{getCheckReccordOperator(grid, columnName)} {columnName} {getCheckReccord(grid, columnName)} @{columnName} ");
                                else
                                    script.Append($"{columnName} {getCheckReccord(grid, columnName)} @{columnName} ");
                            }
                        }

                        //script.Length -= 1;
                        script.AppendLine(")");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}BEGIN");
                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}SELECT 0");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}END");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}ELSE");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}BEGIN");
                    }

                    //with image

                    script.AppendLine($"{Tools.Tools.InsertTabs(1, cc)}IF @imageState = 'yes_image'");
                    script.AppendLine($"{Tools.Tools.InsertTabs(1, cc)}BEGIN");
                    script.Append($"{Tools.Tools.InsertTabs(2, cc)}INSERT INTO {table} (");

                    //Get columns
                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        bool rs = isFieldSelected(grid, columnName);
                        bool rs2 = isFieldIdentity(grid, columnName);
                        if (rs == true && rs2 != true)
                            script.Append($"{columnName}, ");
                    }
                    script.Length -= 2; // Remove the trailing comma and newline
                    script.AppendLine(" )");

                    script.Append($"{Tools.Tools.InsertTabs(2, cc)}VALUES (");
                    //Get Values
                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        bool rs = isFieldSelected(grid, columnName);
                        bool rs2 = isFieldIdentity(grid, columnName);
                        if (rs == true && rs2 != true)
                            script.Append($"@{columnName}, ");
                    }
                    script.Length -= 2;
                    script.AppendLine(" )");

                    script.AppendLine($"{Tools.Tools.InsertTabs(1, cc)}END");
                    //no image insert
                    script.AppendLine($"{Tools.Tools.InsertTabs(1, cc)}IF @imageState = 'no_image'");
                    script.AppendLine($"{Tools.Tools.InsertTabs(1, cc)}BEGIN");
                    script.Append($"{Tools.Tools.InsertTabs(2, cc)}INSERT INTO {table} (");
                    //Get columns
                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        string dataType = reader["DATA_TYPE"].ToString();
                        bool rs = isFieldSelected(grid, columnName);
                        bool rs2 = isFieldIdentity(grid, columnName);
                        bool t = dataType.Equals("image", StringComparison.OrdinalIgnoreCase) ? true : false;
                        if (rs == true && rs2 != true && t != true)
                            script.Append($"{columnName}, ");
                    }
                    script.Length -= 2; // Remove the trailing comma and newline
                    script.AppendLine(" )");

                    script.Append($"{Tools.Tools.InsertTabs(2, cc)}VALUES (");
                    //Get Values
                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        string dataType = reader["DATA_TYPE"].ToString();
                        bool rs = isFieldSelected(grid, columnName);
                        bool rs2 = isFieldIdentity(grid, columnName);
                        bool t = dataType.Equals("image", StringComparison.OrdinalIgnoreCase) ? true : false;

                        if (rs == true && rs2 != true && t != true)
                        {
                            script.Append($"@{columnName}, ");
                        }
                    }

                    script.Length -= 2;
                    script.AppendLine(" )");

                    script.AppendLine($"{Tools.Tools.InsertTabs(1, cc)}END");
                    if (countCheckReccord(grid) > 0)
                    {
                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}SELECT 1");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}END");
                    }

                    script.AppendLine("END");
                }
                else
                {
                    //No image
                    script.Length -= 3;
                    script.AppendLine();
                    script.AppendLine();
                    script.AppendLine("AS");
                    script.AppendLine("BEGIN");

                    if (countCheckReccord(grid) > 0)
                    {
                        script.Append($"{Tools.Tools.InsertTabs(1)}IF EXISTS (SELECT * FROM {table} ");
                        script.Append("WHERE ");

                        //get field for check reccord
                        statusCommand();
                        command = new SqlCommand(schemaQuery, connection);
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string columnName = reader["COLUMN_NAME"].ToString();

                            bool rsCheckReccord = isFieldCheckReccord(grid, columnName);
                            int count = countCheckReccord(grid, columnName);
                            if (rsCheckReccord == true)
                            {
                                if (count > 1)
                                    script.Append($"{getCheckReccordOperator(grid, columnName)} {columnName} {getCheckReccord(grid, columnName)} @{columnName} ");
                                else
                                    script.Append($"{columnName} {getCheckReccord(grid, columnName)} @{columnName} ");
                            }
                        }

                        //script.Length -= 1;
                        script.AppendLine(")");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}BEGIN");
                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}SELECT 0");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}END");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}ELSE");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}BEGIN");
                    }

                    script.Append($"{Tools.Tools.InsertTabs(1, cc)}INSERT INTO {table} (");
                    //Get columns
                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        string dataType = reader["DATA_TYPE"].ToString();
                        bool rs = isFieldSelected(grid, columnName);
                        bool rs2 = isFieldIdentity(grid, columnName);
                        bool t = dataType.Equals("image", StringComparison.OrdinalIgnoreCase) ? true : false;
                        if (rs == true && rs2 != true && t != true)
                            script.Append($"{columnName}, ");
                    }
                    script.Length -= 2; // Remove the trailing comma and newline
                    script.AppendLine(" )");

                    script.Append($"{Tools.Tools.InsertTabs(1, cc)}VALUES (");

                    //Get Values
                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        string dataType = reader["DATA_TYPE"].ToString();
                        bool rs = isFieldSelected(grid, columnName);
                        bool rs2 = isFieldIdentity(grid, columnName);
                        bool t = dataType.Equals("image", StringComparison.OrdinalIgnoreCase) ? true : false;

                        if (rs == true && rs2 != true && t != true)
                        {
                            script.Append($"@{columnName}, ");
                        }
                    }

                    script.Length -= 2;
                    script.AppendLine(" )");
                    if (countCheckReccord(grid) > 0)
                    {
                        script.AppendLine($"{Tools.Tools.InsertTabs(1, cc)}SELECT 1");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}END");
                    }

                    script.AppendLine("END");
                }

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

        public string Update(DataGridView grid, string table, out string message)
        {
            message = string.Empty;
            script = new StringBuilder();
            try
            {
                //script.AppendLine($"USE [{db}]");
                //script.AppendLine();

                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine($"-- Author:{Tools.Tools.InsertTabs(1)}<{ser.Name}>");
                script.AppendLine($"-- Date:{Tools.Tools.InsertTabs(1)}<{DateTime.Now}>");
                script.AppendLine($"-- Description:{Tools.Tools.InsertTabs(1)}<Create Procedure for Update_{table}>");
                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine();

                script.AppendLine($"CREATE PROCEDURE Update_{table}");
                connection = new SqlConnection(ConnectionString);
                statusConnection();

                string schemaQuery = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' ORDER BY ORDINAL_POSITION";
                command = new SqlCommand(schemaQuery, connection);
                reader = command.ExecuteReader();

                //Get parametres
                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();
                    string dataType = reader["DATA_TYPE"].ToString();
                    int? maxLength = reader["CHARACTER_MAXIMUM_LENGTH"] as int?;
                    byte? numericPrecision = reader["NUMERIC_PRECISION"] as byte?;
                    int? numericScale = reader["NUMERIC_SCALE"] as int?;
                    bool rs = isFieldSWC(grid, columnName);
                    if (rs == true)
                    {
                        //if (!string.IsNullOrEmpty(getFieldDefaultValue(grid, columnName)))
                        //{
                        string columnDefinition = GetColumnDefinition(dataType, maxLength, numericPrecision, numericScale);
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}@{columnName} {columnDefinition},");
                        //}
                    }
                }

                bool rsImage = isImageExist(grid);
                int cc = countCheckReccord(grid) > 0 ? 1 : 0;
                if (rsImage == true)
                {
                    //yes image
                    script.AppendLine($"{Tools.Tools.InsertTabs(1)}@imageState nvarchar(50)");
                    script.AppendLine();
                    script.AppendLine("AS");
                    script.AppendLine("BEGIN");

                    if (countCheckReccord(grid) > 0)
                    {
                        script.Append($"{Tools.Tools.InsertTabs(1)}IF EXISTS (SELECT * FROM {table} ");
                        script.Append("WHERE ");

                        //get field for check reccord

                        statusCommand();
                        command = new SqlCommand(schemaQuery, connection);
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string columnName = reader["COLUMN_NAME"].ToString();

                            bool rsCheckReccord = isFieldCheckReccord(grid, columnName);
                            int count = countCheckReccord(grid, columnName);
                            if (rsCheckReccord == true)
                            {
                                if (count > 1)
                                    script.Append($"{getCheckReccordOperator(grid, columnName)} {columnName} {getCheckReccord(grid, columnName)} @{columnName} ");
                                else
                                    script.Append($"{columnName} {getCheckReccord(grid, columnName)} @{columnName} ");
                            }
                        }

                        //script.Length -= 1;
                        script.AppendLine(")");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}BEGIN");
                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}SELECT 0");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}END");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}ELSE");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}BEGIN");
                    }

                    //with image

                    script.AppendLine($"{Tools.Tools.InsertTabs(1, cc)}IF @imageState = 'yes_image'");
                    script.AppendLine($"{Tools.Tools.InsertTabs(1, cc)}BEGIN");
                    script.AppendLine($"{Tools.Tools.InsertTabs(2, cc)}UPDATE {table} SET");
                    script.Append($"{Tools.Tools.InsertTabs(3, cc)}");
                    //Get columns
                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        bool rs = isFieldSelected(grid, columnName);
                        bool rs3 = isFieldWhere(grid, columnName);
                        bool rs2 = isFieldIdentity(grid, columnName);
                        if (rs == true && rs3 != true)
                        {
                            if (rs2 != true)
                                script.Append($"{columnName}, ");
                        }
                    }
                    script.Length -= 2; // Remove the trailing comma and newline
                    script.AppendLine();

                    if (countWhere(grid) > 0)
                    {
                        script.AppendLine($"{Tools.Tools.InsertTabs(2, cc)}WHERE");
                        script.Append($"{Tools.Tools.InsertTabs(3, cc)}");

                        //Get columns for where
                        statusCommand();
                        command = new SqlCommand(schemaQuery, connection);
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string columnName = reader["COLUMN_NAME"].ToString();
                            //bool rs = isFieldSelected(grid, columnName);
                            bool rs3 = isFieldWhere(grid, columnName);
                            if (rs3 == true)
                                script.Append($"{columnName} = @{columnName} and ");
                        }
                        script.Length -= 5;
                        script.AppendLine();
                    }

                    script.AppendLine($"{Tools.Tools.InsertTabs(1, cc)}END");
                    //no image insert
                    script.AppendLine($"{Tools.Tools.InsertTabs(1, cc)}IF @imageState = 'no_image'");
                    script.AppendLine($"{Tools.Tools.InsertTabs(1, cc)}BEGIN");
                    script.AppendLine($"{Tools.Tools.InsertTabs(2, cc)}UPDATE {table} SET");
                    script.Append($"{Tools.Tools.InsertTabs(3, cc)}");
                    //Get columns
                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        string dataType = reader["DATA_TYPE"].ToString();
                        bool rs = isFieldSelected(grid, columnName);
                        bool rs3 = isFieldWhere(grid, columnName);
                        bool rs2 = isFieldIdentity(grid, columnName);
                        if (rs == true && rs3 != true)
                        {
                            bool t = dataType.Equals("image", StringComparison.OrdinalIgnoreCase) ? true : false;
                            if (rs2 != true && t != true)
                                script.Append($"{columnName} = @{columnName}, ");
                        }
                    }
                    script.Length -= 2; // Remove the trailing comma and newline
                    script.AppendLine();

                    if (countWhere(grid) > 0)
                    {
                        script.AppendLine($"{Tools.Tools.InsertTabs(2, cc)}WHERE");
                        script.Append($"{Tools.Tools.InsertTabs(3, cc)}");

                        statusCommand();
                        command = new SqlCommand(schemaQuery, connection);
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string columnName = reader["COLUMN_NAME"].ToString();
                            bool rs3 = isFieldWhere(grid, columnName);
                            if (rs3 == true)
                                script.Append($"{columnName} = @{columnName} and ");
                        }
                        script.Length -= 5;
                        script.AppendLine();
                    }

                    script.AppendLine($"{Tools.Tools.InsertTabs(1, cc)}END");
                    if (countCheckReccord(grid) > 0)
                    {
                        script.AppendLine($"{Tools.Tools.InsertTabs(1, cc)}SELECT 1");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}END");
                    }

                    script.AppendLine($"END");
                }
                else
                {
                    //No image
                    script.Length -= 3;
                    script.AppendLine();
                    script.AppendLine();
                    script.AppendLine("AS");
                    script.AppendLine("BEGIN");

                    if (countCheckReccord(grid) > 0)
                    {
                        script.Append($"{Tools.Tools.InsertTabs(1)}IF EXISTS (SELECT * FROM {table} ");
                        script.Append("WHERE ");

                        //get field for check reccord
                        statusCommand();
                        command = new SqlCommand(schemaQuery, connection);
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string columnName = reader["COLUMN_NAME"].ToString();

                            bool rsCheckReccord = isFieldCheckReccord(grid, columnName);
                            int count = countCheckReccord(grid, columnName);
                            if (rsCheckReccord == true)
                            {
                                if (count > 1)
                                    script.Append($"{getCheckReccordOperator(grid, columnName)} {columnName} {getCheckReccord(grid, columnName)} @{columnName} ");
                                else
                                    script.Append($"{columnName} {getCheckReccord(grid, columnName)} @{columnName} ");
                            }
                        }

                        //script.Length -= 1;
                        script.AppendLine(")");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}BEGIN");
                        script.AppendLine($"{Tools.Tools.InsertTabs(2)}SELECT 0");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}END");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}ELSE");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}BEGIN");
                    }

                    script.AppendLine($"{Tools.Tools.InsertTabs(1, cc)}UPDATE {table} SET");
                    script.Append($"{Tools.Tools.InsertTabs(2, cc)}");
                    //Get columns
                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        bool rs = isFieldSelected(grid, columnName);
                        bool rs3 = isFieldWhere(grid, columnName);
                        bool rs2 = isFieldIdentity(grid, columnName);
                        if (rs == true && rs3 != true)
                        {
                            //bool t = dataType.Equals("image", StringComparison.OrdinalIgnoreCase) ? true : false;
                            if (rs2 != true /*&& t != true*/)
                                script.Append($"{columnName} = @{columnName}, ");
                        }
                    }
                    script.Length -= 2; // Remove the trailing comma and newline
                    script.AppendLine();

                    if (countWhere(grid) > 0)
                    {
                        script.AppendLine($"{Tools.Tools.InsertTabs(1, cc)}WHERE");
                        script.Append($"{Tools.Tools.InsertTabs(2, cc)}");

                        statusCommand();
                        command = new SqlCommand(schemaQuery, connection);
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string columnName = reader["COLUMN_NAME"].ToString();
                            bool rs3 = isFieldWhere(grid, columnName);
                            if (rs3 == true)
                                script.Append($"{columnName} = @{columnName} and ");
                        }
                        script.Length -= 5;
                        script.AppendLine();
                    }

                    script.AppendLine($"{Tools.Tools.InsertTabs(1, cc)}END");
                    if (countCheckReccord(grid) > 0)
                    {
                        script.AppendLine($"{Tools.Tools.InsertTabs(1, cc)}SELECT 1");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}END");
                    }

                    script.AppendLine($"END");
                }
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

        public string Delete(DataGridView grid, string table, out string message)
        {
            message = string.Empty;
            script = new StringBuilder();
            try
            {
                //script.AppendLine($"USE [{db}]");
                //script.AppendLine();

                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine($"-- Author:{Tools.Tools.InsertTabs(1)}<{ser.Name}>");
                script.AppendLine($"-- Date:{Tools.Tools.InsertTabs(1)}<{DateTime.Now}>");
                script.AppendLine($"-- Description:{Tools.Tools.InsertTabs(1)}<Create Procedure for Delete_{table}>");
                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine();

                script.AppendLine($"CREATE PROCEDURE Delete_{table}");
                connection = new SqlConnection(ConnectionString);
                statusConnection();

                string schemaQuery = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' ORDER BY ORDINAL_POSITION";
                command = new SqlCommand(schemaQuery, connection);
                reader = command.ExecuteReader();

                //Get parametres
                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();
                    string dataType = reader["DATA_TYPE"].ToString();
                    int? maxLength = reader["CHARACTER_MAXIMUM_LENGTH"] as int?;
                    byte? numericPrecision = reader["NUMERIC_PRECISION"] as byte?;
                    int? numericScale = reader["NUMERIC_SCALE"] as int?;
                    //bool rs = isFieldSelected(grid, columnName);
                    bool rs2 = isFieldWhere(grid, columnName);
                    if (rs2 == true)
                    {
                        string columnDefinition = GetColumnDefinition(dataType, maxLength, numericPrecision, numericScale);
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}@{columnName} {columnDefinition},");
                    }
                }
                script.Length -= 3;
                script.AppendLine();
                script.AppendLine();

                script.AppendLine("AS");
                script.AppendLine("BEGIN");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}DELETE FROM {table}");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}WHERE");
                script.Append($"{Tools.Tools.InsertTabs(2)}");

                statusCommand();
                command = new SqlCommand(schemaQuery, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();
                    bool rs3 = isFieldWhere(grid, columnName);
                    if (rs3 == true)
                        script.Append($"{columnName} = @{columnName} and ");
                }
                script.Length -= 5;
                script.AppendLine();
                script.AppendLine("END");

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

        public string Select(DataGridView grid, string table, out string message)
        {
            message = string.Empty;
            StringBuilder script = new StringBuilder();
            try
            {
                connection = new SqlConnection(ConnectionString);
                statusConnection();

                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine($"-- Author:{Tools.Tools.InsertTabs(1)}<{ser.Name}>");
                script.AppendLine($"-- Date:{Tools.Tools.InsertTabs(1)}<{DateTime.Now}>");
                script.AppendLine($"-- Description:{Tools.Tools.InsertTabs(1)}<Create Procedure for Select_{table}>");
                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine();

                script.AppendLine($"CREATE PROCEDURE Select_{table}");
                // Retrieve schema information for the specified table
                string schemaQuery = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' ORDER BY ORDINAL_POSITION";

                //Get parametres
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
                        string columnDefinition = GetColumnDefinition(dataType, maxLength, numericPrecision, numericScale);
                        script.AppendLine($"\t@{columnName} {columnDefinition},");
                    }
                }

                if (countWhere(grid) > 0)
                    script.Length -= 3;
                else
                    script.Length -= 2;

                script.AppendLine();
                script.AppendLine();
                script.AppendLine("AS");
                script.AppendLine("BEGIN");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}SELECT");
                script.Append($"{Tools.Tools.InsertTabs(2)}");

                statusCommand();
                command = new SqlCommand(schemaQuery, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();
                    bool rs = isFieldSelected(grid, columnName);
                    string aggregation;
                    bool rs2 = isFieldAggregation(grid, columnName, out aggregation);
                    if (rs)
                    {
                        if (rs2)
                            script.Append($"{aggregation}, ");
                        else
                            script.Append($"{columnName}, ");
                    }
                }

                script.Length -= 2; // Remove the trailing comma and newline
                script.AppendLine();
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}FROM {table}");

                //Where
                if (countWhere(grid) > 0)
                {
                    script.AppendLine($"{Tools.Tools.InsertTabs(1)}WHERE");
                    script.Append($"{Tools.Tools.InsertTabs(2)}");

                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        bool rs = isFieldWhere(grid, columnName);
                        if (rs == true)
                        {
                            script.Append($"{columnName}  = @{columnName} and ");
                        }
                    }

                    script.Length -= 5; // Remove the trailing comma and newline
                    script.AppendLine();
                }

                //Group By
                if (countGrouprBy(grid) > 0)
                {
                    script.AppendLine($"{Tools.Tools.InsertTabs(1)}GROUP BY");
                    script.Append($"{Tools.Tools.InsertTabs(2)}");

                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        bool rs = isFieldGroupBy(grid, columnName);
                        if (rs == true)
                        {
                            script.Append($"{columnName}, ");
                        }
                    }

                    script.Length -= 2; // Remove the trailing comma and newline
                    script.AppendLine();
                }

                //Order By
                if (countOrderBy(grid) > 0)
                {
                    script.AppendLine($"{Tools.Tools.InsertTabs(1)}ORDER BY ");
                    script.Append($"{Tools.Tools.InsertTabs(2)}");

                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        bool rs = isFieldOrderBy(grid, columnName);
                        string order = getOrderByField(grid, columnName);
                        if (rs == true)
                        {
                            script.Append($"{columnName} {order}, ");
                        }
                    }

                    script.Length -= 2; // Remove the trailing comma and newline
                    script.AppendLine();
                }

                script.AppendLine("END");

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

        #endregion CRUD

        #region Aggregation

        public string AVG(DataGridView grid, string table, out string message)
        {
            message = string.Empty;
            StringBuilder script = new StringBuilder();
            try
            {
                connection = new SqlConnection(ConnectionString);
                statusConnection();

                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine($"-- Author:{Tools.Tools.InsertTabs(1)}<{ser.Name}>");
                script.AppendLine($"-- Date:{Tools.Tools.InsertTabs(1)}<{DateTime.Now}>");
                script.AppendLine($"-- Description:{Tools.Tools.InsertTabs(1)}<Create Procedure for AVG_{table}>");
                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine();

                script.AppendLine($"CREATE PROCEDURE AVG_{table}");

                // Retrieve schema information for the specified table
                string schemaQuery = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' ORDER BY ORDINAL_POSITION";

                //Get parametres
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
                        string columnDefinition = GetColumnDefinition(dataType, maxLength, numericPrecision, numericScale);
                        script.AppendLine($"\t@{columnName} {columnDefinition},");
                    }
                }

                script.Length -= 2; // Remove the trailing comma and newline
                script.AppendLine();
                script.AppendLine();
                script.AppendLine("AS");
                script.AppendLine("BEGIN");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}SELECT");
                script.Append($"{Tools.Tools.InsertTabs(2)}");

                statusCommand();
                command = new SqlCommand(schemaQuery, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();
                    bool rs = isFieldSelected(grid, columnName);
                    if (rs == true)
                        script.Append($"COALESCE(AVG({columnName}), 0) as avg_{columnName}, ");
                }

                script.Length -= 2; // Remove the trailing comma and newline
                script.AppendLine();
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}FROM {table}");

                //Where
                if (countWhere(grid) > 0)
                {
                    script.AppendLine($"{Tools.Tools.InsertTabs(1)}WHERE");
                    script.Append($"{Tools.Tools.InsertTabs(2)}");

                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        bool rs = isFieldWhere(grid, columnName);
                        if (rs == true)
                            script.Append($"{columnName}  = @{columnName} and ");
                    }

                    script.Length -= 5; // Remove the trailing comma and newline
                    script.AppendLine();
                }

                script.AppendLine("END");

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

        public string MAX(DataGridView grid, string table, out string message)
        {
            message = string.Empty;
            StringBuilder script = new StringBuilder();
            try
            {
                connection = new SqlConnection(ConnectionString);
                statusConnection();

                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine($"-- Author:{Tools.Tools.InsertTabs(1)}<{ser.Name}>");
                script.AppendLine($"-- Date:{Tools.Tools.InsertTabs(1)}<{DateTime.Now}>");
                script.AppendLine($"-- Description:{Tools.Tools.InsertTabs(1)}<Create Procedure for MAX_{table}>");
                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine();

                script.AppendLine($"CREATE PROCEDURE MAX_{table}");

                // Retrieve schema information for the specified table
                string schemaQuery = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' ORDER BY ORDINAL_POSITION";

                //Get parametres
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
                        string columnDefinition = GetColumnDefinition(dataType, maxLength, numericPrecision, numericScale);
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}@{columnName} {columnDefinition},");
                    }
                }

                script.Length -= 2; // Remove the trailing comma and newline
                script.AppendLine();
                script.AppendLine();
                script.AppendLine("AS");
                script.AppendLine("BEGIN");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}SELECT");
                script.Append($"{Tools.Tools.InsertTabs(2)}");

                statusCommand();
                command = new SqlCommand(schemaQuery, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();
                    bool rs = isFieldSelected(grid, columnName);
                    if (rs == true)
                    {
                        script.Append($"ISNULL (Max({columnName}), 0) as max_{columnName}, ");
                    }
                }

                script.Length -= 2; // Remove the trailing comma and newline
                script.AppendLine();
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}FROM {table}");

                //Where
                if (countWhere(grid) > 0)
                {
                    script.AppendLine($"{Tools.Tools.InsertTabs(1)}WHERE");
                    script.Append($"{Tools.Tools.InsertTabs(2)}");

                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        bool rs = isFieldWhere(grid, columnName);
                        if (rs == true)
                        {
                            script.Append($"{columnName}  = @{columnName} and ");
                        }
                    }

                    script.Length -= 5; // Remove the trailing comma and newline
                    script.AppendLine();
                }

                script.AppendLine("END");

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

        public string MIN(DataGridView grid, string table, out string message)
        {
            message = string.Empty;
            StringBuilder script = new StringBuilder();
            try
            {
                connection = new SqlConnection(ConnectionString);
                statusConnection();

                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine($"-- Author:{Tools.Tools.InsertTabs(1)}<{ser.Name}>");
                script.AppendLine($"-- Date:{Tools.Tools.InsertTabs(1)}<{DateTime.Now}>");
                script.AppendLine($"-- Description:{Tools.Tools.InsertTabs(1)}<Create Procedure for MIN_{table}>");
                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine();

                script.AppendLine($"CREATE PROCEDURE MIN_{table}");

                // Retrieve schema information for the specified table
                string schemaQuery = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' ORDER BY ORDINAL_POSITION";

                //Get parametres

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
                        string columnDefinition = GetColumnDefinition(dataType, maxLength, numericPrecision, numericScale);
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}@{columnName} {columnDefinition},");
                    }
                }

                script.Length -= 2; // Remove the trailing comma and newline
                script.AppendLine();
                script.AppendLine();
                script.AppendLine("AS");
                script.AppendLine("BEGIN");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}SELECT");
                script.Append($"{Tools.Tools.InsertTabs(2)}");

                statusCommand();
                command = new SqlCommand(schemaQuery, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();
                    bool rs = isFieldSelected(grid, columnName);
                    if (rs == true)
                    {
                        script.Append($"ISNULL (MIN({columnName}), 0) as min_{columnName}, ");
                    }
                }

                script.Length -= 2; // Remove the trailing comma and newline
                script.AppendLine();
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}FROM {table}");

                //Where
                if (countWhere(grid) > 0)
                {
                    script.AppendLine($"{Tools.Tools.InsertTabs(1)}WHERE");
                    script.Append($"{Tools.Tools.InsertTabs(2)}");

                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        bool rs = isFieldWhere(grid, columnName);
                        if (rs == true)
                        {
                            script.Append($"{columnName}  = @{columnName} and ");
                        }
                    }

                    script.Length -= 5; // Remove the trailing comma and newline
                    script.AppendLine();
                }

                script.AppendLine("END");

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

        public string COUNT(DataGridView grid, string table, out string message)
        {
            message = string.Empty;
            StringBuilder script = new StringBuilder();
            try
            {
                connection = new SqlConnection(ConnectionString);
                statusConnection();

                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine($"-- Author:{Tools.Tools.InsertTabs(1)}<{ser.Name}>");
                script.AppendLine($"-- Date:{Tools.Tools.InsertTabs(1)}<{DateTime.Now}>");
                script.AppendLine($"-- Description:{Tools.Tools.InsertTabs(1)}<Create Procedure for COUNT_{table}>");
                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine();

                script.AppendLine($"CREATE PROCEDURE COUNT_{table}");

                // Retrieve schema information for the specified table
                string schemaQuery = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' ORDER BY ORDINAL_POSITION";

                //Get parametres
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
                        string columnDefinition = GetColumnDefinition(dataType, maxLength, numericPrecision, numericScale);
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}@{columnName} {columnDefinition},");
                    }
                }

                script.Length -= 2; // Remove the trailing comma and newline
                script.AppendLine();
                script.AppendLine();
                script.AppendLine("AS");
                script.AppendLine("BEGIN");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}SELECT");
                script.Append($"{Tools.Tools.InsertTabs(2)}");

                statusCommand();
                command = new SqlCommand(schemaQuery, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();
                    bool rs = isFieldSelected(grid, columnName);
                    if (rs == true)
                    {
                        script.Append($"COUNT({columnName}) as count_{columnName}, ");
                    }
                }

                script.Length -= 2; // Remove the trailing comma and newline
                script.AppendLine();
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}FROM {table}");

                //Where
                if (countWhere(grid) > 0)
                {
                    script.AppendLine($"{Tools.Tools.InsertTabs(1)}WHERE");
                    script.Append($"{Tools.Tools.InsertTabs(2)}");

                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        bool rs = isFieldWhere(grid, columnName);
                        if (rs == true)
                        {
                            script.Append($"{columnName}  = @{columnName} and ");
                        }
                    }

                    script.Length -= 5; // Remove the trailing comma and newline
                    script.AppendLine();
                }

                script.AppendLine("END");

                state = true;
            }
            catch (Exception ex)
            {
                message = "An error occurred: " + ex.Message;
                state = false;
            }
            return script.ToString();
        }

        public string SUM(DataGridView grid, string table, out string message)
        {
            message = string.Empty;
            StringBuilder script = new StringBuilder();
            try
            {
                connection = new SqlConnection(ConnectionString);
                statusConnection();

                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine($"-- Author:{Tools.Tools.InsertTabs(1)}<{ser.Name}>");
                script.AppendLine($"-- Date:{Tools.Tools.InsertTabs(1)}<{DateTime.Now}>");
                script.AppendLine($"-- Description:{Tools.Tools.InsertTabs(1)}<Create Procedure for SUM_{table}>");
                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine();

                script.AppendLine($"CREATE PROCEDURE SUM_{table}");

                // Retrieve schema information for the specified table
                string schemaQuery = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' ORDER BY ORDINAL_POSITION";

                //Get parametres
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
                        string columnDefinition = GetColumnDefinition(dataType, maxLength, numericPrecision, numericScale);
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}@{columnName} {columnDefinition},");
                    }
                }

                script.Length -= 2; // Remove the trailing comma and newline
                script.AppendLine();
                script.AppendLine();
                script.AppendLine("AS");
                script.AppendLine("BEGIN");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}SELECT");
                script.Append($"{Tools.Tools.InsertTabs(2)}");

                statusCommand();
                command = new SqlCommand(schemaQuery, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();
                    bool rs = isFieldSelected(grid, columnName);
                    if (rs == true)
                    {
                        script.Append($"SUM({columnName}) as sum_{columnName}, ");
                    }
                }

                script.Length -= 2; // Remove the trailing comma and newline
                script.AppendLine();
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}FROM {table}");

                //Where
                if (countWhere(grid) > 0)
                {
                    script.AppendLine($"{Tools.Tools.InsertTabs(1)}WHERE");
                    script.Append($"{Tools.Tools.InsertTabs(2)}");

                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        bool rs = isFieldWhere(grid, columnName);
                        if (rs == true)
                        {
                            script.Append($"{columnName}  = @{columnName} and ");
                        }
                    }

                    script.Length -= 5; // Remove the trailing comma and newline
                    script.AppendLine();
                }

                script.AppendLine("END");

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

        public string Search(DataGridView grid, string table, out string message)
        {
            message = string.Empty;
            StringBuilder script = new StringBuilder();
            try
            {
                connection = new SqlConnection(ConnectionString);
                statusConnection();

                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine($"-- Author:{Tools.Tools.InsertTabs(1)}<{ser.Name}>");
                script.AppendLine($"-- Date:{Tools.Tools.InsertTabs(1)}<{DateTime.Now}>");
                script.AppendLine($"-- Description:{Tools.Tools.InsertTabs(1)}<Create Procedure for Search_{table}>");
                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine();

                script.AppendLine($"CREATE PROCEDURE Search_{table}");

                // Retrieve schema information for the specified table
                string schemaQuery = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' ORDER BY ORDINAL_POSITION";

                //Get parametres

                script.AppendLine($"{Tools.Tools.InsertTabs(1)}@Search nvarchar(max)");

                script.AppendLine();
                script.AppendLine("AS");
                script.AppendLine("BEGIN");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}SELECT");
                script.Append($"{Tools.Tools.InsertTabs(2)}");

                command = new SqlCommand(schemaQuery, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();
                    bool rs = isFieldSelected(grid, columnName);
                    if (rs == true)
                    {
                        script.Append($"{columnName}, ");
                    }
                }

                script.Length -= 2; // Remove the trailing comma and newline
                script.AppendLine();
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}FROM {table}");

                //Where
                if (countWhere(grid) > 0)
                {
                    script.AppendLine($"{Tools.Tools.InsertTabs(1)}WHERE");
                    script.Append($"{Tools.Tools.InsertTabs(2)}");

                    statusCommand();
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
                            script.Append($"{generateSearchString(columnName, dataType, 0)} or ");
                    }

                    script.Length -= 4; // Remove the trailing comma and newline
                    script.AppendLine();
                }

                //Group By
                if (countGrouprBy(grid) > 0)
                {
                    script.AppendLine($"{Tools.Tools.InsertTabs(1)}GROUP BY");
                    script.Append($"{Tools.Tools.InsertTabs(2)}");

                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        bool rs = isFieldGroupBy(grid, columnName);
                        if (rs == true)
                            script.Append($"{columnName}, ");
                    }

                    script.Length -= 2; // Remove the trailing comma and newline
                    script.AppendLine();
                }

                //Order By
                if (countOrderBy(grid) > 0)
                {
                    script.AppendLine($"{Tools.Tools.InsertTabs(1)}ORDER BY ");
                    script.Append($"{Tools.Tools.InsertTabs(2)}");

                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        bool rs = isFieldOrderBy(grid, columnName);
                        if (rs == true)
                            script.Append($"{columnName} ASC, ");
                    }

                    script.Length -= 2; // Remove the trailing comma and newline
                    script.AppendLine();
                }

                script.AppendLine("END");

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

        public string SearchAll(DataGridView grid, string table, out string message)
        {
            message = string.Empty;
            script = new StringBuilder();
            try
            {
                connection = new SqlConnection(ConnectionString);
                statusConnection();

                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine($"-- Author:{Tools.Tools.InsertTabs(1)}<{ser.Name}>");
                script.AppendLine($"-- Date:{Tools.Tools.InsertTabs(1)}<{DateTime.Now}>");
                script.AppendLine($"-- Description:{Tools.Tools.InsertTabs(1)}<Create Procedure for Search_{table}>");
                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine();

                script.AppendLine($"CREATE PROCEDURE Search_{table}");

                // Retrieve schema information for the specified table
                string schemaQuery = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' ORDER BY ORDINAL_POSITION";

                //Get parametres

                script.AppendLine($"{Tools.Tools.InsertTabs(1)}@Search nvarchar(max)");

                script.AppendLine();
                script.AppendLine("AS");
                script.AppendLine("BEGIN");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}SELECT");
                script.Append($"{Tools.Tools.InsertTabs(2)}");

                command = new SqlCommand(schemaQuery, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();
                    bool rs = isFieldSelected(grid, columnName);
                    if (rs == true)
                    {
                        script.Append($"{columnName}, ");
                    }
                }

                script.Length -= 2; // Remove the trailing comma and newline
                script.AppendLine();
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}FROM {table}");

                //Where
                if (countWhere(grid) > 0)
                {
                    script.AppendLine($"{Tools.Tools.InsertTabs(1)}WHERE");
                    script.Append($"{Tools.Tools.InsertTabs(2)}");

                    statusCommand();
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
                            script.Append($"{generateSearchString(columnName, dataType, 1)} + ");
                    }

                    script.Length -= 3; // Remove the trailing comma and newline
                    script.AppendLine();
                    script.AppendLine($"{Tools.Tools.InsertTabs(2)}LIKE '%' + @Search + '%'");
                }

                //Group By
                if (countGrouprBy(grid) > 0)
                {
                    script.AppendLine($"{Tools.Tools.InsertTabs(1)}GROUP BY");
                    script.Append($"{Tools.Tools.InsertTabs(2)}");

                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        bool rs = isFieldGroupBy(grid, columnName);
                        if (rs == true)
                            script.Append($"{columnName}, ");
                    }

                    script.Length -= 2; // Remove the trailing comma and newline
                    script.AppendLine();
                }

                //Order By
                if (countOrderBy(grid) > 0)
                {
                    script.AppendLine($"{Tools.Tools.InsertTabs(1)}ORDER BY ");
                    script.Append($"{Tools.Tools.InsertTabs(2)}");

                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        bool rs = isFieldOrderBy(grid, columnName);
                        if (rs == true)
                            script.Append($"{columnName} ASC, ");
                    }

                    script.Length -= 2; // Remove the trailing comma and newline
                    script.AppendLine();
                }

                script.AppendLine("END");

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

        public string SearchBetweenDate(DataGridView grid, string table, out string message)
        {
            message = string.Empty;
            StringBuilder script = new StringBuilder();
            try
            {
                connection = new SqlConnection(ConnectionString);
                statusConnection();

                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine($"-- Author:{Tools.Tools.InsertTabs(1)}<{ser.Name}>");
                script.AppendLine($"-- Date:{Tools.Tools.InsertTabs(1)}<{DateTime.Now}>");
                script.AppendLine($"-- Description:{Tools.Tools.InsertTabs(1)}<Create Procedure for Search_{table}>");
                script.AppendLine($"-- {Tools.Tools.Insert('=', 50)}");
                script.AppendLine();

                script.AppendLine($"CREATE PROCEDURE Search_{table}");

                // Retrieve schema information for the specified table
                string schemaQuery = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}' ORDER BY ORDINAL_POSITION";

                //Get parametres

                string dtt = string.Empty;

                command = new SqlCommand(schemaQuery, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();
                    string dataType = reader["DATA_TYPE"].ToString();

                    bool rs = isFieldDateExist(grid, columnName);
                    if (dataType.Contains("date"))
                    {
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}@FirstDate_{columnName} {dtt},");
                        script.AppendLine($"{Tools.Tools.InsertTabs(1)}@LastDate_{columnName} {dtt}");
                    }
                }

                script.AppendLine();
                script.AppendLine("AS");
                script.AppendLine("BEGIN");
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}SELECT");
                script.Append($"{Tools.Tools.InsertTabs(2)}");

                statusCommand();
                command = new SqlCommand(schemaQuery, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();
                    bool rs = isFieldSelected(grid, columnName);
                    if (rs == true)
                    {
                        script.Append($"{columnName}, ");
                    }
                }

                script.Length -= 2; // Remove the trailing comma and newline
                script.AppendLine();
                script.AppendLine($"{Tools.Tools.InsertTabs(1)}FROM {table}");

                //Where
                if (countWhere(grid) > 0)
                {
                    script.AppendLine($"{Tools.Tools.InsertTabs(1)}WHERE");
                    script.Append($"{Tools.Tools.InsertTabs(2)}");

                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    int count = countWhereAndDate(grid);
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        string dataType = reader["DATA_TYPE"].ToString();
                        int? maxLength = reader["CHARACTER_MAXIMUM_LENGTH"] as int?;
                        byte? numericPrecision = reader["NUMERIC_PRECISION"] as byte?;
                        int? numericScale = reader["NUMERIC_SCALE"] as int?;

                        bool rs = isFieldWhere(grid, columnName);
                        bool rs2 = isFieldDateExist(grid, columnName);

                        if (rs == true && rs2 == true)
                        {
                            if (count > 1)
                            {
                                script.Append("(");
                                script.Append($"{generateSearchString(columnName, dataType, 0)}) or ");
                            }
                            else
                                script.Append($"{generateSearchString(columnName, dataType, 2)}");
                        }
                    }
                    if (count > 1)
                        script.Length -= 4; // Remove the trailing comma and newline
                    script.AppendLine();
                }

                //Group By
                if (countGrouprBy(grid) > 0)
                {
                    script.AppendLine($"{Tools.Tools.InsertTabs(1)}GROUP BY");
                    script.Append($"{Tools.Tools.InsertTabs(2)}");

                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        bool rs = isFieldGroupBy(grid, columnName);
                        if (rs == true)
                            script.Append($"{columnName}, ");
                    }

                    script.Length -= 2; // Remove the trailing comma and newline
                    script.AppendLine();
                }

                //Order By
                if (countOrderBy(grid) > 0)
                {
                    script.AppendLine($"{Tools.Tools.InsertTabs(1)}ORDER BY ");
                    script.Append($"{Tools.Tools.InsertTabs(2)}");

                    statusCommand();
                    command = new SqlCommand(schemaQuery, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        bool rs = isFieldOrderBy(grid, columnName);
                        if (rs == true)
                            script.Append($"{columnName} ASC, ");
                    }

                    script.Length -= 2; // Remove the trailing comma and newline
                    script.AppendLine();
                }

                script.AppendLine("END");

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

        #endregion Search
    }
}