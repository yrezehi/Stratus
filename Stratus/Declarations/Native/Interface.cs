using Stratus.Declarations.Native.Abstracts;

namespace Stratus.Declarations.Native
{
    public class Interface : IDeclaration
    {
        public string? Name { get; set; }
        public string? Modifier { get; set; }
    }
}
