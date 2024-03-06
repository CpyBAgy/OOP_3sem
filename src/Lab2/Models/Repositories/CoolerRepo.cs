using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class CoolerRepo
{
    private readonly List<Cooler> _coolers;

    public CoolerRepo()
    {
        _coolers = Enumerable.Range(0, 10)
            .Select(i => new CoolerBuilder()
                .WithHeight(100.0 + i)
                .WithTdp(65 + (i * 5))
                .WithSupportedSockets(new Collection<int> { 1100 + (i * 10), 1150 + (i * 10), 1200 + (i * 10), 1250 + (i * 10) })
                .Build())
            .ToList();
    }

    public CoolerRepo(IEnumerable<Cooler> coolers)
    {
        _coolers = new List<Cooler>(coolers);
    }

    public CoolerRepo Add(Cooler cooler)
    {
        _coolers.Add(cooler);
        return this;
    }

    public bool Update(Cooler cooler, Cooler newCooler)
    {
        int index = _coolers.IndexOf(cooler);
        if (index == -1)
            return false;

        _coolers[index] = newCooler;
        return true;
    }

    public bool Delete(Cooler cooler)
    {
        return _coolers.Remove(cooler);
    }

    public IEnumerable<Cooler> FindAll(Predicate<Cooler> predicate)
    {
        return _coolers.Where(cooler => predicate(cooler));
    }
}
