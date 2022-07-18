using FluentAssertions;
using Xunit;

namespace Bowling.Tests;

public class BowlingScorerShould
{
    [Theory]
    [InlineAutoMoqData("X||", 10)]
    [InlineAutoMoqData("5/||", 10)]
    [InlineAutoMoqData("5-||", 5)]
    [InlineAutoMoqData("-5||", 5)]
    [InlineAutoMoqData("X|12||", 16)]
    [InlineAutoMoqData("5/|12||", 14)]
    [InlineAutoMoqData("X|X|X|X|X|X|X|X|X|X||XX", 300)]
    [InlineAutoMoqData("9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||", 90)]
    [InlineAutoMoqData("5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5", 150)]
    [InlineAutoMoqData("X|7/|9-|X|-8|8/|-6|X|X|X||81", 167)]
    public void CalculateAGameScore(string input, int expectedScore)
    {
        new BowlingScorer().Calculate(input).Should().Be(expectedScore);
    }
}