using AutoFixture.Xunit2;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace StockPortfolio.Tests;

public class StatementGeneratorShould
{
    [Theory]
    [InlineAutoNSubstituteData]
    public void Generate_Statement_Lines(
        [Frozen] IShareRepository shareRepository,
        StatementGenerator sut)
    {
        shareRepository.GetSharePrice(new Share("Old School Waterfall Software LTD")).Returns(new SharePrice(5.75m));
        shareRepository.GetSharePrice(new Share("Crafter Masters Limited")).Returns(new SharePrice(17.25m));
        shareRepository.GetSharePrice(new Share("XP Practitioners Incorporated")).Returns(new SharePrice(25.55m));
        
        var transactions = new List<Transaction>
        {
            new Transaction(new Share("Old School Waterfall Software LTD"), new ShareUnits(1000), new DateOnly(1990, 2, 14)),
            new Transaction(new Share("Crafter Masters Limited"), new ShareUnits(400), new DateOnly(2016, 6, 9)),
            new Transaction(new Share("XP Practitioners Incorporated"), new ShareUnits(700), new DateOnly(2018, 12, 10)),
            new Transaction(new Share("Old School Waterfall Software LTD"), new ShareUnits(-500), new DateOnly(2018, 12, 11))
        };

        var actual = sut.Generate(transactions);

        var expectedStatementLines = new List<StatementLine>
        {
            new StatementLine(new Share("XP Practitioners Incorporated"), new ShareUnits(700), new SharePrice(25.55m), 17885.00m, new DateOnly(2018, 12, 10), "bought 700 on 10/12/2018"),
            new StatementLine(new Share("Crafter Masters Limited"), new ShareUnits(400), new SharePrice(17.25m), 6900.00m, new DateOnly(2016, 6, 9), "bought 400 on 09/06/2016"),
            new StatementLine(new Share("Old School Waterfall Software LTD"), new ShareUnits(500), new SharePrice(5.75m), 2875.00m, new  DateOnly(1990, 2, 14), "sold 500 on 11/12/2018")
        };
        actual.Should().NotBeNull();
        actual.Lines.Should().BeEquivalentTo(expectedStatementLines);
    }
}