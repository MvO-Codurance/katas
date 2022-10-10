namespace StockPortfolio;

public interface IShareRepository
{
    public void SetSharePrice(Share share, SharePrice price);
    public SharePrice GetSharePrice(Share share);
}