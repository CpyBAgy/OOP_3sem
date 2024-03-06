using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.StrategiesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Strategies;

public class ModeStrategy : IModeStrategy
{
    private OutputContext _outputContext;

    public ModeStrategy(IOutputStrategy output)
    {
        _outputContext = new OutputContext(output);
    }

    public void Compile(string command)
    {
        try
        {
            if (ConnectStrategy.CurrentDirectory is null) throw new InvalidOperationException("The directory is not installed.");
            string filePath = Path.Combine(ConnectStrategy.CurrentDirectory, command);
            if (!File.Exists(filePath)) throw new FileNotFoundException($"File not found: {filePath}");
            string content = File.ReadAllText(filePath);
            _outputContext.CompileStrategy(content);
        }
        catch (InvalidOperationException ex)
        {
            throw new CustomCompilationException($"Invalid operation: {ex.Message}", ex);
        }
        catch (FileNotFoundException ex)
        {
            throw new CustomCompilationException($"File not found: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            throw new CustomCompilationException($"An unexpected error occurred in Compile: {ex.Message}", ex);
        }
    }
}
