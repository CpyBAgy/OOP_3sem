using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class HddRepo
{
    private readonly List<Hdd> _hdds;

    public HddRepo()
    {
        _hdds = Enumerable.Range(0, 10)
            .Select(i => new HddBuilder()
                .WithCapacity(128 + (i * 128))
                .WithRpm(i % 2 == 0 ? 5400 : 7200)
                .WithPowerConsumption(5 + i)
                .Build())
            .ToList();
    }

    public HddRepo(IEnumerable<Hdd> hdds)
    {
        _hdds = new List<Hdd>(hdds);
    }

    public HddRepo Add(Hdd hdd)
    {
        _hdds.Add(hdd);
        return this;
    }

    public bool Update(Hdd hdd, Hdd newHdd)
    {
        int index = _hdds.IndexOf(hdd);
        if (index == -1)
            return false;

        _hdds[index] = newHdd;
        return true;
    }

    public bool Delete(Hdd hdd)
    {
        return _hdds.Remove(hdd);
    }

    public IEnumerable<Hdd> FindAll(Predicate<Hdd> predicate)
    {
        return _hdds.Where(hdd => predicate(hdd));
    }
}