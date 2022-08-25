namespace MarsRover;

public class Rover
{
    private const char Left = 'L';
    private const char Right = 'R';
    private const char Move = 'M';
    
    private Coordinate _coordinate;
    private readonly Compass _compass;
    private readonly Grid _grid;
    private bool _hitObstacle;

    public Rover()
        : this(0, 0, CompassHeading.N, new Grid())
    {
    }
    
    public Rover(Grid grid)
        : this(0, 0, CompassHeading.N, grid)
    {
    }
    
    public Rover(int initialX, int initialY, CompassHeading initialHeading)
        : this(new Coordinate(initialX, initialY), initialHeading, new Grid())
    {
    }
    
    public Rover(int initialX, int initialY, CompassHeading initialHeading, Grid obstacles)
        : this(new Coordinate(initialX, initialY), initialHeading, obstacles)
    {
    }

    public Rover(Coordinate initialCoordinate, CompassHeading initialHeading, Grid grid)
    {
        _coordinate = initialCoordinate;
        _compass = new Compass(initialHeading);
        _grid = grid;
    }
    
    public string Execute(string commands)
    {
        foreach (char command in commands)
        {
            switch (command)
            {
                case Left:
                    _compass.TurnLeft();
                    break;
                
                case Right:
                    _compass.TurnRight();
                    break;
                
                case Move:
                    var newCoordinate = _grid.Move(_coordinate, _compass.Heading);
                    if (newCoordinate == _coordinate)
                    {
                        _hitObstacle = true;
                    }
                    _coordinate = newCoordinate;
                    
                    break;
                
                default:
                    throw new ArgumentException($"Command '{command}' is not recognised.");
            }
        }

        return ToString();
    }
    
    public override string ToString()
    {
        return $"{(_hitObstacle ? "O:" : string.Empty)}{_coordinate.X}:{_coordinate.Y}:{_compass.Heading}";
    }
}