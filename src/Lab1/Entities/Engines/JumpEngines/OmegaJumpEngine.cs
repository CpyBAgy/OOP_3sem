using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpEngines;

public class OmegaJumpEngine : IJumpEngine
{
    public double JumpFuelConsumption { get; } = 20;
    public double MaxJumpDistance { get; } = 30000;
    public double Weight { get; } = 33333;

    public double TotalFuelConsumption(RouteSegment segment)
    {
        if (segment.Distance > MaxJumpDistance) return double.PositiveInfinity;
        return Math.Exp(segment.Distance) * JumpFuelConsumption;
    }
}