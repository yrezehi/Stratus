using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Xml.Linq;

namespace Stratus.Builders.Roslyn
{

    // Good luck with the maintenance
    public static class RoslynSyntaxBuilder
    {
        public static AttributeListSyntax KeyValueAttirbute(string key, string value)
        {
            return SyntaxFactory.AttributeList(
                SyntaxFactory.SingletonSeparatedList(
                        SyntaxFactory.Attribute(
                            SyntaxFactory.ParseName(key),
                                SyntaxFactory.AttributeArgumentList(
                                    SyntaxFactory.SingletonSeparatedList
                                    (
                                        SyntaxFactory.AttributeArgument(
                                            SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(value))
                                        )
                                    )
                                )
                        )
                )
            );
        }

        public static AttributeListSyntax KeyAttirbute(string key) =>
            SyntaxFactory.AttributeList(SyntaxFactory.SingletonSeparatedList(SyntaxFactory.Attribute(SyntaxFactory.ParseName(key))));

        public static AccessorDeclarationSyntax[] GetSetAccessors() => new AccessorDeclarationSyntax[] {
            SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
            SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
        };

        public static PropertyDeclarationSyntax VariableDeclaration(SyntaxKind modifier, string type, string name)
        {
            return SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName(type), name)
                .AddModifiers(SyntaxFactory.Token(modifier))
                    .AddAccessorListAccessors(RoslynSyntaxBuilder.GetSetAccessors())
                        .AddAttributeLists(RoslynSyntaxBuilder.KeyValueAttirbute("Column", name.ToLower()));
        }

    }
}
