namespace BankKata;

public interface ITransactionRepository
{
    void Add(Money money);
    Balance GetBalance();
}
