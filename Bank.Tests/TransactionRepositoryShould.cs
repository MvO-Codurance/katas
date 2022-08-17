using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using Xunit;

namespace Bank.Tests;

public class TransactionRepositoryShould
{
    [Theory]
    [InlineAutoMoqData]
    public void AcceptDeposit(
        int amount,
        DateOnly date,
        [Frozen] Mock<IClock> clock,
        TransactionRepository sut)
    {
        // arrange
        clock.Setup(x => x.Today()).Returns(date);
        
        // act
        sut.Deposit(amount);

        // assert
        var expectedTransactions = new List<Transaction>
        {
            new Transaction { Amount = amount, Date = date }
        };
        
        sut.GetTransactions().Should().BeEquivalentTo(expectedTransactions);
    }
    
    [Theory]
    [InlineAutoMoqData]
    public void AcceptWithdraw(
        int amount,
        DateOnly date,
        [Frozen] Mock<IClock> clock,
        TransactionRepository sut)
    {
        // arrange
        clock.Setup(x => x.Today()).Returns(date);
        
        // act
        sut.Withdraw(amount);

        // assert
        var expectedTransactions = new List<Transaction>
        {
            new Transaction { Amount = -amount, Date = date }
        };
        
        sut.GetTransactions().Should().BeEquivalentTo(expectedTransactions);
    }
}