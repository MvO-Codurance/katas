using FluentAssertions;
using Xunit;

namespace StringCalculator.Tests;

public class StringCalculatorAddShould
{
    [Theory]
    [InlineAutoMoqData]
    public void ReturnZeroWhenPassedEmptyString(StringCalculator sut)
    {
        // arrange

        // act
        int actual = sut.Add(string.Empty);

        // assert
        actual.Should().Be(0);
    }
    
    [Theory]
    [InlineAutoMoqData("4", 4)]
    [InlineAutoMoqData("5", 5)]
    [InlineAutoMoqData("14", 14)]
    [InlineAutoMoqData("444", 444)]
    public void ReturnNumberWhenPassedOneNumber(string number, int expected, StringCalculator sut)
    {
        // arrange

        // act
        int actual = sut.Add(number);

        // assert
        actual.Should().Be(expected);
    }
    
    [Theory]
    [InlineAutoMoqData("1,2", 3)]
    [InlineAutoMoqData("4,5", 9)]
    [InlineAutoMoqData("7,10", 17)]
    [InlineAutoMoqData("44,11", 55)]
    public void ReturnSumWhenPassedTwoNumbers(string numbers, int expected, StringCalculator sut)
    {
        // arrange

        // act
        int actual = sut.Add(numbers);

        // assert
        actual.Should().Be(expected);
    }
    
    [Theory]
    [InlineAutoMoqData("1,2,3,4,5", 15)]
    [InlineAutoMoqData("1,2,3,4,5,6,7,8,9", 45)]
    public void ReturnSumWhenPassedAnyNumberSize(string numbers, int expected, StringCalculator sut)
    {
        // arrange

        // act
        int actual = sut.Add(numbers);

        // assert
        actual.Should().Be(expected);
    }
    
    [Theory]
    [InlineAutoMoqData("1\n2,3", 6)]
    [InlineAutoMoqData("1\n2\n3", 6)]
    [InlineAutoMoqData("1,2\n3,4\n5", 15)]
    public void ReturnSumWhenNewLineIsUsedAsSeparator(string numbers, int expected, StringCalculator sut)
    {
        // arrange

        // act
        int actual = sut.Add(numbers);

        // assert
        actual.Should().Be(expected);
    }
    
    [Theory]
    [InlineAutoMoqData("//;\n1;2", 3)]
    [InlineAutoMoqData("//;\n1;2,3,4\n5", 15)]
    public void SupportACustomSeparator(string numbers, int expected, StringCalculator sut)
    {
        // arrange

        // act
        int actual = sut.Add(numbers);

        // assert
        actual.Should().Be(expected);
    }
    
    [Theory]
    [InlineAutoMoqData("1,-2,-3")]
    public void ThrowWhenGivenNegativeNumbers(string numbers, StringCalculator sut)
    {
        // arrange

        // act
        Action act = () => sut.Add(numbers);

        // assert
        act.Should().ThrowExactly<ArgumentException>()
            .WithMessage("negatives are not allowed: -2 -3");
    }
    
    [Theory]
    [InlineAutoMoqData("1001,2", 2)]
    public void IgnoreNumbersGreaterThan1000(string numbers, int expected, StringCalculator sut)
    {
        // arrange

        // act
        int actual = sut.Add(numbers);

        // assert
        actual.Should().Be(expected);
    }
}