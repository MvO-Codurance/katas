using FluentAssertions;
using Xunit;

namespace Bowling.Tests;

public class GameCardParserShould
{
    [Theory]
    [InlineAutoMoqData("X|X|X|X|X|X|X|X|X|X||XX", 10)]
    [InlineAutoMoqData("9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||", 10)]
    [InlineAutoMoqData("5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5", 10)]
    [InlineAutoMoqData("X|7/|9-|X|-8|8/|-6|X|X|X||81", 10)]
    [InlineAutoMoqData("X|7/|9-||", 3)]
    public void CountTheNumberOfFrames(string input, int expectedFrameCount)
    {
        new GameCardParser().Parse(input).FrameCount.Should().Be(expectedFrameCount);
    }
    
    [Theory]
    [InlineAutoMoqData("X|X|X|X|X|X|X|X|X|X||XX")]
    public void ParseTheFramesExample1(string input)
    {
        var frames = new GameCardParser().Parse(input).Frames;
        string[] actualFrames = frames.Select(f => f.ToString()).ToArray();
        string[] expectedFrames = { "X", "X", "X", "X", "X", "X", "X", "X", "X", "X" };
        actualFrames.Should().BeEquivalentTo(expectedFrames);
    }
    
    [Theory]
    [InlineAutoMoqData("9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||")]
    public void ParseTheFramesExample2(string input)
    {
        var frames = new GameCardParser().Parse(input).Frames;
        string[] actualFrames = frames.Select(f => f.ToString()).ToArray();
        string[] expectedFrames = new [] { "9-", "9-", "9-", "9-", "9-", "9-", "9-", "9-", "9-", "9-" };
        actualFrames.Should().BeEquivalentTo(expectedFrames);
    }
    
    [Theory]
    [InlineAutoMoqData("5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5")]
    public void ParseTheFramesExample3(string input)
    {
        var frames = new GameCardParser().Parse(input).Frames;
        string[] actualFrames = frames.Select(f => f.ToString()).ToArray();
        string[] expectedFrames = new [] { "5/", "5/", "5/", "5/", "5/", "5/", "5/", "5/", "5/", "5/" };
        actualFrames.Should().BeEquivalentTo(expectedFrames);
    }
    
    [Theory]
    [InlineAutoMoqData("X|7/|9-|X|-8|8/|-6|X|X|X||81")]
    public void ParseTheFramesExample4(string input)
    {
        var frames = new GameCardParser().Parse(input).Frames;
        string[] actualFrames = frames.Select(f => f.ToString()).ToArray();
        string[] expectedFrames = new [] { "X", "7/", "9-", "X", "-8", "8/", "-6", "X", "X", "X" };
        actualFrames.Should().BeEquivalentTo(expectedFrames);
    }
    
    [Theory]
    [InlineAutoMoqData("X|X|X|X|X|X|X|X|X|X||XX", "X", "X")]
    [InlineAutoMoqData("9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||", null, null)]
    [InlineAutoMoqData("5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5", "5", null)]
    [InlineAutoMoqData("X|7/|9-|X|-8|8/|-6|X|X|X||81", "8", "1")]
    [InlineAutoMoqData("X|7/|9-||", null, null)]
    public void ParseTheBonusBalls(string input, string expectedBonusBall1, string expectedBonusBall2)
    {
        new GameCardParser().Parse(input).BonusBall1.Code?.ToString().Should().BeEquivalentTo(expectedBonusBall1);
        new GameCardParser().Parse(input).BonusBall2.Code?.ToString().Should().BeEquivalentTo(expectedBonusBall2);
    }
}