using System;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.StrategiesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Strategies;

public class LocalModeStrategy : IModeStrategy
{
    private OutputContext _outputContext;

    public LocalModeStrategy()
    {
        _outputContext = new OutputContext(new OutputStrategy());
    }

    public void Compile(string command)
    {
        try
        {
            ConnectStrategy.CurrentDirectory = command;
            _outputContext.CompileStrategy($"Connected to directory: {ConnectStrategy.CurrentDirectory}");
        }
        catch (Exception ex)
        {
            throw new CustomCompilationException($"An unexpected error occurred in Compile: {ex.Message}", ex);
        }
    }
}
