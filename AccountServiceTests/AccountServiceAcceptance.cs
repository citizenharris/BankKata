namespace AccountServiceTests;

public class AccountServiceAcceptance
{
    private const string StatementHeader = "Date || Amount || Balance";
    private const string Line1 = "14/01/2012 || -500 || 2500";
    private const string Line2 = "13/01/2012 || 2000 || 3000";
    private const string Line3 = "10/01/2012 || 1000 || 1000";

    [Test]
    public void GivenHistoryAccountServicePrintsStatement()
    {
        // Arrange
        var printer = new Mock<IPrinter>(MockBehavior.Strict);
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
        printer.InSequence(sequence).Setup(c => c.Print(StatementHeader));
        printer.InSequence(sequence).Setup(c => c.Print(Line1));
        printer.InSequence(sequence).Setup(c => c.Print(Line2));
        printer.InSequence(sequence).Setup(c => c.Print(Line3));

        var account = new AccountService(statementPrinter, repo);

        // Act
        account.Deposit(1000);
        account.Deposit(2000);
        account.Withdraw(500);
        account.PrintStatement();

        // Assert
        printer.Verify(c => c.Print(StatementHeader));
        printer.Verify(c => c.Print(Line1));
        printer.Verify(c => c.Print(Line2));
        printer.Verify(c => c.Print(Line3));
    }
}
