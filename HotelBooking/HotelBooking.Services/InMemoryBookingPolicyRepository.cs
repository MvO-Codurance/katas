using HotelBooking.Abstractions;
using HotelBooking.Models;

namespace HotelBooking.Services;

public class InMemoryBookingPolicyRepository : IBookingPolicyRepository
{
    private readonly Dictionary<Guid, List<RoomType>> _employeePolicies = new Dictionary<Guid, List<RoomType>>();
    private readonly Dictionary<Guid, List<RoomType>> _companyPolicies = new Dictionary<Guid, List<RoomType>>();
    
    public void UpsertCompanyPolicy(Guid companyId, List<RoomType> roomTypes)
    {
        if (_companyPolicies.ContainsKey(companyId))
        {
            _companyPolicies[companyId] = roomTypes;
        }
        else
        {
            _companyPolicies.Add(companyId, roomTypes);   
        }
    }

    public void UpsertEmployeePolicy(Guid employeeId, List<RoomType> roomTypes)
    {
        if (_employeePolicies.ContainsKey(employeeId))
        {
            _employeePolicies[employeeId] = roomTypes;
        }
        else
        {
            _employeePolicies.Add(employeeId, roomTypes);   
        }
    }

    public List<RoomType>? GetCompanyPolicy(Guid companyId)
    {
        return _companyPolicies.TryGetValue(companyId, out var policy) ? policy : null;
    }

    public List<RoomType>? GetEmployeePolicy(Guid employeeId)
    {
        return _employeePolicies.TryGetValue(employeeId, out var policy) ? policy : null;
    }
}