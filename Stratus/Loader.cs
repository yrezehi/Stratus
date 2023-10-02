using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;

namespace Stratus
{
    public class Loader {
    
        private MSBuildWorkspace Workspace;
        private Solution Solution;

        public static async Task<Loader> Load(string path) {
            MSBuildLocator.RegisterDefaults();
            Loader loader = new Loader();
            loader.Workspace = MSBuildWorkspace.Create();
            loader.Solution = await loader.Workspace.OpenSolutionAsync(path);
            return loader;
        }

        public async void Inquery()
        {
            foreach (var project in Solution.Projects.SelectMany(csProject => csProject.Documents))
            {
                var syntaxRoot = await project.GetSyntaxRootAsync();
                var semanticModel = await project.GetSemanticModelAsync();
                if(syntaxRoot != null && semanticModel != null) {
                    var declarations = syntaxRoot.DescendantNodes().OfType<LocalDeclarationStatementSyntax>();
                    foreach (var declaration in declarations)
                    {
                        var symbolInformation = semanticModel.GetSymbolInfo(declaration);
                        var typeSymbol = symbolInformation.Symbol;
                    }
                }
            }
        }
    }
}
