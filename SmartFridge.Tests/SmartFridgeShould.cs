using FluentAssertions;
using Moq;
using NuGet.Frameworks;
using Xunit;

namespace SmartFridge.Tests;

public class SmartFridgeShould
{
    [Theory]
    [InlineAutoMoqData]
    public void BeEmptyWhenNew(Mock<IClock> clock)
    {
        new SmartFridge(clock.Object).Contents.Should().HaveCount(0);
    }
    
    [Theory]
    [InlineAutoMoqData]
    public void HaveUtcNowAsTheDefaultCurrentDate(Mock<IClock> clock)
    {
        var utcNow = DateTimeOffset.UtcNow;
        clock.Setup(x => x.UtcNow).Returns(utcNow);
        
        new SmartFridge(clock.Object).CurrentDate.Should().Be(DateOnly.FromDateTime(utcNow.Date));
    }
    
    [Theory]
    [InlineAutoMoqData]
    public void RecordTheSpecifiedCurrentDate(Mock<IClock> clock, DateOnly currentDate)
    {
        var fridge = new SmartFridge(clock.Object);
        
        fridge.SetCurrentDate(currentDate);
        
        fridge.CurrentDate.Should().Be(currentDate);
    }
    
    [Theory]
    [InlineAutoMoqData]
    public void TrackItemPlacedIntoTheFridge(Mock<IClock> clock, DateOnly expiry)
    {
        var utcNow = DateTimeOffset.UtcNow;
        clock.Setup(x => x.UtcNow).Returns(utcNow);
        var fridge = new SmartFridge(clock.Object);
        
        var milk = new FridgeItem("Milk", expiry, FridgeItemCondition.Opened);
        
        fridge.ScanAddedItem(milk);
        
        fridge.Contents.Should().HaveCount(1);
        fridge.Contents[0].Name.Should().Be("Milk");
        fridge.Contents[0].Added.Should().Be(DateOnly.FromDateTime(utcNow.Date));
    }
    
    [Theory]
    [InlineAutoMoqData]
    public void TrackItemRemovedFromTheFridge(Mock<IClock> clock, DateOnly expiry)
    {
        var milk = new FridgeItem("Milk", expiry, FridgeItemCondition.Opened);
        var fridge = new SmartFridge(clock.Object);
        fridge.ScanAddedItem(milk);
        
        fridge.ScanRemovedItem("Milk");
        
        fridge.Contents.Should().HaveCount(0);
    }
    
    [Theory]
    [InlineAutoMoqData]
    public void TrackFirstOccurrenceOfItemRemovedFromTheFridge(
        Mock<IClock> clock, 
        DateOnly milk1Expiry, 
        DateOnly milk2Expiry)
    {
        var milk1 = new FridgeItem("Milk", milk1Expiry, FridgeItemCondition.Opened);
        var milk2 = new FridgeItem("Milk", milk2Expiry, FridgeItemCondition.Sealed);
        var fridge = new SmartFridge(clock.Object);
        fridge.ScanAddedItem(milk1);
        fridge.ScanAddedItem(milk2);
        
        fridge.ScanRemovedItem("Milk");
        
        fridge.Contents.Should().HaveCount(1);
        fridge.Contents[0].Condition.Should().Be(FridgeItemCondition.Sealed, "this is the condition of the second milk");
    }
    
    [Theory]
    [InlineAutoMoqData]
    public void NotTrackItemRemovedFromTheFridgeThatDoesNotExist(Mock<IClock> clock, DateOnly expiry)
    {
        var milk = new FridgeItem("Milk", expiry, FridgeItemCondition.Opened);
        var fridge = new SmartFridge(clock.Object);
        fridge.ScanAddedItem(milk);
        
        fridge.ScanRemovedItem("Not Milk");
        
        fridge.Contents.Should().HaveCount(1);
        fridge.Contents[0].Name.Should().Be("Milk");
    }
    
