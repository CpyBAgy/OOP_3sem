using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class PcRepo
{
    private readonly List<Pc> _pcs;

    public PcRepo()
    {
        _pcs = new List<Pc>();
    }

    public PcRepo(IEnumerable<Pc> pcs)
    {
        _pcs = new List<Pc>(pcs);
    }

    public PcRepo Add(Pc pc)
    {
        _pcs.Add(pc);
        return this;
    }

    public bool Update(Pc pc, Pc newPc)
    {
        int index = _pcs.IndexOf(pc);
        if (index == -1)
            return false;

        _pcs[index] = newPc;
        return true;
    }

    public bool Delete(Pc pc)
    {
        return _pcs.Remove(pc);
    }

    public IEnumerable<Pc> FindAll(Predicate<Pc> predicate)
    {
        return _pcs.Where(pc => predicate(pc));
    }
}
