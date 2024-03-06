using Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentBuilders;

public class BiosBuilder : IBiosBuilder
{
    private string _type = " ";
    private int _processorRank;

    public BiosBuilder() { }

    public BiosBuilder(Bios bios)
    {
        _type = bios.Type;
        _processorRank = bios.ProcessorRank;
    }

    public IBiosBuilder WithType(string type)
    {
        _type = type;
        return this;
    }

    public IBiosBuilder WithProcessorRank(int processorRank)
    {
        _processorRank = processorRank;
        return this;
    }

    public Bios Build()
    {
        return new Bios(_type, 1, _processorRank);
    }
}