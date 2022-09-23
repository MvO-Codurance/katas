namespace SimpleMarsRover;

public class Position
{
    private const char North = 'N';
    private const char East = 'E';
    private const char South = 'S';
    private const char West = 'W';
    
    private const char Left = 'L';
    private const char Right = 'R';
    private const char Move = 'M';
    
    private const int MinimumIndex = 0;
    private const int MaximumIndex = 9;

    public int X { get; private set; }

    public int Y { get; private set; } 

    public char Direction { get; private set; }

    public Position(int x, int y, char direction)
    {
        X = x;
        Y = y;
        Direction = direction;
    }

    public Position()
    {
        X = 0;
        Y = 0;
        Direction = North;
    }

    public void Execute(char command)
    { 
        switch (command)
        {
            // left
            case Left when Direction == North:
                Direction = West;
                break;
            case Left when Direction == West:
                Direction = South;
                break;
            case Left when Direction == South:
                Direction = East;
                break;
            case Left when Direction == East:
                Direction = North;
                break;
            
            // right
            case Right when Direction == North:
                Direction = East;
                break;
            case Right when Direction == East:
                Direction = South;
                break;
            case Right when Direction == South:
                Direction = West;
                break;
            case Right when Direction == West:
                Direction = North;
                break;
            
            // move
            case Move when Direction == North:
                Y = IncrementPositionIndex(Y);
                break;
            case Move when Direction == East:
                X = IncrementPositionIndex(X);
                break;
            case Move when Direction == South:
                Y = DecrementPositionIndex(Y);
                break;
            case Move when Direction == West:
                X = DecrementPositionIndex(X);
                break;
        }
    }
    
    public override string ToString()
    {
        return $"{X}:{Y}:{Direction}";
    }

    private int IncrementPositionIndex(int index)
    {
        index++;
        
        if (index > MaximumIndex)
        {
            index = MinimumIndex;
        }

        return index;
    }
    
    private int DecrementPositionIndex(int index)
    {
        index--;
        
        if (index < MinimumIndex)
        {
            index = MaximumIndex;
        }

        return index;
    }
}