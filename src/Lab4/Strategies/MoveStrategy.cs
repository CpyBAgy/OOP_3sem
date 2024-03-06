using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.StrategiesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Strategies;

public class MoveStrategy : ICommandStrategy
{
    public void Compile(string[] command)
    {
        try
        {
            if (command is null) throw new ArgumentNullException(nameof(command));
            if (command.Length < 3) throw new ArgumentException("Invalid command arguments. Expected at least 3 elements.");
            if (ConnectStrategy.CurrentDirectory is null) return;
            string sourcePath = Path.Combine(ConnectStrategy.CurrentDirectory, command[1]);
            string destinationPath = Path.Combine(ConnectStrategy.CurrentDirectory, command[2]);
            if (File.Exists(sourcePath))
            {
                if (Directory.Exists(destinationPath)) destinationPath = Path.Combine(destinationPath, Path.GetFileName(sourcePath));
                File.Move(sourcePath, destinationPath);
            }
            else if (Directory.Exists(sourcePath))
            {
                Directory.Move(sourcePath, destinationPath);
            }
            else
            {
                throw new FileNotFoundException($"Source {sourcePath} not found");
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
            throw new CustomCompilationException($"Source file not found: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            throw new CustomCompilationException($"An unexpected error occurred in Compile: {ex.Message}", ex);
        }
    }
}
