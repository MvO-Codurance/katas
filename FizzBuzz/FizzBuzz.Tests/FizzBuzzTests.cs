using FluentAssertions;
using Xunit;

namespace FizzBuzz.Tests;

public class FizzBuzzTests
{
    [Theory]
    [InlineAutoMoqData(1, "1")]
    [InlineAutoMoqData(2, "2")]
    [InlineAutoMoqData(4, "4")]
    public void Convert_Number_To_String(
        int number,
        string expectedOutput,
        FizzBuzz sut)
    {
        // arrange
        
        // act
        var actual = sut.Convert(number);

        // assert
        actual.Should().Be(expectedOutput);
    }

    [Theory]
    [InlineAutoMoqData(3)]
    [InlineAutoMoqData(6)]
    [InlineAutoMoqData(9)]
    [InlineAutoMoqData(12)]
    public void Convert_MultiplesOf3_To_Fizz(int number, FizzBuzz sut)
    {
        // arrange
        
        // act
        var actual = sut.Convert(number);

        // assert
        actual.Should().Be("Fizz");
    }
    
    [Theory]
    [InlineAutoMoqData(5)]
    [InlineAutoMoqData(10)]
    [InlineAutoMoqData(20)]
    public void Convert_MultiplesOf5_To_Buzz(int number, FizzBuzz sut)
    {
        // arrange
        
        // act
        var actual = sut.Convert(number);

        // assert
        actual.Should().Be("Buzz");
    }
    
    [Theory]
    [InlineAutoMoqData(15)]
    [InlineAutoMoqData(30)]
    [InlineAutoMoqData(45)]
    public void Convert_MultiplesOf3And5_To_FizzBuzz(int number, FizzBuzz sut)
    {
        // arrange
        
        // act
        var actual = sut.Convert(number);

        // assert
        actual.Should().Be("FizzBuzz");
    }
}