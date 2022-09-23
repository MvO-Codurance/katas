using HotelBooking.Abstractions;
using HotelBooking.Models;

namespace HotelBooking.Services;

public class InMemoryCompanyRepository : ICompanyRepository
{
    private Dictionary<Guid, Employee> _employees = new Dictionary<Guid, Employee>();
    
    public void AddEmployee(Employee employee)
    {
        _employees.Add(employee.Id, employee);
    }

    public void DeleteEmployee(Guid employeeId)
    {
        if (_employees.ContainsKey(employeeId))
        {
            _employees.Remove(employeeId);
        }
    }

    public Employee? FindEmployeeBy(Guid employeeId)
    {
        return _employees.TryGetValue(employeeId, out var employee) ? employee : null;
    }
}