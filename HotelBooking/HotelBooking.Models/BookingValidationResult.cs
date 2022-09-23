namespace HotelBooking.Models;

public class BookingValidationResult
{
    public bool Valid => !Errors.Any();
    public List<string> Errors { get; } = new List<string>();
}