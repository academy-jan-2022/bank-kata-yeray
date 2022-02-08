using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BankKata.Tests;

public class TransactionRepositoryShould
{
    [Fact(DisplayName = "register a transaction")]
    public void Test1()
    {
        ITransactionRepository repository = new TransactionRepository();
        repository.Add(100);
        var transactions = repository.GetTransactions();
        var expected = new List<Transaction>
        {
            new(100, new DateTime(2017, 01, 01))
        }.AsEnumerable();
        Assert.Equal(expected, transactions);
    }
}
