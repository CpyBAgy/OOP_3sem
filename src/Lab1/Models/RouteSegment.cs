using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class RouteSegment
{
    public RouteSegment(IEnvironment environment, int? distance)
    {
        Distance = distance ?? 1000;
        Environment = environment;
    }

    public IEnvironment Environment { get; }
    public int Distance { get; }
}
