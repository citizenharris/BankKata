namespace AccountServiceTests;

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
        var actualTransactions = transactionRepo.GetAllTransactions().ToList();

        actualTransactions.ForEach(t =>
        {
            Assert.Multiple(() =>
            {
                Assert.That(t.Timestamp, Is.EqualTo(now));
                Assert.That(t.Amount, Is.EqualTo(5));
            });
        });
    }
}
