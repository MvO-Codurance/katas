using HotelBooking.Abstractions;
using HotelBooking.Models;

namespace HotelBooking.Services;

public class BookingService : IBookingService
{
    private readonly IBookingValidator _bookingValidator;
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingValidator bookingValidator, IBookingRepository bookingRepository)
    {
        _bookingValidator = bookingValidator ?? throw new ArgumentNullException(nameof(bookingValidator));
        _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
    }
    
    public Booking Book(Guid employeeId, Guid hotelId, RoomType roomType, DateOnly checkIn, DateOnly checkOut)
    {
        Booking booking = new Booking
        {
            Id = Guid.NewGuid(),
            EmployeeId = employeeId,
            HotelId = hotelId,
            RoomType = roomType,
            CheckInDate = checkIn,
            CheckOutDate = checkOut
        };
        
        var validationResult = _bookingValidator.Validate(booking);
        if (!validationResult.Valid)
        {
            throw new InvalidBookingException(validationResult);
        }
        
        _bookingRepository.AddBooking(booking);

        return booking;
    }
}