namespace Bank;

public interface ITransactionRepository
{
    void Deposit(int amount);

    void Withdraw(int amount);

    List<Transaction> GetTransactions();
}