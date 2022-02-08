namespace BankKata;

public class UserInterface : IUserInterface
{
    public void Write(string output) =>
        Console.Write(output);
}
