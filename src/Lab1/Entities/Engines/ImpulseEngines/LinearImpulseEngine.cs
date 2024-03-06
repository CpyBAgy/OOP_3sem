using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;

public class LinearImpulseEngine : IImpulseEngine
{
    public double StartFuelConsumption { get; } = 10;
    public double MoveFuelConsumption { get; } = 5;
    public double Weight { get; } = 1212;

    public double TotalFuelConsumption(RouteSegment segment)
    {
        const double speed = 100;
        return ((segment.Distance * MoveFuelConsumption) / speed) + StartFuelConsumption;
    }
}
