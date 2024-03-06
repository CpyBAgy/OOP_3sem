using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Shuttle : IShip
{
    public Shuttle(bool? antiNitrinoEmitter = false)
    {
        ShipsHull = new SmallHull();
        ShipImpulseEngine = new LinearImpulseEngine();
        ShipAntiNitrinoEmitter = antiNitrinoEmitter;

        Weight = ShipsHull.Weight + ShipImpulseEngine.Weight;

        ShipJumpEngine = null;
        ShipDeflector = null;
        ShipPhotinicallyModifiedDeflector = null;
    }

    public IHull ShipsHull { get; }
    public IImpulseEngine ShipImpulseEngine { get; }
    public IJumpEngine? ShipJumpEngine { get; }
    public bool? ShipAntiNitrinoEmitter { get; private set; }
    public IDeflector? ShipDeflector { get; }
    public PhotinicallyModifiedDeflector? ShipPhotinicallyModifiedDeflector { get; }
    public double? Weight { get; }

    public bool Reflect(IObstacle obstacle, int obstaclesAmount)
    {
        double totalDamage = obstacle.Damage * obstaclesAmount;

        return ShipsHull.Reflect(totalDamage);
    }
}