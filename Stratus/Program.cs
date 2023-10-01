// See https://aka.ms/new-console-template for more information

using Microsoft.CodeAnalysis.CSharp;
using Stratus.Builders.Web.Controllers;

Console.WriteLine(
    ControllerBuilder.Builder("Agent")
        .Build()
    );

Console.WriteLine("Finished Execution!");