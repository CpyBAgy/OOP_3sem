using Npgsql;

namespace Infrastructure;

public class TableInitializer
{
    private readonly string _connectionString;

    public TableInitializer(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Initialize()
    {
        try
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            InitializeWithDefaultData(connection);
            CreateUsersTable(connection);
            CreateTransactionsTable(connection);
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine($"Error initializing tables: {ex.Message}");
        }
    }

    private static void InitializeWithDefaultData(NpgsqlConnection connection)
    {
        try
        {
            using var checkCmd = new NpgsqlCommand("SELECT COUNT(*) FROM users WHERE type = 'Admin'", connection);
            object? result = checkCmd.ExecuteScalar();
            int count = (result as int?) ?? 0;

            if (count != 0) return;
            using var insertCmd = new NpgsqlCommand("INSERT INTO users (type, balance, pin_code) VALUES ('Admin', 0, '12345')", connection);
            insertCmd.ExecuteNonQuery();
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine($"Error initializing default data: {ex.Message}");
        }
    }

    private static void CreateUsersTable(NpgsqlConnection connection)
    {
        const string createUsersTableCommand = @"
                                                 CREATE TABLE IF NOT EXISTS users (
                                                    id SERIAL PRIMARY KEY,
                                                    type VARCHAR(255),
                                                    balance DECIMAL,
                                                    password VARCHAR(255));";
        try
        {
            using var cmdUsers = new NpgsqlCommand(createUsersTableCommand, connection);
            cmdUsers.ExecuteNonQuery();
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine($"Error creating users table: {ex.Message}");
        }
    }

    private static void CreateTransactionsTable(NpgsqlConnection connection)
    {
        const string createTransactionsTableCommand = @"
                                                        CREATE TABLE IF NOT EXISTS transactions (
                                                            id SERIAL PRIMARY KEY,
                                                            account_id INTEGER REFERENCES users(id),
                                                            amount DECIMAL,
                                                            type VARCHAR(255));";
        try
        {
            using var cmdTransactions = new NpgsqlCommand(createTransactionsTableCommand, connection);
            cmdTransactions.ExecuteNonQuery();
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine($"Error creating transactions table: {ex.Message}");
        }
    }
}
