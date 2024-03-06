namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

public class Ssd
{
    public Ssd(int capacity, bool sataConnection, int readSpeed, int writeSpeed, int powerConsumption)
    {
        Capacity = capacity;
        SataConnection = sataConnection;
        ReadSpeed = readSpeed;
        WriteSpeed = writeSpeed;
        PowerConsumption = powerConsumption;
    }

    public bool SataConnection { get; }
    public int Capacity { get; }
    public int ReadSpeed { get; }
    public int WriteSpeed { get; }
    public int PowerConsumption { get; }
}