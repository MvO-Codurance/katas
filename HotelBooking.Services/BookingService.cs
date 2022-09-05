using HotelBooking.Abstractions;
using HotelBooking.Models;

namespace HotelBooking.Services;

public class BookingService : IBookingService
{
    private readonly IBookingValidator _bookingValidator;

    public BookingService(IBookingValidator bookingValidator)
    {
        _bookingValidator = bookingValidator ?? throw new ArgumentNullException(nameof(bookingValidator));
    }
    
    public Booking Book(Guid employeeId, Guid hotelId, RoomType roomType, DateOnly checkIn, DateOnly checkOut)
    {
        throw new NotImplementedException();
    }
}