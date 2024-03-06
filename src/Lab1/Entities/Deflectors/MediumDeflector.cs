namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class MediumDeflector : IDeflector
{
    public double Weight { get; } = 10000;
    public double HealthPoints { get; private set; } = 10;
    public bool Reflect(double damage)
    {
        HealthPoints -= damage;
        return HealthPoints >= 0;
    }
}