using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTIL;

namespace BL.Configs
{
    public class CodeSnippet
    {
        public CodeSnippet()
        {
            GUID = "";
            Name = "";
            Text = "";
            Synatxe = Language.Custom;
        }

        public CodeSnippet(string guid, string name, string text, Language synatxe)
        {
            GUID = guid;
            Name = name;
            Text = text;
            Synatxe = synatxe;
        }

        public string GUID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public Language Synatxe { get; set; }
    }
}