namespace StockPortfolio;

public class StatementGenerator : IStatementGenerator
{
    private readonly IShareRepository _shareRepository;

    public StatementGenerator(IShareRepository shareRepository)
    {
        _shareRepository = shareRepository ?? throw new ArgumentNullException(nameof(shareRepository));
    }
    
    public Statement Generate(List<Transaction> transactions)
    {
        var lines = new Dictionary<Share, StatementLine>();
        
        foreach (var transaction in transactions)
        {
            if (lines.TryGetValue(transaction.Share, out var existingLine))
            {
                existingLine.ShareUnits = new ShareUnits(existingLine.ShareUnits.Number + transaction.Units.Number);
                existingLine.Value = CalculateHoldingValue(existingLine.ShareUnits, existingLine.Price);
                existingLine.LastOperation = GetLastOperation(transaction);
                lines[transaction.Share] = existingLine;
            }
            else
            {
                var price = _shareRepository.GetSharePrice(transaction.Share);
                var holdingValue = CalculateHoldingValue(transaction.Units, price);
                var newLine = new StatementLine(transaction.Share, transaction.Units, price, holdingValue, transaction.Date, GetLastOperation(transaction));
                lines.Add(newLine.Share, newLine);
            }
        }

        var orderedLines = lines.Values
            .OrderByDescending(x => x.FirstOperationDate)
            .ToList();
        
        return new Statement(orderedLines);
    }

    private static decimal CalculateHoldingValue(ShareUnits units, SharePrice price)
    {
        return units.Number * price.Value;
    }

    private string GetLastOperation(Transaction transaction)
    {
        string boughtOrSold = transaction.Units.Number >= 0 ? "bought" : "sold";
        return $"{boughtOrSold} {Math.Abs(transaction.Units.Number)} on {transaction.Date.ToString("dd/MM/yyyy")}";
    }
}