using Core.Entities.Transaction;

namespace Core.Entities.Account;

public class UserAccount : IAccount
{
    public UserAccount(ulong id, ulong balance, string password, AccType type)
    {
        Id = id;
        Balance = balance;
        Password = password;
        Type = type == AccType.User ? type : AccType.User;
    }

    public ulong Id { get; set; }
    public AccType Type { get; }
    public ulong Balance { get; set; }
    public string Password { get; init; }
    public IEnumerable<ITransaction>? History { get; set; }
}