using Itmo.ObjectOrientedProgramming.Lab4.StrategiesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts;

public class CommandContext
{
    private ICommandStrategy _strategy;

    public CommandContext(ICommandStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(ICommandStrategy strategy)
    {
        _strategy = strategy;
    }

    public void CompileStrategy(string[] command)
    {
        _strategy.Compile(command);
    }
}
