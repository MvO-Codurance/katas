using FluentAssertions;
using Xunit;

namespace SimpleMarsRover.Tests;

public class PositionShould
{
    [Fact]
    public void HaveInitialPositionOf_00N()
    {
        new Position().ToString().Should().Be("0:0:N");
    }
    
    [Theory]
    [InlineAutoMoqData('N', 'L', 'W')]
    [InlineAutoMoqData('W', 'L', 'S')]
    [InlineAutoMoqData('S', 'L', 'E')]
    [InlineAutoMoqData('E', 'L', 'N')]
    [InlineAutoMoqData('N', 'R', 'E')]
    [InlineAutoMoqData('E', 'R', 'S')]
    [InlineAutoMoqData('S', 'R', 'W')]
    [InlineAutoMoqData('W', 'R', 'N')]
    public void FaceCorrectDirectionWhenRotated(char initialDirection, char command, char expectedDirection)
    {
        var sut = new Position(0, 0, initialDirection);
        sut.Execute(command);
        sut.Direction.Should().Be(expectedDirection);
    }
    
    [Theory]
    [InlineAutoMoqData(0, 1)]
    [InlineAutoMoqData(1, 2)]
    [InlineAutoMoqData(2, 3)]
    [InlineAutoMoqData(9, 0)]
    public void MoveYPositionWhenFacingNorth(int initialY, int expectedY)
    {
        var sut = new Position(0, initialY, 'N');
        sut.Execute('M');
        sut.Y.Should().Be(expectedY);
    }
    
    [Theory]
    [InlineAutoMoqData(9, 8)]
    [InlineAutoMoqData(8, 7)]
    [InlineAutoMoqData(7, 6)]
    [InlineAutoMoqData(0, 9)]
    public void MoveYPositionWhenFacingSouth(int initialY, int expectedY)
    {
        var sut = new Position(0, initialY, 'S');
        sut.Execute('M');
        sut.Y.Should().Be(expectedY);
    }
    
    [Theory]
    [InlineAutoMoqData(0, 1)]
    [InlineAutoMoqData(1, 2)]
    [InlineAutoMoqData(2, 3)]
    [InlineAutoMoqData(9, 0)]
    public void MoveXPositionWhenFacingEast(int initialX, int expectedX)
    {
        var sut = new Position(initialX, 0, 'E');
        sut.Execute('M');
        sut.X.Should().Be(expectedX);
    }
    
    [Theory]
    [InlineAutoMoqData(9, 8)]
    [InlineAutoMoqData(8, 7)]
    [InlineAutoMoqData(7, 6)]
    [InlineAutoMoqData(0, 9)]
    public void MoveXPositionWhenFacingWest(int initialX, int expectedX)
    {
        var sut = new Position(initialX, 0, 'W');
        sut.Execute('M');
        sut.X.Should().Be(expectedX);
    }
}