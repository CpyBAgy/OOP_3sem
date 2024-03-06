namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

public class Motherboard
{
    public Motherboard(int size, int socket, int pciAmount, int sataAmount, int ramMaxFrequency, int ramAmount, int ramStandard, Bios bios)
    {
        Size = size;
        Socket = socket;
        PciAmount = pciAmount;
        SataAmount = sataAmount;
        RamMaxFrequency = ramMaxFrequency;
        RamStandard = ramStandard;
        RamAmount = ramAmount;
        Bios = bios;
    }

    public int Socket { get; }
    public int PciAmount { get; }
    public int SataAmount { get; }
    public int RamMaxFrequency { get; }
    public int RamStandard { get; }
    public int RamAmount { get; }
    public int Size { get; }
    public Bios? Bios { get; }
}