namespace HotelBooking.Models;

public class Hotel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Dictionary<string, Room> Rooms { get; } = new Dictionary<string, Room>(StringComparer.OrdinalIgnoreCase);
}