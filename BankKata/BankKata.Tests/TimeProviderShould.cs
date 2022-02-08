using System;
using Xunit;

namespace BankKata.Tests;

public class TimeProviderShould
{
    [Fact(DisplayName = "return today's date")]
    public void Test1()
    {
        ITimeProvider provider = new TimeProvider();
        var result = provider.Now();
        var expected = DateTime.Now.Date;
        Assert.Equal(expected, result);
    }
}
