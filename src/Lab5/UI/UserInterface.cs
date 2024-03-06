using Core.Entities.Account;
using Core.Entities.Transaction;
using Core.Services.AccountService;
using Core.Services.Parser;
using Core.Services.RepositoryInterfaces;
using Infrastructure;

namespace UI;

public class UserInterface
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUserService _userService;
    private readonly IAdminService _adminService;
    private readonly string _connectionString;

    public UserInterface(IAccountRepository accountRepository, IUserService userService, IAdminService adminService, string connectionString)
    {
        _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

    public void Start()
    {
        InitializeDatabase();

        Console.WriteLine("Enter command (example: -id 12345 -p password):");
        string? input = Console.ReadLine();
        string[] args = input?.Split(' ') ?? Array.Empty<string>();

        CommandLineArgs parsedArgs = ParseCommandLineArgs(args);
        AccType accountType = DetermineAccountType(parsedArgs);

        switch (accountType)
        {
            case AccType.User:
                HandleUserCommands(parsedArgs);
                break;
            case AccType.Admin:
                HandleAdminCommands();
                break;
            case AccType.Invalid:
                Console.WriteLine("Invalid account type.");
                break;
            default:
                Console.WriteLine("Unknown account type.");
                break;
        }
    }

    private static CommandLineArgs ParseCommandLineArgs(string[] args)
    {
        var commandLineArgs = new CommandLineArgs();
        var idHandler = new IdHandler();
        var passwordHandler = new PasswordHandler();

        idHandler.SetNext(passwordHandler);

        int position = 0;
        while (position < args.Length)
        {
            idHandler.Handle(args, commandLineArgs, ref position);
            position++;
        }

        return commandLineArgs;
    }

    private void InitializeDatabase()
    {
        var tableInitializer = new TableInitializer(_connectionString);
        tableInitializer.Initialize();
    }

    private AccType DetermineAccountType(CommandLineArgs args)
    {
        if (string.IsNullOrEmpty(args.Id)) return AccType.Invalid;
        if (args.Id.Equals("1", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(args.Password))
            return _accountRepository.ValidatePassword(args.Password) ? AccType.Admin : AccType.Invalid;

        if (ulong.TryParse(args.Id, out ulong accountId) && !string.IsNullOrEmpty(args.Password))
            return _accountRepository.ValidatePassword(accountId, args.Password) ? AccType.User : AccType.Invalid;

        return AccType.Invalid;
    }

    private void HandleUserCommands(CommandLineArgs parsedArgs)
    {
        if (!ulong.TryParse(parsedArgs.Id, out ulong accountId))
        {
            Console.WriteLine("Invalid account ID.");
            return;
        }

        while (true)
        {
            Console.WriteLine("\nChoose operation:");
            Console.WriteLine("1. Check balance");
            Console.WriteLine("2. Withdraw from account");
            Console.WriteLine("3. Deposit to account");
            Console.WriteLine("4. View transaction history");
            Console.WriteLine("5. Exit");

            string? operation = Console.ReadLine();
            switch (operation)
            {
                case "1":
                    IAccount account = _userService.GetAccount(accountId);
                    Console.WriteLine($"Balance account: {account.Balance}");
                    break;
                case "2":
                    Console.WriteLine("Enter amount to withdraw:");
                    if (ulong.TryParse(Console.ReadLine(), out ulong withdrawAmount))
                    {
                        try
                        {
                            _userService.Withdraw(accountId, withdrawAmount);
                            Console.WriteLine("Withdrawal successful.");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount.");
                    }

                    break;
                case "3":
                    Console.WriteLine("Enter amount to deposit:");
                    if (ulong.TryParse(Console.ReadLine(), out ulong depositAmount))
                    {
                        _userService.Deposit(accountId, depositAmount);
                        Console.WriteLine("Deposit successful.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount.");
                    }

                    break;
                case "4":
                    PrintTransactionHistory(accountId);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid operation, please try again.");
                    break;
            }
        }
    }

    private void PrintTransactionHistory(ulong accountId)
    {
        Console.WriteLine("Transaction History:");

        IEnumerable<ITransaction> transactions = _userService.GetTransactions(accountId);
        foreach (ITransaction transaction in transactions)
        {
            Console.WriteLine($"ID: {transaction.Id}, Amount: {transaction.Amount}, Type: {transaction.Type}, Date: {transaction.TransactionDate}");
        }
    }

    private void HandleAdminCommands()
    {
        while (true)
        {
            Console.WriteLine("\nChoose operation:");
            Console.WriteLine("1. Create new account");
            Console.WriteLine("2. Delete account");
            Console.WriteLine("3. Exit");

            string? operation = Console.ReadLine();
            switch (operation)
            {
                case "1":
                    CreateNewAccount();
                    break;
                case "2":
                    DeleteAccount();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid operation, please try again.");
                    break;
            }
        }
    }

    private void CreateNewAccount()
    {
        const ulong balance = 0;
        Console.WriteLine("Enter account type (User/Admin):");
        string? accountTypeInput = Console.ReadLine();
        if (!Enum.TryParse(accountTypeInput, true, out AccType accountType))
        {
            Console.WriteLine("Invalid account type");
            return;
        }

        Console.WriteLine("Enter pin-code:");
        string? pinCode = Console.ReadLine();

        var account = new UserAccount(1, balance, pinCode ?? string.Empty, accountType);
        _adminService.CreateNewAccount(account);

        Console.WriteLine($"Account with ID {account.Id} has been successfully created.");
    }

    private void DeleteAccount()
    {
        Console.WriteLine("Enter ID of the account to delete:");
        if (!ulong.TryParse(Console.ReadLine(), out ulong accountId))
        {
            Console.WriteLine("Invalid account ID");
            return;
        }

        try
        {
            _adminService.DeleteAccount(accountId);
            Console.WriteLine($"Account with ID {accountId} deleted successfully.");
        }
        catch (AggregateException ex)
        {
            Console.WriteLine($"Operation cannot be executed: {ex.Message}");
        }
    }
}