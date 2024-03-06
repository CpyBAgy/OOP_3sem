using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;

public interface IPowerSupplyBuilder
{
    IPowerSupplyBuilder WithPowerCapacity(int powerCapacity);
    PowerSupply Build();
}