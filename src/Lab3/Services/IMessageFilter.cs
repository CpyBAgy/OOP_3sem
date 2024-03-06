using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public interface IMessageFilter
{
    bool IsMessageAllowed(IMessage message);
}