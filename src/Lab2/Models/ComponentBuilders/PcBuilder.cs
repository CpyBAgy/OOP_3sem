using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentBuilders;

public class PcBuilder : IPcBuilder
{
    private Motherboard? _pcMotherboard;
    private Cpu? _pcCpu;
    private Ram? _pcRam;
    private Cooler? _pcCooler;
    private PcCase? _pcCase;
    private PowerSupply? _pcPowerSupply;
    private Gpu? _pcGpu;
    private Ssd? _pcSsd;
    private Hdd? _pcHdd;

    public PcBuilder() { }

    public PcBuilder(Pc pc)
    {
        _pcMotherboard = pc.PcMotherboard;
        _pcCpu = pc.PcCpu;
        _pcRam = pc.PcRam;
        _pcCooler = pc.PcCooler;
        _pcCase = pc.PcCase;
        _pcPowerSupply = pc.PcPowerSupply;
        _pcGpu = pc.PcGpu;
        _pcSsd = pc.PcSsd;
        _pcHdd = pc.PcHdd;
    }

    public IPcBuilder WithMotherboard(Motherboard motherboard)
    {
        _pcMotherboard = motherboard;
        return this;
    }

    public IPcBuilder WithCpu(Cpu cpu)
    {
        _pcCpu = cpu;
        return this;
    }

    public IPcBuilder WithRam(Ram ram)
    {
        _pcRam = ram;
        return this;
    }

    public IPcBuilder WithCooler(Cooler cooler)
    {
        _pcCooler = cooler;
        return this;
    }

    public IPcBuilder WithPcCase(PcCase pcCase)
    {
        _pcCase = pcCase;
        return this;
    }

    public IPcBuilder WithPowerSupply(PowerSupply powerSupply)
    {
        _pcPowerSupply = powerSupply;
        return this;
    }

    public IPcBuilder WithGpu(Gpu? gpu)
    {
        _pcGpu = gpu;
        return this;
    }

    public IPcBuilder WithSsd(Ssd? ssd)
    {
        _pcSsd = ssd;
        return this;
    }

    public IPcBuilder WithHdd(Hdd? hdd)
    {
        _pcHdd = hdd;
        return this;
    }

    public Pc Build()
    {
        if (_pcMotherboard is null || _pcCpu is null || _pcRam is null || _pcCooler is null || _pcCase is null || _pcPowerSupply is null) throw new ArgumentNullException();
        return new Pc(_pcMotherboard, _pcCpu, _pcRam, _pcCooler, _pcCase, _pcPowerSupply, _pcGpu, _pcSsd, _pcHdd);
    }
}
