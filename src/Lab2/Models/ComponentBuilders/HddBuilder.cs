using Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentBuilders;

public class HddBuilder : IHddBuilder
{
    private int _capacity;
    private int _rpm;
    private int _powerConsumption;

    public HddBuilder() { }

    public HddBuilder(Hdd hdd)
    {
        _capacity = hdd.Capacity;
        _rpm = hdd.Rpm;
        _powerConsumption = hdd.PowerConsumption;
    }

    public IHddBuilder WithCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public IHddBuilder WithRpm(int rpm)
    {
        _rpm = rpm;
        return this;
    }

    public IHddBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Hdd Build()
    {
        return new Hdd(_capacity, _rpm, _powerConsumption);
    }
}