using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Strategies;
using Itmo.ObjectOrientedProgramming.Lab4.StrategiesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Factories;

public class ModeFactory
{
    private Dictionary<string, IModeStrategy> _strategies;

    public ModeFactory()
    {
        _strategies = new Dictionary<string, IModeStrategy> { { "local", new LocalModeStrategy() }, };
    }

    public IModeStrategy GetStrategy(string modeType)
    {
        if (_strategies.TryGetValue(modeType, out IModeStrategy? strategy)) return strategy;
        throw new ArgumentException($"'{modeType}' mode not found.");
    }
}