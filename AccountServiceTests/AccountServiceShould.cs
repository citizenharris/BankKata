using Bank;
using Moq;
using NUnit.Framework;

namespace AccountServiceTests
{
    public class AccountServiceShould
    {
        [Test]
        public void PrintStatementGivenHistory()
        {
            // Arrange
            var console = new Mock<IConsole>();
            var sequence = new MockSequence();
            var account = new AccountService(console.Object);
            console.InSequence(sequence).Setup(c => c.Print("Date || Amount || Balance"));
            console.InSequence(sequence).Setup(c => c.Print("14/01/2012 || -500 || 2500"));
            console.InSequence(sequence).Setup(c => c.Print("13/01/2012 || 2000 || 3000"));
            console.InSequence(sequence).Setup(c => c.Print("10/01/2012 || 1000 || 1000"));
            
            // Act
            account.Deposit(1000);
            account.Deposit(2000);
            account.Withdraw(500);
            account.PrintStatement();
            
            // Assert
            console.Verify(c => c.Print("Date || Amount || Balance"));
            console.Verify(c => c.Print("14/01/2012 || -500 || 2500"));
            console.Verify(c => c.Print("13/01/2012 || 2000 || 3000"));
            console.Verify(c => c.Print("10/01/2012 || 1000 || 1000"));

        }
    }
}