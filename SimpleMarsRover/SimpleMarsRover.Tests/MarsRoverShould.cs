using FluentAssertions;
using Xunit;

namespace SimpleMarsRover.Tests;

public class MarsRoverShould
{
    [Fact]
    public void HaveInitialPositionOf_00N()
    {
        new MarsRover().Position.ToString().Should().Be("0:0:N");
    }
    
    [Fact]
    public void Output_23N_WhenGivenInput_MMRMMLM()
    {
        new MarsRover().Execute("MMRMMLM").Should().Be("2:3:N");
    }
    
    [Fact]
    public void Output_00N_WhenGivenInput_MMMMMMMMMM()
    {
        new MarsRover().Execute("MMMMMMMMMM").Should().Be("0:0:N");
    }
    
    [Fact]
    public void Output_21N_WhenGivenInput_RMMLM()
    {
        new MarsRover().Execute("RMMLM").Should().Be("2:1:N");
    }
}