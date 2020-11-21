using System.Collections.Generic;

namespace Bank.Interfaces
{
    public interface IStatementPrinter
    {
        public void Print(IReadOnlyList<Transaction> transactions);
    }
}
