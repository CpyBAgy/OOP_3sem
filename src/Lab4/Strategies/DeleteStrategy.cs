using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.StrategiesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Strategies;

public class DeleteStrategy : ICommandStrategy
{
    public void Compile(string[] command)
    {
        try
        {
            if (command is null) throw new ArgumentNullException(nameof(command));
            if (command.Length < 2) throw new ArgumentException("Invalid command arguments. Expected at least 2 elements.");
            if (ConnectStrategy.CurrentDirectory is null) return;
            string path = Path.Combine(ConnectStrategy.CurrentDirectory, command[1]);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            else if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            else
            {
                throw new FileNotFoundException($"Path {path} not found");
            }
        }
        catch (ArgumentNullException ex)
        {
            throw new CustomCompilationException($"Command is null: {ex.Message}", ex);
        }
        catch (ArgumentException ex)
        {
            throw new CustomCompilationException($"Invalid command arguments: {ex.Message}", ex);
        }
        catch (FileNotFoundException ex)
        {
            throw new CustomCompilationException($"File or directory not found: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            throw new CustomCompilationException($"An unexpected error occurred in Compile: {ex.Message}", ex);
        }
    }
}
