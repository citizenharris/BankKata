using Bank;
using Bank.Interfaces;
using Moq;
using NUnit.Framework;

namespace AccountServiceTests
{
    public class AccountServiceShould
    {
        [Test]
        public void AcceptADeposit()
        {
            var console = new Mock<IConsole>();
            var transactionRepo = new Mock<ITransactionRepository>();
            var account = new AccountService(console.Object, transactionRepo.Object);
            account.Deposit(3);
            transactionRepo.Verify(r => r.Deposit(3), Times.Once);
        }
    }
}
