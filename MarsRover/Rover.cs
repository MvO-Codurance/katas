namespace MarsRover;

public class Rover
{
    private const char Left = 'L';
    private const char Right = 'R';
    private const char Move = 'M';
    
    private const int MinimumIndex = 0;
    private const int MaximumIndex = 9;

    private int X { get; set; }
    private int Y { get; set; }
    private Direction Direction { get; set; }

    public Rover()
        : this(0, 0, Direction.N)
    {
    }

    public Rover(int initialX, int initialY, Direction initialDirection)
    {
        X = initialX;
        Y = initialY;
        Direction = initialDirection;
    }
    
    public string Execute(string commands)
    {
        foreach (char command in commands)
        {
            switch (command)
            {
                // left
                case Left when Direction == Direction.N:
                    Direction = Direction.W;
                    break;
                case Left when Direction == Direction.W:
                    Direction = Direction.S;
                    break;
                case Left when Direction == Direction.S:
                    Direction = Direction.E;
                    break;
                case Left when Direction == Direction.E:
                    Direction = Direction.N;
                    break;
                
                // right
                case Right when Direction == Direction.N:
                    Direction = Direction.E;
                    break;
                case Right when Direction == Direction.E:
                    Direction = Direction.S;
                    break;
                case Right when Direction == Direction.S:
                    Direction = Direction.W;
                    break;
                case Right when Direction == Direction.W:
                    Direction = Direction.N;
                    break;
                
                // move
                case Move when Direction == Direction.N:
                    Y = IncrementPositionIndex(Y);
                    break;
                case Move when Direction == Direction.E:
                    X = IncrementPositionIndex(X);
                    break;
                case Move when Direction == Direction.S:
                    Y = DecrementPositionIndex(Y);
                    break;
                case Move when Direction == Direction.W:
                    X = DecrementPositionIndex(X);
                    break;
                
                default:
                    throw new ArgumentException($"Command '{command}' is not recognised.");
            }
        }

        return ToString();
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