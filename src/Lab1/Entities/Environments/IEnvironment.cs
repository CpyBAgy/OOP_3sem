using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public interface IEnvironment
{
    IEnumerable<ObstacleCluster> Obstacles { get; }
}
