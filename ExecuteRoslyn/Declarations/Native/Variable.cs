using ExecuteRoslyn.Declarations.Native.Abstracts;

namespace ExecuteRoslyn.Declarations.Native
{
    public class Variable : IDeclaration
    {
        public string Name { get; set; }
        public string Modifier { get; set; }
    }
}
