using FluentAssertions;
using Xunit;

namespace MarsRover.Tests;

public class GridShould
{
    [Theory]
    [InlineData(0, 0, CompassHeading.N, 0, 1)]
    [InlineData(0, 1, CompassHeading.N, 0, 2)]
    [InlineData(0, 9, CompassHeading.N, 0, 0)]
    [InlineData(0, 0, CompassHeading.S, 0, 9)]
    [InlineData(0, 2, CompassHeading.S, 0, 1)]
    [InlineData(0, 9, CompassHeading.S, 0, 8)]
    [InlineData(0, 0, CompassHeading.E, 1, 0)]
    [InlineData(1, 0, CompassHeading.E, 2, 0)]
    [InlineData(9, 0, CompassHeading.E, 0,0)]
    [InlineData(0, 0, CompassHeading.W, 9,0)]
    [InlineData(2, 0, CompassHeading.W, 1,0)]
    [InlineData(9, 0, CompassHeading.W, 8,0)]
    public void Move_To_Correct_Coordinate(
        int initialX, 
        int initialY, 
        CompassHeading heading, 
        int expectedX,
        int expectedY)
    {
        new Grid().Move(new Coordinate(initialX, initialY), heading).Should().Be(new Coordinate(expectedX, expectedY));
    }
    
    [Fact]
    public void Stay_In_Current_Position_When_Hits_An_Obstacle()
    {
        var obstacles = new List<Coordinate>
        {
            new Coordinate(0, 1)
        };
        var grid = new Grid(obstacles);
        
        grid.Move(new Coordinate(0, 0), CompassHeading.N).Should().Be(new Coordinate(0, 0));
    }
}