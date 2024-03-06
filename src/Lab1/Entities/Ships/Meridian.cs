using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Meridian : IShip
{
    public Meridian(PhotinicallyModifiedDeflector? photinicallyModifiedDeflector = null, bool? antiNitrinoEmitter = true)
    {
        ShipsHull = new MediumHull();

        ShipImpulseEngine = new ExponentialImpulseEngine();
        ShipJumpEngine = null;

        ShipAntiNitrinoEmitter = antiNitrinoEmitter;

        ShipDeflector = new MediumDeflector();
        ShipPhotinicallyModifiedDeflector = photinicallyModifiedDeflector;

        Weight = ShipsHull.Weight + ShipImpulseEngine.Weight + ShipDeflector.Weight +
                 ShipPhotinicallyModifiedDeflector?.Weight;
    }

    public IHull ShipsHull { get; }
    public IImpulseEngine ShipImpulseEngine { get; }
    public IJumpEngine? ShipJumpEngine { get; }
    public bool? ShipAntiNitrinoEmitter { get; }
    public IDeflector? ShipDeflector { get; }
    public PhotinicallyModifiedDeflector? ShipPhotinicallyModifiedDeflector { get; }
    public double? Weight { get; }

    public bool Reflect(IObstacle obstacle, int obstaclesAmount)
    {
        double totalDamage = obstacle.Damage * obstaclesAmount;
        if (obstacle is IReflectCondition specialObstacle)
        {
            if (specialObstacle.RecommendedAntiNitrinoEmitter() && ShipAntiNitrinoEmitter == true) return true;
            if (specialObstacle.RequiresPhotonicallyModifiedDeflector()) return ShipPhotinicallyModifiedDeflector != null && ShipPhotinicallyModifiedDeflector.Reflect(totalDamage);
        }

        if (ShipDeflector == null) return ShipsHull.Reflect(totalDamage);
        double hullDamage = (totalDamage >= ShipDeflector.HealthPoints) ? totalDamage - ShipDeflector.HealthPoints : 0;

        return ShipDeflector.Reflect(totalDamage) || ShipsHull.Reflect(hullDamage);
    }
}