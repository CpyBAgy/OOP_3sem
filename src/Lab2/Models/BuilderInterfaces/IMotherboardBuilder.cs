using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;

public interface IMotherboardBuilder
{
    IMotherboardBuilder WithSocket(int socket);
    IMotherboardBuilder WithPciAmount(int pciAmount);
    IMotherboardBuilder WithSataAmount(int sataAmount);
    IMotherboardBuilder WithRamMaxFrequency(int ramMaxFrequency);
    IMotherboardBuilder WithRamAmount(int ramAmount);
    IMotherboardBuilder WithRamStandard(int ramStandard);
    IMotherboardBuilder WithSize(int size);
    IMotherboardBuilder WithBios(Bios? bios);
    Motherboard Build();
}