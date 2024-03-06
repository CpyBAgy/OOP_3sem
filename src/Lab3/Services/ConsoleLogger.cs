using System;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class ConsoleLogger : ILogger
{
    public void LogMessage(IMessage message)
    {
        Console.WriteLine($"Logging: {message.Title}");
    }
}