using HotelBooking.Abstractions;
using HotelBooking.Models;

namespace HotelBooking.Services.BookingValidators;

public class HotelValidator : IBookingValidator
{
    private readonly IHotelService _hotelService;

    public HotelValidator(IHotelService hotelService)
    {
        _hotelService = hotelService ?? throw new ArgumentNullException(nameof(hotelService));
    }
    
    public BookingValidationResult Validate(Booking booking)
    {
        var result = new BookingValidationResult();
        
        var hotel = _hotelService.FindHotelBy(booking.HotelId);
        if (hotel == null)
        {
            result.Errors.Add($"Hotel with id {booking.HotelId} does not exist.");
        }
        else
        {
            if (hotel.Rooms.Values.Any(x => x.Type == booking.RoomType) == false)
            {
                result.Errors.Add($"Hotel with id {booking.HotelId} does not provide rooms of type {booking.RoomType}.");
            }
        }
        
        return result;
    }
}