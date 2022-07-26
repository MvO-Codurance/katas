namespace SmartFridge;

public interface IClock
{
    public DateTimeOffset UtcNow { get; }
}