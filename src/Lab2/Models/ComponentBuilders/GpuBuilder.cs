using Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentBuilders;

public class GpuBuilder : IGpuBuilder
{
    private double _height;
    private double _width;
    private int _frequency;
    private int _powerConsumption;

    public GpuBuilder() { }

    public GpuBuilder(Gpu gpu)
    {
        _height = gpu.Height;
        _width = gpu.Width;
        _frequency = gpu.Frequency;
        _powerConsumption = gpu.PowerConsumption;
    }

    public IGpuBuilder WithHeight(double height)
    {
        _height = height;
        return this;
    }

    public IGpuBuilder WithWidth(double width)
    {
        _width = width;
        return this;
    }

    public IGpuBuilder WithFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public IGpuBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Gpu Build()
    {
        return new Gpu(_height, _width, _frequency, _powerConsumption);
    }
}