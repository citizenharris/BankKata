namespace BankAccount;

public class Transaction
{
    public Transaction(DateTime timestamp, int amount)
    {
        Timestamp = timestamp;
        Amount = amount;
    }

    public DateTime Timestamp { get; }
    public int Amount { get; }
}
