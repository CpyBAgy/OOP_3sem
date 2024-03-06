using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class HighDensityNebulae : IEnvironment, IMovementCondition
{
    public HighDensityNebulae(params ObstacleCluster[] obstacles)
    {
        Obstacles = obstacles.Where(cluster => cluster.Obstacle is AntimatterExplosion);
    }

    public IEnumerable<ObstacleCluster> Obstacles { get; }
    public bool RequiresJumpEngine() { return true; }
    public bool RequiresExponentialImpulseEngine() { return false; }
}
