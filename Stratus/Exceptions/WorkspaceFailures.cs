using Microsoft.CodeAnalysis;

namespace Stratus.Exceptions
{
    public static class WorkspaceFailures
    {
        public static void OnWorkspaceFailed(object? sender, WorkspaceDiagnosticEventArgs @event) =>
            Console.WriteLine(@event.Diagnostic.Message);
    }
}