    [Theory]
    [InlineAutoMoqData]
    public void DegradeExpiryOfItemsBy1Or5HoursWhenFridgeDoorIsOpened(
        Mock<IClock> clock, 
        DateOnly milkExpiry, 
        DateOnly cheeseExpiry)
    {
        var utcNow = DateTimeOffset.UtcNow;
        clock.Setup(x => x.UtcNow).Returns(utcNow);
        var fridge = new SmartFridge(clock.Object);
        
        var milk = new FridgeItem("Milk", milkExpiry, FridgeItemCondition.Sealed);
        var cheese = new FridgeItem("Cheese", cheeseExpiry, FridgeItemCondition.Opened);

        fridge.ScanAddedItem(milk);
        fridge.ScanAddedItem(cheese);

        var expectedMilkExpiry = milk.Expiry.AddHours(-1); 
        var expectedCheeseExpiry = cheese.Expiry.AddHours(-5);
        
        fridge.SignalFridgeDoorOpened();
        
        fridge.Contents[0].Expiry.Should().Be(expectedMilkExpiry, "the sealed milk expiry should have degraded by 1 hour");
        fridge.Contents[1].Expiry.Should().Be(expectedCheeseExpiry, "the opened cheese expiry should have degraded by 5 hours");
    }
    
    [Theory]
    [InlineAutoMoqData]
    public void RecordDoorPositionAsClosedWhenNew(Mock<IClock> clock)
    {
        new SmartFridge(clock.Object).DoorPosition.Should().Be(DoorPosition.Closed);
    }
    
    [Theory]
    [InlineAutoMoqData]
    public void RecordDoorPosition(Mock<IClock> clock)
    {
        var fridge = new SmartFridge(clock.Object);
        
        fridge.SignalFridgeDoorOpened();
        fridge.DoorPosition.Should().Be(DoorPosition.Open);

        fridge.SignalFridgeDoorClosed();
        fridge.DoorPosition.Should().Be(DoorPosition.Closed);
    }
    
    [Theory]
    [InlineAutoMoqData]
    public void SimulateDayOverByAdvancingTheCurrentDateBy1Day(Mock<IClock> clock, DateOnly currentDate)
    {
        var fridge = new SmartFridge(clock.Object);
        fridge.SetCurrentDate(currentDate);
        
        fridge.SimulateDayOver();
        
        fridge.CurrentDate.Should().Be(currentDate.AddDays(1));
    }
    
    [Theory]
    [InlineAutoMoqData]
    public void DisplayCorrectOutputFormat(Mock<IClock> clock)
    {
        var utcNow = DateTimeOffset.UtcNow;
        clock.Setup(x => x.UtcNow).Returns(utcNow);
        var fridge = new SmartFridge(clock.Object);

        fridge.SetCurrentDate(new DateOnly(2021, 10, 18));
        fridge.SignalFridgeDoorOpened();
        fridge.ScanAddedItem(new FridgeItem("Milk", new DateOnly(2021, 10, 20), FridgeItemCondition.Sealed));
        fridge.ScanAddedItem(new FridgeItem("Cheese", new DateOnly(2021, 11, 21), FridgeItemCondition.Sealed));
        fridge.ScanAddedItem(new FridgeItem("Beef", new DateOnly(2021, 10, 21), FridgeItemCondition.Sealed));
        fridge.ScanAddedItem(new FridgeItem("Lettuce", new DateOnly(2021, 10, 22), FridgeItemCondition.Sealed));
        fridge.SignalFridgeDoorClosed();
        
        fridge.SimulateDayOver();
        
        fridge.SignalFridgeDoorOpened();
        fridge.SignalFridgeDoorClosed();
        
        fridge.SignalFridgeDoorOpened();
        fridge.ScanRemovedItem("Milk");
        fridge.SignalFridgeDoorClosed();
        
        fridge.SignalFridgeDoorOpened();
        fridge.ScanAddedItem(new FridgeItem("Milk", new DateOnly(2021, 10, 20), FridgeItemCondition.Opened));
        fridge.ScanAddedItem(new FridgeItem("Peppers", new DateOnly(2021, 10, 22), FridgeItemCondition.Opened));
        fridge.SignalFridgeDoorClosed();
        
        fridge.SimulateDayOver();
        
        fridge.SignalFridgeDoorOpened();
        fridge.ScanRemovedItem("Beef");
        fridge.ScanRemovedItem("Lettuce");
        fridge.SignalFridgeDoorClosed();
        
        fridge.SignalFridgeDoorOpened();
        fridge.ScanAddedItem(new FridgeItem("Lettuce", new DateOnly(2021, 10, 21), FridgeItemCondition.Opened));
        fridge.SignalFridgeDoorClosed();
        
        fridge.SignalFridgeDoorOpened();
        fridge.SignalFridgeDoorClosed();
        
        fridge.SimulateDayOver();
        
        fridge.ShowDisplay().Should().Be(
@"
EXPIRED: Milk
Lettuce: 0 days remaining
Peppers: 1 day remaining
Cheese: 31 days remaining
"
);
    }
}