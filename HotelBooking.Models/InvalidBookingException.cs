namespace HotelBooking.Models;

public class InvalidBookingException : Exception
{
    public InvalidBookingException(BookingValidationResult validationResult)
        :base(string.Join(Environment.NewLine, validationResult.Errors))
    {
    }
}