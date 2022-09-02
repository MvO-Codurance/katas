using HotelBooking.Models;

namespace HotelBooking.Abstractions;

public interface ICompanyRepository
{
    void AddEmployee(Employee employee);

    void DeleteEmployee(Guid employeeId);
    
    Employee? FindEmployeeBy(Guid employeeId);
}