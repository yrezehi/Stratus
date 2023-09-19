using ExecuteRoslyn.Declarations.Native.Abstracts;

namespace ExecuteRoslyn.Declarations.Native
{
    public class Interface : IDeclaration
    {
        public string Name { get; set; }
        public string Modifier { get; set; }
    }
}
