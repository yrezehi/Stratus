using Stratus.Declarations.Native.Abstracts;
using System.Xml.Linq;

namespace Stratus.Declarations.Native
{
    public class Method : IDeclaration<Method>
    {
        public string? Name { get; set; }
        public string? Modifier { get; set; }

        public Method() { }

        public Method(string name, string modifier)
        {
            Name = name;
            Modifier = modifier;
        }

        public static Method Build(string name, string modifier = "public")
        {
            return new Method(name, modifier);
        }
    }
}
