using Moq;
using Xunit;

namespace BankKata.Tests;

public class AccountShould
{
    [Fact(DisplayName = "deposit an amount")]
    public void Test1()
    {
        var repoMock = new Mock<ITransactionRepository>();
        var account = new Account(repoMock.Object);
        account.Deposit(1000);
        repoMock.Verify(repo => repo.Add(1000), Times.Once);
    }

    [Fact(DisplayName = "withdraws an amount")]
    public void Test2()
    {
        var repoMock = new Mock<ITransactionRepository>();
        var account = new Account(repoMock.Object);
        account.Withdraw(1000);
        repoMock.Verify(repo => repo.Add(-1000), Times.Once);
    }
}
