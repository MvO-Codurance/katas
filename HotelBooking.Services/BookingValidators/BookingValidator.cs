using HotelBooking.Abstractions;
using HotelBooking.Models;

namespace HotelBooking.Services.BookingValidators;

public class BookingValidator : IBookingValidator
{
    private readonly List<IBookingValidator> _validators;
    
    public BookingValidator(
        CheckInCheckOutValidator checkInCheckOutValidator,
        HotelValidator hotelValidator,
        BookingPolicyValidator bookingPolicyValidator)
    {
        // pull this list from configuration?
        // or caller provides it?
        _validators = new List<IBookingValidator>
        {
            checkInCheckOutValidator,
            hotelValidator,
            bookingPolicyValidator
        };
    }
    
    public BookingValidationResult Validate(Booking booking)
    {
        var overallResult = new BookingValidationResult();

        foreach (var validator in _validators)
        {
            var newResult = validator.Validate(booking);
            overallResult.Errors.AddRange(newResult.Errors);
        }

        return overallResult;
    }
}