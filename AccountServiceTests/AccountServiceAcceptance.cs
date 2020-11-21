using System;
using System.Collections.Generic;
using Bank;
using Bank.Interfaces;
using Moq;
using NUnit.Framework;

namespace AccountServiceTests
{
    public class AccountServiceAcceptance
    {
        [Test]
        public void GivenHistoryAccountServicePrintsStatement()
        {
            // Arrange
            var printer = new Mock<IPrinter>();
            var statementPrinter = new StatementPrinter(printer.Object);
            var dateTimeHandler = new Mock<IDateTimeHandler>();

            var dateTimeQueue = new Queue<DateTime>(new[]
            {
                new DateTime(2012, 01, 10), 
                new DateTime(2012, 01, 13), 
                new DateTime(2012, 01, 14)
            });

            dateTimeHandler
                .Setup(dth => dth.Now())
                .Returns(dateTimeQueue.Dequeue);

            var repo = new TransactionRepository(dateTimeHandler.Object);
            var sequence = new MockSequence();
            var account = new AccountService(statementPrinter, repo);
            printer.InSequence(sequence).Setup(c => c.Print("Date || Amount || Balance"));
            printer.InSequence(sequence).Setup(c => c.Print("14/01/2012 || -500 || 2500"));
            printer.InSequence(sequence).Setup(c => c.Print("13/01/2012 || 2000 || 3000"));
            printer.InSequence(sequence).Setup(c => c.Print("10/01/2012 || 1000 || 1000"));
            
            // Act
            account.Deposit(1000);
            account.Deposit(2000);
            account.Withdraw(500);
            account.PrintStatement();
            
            // Assert
            printer.Verify(c => c.Print("Date || Amount || Balance"));
            printer.Verify(c => c.Print("14/01/2012 || -500 || 2500"));
            printer.Verify(c => c.Print("13/01/2012 || 2000 || 3000"));
            printer.Verify(c => c.Print("10/01/2012 || 1000 || 1000"));

        }
    }
}