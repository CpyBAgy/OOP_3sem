using System;
using Itmo.ObjectOrientedProgramming.Lab4.StrategiesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Strategies;

public class DisconnectStrategy : ICommandStrategy
{
    public void Compile(string[] command)
    {
        try
        {
            ConnectStrategy.CurrentDirectory = null;
        }
        catch (Exception ex)
        {
            throw new CustomCompilationException($"An unexpected error occurred in Compile: {ex.Message}", ex);
        }
    }
}
