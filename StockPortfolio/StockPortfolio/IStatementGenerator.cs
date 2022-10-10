namespace StockPortfolio;

public interface IStatementGenerator
{
    public Statement Generate(List<Transaction> transactions);
}