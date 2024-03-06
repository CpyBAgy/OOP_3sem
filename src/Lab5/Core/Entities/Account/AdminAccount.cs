using Core.Entities.Transaction;

namespace Core.Entities.Account;

public class AdminAccount : IAccount
{
    public AdminAccount(ulong id, ulong balance, string password, AccType type)
    {
        Id = id;
        Balance = balance;
        Password = password;
        Type = type == AccType.Admin ? type : AccType.Admin;
    }

    public ulong Id { get; set; }
    public AccType Type { get; }
    public ulong Balance { get; set; }
    public string Password { get; init; }
    public IEnumerable<ITransaction>? History { get; set; }
}