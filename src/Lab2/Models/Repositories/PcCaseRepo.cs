using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class PcCaseRepo
{
    private readonly List<PcCase> _pcCases;

    public PcCaseRepo()
    {
        _pcCases = Enumerable.Range(0, 10)
            .Select(i => new PcCaseBuilder()
                .WithMotherboardMaxSize(12 + i)
                .WithInsideHeight(10.0 + i)
                .WithInsideWidth(20.0 + i)
                .WithLength(40.0 + i)
                .WithWidth(15.0 + i)
                .WithHeight(25.0 + i)
                .Build())
            .ToList();
    }

    public PcCaseRepo(IEnumerable<PcCase> pcCases)
    {
        _pcCases = new List<PcCase>(pcCases);
    }

    public PcCaseRepo Add(PcCase pcCase)
    {
        _pcCases.Add(pcCase);
        return this;
    }

    public bool Update(PcCase pcCase, PcCase newPcCase)
    {
        int index = _pcCases.IndexOf(pcCase);
        if (index == -1)
            return false;

        _pcCases[index] = newPcCase;
        return true;
    }

    public bool Delete(PcCase pcCase)
    {
        return _pcCases.Remove(pcCase);
    }

    public IEnumerable<PcCase> FindAll(Predicate<PcCase> predicate)
    {
        return _pcCases.Where(pc => predicate(pc));
    }
}
