using Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentBuilders;

public class PcCaseBuilder : IPcCaseBuilder
{
    private int _motherboardMaxSize;
    private double _insideHeight;
    private double _insideWidth;
    private double _length;
    private double _width;
    private double _height;

    public PcCaseBuilder() { }

    public PcCaseBuilder(PcCase pcCase)
    {
        _motherboardMaxSize = pcCase.MotherboardMaxSize;
        _insideHeight = pcCase.InsideHeight;
        _insideWidth = pcCase.InsideWidth;
        _length = pcCase.Length;
        _width = pcCase.Width;
        _height = pcCase.Height;
    }

    public IPcCaseBuilder WithMotherboardMaxSize(int motherboardMaxSize)
    {
        _motherboardMaxSize = motherboardMaxSize;
        return this;
    }

    public IPcCaseBuilder WithInsideHeight(double insideHeight)
    {
        _insideHeight = insideHeight < _width ? insideHeight : _width;
        return this;
    }

    public IPcCaseBuilder WithInsideWidth(double insideWidth)
    {
        _insideWidth = insideWidth < _length ? insideWidth : _length;
        return this;
    }

    public IPcCaseBuilder WithLength(double length)
    {
        _length = length;
        return this;
    }

    public IPcCaseBuilder WithWidth(double width)
    {
        _width = width;
        return this;
    }

    public IPcCaseBuilder WithHeight(double height)
    {
        _height = height;
        return this;
    }

    public PcCase Build()
    {
        return new PcCase(_motherboardMaxSize, _insideHeight, _insideWidth, _length, _width, _height);
    }
}