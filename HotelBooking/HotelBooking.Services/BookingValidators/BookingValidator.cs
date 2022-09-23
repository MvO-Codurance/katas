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
        // TODO add validators for:
        // Booking should only be allowed if there is at least one room type available during the whole booking period.
        // Keep track of all bookings. E.g. If hotel has 5 standard rooms, we should have no more than 5 bookings in the same day.
        // Hotel rooms can be booked many times as long as there are no conflicts with the dates.
        
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