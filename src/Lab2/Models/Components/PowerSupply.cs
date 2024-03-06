namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

public class PowerSupply
{
    public PowerSupply(int powerCapacity)
    {
        PowerCapacity = powerCapacity;
    }

    public int PowerCapacity { get; }
}