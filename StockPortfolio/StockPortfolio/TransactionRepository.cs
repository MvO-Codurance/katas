namespace StockPortfolio;

public class TransactionRepository : ITransactionRepository
{
    private List<Transaction> _transactions = new();

    public void Save(Transaction transaction)
    {
        _transactions.Add(transaction);
    }

    public List<Transaction> GetAll()
    {
        return _transactions.OrderByDescending(t => t.Date).ToList();
    }
}