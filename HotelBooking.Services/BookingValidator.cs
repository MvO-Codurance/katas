using HotelBooking.Abstractions;
using HotelBooking.Models;

namespace HotelBooking.Services;

public class BookingValidator : IBookingValidator
{
    private readonly IHotelService _hotelService;

    public BookingValidator(IHotelService hotelService)
    {
        _hotelService = hotelService ?? throw new ArgumentNullException(nameof(hotelService));
    }
    
    public BookingValidationResult Validate(Booking booking)
    {
        var result = new BookingValidationResult();
        
        // checkout is later than checkin?
        if (booking.CheckOutDate.DayNumber - booking.CheckInDate.DayNumber < 1)
        {
            result.Errors.Add("Check out date must be later than check in date.");
        }
        
        // hotel exists and provides requested room type?
        var hotel = _hotelService.FindHotelBy(booking.HotelId);
        if (hotel == null)
        {
            result.Errors.Add($"Hotel with id {booking.HotelId} does not exist.");
        }
        
        // TODO

        return result;
    }
}