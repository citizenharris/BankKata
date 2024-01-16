namespace BankAccount.Interfaces;

public interface ITransactionRepository
{
    void Deposit(int amount);
    void Withdraw(int amount);
    IReadOnlyList<Transaction> GetAllTransactions();
}
