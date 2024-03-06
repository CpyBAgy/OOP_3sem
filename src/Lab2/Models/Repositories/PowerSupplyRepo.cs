using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class PowerSupplyRepo
{
    private readonly List<PowerSupply> _powerSupplies;

    public PowerSupplyRepo()
    {
        _powerSupplies = Enumerable.Range(0, 10)
            .Select(i => new PowerSupplyBuilder()
                .WithPowerCapacity(300 + (i * 50))
                .Build())
            .ToList();
    }

    public PowerSupplyRepo(IEnumerable<PowerSupply> powerSupplies)
    {
        _powerSupplies = new List<PowerSupply>(powerSupplies);
    }

    public PowerSupplyRepo Add(PowerSupply powerSupply)
    {
        _powerSupplies.Add(powerSupply);
        return this;
    }

    public bool Update(PowerSupply powerSupply, PowerSupply newPowerSupply)
    {
        int index = _powerSupplies.IndexOf(powerSupply);
        if (index == -1)
            return false;

        _powerSupplies[index] = newPowerSupply;
        return true;
    }

    public bool Delete(PowerSupply powerSupply)
    {
        return _powerSupplies.Remove(powerSupply);
    }

    public IEnumerable<PowerSupply> FindAll(Predicate<PowerSupply> predicate)
    {
        return _powerSupplies.Where(psu => predicate(psu));
    }
}
