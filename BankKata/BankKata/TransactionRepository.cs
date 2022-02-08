namespace BankKata;

public class TransactionRepository : ITransactionRepository
{
    private readonly ITimeProvider timeProvider;
    private readonly List<Transaction> transactions = new();

    public TransactionRepository(ITimeProvider timeProvider) =>
        this.timeProvider = timeProvider;

    public void Add(Money money) =>
        transactions.Add(new Transaction(money, timeProvider.Now()));

    public IEnumerable<Transaction> GetTransactions() =>
        transactions;
}
