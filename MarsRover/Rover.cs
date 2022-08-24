namespace MarsRover;

public class Rover
{
    private const char Left = 'L';
    private const char Right = 'R';
    private const char Move = 'M';
    
    private const int MinimumIndex = 0;
    private const int MaximumIndex = 9;

    private Position Position { get; set; }
    private Direction Direction { get; set; }
    private List<Position> Obstacles { get; set; }
    private bool HitObstacle { get; set; }

    public Rover()
        : this(0, 0, Direction.N, new List<Position>())
    {
    }
    
    public Rover(List<Position> obstacles)
        : this(0, 0, Direction.N, obstacles)
    {
    }
    
    public Rover(int initialX, int initialY, Direction initialDirection)
        : this(new Position(initialX, initialY), initialDirection, new List<Position>())
    {
    }
    
    public Rover(int initialX, int initialY, Direction initialDirection, List<Position> obstacles)
        : this(new Position(initialX, initialY), initialDirection, obstacles)
    {
    }

    public Rover(Position initialPosition, Direction initialDirection, List<Position> obstacles)
    {
        Position = initialPosition;
        Direction = initialDirection;
        Obstacles = obstacles;
    }
    
    public string Execute(string commands)
    {
        foreach (char command in commands)
        {
            int newX = Position.X;
            int newY = Position.Y;
            
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
                    newY = IncrementPositionIndex(Position.Y);
                    break;
                case Move when Direction == Direction.E:
                    newX = IncrementPositionIndex(Position.X);
                    break;
                case Move when Direction == Direction.S:
                    newY = DecrementPositionIndex(Position.Y);
                    break;
                case Move when Direction == Direction.W:
                    newX = DecrementPositionIndex(Position.X);
                    break;
                
                default:
                    throw new ArgumentException($"Command '{command}' is not recognised.");
            }
            
            // check for obstacle
            foreach (Position obstacle in Obstacles)
            {
                if (obstacle.X == newX && obstacle.Y == newY)
                {
                    // we found an obstacle at the position we want to move to
                    HitObstacle = true;
                    break;
                }
            }

            if (HitObstacle)
            {
                // we hit an obstacle so stop processing commands
                break;
            }

            Position.X = newX;
            Position.Y = newY;
        }

        return ToString();
    }
    
    public override string ToString()
    {
        return $"{(HitObstacle ? "O:" : string.Empty)}{Position.X}:{Position.Y}:{Direction}";
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