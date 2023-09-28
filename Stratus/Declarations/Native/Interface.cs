using Stratus.Declarations.Native.Abstracts;

namespace Stratus.Declarations.Native
{
    public class Interface : IDeclaration<Interface>
    {
        public string? Name { get; set; }
        public string? Modifier { get; set; }

        public Interface() { }

        public Interface(string name, string modifier)
        {
            Name = name;
            Modifier = modifier;
        }

        public static Interface Build(string name, string modifier = "public")
        {
            return new Interface(name, modifier);
        }

    }
}
