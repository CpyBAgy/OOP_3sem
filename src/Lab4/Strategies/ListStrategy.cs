using System;
using System.Globalization;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.StrategiesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Strategies;

public class ListStrategy : ICommandStrategy
{
    private OutputContext _outputContext;

    public ListStrategy(IOutputStrategy output)
    {
        _outputContext = new OutputContext(output);
    }

    public void Compile(string[] command)
    {
        try
        {
            if (command is null) throw new ArgumentNullException(nameof(command));
            if (command.Length < 2) throw new ArgumentException("Invalid command arguments");
            if (command[1] != "-d") return;
            int depth = command.Length > 2 ? int.Parse(command[2], CultureInfo.InvariantCulture) : 1;
            if (ConnectStrategy.CurrentDirectory is not null) ListDirectories(ConnectStrategy.CurrentDirectory, depth);
        }
        catch (ArgumentException ex)
        {
            throw new CustomCompilationException($"Invalid arguments for ListDirectories: {ex.Message}", ex);
        }
        catch (FormatException ex)
        {
            throw new CustomCompilationException($"Invalid depth format: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            throw new CustomCompilationException($"An unexpected error occurred in ListDirectories: {ex.Message}", ex);
        }
    }

    private void ListDirectories(string directoryPath, int depth, string prefix = "")
    {
        if (depth < 0) return;
        _outputContext.CompileStrategy(prefix + (string.IsNullOrEmpty(prefix) ? null : "├── ") + Path.GetFileName(directoryPath));
        string[] directories = Directory.GetDirectories(directoryPath);
        for (int i = 0; i < directories.Length; i++)
        {
            string directory = directories[i];
            string subPrefix = prefix + (i < directories.Length - 1 ? "│   " : "    ");
            ListDirectories(directory, depth - 1, subPrefix);
        }
    }
}
