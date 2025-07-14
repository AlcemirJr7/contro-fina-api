// Script to add a new Entity Framework Core migration

using System;
using System.Diagnostics;

var exemple = "Exemple: dotnet run migration [MigrationName]";

if (Args.Count == 0)
{
    Console.WriteLine($"Migration name should by passed in first arg. {exemple}");
    return;
}

if (Args.Count > 1)
{
    Console.WriteLine($"Expected only 1 arg, was given more than 1. {exemple}");
    return;
}

if (Args[0].Length > 100)
{
    Console.WriteLine("Migration name should by Max. 100 length.");
    return;
}

var startupProject = "./ControlFina.Api";
var targetProject = "./ControlFina.Infrastructure";
var outputMigrationDir = "Database/Migrations";

var comando = $"dotnet ef migrations add {Args[0]} --project {targetProject} --startup-project {startupProject} --output-dir {outputMigrationDir}";

var processo = new Process();

processo.StartInfo.FileName = "cmd.exe";
processo.StartInfo.Arguments = $"/c {comando}";
processo.StartInfo.RedirectStandardOutput = true;
processo.StartInfo.RedirectStandardError = true;
processo.StartInfo.UseShellExecute = false;
processo.StartInfo.CreateNoWindow = true;

processo.OutputDataReceived += (sender, args) =>
{
    if (args.Data != null)
        Console.WriteLine(args.Data);
};

processo.ErrorDataReceived += (sender, args) =>
{
    if (args.Data != null)
        Console.WriteLine($"Error: {args.Data}");
};

processo.Start();
processo.BeginOutputReadLine();
processo.BeginErrorReadLine();
processo.WaitForExit();
