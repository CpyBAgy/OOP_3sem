using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;

public class ExponentialImpulseEngine : IImpulseEngine
{
    public double StartFuelConsumption { get; } = 100;
    public double MoveFuelConsumption { get; } = 20;
    public double Weight { get; } = 2323;

    public double TotalFuelConsumption(RouteSegment segment)
    {
        double speed = Math.Exp(segment.Distance);
        return ((segment.Distance * MoveFuelConsumption) / speed) + StartFuelConsumption;
    }
}
