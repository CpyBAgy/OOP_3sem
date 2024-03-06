using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;

public interface IHddBuilder
{
    IHddBuilder WithCapacity(int capacity);
    IHddBuilder WithRpm(int rpm);
    IHddBuilder WithPowerConsumption(int powerConsumption);
    Hdd Build();
}