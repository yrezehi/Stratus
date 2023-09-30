using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;

namespace Stratus.Builders.Roslyn.Web.Services
{
    public class DBSetBuilder
    {
        protected CompilationUnitSyntax CompilationUnit { get; set; }
        private string Name { get; set; }

        private DBSetBuilder(string name)
        {
            Name = name;
            CompilationUnit = SyntaxFactory.CompilationUnit();
        }

        public static DBSetBuilder Builder(string name) => new DBSetBuilder(name);

        public string Build()
        {
            return CompilationUnit
                .WithMembers(
                    SyntaxFactory.SingletonList<MemberDeclarationSyntax>(
                        SyntaxFactory.PropertyDeclaration(
                            SyntaxFactory.GenericName(
                                SyntaxFactory.Identifier("DbSet"))
                            .WithTypeArgumentList(
                                SyntaxFactory.TypeArgumentList(
                                    SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                        SyntaxFactory.IdentifierName(Name)))),
                            SyntaxFactory.Identifier(Name))
                        .WithModifiers(
                            SyntaxFactory.TokenList(
                                new[]{
                                    SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                                    SyntaxFactory.Token(SyntaxKind.VirtualKeyword)}))
                        .WithAccessorList(
                            SyntaxFactory.AccessorList(
                                SyntaxFactory.List<AccessorDeclarationSyntax>(
                                    new AccessorDeclarationSyntax[]{
                                        SyntaxFactory.AccessorDeclaration(
                                            SyntaxKind.GetAccessorDeclaration)
                                        .WithSemicolonToken(
                                            SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                                        SyntaxFactory.AccessorDeclaration(
                                            SyntaxKind.SetAccessorDeclaration)
                                        .WithSemicolonToken(
                                            SyntaxFactory.Token(SyntaxKind.SemicolonToken))})))))
                .NormalizeWhitespace().ToFullString();
        }
    }
}
