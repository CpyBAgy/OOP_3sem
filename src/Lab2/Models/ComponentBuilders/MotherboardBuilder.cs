using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.BuilderInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentBuilders;

public class MotherboardBuilder : IMotherboardBuilder
{
    private int _socket;
    private int _pciAmount;
    private int _sataAmount;
    private int _ramMaxFrequency;
    private int _ramAmount;
    private int _ramStandard;
    private int _size;
    private Bios? _bios;

    public MotherboardBuilder() { }

    public MotherboardBuilder(Motherboard motherboard)
    {
        _socket = motherboard.Socket;
        _pciAmount = motherboard.PciAmount;
        _sataAmount = motherboard.SataAmount;
        _ramMaxFrequency = motherboard.RamMaxFrequency;
        _ramAmount = motherboard.RamAmount;
        _ramStandard = motherboard.RamStandard;
        _size = motherboard.Size;
        _bios = motherboard.Bios;
    }

    public IMotherboardBuilder WithSocket(int socket)
    {
        _socket = socket;
        return this;
    }

    public IMotherboardBuilder WithPciAmount(int pciAmount)
    {
        _pciAmount = pciAmount;
        return this;
    }

    public IMotherboardBuilder WithSataAmount(int sataAmount)
    {
        _sataAmount = sataAmount;
        return this;
    }

    public IMotherboardBuilder WithRamMaxFrequency(int ramMaxFrequency)
    {
        _ramMaxFrequency = ramMaxFrequency;
        return this;
    }

    public IMotherboardBuilder WithRamAmount(int ramAmount)
    {
        _ramAmount = ramAmount;
        return this;
    }

    public IMotherboardBuilder WithRamStandard(int ramStandard)
    {
        _ramStandard = ramStandard;
        return this;
    }

    public IMotherboardBuilder WithSize(int size)
    {
        _size = size;
        return this;
    }

    public IMotherboardBuilder WithBios(Bios? bios)
    {
        _bios = bios;
        return this;
    }

    public Motherboard Build()
    {
        return new Motherboard(_size, _socket, _pciAmount, _sataAmount, _ramMaxFrequency, _ramAmount, _ramStandard, _bios ?? throw new ArgumentNullException());
    }
}