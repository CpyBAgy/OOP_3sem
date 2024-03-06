namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class LargeDeflector : IDeflector
{
    public double Weight { get; } = 40000;
    public double HealthPoints { get; private set; } = 40;
    public bool Reflect(double damage)
    {
        HealthPoints -= damage;
        return HealthPoints >= 0;
    }
}