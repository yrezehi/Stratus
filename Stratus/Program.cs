// See https://aka.ms/new-console-template for more information

using Microsoft.CodeAnalysis.CSharp;
using Stratus.Builders.Roslyn.Web.Controllers;
using Stratus.Builders.Roslyn.Web.Entity;

Console.WriteLine(
    ControllerBuilder.Builder("Agent")
        .Build()
    );

Console.WriteLine("Finished Execution!");