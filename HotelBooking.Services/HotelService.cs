using HotelBooking.Abstractions;
using HotelBooking.Models;

namespace HotelBooking.Services;

public class HotelService : IHotelService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
    }
    
    public void AddHotel(Guid hotelId, string hotelName)
    {
        var hotel = FindHotelBy(hotelId);
        if (hotel != null)
        {
            throw new ArgumentException($"Hotel with id {hotelId} already exists.");    
        }
        
        _hotelRepository.AddHotel(new Hotel
        {
            Id = hotelId,
            Name = hotelName
        });
    }

    public void SetRoom(Guid hotelId, string number, RoomType roomType)
    {
        var hotel = FindHotelBy(hotelId);
        if (hotel == null)
        {
            throw new ArgumentException($"Hotel with id {hotelId} does not exist.");    
        }
        
        _hotelRepository.UpsertRoom(hotelId, number, roomType);
    }

    public Hotel? FindHotelBy(Guid hotelId)
    {
        return _hotelRepository.FindHotelBy(hotelId);
    }
}