using Core.Entities.Account;
using Core.Entities.Transaction;
using Core.Services.RepositoryInterfaces;
using Npgsql;

namespace Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private const ulong AdminAccountId = 1;
    private readonly string _connectionString;

    public AccountRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IAccount GetById(ulong id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var cmd = new NpgsqlCommand("SELECT * FROM users WHERE id = @id", connection);
        cmd.Parameters.AddWithValue("@id", id);
        using NpgsqlDataReader reader = cmd.ExecuteReader();
        if (!reader.Read()) throw new InvalidOperationException("Account not found.");

        ulong accountId = (ulong)reader.GetInt64(reader.GetOrdinal("id"));
        ulong balance = (ulong)reader.GetInt64(reader.GetOrdinal("balance"));
        string password = reader.GetString(reader.GetOrdinal("password"));

        string type = reader.GetString(reader.GetOrdinal("type"));
        if (!Enum.TryParse(type, out AccType accountType))
            throw new InvalidOperationException("Unknown account type");

        return accountType switch
        {
            AccType.User => new UserAccount(accountId, balance, password, accountType),
            AccType.Admin => new AdminAccount(accountId, balance, password, accountType),
            _ => throw new InvalidOperationException("Invalid account type"),
        };
    }

    public void SaveUser(IAccount account)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        const string updateCommand = @"
                                        UPDATE users
                                        SET   type = @type,
                                            balance = @balance,
                                            password = @password
                                        WHERE id = @id;";

        using var cmd = new NpgsqlCommand(updateCommand, connection);
        cmd.Parameters.AddWithValue("@id", account.Id);
        cmd.Parameters.AddWithValue("@type", account.Type.ToString());
        cmd.Parameters.AddWithValue("@balance", account.Balance);
        cmd.Parameters.AddWithValue("@password", account.Password);

        int affectedRows = cmd.ExecuteNonQuery();
        if (affectedRows == 0)
            throw new InvalidOperationException("Update failed, account not found.");
    }

    public void CreateUser(IAccount account)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        const string insertCommand = @"
                                        INSERT INTO users (type, balance, password)
                                        VALUES (@type, @balance, @password)
                                        RETURNING id;";

        using var cmd = new NpgsqlCommand(insertCommand, connection);
        cmd.Parameters.AddWithValue("@type", account.Type.ToString());
        cmd.Parameters.AddWithValue("@balance", account.Balance);
        cmd.Parameters.AddWithValue("@password", account.Password);

        object? result = cmd.ExecuteScalar();
        if (result is int id) account.Id = (ulong)id;
        else throw new InvalidOperationException("Id cannot be null or non-decimal.");
    }

    public void DeleteUser(ulong id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        const string deleteCommand = "DELETE FROM users WHERE id = @id;";

        using var cmd = new NpgsqlCommand(deleteCommand, connection);
        cmd.Parameters.AddWithValue("@id", id);

        int affectedRows = cmd.ExecuteNonQuery();
        if (affectedRows == 0)
            throw new InvalidOperationException("Delete failed, account not found.");
    }

    public bool ValidatePassword(ulong id, string password)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        const string command = "SELECT password FROM users WHERE id = @id;";
        using var cmd = new NpgsqlCommand(command, connection);
        cmd.Parameters.AddWithValue("@id", id);

        using NpgsqlDataReader reader = cmd.ExecuteReader();
        if (!reader.Read()) return false;
        string storedPassword = reader.GetString(0);
        return storedPassword == password;
    }

    public IEnumerable<ITransaction> GetTransactionsByAccountId(ulong id)
    {
        var transactions = new List<ITransaction>();

        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        const string command = "SELECT * FROM transactions WHERE account_id = @account_id;";
        using var cmd = new NpgsqlCommand(command, connection);
        cmd.Parameters.AddWithValue("@account_id", id);

        using NpgsqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            string transactionTypeString = reader.GetString(reader.GetOrdinal("type"));
            if (!Enum.TryParse(transactionTypeString, out TrsType transactionType)) continue;
            ITransaction transaction = transactionType switch
            {
                TrsType.Deposit => new DepositeTransaction(
                    (ulong)reader.GetInt64(reader.GetOrdinal("id")),
                    (ulong)reader.GetInt64(reader.GetOrdinal("account_id")),
                    (ulong)reader.GetInt64(reader.GetOrdinal("amount")),
                    reader.GetDateTime(reader.GetOrdinal("transaction_date"))),
                TrsType.Withdrawal => new WithdrawalTransaction(
                    (ulong)reader.GetInt64(reader.GetOrdinal("id")),
                    (ulong)reader.GetInt64(reader.GetOrdinal("account_id")),
                    (ulong)reader.GetInt64(reader.GetOrdinal("amount")),
                    reader.GetDateTime(reader.GetOrdinal("transaction_date"))),
                _ => throw new InvalidOperationException("Unknown transaction type"),
            };
            transactions.Add(transaction);
        }

        return transactions;
    }

    public bool ValidatePassword(string password)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        const string command = "SELECT password FROM users WHERE id = @id;";
        using var cmd = new NpgsqlCommand(command, connection);
        cmd.Parameters.AddWithValue("@id", AdminAccountId);

        using NpgsqlDataReader reader = cmd.ExecuteReader();
        if (!reader.Read()) return false;
        string storedAdminPassword = reader.GetString(0);
        return storedAdminPassword == password;
    }
}