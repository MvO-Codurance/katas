using HotelBooking.Models;

namespace HotelBooking.Abstractions;

public interface IBookingValidator
{
    BookingValidationResult Validate(Booking booking);
}