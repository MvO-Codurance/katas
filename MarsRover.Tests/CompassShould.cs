using FluentAssertions;
using Xunit;

namespace MarsRover.Tests;

public class CompassShould
{
    [Theory]
    [InlineData(CompassHeading.N, CompassHeading.W)]
    [InlineData(CompassHeading.W, CompassHeading.S)]
    [InlineData(CompassHeading.S, CompassHeading.E)]
    [InlineData(CompassHeading.E, CompassHeading.N)]
    public void Turn_Left_To_Correct_Heading(CompassHeading initialHeading, CompassHeading expectedHeading)
    {
        new Compass(initialHeading).TurnLeft().Should().Be(expectedHeading);
    }
    
    [Theory]
    [InlineData(CompassHeading.N, CompassHeading.E)]
    [InlineData(CompassHeading.E, CompassHeading.S)]
    [InlineData(CompassHeading.S, CompassHeading.W)]
    [InlineData(CompassHeading.W, CompassHeading.N)]
    public void Turn_Right_To_Correct_Heading(CompassHeading initialHeading, CompassHeading expectedHeading)
    {
        new Compass(initialHeading).TurnRight().Should().Be(expectedHeading);
    }
}