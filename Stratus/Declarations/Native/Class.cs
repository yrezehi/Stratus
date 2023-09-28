using Stratus.Declarations.Native.Abstracts;

namespace Stratus.Declarations.Native
{
    public class Class : IDeclaration<Class>
    {
        public string? Name { get; set; }
        public string? Modifier { get; set; }

        public Class() { }

        public Class(string name, string modifier)
        {
            Name = name;
            Modifier = modifier;
        }

        public static Class Build(string name, string modifier = "public")
        {
            return new Class(name, modifier);
        }
    }
}
