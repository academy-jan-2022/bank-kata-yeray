using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;

namespace BankKata.Tests;

public class TransactionRepositoryShould
{
    [Fact(DisplayName = "register a transaction")]
    public void Test1()
    {
        var timeProviderMock = new Mock<ITimeProvider>();
        var expectedDate = new DateTime(2017, 01, 01);
        timeProviderMock.Setup(tp => tp.Now()).Returns(expectedDate);
        ITransactionRepository repository = new TransactionRepository(timeProviderMock.Object);
        repository.Add(new Money(100));
        var balance = repository.GetBalance();
        var expected = new List<string> { "01/01/2017 ||100 ||100" };
        var result = balance.Render(
            (transaction, bal) => $"{transaction.Date:dd/MM/yyyy} ||{transaction.Money.Amount} ||{bal}"
        );
        Assert.Equal(expected, result);
    }
}
