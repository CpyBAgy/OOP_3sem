namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public interface IMovementCondition
{
    bool RequiresJumpEngine();
    bool RequiresExponentialImpulseEngine();
}