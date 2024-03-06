using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;

public interface IRamBuilder
{
    IRamBuilder WithDdrStandard(string ddrStandard);
    IRamBuilder WithFrequency(int frequency);
    IRamBuilder WithStandard(int standard);
    IRamBuilder WithPowerConsumption(int powerConsumption);
    Ram Build();
}