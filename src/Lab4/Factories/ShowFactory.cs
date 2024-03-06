using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Strategies;
using Itmo.ObjectOrientedProgramming.Lab4.StrategiesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Factories;

public class ShowFactory
{
    private Dictionary<string, IModeStrategy> _strategies;

    public ShowFactory(IOutputStrategy output)
    {
        _strategies = new Dictionary<string, IModeStrategy> { { "console", new ModeStrategy(output) }, };
    }

    public IModeStrategy GetStrategy(string modeType)
    {
        if (_strategies.TryGetValue(modeType, out IModeStrategy? strategy)) return strategy;
        throw new ArgumentException($"'{modeType}' mode not found.");
    }
}