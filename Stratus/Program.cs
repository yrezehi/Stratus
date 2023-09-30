﻿// See https://aka.ms/new-console-template for more information

using Microsoft.CodeAnalysis.CSharp;
using Stratus.Builders;

Console.WriteLine(
    EntityBuilder.Builder()
        .WithSpaceName("Entities")
        .WithName("User")
        .WithImports("ComponentModel.DataAnnotations", "ComponentModel.DataAnnotations.Schema")
        .WithBases("IEntity")
        .Build()
    );

Console.WriteLine("Finished Execution!");