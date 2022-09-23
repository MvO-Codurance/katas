using HotelBooking.Abstractions;
using HotelBooking.Models;

namespace HotelBooking.Services.BookingValidators;

public class BookingPolicyValidator : IBookingValidator
{
    private readonly IBookingPolicyService _bookingPolicyService;

    public BookingPolicyValidator(IBookingPolicyService bookingPolicyService)
    {
        _bookingPolicyService = bookingPolicyService ?? throw new ArgumentNullException(nameof(bookingPolicyService));
    }
    
    public BookingValidationResult Validate(Booking booking)
    {
        var result = new BookingValidationResult();

        var bookingAllowed = _bookingPolicyService.IsBookingAllowed(booking.EmployeeId, booking.RoomType);
        if (!bookingAllowed)
        {
            result.Errors.Add($"Booking policy of hotel with id {booking.HotelId} does not allow employee with id {booking.EmployeeId} to book a room of type {booking.RoomType}.");
        }
        
        return result;
    }
}