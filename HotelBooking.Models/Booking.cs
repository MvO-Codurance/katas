namespace HotelBooking.Models;

public class Booking
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid HotelId { get; set; }
    public RoomType RoomType { get; set; }
    public DateOnly CheckInDate { get; set; }
    public DateOnly CheckOutDate { get; set; }
}