namespace BankKata;

public interface ITransactionRepository
{
    void Add(Money money);
    IEnumerable<Transaction> GetTransactions();
}
