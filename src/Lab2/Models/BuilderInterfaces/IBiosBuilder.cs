using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;

public interface IBiosBuilder
{
    IBiosBuilder WithType(string type);
    IBiosBuilder WithProcessorRank(int processorRank);
    Bios Build();
}