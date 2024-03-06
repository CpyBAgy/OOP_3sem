using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipient;

public class Display
{
    private readonly string _name;
    private readonly IDisplayDriver _displayDriver;

    public Display(string name, IDisplayDriver displayDriver)
    {
        _name = name;
        _displayDriver = displayDriver;
    }

    public void ReceiveMessage(IMessage message)
    {
        _displayDriver.Clear();
        _displayDriver.Write($"[{_name}] {message.Title}\n{message.Body}");
    }
}