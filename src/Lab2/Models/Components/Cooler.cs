using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

public class Cooler
{
    public Cooler(double height, int tdp, IReadOnlyCollection<int> supportedSockets)
    {
        Height = height;
        Tdp = tdp;
        SupportedSockets = supportedSockets;
    }

    public double Height { get; }
    public IReadOnlyCollection<int>? SupportedSockets { get; }
    public int Tdp { get; }
}