using BankAccount.Interfaces;

namespace BankAccount;

public class StatementPrinter : IStatementPrinter
{
    private readonly IPrinter _printer;

    public StatementPrinter(IPrinter printer)
    {
        _printer = printer;
    }

    public void Print(IReadOnlyList<Transaction> transactions)
    {
        _printer.Print("Date || Amount || Balance");

        var balance = transactions.Sum(t => t.Amount);
        foreach (var transaction in transactions.OrderByDescending(t => t.Timestamp))
        {
            _printer.Print($"{transaction.Timestamp:d} || {transaction.Amount} || {balance}");
            balance -= transaction.Amount;
        }
    }
}