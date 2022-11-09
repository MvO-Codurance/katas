using FluentAssertions;
using Xunit;

namespace Fibonacci.Tests;

public class FibonacciSequenceShould
{
    [Theory]
    [InlineAutoNSubstituteData(0, 0)]
    [InlineAutoNSubstituteData(1, 1)]
    [InlineAutoNSubstituteData(2, 1)]
    [InlineAutoNSubstituteData(3, 2)]
    [InlineAutoNSubstituteData(4, 3)]
    [InlineAutoNSubstituteData(5, 5)]
    [InlineAutoNSubstituteData(6, 8)]
    [InlineAutoNSubstituteData(7, 13)]
    [InlineAutoNSubstituteData(8, 21)]
    [InlineAutoNSubstituteData(9, 34)]
    [InlineAutoNSubstituteData(10, 55)]
    [InlineAutoNSubstituteData(15, 610)]
    public void Determine_The_Correct_Number_At_The_Given_Step(int step, int expectedNumber)
    {
        new FibonacciSequence().NumberAtStep(step).Should().Be(expectedNumber);
    }
}