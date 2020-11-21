namespace Bank
{
    public interface IAccountService
    {
        public void Deposit(int amount);
        public void Withdraw(int amount);
        public void PrintStatement();
    }
}
