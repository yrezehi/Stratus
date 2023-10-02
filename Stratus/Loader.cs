using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using Stratus.Exceptions;

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

            loader.Workspace.WorkspaceFailed += WorkspaceFailures.OnWorkspaceFailed;

            return loader;
        }

        public Project? GetProject(string name) =>
            Solution.Projects.FirstOrDefault(project => project.Name == name); 

        public async INamedTypeSymbol GetClass(string projectName, string className)
        {
            Project? project = this.GetProject(projectName);

            if (project == null)
                throw new Exception($"Couldn't load project {projectName}");

            Compilation? compilation = await project.GetCompilationAsync();

            if (compilation == null)
                throw new Exception($"Couldn't load compilation for {projectName}");

            INamedTypeSymbol? classTypeSymbol = compilation.GetTypeByMetadataName(className);

            if (classTypeSymbol == null)
                throw new Exception($"Couldn't load named type symbol for {projectName}");

            return classTypeSymbol;
        }
    }
}
