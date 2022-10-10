using System.Reflection;
using FluentAssertions;
using Xunit;

namespace StockPortfolio.Tests;

public class TransactionRepositoryShould
{
    [Theory]
    [InlineAutoNSubstituteData]
    public void Save_A_Transaction(
        Transaction transaction,
        TransactionRepository sut)
    {
        sut.Save(transaction);

        sut.GetAll().Should().BeEquivalentTo(new List<Transaction> { transaction });
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Get_All_Transactions_In_Date_Descending_Order(
        Transaction transaction1,
        Transaction transaction2,
        Transaction transaction3,
        TransactionRepository sut)
    {
        sut.Save(transaction1);
        sut.Save(transaction2);
        sut.Save(transaction3);

        var actual = sut.GetAll();

        actual.Should().HaveCount(3);
        actual.Should().Contain(transaction1);
        actual.Should().Contain(transaction2);
        actual.Should().Contain(transaction3);
        actual[0].Date.Should().BeOnOrAfter(actual[1].Date);
        actual[1].Date.Should().BeOnOrAfter(actual[2].Date);
    }
}