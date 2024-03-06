using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class Validator
{
    private readonly Pc? _pc;

    public Validator(Pc pc)
    {
        _pc = pc;
    }

    public ICollection<ConfigurationResult> Troubles()
    {
        if (_pc is null) return new List<ConfigurationResult> { ConfigurationResult.NullPc };
        var troubles = new List<ConfigurationResult>();
        ConfigurationResult currentResult;
        if ((currentResult = CheckCpu()) is not ConfigurationResult.Success) troubles.Add(currentResult);
        if ((currentResult = CheckRam()) is not ConfigurationResult.Success) troubles.Add(currentResult);
        if ((currentResult = CheckGpu()) is not ConfigurationResult.Success) troubles.Add(currentResult);
        if ((currentResult = CheckCooler()) is not ConfigurationResult.Success) troubles.Add(currentResult);
        if ((currentResult = CheckCase()) is not ConfigurationResult.Success) troubles.Add(currentResult);
        if ((currentResult = CheckPower()) is not ConfigurationResult.Success) troubles.Add(currentResult);
        return troubles.Any() ? troubles : new List<ConfigurationResult> { ConfigurationResult.Success };
    }

    private ConfigurationResult CheckCpu()
    {
        if (_pc?.PcCpu.Socket != _pc?.PcMotherboard.Socket) return ConfigurationResult.SocketConflict;
        return _pc?.PcCpu.Rank != _pc?.PcMotherboard.Bios?.ProcessorRank ? ConfigurationResult.OutdatedBios : ConfigurationResult.Success;
    }

    private ConfigurationResult CheckRam()
    {
        return _pc?.PcRam.Standard != _pc?.PcMotherboard.RamStandard ? ConfigurationResult.RamStandardConflict : ConfigurationResult.Success;
    }

    private ConfigurationResult CheckGpu()
    {
        return _pc?.PcGpu?.Height <= _pc?.PcCase.InsideHeight && _pc?.PcGpu?.Width <= _pc?.PcCase.InsideWidth
            ? ConfigurationResult.SpaceConflict
            : ConfigurationResult.Success;
    }

    private ConfigurationResult CheckCooler()
    {
        if (_pc?.PcCooler.Tdp < _pc?.PcCpu.Tdp) return ConfigurationResult.NoWarranty;
        return _pc?.PcCooler.Height <= _pc?.PcCase.Width ? ConfigurationResult.SpaceConflict : ConfigurationResult.Success;
    }

    private ConfigurationResult CheckCase()
    {
        return _pc?.PcCase.MotherboardMaxSize >= _pc?.PcMotherboard.Size ? ConfigurationResult.Success : ConfigurationResult.MotherboardSizeConflict;
    }

    private ConfigurationResult CheckPower()
    {
        return TotalPowerConsumption() <= _pc?.PcPowerSupply.PowerCapacity
            ? ConfigurationResult.Success
            : ConfigurationResult.LessPowerCapacity;
    }

    private int TotalPowerConsumption()
    {
        return (_pc?.PcCpu.PowerConsumption ?? 0) +
               (_pc?.PcGpu?.PowerConsumption ?? 0) +
               (_pc?.PcRam.PowerConsumption * _pc?.PcMotherboard.RamAmount ?? 0) +
               (_pc?.PcHdd?.PowerConsumption ?? 0) +
               (_pc?.PcSsd?.PowerConsumption ?? 0);
    }
}