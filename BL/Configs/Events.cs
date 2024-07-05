using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Configs
{
    public class Events
    {
        public string Field { get; set; }
        public List<string> EventsName { get; set; }

        public Events()
        {
            Field = "";
            EventsName = new List<string>();
        }
    }
}