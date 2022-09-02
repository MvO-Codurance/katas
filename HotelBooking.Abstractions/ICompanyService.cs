using HotelBooking.Models;

namespace HotelBooking.Abstractions;

public interface ICompanyService
{
    void AddEmployee(Guid companyId, Guid employeeId);
        
    void DeleteEmployee(Guid employeeId);
    
    Employee? FindEmployeeBy(Guid employeeId);
}