using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipient;

public class User
{
    private readonly string _name;
    private readonly List<UserMessage> _userMessages;

    public User(string name)
    {
        _name = name;
        _userMessages = new List<UserMessage>();
    }

    public void ReceiveMessage(IMessage message)
    {
        _userMessages.Add(new UserMessage(message));
        Console.WriteLine($"User [{_name}] received a message: {message.Title}");
    }

    public void SendMessage(IMessage message)
    {
        Console.WriteLine($"User [{_name}] sent a message: {message.Title}");
    }

    public void MarkMessageAsRead(IMessage message)
    {
        var userMessage = new UserMessage(message);
        if (_userMessages.Contains(userMessage))
        {
            Console.WriteLine(userMessage.TryMarkAsRead()
                ? $"User [{_name}] marked message as read: {userMessage.Title}"
                : $"User [{_name}] message is already marked as read: {userMessage.Title}");
        }
    }
}