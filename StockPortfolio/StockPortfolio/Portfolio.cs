namespace StockPortfolio;

public class Portfolio
{
    private readonly IShareRepository _shareRepository;
    private readonly ITransactionRepository _transactionRepository;

    public Portfolio(IShareRepository shareRepository, ITransactionRepository transactionRepository)
    {
        _shareRepository = shareRepository ?? throw new ArgumentNullException(nameof(shareRepository));
        _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
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
        return @"
company | shares | current price | current value | last operation
Old School Waterfall Software LTD | 500 | $5.75 | $2,875.00 | sold 500 on 11/12/2018
Crafter Masters Limited | 400 | $17.25 | $6,900.00 | bought 400 on 09/06/2016
XP Practitioners Incorporated | 700 | $25.55 | $17,885.00 | bought 700 on 10/12/2018
";
    }
}