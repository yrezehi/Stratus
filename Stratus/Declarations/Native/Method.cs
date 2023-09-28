using Stratus.Declarations.Native.Abstracts;
using System.Xml.Linq;

namespace Stratus.Declarations.Native
{
    public class Method : IDeclaration
    {
        public string? Name { get; set; }
        public string? Modifier { get; set; }

        public Method(string name, string modifier = "public")
        {
            Name = name;
            Modifier = modifier;
        }
    }
}
