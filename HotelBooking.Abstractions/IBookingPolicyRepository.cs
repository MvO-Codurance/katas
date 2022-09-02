using HotelBooking.Models;

namespace HotelBooking.Abstractions;

public interface IBookingPolicyRepository
{
    void UpsertCompanyPolicy(Guid companyId, List<RoomType> roomTypes);
        
    void UpsertEmployeePolicy(Guid employeeId, List<RoomType> roomTypes);

    List<RoomType>? GetCompanyPolicy(Guid companyId);
    
    List<RoomType>? GetEmployeePolicy(Guid employeeId);
}