using AutoFixture.Xunit2;
using FluentAssertions;
using HotelBooking.Abstractions;
using HotelBooking.Models;
using HotelBooking.Services;
using NSubstitute;
using Xunit;

namespace HotelBooking.Tests;

public class BookingServiceShould
{
    [Theory]
    [InlineAutoNSubstituteData]
    public void Accept_A_Valid_Booking( 
        Guid employeeId, 
        Guid hotelId, 
        RoomType roomType, 
        DateOnly checkIn, 
        DateOnly checkOut,
        [Frozen] IBookingValidator bookingValidator,
        [Frozen] IBookingRepository bookingRepository,
        BookingService sut)
    {
        // arrange
        bookingValidator.Validate(Arg.Any<Booking>()).Returns(new BookingValidationResult());
        
        // act
        var actual = sut.Book(employeeId, hotelId, roomType, checkIn, checkOut);
        
        // assert
        actual.Id.Should().NotBeEmpty();
        actual.EmployeeId.Should().Be(employeeId);
        actual.HotelId.Should().Be(hotelId);
        actual.RoomType.Should().Be(roomType);
        actual.CheckInDate.Should().Be(checkIn);
        actual.CheckOutDate.Should().Be(checkOut);
        
        bookingValidator.Received(1).Validate(Arg.Any<Booking>());
        bookingRepository.Received(1).AddBooking(Arg.Any<Booking>());
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Throw_For_An_Invalid_Booking(
        Guid employeeId, 
        Guid hotelId, 
        RoomType roomType, 
        DateOnly checkIn, 
        DateOnly checkOut,
        [Frozen] IBookingValidator bookingValidator,
        [Frozen] IBookingRepository bookingRepository,
        BookingService sut)
    {
        // arrange
        var validationResult = new BookingValidationResult();
        validationResult.Errors.Add("An error");
        bookingValidator.Validate(Arg.Any<Booking>()).Returns(validationResult);
        
        // act
        Action act = () => sut.Book(employeeId, hotelId, roomType, checkIn, checkOut);

        // assert
        act.Should().ThrowExactly<InvalidBookingException>();

        bookingValidator.Received(1).Validate(Arg.Any<Booking>());
        bookingRepository.DidNotReceive().AddBooking(Arg.Any<Booking>());
    }
}