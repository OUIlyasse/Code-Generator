using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTIL;
using System.Text.RegularExpressions;
using BL.Configs;
using BL.Helper;
using Code_Generator.Main.SQL;
using Code_Generator.Sub;

namespace Code_Generator.UC
{
    public partial class ucEditor : UserControl
    {
        #region Daclaration

        private Language _language = Language.Custom;
        private bool showLineNumbering = true;
        private Color foreColorLine = Color.Black;
        private Stack<string> undoStack;
        private Stack<string> redoStack;
        private string lastText;
        private SQL_frmMain frmSQL;

        #endregion Daclaration

        #region Property

        public dbInfo dbInfo { get; set; }
        public BL.iSQL.SQL SQL { get; set; }
        public string Titre { get; set; }

        public Language Syntaxe
        {
            get { return _language; }
            set
            {
                _language = value;
                richTextBox1.Invalidate();
            }
        }

        public RichTextBox Editor
        {
            get { return richTextBox1; }
            set
            {
                richTextBox1 = value;
                richTextBox1.Invalidate();
            }
        }

        public bool ShowLineNumbering
        {
            get { return showLineNumbering; }
            set
            {
                showLineNumbering = value;
                picLines.Invalidate();
                //UpdateLineNumbers();
            }
        }

        public Color ForeColorLine
        {
            get { return foreColorLine; }
            set
            {
                foreColorLine = value;
                picLines.Invalidate();
            }
        }

        public SQL_frmMain FrmSQL { get => frmSQL; set => frmSQL = value; }

        #endregion Property

        #region Overrides

        public override string Text { get { return Editor.Text; } set { Editor.Text = value; richTextBox1_TextChanged(null, null); /*Editor.Invalidate(); */} }

        #endregion Overrides

        #region Codes

        private void UpdateLineNumbers()
        {
            picLines.Controls.Clear();

            int firstIndex = richTextBox1.GetCharIndexFromPosition(new Point(0, 0));
            int firstLine = richTextBox1.GetLineFromCharIndex(firstIndex);
            int firstLineY = richTextBox1.GetPositionFromCharIndex(firstIndex).Y;

            int lastIndex = richTextBox1.GetCharIndexFromPosition(new Point(0, richTextBox1.ClientSize.Height));
            int lastLine = richTextBox1.GetLineFromCharIndex(lastIndex);
            int lastLineY = richTextBox1.GetPositionFromCharIndex(lastIndex).Y;

            for (int i = firstLine; i <= lastLine /*+ 1*/; i++)
            {
                Label lineNumberLabel = new Label
                {
                    AutoSize = false,
                    Width = picLines.Width,
                    Height = richTextBox1.Font.Height,
                    Location = new Point(0, firstLineY + ((i - firstLine) * richTextBox1.Font.Height)),
                    Text = (i + 1).ToString(),
                    Font = richTextBox1.Font,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                picLines.Controls.Add(lineNumberLabel);
            }
        }

        private void SyntaxeSQL()
        {
            richTextBox1.SuspendLayout();
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

            MatchCollection typeMatches1 = Regex.Matches(Editor.Text.ToUpper(), keywords1);

            // getting types/classes from the text
            string keywords2 = @"\b(PARAMETERS|COLUMNS|DATABASES|SCHEMAS|TABLES)\b";
            MatchCollection typeMatches2 = Regex.Matches(Editor.Text.ToUpper(), keywords2);

            string keywords3 = @"\b(ALL|AND|ANY|BETWEEN|CROSS|EXISTS|IN|INNER|IS|JOIN|LEFT|LIKE|NOT|NULL|OR|OUTER|RIGHT|SOME|
                                                   MATCHED|SOURCE)\b";
            MatchCollection typeMatches3 = Regex.Matches(Editor.Text.ToUpper(), keywords3);

            string keywords4 = @"\b(ABS|AVG|CAST|CEILING|CAST|CEILING|CAST|CEILING|CAST|CHECKSUM|COALESCE|COLLATE|CONTAINS|CONVERT|
                                                   COUNT|CURRENT_TIME|CURRENT_TIMESTAMP|CURRENT_USER|DENSE_RANK|EXP|EXTRACT|FLOOR|GROUPING|HOUR|
                                                   ISNULL|LOWER|MAX|MIN|MINUTE|MOD|MONTH|NULLIF|POWER|RANK|REPLACE|ROW_NUMBER|SCHEMA_NAME|
                                                   SECOND|SESSION_USER|SPACE|UPPER|SQRT|SUBSTRING|SUM|SYSTEM_USER|TSEQUAL|UPDATE|DAY|BIT_LENGTH|YEAR|
                                                   DAYOFMONTH|DAYOFWEEK|DAYOFYEAR|MONTHNAME|NORMALIZE|OCTET_LENGTH)\b";
            MatchCollection typeMatches4 = Regex.Matches(Editor.Text.ToUpper(), keywords4);

