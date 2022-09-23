namespace Bank;

public class TransactionRepository : ITransactionRepository
{
    private readonly IClock _clock;
    private readonly List<Transaction> _transactions = new List<Transaction>();

    public TransactionRepository(IClock clock)
    {
        _clock = clock ?? throw new ArgumentNullException(nameof(clock));
    }
    
    public void Deposit(int amount)
    {
        var transaction = new Transaction
        {
            Amount = amount,
            Date = _clock.Today()
        };
        
        _transactions.Add(transaction);
    }

    public void Withdraw(int amount)
    {
        var transaction = new Transaction
        {
            Amount = -amount,
            Date = _clock.Today()
        };
        
        _transactions.Add(transaction);
    }

    public List<Transaction> GetTransactions()
    {
        return _transactions;
    }
}