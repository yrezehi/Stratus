using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
using Stratus.Exceptions;

namespace Stratus
{
    public class MSLoader {
    
        private MSBuildWorkspace Workspace;
        private Solution Solution;

        private static string SOLUTION_PATTERN = "*.sln";

        public static async Task<MSLoader> Load(string path) {
            MSBuildLocator.RegisterDefaults();
            MSLoader loader = new MSLoader();

            loader.Workspace = MSBuildWorkspace.Create();
            loader.Solution = await loader.Workspace.OpenSolutionAsync(path);

            loader.Workspace.WorkspaceFailed += WorkspaceFailures.OnWorkspaceFailed;

            return loader;
        }

        public Project? GetProject(string name) =>
            Solution.Projects.FirstOrDefault(project => project.Name == name); 

        public async Task<SyntaxNode> GetClass(string projectName, string className)
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

            return classTypeSymbol.DeclaringSyntaxReferences[0].GetSyntax();
        }

        public string SolutionGlobbing(string directoryPath)
        {
            PatternMatchingResult matcherResult = new Matcher().AddInclude(SOLUTION_PATTERN).Execute(new DirectoryInfoWrapper(new DirectoryInfo(directoryPath)));

            if (!matcherResult.HasMatches)
            {
                throw new Exception($"No matches found for any solution under {directoryPath}");
            }

            return matcherResult.Files.FirstOrDefault().Path;
        }
    }
}
