﻿
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Stratus.Builders.Roslyn.Web.Entity;

namespace Stratus.Builders.Roslyn.Web.Controllers
{
    public class ControllerBuilder
    {

        private static string ROUTE_ATTRIBUTE = "[controller]";
        private static string CLASS_NAME_SUFFIX = "Controller";

        protected CompilationUnitSyntax CompilationUnit { get; set; }

        private NamespaceDeclarationSyntax NamespaceDeclaration { get; set; }
        private ClassDeclarationSyntax ClassDeclaration { get; set; }
        
        private string Name { get; set; }

        private ControllerBuilder(string name)
        {
            Name = name;
            CompilationUnit = SyntaxFactory.CompilationUnit();
        }

        public static ControllerBuilder Builder(string name) => new ControllerBuilder(name);

        public ControllerBuilder WithName()
        {
            ClassDeclaration = SyntaxFactory.ClassDeclaration(Name + CLASS_NAME_SUFFIX)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                    .AddAttributeLists(RoslynSyntaxBuilder.KeyValueAttirbute("Route", ROUTE_ATTRIBUTE));
            return this;
        }

        private ControllerBuilder WithBases()
        {
            ClassDeclaration = ClassDeclaration
               .WithBaseList(
                   SyntaxFactory.BaseList(
                        SyntaxFactory.SingletonSeparatedList<BaseTypeSyntax>(
                           SyntaxFactory.SimpleBaseType(
                               SyntaxFactory.GenericName(
                                   SyntaxFactory.Identifier("BaseController")
                               ).WithTypeArgumentList(
                                   SyntaxFactory.TypeArgumentList(
                                       SyntaxFactory.SeparatedList<TypeSyntax>(
                                           SyntaxFactory.NodeOrTokenList(
                                                SyntaxFactory.IdentifierName(Name + "Service"),
                                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                                SyntaxFactory.IdentifierName(Name)))))))));
            return this;
        }

        public ControllerBuilder WithConstructor()
        {
            ClassDeclaration = ClassDeclaration.WithMembers(
                SyntaxFactory.SingletonList<MemberDeclarationSyntax>(
                    SyntaxFactory.ConstructorDeclaration(
                        SyntaxFactory.Identifier("AgentsController"))
                    .WithModifiers(
                        SyntaxFactory.TokenList(
                            SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                    .WithParameterList(
                        SyntaxFactory.ParameterList(
                            SyntaxFactory.SingletonSeparatedList<ParameterSyntax>(
                                SyntaxFactory.Parameter(
                                    SyntaxFactory.Identifier("Service"))
                                .WithType(
                                    SyntaxFactory.IdentifierName(Name  + "Service")))))
                    .WithInitializer(
                        SyntaxFactory.ConstructorInitializer(
                            SyntaxKind.BaseConstructorInitializer,
                            SyntaxFactory.ArgumentList(
                                SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                    SyntaxFactory.Argument(
                                        SyntaxFactory.IdentifierName("Service"))))))
                    .WithBody(
                        SyntaxFactory.Block())));


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
