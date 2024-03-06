namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;

public class LargeHull : IHull
{
    public double Weight { get; } = 100000;
    public double HealthPoints { get; private set; } = 20;
    public bool Reflect(double damage)
    {
        HealthPoints -= damage;
        return HealthPoints >= 0;
    }
}