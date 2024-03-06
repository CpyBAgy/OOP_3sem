namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class PhotinicallyModifiedDeflector
{
    public double Weight { get; } = 87879;
    public double SpecialHealthPoints { get; private set; } = 3;

    public bool Reflect(double specialDamage)
    {
        SpecialHealthPoints -= specialDamage;
        return SpecialHealthPoints >= 0;
    }
}