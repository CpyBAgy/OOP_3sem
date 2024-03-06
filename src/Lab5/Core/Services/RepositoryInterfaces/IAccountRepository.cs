using Core.Entities.Account;
using Core.Entities.Transaction;

namespace Core.Services.RepositoryInterfaces;

public interface IAccountRepository
{
    IAccount GetById(ulong id);
    void SaveUser(IAccount account);
    void CreateUser(IAccount account);
    IEnumerable<ITransaction> GetTransactionsByAccountId(ulong id);
    void DeleteUser(ulong id);
    bool ValidatePassword(ulong id, string password);
    bool ValidatePassword(string password);
}