            // getting comments (inline or multiline)
            //string comments = @"(\/\/.+?$|\/\*.+?\*\/)";
            string comments = @"(--.+?$|\/\*.+?\*\/)";
            MatchCollection commentMatches = Regex.Matches(Editor.Text, comments, RegexOptions.Multiline);

            // getting strings
            string strings = @"(@\S+)";
            MatchCollection stringMatches = Regex.Matches(Editor.Text, strings);

            // getting strings
            string strings2 = "\'.+?\'";
            MatchCollection stringMatches2 = Regex.Matches(Editor.Text, strings2);

            // saving the original caret position + forecolor
            int originalIndex = Editor.SelectionStart;
            int originalLength = Editor.SelectionLength;
            Color originalColor = Color.Black;

            picLines.Focus();

            // removes any previous highlighting (so modified words won't remain highlighted)
            Editor.SelectionStart = 0;
            Editor.SelectionLength = Editor.Text.Length;
            Editor.SelectionColor = originalColor;

            // scanning...
            foreach (Match m in typeMatches1)
            {
                Editor.SelectionStart = m.Index;
                Editor.SelectionLength = m.Length;
                Editor.SelectionColor = Color.FromArgb(0, 0, 255); //Bleu
                Editor.SelectedText = Regex.Replace(m.Value,
                  @"\b[A-Z]",
                  s => s.ToString().ToUpper(),
                  RegexOptions.IgnoreCase);
            }

            foreach (Match m in typeMatches2)
            {
                Editor.SelectionStart = m.Index;
                Editor.SelectionLength = m.Length;
                Editor.SelectionColor = Color.FromArgb(52, 255, 52); //Vert
                Editor.SelectedText = Regex.Replace(m.Value,
                  @"\b[A-Z]",
                  s => s.ToString().ToUpper(),
                  RegexOptions.IgnoreCase);
            }

            foreach (Match m in typeMatches3)
            {
                Editor.SelectionStart = m.Index;
                Editor.SelectionLength = m.Length;
                Editor.SelectionColor = Color.FromArgb(128, 128, 150); //Gris
                Editor.SelectedText = Regex.Replace(m.Value,
                  @"\b[A-Z]",
                  s => s.ToString().ToUpper(),
                  RegexOptions.IgnoreCase);
            }

            foreach (Match m in typeMatches4)
            {
                Editor.SelectionStart = m.Index;
                Editor.SelectionLength = m.Length;
                Editor.SelectionColor = Color.FromArgb(255, 0, 255);//Rose
                Editor.SelectedText = Regex.Replace(m.Value,
                  @"\b[A-Z]",
                  s => s.ToString().ToUpper(),
                  RegexOptions.IgnoreCase);
            }

            foreach (Match m in commentMatches)
            {
                Editor.SelectionStart = m.Index;
                Editor.SelectionLength = m.Length;
                Editor.SelectionColor = Color.Green;
            }

