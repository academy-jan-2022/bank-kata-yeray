namespace BankKata.Tests;

public class TimeProvider : ITimeProvider
{
    public DateTime Now() =>
        DateTime.Now.Date;
}
