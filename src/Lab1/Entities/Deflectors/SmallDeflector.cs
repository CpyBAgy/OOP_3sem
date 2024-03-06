namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class SmallDeflector : IDeflector
{
    public double Weight { get; } = 2000;
    public double HealthPoints { get; private set; } = 2;
    public bool Reflect(double damage)
    {
        HealthPoints -= damage;
        return HealthPoints >= 0;
    }
}