            foreach (Match m in stringMatches)
            {
                Editor.SelectionStart = m.Index;
                Editor.SelectionLength = m.Length;
                Editor.SelectionColor = Color.FromArgb(173, 0, 173); //Violet
            }

            foreach (Match m in stringMatches2)
            {
                Editor.SelectionStart = m.Index;
                Editor.SelectionLength = m.Length;
                Editor.SelectionColor = Color.FromArgb(255, 0, 0); //Rouge
            }

            // restoring the original colors, for further writing
            Editor.SelectionStart = originalIndex;
            Editor.SelectionLength = originalLength;
            Editor.SelectionColor = originalColor;
            // giving back the focus

            richTextBox1.Focus();
            richTextBox1.ResumeLayout();
        }

        private void SyntaxeCsharp()
        {
            // getting keywords/functions
            string keywords = @"\b(abstract|as|base|bool|break|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|do|double|else|
                                                enum|event|explicit|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|in|int|interface|internal|is|lock|long|namespace|
                                                new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|
                                                static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|var|virtual|void|volatile|while)\b";
            MatchCollection keywordMatches = Regex.Matches(Editor.Text, keywords);

            // getting types/classes from the text
            string types = @"\b(Console)\b";
            MatchCollection typeMatches = Regex.Matches(Editor.Text, types);

            // getting comments (inline or multiline)
            string comments = @"(\/\/.+?$|\/\*.+?\*\/)";
            MatchCollection commentMatches = Regex.Matches(Editor.Text, comments, RegexOptions.Multiline);

            // getting strings
            string strings = "\".+?\"|\'.+?\'";
            MatchCollection stringMatches = Regex.Matches(Editor.Text, strings);

            // saving the original caret position + forecolor
            int originalIndex = Editor.SelectionStart;
            int originalLength = Editor.SelectionLength;
            Color originalColor = Color.Black;

            picLines.Focus();

            // removes any previous highlighting (so modified words won't remain highlighted)
            Editor.SelectionStart = 0;
            Editor.SelectionLength = Editor.Text.Length;
            Editor.SelectionColor = originalColor;

            // scanning...
            foreach (Match m in keywordMatches)
            {
                Editor.SelectionStart = m.Index;
                Editor.SelectionLength = m.Length;
                Editor.SelectionColor = Color.FromArgb(0, 0, 255); //Bleu
            }

            foreach (Match m in typeMatches)
            {
                Editor.SelectionStart = m.Index;
                Editor.SelectionLength = m.Length;
                Editor.SelectionColor = Color.DarkCyan;
            }

            foreach (Match m in commentMatches)
            {
                Editor.SelectionStart = m.Index;
                Editor.SelectionLength = m.Length;
                Editor.SelectionColor = Color.Green;
            }

            foreach (Match m in stringMatches)
            {
                Editor.SelectionStart = m.Index;
                Editor.SelectionLength = m.Length;
                Editor.SelectionColor = Color.Brown;
            }

            // restoring the original colors, for further writing
            Editor.SelectionStart = originalIndex;
            Editor.SelectionLength = originalLength;
            Editor.SelectionColor = originalColor;

