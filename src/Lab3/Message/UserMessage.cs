namespace Itmo.ObjectOrientedProgramming.Lab3.Message;

public class UserMessage : IMessage
{
    public UserMessage(string title, string body, int priority)
    {
        Title = title;
        Body = body;
        Priority = priority;
        IsRead = false;
    }

    public UserMessage(IMessage message)
    {
        Title = message.Title;
        Body = message.Body;
        Priority = message.Priority;
        IsRead = false;
    }

    public string Title { get; }
    public string Body { get; }
    public int Priority { get; }
    public bool IsRead { get; private set; }

    public bool TryMarkAsRead()
    {
        if (IsRead) return false;
        IsRead = true;
        return true;
    }
}
