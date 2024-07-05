using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTIL;

namespace BL.Configs
{
    public class configApp
    {
        #region Language Function

        private Crud crud;
        private Procedure procedure;
        private Variable variable;

        #endregion Language Function

        public List<Toolbox> Toolboxs { get; set; }
        public Crud Crud { get => crud; set => crud = value; }
        public Procedure Procedure { get => procedure; set => procedure = value; }
        public Variable Variable { get => variable; set => variable = value; }

        public configApp()
        {
            crud = Crud.Parametre;
            procedure = Procedure.Private;
            variable = Variable.Private;
            Toolboxs = new List<Toolbox>();
        }
    }
}