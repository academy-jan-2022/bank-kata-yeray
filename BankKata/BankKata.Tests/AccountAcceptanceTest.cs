using System;
using System.IO;
using Moq;
using Xunit;

namespace BankKata.Tests;

/*
Given a client makes a deposit of 1000 on 10-01-2012
And a deposit of 2000 on 13-01-2012
And a withdrawal of 500 on 14-01-2012
When they print their bank statement
Then they would see:

Date       || Amount || Balance
14/01/2012 || -500   || 2500
13/01/2012 || 2000   || 3000
10/01/2012 || 1000   || 1000
 */

public class AccountAcceptanceTest
{
    private const string Output = @"Date ||Amount ||Balance
14/01/2012 ||-500 ||2500
13/01/2012 ||2000 ||3000
10/01/2012 ||1000 ||1000";

    [Fact(DisplayName = "Account should follow a standard deposit and withdrawall process")]
    public void Test1()
    {
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var timeProviderMock = new Mock<ITimeProvider>();
        var count = 0;
        timeProviderMock.Setup(tp => tp.Now())
            .Returns(() =>
            {
                count++;
                if (count == 1)
                    return new DateTime(2012, 01, 10);
                if (count == 2)
                    return new DateTime(2012, 01, 13);
                return new DateTime(2012, 01, 14);
            });

        var account = new Account(new TransactionRepository(timeProviderMock.Object), new UserInterface());
        account.Deposit(1000);
        account.Deposit(2000);
        account.Withdraw(500);
        account.PrintStatement();
        Assert.Equal(Output, stringWriter.ToString());
    }
}
