using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class NormalSpace : IEnvironment
{
    public NormalSpace(params ObstacleCluster[] obstacles)
    {
        Obstacles = obstacles.Where(cluster => cluster.Obstacle is SmallAsteroid or Meteor);
    }

    public IEnumerable<ObstacleCluster> Obstacles { get; }
}