using AutoFixture.Xunit2;
using Moq;
using Xunit;

namespace Bank.Tests;

public class AccountServiceShould
{
    [Theory]
    [InlineAutoMoqData]
    public void AcceptDeposit(
        int amount,
        [Frozen] Mock<ITransactionRepository> transactionRepository,
        AccountService sut)
    {
        // arrange
        
        // act
        sut.Deposit(amount);
        
        // assert
        transactionRepository.Verify(x => x.Deposit(amount), Times.Once);
    }
    
    [Theory]
    [InlineAutoMoqData]
    public void AcceptWithdraw(
        int amount,
        [Frozen] Mock<ITransactionRepository> transactionRepository,
        AccountService sut)
    {
        // arrange
        
        // act
        sut.Withdraw(amount);
        
        // assert
        transactionRepository.Verify(x => x.Withdraw(amount), Times.Once);
    }
    
    [Theory]
    [InlineAutoMoqData]
    public void PrintCorrectStatement(Mock<ITransactionRepository> transactionRepository)
    {
        // arrange
        transactionRepository.Setup(x => x.GetTransactions())
            .Returns(new List<Transaction>
            {
                new Transaction { Amount = 1000, Date = new DateOnly(2012, 1, 10) },
                new Transaction { Amount = 2000, Date = new DateOnly(2012, 1, 13) },
                new Transaction { Amount = -500, Date = new DateOnly(2012, 1, 14) }
            });

        // Moq's sequencing verification sucks soooo bad!!
        var statementPrinter = new Mock<IStatementPrinter>(MockBehavior.Strict);
        var sut = new AccountService(transactionRepository.Object, statementPrinter.Object);
        
        var sequence = new MockSequence();
        statementPrinter.InSequence(sequence).Setup(x => x.PrintLine("Date       || Amount || Balance"));
        statementPrinter.InSequence(sequence).Setup(x => x.PrintLine("14/01/2012 || -500   || 2500"));
        statementPrinter.InSequence(sequence).Setup(x => x.PrintLine("13/01/2012 || 2000   || 3000"));
        statementPrinter.InSequence(sequence).Setup(x => x.PrintLine("10/01/2012 || 1000   || 1000"));
        
        // act
        sut.PrintStatement();
        
        // assert
        statementPrinter.Verify(x => x.PrintLine("Date       || Amount || Balance"), Times.Once);
        statementPrinter.Verify(x => x.PrintLine("14/01/2012 || -500   || 2500"), Times.Once);
        statementPrinter.Verify(x => x.PrintLine("13/01/2012 || 2000   || 3000"), Times.Once);
        statementPrinter.Verify(x => x.PrintLine("10/01/2012 || 1000   || 1000"), Times.Once);
    }
}