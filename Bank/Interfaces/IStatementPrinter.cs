namespace BankAccount.Interfaces;

public interface IStatementPrinter
{
    public void Print(IReadOnlyCollection<Transaction> transactions);
}
