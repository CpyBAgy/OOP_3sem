using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpEngines;

public interface IJumpEngine
{
    double JumpFuelConsumption { get; }
    double MaxJumpDistance { get; }
    double Weight { get; }

    double TotalFuelConsumption(RouteSegment segment);
}