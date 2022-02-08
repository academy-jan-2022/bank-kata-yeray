namespace BankKata;

public class Account
{
    private readonly ITransactionRepository repository;

    public Account(ITransactionRepository repository) =>
        this.repository = repository;

    public void Deposit(int amount) =>
        repository.Add(amount);

    public void Withdraw(int amount) =>
        throw new NotImplementedException();

    public void PrintStatement() =>
        throw new NotImplementedException();
}
