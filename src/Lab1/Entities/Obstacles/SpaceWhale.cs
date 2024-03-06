namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class SpaceWhale : IObstacle, IReflectCondition
{
    public double Damage { get; } = 40;
    public bool RequiresPhotonicallyModifiedDeflector() { return false; }
    public bool RecommendedAntiNitrinoEmitter() { return true; }
}
