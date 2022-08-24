namespace BankAccount.Interfaces;

public interface IStatementPrinter
{
    public void Print(IReadOnlyList<Transaction> transactions);
}