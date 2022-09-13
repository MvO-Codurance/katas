using FluentAssertions;
using Xunit;

namespace Elevator.Tests;

public class Elevator1Should
{
    [Fact]
    public void Open_Doors_In_Order_3_B_G_B_2_B_1_3()
    {
        var sut = new Elevator1();

        sut.Call(Floor.Three, Floor.Basement);
        sut.Call(Floor.Ground, Floor.Basement);
        sut.Call(Floor.Two, Floor.Basement);
        sut.Call(Floor.One, Floor.Three).Should().Be("3BGB2B13");
    }
}