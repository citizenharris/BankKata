using Bank.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Bank
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IDateTimeHandler _dateTimeHandler;
        private readonly IList<Transaction> _transactionStore;

        public TransactionRepository(IDateTimeHandler dateTimeHandler)
        {
            _dateTimeHandler = dateTimeHandler;
            _transactionStore = new List<Transaction>();
        }

        public void Deposit(int amount)
        {
            _transactionStore.Add(new Transaction(_dateTimeHandler.Now(), amount));
        }

        public void Withdraw(int amount)
        {
            _transactionStore.Add(new Transaction(_dateTimeHandler.Now(), -amount));
        }

        public IReadOnlyList<Transaction> GetAllTransactions()
        {
            return new ReadOnlyCollection<Transaction>(_transactionStore);
        }
    }
}
