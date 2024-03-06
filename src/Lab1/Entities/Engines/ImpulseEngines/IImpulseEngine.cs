using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;

public interface IImpulseEngine
{
    double StartFuelConsumption { get; }
    double MoveFuelConsumption { get; }
    double Weight { get; }

    double TotalFuelConsumption(RouteSegment segment);
}
