using Core.Entities.Transaction;

namespace Core.Services.TransactionService;

public interface ITransactionService
{
    void RecordTransaction(ITransaction transaction);
}