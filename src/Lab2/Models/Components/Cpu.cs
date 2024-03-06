namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

public class Cpu
{
    public Cpu(int rank, double coreFrequency, int coreAmount, int socket, bool onBoardGraphic, int ramMaxFrequency, int tdp, int powerConsumption)
    {
        Rank = rank;
        CoreFrequency = coreFrequency;
        CoreAmount = coreAmount;
        Socket = socket;
        OnBoardGraphic = onBoardGraphic;
        RamMaxFrequency = ramMaxFrequency;
        Tdp = tdp;
        PowerConsumption = powerConsumption;
    }

    public double CoreFrequency { get; }
    public int CoreAmount { get; }
    public int Socket { get; }
    public bool OnBoardGraphic { get; }
    public int RamMaxFrequency { get; }
    public int Tdp { get; }
    public int Rank { get; }
    public int PowerConsumption { get; }
}