namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class AntimatterExplosion : IObstacle, IReflectCondition
{
    public double Damage { get; } = 1;
    public bool RequiresPhotonicallyModifiedDeflector() { return true; }
    public bool RecommendedAntiNitrinoEmitter() { return false; }
}
