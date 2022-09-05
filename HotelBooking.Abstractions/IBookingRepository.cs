using HotelBooking.Models;

namespace HotelBooking.Abstractions;

public interface IBookingRepository
{
    void AddBooking(Booking booking);
}