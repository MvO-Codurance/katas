using FluentAssertions;
using Xunit;

namespace MarsRover.Tests;

public class MarsRoverShould
{
    [Fact]
    public void Given_Grid_With_No_Obstacles_With_Input_MMRMMLM_Give_Output_2_3_N()
    {
        new Rover().Execute("MMRMMLM").Should().Be("2:3:N");
    }
    
    [Fact]
    public void Given_Grid_With_No_Obstacles_With_Input_MMMMMMMMMM_Give_Output_0_0_N()
    {
        new Rover().Execute("MMMMMMMMMM").Should().Be("0:0:N");
    }
    
    // TODO
    // [Fact]
    public void Given_Grid_With_Obstacles_With_Input_MMMM_Give_Output_O_0_2_N()
    {
        new Rover().Execute("MMMM").Should().Be("O:0:2:N");
    }

    [Fact]
    public void Be_At_Position_0_0_N_When_Not_Given_Initial_Position()
    {
        new Rover().ToString().Should().Be("0:0:N");
    }
    
    [Fact]
    public void Be_At_Correct_Position_When_Given_Initial_Position()
    {
        new Rover(2, 3, Direction.S).ToString().Should().Be("2:3:S");
    }
    
    [Fact]
    public void Turn_To_Correct_Direction()
    {
        var rover = new Rover();

        rover.Execute("L").Should().Be("0:0:W");
        rover.Execute("L").Should().Be("0:0:S");
        rover.Execute("L").Should().Be("0:0:E");
        rover.Execute("L").Should().Be("0:0:N");
        
        rover.Execute("R").Should().Be("0:0:E");
        rover.Execute("R").Should().Be("0:0:S");
        rover.Execute("R").Should().Be("0:0:W");
        rover.Execute("R").Should().Be("0:0:N");
    }
    
    [Theory]
    [InlineData(0, 0, Direction.N, "0:1:N")]
    [InlineData(0, 1, Direction.N, "0:2:N")]
    [InlineData(0, 9, Direction.N, "0:0:N")]
    [InlineData(0, 0, Direction.S, "0:9:S")]
    [InlineData(0, 2, Direction.S, "0:1:S")]
    [InlineData(0, 9, Direction.S, "0:8:S")]
    [InlineData(0, 0, Direction.E, "1:0:E")]
    [InlineData(1, 0, Direction.E, "2:0:E")]
    [InlineData(9, 0, Direction.E, "0:0:E")]
    [InlineData(0, 0, Direction.W, "9:0:W")]
    [InlineData(2, 0, Direction.W, "1:0:W")]
    [InlineData(9, 0, Direction.W, "8:0:W")]
    public void Move_To_Correct_Position(int initialX, int initialY, Direction initialDirection, string expectedPosition)
    {
        var rover = new Rover(initialX, initialY, initialDirection);
        rover.Execute("M").Should().Be(expectedPosition);
    }
    
    [Fact]
    public void Throws_When_Given_Unrecognised_Command()
    {
        var act = () => new Rover().Execute("X");

        act.Should().ThrowExactly<ArgumentException>()
            .WithMessage("Command 'X' is not recognised.");
    }
}