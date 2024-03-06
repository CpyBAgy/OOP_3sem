using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class CpuRepo
{
    private readonly List<Cpu> _cpus;

    public CpuRepo()
    {
        _cpus = _cpus = Enumerable.Range(0, 10)
            .Select(i => new CpuBuilder()
                .WithRank(i + 1)
                .WithCoreFrequency(3.0 + (i * 0.1))
                .WithCoreAmount(4 + ((i * 2) % 10))
                .WithSocket(1150 + (i * 10))
                .WithOnBoardGraphic(i % 3 == 0)
                .WithRamMaxFrequency(1600 + (i * 200))
                .WithTdp(65 + (i * 5))
                .WithPowerConsumption(165 + i)
                .Build())
            .ToList();
    }

    public CpuRepo(IEnumerable<Cpu> cpus)
    {
        _cpus = new List<Cpu>(cpus);
    }

    public CpuRepo Add(Cpu cpu)
    {
        _cpus.Add(cpu);
        return this;
    }

    public bool Update(Cpu cpu, Cpu newCpu)
    {
        int index = _cpus.IndexOf(cpu);
        if (index == -1)
            return false;

        _cpus[index] = newCpu;
        return true;
    }

    public bool Delete(Cpu cpu)
    {
        return _cpus.Remove(cpu);
    }

    public IEnumerable<Cpu> FindAll(Predicate<Cpu> predicate)
    {
        return _cpus.Where(c => predicate(c));
    }
}
