using BankAccount.Interfaces;

namespace BankAccount;

public class AccountService : IAccountService
{
    private readonly IStatementPrinter _statementPrinter;
    private readonly ITransactionRepository _transactionRepo;

    public AccountService(IStatementPrinter statementPrinter, ITransactionRepository transactionRepo)
    {
        _statementPrinter = statementPrinter;
        _transactionRepo = transactionRepo;
    }

    public void Deposit(int amount) => _transactionRepo.Deposit(amount);

    public void Withdraw(int amount) => _transactionRepo.Withdraw(amount);

    public void PrintStatement() => _statementPrinter.Print(_transactionRepo.GetAllTransactions());
}
