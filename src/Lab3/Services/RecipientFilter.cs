using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class RecipientFilter : IRecipient
{
    private readonly int _priority;
    private readonly RecipientLogging _logging;

    public RecipientFilter(RecipientLogging logging, int priority)
    {
        _logging = logging;
        _priority = priority;
    }

    public void ReceiveMessage(IMessage message)
    {
        if (message.Priority <= _priority)
            _logging.ReceiveMessage(message);
    }
}