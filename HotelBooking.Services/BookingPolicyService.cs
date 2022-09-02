using HotelBooking.Abstractions;
using HotelBooking.Models;

namespace HotelBooking.Services;

public class BookingPolicyService : IBookingPolicyService
{
    private readonly ICompanyService _companyService;
    private readonly IBookingPolicyRepository _bookingPolicyRepository;

    public BookingPolicyService(
        ICompanyService companyService,
        IBookingPolicyRepository bookingPolicyRepository)
    {
        _companyService = companyService ?? throw new ArgumentNullException(nameof(companyService));
        _bookingPolicyRepository = bookingPolicyRepository ?? throw new ArgumentNullException(nameof(bookingPolicyRepository));
    }
    
    public void SetCompanyPolicy(Guid companyId, List<RoomType> roomTypes)
    {
        _bookingPolicyRepository.UpsertCompanyPolicy(companyId, roomTypes);
    }

    public void SetEmployeePolicy(Guid employeeId, List<RoomType> roomTypes)
    {
        _bookingPolicyRepository.UpsertEmployeePolicy(employeeId, roomTypes);
    }

    public bool IsBookingAllowed(Guid employeeId, RoomType roomType)
    {
        var employee = _companyService.FindEmployeeBy(employeeId);
        if (employee == null)
        {
            return false;
        }
        
        var employeePolicy = _bookingPolicyRepository.GetEmployeePolicy(employee.Id);
        if (employeePolicy != null)
        {
            return employeePolicy.Contains(roomType);
        }
        
        var companyPolicy = _bookingPolicyRepository.GetCompanyPolicy(employee.CompanyId);
        if (companyPolicy != null)
        {
            return companyPolicy.Contains(roomType);
        }
        
        return true;
    }
}