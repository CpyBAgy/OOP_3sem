namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public interface IDeflector
{
    double Weight { get; }
    double HealthPoints { get; }
    bool Reflect(double damage);
}