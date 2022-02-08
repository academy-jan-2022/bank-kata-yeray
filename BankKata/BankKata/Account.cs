namespace BankKata;

public class Account
{
    private readonly ITransactionRepository repository;
    private readonly IUserInterface userInterface;

    public Account(ITransactionRepository repository, IUserInterface userInterface)
    {
        this.repository = repository;
        this.userInterface = userInterface;
    }

    public void Deposit(int amount) =>
        repository.Add(new Money(amount));

    public void Withdraw(int amount) =>
        repository.Add(new Money(-amount));

    public void PrintStatement()
    {
        var toPrint = new List<string> { "Date ||Amount ||Balance" };
        var balance = repository.GetBalance();
        toPrint.AddRange(balance.Render(
            (transaction, bal) => $"{transaction.Date:dd/MM/yyyy} ||{transaction.Money.Amount} ||{bal}")
        );
        userInterface.Write(string.Join(Environment.NewLine, toPrint));
    }
}
