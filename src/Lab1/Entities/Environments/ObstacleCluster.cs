using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class ObstacleCluster
{
    public ObstacleCluster(IObstacle obstacle, int? amount = 1)
    {
        Obstacle = obstacle;
        Amount = amount;
    }

    public IObstacle Obstacle { get; }
    public int? Amount { get; }
}