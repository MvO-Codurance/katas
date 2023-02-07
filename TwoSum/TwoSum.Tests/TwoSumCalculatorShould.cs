using System.Security.Cryptography;
using FluentAssertions;
using Xunit;

namespace TwoSum.Tests;

public class TwoSumCalculatorShould
{
    [Theory]
    [InlineData(new [] { 2,7,11,15 }, 9, new [] { 0,1 })]
    [InlineData(new [] { 3,2,4 }, 6, new [] { 1,2 })]
    [InlineData(new [] { 3,3 }, 6, new [] { 0,1 })]
    [InlineData(new [] { -30,14,55,61,10,-5 }, 9, new [] { 1,5 })]
    [InlineData(new [] { -1_000_000_000, 1_000_000_000, 999, 888, 777, -666, 123456 }, 999_999_334, new [] { 1,5 })]
    public void Find_The_Two_Indices_Of_The_Input_That_Sum_Together_To_Equal_The_Target(
        int[] input,
        int target,
        int[] expectedOutput)
    {
        new TwoSumCalculator().Calculate(input, target).Should()
            .HaveCount(expectedOutput.Length)
            .And.ContainInOrder(expectedOutput);
    }
    
    [Theory]
    [InlineData(new [] { 2,7,11,15 }, 9, new [] { 0,1 })]
    [InlineData(new [] { 3,2,4 }, 6, new [] { 1,2 })]
    [InlineData(new [] { 3,3 }, 6, new [] { 0,1 })]
    [InlineData(new [] { -30,14,55,61,10,-5 }, 9, new [] { 1,5 })]
    [InlineData(new [] { -1_000_000_000, 1_000_000_000, 999, 888, 777, -666, 123456 }, 999_999_334, new [] { 1,5 })]
    public void Find_The_Two_Indices_Of_The_Input_That_Sum_Together_To_Equal_The_Target_Faster_Than_Quadratic_Time_Complexity(
        int[] input,
        int target,
        int[] expectedOutput)
    {
        new TwoSumCalculator().CalculateFaster(input, target).Should()
            .HaveCount(expectedOutput.Length)
            .And.ContainInOrder(expectedOutput);
    }
}