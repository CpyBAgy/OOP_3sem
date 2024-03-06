namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;

public class MediumHull : IHull
{
    public double Weight { get; } = 25000;
    public double HealthPoints { get; private set; } = 5;
    public bool Reflect(double damage)
    {
        HealthPoints -= damage;
        return HealthPoints >= 0;
    }
}