using HotelBooking.Models;

namespace HotelBooking.Abstractions;

public interface IHotelRepository
{
    public void AddHotel(Hotel hotel);
    
    Hotel? FindHotelBy(Guid hotelId);

    void UpsertRoom(Guid hotelId, string roomNumber, RoomType roomType);
}