using HotelBooking.Models;

namespace HotelBooking.Abstractions;

public interface IBookingService
{
    Booking Book(Guid employeeId, Guid hotelId, RoomType roomType, DateOnly checkIn, DateOnly checkOut);
}