using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipient;

public class DisplayRecipient : IRecipient
{
    private readonly Display _display;

    public DisplayRecipient(Display display)
    {
        _display = display;
    }

    public void ReceiveMessage(IMessage message)
    {
        _display.ReceiveMessage(message);
    }
}
