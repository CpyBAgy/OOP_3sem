using System;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.StrategiesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Compilator
{
    public static void Compile(string command, IOutputStrategy output)
    {
        if (command is null) throw new ArgumentNullException(nameof(command), "Command cannot be null");
        string[] split = command.Split(' ');
        var factory = new AdapterFactory(output);
        ICommandStrategy connectStrategy = factory.GetStrategy(split[0]);
        var context = new CommandContext(connectStrategy);
        context.CompileStrategy(split);
    }
}
