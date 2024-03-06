using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class Configurator
{
    private Motherboard _motherboard;
    private Cpu? _cpu;
    private Cooler? _cooler;
    private Gpu? _gpu;
    private Hdd? _hdd;
    private PcCase? _pcCase;
    private PowerSupply? _powerSupply;
    private Ram? _ram;
    private Ssd? _ssd;

    public Configurator(Motherboard pcMotherboard, Cpu? pcCpu, Ram? pcRam, Cooler? pcCooler, PcCase? pcCase, PowerSupply? pcPowerSupply, Gpu? pcGpu, Ssd? pcSsd, Hdd? pcHdd)
    {
        _motherboard = pcMotherboard;
        _cpu = pcCpu;
        _cooler = pcCooler;
        _gpu = pcGpu;
        _pcCase = pcCase;
        _powerSupply = pcPowerSupply;
        _ram = pcRam;
        _ssd = pcSsd;
        _hdd = pcHdd;
    }

    public Pc Configure()
    {
        SelectCpuPack().SelectGpu().SelectRam().SelectPcCase();
        if (_cpu?.OnBoardGraphic is false) SelectGpu();
        if (_hdd is null && _ssd is null) SelectHdd();
        SelectPowerSupply();
        return new Pc(
            _motherboard,
            _cpu ?? throw new ArgumentNullException(),
            _ram ?? throw new ArgumentNullException(),
            _cooler ?? throw new ArgumentNullException(),
            _pcCase ?? throw new ArgumentNullException(),
            _powerSupply ?? throw new ArgumentNullException(),
            _gpu,
            _ssd,
            _hdd);
    }

    private int TotalPowerConsumption()
    {
        return (_cpu?.PowerConsumption ?? 0) +
               (_gpu?.PowerConsumption ?? 0) +
               (_ram?.PowerConsumption * _motherboard.RamAmount ?? 0) +
               (_hdd?.PowerConsumption ?? 0) +
               (_ssd?.PowerConsumption ?? 0);
    }

    private Configurator SelectCpuPack()
    {
        _cpu ??= AllComponentsRepo.Cpus.FindAll(cpu => cpu.Socket == _motherboard.Socket)
            .MinBy(cpu => cpu.PowerConsumption);
        if (_cpu is null) return this;
        _cooler ??= AllComponentsRepo.Coolers
            .FindAll(cooler => cooler.Tdp >= _cpu.Tdp)
            .Where(cooler => cooler.SupportedSockets?.Contains(_cpu.Socket) ?? false)
            .MinBy(cooler => cooler.Height);
        return this;
    }

    private Configurator SelectHdd()
    {
        _hdd ??= AllComponentsRepo.Hdds.FindAll(_ => true)
            .MinBy(hdd => hdd.PowerConsumption);
        return this;
    }

    private Configurator SelectSsd()
    {
        _ssd ??= AllComponentsRepo.Ssds.FindAll(_ => true)
            .MinBy(ssd => ssd.PowerConsumption);
        return this;
    }

    private Configurator SelectPcCase()
    {
        _pcCase ??= AllComponentsRepo.PcCases
            .FindAll(pcCase => pcCase.MotherboardMaxSize >= _motherboard.Size)
            .Where(pcCase => pcCase.InsideHeight >= _gpu?.Height
                             && pcCase.InsideHeight >= _cooler?.Height
                             && pcCase.InsideWidth >= _gpu?.Width)
            .MinBy(pcCase => pcCase.Height * pcCase.Width * pcCase.Length);
        return this;
    }

    private Configurator SelectGpu()
    {
        _gpu ??= AllComponentsRepo.Gpus.FindAll(_ => true)
            .MinBy(gpu => gpu.PowerConsumption);
        return this;
    }

    private Configurator SelectRam()
    {
        _ram ??= AllComponentsRepo.Rams.FindAll(ram => ram.Standard == _motherboard.RamStandard)
            .MinBy(ram => ram.PowerConsumption);
        return this;
    }

    private Configurator SelectPowerSupply()
    {
        _powerSupply ??= AllComponentsRepo.PowerSupplies.FindAll(obj => obj.PowerCapacity > TotalPowerConsumption())
            .MinBy(obj => obj.PowerCapacity);
        return this;
    }
}