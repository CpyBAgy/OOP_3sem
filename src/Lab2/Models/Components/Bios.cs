namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

public class Bios
{
    public Bios(string type, int version, int processorRank)
    {
        Type = type;
        Version = version;
        ProcessorRank = processorRank;
    }

    public string Type { get; }
    public int Version { get; private set; }
    public int ProcessorRank { get; private set; }

    public Bios Update(int processorRank)
    {
        ProcessorRank = processorRank;
        Version++;
        return this;
    }
}