using HotelBooking.Abstractions;
using HotelBooking.Models;

namespace HotelBooking.Services;

public class InMemoryHotelRepository : IHotelRepository
{
    private readonly Dictionary<Guid, Hotel> _hotels = new Dictionary<Guid, Hotel>();

    public void AddHotel(Hotel hotel)
    {
        _hotels.Add(hotel.Id, hotel);
    }

    public Hotel? FindHotelBy(Guid hotelId)
    {
        if (_hotels.TryGetValue(hotelId, out var hotel))
        {
            return hotel;
        }

        return null;
    }

    public void UpsertRoom(Guid hotelId, string roomNumber, RoomType roomType)
    {
        if (_hotels.TryGetValue(hotelId, out var hotel))
        {
            if (hotel.Rooms.ContainsKey(roomNumber))
            {
                hotel.Rooms[roomNumber].Type = roomType;
            }
            else
            {
                hotel.Rooms.Add(roomNumber, new Room { Number = roomNumber, Type = roomType });
            }
        }
    }
}