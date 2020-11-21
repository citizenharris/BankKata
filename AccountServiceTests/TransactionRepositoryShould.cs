using Bank;
using Bank.Interfaces;
using Castle.Core.Internal;
using Moq;
using NUnit.Framework;
using System;

namespace AccountServiceTests
{
    public class TransactionRepositoryShould
    {
        [Test]
        public void DepositTransaction()
        {
            var now = DateTime.Now;
            var dateTimeHandler = new Mock<IDateTimeHandler>();
            dateTimeHandler.Setup(dth => dth.Now()).Returns(now);
            var transactionRepo = new TransactionRepository(dateTimeHandler.Object);
            
            transactionRepo.Deposit(5);
            var actualTransactions = transactionRepo.GetAllTransactions();
            
            actualTransactions.ForEach(t =>
            {
                Assert.AreEqual(now, t.Timestamp);
                Assert.AreEqual(5, t.Amount);
            });
        }
    }
}
