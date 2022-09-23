using System.Text;

namespace SmartFridge;

public class SmartFridge
{
    public DateOnly CurrentDate { get; private set; }
    public List<FridgeItem> Contents { get; }
    public DoorPosition DoorPosition { get; private set; }

    public SmartFridge(IClock clock)
    {
        CurrentDate = DateOnly.FromDateTime(clock.UtcNow.Date);
        Contents = new List<FridgeItem>();
        DoorPosition = DoorPosition.Closed;
    }
    
    public void SetCurrentDate(DateOnly currentDate)
    {
        CurrentDate = currentDate;
    }
    
    public void ScanAddedItem(FridgeItem item)
    {
        item.Added = CurrentDate;
        Contents.Add(item);
    }

    public void ScanRemovedItem(string itemName)
    {
        var index = Contents.FindIndex(i => string.Equals(i.Name, itemName, StringComparison.OrdinalIgnoreCase));
        if (index >= 0)
        {
            Contents.RemoveAt(index);
        }
    }

    public void SignalFridgeDoorOpened()
    {
        DoorPosition = DoorPosition.Open;
        foreach (var item in Contents)
        {
            item.DegradeExpiry();
        }
    }

    public void SignalFridgeDoorClosed()
    {
        DoorPosition = DoorPosition.Closed;
    }

    public void SimulateDayOver()
    {
        CurrentDate = CurrentDate.AddDays(1);
    }
    
    public string ShowDisplay()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine();

        var expiredItems = Contents.Where(i => i.IsExpired(CurrentDate)).ToList();
        foreach (var item in expiredItems)
        {
            sb.AppendLine($"EXPIRED: {item.Name}");
        }
        
        var inDateItems = Contents.Except(expiredItems).OrderBy(i => i.ExpiresIn(CurrentDate));
        foreach (var item in inDateItems)
        {
            var totalDays = item.ExpiresIn(CurrentDate).TotalDays;
            var dayOrDays = totalDays == 1 ? "day" : "days";
            sb.AppendLine($"{item.Name}: {totalDays} {dayOrDays} remaining");
        }

        return sb.ToString();
    }
}

public enum DoorPosition
{
    Closed,
    Open
}