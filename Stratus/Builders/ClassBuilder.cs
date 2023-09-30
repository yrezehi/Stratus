using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Stratus.Declarations.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Stratus.Builders
{
    public class ClassBuilder
    {
        protected CompilationUnitSyntax CompilationUnit { get; set; }

        private NamespaceDeclarationSyntax NamespaceDeclaration { get; set; }
        private ClassDeclarationSyntax ClassDeclaration { get; set; }
        private List<FieldDeclarationSyntax> FieldDeclarations { get; set; } = new List<FieldDeclarationSyntax>();

        private ClassBuilder()
        {
            CompilationUnit = SyntaxFactory.CompilationUnit();
        }

        public static ClassBuilder Builder() => new ClassBuilder();

        public ClassBuilder WithName(string name)
        {
            ClassDeclaration = SyntaxFactory.ClassDeclaration(name);
            return this;
        }

        public ClassBuilder WithBases(params string[] bases)
        {
            foreach (var @base in bases)
            {
                ClassDeclaration = ClassDeclaration.AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(@base)));
            }
            return this;
        }

        public ClassBuilder WithSpaceName(string @namespace)
        {
            NamespaceDeclaration = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(@namespace)).NormalizeWhitespace();
            return this;
        }

        public ClassBuilder WithImports(params string[] imports)
        {
            foreach (var import in imports)
            {
                CompilationUnit = CompilationUnit.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(import)));
            }
            return this;
        }

        public ClassBuilder WithVariable(SyntaxKind modifier, string type, string name)
        {
            FieldDeclarations.Add(SyntaxFactory.FieldDeclaration(SyntaxFactory.VariableDeclaration(SyntaxFactory.ParseTypeName(type))
                .AddVariables(SyntaxFactory.VariableDeclarator(name)))
                .AddModifiers(SyntaxFactory.Token(modifier)));
            return this;
        }

        public string Build()
        {
            NamespaceDeclaration = NamespaceDeclaration.AddMembers(ClassDeclaration);
            CompilationUnit = CompilationUnit.AddMembers(NamespaceDeclaration);

            foreach(var field in FieldDeclarations)
            {
                ClassDeclaration.AddMembers(field);
            }

            return CompilationUnit.NormalizeWhitespace().ToFullString();
        }

    }
}
