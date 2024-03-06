using Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentBuilders;

public class CpuBuilder : ICpuBuilder
{
    private int _rank;
    private double _coreFrequency;
    private int _coreAmount;
    private int _socket;
    private bool _onBoardGraphic;
    private int _ramMaxFrequency;
    private int _tdp;
    private int _powerConsumption;

    public CpuBuilder() { }

    public CpuBuilder(Cpu cpu)
    {
        _rank = cpu.Rank;
        _coreFrequency = cpu.CoreFrequency;
        _coreAmount = cpu.CoreAmount;
        _socket = cpu.Socket;
        _onBoardGraphic = cpu.OnBoardGraphic;
        _ramMaxFrequency = cpu.RamMaxFrequency;
        _tdp = cpu.Tdp;
        _powerConsumption = cpu.PowerConsumption;
    }

    public ICpuBuilder WithRank(int rank)
    {
        _rank = rank;
        return this;
    }

    public ICpuBuilder WithCoreFrequency(double coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public ICpuBuilder WithCoreAmount(int coreAmount)
    {
        _coreAmount = coreAmount;
        return this;
    }

    public ICpuBuilder WithSocket(int socket)
    {
        _socket = socket;
        return this;
    }

    public ICpuBuilder WithOnBoardGraphic(bool onBoardGraphic)
    {
        _onBoardGraphic = onBoardGraphic;
        return this;
    }

    public ICpuBuilder WithRamMaxFrequency(int ramMaxFrequency)
    {
        _ramMaxFrequency = ramMaxFrequency;
        return this;
    }

    public ICpuBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ICpuBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Cpu Build()
    {
        return new Cpu(_rank, _coreFrequency, _coreAmount, _socket, _onBoardGraphic, _ramMaxFrequency, _tdp, _powerConsumption);
    }
}