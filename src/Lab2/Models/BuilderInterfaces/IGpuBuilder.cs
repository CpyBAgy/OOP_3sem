using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;

public interface IGpuBuilder
{
    IGpuBuilder WithHeight(double height);
    IGpuBuilder WithWidth(double width);
    IGpuBuilder WithFrequency(int frequency);
    IGpuBuilder WithPowerConsumption(int powerConsumption);
    Gpu Build();
}