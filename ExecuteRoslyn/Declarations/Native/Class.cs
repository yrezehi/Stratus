using ExecuteRoslyn.Declarations.Native.Abstracts;

namespace ExecuteRoslyn.Declarations.Native
{
    public class Class : IDeclaration
    {
        public string? Name { get; set; }
        public string? Modifier { get; set; }
    }
}
