using FluentAssertions;
using Xunit;

namespace MultiplesOf3Or5.Tests;

public class MultiplesOf3Or5FinderShould
{
    [Fact]
    public void Calculate_The_SimpleSum_Of_Multiples_Of_3_Or_5_Below_10_To_Be_23()
    {
        new MultiplesOf3Or5Finder().SimpleSum(10).Should().Be(23);
    }
    
    [Theory]
    [InlineAutoNSubstituteData(10, 23)]
    [InlineAutoNSubstituteData(20, 78)]
    [InlineAutoNSubstituteData(1000, 233168)]
    public void Correctly_Calculate_The_SimpleSum_Of_Multiples_Of_3_Or_5_Below_The_Limit(int limit, int expectedSum)
    {
        new MultiplesOf3Or5Finder().SimpleSum(limit).Should().Be(expectedSum);
    }
    
    [Fact]
    public void Calculate_The_AlgorithmicSum_Of_Multiples_Of_3_Or_5_Below_10_To_Be_23()
    {
        new MultiplesOf3Or5Finder().AlgorithmicSum(10).Should().Be(23);
    }
    
    [Theory]
    [InlineAutoNSubstituteData(10, 23)]
    [InlineAutoNSubstituteData(20, 78)]
    [InlineAutoNSubstituteData(1000, 233168)]
    public void Correctly_Calculate_The_AlgorithmicSum_Of_Multiples_Of_3_Or_5_Below_The_Limit(int limit, int expectedSum)
    {
        new MultiplesOf3Or5Finder().AlgorithmicSum(limit).Should().Be(expectedSum);
    }
}