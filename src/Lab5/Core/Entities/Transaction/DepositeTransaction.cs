namespace Core.Entities.Transaction;

public class DepositeTransaction : ITransaction
{
    public DepositeTransaction(ulong id, ulong accountId, ulong amount, DateTime transactionDate)
    {
        Id = id;
        AccountId = accountId;
        Amount = amount;
        TransactionDate = transactionDate;
    }

    public ulong Id { get; init; }
    public ulong AccountId { get; init; }
    public ulong Amount { get; init; }
    public DateTime TransactionDate { get; set; }
    public TrsType Type { get; } = TrsType.Deposit;
}