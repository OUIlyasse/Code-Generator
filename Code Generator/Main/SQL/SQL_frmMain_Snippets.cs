using Code_Generator.Sub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator.Main.SQL
{
    public partial class SQL_frmMain
    {
        private void Snippets()
        {
            frmCodeSnippet fr = new frmCodeSnippet(this);
            fr.ShowDialog();
        }
    }
}