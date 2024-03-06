using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpEngines;

public class AlphaJumpEngine : IJumpEngine
{
    public double JumpFuelConsumption { get; } = 20;
    public double MaxJumpDistance { get; } = 10000;
    public double Weight { get; } = 11111;

    public double TotalFuelConsumption(RouteSegment segment)
    {
        if (segment.Distance > MaxJumpDistance) return double.PositiveInfinity;
        return segment.Distance * JumpFuelConsumption;
    }
}
