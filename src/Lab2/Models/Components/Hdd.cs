namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

public class Hdd
{
    public Hdd(int capacity, int rpm, int powerConsumption)
    {
        Capacity = capacity;
        Rpm = rpm;
        PowerConsumption = powerConsumption;
    }

    public int Capacity { get; }
    public int Rpm { get; }
    public int PowerConsumption { get; }
}