namespace BankKata;

public interface ITransactionRepository
{
    void Add(int amount);
    IEnumerable<Transaction> GetTransactions();
}
