using HotelBooking.Models;

namespace HotelBooking.Abstractions;

public interface IHotelService
{
    void AddHotel(Guid hotelId, string hotelName);
    
    void SetRoom(Guid hotelId, string number, RoomType roomType);
            
    Hotel FindHotelBy(Guid hotelId); 
}