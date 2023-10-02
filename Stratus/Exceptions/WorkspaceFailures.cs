using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratus.Exceptions
{
    public static class WorkspaceFailures
    {
        public static void OnWorkspaceFailed(object? sender, WorkspaceDiagnosticEventArgs @event)
        {
            Console.WriteLine(@event.Diagnostic.Message);
        }
    }
}
