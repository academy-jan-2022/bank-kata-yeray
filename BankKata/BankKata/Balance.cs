namespace BankKata;

public class Balance
{
    private readonly List<Transaction> transactions = new();

    public void Add(Money money, DateTime time) =>
        transactions.Add(new Transaction(money, time));

    public IEnumerable<string> Render(Func<Transaction, int, string> renderer)
    {
        var result = new List<string>();
        var balance = 0;

        foreach (var transaction in transactions)
        {
            balance += transaction.Money.Amount;
            result.Add(renderer(transaction, balance));
        }

        return result;
    }

}
