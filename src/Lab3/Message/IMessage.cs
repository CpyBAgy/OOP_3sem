namespace Itmo.ObjectOrientedProgramming.Lab3.Message;

public interface IMessage
{
    string Title { get; }
    string Body { get; }
    int Priority { get; }
}