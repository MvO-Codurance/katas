using FluentAssertions;
using Xunit;

namespace StockPortfolio.Tests;

public class ShareRepositoryShould
{
    [Theory]
    [InlineAutoNSubstituteData]
    public void Store_Share_Price(
        Share share,
        SharePrice price,
        ShareRepository sut)
    {
        sut.SetSharePrice(share, price);

        sut.GetSharePrice(share).Should().Be(price);
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Give_Zero_Price_When_The_Share_Does_Not_Exist(
        Share share,
        ShareRepository sut)
    {
        sut.GetSharePrice(share).Should().Be(new SharePrice(0.00m));
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Update_The_Price_When_The_Price_Is_Updated(
        Share share,
        SharePrice price1,
        SharePrice price2,
        ShareRepository sut)
    {
        sut.SetSharePrice(share, price1);
        sut.SetSharePrice(share, price2);

        sut.GetSharePrice(share).Should().Be(price2);
    }
}