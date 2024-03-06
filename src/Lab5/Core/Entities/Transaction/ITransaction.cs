namespace Core.Entities.Transaction;

public interface ITransaction
{
    public ulong Id { get; init; }
    public ulong AccountId { get; init; }
    public ulong Amount { get; init; }
    public DateTime TransactionDate { get; set; }
    public TrsType Type { get; }
}