namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

public class Ram
{
    public Ram(string ddrStandard, int frequency, int standard, int powerConsumption)
    {
        DdrStandard = ddrStandard;
        Frequency = frequency;
        Standard = standard;
        PowerConsumption = powerConsumption;
    }

    public string DdrStandard { get; }
    public int Frequency { get; }
    public int Standard { get; }
    public int PowerConsumption { get; }
}