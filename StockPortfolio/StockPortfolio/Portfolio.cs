using System.Globalization;
using System.Text;

namespace StockPortfolio;

public class Portfolio
{
    private static readonly CultureInfo CurrencyCulture = CultureInfo.GetCultureInfo("en-US");
    
    private readonly IShareRepository _shareRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IStatementGenerator _statementGenerator;

    public Portfolio(
        IShareRepository shareRepository, 
        ITransactionRepository transactionRepository,
        IStatementGenerator statementGenerator)
    {
        _shareRepository = shareRepository ?? throw new ArgumentNullException(nameof(shareRepository));
        _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
        _statementGenerator = statementGenerator ?? throw new ArgumentNullException(nameof(statementGenerator));
    }
    
    public void Buy(Share share, ShareUnits units, DateOnly date)
    {
        var transaction = new Transaction(share, units, date);
        _transactionRepository.Save(transaction);
    }

    public void Sell(Share share, ShareUnits units, DateOnly date)
    {
        var transaction = new Transaction(share, new ShareUnits(0 - units.Number), date);
        _transactionRepository.Save(transaction);
    }

    public string Print()
    {
        var transactions = _transactionRepository.GetAll();
        var statement = _statementGenerator.Generate(transactions);

        var output = new StringBuilder();
        output.AppendLine();
        output.AppendLine("company | shares | current price | current value | last operation");
        
        foreach (var line in statement.Lines)
        {
            output.AppendLine($"{line.Share.Name} | {line.ShareUnits.Number} | {FormatCurrency(line.Price.Value)} | {FormatCurrency(line.Value)} | {line.LastOperation}");
        }

        return output.ToString();
    }

    private string FormatCurrency(decimal value)
    {
        return value.ToString("C", CurrencyCulture);
    }
}