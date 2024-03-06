using Core.Entities.Account;
using Core.Services.RepositoryInterfaces;

namespace Core.Services.AccountService;

public class AdminService : IAdminService
{
    private readonly IAccountRepository _accountRepository;

    public AdminService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public void CreateNewAccount(IAccount account)
    {
        _accountRepository.CreateUser(account);
    }

    public void DeleteAccount(ulong id)
    {
        _accountRepository.DeleteUser(id);
    }
}