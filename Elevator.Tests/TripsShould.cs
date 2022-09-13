using FluentAssertions;
using Xunit;

namespace Elevator.Tests;

public class TripsShould
{
    [Theory]
    [InlineAutoNSubstituteData(Floor.Three, Floor.Basement, "3B")]
    [InlineAutoNSubstituteData(Floor.Ground, Floor.Basement, "GB")]
    [InlineAutoNSubstituteData(Floor.Two, Floor.Basement, "2B")]
    [InlineAutoNSubstituteData(Floor.One, Floor.Three, "13")]
    public void Add_A_Trip_Where_The_Doors_Open_On_The_Correct_Floors(
        Floor calledFromFloor,
        Floor goToFloor,
        string expectedDoorsOpenOnFloor)
    {
        var sut = new Trips(Floor.Ground);

        sut.AddFrom(new Call(calledFromFloor, goToFloor)).DoorsOpenedOnFloors.Should().Be(expectedDoorsOpenOnFloor);
    }
}