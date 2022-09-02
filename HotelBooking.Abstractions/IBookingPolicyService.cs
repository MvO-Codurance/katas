using HotelBooking.Models;

namespace HotelBooking.Abstractions;

public interface IBookingPolicyService
{
    void SetCompanyPolicy(Guid companyId, List<RoomType> roomTypes);
        
    void SetEmployeePolicy(Guid employeeId, List<RoomType> roomTypes);
        
    bool IsBookingAllowed(Guid employeeId, RoomType roomType);
}