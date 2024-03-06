using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Tests
{
    public static IEnumerable<object[]> TestDataCase1
    {
        get
        {
            yield return new object[] { new Simulation(new List<IShip> { new Shuttle(), new Augur() },  new Route(new RouteSegment(new HighDensityNebulae(), 1000000))), RoutePossibleResults.ShipLoss };
        }
    }

    public static IEnumerable<object[]> TestDataCase2
    {
        get
        {
            yield return new object[] { new Simulation(new List<IShip> { new Waklas(), new Waklas(new PhotinicallyModifiedDeflector()) }, new Route(new RouteSegment(new HighDensityNebulae(new ObstacleCluster(new AntimatterExplosion())), 10000))), RoutePossibleResults.CrewDied, RoutePossibleResults.Success };
        }
    }

    public static IEnumerable<object[]> TestDataCase3
    {
        get
        {
            yield return new object[] { new Simulation(new List<IShip> { new Waklas(), new Meridian(), new Augur() }, new Route(new RouteSegment(new NitrinoParticleNebulae(new ObstacleCluster(new SpaceWhale())), 1000))), RoutePossibleResults.ShipDestruction, RoutePossibleResults.Success };
        }
    }

    public static IEnumerable<object[]> TestDataCase4
    {
        get
        {
            yield return new object[] { new Simulation(new List<IShip> { new Shuttle(), new Waklas() }, new Route(new RouteSegment(new NormalSpace(), 1000))), new Shuttle() };
        }
    }

    public static IEnumerable<object[]> TestDataCase5
    {
        get
        {
            yield return new object[] { new Simulation(new List<IShip> { new Augur(), new Stella() }, new Route(new RouteSegment(new HighDensityNebulae(), 20000))), RoutePossibleResults.ShipLoss, RoutePossibleResults.Success };
        }
    }

    public static IEnumerable<object[]> TestDataCase6
    {
        get
        {
            yield return new object[] { new Simulation(new List<IShip> { new Shuttle(), new Waklas() }, new Route(new RouteSegment(new NitrinoParticleNebulae(), 10000))), RoutePossibleResults.BadImpulseEngine, RoutePossibleResults.Success };
        }
    }

    public static IEnumerable<object[]> TestDataCase7
    {
        get
        {
            yield return new object[] { new Simulation(new List<IShip> { new Shuttle(), new Augur(), new Stella() }, new Route(new RouteSegment(new HighDensityNebulae(), 50000))), new List<RoutePossibleResults> { RoutePossibleResults.ShipLoss, RoutePossibleResults.ShipLoss, RoutePossibleResults.ShipLoss } };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataCase1))]
    public void TestHighDensityNebulae(Simulation simulation, RoutePossibleResults expectedResult)
    {
        foreach (IShip ship in simulation.Ships)
        {
            RouteResult result = new Simulate(ship, simulation.Routes.First()).ProcessTrip();
            Assert.Equal(expectedResult, result.Result);
        }
    }

    [Theory]
    [MemberData(nameof(TestDataCase2))]
    public void TestAntimatterExplosion(Simulation simulation, RoutePossibleResults firstExpectedResult, RoutePossibleResults secondExpectedResult)
    {
        foreach (IShip ship in simulation.Ships)
        {
            RouteResult result = new Simulate(ship, simulation.Routes.First()).ProcessTrip();
            Assert.Equal(ship.ShipPhotinicallyModifiedDeflector == null ? firstExpectedResult : secondExpectedResult, result.Result);
        }
    }

    [Theory]
    [MemberData(nameof(TestDataCase3))]
    public void TestSpaceWhale(Simulation simulation, RoutePossibleResults firstExpectedResult, RoutePossibleResults otherExpectedResult)
    {
        foreach (IShip ship in simulation.Ships)
        {
            RouteResult result = new Simulate(ship, simulation.Routes.First()).ProcessTrip();
            Assert.Equal(ship is Waklas ? firstExpectedResult : otherExpectedResult, result.Result);
        }
    }

    [Theory]
    [MemberData(nameof(TestDataCase4))]
    public void TestNormalSpace(Simulation simulation, IShip expectedOptimalShip)
    {
        Assert.Equal(expectedOptimalShip.Weight, simulation.SelectOptimalShip().Weight);
    }

    [Theory]
    [MemberData(nameof(TestDataCase5))]
    public void TestLongHighDensityNebulae(Simulation simulation, RoutePossibleResults firstExpectedResult, RoutePossibleResults secondExpectedResult)
    {
        foreach (IShip ship in simulation.Ships)
        {
            RouteResult result = new Simulate(ship, simulation.Routes.First()).ProcessTrip();
            Assert.Equal(ship is Augur ? firstExpectedResult : secondExpectedResult, result.Result);
        }
    }

    [Theory]
    [MemberData(nameof(TestDataCase6))]
    public void TestNitrinoParticleNebulae(Simulation simulation, RoutePossibleResults firstExpectedResult, RoutePossibleResults secondExpectedResult)
    {
        foreach (IShip ship in simulation.Ships)
        {
            RouteResult result = new Simulate(ship, simulation.Routes.First()).ProcessTrip();
            Assert.Equal(ship.ShipJumpEngine == null ? firstExpectedResult : secondExpectedResult, result.Result);
        }
    }

    [Theory]
    [MemberData(nameof(TestDataCase7))]
    public void TestMultipleShipsInHighDensityNebulae(Simulation simulation, ICollection<RoutePossibleResults> expectedResults)
    {
        var shipsList = simulation.Ships.ToList();
        for (int i = 0; i < shipsList.Count; i++)
        {
            IShip ship = shipsList[i];
            RouteResult result = new Simulate(ship, simulation.Routes.First()).ProcessTrip();
            Assert.Equal(expectedResults.ElementAt(i), result.Result);
        }
    }
}