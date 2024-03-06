using System;
using Itmo.ObjectOrientedProgramming.Lab4.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.StrategiesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Strategies;

public class ShowStrategy : ICommandStrategy
{
    private IOutputStrategy _output;

    public ShowStrategy(IOutputStrategy output)
    {
        _output = output;
    }

    public void Compile(string[] command)
    {
        try
        {
            if (command is null) throw new ArgumentNullException(nameof(command));
            if (command.Length < 4) throw new ArgumentException("Invalid command arguments. Expected at least 4 elements.");
            if (ConnectStrategy.CurrentDirectory is null) return;
            var factory = new ShowFactory(_output);
            IModeStrategy modeStrategy = factory.GetStrategy(command[3]);
            modeStrategy.Compile(command[1]);
        }
        catch (ArgumentNullException ex)
        {
            throw new CustomCompilationException($"Command is null: {ex.Message}", ex);
        }
        catch (ArgumentException ex)
        {
            throw new CustomCompilationException($"Invalid command arguments: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            throw new CustomCompilationException($"An unexpected error occurred in Compile: {ex.Message}", ex);
        }
    }
}
