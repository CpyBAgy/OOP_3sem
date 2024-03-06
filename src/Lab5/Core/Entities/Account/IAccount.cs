using Core.Entities.Transaction;

namespace Core.Entities.Account;

public interface IAccount
{
    public ulong Id { get; set; }
    public ulong Balance { get; set;  }
    public string Password { get; init; }
    public AccType Type { get; }
    public IEnumerable<ITransaction>? History { get; set; }
}