using HotelBooking.Abstractions;
using HotelBooking.Models;

namespace HotelBooking.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
    }
    
    public void AddEmployee(Guid companyId, Guid employeeId)
    {
        var employee = _companyRepository.FindEmployeeBy(employeeId);
        if (employee != null)
        {
            throw new ArgumentException($"Employee with id {employeeId} already exists.");
        }
        
        _companyRepository.AddEmployee(new Employee{ Id = employeeId, CompanyId = companyId });
    }

    public void DeleteEmployee(Guid employeeId)
    {
        _companyRepository.DeleteEmployee(employeeId);
    }

    public Employee? FindEmployeeBy(Guid employeeId)
    {
        return _companyRepository.FindEmployeeBy(employeeId);
    }
}