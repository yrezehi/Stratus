using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Stratus.Builders.Roslyn
{
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

        public static AccessorDeclarationSyntax[] GetSetAccessors() => new AccessorDeclarationSyntax[] {
            SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
            SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
        };
    }
}
