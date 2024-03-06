using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Strategies;
using Itmo.ObjectOrientedProgramming.Lab4.StrategiesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Factories;

public class AdapterFactory
{
    private Dictionary<string, ICommandStrategy> _strategies;

    public AdapterFactory(IOutputStrategy output)
    {
        _strategies = new Dictionary<string, ICommandStrategy>
        {
            { "connect", new ConnectStrategy() },
            { "disconnect", new DisconnectStrategy() },
            { "treeGoto", new GoToStrategy() },
            { "treeList", new ListStrategy(output) },
            { "fileShow", new ShowStrategy(output) },
            { "fileMove", new MoveStrategy() },
            { "fileCopy", new CopyStrategy() },
            { "fileDelete", new DeleteStrategy() },
            { "fileRename", new RenameStrategy() },
        };
    }

    public ICommandStrategy GetStrategy(string strategyType)
    {
        if (_strategies.TryGetValue(strategyType, out ICommandStrategy? strategy)) return strategy;
        throw new ArgumentException($"Strategy '{strategyType}' not found.");
    }
}
