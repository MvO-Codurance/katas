using AutoFixture.Xunit2;
using FluentAssertions;
using HotelBooking.Abstractions;
using HotelBooking.Models;
using HotelBooking.Services;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace HotelBooking.Tests;

public class CompanyServiceShould
{
    [Theory]
    [InlineAutoNSubstituteData]
    public void Throw_When_Adding_An_Employee_That_Exists(
        Guid companyId,
        Guid employeeId,
        Employee? existingEmployee,
        [Frozen] ICompanyRepository companyRepository,
        CompanyService sut)
    {
        // arrange
        companyRepository.FindEmployeeBy(Arg.Any<Guid>()).Returns(existingEmployee);
        
        // act
        Action act = () => sut.AddEmployee(companyId, employeeId);

        // assert
        act.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"Employee with id {employeeId} already exists.");
        
        companyRepository.Received(1).FindEmployeeBy(employeeId);
        companyRepository.DidNotReceive().AddEmployee(Arg.Any<Employee>());
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Adds_New_Employee_When_Employee_Does_Not_Exist(
        Guid companyId,
        Guid employeeId,
        [Frozen] ICompanyRepository companyRepository,
        CompanyService sut)
    {
        // arrange
        companyRepository.FindEmployeeBy(Arg.Any<Guid>()).Returns(null as Employee);
        
        // act
        sut.AddEmployee(companyId, employeeId);

        // assert
        companyRepository.Received(1).FindEmployeeBy(employeeId);
        companyRepository.Received(1).AddEmployee(Arg.Is<Employee>(x => x.Id == employeeId && x.CompanyId == companyId));
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Deletes_Employee(
        Guid employeeId,
        [Frozen] ICompanyRepository companyRepository,
        CompanyService sut)
    {
        // arrange
        
        // act
        sut.DeleteEmployee(employeeId);

        // assert
        companyRepository.Received(1).DeleteEmployee(employeeId);
        
        // TODO ensure all employee bookings and policies are deleted
    }
}