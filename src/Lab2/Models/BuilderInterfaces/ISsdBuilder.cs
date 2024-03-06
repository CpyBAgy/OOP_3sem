using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;

public interface ISsdBuilder
{
    ISsdBuilder WithCapacity(int capacity);
    ISsdBuilder WithSataConnection(bool sataConnection);
    ISsdBuilder WithReadSpeed(int readSpeed);
    ISsdBuilder WithWriteSpeed(int writeSpeed);
    ISsdBuilder WithPowerConsumption(int powerConsumption);
    Ssd Build();
}