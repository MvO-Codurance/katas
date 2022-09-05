using AutoFixture.Xunit2;
using FluentAssertions;
using HotelBooking.Abstractions;
using HotelBooking.Models;
using HotelBooking.Services;
using HotelBooking.Services.BookingValidators;
using NSubstitute;
using Xunit;

namespace HotelBooking.Tests;

public class BookingValidatorsShould
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
        CheckInCheckOutValidator sut)
    {
        // arrange
        booking.CheckInDate = DateOnly.Parse(checkInDate);
        booking.CheckOutDate = DateOnly.Parse(checkOutDate);

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
    public void Validate_Hotel_When_It_Exists_And_Provides_RoomType(
        Booking booking,
        Hotel hotel,
        string roomNumber,
        [Frozen] IHotelService hotelService,
        HotelValidator sut)
    {
        // arrange
        booking.HotelId = hotel.Id;
        hotel.Rooms.Add(roomNumber, new Room { Number = roomNumber, Type = booking.RoomType });
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
        HotelValidator sut)
    {
        // arrange
        hotelService.FindHotelBy(Arg.Any<Guid>()).Returns(null as Hotel);
        
        // act
        var actual = sut.Validate(booking);

        // assert
        actual.Should().NotBeNull();
        actual.Valid.Should().BeFalse();
        actual.Errors.Should().BeEquivalentTo(new List<string> { $"Hotel with id {booking.HotelId} does not exist." });
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Validate_Hotel_When_RoomType_Is_Not_Provided(
        Booking booking,
        Hotel hotel,
        [Frozen] IHotelService hotelService,
        HotelValidator sut)
    {
        // arrange
        booking.HotelId = hotel.Id;
        hotelService.FindHotelBy(hotel.Id).Returns(hotel);
        
        // act
        var actual = sut.Validate(booking);

        // assert
        actual.Should().NotBeNull();
        actual.Valid.Should().BeFalse();
        actual.Errors.Should().BeEquivalentTo(new List<string> { $"Hotel with id {booking.HotelId} does not provide rooms of type {booking.RoomType}." });

        hotelService.Received(1).FindHotelBy(booking.HotelId);
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Validate_Booking_Policy_When_Allowed(
        Booking booking,
        Hotel hotel,
        [Frozen] IBookingPolicyService bookingPolicyService,
        BookingPolicyValidator sut)
    {
        // arrange
        booking.HotelId = hotel.Id;
        bookingPolicyService.IsBookingAllowed(booking.EmployeeId, booking.RoomType).Returns(true);
        
        // act
        var actual = sut.Validate(booking);

        // assert
        actual.Should().NotBeNull();
        actual.Valid.Should().BeTrue();
        actual.Errors.Should().HaveCount(0);
        
        bookingPolicyService.Received(1).IsBookingAllowed(booking.EmployeeId, booking.RoomType);
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Validate_Booking_Policy_When_Not_Allowed(
        Booking booking,
        Hotel hotel,
        [Frozen] IBookingPolicyService bookingPolicyService,
        BookingPolicyValidator sut)
    {
        // arrange
        booking.HotelId = hotel.Id;
        bookingPolicyService.IsBookingAllowed(booking.EmployeeId, booking.RoomType).Returns(false);
        
        // act
        var actual = sut.Validate(booking);

        // assert
        actual.Should().NotBeNull();
        actual.Valid.Should().BeFalse();
        actual.Errors.Should().BeEquivalentTo(new List<string> { $"Booking policy of hotel with id {booking.HotelId} does not allow employee with id {booking.EmployeeId} to book a room of type {booking.RoomType}." });
        
        bookingPolicyService.Received(1).IsBookingAllowed(booking.EmployeeId, booking.RoomType);
    }
}