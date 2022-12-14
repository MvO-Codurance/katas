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
    public void Add_A_Trip_With_The_Doors_Opening_On_The_Correct_Floors(
        Floor calledFromFloor,
        Floor destinationFloor,
        string expectedDoorsOpenOnFloor)
    {
        var sut = new Trips(Floor.Ground);

        sut.AddFrom(new Call(calledFromFloor, destinationFloor)).DoorsOpenedOnFloors.Should().Be(expectedDoorsOpenOnFloor);
    }
    
    [Fact]
    public void Record_All_Door_Openings_In_Order_3_B_G_B_2_B_1_3()
    {
        var sut = new Elevator1(Floor.Ground);

        sut.Call(Floor.Three, Floor.Basement);
        sut.Call(Floor.Ground, Floor.Basement);
        sut.Call(Floor.Two, Floor.Basement);
        sut.Call(Floor.One, Floor.Three);
        
        sut.Trips.DoorsOpenedOnFloors().Should().Be("3BGB2B13");
    }
    
    [Theory]
    [InlineAutoNSubstituteData(Floor.Ground, Floor.Three, Floor.Basement, 13)]
    [InlineAutoNSubstituteData(Floor.Basement, Floor.Ground, Floor.Basement, 8)]
    [InlineAutoNSubstituteData(Floor.Basement, Floor.Two, Floor.Basement, 12)]
    [InlineAutoNSubstituteData(Floor.Basement, Floor.One, Floor.Three, 10)]
    public void Calculate_The_Time_Taken_For_A_Trip(
        Floor startingFloor, 
        Floor calledFromFloor, 
        Floor destinationFloor,
        int expectedTimeTaken)
    {
        var sut = new Elevator1(startingFloor);
    
        sut.Call(calledFromFloor, destinationFloor);
            
        sut.Trips.TimeTaken().Should().Be(expectedTimeTaken);
    }
    
    [Fact]
    public void Calculate_Time_Taken_For_All_Trips_In_Order_G_3_B_G_B_2_B_1_3()
    {
        var sut = new Elevator1(Floor.Ground);

        sut.Call(Floor.Three, Floor.Basement);
        sut.Call(Floor.Ground, Floor.Basement);
        sut.Call(Floor.Two, Floor.Basement);
        sut.Call(Floor.One, Floor.Three);
        
        sut.Trips.TimeTaken().Should().Be(43);
    }
}