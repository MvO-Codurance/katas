using FluentAssertions;
using HotelBooking.Models;
using HotelBooking.Services;
using Xunit;

namespace HotelBooking.Tests;

public class InMemoryHotelRepositoryShould
{
    [Theory]
    [InlineAutoNSubstituteData]
    public void Throw_When_Adding_A_Hotel_That_Exists(
        Hotel hotel,
        InMemoryHotelRepository sut)
    {
        // arrange
        sut.AddHotel(hotel);
        
        // act
        Action act = () => sut.AddHotel(hotel);
        
        // assert
        act.Should().ThrowExactly<ArgumentException>();
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Add_A_Hotel_That_Does_Not_Exist(
        Hotel hotel,
        InMemoryHotelRepository sut)
    {
        // arrange
        
        // act
        Action act = () => sut.AddHotel(hotel);

        // assert
        act.Should().NotThrow();
        sut.FindHotelBy(hotel.Id).Should().BeEquivalentTo(hotel);
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Return_Null_For_A_Hotel_That_Does_Not_Exist(
        Guid hotelId,
        InMemoryHotelRepository sut)
    {
        // arrange
        
        // act
        var actual = sut.FindHotelBy(hotelId);

        // assert
        actual.Should().BeNull();
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Return_The_Hotel_For_A_Hotel_That_Does_Exists(
        Hotel hotel,
        InMemoryHotelRepository sut)
    {
        // arrange
        sut.AddHotel(hotel);
        
        // act
        var actual = sut.FindHotelBy(hotel.Id);

        // assert
        actual.Should().BeEquivalentTo(hotel);
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Insert_A_Room_When_RoomNumber_Does_Not_Exist(
        Hotel hotel,
        string roomNumber,
        RoomType roomType,
        InMemoryHotelRepository sut)
    {
        // arrange
        hotel.Rooms.Clear();
        sut.AddHotel(hotel);
        
        // act
        sut.UpsertRoom(hotel.Id, roomNumber, roomType);

        // assert
        var returnedHotel = sut.FindHotelBy(hotel.Id);
        returnedHotel.Should().NotBeNull();

        var expectedRooms = new Dictionary<string, Room>
        {
            { roomNumber, new Room { Number = roomNumber, Type = roomType } }
        };
        returnedHotel!.Rooms.Should().BeEquivalentTo(expectedRooms);
    }
    
    [Theory]
    [InlineAutoNSubstituteData]
    public void Update_A_Room_When_RoomNumber_Does_Exist(
        Hotel hotel,
        string roomNumber,
        RoomType originalRoomType,
        RoomType newRoomType,
        InMemoryHotelRepository sut)
    {
        // arrange
        hotel.Rooms.Clear();
        sut.AddHotel(hotel);
        sut.UpsertRoom(hotel.Id, roomNumber, originalRoomType);
        
        // act
        sut.UpsertRoom(hotel.Id, roomNumber, newRoomType);

        // assert
        var returnedHotel = sut.FindHotelBy(hotel.Id);
        returnedHotel.Should().NotBeNull();

        var expectedRooms = new Dictionary<string, Room>
        {
            { roomNumber, new Room { Number = roomNumber, Type = newRoomType } }
        };
        returnedHotel!.Rooms.Should().BeEquivalentTo(expectedRooms);
    }
}