namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;

public class SmallHull : IHull
{
    public double Weight { get; } = 5000;
    public double HealthPoints { get; private set; } = 1;
    public bool Reflect(double damage)
    {
        HealthPoints -= damage;
        return HealthPoints >= 0;
    }
}