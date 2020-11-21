using System;
using Bank.Interfaces;

namespace Bank
{
    public class AccountService : IAccountService
    {
        private readonly IConsole _console;
        private readonly ITransactionRepository _transactionRepo;

        public AccountService(IConsole console, ITransactionRepository transactionRepo)
        {
            _console = console;
            _transactionRepo = transactionRepo;
        }

        public void Deposit(int amount)
        {
            _transactionRepo.Deposit(amount);
        }

        public void Withdraw(int amount)
        {
            _transactionRepo.Withdraw(amount);
        }

        public void PrintStatement()
        {
            throw new NotImplementedException();
        }
    }
}
