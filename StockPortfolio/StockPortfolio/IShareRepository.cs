namespace StockPortfolio;

public interface IShareRepository
{
    public void SetShareValue(Share share, ShareValue value);
}