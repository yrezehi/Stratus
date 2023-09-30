
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Stratus.Builders.Roslyn.Web.Entity;

namespace Stratus.Builders.Roslyn.Web.Controllers
{
    public class ControllerBuilder
    {
        protected CompilationUnitSyntax CompilationUnit { get; set; }

        private NamespaceDeclarationSyntax NamespaceDeclaration { get; set; }
        private ClassDeclarationSyntax ClassDeclaration { get; set; }

        private ControllerBuilder()
        {
            CompilationUnit = SyntaxFactory.CompilationUnit();
        }

        public static ControllerBuilder Builder() => new ControllerBuilder();

        public ControllerBuilder WithName(string name)
        {
            ClassDeclaration = SyntaxFactory.ClassDeclaration(name).AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword)).AddAttributeLists(RoslynSyntaxBuilder.KeyValueAttirbute("Table", name.ToLower()));

            return this;
        }

        public ControllerBuilder WithBases(params string[] bases)
        {
            foreach (var @base in bases)
            {
                ClassDeclaration = ClassDeclaration.AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(@base)));
            }
            return this;
        }

        public ControllerBuilder WithSpaceName(string @namespace)
        {   
            NamespaceDeclaration = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(@namespace)).NormalizeWhitespace();
            return this;
        }

        public ControllerBuilder WithImports(params string[] imports)
        {
            foreach (var import in imports)
            {
                CompilationUnit = CompilationUnit.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(import)));
            }
            return this;
        }

        public string Build()
        {
            NamespaceDeclaration = NamespaceDeclaration.AddMembers(ClassDeclaration);
            CompilationUnit = CompilationUnit.AddMembers(NamespaceDeclaration);

            return CompilationUnit.NormalizeWhitespace().ToFullString();
        }

    }
}
