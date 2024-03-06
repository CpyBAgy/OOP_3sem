using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipient;

public interface IRecipient
{
    void ReceiveMessage(IMessage message);
}