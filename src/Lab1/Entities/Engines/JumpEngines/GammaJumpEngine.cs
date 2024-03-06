using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpEngines;

public class GammaJumpEngine : IJumpEngine
{
    public double JumpFuelConsumption { get; } = 20;
    public double MaxJumpDistance { get; } = 20000;
    public double Weight { get; } = 22222;

    public double TotalFuelConsumption(RouteSegment segment)
    {
        if (segment.Distance > MaxJumpDistance) return double.PositiveInfinity;
        return Math.Pow(segment.Distance, 2) * JumpFuelConsumption;
    }
}