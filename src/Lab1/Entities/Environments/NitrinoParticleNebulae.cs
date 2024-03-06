using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class NitrinoParticleNebulae : IEnvironment, IMovementCondition
{
    public NitrinoParticleNebulae(params ObstacleCluster[] obstacles)
    {
        Obstacles = obstacles.Where(cluster => cluster.Obstacle is SpaceWhale);
    }

    public IEnumerable<ObstacleCluster> Obstacles { get; }
    public bool RequiresJumpEngine() { return false; }
    public bool RequiresExponentialImpulseEngine() { return true; }
}