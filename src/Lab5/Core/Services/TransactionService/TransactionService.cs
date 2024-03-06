using Core.Entities.Transaction;
using Core.Services.RepositoryInterfaces;

namespace Core.Services.TransactionService;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public void RecordTransaction(ITransaction transaction)
    {
        _transactionRepository.Save(transaction);
    }
}