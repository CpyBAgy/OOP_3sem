using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Recipient;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Tests
{
    [Fact]
    public void UserReceivesUnreadMessage()
    {
        var user = new User("John");
        var userMessage = new UserMessage("Title", "Body", 1);
        user.ReceiveMessage(userMessage);
        Assert.False(userMessage.IsRead);
    }

    [Fact]
    public void UserMarksUnreadMessageAsRead()
    {
        var user = new User("John");
        var userMessage = new UserMessage("Title", "Body", 1);
        user.ReceiveMessage(userMessage);
        user.MarkMessageAsRead(userMessage);
        Assert.False(userMessage.IsRead);
    }

    [Fact]
    public void FilteredMessageDoesNotReachRecipient()
    {
        var user = new User("John");
        var filteredMessage = new Mock<UserMessage>("Filtered Title", "Filtered Body", 2);
        user.ReceiveMessage(filteredMessage.Object);
        Assert.False(filteredMessage.Object.IsRead);
    }
}
