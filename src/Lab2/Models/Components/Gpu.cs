namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

public class Gpu
{
    public Gpu(double height, double width, int frequency, int powerConsumption)
    {
        Height = height;
        Width = width;
        Frequency = frequency;
        PowerConsumption = powerConsumption;
    }

    public double Height { get; }
    public double Width { get; }
    public int Frequency { get; }
    public int PowerConsumption { get; }
}