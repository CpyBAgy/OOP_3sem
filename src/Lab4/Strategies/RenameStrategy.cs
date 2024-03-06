using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.StrategiesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Strategies;

public class RenameStrategy : ICommandStrategy
{
    public void Compile(string[] command)
    {
        try
        {
            if (command is null) throw new ArgumentNullException(nameof(command));
            if (command.Length < 3) throw new ArgumentException("Invalid command arguments. Expected at least 3 elements.");
            if (ConnectStrategy.CurrentDirectory is null) return;
            string oldPath = Path.Combine(ConnectStrategy.CurrentDirectory, command[1]);
            string fileName = command[2];
            string? directoryPath = Path.GetDirectoryName(oldPath);
            if (directoryPath is not null)
            {
                string newPath = Path.Combine(directoryPath, fileName);
                if (File.Exists(oldPath))
                {
                    File.Move(oldPath, newPath);
                }
                else if (Directory.Exists(oldPath))
                {
                    Directory.Move(oldPath, newPath);
                }
                else
                {
                    throw new FileNotFoundException($"Path {oldPath} not found");
                }
            }
            else
            {
                throw new InvalidOperationException("Unable to get the directory of the file.");
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
        catch (InvalidOperationException ex)
        {
            throw new CustomCompilationException($"Invalid operation: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            throw new CustomCompilationException($"An unexpected error occurred in Compile: {ex.Message}", ex);
        }
    }
}
