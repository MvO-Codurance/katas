using FluentAssertions;
using HotelBooking.Models;
using HotelBooking.Services;
using Xunit;

namespace HotelBooking.Tests;

public class InMemoryCompanyRepositoryShould
{
    [Theory]
    [InlineAutoNSubstituteData()]
    public void Throw_When_Adding_Employee_That_Exists(
        Employee employee,
        InMemoryCompanyRepository sut)
    {
        // arrange
        sut.AddEmployee(employee);
        
        // act
        Action act = () => sut.AddEmployee(employee);
        
        // assert
        act.Should().ThrowExactly<ArgumentException>();
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Add_An_Employee_That_Does_Not_Exist(
        Employee employee,
        InMemoryCompanyRepository sut)
    {
        // arrange
        
        // act
        sut.AddEmployee(employee);

        // assert
        sut.FindEmployeeBy(employee.Id).Should().BeEquivalentTo(employee);
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Delete_An_Employee_That_Does_Not_Exist(
        Employee employee,
        InMemoryCompanyRepository sut)
    {
        // arrange
        
        // act
        sut.DeleteEmployee(employee.Id);

        // assert
        sut.FindEmployeeBy(employee.Id).Should().BeNull();
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Delete_An_Employee_That_Does_Exist(
        Employee employee,
        InMemoryCompanyRepository sut)
    {
        // arrange
        sut.AddEmployee(employee);
        
        // act
        sut.DeleteEmployee(employee.Id);

        // assert
        sut.FindEmployeeBy(employee.Id).Should().BeNull();
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Return_Null_When_An_Employee_Does_Not_Exist(
        Employee employee,
        InMemoryCompanyRepository sut)
    {
        // arrange
        
        // act
        var actual = sut.FindEmployeeBy(employee.Id);

        // assert
        actual.Should().BeNull();
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Return_The_Employee_When_They_Do_Exist(
        Employee employee,
        InMemoryCompanyRepository sut)
    {
        // arrange
        sut.AddEmployee(employee);
        
        // act
        var actual = sut.FindEmployeeBy(employee.Id); 

        // assert
        actual.Should().BeEquivalentTo(employee);
    }
}