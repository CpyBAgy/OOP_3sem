using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.StrategiesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Strategies;

public class GoToStrategy : ICommandStrategy
{
    public void Compile(string[] command)
    {
        try
        {
            if (command is null) throw new ArgumentNullException(nameof(command));
            if (command.Length < 2) throw new ArgumentException("Invalid command arguments. Expected at least 2 elements.");
            if (ConnectStrategy.CurrentDirectory is null) return;
            string currentDirectory = Path.Combine(ConnectStrategy.CurrentDirectory, command[1]);
            if (!Directory.Exists(currentDirectory)) throw new DirectoryNotFoundException($"The directory {currentDirectory} does not exist.");
            ConnectStrategy.CurrentDirectory = currentDirectory;
        }
        catch (ArgumentNullException ex)
        {
            throw new CustomCompilationException($"Command is null: {ex.Message}", ex);
        }
        catch (ArgumentException ex)
        {
            throw new CustomCompilationException($"Invalid command arguments: {ex.Message}", ex);
        }
        catch (DirectoryNotFoundException ex)
        {
            throw new CustomCompilationException($"Directory not found: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            throw new CustomCompilationException($"An unexpected error occurred in Compile: {ex.Message}", ex);
        }
    }
}
