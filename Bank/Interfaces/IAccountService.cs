namespace BankAccount.Interfaces;

public interface IAccountService
{
    public void Deposit(int amount);
    public void Withdraw(int amount);
    public void PrintStatement();
}