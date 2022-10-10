using AutoFixture.Xunit2;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace StockPortfolio.Tests;

public class PortfolioShould
{
    [Theory]
    [InlineAutoNSubstituteData]
    public void Print_Portfolio_Correctly(
        [Frozen] IShareRepository shareRepository,
        [Frozen] ITransactionRepository transactionRepository,
        Portfolio sut)
    {
        sut.SetShareValue(new Share("Old School Waterfall Software LTD"), new ShareValue(5.75m));
        sut.SetShareValue(new Share("Crafter Masters Limited"), new ShareValue(17.25m));
        sut.SetShareValue(new Share("XP Practitioners Incorporated"), new ShareValue(25.55m));
        
        sut.Buy(new Share("Old School Waterfall Software LTD"), new ShareUnits(1000), new DateOnly(1990, 2, 14));
        sut.Buy(new Share("Crafter Masters Limited"), new ShareUnits(400), new DateOnly(2016, 6, 9));
        sut.Buy(new Share("XP Practitioners Incorporated"), new ShareUnits(700), new DateOnly(2018, 12, 10));
        sut.Sell(new Share("Old School Waterfall Software LTD"), new ShareUnits(500), new DateOnly(2018, 12, 11));

        var output = sut.Print();

        output.Should().Be(@"
company | shares | current price | current value | last operation
Old School Waterfall Software LTD | 500 | $5.75 | $2,875.00 | sold 500 on 11/12/2018
Crafter Masters Limited | 400 | $17.25 | $6,900.00 | bought 400 on 09/06/2016
XP Practitioners Incorporated | 700 | $25.55 | $17,885.00 | bought 700 on 10/12/2018
");
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Store_Share_Price(
        Share share,
        ShareValue shareValue,
        [Frozen] IShareRepository shareRepository,
        Portfolio sut)
    {
        sut.SetShareValue(share, shareValue);
        
        shareRepository.Received(1).SetShareValue(share, shareValue);
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Buy_Shares(
        Share share,
        ShareUnits units,
        DateOnly date,
        [Frozen] ITransactionRepository transactionRepository,
        Portfolio sut)
    {
        sut.Buy(share, units, date);
        
        transactionRepository.Received(1).Save(Arg.Is<Transaction>(x => 
            x.Share == share && x.Units == units && x.Date == date));
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Sell_Shares(
        Share share,
        ShareUnits units,
        DateOnly date,
        [Frozen] ITransactionRepository transactionRepository,
        Portfolio sut)
    {
        sut.Sell(share, units, date);

        var expectedUnits = new ShareUnits(0 - units.Number);
        
        transactionRepository.Received(1).Save(Arg.Is<Transaction>(x => 
            x.Share == share && x.Units == expectedUnits && x.Date == date));
    }
}

