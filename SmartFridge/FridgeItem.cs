namespace SmartFridge;

public class FridgeItem
{
    private DateTimeOffset _exactExpiry;
    
    public string Name { get; }
    public DateTimeOffset Expiry => _exactExpiry;
    public FridgeItemCondition Condition { get; }
    public DateOnly Added { get; set; }
    
    public FridgeItem(string name, DateOnly expiry, FridgeItemCondition condition)
    {
        Name = name;
        _exactExpiry = new DateTimeOffset(expiry.Year, expiry.Month, expiry.Day, 23, 59, 59, TimeSpan.Zero);
        Condition = condition;
    }
    
    public void DegradeExpiry()
    {
        _exactExpiry = Condition switch
        {
            FridgeItemCondition.Sealed => _exactExpiry.AddHours(-1),
            FridgeItemCondition.Opened => _exactExpiry.AddHours(-5),
            _ => _exactExpiry
        };
    }

    public bool IsExpired(DateOnly currentDate)
    {
        return currentDate.ToDateTime(TimeOnly.MinValue) > Expiry;
    }

    public TimeSpan ExpiresIn(DateOnly currentDate)
    {
        return Expiry.Date - currentDate.ToDateTime(TimeOnly.MinValue);
    }
}

public enum FridgeItemCondition
{
    Sealed,
    Opened
}