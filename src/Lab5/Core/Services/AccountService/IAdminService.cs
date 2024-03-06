using Core.Entities.Account;

namespace Core.Services.AccountService;

public interface IAdminService
{
    void CreateNewAccount(IAccount account);
    void DeleteAccount(ulong id);
}