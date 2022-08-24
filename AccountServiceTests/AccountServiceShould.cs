namespace AccountServiceTests;

public class AccountServiceShould
{
    private Mock<ITransactionRepository> _transactionRepo;
    private AccountService _account;
    private Mock<IStatementPrinter> _statementPrinter;

    [SetUp]
    public void Setup()
    {
        _statementPrinter = new Mock<IStatementPrinter>();
        _transactionRepo = new Mock<ITransactionRepository>();
        _account = new AccountService(_statementPrinter.Object, _transactionRepo.Object);
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

    [Test]
    public void PrintAStatement()
    {
        var transactions = new List<Transaction>
        {
            new(DateTime.Now, 5),
            new(DateTime.Now, 6)
        };
        _transactionRepo.Setup(r => r.GetAllTransactions()).Returns(transactions);
        
        _account.PrintStatement();
        
        _statementPrinter.Verify(c => c.Print(transactions), Times.Once);
    }
}