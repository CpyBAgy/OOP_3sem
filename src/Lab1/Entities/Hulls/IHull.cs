namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Hulls;

public interface IHull
{
    double Weight { get; }
    double HealthPoints { get; }
    bool Reflect(double damage);
}