using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;

public interface ICpuBuilder
{
    ICpuBuilder WithRank(int rank);
    ICpuBuilder WithCoreFrequency(double coreFrequency);
    ICpuBuilder WithCoreAmount(int coreAmount);
    ICpuBuilder WithSocket(int socket);
    ICpuBuilder WithOnBoardGraphic(bool onBoardGraphic);
    ICpuBuilder WithRamMaxFrequency(int ramMaxFrequency);
    ICpuBuilder WithTdp(int tdp);
    ICpuBuilder WithPowerConsumption(int powerConsumption);
    Cpu Build();
}