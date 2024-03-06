using Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentBuilders;

public class SsdBuilder : ISsdBuilder
{
    private int _capacity;
    private bool _sataConnection;
    private int _readSpeed;
    private int _writeSpeed;
    private int _powerConsumption;

    public SsdBuilder() { }

    public SsdBuilder(Ssd ssd)
    {
        _capacity = ssd.Capacity;
        _sataConnection = ssd.SataConnection;
        _readSpeed = ssd.ReadSpeed;
        _writeSpeed = ssd.WriteSpeed;
        _powerConsumption = ssd.PowerConsumption;
    }

    public ISsdBuilder WithCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public ISsdBuilder WithSataConnection(bool sataConnection)
    {
        _sataConnection = sataConnection;
        return this;
    }

    public ISsdBuilder WithReadSpeed(int readSpeed)
    {
        _readSpeed = readSpeed;
        return this;
    }

    public ISsdBuilder WithWriteSpeed(int writeSpeed)
    {
        _writeSpeed = writeSpeed;
        return this;
    }

    public ISsdBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Ssd Build()
    {
        return new Ssd(_capacity, _sataConnection, _readSpeed, _writeSpeed, _powerConsumption);
    }
}