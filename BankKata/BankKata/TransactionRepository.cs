namespace BankKata;

public class TransactionRepository : ITransactionRepository
{
    private readonly ITimeProvider timeProvider;
    private readonly List<Transaction> transactions = new();

    public TransactionRepository(ITimeProvider timeProvider) =>
        this.timeProvider = timeProvider;

    public void Add(int amount) =>
        transactions.Add(new Transaction(amount, timeProvider.Now()));

    public IEnumerable<Transaction> GetTransactions() =>
        transactions;
}
