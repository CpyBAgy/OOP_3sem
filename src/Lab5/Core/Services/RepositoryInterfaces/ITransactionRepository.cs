using Core.Entities.Transaction;

namespace Core.Services.RepositoryInterfaces;

public interface ITransactionRepository
{
    void Save(ITransaction account);
}