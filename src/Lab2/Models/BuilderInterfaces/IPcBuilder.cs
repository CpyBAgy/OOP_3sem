using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;

public interface IPcBuilder
{
    IPcBuilder WithMotherboard(Motherboard motherboard);
    IPcBuilder WithCpu(Cpu cpu);
    IPcBuilder WithRam(Ram ram);
    IPcBuilder WithCooler(Cooler cooler);
    IPcBuilder WithPcCase(PcCase pcCase);
    IPcBuilder WithPowerSupply(PowerSupply powerSupply);
    IPcBuilder WithGpu(Gpu? gpu);
    IPcBuilder WithSsd(Ssd? ssd);
    IPcBuilder WithHdd(Hdd? hdd);
    Pc Build();
}