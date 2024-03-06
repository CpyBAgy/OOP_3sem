using Core.Entities.Account;
using Core.Entities.Transaction;

namespace Core.Services.AccountService;

public interface IUserService
{
    UserAccount CreateAccount(UserAccount account);
    IAccount GetAccount(ulong id);
    void Deposit(ulong id, ulong amount);
    IEnumerable<ITransaction> GetTransactions(ulong id);
    void Withdraw(ulong id, ulong amount);
}