using AutoFixture.Xunit2;
using FluentAssertions;
using HotelBooking.Abstractions;
using HotelBooking.Models;
using HotelBooking.Services;
using NSubstitute;
using Xunit;

namespace HotelBooking.Tests;

public class BookingValidatorShould
{
    [Theory]
    [InlineAutoNSubstituteData("2022-09-02", "2022-09-01", false)]
    [InlineAutoNSubstituteData("2022-09-02", "2022-09-02", false)]
    [InlineAutoNSubstituteData("2022-09-02", "2022-09-03", true)]
    public void Validate_CheckInDate_And_CheckOutDate(
        string checkInDate,
        string checkOutDate,
        bool expectedResult,
        Booking booking,
        Hotel hotel,
        [Frozen] IHotelService hotelService,
        BookingValidator sut)
    {
        // arrange
        booking.CheckInDate = DateOnly.Parse(checkInDate);
        booking.CheckOutDate = DateOnly.Parse(checkOutDate);
        booking.HotelId = hotel.Id;
        hotelService.FindHotelBy(hotel.Id).Returns(hotel);

        // act
        var actual = sut.Validate(booking);

        // assert
        actual.Should().NotBeNull();
        actual.Valid.Should().Be(expectedResult);

        if (expectedResult)
        {
            actual.Errors.Should().HaveCount(0);
        }
        else
        {
            actual.Errors.Should().BeEquivalentTo(new List<string> { "Check out date must be later than check in date." });
        }        
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Validate_Hotel_Whe_It_Does_Exist(
        Booking booking,
        Hotel hotel,
        [Frozen] IHotelService hotelService,
        BookingValidator sut)
    {
        // arrange
        booking.CheckInDate = DateOnly.FromDayNumber(0);
        booking.CheckOutDate = DateOnly.FromDayNumber(1);
        booking.HotelId = hotel.Id;
        hotelService.FindHotelBy(hotel.Id).Returns(hotel);
        
        // act
        var actual = sut.Validate(booking);

        // assert
        actual.Should().NotBeNull();
        actual.Valid.Should().BeTrue();
        actual.Errors.Should().HaveCount(0);     
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Validate_Hotel_When_It_Does_Not_Exist(
        Booking booking,
        [Frozen] IHotelService hotelService,
        BookingValidator sut)
    {
        // arrange
        booking.CheckInDate = DateOnly.FromDayNumber(0);
        booking.CheckOutDate = DateOnly.FromDayNumber(1);

        hotelService.FindHotelBy(Arg.Any<Guid>()).Returns(null as Hotel);
        
        // act
        var actual = sut.Validate(booking);

        // assert
        actual.Should().NotBeNull();
        actual.Valid.Should().BeFalse();
        actual.Errors.Should().BeEquivalentTo(new List<string> { $"Hotel with id {booking.HotelId} does not exist." });
       
    }
}