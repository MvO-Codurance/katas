using AutoFixture.Xunit2;
using FluentAssertions;
using HotelBooking.Abstractions;
using HotelBooking.Models;
using HotelBooking.Services;
using NSubstitute;
using Xunit;

namespace HotelBooking.Tests;

public class HotelServiceShould
{
    [Theory]
    [InlineAutoNSubstituteData]
    public void Throw_When_Creating_Hotel_And_Hotel_Id_Already_Exists(
        Hotel hotel,
        [Frozen] IHotelRepository hotelRepository,
        HotelService sut)
    {
        // arrange
        hotelRepository.FindHotelBy(Arg.Any<Guid>()).Returns(hotel);
        
        // act
        Action act = () => sut.AddHotel(hotel.Id, hotel.Name);

        // assert
        act.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"Hotel with id {hotel.Id} already exists.");
        
        hotelRepository.Received(1).FindHotelBy(hotel.Id);
        hotelRepository.DidNotReceive().AddHotel(Arg.Any<Hotel>());
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Create_Hotel_When_Hotel_Id_Does_Not_Exist(
        Hotel hotel,
        [Frozen] IHotelRepository hotelRepository,
        HotelService sut)
    {
        // arrange
        hotelRepository.FindHotelBy(Arg.Any<Guid>()).Returns(null as Hotel);
        
        // act
        sut.AddHotel(hotel.Id, hotel.Name);

        // assert
        hotelRepository.Received(1).FindHotelBy(hotel.Id);
        hotelRepository.Received(1).AddHotel(Arg.Is<Hotel>(x => 
            x.Id == hotel.Id &&
            string.Equals(x.Name, hotel.Name, StringComparison.OrdinalIgnoreCase))
        );
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Return_Null_When_Finding_A_Hotel_That_Does_Not_Exist(
        Guid hotelId,
        [Frozen] IHotelRepository hotelRepository,
        HotelService sut)
    {
        // arrange
        hotelRepository.FindHotelBy(Arg.Any<Guid>()).Returns(null as Hotel);
        
        // act & assert
        sut.FindHotelBy(hotelId).Should().BeNull();
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Return_Hotel_When_Finding_A_Hotel_That_Does_Exist(
        Hotel hotel,
        [Frozen] IHotelRepository hotelRepository,
        HotelService sut)
    {
        // arrange
        hotelRepository.FindHotelBy(hotel.Id).Returns(hotel);
        
        // act
        var actual = sut.FindHotelBy(hotel.Id);
            
        // assert
        actual.Should().BeEquivalentTo(hotel);
        
        hotelRepository.Received(1).FindHotelBy(hotel.Id);
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Throw_When_Setting_A_Room_And_Hotel_Does_Not_Exist(
        Guid hotelId,
        string roomNumber,
        RoomType roomType,
        [Frozen] IHotelRepository hotelRepository,
        HotelService sut)
    {
        // arrange
        hotelRepository.FindHotelBy(Arg.Any<Guid>()).Returns(null as Hotel);
        
        // act
        Action act = () => sut.SetRoom(hotelId, roomNumber, roomType);

        // assert
        act.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"Hotel with id {hotelId} does not exist.");
        
        hotelRepository.Received(1).FindHotelBy(hotelId);
        hotelRepository.DidNotReceive().UpsertRoom(Arg.Any<Guid>(), Arg.Any<string>(), Arg.Any<RoomType>());
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Set_A_Room_When_Hotel_Exists(
        Hotel hotel,
        string roomNumber,
        RoomType roomType,
        [Frozen] IHotelRepository hotelRepository,
        HotelService sut)
    {
        // arrange
        hotelRepository.FindHotelBy(Arg.Any<Guid>()).Returns(hotel);
        
        // act
        sut.SetRoom(hotel.Id, roomNumber, roomType);

        // assert
        hotelRepository.Received(1).FindHotelBy(hotel.Id);
        hotelRepository.Received(1).UpsertRoom(hotel.Id, roomNumber, roomType);
    }
}