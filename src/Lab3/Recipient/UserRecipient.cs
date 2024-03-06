using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipient;

public class UserRecipient : IRecipient
{
    private readonly User _user;

    public UserRecipient(User user)
    {
        _user = user;
    }

    public void ReceiveMessage(IMessage message)
    {
        _user.ReceiveMessage(message);
    }
}
