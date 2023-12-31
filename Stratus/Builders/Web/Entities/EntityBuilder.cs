﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Stratus.Builders.Roslyn;

namespace Stratus.Builders.Web.Entities
{
    public class EntityBuilder
    {
        protected CompilationUnitSyntax CompilationUnit { get; set; }

        private NamespaceDeclarationSyntax NamespaceDeclaration { get; set; }
        private ClassDeclarationSyntax ClassDeclaration { get; set; }
        private List<PropertyDeclarationSyntax> PropertyDeclarations { get; set; } = new List<PropertyDeclarationSyntax>();

        private EntityBuilder()
        {
            CompilationUnit = SyntaxFactory.CompilationUnit();

            PropertyDeclarations.Add(RoslynSyntaxBuilder.VariableDeclaration(SyntaxKind.PublicKeyword, "int", "Id").AddAttributeLists(RoslynSyntaxBuilder.KeyAttirbute("Key")));
        }

        public static EntityBuilder Builder() => new EntityBuilder();

        public EntityBuilder WithName(string name)
        {
            ClassDeclaration = SyntaxFactory.ClassDeclaration(name).AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword)).AddAttributeLists(RoslynSyntaxBuilder.KeyValueAttirbute("Table", name.ToLower()));

            return this;
        }

        public EntityBuilder WithBases(params string[] bases)
        {
            foreach (var @base in bases)
            {
                ClassDeclaration = ClassDeclaration.AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(@base)));
            }
            return this;
        }

        public EntityBuilder WithSpaceName(string @namespace)
        {
            NamespaceDeclaration = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(@namespace)).NormalizeWhitespace();
            return this;
        }

        public EntityBuilder WithImports(params string[] imports)
        {
            foreach (var import in imports)
            {
                CompilationUnit = CompilationUnit.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(import)));
            }
            return this;
        }

        public EntityBuilder WithGlobalVariable(SyntaxKind modifier, string type, string name)
        {
            PropertyDeclarations.Add(RoslynSyntaxBuilder.VariableDeclaration(modifier, type, name));

            return this;
        }



        public string Build()
        {
            foreach (var field in PropertyDeclarations)
            {
                ClassDeclaration = ClassDeclaration.AddMembers(field);
            }

            NamespaceDeclaration = NamespaceDeclaration.AddMembers(ClassDeclaration);
            CompilationUnit = CompilationUnit.AddMembers(NamespaceDeclaration);

            return CompilationUnit.NormalizeWhitespace().ToFullString();
        }

    }
}
