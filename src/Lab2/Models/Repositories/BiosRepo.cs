using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class BiosRepo
{
    private readonly List<Bios> _bioses;

    public BiosRepo()
    {
        _bioses = Enumerable.Range(0, 10)
            .Select(i => new BiosBuilder()
                .WithType($"Type{i + 1}")
                .WithProcessorRank(i + 1)
                .Build())
            .ToList();
    }

    public BiosRepo(IEnumerable<Bios> bioses)
    {
        _bioses = new List<Bios>(bioses);
    }

    public BiosRepo Add(Bios bios)
    {
        _bioses.Add(bios);
        return this;
    }

    public bool Update(Bios bios, Bios newBios)
    {
        int index = _bioses.IndexOf(bios);
        if (index == -1)
            return false;

        _bioses[index] = newBios;
        return true;
    }

    public bool Delete(Bios bios)
    {
        return _bioses.Remove(bios);
    }

    public IEnumerable<Bios> FindAll(Predicate<Bios> predicate)
    {
        return _bioses.Where(bios => predicate(bios));
    }
}
