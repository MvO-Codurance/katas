using AutoFixture.Xunit2;
using FluentAssertions;
using HotelBooking.Abstractions;
using HotelBooking.Models;
using HotelBooking.Services;
using NSubstitute;
using Xunit;

namespace HotelBooking.Tests;

public class BookingPolicyServiceShould
{
    [Theory]
    [InlineAutoNSubstituteData]
    public void Upsert_Company_Policy(
        Guid companyId,
        List<RoomType> newPolicy,
        [Frozen] IBookingPolicyRepository bookingPolicyRepository,
        BookingPolicyService sut)
    {
        // arrange
        
        // act
        sut.SetCompanyPolicy(companyId, newPolicy);

        // assert
        bookingPolicyRepository.Received(1).UpsertCompanyPolicy(companyId, newPolicy);
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Upsert_Employee_Policy(
        Guid employeeId,
        List<RoomType> newPolicy,
        [Frozen] IBookingPolicyRepository bookingPolicyRepository,
        BookingPolicyService sut)
    {
        // arrange
        
        // act
        sut.SetEmployeePolicy(employeeId, newPolicy);

        // assert
        bookingPolicyRepository.Received(1).UpsertEmployeePolicy(employeeId, newPolicy);
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Disallow_Booking_When_Employee_Does_Not_Exist(
        Employee employee,
        RoomType roomType,
        [Frozen] ICompanyService companyService,
        [Frozen] IBookingPolicyRepository bookingPolicyRepository,
        BookingPolicyService sut)
    {
        // arrange
        companyService.FindEmployeeBy(employee.Id).Returns(null as Employee);
        
        // act
        var actual = sut.IsBookingAllowed(employee.Id, roomType);

        // assert
        actual.Should().BeFalse();
        companyService.Received(1).FindEmployeeBy(employee.Id);
        bookingPolicyRepository.DidNotReceive().GetEmployeePolicy(Arg.Any<Guid>());
        bookingPolicyRepository.DidNotReceive().GetCompanyPolicy(Arg.Any<Guid>());
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Allow_Booking_When_No_Policy_Exists(
        Employee employee,
        RoomType roomType,
        [Frozen] ICompanyService companyService,
        [Frozen] IBookingPolicyRepository bookingPolicyRepository,
        BookingPolicyService sut)
    {
        // arrange
        companyService.FindEmployeeBy(employee.Id).Returns(employee);
        bookingPolicyRepository.GetEmployeePolicy(Arg.Any<Guid>()).Returns(null as List<RoomType>);
        bookingPolicyRepository.GetCompanyPolicy(Arg.Any<Guid>()).Returns(null as List<RoomType>);
        
        // act
        var actual = sut.IsBookingAllowed(employee.Id, roomType);

        // assert
        actual.Should().BeTrue();
        companyService.Received(1).FindEmployeeBy(employee.Id);
        bookingPolicyRepository.Received(1).GetEmployeePolicy(employee.Id);
        bookingPolicyRepository.Received(1).GetCompanyPolicy(Arg.Any<Guid>());
    }
    
    [Theory]
    [InlineAutoNSubstituteData(RoomType.JuniorSuite, true)]
    [InlineAutoNSubstituteData(RoomType.MasterSuite, false)]
    public void Use_Employee_Policy_When_Employee_Policy_Exists(
        RoomType roomType,
        bool expectedResult,
        Employee employee,
        [Frozen] ICompanyService companyService,
        [Frozen] IBookingPolicyRepository bookingPolicyRepository,
        BookingPolicyService sut)
    {
        // arrange
        companyService.FindEmployeeBy(employee.Id).Returns(employee);
        bookingPolicyRepository.GetEmployeePolicy(Arg.Any<Guid>()).Returns(new List<RoomType> { RoomType.JuniorSuite });
        bookingPolicyRepository.GetCompanyPolicy(Arg.Any<Guid>()).Returns(null as List<RoomType>);
        
        // act
        var actual = sut.IsBookingAllowed(employee.Id, roomType);

        // assert
        actual.Should().Be(expectedResult);
        companyService.Received(1).FindEmployeeBy(employee.Id);
        bookingPolicyRepository.Received(1).GetEmployeePolicy(employee.Id);
        bookingPolicyRepository.DidNotReceive().GetCompanyPolicy(Arg.Any<Guid>());
    }
    
    [Theory]
    [InlineAutoNSubstituteData(RoomType.JuniorSuite, true)]
    [InlineAutoNSubstituteData(RoomType.MasterSuite, false)]
    public void Use_Company_Policy_When_Employee_Policy_Does_Not_Exist_And_Company_Policy_Does_Exist(
        RoomType roomType,
        bool expectedResult,
        Employee employee,
        [Frozen] ICompanyService companyService,
        [Frozen] IBookingPolicyRepository bookingPolicyRepository,
        BookingPolicyService sut)
    {
        // arrange
        companyService.FindEmployeeBy(employee.Id).Returns(employee);
        bookingPolicyRepository.GetEmployeePolicy(Arg.Any<Guid>()).Returns(null as List<RoomType>);
        bookingPolicyRepository.GetCompanyPolicy(Arg.Any<Guid>()).Returns(new List<RoomType> { RoomType.JuniorSuite });
        
        // act
        var actual = sut.IsBookingAllowed(employee.Id, roomType);

        // assert
        actual.Should().Be(expectedResult);
        companyService.Received(1).FindEmployeeBy(employee.Id);
        bookingPolicyRepository.Received(1).GetEmployeePolicy(employee.Id);
        bookingPolicyRepository.Received(1).GetCompanyPolicy(employee.CompanyId);
    }
}