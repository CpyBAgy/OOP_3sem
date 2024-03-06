using System;
using Core.Entities.Account;
using Core.Services.AccountService;
using Core.Services.RepositoryInterfaces;
using Core.Services.TransactionService;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Tests
{
    [Fact]
    public void DepositIncreasesBalanceCorrectly()
    {
        IAccountRepository mockRepo = Substitute.For<IAccountRepository>();
        ITransactionRepository mockTransactionRepo = Substitute.For<ITransactionRepository>();
        ITransactionService transactionService = new TransactionService(mockTransactionRepo);
        var account = new UserAccount(1, 100, "password", AccType.User);
        mockRepo.GetById(1).Returns(account);
        var accountService = new UserService(mockRepo, transactionService);
        accountService.Deposit(1, 50);
        Assert.Equal(150, (int)account.Balance);
        mockRepo.Received().SaveUser(account);
    }

    [Fact]
    public void WithdrawalDecreasesBalanceCorrectly()
    {
        IAccountRepository mockRepo = Substitute.For<IAccountRepository>();
        ITransactionRepository mockTransactionRepo = Substitute.For<ITransactionRepository>();
        ITransactionService transactionService = new TransactionService(mockTransactionRepo);
        var account = new UserAccount(1, 100, "password", AccType.User);
        mockRepo.GetById(1).Returns(account);
        var accountService = new UserService(mockRepo, transactionService);
        UserService withdrawalResult = accountService;
        withdrawalResult.Withdraw(1, 50);
        Assert.Equal(50, (int)account.Balance);
        mockRepo.Received().SaveUser(account);
    }

    [Fact]
    public void WithdrawalFailsWithInsufficientBalance()
    {
        IAccountRepository mockRepo = Substitute.For<IAccountRepository>();
        ITransactionRepository mockTransactionRepo = Substitute.For<ITransactionRepository>();
        ITransactionService transactionService = new TransactionService(mockTransactionRepo);
        var account = new UserAccount(1, 25, "password", AccType.User);
        mockRepo.GetById(1).Returns(account);
        var accountService = new UserService(mockRepo, transactionService);
        UserService withdrawalResult = accountService;
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => accountService.Withdraw(1, 50));
        Assert.Equal("Not enough money", exception.Message);
        mockRepo.DidNotReceive().SaveUser(Arg.Any<UserAccount>());
    }
}