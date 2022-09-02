using FluentAssertions;
using HotelBooking.Models;
using HotelBooking.Services;
using Xunit;

namespace HotelBooking.Tests;

public class InMemoryBookingPolicyRepositoryShould
{
    [Theory]
    [InlineAutoNSubstituteData]
    public void Return_Null_When_Employee_Policy_Does_Not_Exist(
        Guid employeeId,
        InMemoryBookingPolicyRepository sut)
    {
        // arrange
        
        // act
        var actual = sut.GetEmployeePolicy(employeeId);

        // assert
        actual.Should().BeNull();
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Return_Policy_When_Employee_Policy_Does_Exist(
        Guid employeeId,
        List<RoomType> policy,
        InMemoryBookingPolicyRepository sut)
    {
        // arrange
        sut.UpsertEmployeePolicy(employeeId, policy);
        
        // act
        var actual = sut.GetEmployeePolicy(employeeId);

        // assert
        actual.Should().BeEquivalentTo(policy);
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Insert_Employee_Policy_When_Employee_Policy_Does_Not_Exist(
        Guid employeeId,
        List<RoomType> policy,
        InMemoryBookingPolicyRepository sut)
    {
        // arrange
        
        // act
        sut.UpsertEmployeePolicy(employeeId, policy);

        // assert
        sut.GetEmployeePolicy(employeeId).Should().BeEquivalentTo(policy);
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Update_Employee_Policy_When_Employee_Policy_Does_Exist(
        Guid employeeId,
        List<RoomType> originalPolicy,
        List<RoomType> newPolicy,
        InMemoryBookingPolicyRepository sut)
    {
        // arrange
        sut.UpsertEmployeePolicy(employeeId, originalPolicy);
        
        // act
        sut.UpsertEmployeePolicy(employeeId, newPolicy);

        // assert
        sut.GetEmployeePolicy(employeeId).Should().BeEquivalentTo(newPolicy);
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Return_Null_When_Company_Policy_Does_Not_Exist(
        Guid companyId,
        InMemoryBookingPolicyRepository sut)
    {
        // arrange
        
        // act
        var actual = sut.GetCompanyPolicy(companyId);

        // assert
        actual.Should().BeNull();
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Return_Policy_When_Company_Policy_Does_Exist(
        Guid companyId,
        List<RoomType> policy,
        InMemoryBookingPolicyRepository sut)
    {
        // arrange
        sut.UpsertCompanyPolicy(companyId, policy);
        
        // act
        var actual = sut.GetCompanyPolicy(companyId);

        // assert
        actual.Should().BeEquivalentTo(policy);
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Insert_Company_Policy_When_Company_Policy_Does_Not_Exist(
        Guid companyId,
        List<RoomType> policy,
        InMemoryBookingPolicyRepository sut)
    {
        // arrange
        
        // act
        sut.UpsertCompanyPolicy(companyId, policy);

        // assert
        sut.GetCompanyPolicy(companyId).Should().BeEquivalentTo(policy);
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Update_Company_Policy_When_Company_Policy_Does_Exist(
        Guid companyId,
        List<RoomType> originalPolicy,
        List<RoomType> newPolicy,
        InMemoryBookingPolicyRepository sut)
    {
        // arrange
        sut.UpsertCompanyPolicy(companyId, originalPolicy);
        
        // act
        sut.UpsertCompanyPolicy(companyId, newPolicy);

        // assert
        sut.GetCompanyPolicy(companyId).Should().BeEquivalentTo(newPolicy);
    }
}