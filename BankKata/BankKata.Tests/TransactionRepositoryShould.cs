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
        repository.Add(100);
        var transactions = repository.GetTransactions();
        var expected = new List<Transaction> { new(100, expectedDate) }.AsEnumerable();
        Assert.Equal(expected, transactions);
    }
}
