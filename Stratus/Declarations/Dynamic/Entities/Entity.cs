using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Stratus.Declarations.Dynamic.Entities
{
    public class Entity
    {
        private string Name { get; set; }

        public Entity(string name) {
            Name = name;
        }

        public static string Build(string name)
        {
            var syntaxFactory = SyntaxFactory.CompilationUnit();

            syntaxFactory = syntaxFactory.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("ComponentModel.DataAnnotations")));
            syntaxFactory = syntaxFactory.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("ComponentModel.DataAnnotations.Schema")));

            var @namespace = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName("Entities")).NormalizeWhitespace();

            var classDeclaration = SyntaxFactory.ClassDeclaration(name);
            classDeclaration = classDeclaration.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));
            classDeclaration = classDeclaration.AddBaseListTypes(
               SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName("IEntity")));

            var variableDeclaration = SyntaxFactory.VariableDeclaration(SyntaxFactory.ParseTypeName("int"))
                .AddVariables(SyntaxFactory.VariableDeclarator("Id"));
            var fieldDeclaration = SyntaxFactory.FieldDeclaration(variableDeclaration)
                 .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));

            @namespace = @namespace.AddMembers(classDeclaration);

            syntaxFactory = syntaxFactory.AddMembers(@namespace);

            return syntaxFactory
                 .NormalizeWhitespace()
                 .ToFullString();
        }
    }
}
