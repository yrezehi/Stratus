// See https://aka.ms/new-console-template for more information

using Stratus.Builders;

Console.WriteLine(
    ClassBuilder.Builder()
        .WithSpaceName("Entities")
        .WithName("User")
        .WithImports("ComponentModel.DataAnnotations", "ComponentModel.DataAnnotations.Schema")
        .WithBases("IEntity")
        .Build()
    );

Console.WriteLine("Finished Execution!");