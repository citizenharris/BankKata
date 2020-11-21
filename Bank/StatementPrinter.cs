using Bank.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Bank
{
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

            var balance = 0;
            var toBePrinted = new List<string>();
            foreach (var transaction in transactions.OrderBy(t => t.Timestamp))
            {
                balance += transaction.Amount;
                toBePrinted.Add($"{transaction.Timestamp:d} || {transaction.Amount} || {balance}");
            }

            toBePrinted.ForEach(line => _printer.Print(line));
        }
    }
}
