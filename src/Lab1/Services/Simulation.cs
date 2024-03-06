using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class Simulation
{
    public Simulation(IEnumerable<IShip> ships, IEnumerable<Route> routes)
    {
        Ships = ships;
        Routes = routes;
    }

    public Simulation(IShip ship, IEnumerable<Route> routes)
    {
        Ships = new IShip[] { ship };
        Routes = routes;
    }

    public Simulation(IEnumerable<IShip> ships, Route route)
    {
        Ships = ships;
        Routes = new Route[] { route };
    }

    public Simulation(IShip ship, Route route)
    {
        Ships = new IShip[] { ship };
        Routes = new Route[] { route };
    }

    public IEnumerable<IShip> Ships { get; }

    public IEnumerable<Route> Routes { get; }

    public IShip SelectOptimalShip()
    {
        IShip optimalShip = Ships.First();
        RouteResult optimalShipWorstResult = WorstShipResult(optimalShip);
        foreach (IShip ship in Ships)
        {
            RouteResult currentShipResult = WorstShipResult(ship);
            if (!currentShipResult.Better(optimalShipWorstResult)) continue;
            optimalShip = ship;
            optimalShipWorstResult = currentShipResult;
        }

        if (optimalShipWorstResult.Result != RoutePossibleResults.Success) throw new RouteUnpassableException();

        return optimalShip;
    }

    public void AnalyzeTrip() // optional method for future using
    {
        var worstCaseDictionary = new Dictionary<int, RouteResult>();

        int shipIndex = 0;
        foreach (IShip ship in Ships)
        {
            worstCaseDictionary[shipIndex] = WorstShipResult(ship);
            shipIndex++;
        }

        // return what you want
    }

    public RouteResult WorstShipResult(IShip ship)
    {
        var worstResult = new RouteResult();

        worstResult = Routes.Select(route => new Simulate(ship, route)
                .ProcessTrip())
                .Aggregate(worstResult, (current, currentResult) =>
                current.Better(currentResult) ? currentResult : current);

        return worstResult;
    }
}
