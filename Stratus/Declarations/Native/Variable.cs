using Stratus.Declarations.Native.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratus.Declarations.Native
{
    public class Variable : IDeclaration<Variable>
    {
        public string? Name { get; set; }
        public string? Modifier { get; set; }

        public Variable() { }

        public Variable(string name, string modifier)
        {
            Name = name;
            Modifier = modifier;
        }

        public static Variable Build(string name, string modifier = "public")
        {
            return new Variable(name, modifier);
        }
    }
}
