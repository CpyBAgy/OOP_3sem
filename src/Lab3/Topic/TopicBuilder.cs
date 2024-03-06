using Itmo.ObjectOrientedProgramming.Lab3.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topic;

public class TopicBuilder
{
    private string _name = "Default Topic Name";
    private IRecipient _recipient = new MessengerRecipient("Default Messenger Name");

    public TopicBuilder WithName(string topicName)
    {
        _name = topicName;
        return this;
    }

    public TopicBuilder WithRecipient(IRecipient topicRecipient)
    {
        _recipient = topicRecipient;
        return this;
    }

    public ITopic Build()
    {
        return new Topic(_name, _recipient);
    }
}
