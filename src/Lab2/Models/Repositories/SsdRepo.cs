using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class SsdRepo
{
    private readonly List<Ssd> _ssds;

    public SsdRepo()
    {
        _ssds = Enumerable.Range(0, 10)
            .Select(i => new SsdBuilder()
                .WithCapacity(256 + (i * 128))
                .WithSataConnection(i % 3 == 0)
                .WithReadSpeed(500 + (i * 100))
                .WithWriteSpeed(450 + (i * 90))
                .WithPowerConsumption(3 + i)
                .Build())
            .ToList();
    }

    public SsdRepo(IEnumerable<Ssd> ssds)
    {
        _ssds = new List<Ssd>(ssds);
    }

    public SsdRepo Add(Ssd ssd)
    {
        _ssds.Add(ssd);
        return this;
    }

    public bool Update(Ssd ssd, Ssd newSsd)
    {
        int index = _ssds.IndexOf(ssd);
        if (index == -1)
            return false;

        _ssds[index] = newSsd;
        return true;
    }

    public bool Delete(Ssd ssd)
    {
        return _ssds.Remove(ssd);
    }

    public IEnumerable<Ssd> FindAll(Predicate<Ssd> predicate)
    {
        return _ssds.Where(ssd => predicate(ssd));
    }
}
