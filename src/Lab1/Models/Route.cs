using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Route
{
    public Route(params RouteSegment[] route)
    {
        Segments = route.Where(segment => segment.Distance >= 0);
    }

    public IEnumerable<RouteSegment> Segments { get; }

    public double Length()
    {
        return Segments.Sum(segment => segment.Distance);
    }

    public bool ContainsEnvironment(IEnvironment environment)
    {
        return Segments.Any(segment => segment.Environment == environment);
    }

    public bool ContainsSegment(RouteSegment routeSegment)
    {
        return Segments.Any(segment => segment == routeSegment);
    }
}