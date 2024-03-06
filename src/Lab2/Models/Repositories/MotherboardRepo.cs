using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class MotherboardRepo
{
    private readonly List<Motherboard> _motherboards;

    public MotherboardRepo()
    {
        _motherboards = Enumerable.Range(0, 10)
            .Select(i => new MotherboardBuilder()
                .WithSocket(1150 + (i * 10))
                .WithPciAmount(3)
                .WithSataAmount(6)
                .WithRamMaxFrequency(1600 + (i * 200))
                .WithRamAmount(4)
                .WithRamStandard(1 + i)
                .WithSize(12 + i)
                .WithBios(new BiosBuilder().WithType($"Type{i + 1}").WithProcessorRank(i + 1).Build())
                .Build())
            .ToList();
    }

    public MotherboardRepo(IEnumerable<Motherboard> motherboards)
    {
        _motherboards = new List<Motherboard>(motherboards);
    }

    public MotherboardRepo Add(Motherboard motherboard)
    {
        _motherboards.Add(motherboard);
        return this;
    }

    public bool Update(Motherboard motherboard, Motherboard newMotherboard)
    {
        int index = _motherboards.IndexOf(motherboard);
        if (index == -1)
            return false;

        _motherboards[index] = newMotherboard;
        return true;
    }

    public bool Delete(Motherboard motherboard)
    {
        return _motherboards.Remove(motherboard);
    }

    public IEnumerable<Motherboard> FindAll(Predicate<Motherboard> predicate)
    {
        return _motherboards.Where(mb => predicate(mb));
    }
}
