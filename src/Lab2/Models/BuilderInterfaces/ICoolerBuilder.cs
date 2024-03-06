using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;

public interface ICoolerBuilder
{
    ICoolerBuilder WithHeight(double height);
    ICoolerBuilder WithTdp(int tdp);
    ICoolerBuilder WithSupportedSockets(Collection<int> supportedSockets);
    Cooler Build();
}