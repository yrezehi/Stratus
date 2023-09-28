using Stratus.Declarations.Native.Abstracts;

namespace Stratus.Declarations.Native
{
    public class Class : IDeclaration
    {
        public string? Name { get; set; }
        public string? Modifier { get; set; }
    }
}
