namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

public class PcCase
{
    public PcCase(int motherboardMaxSize, double insideHeight, double insideWidth, double length, double width, double height)
    {
        MotherboardMaxSize = motherboardMaxSize;
        Length = length;
        Width = width;
        Height = height;
        InsideHeight = insideHeight < Width ? insideHeight : Width;
        InsideWidth = insideWidth < Length ? insideWidth : Length;
    }

    public int MotherboardMaxSize { get; }
    public double InsideHeight { get; }
    public double InsideWidth { get; }
    public double Length { get; }
    public double Height { get; }
    public double Width { get; }
}