using Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentBuilders;

public class RamBuilder : IRamBuilder
{
    private string _ddrStandard = " ";
    private int _frequency;
    private int _standard;
    private int _powerConsumption;

    public RamBuilder() { }

    public RamBuilder(Ram ram)
    {
        _ddrStandard = ram.DdrStandard;
        _frequency = ram.Frequency;
        _standard = ram.Standard;
        _powerConsumption = ram.PowerConsumption;
    }

    public IRamBuilder WithDdrStandard(string ddrStandard)
    {
        _ddrStandard = ddrStandard;
        return this;
    }

    public IRamBuilder WithFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public IRamBuilder WithStandard(int standard)
    {
        _standard = standard;
        return this;
    }

    public IRamBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Ram Build()
    {
        return new Ram(_ddrStandard, _frequency, _standard, _powerConsumption);
    }
}