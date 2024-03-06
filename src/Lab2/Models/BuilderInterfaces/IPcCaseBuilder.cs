using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;

public interface IPcCaseBuilder
{
    IPcCaseBuilder WithMotherboardMaxSize(int motherboardMaxSize);
    IPcCaseBuilder WithInsideHeight(double insideHeight);
    IPcCaseBuilder WithInsideWidth(double insideWidth);
    IPcCaseBuilder WithLength(double length);
    IPcCaseBuilder WithWidth(double width);
    IPcCaseBuilder WithHeight(double height);
    PcCase Build();
}