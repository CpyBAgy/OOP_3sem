using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class RamRepo
{
    private readonly List<Ram> _rams;

    public RamRepo()
    {
        _rams = Enumerable.Range(0, 10)
            .Select(i => new RamBuilder()
                .WithDdrStandard($"DDR{3 + (i % 3)}")
                .WithFrequency(1600 + (i * 200))
                .WithStandard(1 + i)
                .WithPowerConsumption(5 + i)
                .Build())
            .ToList();
    }

    public RamRepo(IEnumerable<Ram> rams)
    {
        _rams = new List<Ram>(rams);
    }

    public RamRepo Add(Ram ram)
    {
        _rams.Add(ram);
        return this;
    }

    public bool Update(Ram ram, Ram newRam)
    {
        int index = _rams.IndexOf(ram);
        if (index == -1)
            return false;

        _rams[index] = newRam;
        return true;
    }

    public bool Delete(Ram ram)
    {
        return _rams.Remove(ram);
    }

    public IEnumerable<Ram> FindAll(Predicate<Ram> predicate)
    {
        return _rams.Where(ram => predicate(ram));
    }
}
