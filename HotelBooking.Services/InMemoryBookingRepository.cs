using HotelBooking.Abstractions;
using HotelBooking.Models;

namespace HotelBooking.Services;

public class InMemoryBookingRepository : IBookingRepository
{
    private readonly Dictionary<Guid, Booking> _bookings = new Dictionary<Guid, Booking>();
    
    public void AddBooking(Booking booking)
    {
        _bookings.Add(booking.Id, booking);
    }
}