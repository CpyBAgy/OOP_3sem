using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentBuilders;

public class CoolerBuilder : ICoolerBuilder
{
    private double _height;
    private int _tdp;
    private IReadOnlyCollection<int>? _supportedSockets;

    public CoolerBuilder() { }

    public CoolerBuilder(Cooler cooler)
    {
        _height = cooler.Height;
        _tdp = cooler.Tdp;
        _supportedSockets = cooler.SupportedSockets;
    }

    public ICoolerBuilder WithHeight(double height)
    {
        _height = height;
        return this;
    }

    public ICoolerBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ICoolerBuilder WithSupportedSockets(Collection<int> supportedSockets)
    {
        _supportedSockets = supportedSockets;
        return this;
    }

    public Cooler Build()
    {
        return new Cooler(_height, _tdp, _supportedSockets ?? throw new ArgumentNullException());
    }
}