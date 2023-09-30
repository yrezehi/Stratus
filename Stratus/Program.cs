// See https://aka.ms/new-console-template for more information

using Stratus.Generator;

Console.WriteLine(
    ClassBuilder.Builder()
        .WithSpaceName("Entities")
        .WithName("User")
        .WithUsing("ComponentModel.DataAnnotations", "ComponentModel.DataAnnotations.Schema")
        .WithBase("IEntity")
        .Build()
    );

Console.WriteLine("Finished Execution!");