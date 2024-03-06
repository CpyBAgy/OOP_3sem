using Itmo.ObjectOrientedProgramming.Lab4.StrategiesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts;

public class OutputContext
{
    private IOutputStrategy _strategy;

    public OutputContext(IOutputStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IOutputStrategy strategy)
    {
        _strategy = strategy;
    }

    public void CompileStrategy(string message)
    {
        _strategy.Compile(message);
    }
}