using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topic;

public interface ITopic
{
    string Name { get; }
    IRecipient Recipient { get; }
    void AddMessage(IMessage message);
}