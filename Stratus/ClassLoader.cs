using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.IO;

namespace Stratus
{
    public static class ClassLoader
    {
        public static CompilationUnitSyntax Load(string classPath) {

            if (!File.Exists(classPath))
            {
                throw new FileNotFoundException($"Class was not found for {classPath}");
            }

            return ParseClassSyntax(LoadAsText(classPath));
        }

        private static string LoadAsText(string classPath)
        {
            using (var streamReader = new StreamReader(classPath))
            {
                return streamReader.ReadToEnd();
            }
        }

        private static CompilationUnitSyntax ParseClassSyntax(string serializedClass) =>
            (CompilationUnitSyntax) CSharpSyntaxTree.ParseText(serializedClass).GetRoot();
    }
}
