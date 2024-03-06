using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public interface IShip
{
    public IHull ShipsHull { get; }
    public IImpulseEngine ShipImpulseEngine { get; }
    public IJumpEngine? ShipJumpEngine { get; }
    public bool? ShipAntiNitrinoEmitter { get; }
    public IDeflector? ShipDeflector { get; }
    public PhotinicallyModifiedDeflector? ShipPhotinicallyModifiedDeflector { get; }
    public double? Weight { get; }

    public bool Reflect(IObstacle obstacle, int obstaclesAmount);
}