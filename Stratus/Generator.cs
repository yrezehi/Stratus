using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Stratus
{
    public class Generator
    {
        public SyntaxNode GlobalVariable(ClassDeclarationSyntax @class, FieldDeclarationSyntax variable) =>
           @class.AddMembers(variable);

        public Document? UpdateClass(Project project, SyntaxTree sourceTree, SyntaxNode @class) =>
            project.GetDocument(sourceTree)?.WithSyntaxRoot(@class);

        public void UpdateSolution(Workspace workspace, Document document) =>
            workspace.TryApplyChanges(document.Project.Solution);
    }
}
