namespace BankKata;

public class Account
{
    private readonly ITransactionRepository repository;

    public Account(ITransactionRepository repository, IUserInterface userInterfaceObject) =>
        this.repository = repository;

    public void Deposit(int amount) =>
        repository.Add(new Money(amount));

    public void Withdraw(int amount) =>
        repository.Add(new Money(-amount));

    public void PrintStatement() =>
        throw new NotImplementedException();
}
