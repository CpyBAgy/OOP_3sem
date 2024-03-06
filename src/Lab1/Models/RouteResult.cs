namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class RouteResult
{
    public RouteResult(RoutePossibleResults? result = RoutePossibleResults.Success, double? fuel = 0, double? specialFuel = 0)
    {
        Result = result;
        Fuel = fuel;
        SpecialFuel = specialFuel;
    }

    public RoutePossibleResults? Result { get; private set;  }
    public double? Fuel { get; private set;  }
    public double? SpecialFuel { get; private set;  }

    public RouteResult UpdateStatus(RoutePossibleResults? result = RoutePossibleResults.Success, double? fuel = 0, double? specialFuel = 0)
    {
        Result = (result > Result) ? result : Result;
        Fuel += fuel;
        SpecialFuel += specialFuel;
        return this;
    }

    public RouteResult UpdateStatus(RouteResult other)
    {
        Result = (other.Result > Result) ? other.Result : Result;
        Fuel += other.Fuel;
        SpecialFuel += other.SpecialFuel;
        return this;
    }

    public bool Better(RouteResult other)
    {
        if (Result > other.Result) return false;
        return Fuel + SpecialFuel < other.Fuel + other.SpecialFuel;
    }
}