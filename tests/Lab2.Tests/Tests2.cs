using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Tests2
{
    [Fact]
    public void SuccessTest()
    {
        Motherboard? motherboard = AllComponentsRepo.Motherboards.FindAll(_ => true).FirstOrDefault();
        Cpu? cpu = AllComponentsRepo.Cpus.FindAll(_ => true).FirstOrDefault();
        Cooler? cooler = AllComponentsRepo.Coolers.FindAll(_ => true).FirstOrDefault();
        Gpu? gpu = AllComponentsRepo.Gpus.FindAll(_ => true).FirstOrDefault();
        Hdd? hdd = AllComponentsRepo.Hdds.FindAll(_ => true).FirstOrDefault();
        Ssd? ssd = AllComponentsRepo.Ssds.FindAll(_ => true).FirstOrDefault();
        PcCase? pcCase = AllComponentsRepo.PcCases.FindAll(_ => true).Last();
        Ram? ram = AllComponentsRepo.Rams.FindAll(_ => true).FirstOrDefault();
        PowerSupply? power = AllComponentsRepo.PowerSupplies.FindAll(_ => true).FirstOrDefault();
        if (motherboard is null) return;
        Pc pc = new Configurator(motherboard, cpu, ram, cooler, pcCase, power, gpu, ssd, hdd).Configure();
        Assert.Equal(new Validator(pc).Troubles(), new List<ConfigurationResult> { ConfigurationResult.Success });
    }

    [Fact]
    public void PowerWarningTest()
    {
        Motherboard? motherboard = AllComponentsRepo.Motherboards.FindAll(_ => true).Last();
        Cpu? cpu = AllComponentsRepo.Cpus.FindAll(_ => true).Last();
        Cooler? cooler = AllComponentsRepo.Coolers.FindAll(_ => true).Last();
        Gpu? gpu = AllComponentsRepo.Gpus.FindAll(_ => true).Last();
        Hdd? hdd = AllComponentsRepo.Hdds.FindAll(_ => true).Last();
        Ssd? ssd = AllComponentsRepo.Ssds.FindAll(_ => true).Last();
        PcCase? pcCase = AllComponentsRepo.PcCases.FindAll(_ => true).Last();
        Ram? ram = AllComponentsRepo.Rams.FindAll(_ => true).Last();
        PowerSupply? power = AllComponentsRepo.PowerSupplies.FindAll(_ => true).First();
        Pc pc = new Configurator(motherboard, cpu, ram, cooler, pcCase, power, gpu, ssd, hdd).Configure();
        Assert.Equal(new Validator(pc).Troubles(), new List<ConfigurationResult> { ConfigurationResult.LessPowerCapacity });
    }

    [Fact]
    public void CoolerWarningTest()
    {
        Motherboard? motherboard = AllComponentsRepo.Motherboards.FindAll(_ => true).Last();
        Cpu? cpu = AllComponentsRepo.Cpus.FindAll(_ => true).Last();
        Cooler? cooler = AllComponentsRepo.Coolers.FindAll(_ => true).FirstOrDefault();
        Gpu? gpu = AllComponentsRepo.Gpus.FindAll(_ => true).Last();
        Hdd? hdd = AllComponentsRepo.Hdds.FindAll(_ => true).Last();
        Ssd? ssd = AllComponentsRepo.Ssds.FindAll(_ => true).Last();
        PcCase? pcCase = AllComponentsRepo.PcCases.FindAll(_ => true).Last();
        Ram? ram = AllComponentsRepo.Rams.FindAll(_ => true).Last();
        PowerSupply? power = AllComponentsRepo.PowerSupplies.FindAll(_ => true).Last();
        Pc pc = new Configurator(motherboard, cpu, ram, cooler, pcCase, power, gpu, ssd, hdd).Configure();
        Assert.Equal(new Validator(pc).Troubles(), new List<ConfigurationResult> { ConfigurationResult.NoWarranty });
    }

    [Fact]
    public void RamConflictTest()
    {
        Motherboard? motherboard = AllComponentsRepo.Motherboards.FindAll(_ => true).FirstOrDefault();
        Cpu? cpu = AllComponentsRepo.Cpus.FindAll(_ => true).FirstOrDefault();
        Cooler? cooler = AllComponentsRepo.Coolers.FindAll(_ => true).FirstOrDefault();
        Gpu? gpu = AllComponentsRepo.Gpus.FindAll(_ => true).FirstOrDefault();
        Hdd? hdd = AllComponentsRepo.Hdds.FindAll(_ => true).FirstOrDefault();
        Ssd? ssd = AllComponentsRepo.Ssds.FindAll(_ => true).FirstOrDefault();
        PcCase? pcCase = AllComponentsRepo.PcCases.FindAll(_ => true).Last();
        Ram? ram = AllComponentsRepo.Rams.FindAll(_ => true).Last();
        PowerSupply? power = AllComponentsRepo.PowerSupplies.FindAll(_ => true).Last();
        if (motherboard is null) return;
        Pc pc = new Configurator(motherboard, cpu, ram, cooler, pcCase, power, gpu, ssd, hdd).Configure();
        Assert.Equal(new Validator(pc).Troubles(), new List<ConfigurationResult> { ConfigurationResult.RamStandardConflict });
    }

    [Fact]
    public void SocketConflictTest()
    {
        Motherboard? motherboard = AllComponentsRepo.Motherboards.FindAll(_ => true).FirstOrDefault();
        Cpu? cpu = AllComponentsRepo.Cpus.FindAll(_ => true).Last();
        Cooler? cooler = AllComponentsRepo.Coolers.FindAll(_ => true).FirstOrDefault();
        Gpu? gpu = AllComponentsRepo.Gpus.FindAll(_ => true).FirstOrDefault();
        Hdd? hdd = AllComponentsRepo.Hdds.FindAll(_ => true).FirstOrDefault();
        Ssd? ssd = AllComponentsRepo.Ssds.FindAll(_ => true).FirstOrDefault();
        PcCase? pcCase = AllComponentsRepo.PcCases.FindAll(_ => true).Last();
        Ram? ram = AllComponentsRepo.Rams.FindAll(_ => true).FirstOrDefault();
        PowerSupply? power = AllComponentsRepo.PowerSupplies.FindAll(_ => true).Last();
        if (motherboard is null) return;
        Pc pc = new Configurator(motherboard, cpu, ram, cooler, pcCase, power, gpu, ssd, hdd).Configure();
        Assert.Equal(new Validator(pc).Troubles(), new List<ConfigurationResult> { ConfigurationResult.SocketConflict, ConfigurationResult.NoWarranty });
    }
}