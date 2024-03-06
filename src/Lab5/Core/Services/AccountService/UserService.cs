using Core.Entities.Account;
using Core.Entities.Transaction;
using Core.Services.RepositoryInterfaces;
using Core.Services.TransactionService;

namespace Core.Services.AccountService;

public class UserService : IUserService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionService _transactionService;

    public UserService(IAccountRepository accountRepository, ITransactionService transactionService)
    {
        _accountRepository = accountRepository;
        _transactionService = transactionService;
    }

    public void Deposit(ulong id, ulong amount)
    {
        IAccount account = _accountRepository.GetById(id);
        account.Balance += amount;
        _accountRepository.SaveUser(account);
        var transaction = new DepositeTransaction(id, id, amount, DateTime.Now);
        _transactionService.RecordTransaction(transaction);
    }

    public void Withdraw(ulong id, ulong amount)
    {
        IAccount account = _accountRepository.GetById(id);
        if (account.Balance < amount) throw new InvalidOperationException("Not enough money");
        account.Balance -= amount;
        _accountRepository.SaveUser(account);
        var transaction = new WithdrawalTransaction(id, id, amount, DateTime.Now);
        _transactionService.RecordTransaction(transaction);
    }

    public UserAccount CreateAccount(UserAccount account)
    {
        _accountRepository.SaveUser(account);
        return account;
    }

    public IAccount GetAccount(ulong id)
    {
        return _accountRepository.GetById(id);
    }

    public IEnumerable<ITransaction> GetTransactions(ulong id)
    {
        return _accountRepository.GetTransactionsByAccountId(id);
    }
}
