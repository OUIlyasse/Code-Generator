using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTIL;

namespace BL.Configs
{
    public class dbInfo
    {
        public dbInfo()
        {
            TypeDatabase = TypeDatabase.None;
            ServerName = "";
            Username = "";
            Password = "";
            DatabaseName = "";
            isRemember = false;
            conString = "";
            conStringMaster = "";
            Collation = "";
        }

        public TypeDatabase TypeDatabase { get; set; }
        public string ServerName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }
        public bool isRemember { get; set; }
        public string conString { get; set; }
        public string conStringMaster { get; set; }
        public string Collation { get; set; }
    }
}