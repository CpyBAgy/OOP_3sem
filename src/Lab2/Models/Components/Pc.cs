namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

public class Pc
{
    public Pc(Motherboard pcMotherboard, Cpu pcCpu, Ram pcRam, Cooler pcCooler, PcCase pcCase, PowerSupply pcPowerSupply, Gpu? pcGpu, Ssd? pcSsd, Hdd? pcHdd)
    {
        PcMotherboard = pcMotherboard;
        PcCpu = pcCpu;
        PcRam = pcRam;
        PcCooler = pcCooler;
        PcCase = pcCase;
        PcPowerSupply = pcPowerSupply;
        PcGpu = pcGpu;
        PcSsd = pcSsd;
        PcHdd = pcHdd;
    }

    public Motherboard PcMotherboard { get; }
    public Cpu PcCpu { get; }
    public Ram PcRam { get; }
    public Cooler PcCooler { get; }
    public PcCase PcCase { get; }
    public PowerSupply PcPowerSupply { get; }
    public Gpu? PcGpu { get; }
    public Ssd? PcSsd { get; }
    public Hdd? PcHdd { get; }
}