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

namespace Stratus.Generator
{
    public class ClassBuilder
    {
        protected Class ClassBlueprint { get; set; }
        protected CompilationUnitSyntax CompilationUnit { get; set; }

        private List<NamespaceDeclarationSyntax> Namespaces { get; set; } = new List<NamespaceDeclarationSyntax>();

        private ClassBuilder() {
            ClassBlueprint = new Class();
            CompilationUnit = SyntaxFactory.CompilationUnit();
        }

        public static ClassBuilder Builder() => new ClassBuilder();
        public Class Build() => ClassBlueprint;

        public ClassBuilder WithSpaceName(params string[] namespaces)
        {
            foreach(var @namespace in namespaces)
            {
                Namespaces.Add(SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(@namespace)).NormalizeWhitespace());
            }
            return this;
        }

    }
}
