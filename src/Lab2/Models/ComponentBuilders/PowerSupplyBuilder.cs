using Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentBuilders;

public class PowerSupplyBuilder : IPowerSupplyBuilder
{
    private int _powerCapacity;

    public PowerSupplyBuilder() { }

    public PowerSupplyBuilder(PowerSupply powerSupply)
    {
        _powerCapacity = powerSupply.PowerCapacity;
    }

    public IPowerSupplyBuilder WithPowerCapacity(int powerCapacity)
    {
        _powerCapacity = powerCapacity;
        return this;
    }

    public PowerSupply Build()
    {
        return new PowerSupply(_powerCapacity);
    }
}