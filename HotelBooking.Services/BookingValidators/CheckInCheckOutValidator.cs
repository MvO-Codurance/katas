using HotelBooking.Abstractions;
using HotelBooking.Models;

namespace HotelBooking.Services.BookingValidators;

public class CheckInCheckOutValidator : IBookingValidator
{
    public BookingValidationResult Validate(Booking booking)
    {
        var result = new BookingValidationResult();
        
        // checkout is later than checkin?
        if (booking.CheckOutDate.DayNumber - booking.CheckInDate.DayNumber < 1)
        {
            result.Errors.Add("Check out date must be later than check in date.");
        }
        
        return result;
    }
}