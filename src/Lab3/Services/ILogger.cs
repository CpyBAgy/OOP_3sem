using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public interface ILogger
{
    void LogMessage(IMessage message);
}