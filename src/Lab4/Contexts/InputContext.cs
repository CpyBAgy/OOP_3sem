using Itmo.ObjectOrientedProgramming.Lab4.StrategiesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts;

public class InputContext
{
    private IInputStrategy _strategy;

    public InputContext(IInputStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IInputStrategy strategy)
    {
        _strategy = strategy;
    }

    public string CompileStrategy()
    {
        return _strategy.Compile();
    }
}