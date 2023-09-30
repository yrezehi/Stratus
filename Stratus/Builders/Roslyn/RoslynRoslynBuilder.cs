using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Stratus.Builders.Roslyn
{
    public static class RoslynRoslynBuilder
    {
        public static AttributeListSyntax Attirbute(string name)
        {
            return SyntaxFactory.AttributeList(
                SyntaxFactory.SingletonSeparatedList(
                        SyntaxFactory.Attribute(
                            SyntaxFactory.ParseName("Column"),
                                SyntaxFactory.AttributeArgumentList(
                                    SyntaxFactory.SingletonSeparatedList
                                    (
                                        SyntaxFactory.AttributeArgument(
                                            SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(name))
                                        )
                                    )
                                )
                        )
                )
            );
        }
    }
}
