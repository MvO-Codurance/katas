namespace StockPortfolio;

public class ShareRepository : IShareRepository
{
    private Dictionary<Share, SharePrice> _prices = new();

    public void SetSharePrice(Share share, SharePrice price)
    {
        if (_prices.ContainsKey(share))
        {
            _prices[share] = price;
            return;
        }
            
        _prices.Add(share, price);
    }

    public SharePrice GetSharePrice(Share share)
    {
        if (_prices.TryGetValue(share, out var price))
        {
            return price;
        };

        return new SharePrice(0.00m);
    }
}