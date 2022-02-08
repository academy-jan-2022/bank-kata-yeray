namespace BankKata;

public class TransactionRepository : ITransactionRepository
{
    private readonly ITimeProvider timeProvider;
    private readonly Balance balance = new();

    public TransactionRepository(ITimeProvider timeProvider) =>
        this.timeProvider = timeProvider;

    public void Add(Money money) =>
        balance.Add(money, timeProvider.Now());

    public Balance GetBalance() =>
        balance;
}
