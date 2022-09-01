using BankAccount.Interfaces;

namespace BankAccount;

public class StatementPrinter : IStatementPrinter
{
    private readonly IPrinter _printer;
    private const string StatementHeader = "Date || Amount || Balance";

    public StatementPrinter(IPrinter printer)
    {
        _printer = printer;
    }

    public void Print(IReadOnlyCollection<Transaction> transactions)
    {
        _printer.Print(StatementHeader);

        var balance = transactions.Sum(t => t.Amount);
        foreach (var transaction in transactions.OrderByDescending(t => t.Timestamp))
        {
            _printer.Print($"{transaction.Timestamp:d} || {transaction.Amount} || {balance}");
            balance -= transaction.Amount;
        }
    }
}
