using System;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace BankKata.Tests;

public class AccountShould
{
    [Fact(DisplayName = "deposit an amount")]
    public void Test1()
    {
        var repoMock = new Mock<ITransactionRepository>();
        var userInterface = new Mock<IUserInterface>();
        var account = new Account(repoMock.Object, userInterface.Object);
        account.Deposit(1000);
        repoMock.Verify(repo => repo.Add(new Money(1000)), Times.Once);
    }

    [Fact(DisplayName = "withdraws an amount")]
    public void Test2()
    {
        var repoMock = new Mock<ITransactionRepository>();
        var userInterface = new Mock<IUserInterface>();
        var account = new Account(repoMock.Object, userInterface.Object);
        account.Withdraw(1000);
        repoMock.Verify(repo => repo.Add(new Money(-1000)), Times.Once);
    }

    [Fact(DisplayName = "print a statement")]
    public void Test3()
    {
        const string expected = @"Date ||Amount ||Balance
19/08/2019 ||-500 ||500
01/01/2017 ||1000 ||1000";
        var userInterface = new Mock<IUserInterface>();
        var repoMock = new Mock<ITransactionRepository>();
        var balance = new Balance();
        balance.Add(new Money(1000), new DateTime(2017, 01, 01));
        balance.Add(new Money(-500), new DateTime(2019, 08, 19));

        repoMock.Setup(r => r.GetBalance()).Returns(balance);
        var account = new Account(repoMock.Object, userInterface.Object);
        account.PrintStatement();
        userInterface.Verify(ui => ui.Write(expected));
    }
}
