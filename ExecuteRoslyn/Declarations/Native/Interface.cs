using ExecuteRoslyn.Declarations.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteRoslyn.Declarations.Native
{
    public class Interface : IDeclaration
    {
        public string Name { get; set; }
        public string Modifier { get; set; }
    }
}
