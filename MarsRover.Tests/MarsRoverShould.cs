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
    
    [Fact]
    public void Given_Grid_With_Obstacles_With_Input_MMMM_Give_Output_O_0_2_N()
    {
        var obstacles = new List<Coordinate>
        {
            new Coordinate(0, 3)
        };
        var grid = new Grid(obstacles);
        new Rover(grid).Execute("MMMM").Should().Be("O:0:2:N");
    }

    [Fact]
    public void Be_At_Position_0_0_N_When_Not_Given_Initial_Position()
    {
        new Rover().ToString().Should().Be("0:0:N");
    }
    
    [Fact]
    public void Be_At_Correct_Position_When_Given_Initial_Position()
    {
        new Rover(2, 3, CompassHeading.S).ToString().Should().Be("2:3:S");
    }
    
    [Fact]
    public void Throws_When_Given_Unrecognised_Command()
    {
        var act = () => new Rover().Execute("X");

        act.Should().ThrowExactly<ArgumentException>()
            .WithMessage("Command 'X' is not recognised.");
    }
}