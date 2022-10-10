namespace StockPortfolio;

public interface ITransactionRepository
{
    public void Save(Transaction transaction);
    public List<Transaction> GetAll();
}