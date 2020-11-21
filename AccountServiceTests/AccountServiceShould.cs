using Bank;
using Bank.Interfaces;
using Moq;
using NUnit.Framework;

namespace AccountServiceTests
{
    public class AccountServiceShould
    {
        private Mock<IConsole> _console;
        private Mock<ITransactionRepository> _transactionRepo;
        private AccountService _account;

        [SetUp]
        public void Setup()
        {
            _console = new Mock<IConsole>();
            _transactionRepo = new Mock<ITransactionRepository>();
            _account = new AccountService(_console.Object, _transactionRepo.Object);
        }

        [Test]
        public void AcceptADeposit()
        {
            _account.Deposit(3);
            _transactionRepo.Verify(r => r.Deposit(3), Times.Once);
        }

        [Test]
        public void AcceptAWithdrawal()
        {
            _account.Withdraw(5);
            _transactionRepo.Verify(r => r.Withdraw(5), Times.Once);
        }
    }
}
