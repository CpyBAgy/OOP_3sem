using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topic;

public class Topic : ITopic
{
    private readonly List<IMessage> _messages = new List<IMessage>();

    public Topic(string name, IRecipient recipient)
    {
        Name = name;
        Recipient = recipient;
    }

    public string Name { get; }
    public IRecipient Recipient { get; }

    public void AddMessage(IMessage message)
    {
        _messages.Add(message);
    }
}