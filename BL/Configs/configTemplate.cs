using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Configs
{
    [Serializable]
    public class configTemplate
    {
        public List<Template> Templates { get; set; } = new List<Template>();

        //public List<TemplateDatagridview> TemplatesDatagridview { get; set; }
    }
}