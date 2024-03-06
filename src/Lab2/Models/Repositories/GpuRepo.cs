using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class GpuRepo
{
    private readonly List<Gpu> _gpus;

    public GpuRepo()
    {
        _gpus = Enumerable.Range(0, 10)
            .Select(i => new GpuBuilder()
                .WithHeight(10.0 + i)
                .WithWidth(20.0 + i)
                .WithFrequency(1500 + (i * 100))
                .WithPowerConsumption(100 + i)
                .Build())
            .ToList();
    }

    public GpuRepo(IEnumerable<Gpu> gpus)
    {
        _gpus = new List<Gpu>(gpus);
    }

    public GpuRepo Add(Gpu gpu)
    {
        _gpus.Add(gpu);
        return this;
    }

    public bool Update(Gpu gpu, Gpu newGpu)
    {
        int index = _gpus.IndexOf(gpu);
        if (index == -1)
            return false;

        _gpus[index] = newGpu;
        return true;
    }

    public bool Delete(Gpu gpu)
    {
        return _gpus.Remove(gpu);
    }

    public IEnumerable<Gpu> FindAll(Predicate<Gpu> predicate)
    {
        return _gpus.Where(g => predicate(g));
    }
}
