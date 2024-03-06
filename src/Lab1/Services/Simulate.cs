using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class Simulate
{
    public Simulate(IShip ship, Route route)
    {
        Ship = ship;
        Route = route;
    }

    public IShip Ship { get; }
    public Route Route { get; }

    public RouteResult ProcessTrip()
    {
        var result = new RouteResult();
        foreach (RouteSegment segment in Route.Segments)
        {
            RouteResult segmentResult = MoveThroughEnvironment(segment);
            result.UpdateStatus(segmentResult);
            if (result.Result is not RoutePossibleResults.Success) return result;
        }

        return result;
    }

    private RouteResult MoveThroughEnvironment(RouteSegment segment)
    {
        var result = new RouteResult();
        if (segment.Environment is IMovementCondition specialEnvironment)
        {
            if (specialEnvironment.RequiresExponentialImpulseEngine() && Ship.ShipImpulseEngine is not ExponentialImpulseEngine)
                return result.UpdateStatus(RoutePossibleResults.BadImpulseEngine);
            if (specialEnvironment.RequiresJumpEngine())
            {
                if (Ship.ShipJumpEngine == null || Ship.ShipJumpEngine.MaxJumpDistance < segment.Distance)
                    return result.UpdateStatus(RoutePossibleResults.ShipLoss);
                result.UpdateStatus(default, default, Ship.ShipJumpEngine.TotalFuelConsumption(segment));
            }
        }

        foreach (ObstacleCluster obstacle in segment.Environment.Obstacles)
        {
            result.UpdateStatus(Ship.Reflect(obstacle.Obstacle, obstacle.Amount ?? 1)
                ? RoutePossibleResults.Success
                : RoutePossibleResults.ShipDestruction);
            if (result.Result == RoutePossibleResults.Success) continue;
            return obstacle.Obstacle is IReflectCondition specialObstacle &&
                   specialObstacle.RequiresPhotonicallyModifiedDeflector()
                ? result.UpdateStatus(RoutePossibleResults.CrewDied)
                : result;
        }

        result.UpdateStatus(default, Ship.ShipImpulseEngine.TotalFuelConsumption(segment), default);

        return result;
    }
}
