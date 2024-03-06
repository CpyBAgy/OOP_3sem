using System;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipient;

public class MessengerRecipient : IRecipient
{
    private readonly string _name;

    public MessengerRecipient(string name)
    {
        _name = name;
    }

    public void ReceiveMessage(IMessage message)
    {
        SendMessage($"[{_name}] {message.Title}\n{message.Body}");
    }

    private static void SendMessage(string text)
    {
        Console.WriteLine($"Messenger: {text}");
    }
}
