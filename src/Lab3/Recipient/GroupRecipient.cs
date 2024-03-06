using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipient;

public class GroupRecipient : IRecipient
{
    private readonly List<IRecipient> _recipients;

    public GroupRecipient()
    {
        _recipients = new List<IRecipient>();
    }

    public void AddRecipient(IRecipient recipient)
    {
        _recipients.Add(recipient);
    }

    public void RemoveRecipient(IRecipient recipient)
    {
        _recipients.Remove(recipient);
    }

    public void ReceiveMessage(IMessage message)
    {
        foreach (IRecipient recipient in _recipients) recipient.ReceiveMessage(message);
    }
}