            // giving back the focus
            Editor.Focus();
        }

        private void SyntaxeVB_Net()
        {
            // getting keywords/functions
            string keywords = @"\b(AddHandler|AddressOf|Alias|And|AndAlso|As|Boolean|ByRef|Byte|ByVal|Call|Case|Catch|CBool|CByte|CChar|CDate|CDbl|
                                               CDec|Char|CInt|Class|CLng|CObj|Const|Continue|CSByte|CShort|CSng|CStr|CType|CUInt|CULng|CUShort|Date|Decimal|Declare|
                                               Default|Delegate|Dim|DirectCast|Do|Double|Each|Else|ElseIf|End|EndIf|Enum|Erase|Error|Event|Exit|False|Finally|For|Friend|
                                               Function|Get|GetType|GetXMLNamespace|Global|GoSub|GoTo|Handles|If|Implements|Imports|In|Inherits|Integer|Interface|Is|
                                               IsNot|Let|Lib|Like|Long|Loop|Me|Mod|Module|MustInherit|MustOverride|MyBase|MyClass|NameOf|Namespace|Narrowing|New|
                                               New Operator|Next|Not|Nothing|NotInheritable|NotOverridable|Object|Of|On|Operator|Option|Optional|Or|OrElse|Out|Overloads|
                                               Overridable|Overrides|ParamArray|Partial|Private|Property|Protected|Public|RaiseEvent|ReadOnly|ReDim|RemoveHandler|Resume|
                                               Return|SByte|Select|Set|Shadows|Shared|Short|Single|Static|Step|Stop|String|Structure|Structure|Sub|SyncLock|Then|Throw|To|
                                               True|Try|TryCast|TypeOf…Is|UInteger|ULong|UShort|Using|Variant|Wend|When|While|Widening|With|WithEvents|WriteOnly|Xor)\b";
            MatchCollection keywordMatches = Regex.Matches(Editor.Text, keywords);

            string keywords2 = @"\b(REM)\b";
            MatchCollection keywordMatches2 = Regex.Matches(Editor.Text, keywords2);

            string keywords3 = @"\b(#Const|#Else|#ElseIf|#End|#If|#Region|#End Region)\b";
            MatchCollection keywordMatches3 = Regex.Matches(Editor.Text, keywords3);

            // getting types/classes from the text
            string types = @"\b(Type)\b";
            MatchCollection typeMatches = Regex.Matches(Editor.Text, types);

            // getting comments (inline or multiline)
            string comments = @"('.+?$)";
            MatchCollection commentMatches = Regex.Matches(Editor.Text, comments, RegexOptions.Multiline);

            // getting strings
            string strings = "\".+?\"";
            MatchCollection stringMatches = Regex.Matches(Editor.Text, strings);

            // saving the original caret position + forecolor
            int originalIndex = Editor.SelectionStart;
            int originalLength = Editor.SelectionLength;
            Color originalColor = Color.Black;

            picLines.Focus();

            // removes any previous highlighting (so modified words won't remain highlighted)
            Editor.SelectionStart = 0;
            Editor.SelectionLength = Editor.Text.Length;
            Editor.SelectionColor = originalColor;

            // scanning...
            foreach (Match m in keywordMatches)
            {
                Editor.SelectionStart = m.Index;
                Editor.SelectionLength = m.Length;
                Editor.SelectionColor = Color.FromArgb(0, 0, 255); //Bleu
            }

            foreach (Match m in keywordMatches2)
            {
                Editor.SelectionStart = m.Index;
                Editor.SelectionLength = m.Length;
                Editor.SelectionColor = Color.FromArgb(58, 144, 74);
            }

            foreach (Match m in keywordMatches3)
            {
                Editor.SelectionStart = m.Index;
                Editor.SelectionLength = m.Length;
                Editor.SelectionColor = Color.FromArgb(155, 155, 155);
            }

            foreach (Match m in typeMatches)
            {
                Editor.SelectionStart = m.Index;
                Editor.SelectionLength = m.Length;
                Editor.SelectionColor = Color.FromArgb(78, 201, 176);
            }

            foreach (Match m in commentMatches)
            {
                Editor.SelectionStart = m.Index;
                Editor.SelectionLength = m.Length;
                Editor.SelectionColor = Color.FromArgb(57, 172, 57); //Vert
            }

            foreach (Match m in stringMatches)
            {
                Editor.SelectionStart = m.Index;
                Editor.SelectionLength = m.Length;
                Editor.SelectionColor = Color.FromArgb(186, 95, 48);
            }

            // restoring the original colors, for further writing
            Editor.SelectionStart = originalIndex;
            Editor.SelectionLength = originalLength;
            Editor.SelectionColor = originalColor;

            // giving back the focus
            Editor.Focus();
        }

        private void SyntaxeNormal()
        {
            //Editor.SelectionFont = Font;
            Editor.SelectionColor = Color.Black;
        }

        private void HighlightSyntax()
        {
            switch (_language)
            {
                case Language.Custom:
                    SyntaxeNormal();
                    break;

                case Language.SQL:
                    SyntaxeSQL();
                    break;

                case Language.CSharp:
                    SyntaxeCsharp();

                    break;

                case Language.VBNET:
                    SyntaxeVB_Net();
                    break;

                default:
                    SyntaxeNormal();
                    break;
            }
        }

        private void SetupLineNumbersPictureBox()
        {
            picLines.Paint += picLines_Paint;
        }

        private void getType()
        {
            string rs;
            switch (_language)
            {
                case Language.Custom:
                    rs = "Normal text";
                    break;

                case Language.SQL:
                    rs = "Structured Query Language";

                    break;

                case Language.CSharp:
                    rs = "C# source";

                    break;

                case Language.VBNET:
                    rs = "Visual Basic source";

                    break;

                default:
                    rs = "Normal text";
                    break;
            }

            lblTypeFile.Text = rs;
        }

        private void UpdateInfo()
        {
            int textLength = richTextBox1.Text.Length;
            int lineCount = richTextBox1.Lines.Length;

            // Get the character index of the start of the selection
            int charIndex = richTextBox1.SelectionStart;

            // Get the line index
            int lineIndex = richTextBox1.GetLineFromCharIndex(charIndex);

            // Get the start index of the line
            int lineStartIndex = richTextBox1.GetFirstCharIndexFromLine(lineIndex);

            // Calculate the column index
            int columnIndex = charIndex - lineStartIndex;

            lblTotal.Text = $"Length: {textLength:00}        Lines: {lineCount:00}";
            lblSelection.Text = $"Ln {lineIndex + 1}        Col {columnIndex + 1}";
            getType();
        }

        private void CopyLineOrSelectedText()
        {
            if (richTextBox1.SelectionLength > 0)
            {
                // If text is selected, copy the selected text
                Clipboard.SetText(richTextBox1.SelectedText);
            }
            else
            {
                // If no text is selected, find the current line and copy it
                int currentLine = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
                int lineStartIndex = richTextBox1.GetFirstCharIndexFromLine(currentLine);
                int lineEndIndex = richTextBox1.GetFirstCharIndexFromLine(currentLine + 1);
                if (lineEndIndex == -1)
                {
                    // If it's the last line, set the end index to the end of the text
                    lineEndIndex = richTextBox1.TextLength;
                }
                int lineLength = lineEndIndex - lineStartIndex;
                richTextBox1.Select(lineStartIndex, lineLength);
                Clipboard.SetText(richTextBox1.SelectedText);
                // Restore the selection
                richTextBox1.Select(lineEndIndex, 0);
            }
        }

        private void CutLineOrSelectedText()
        {
            if (richTextBox1.SelectionLength > 0)
            {
                // If text is selected, cut the selected text
                Clipboard.SetText(richTextBox1.SelectedText);
                richTextBox1.SelectedText = "";
            }
            else
            {
                // If no text is selected, find the current line and cut it
                int currentLine = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
                int lineStartIndex = richTextBox1.GetFirstCharIndexFromLine(currentLine);
                int lineEndIndex = richTextBox1.GetFirstCharIndexFromLine(currentLine + 1);
                if (lineEndIndex == -1)
                {
                    // If it's the last line, set the end index to the end of the text
                    lineEndIndex = richTextBox1.TextLength;
                }
                int lineLength = lineEndIndex - lineStartIndex;
                richTextBox1.Select(lineStartIndex, lineLength);
                Clipboard.SetText(richTextBox1.SelectedText);
                richTextBox1.SelectedText = "";
            }
        }

        private void SelectAllAndCopy()
        {
            // Select all text in the RichTextBox
            richTextBox1.SelectAll();

            // Copy the selected text to the clipboard
            if (!string.IsNullOrEmpty(richTextBox1.SelectedText))
            {
                Clipboard.SetText(richTextBox1.SelectedText);
            }

            // Deselect the text
            richTextBox1.DeselectAll();
        }

        private void CommentLine()
        {
            if (richTextBox1.Text.Length > 0 && richTextBox1.SelectionLength >= 0)
            {
                string[] lines = richTextBox1.Text.Split(new string[] { Environment.NewLine, "\n", "\r", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                //Color normalColor = Color.Black, commentColor = Color.Red;
                int selStart = richTextBox1.SelectionStart, selEnd = selStart + richTextBox1.SelectionLength,
                startLine = -1, endLine = -1, lineSum = 0, k = 0;

                for (k = 0; k < lines.Length; k++)
                    if (startLine == -1)
                    {
                        if ((lineSum += lines[k].Length + 1) > selStart)
                        {
                            startLine = k;
                            if (selEnd <= lineSum) endLine = k;
                        }
                    }
                    else if (endLine == -1)
                    {
                        if ((lineSum += lines[k].Length + 1) >= selEnd)
                            endLine = k;
                    }
                    else break;

                for (int i = 0; i < lines.Length - 1; i++)
                    lines[i] = (i >= startLine && i <= endLine ? "--" : "") + lines[i];

                richTextBox1.Text = "";
                richTextBox1.SelectionStart = 0;
                for (int i = 0; i < lines.Length; i++)
                {
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    //richTextBox1.SelectionColor = lines[i].TrimStart().StartsWith("//") ? commentColor : normalColor;
                    richTextBox1.SelectedText = lines[i] += (i == lines.Length - 1 ? "" : "\r\n");
                }

                int selectStarIndx = richTextBox1.GetFirstCharIndexFromLine(startLine), selectEndIndx = richTextBox1.GetFirstCharIndexFromLine(endLine + 1);
                if (selectEndIndx == -1) selectEndIndx = richTextBox1.Text.Length;

                richTextBox1.Select(selectStarIndx, selectEndIndx - selectStarIndx);
                richTextBox1.Focus();
            }
            //int sStart = Editor.SelectionStart;
            //int currentLine = Editor.GetLineFromCharIndex(sStart);
            //int lineIndex = richTextBox1.GetFirstCharIndexFromLine(currentLine);

            //// Next, set the SelectionStart property to the start of the line
            //richTextBox1.SelectionStart = lineIndex;

            //// Now, insert your text at the beginning of the line
            //richTextBox1.SelectedText = "--"/* + richTextBox1.Lines[currentLine]*/;
            //richTextBox1.Select(sStart + 2, 0);
            //richTextBox1.Focus();
        }

        private void UncommentLine()
        {
            if (richTextBox1.Text.Length > 0 && richTextBox1.SelectionLength >= 0)
            {
                string[] lines = richTextBox1.Text.Split(new string[] { Environment.NewLine, "\n", "\r", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                //Color normalColor = Color.Black, commentColor = Color.Red;
                int selStart = richTextBox1.SelectionStart, selEnd = selStart + richTextBox1.SelectionLength,
                startLine = -1, endLine = -1, lineSum = 0, k = 0;

                for (k = 0; k < lines.Length; k++)
                    if (startLine == -1)
                    {
                        if ((lineSum += lines[k].Length + 1) > selStart)
                        {
                            startLine = k;
                            if (selEnd <= lineSum) endLine = k;
                        }
                    }
                    else if (endLine == -1)
                    {
                        if ((lineSum += lines[k].Length + 1) >= selEnd)
                            endLine = k;
                    }
                    else break;

                for (int i = 0; i < lines.Length; i++)
                {
                    if (i >= startLine && i <= endLine)
                    {
                        if (lines[i].TrimStart().StartsWith("--"))
                        {
                            lines[i] = lines[i].Substring(2);
                        }
                    }
                }

                richTextBox1.Text = "";
                richTextBox1.SelectionStart = 0;
                for (int i = 0; i < lines.Length; i++)
                {
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    //richTextBox1.SelectionColor = lines[i].TrimStart().StartsWith("//") ? commentColor : normalColor;
                    richTextBox1.SelectedText = lines[i] += (i == lines.Length - 1 ? "" : "\r\n");
                }

                int selectStarIndx = richTextBox1.GetFirstCharIndexFromLine(startLine), selectEndIndx = richTextBox1.GetFirstCharIndexFromLine(endLine + 1);
                if (selectEndIndx == -1) selectEndIndx = richTextBox1.Text.Length;

                richTextBox1.Select(selectStarIndx, selectEndIndx - selectStarIndx);
                richTextBox1.Focus();
            }
            //int currentLine = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
            //int lineStartIndex = richTextBox1.GetFirstCharIndexFromLine(currentLine);
            //int lineEndIndex = richTextBox1.GetFirstCharIndexFromLine(currentLine + 1);
            //if (lineEndIndex == -1)
            //{
            //    // If it's the last line, set the end index to the end of the text
            //    lineEndIndex = richTextBox1.TextLength;
            //}
            //int lineLength = lineEndIndex - lineStartIndex;
            //richTextBox1.Select(lineStartIndex, lineLength);
            //string rs = richTextBox1.SelectedText;

            //if (!string.IsNullOrEmpty(richTextBox1.SelectedText) && richTextBox1.SelectedText.StartsWith("--"))
            //{
            //    richTextBox1.SelectedText = richTextBox1.SelectedText.Substring(2);
            //}
            ////richTextBox1.SelectedText = rs;
            //richTextBox1.Select(richTextBox1.SelectionStart - 1, 0);
        }

        private void UpdateUndoRedoButtons()
        {
            btnUndo.Enabled = richTextBox1.CanUndo;
            btnRedo.Enabled = richTextBox1.CanRedo;
        }

        #endregion Codes

        #region Constractors

        public ucEditor()
        {
            InitializeComponent();
            _language = Language.Custom;
            dbInfo = HDbInfo.LoadConfiguration();
            SQL = new BL.iSQL.SQL(dbInfo.conString, dbInfo.DatabaseName);
            undoStack = new Stack<string>();
            redoStack = new Stack<string>();
            //lastText = "";
            SetupLineNumbersPictureBox();
            UpdateInfo();
        }

        public ucEditor(SQL_frmMain frmSQL) : this()
        {
            this.FrmSQL = frmSQL;
        }

        #endregion Constractors

        #region Events

        #endregion Events

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateLineNumbers();
            HighlightSyntax();
            UpdateInfo();
            //UpdateUndoRedoButtons();
        }

        private void picLines_Paint(object sender, PaintEventArgs e)
        {
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            picLines.Invalidate();
            UpdateInfo();
        }

        private void richTextBox1_VScroll(object sender, EventArgs e)
        {
            picLines.Invalidate();
        }

        private void menu_Opening(object sender, CancelEventArgs e)
        {
            if (_language == Language.SQL)
            {
                btnExecute.Visible = true;
                toolStripSeparator1.Visible = true;
            }
            else
            {
                btnExecute.Visible = false;
                toolStripSeparator1.Visible = false;
            }
            //if (richTextBox11.Language == FastColoredTextBoxNS.Language.Custom)
            //{
            //    btnComment.Visible = false;
            //    btnUncomment.Visible = false;
            //}
            //else
            //{
            //    btnComment.Visible = true;
            //    btnUncomment.Visible = true;
            //}

            btnComment.Visible = false;
            btnUncomment.Visible = false;

            //UpdateUndoRedoButtons();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            CutLineOrSelectedText();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            CopyLineOrSelectedText();
        }

        private void btnPast_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                string textToPaste = Clipboard.GetText();
                int selectionStart = richTextBox1.SelectionStart;
                richTextBox1.SelectedText = textToPaste;
                // Move the selection to the end of the pasted text
                richTextBox1.Select(selectionStart + textToPaste.Length, 0);
            }
        }

        private void btnSelectAllAndCopy_Click(object sender, EventArgs e)
        {
            SelectAllAndCopy();
        }

        private void btnComment_Click(object sender, EventArgs e)
        {
            CommentLine();
        }

        private void btnUncomment_Click(object sender, EventArgs e)
        {
            UncommentLine();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            //if (undoStack.Count > 0)
            //{
            //    redoStack.Push(lastText);
            //    lastText = undoStack.Pop();
            //    richTextBox1.Text = lastText;
            //}
            if (richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
                // After undo, disable the undo functionality
                richTextBox1.ClearUndo();
            }
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            //if (redoStack.Count > 0)
            //{
            //    undoStack.Push(lastText);
            //    lastText = redoStack.Pop();
            //    richTextBox1.Text = lastText;
            //}
            if (richTextBox1.CanRedo)
            {
                richTextBox1.Redo();
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string msg;
            if (richTextBox1.SelectedText.Length > 0)
                SQL.ExecuteScript(richTextBox1.SelectedText, out msg);
            else
                SQL.ExecuteScript(richTextBox1.Text, out msg);

            FrmSQL.LoadTables();
            FrmSQL.LoadViews();
            FrmSQL.LoadSP();
            if (SQL.state == true)
                frmSQL.showStatus(msg);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            //save.InitialDirectory = "";
            switch (_language)
            {
                case Language.Custom:
                    save.Filter = "Text Files(txt)|*.txt";
                    break;

                case Language.SQL:
                    save.Filter = "SQL Files(sql)|*.sql";
                    break;

                case Language.CSharp:
                    break;

                case Language.VBNET:
                    break;

                default:
                    save.Filter = "Text Files(txt)|*.txt";
                    break;
            }

            if (save.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(save.FileName, RichTextBoxStreamType.PlainText);
                frmSQL.showStatus("Save File!!");
            }
        }

        private void richTextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = richTextBox1.GetCharIndexFromPosition(e.Location);
            string text = richTextBox1.Text;

            // Define the regular expression pattern to match words
            string wordBoundaryPattern = @"\b\w+\b";
            MatchCollection matches = Regex.Matches(text, wordBoundaryPattern);

            // Iterate through the matches to find the clicked word
            foreach (Match match in matches)
            {
                int startIndex = match.Index;
                int endIndex = match.Index + match.Length - 1;

                // Check if the clicked index is within the boundaries of the current match
                if (index >= startIndex && index <= endIndex)
                {
                    // Select the clicked word
                    richTextBox1.SelectionStart = startIndex;
                    richTextBox1.SelectionLength = match.Length;
                    richTextBox1.Focus(); // Set focus back to the RichTextBox
                    break;
                }
            }
        }

        private void btnNormalText_Click(object sender, EventArgs e)
        {
            Syntaxe = Language.Custom;
            SyntaxeNormal();
            richTextBox1.Refresh();
            getType();
        }

        private void btnSQL_Click(object sender, EventArgs e)
        {
            Syntaxe = Language.SQL;
            SyntaxeSQL();
            richTextBox1.Refresh();
            getType();
        }

        private void btnCSharp_Click(object sender, EventArgs e)
        {
            Syntaxe = Language.CSharp;
            SyntaxeCsharp();
            richTextBox1.Refresh();
            getType();
        }

        private void btnVBNET_Click(object sender, EventArgs e)
        {
            Syntaxe = Language.VBNET;
            SyntaxeVB_Net();
            richTextBox1.Refresh();
            getType();
        }

        private void btnAddInSnippets_Click(object sender, EventArgs e)
        {
            string clip = Editor.SelectedText;
            if (!string.IsNullOrEmpty(clip))
            {
                frmSnippet frm = new frmSnippet(clip, Syntaxe.ToString());
                var dr = frm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    FrmSQL.showStatus("Saved!!");
                }
            }
        }

        private void richTextBox1_FontChanged(object sender, EventArgs e)
        {
            UpdateLineNumbers();
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}