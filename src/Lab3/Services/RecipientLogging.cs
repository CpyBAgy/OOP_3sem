using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class RecipientLogging : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly ILogger _logger;

    public RecipientLogging(IRecipient recipient, ILogger logger)
    {
        _recipient = recipient;
        _logger = logger;
    }

    public void ReceiveMessage(IMessage message)
    {
        _logger.LogMessage(message);
        _recipient.ReceiveMessage(message);
    }
}