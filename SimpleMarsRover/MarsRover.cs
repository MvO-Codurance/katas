namespace SimpleMarsRover;

public class MarsRover
{
    public Position Position { get; }

    public MarsRover()
    {
        Position = new Position();
    }

    public string Execute(string command)
    {
        foreach (char cmd in command)
        {
            Position.Execute(cmd);
        }

        return Position.ToString();
    }
}