namespace MarsRover;

public class Grid
{
    private const int DefaultGridSize = 10;
    
    private readonly int _minimumIndex = 0;
    private readonly int _maximumIndex;
    private readonly List<Coordinate> _obstacles;
    
    public Grid()
        : this(DefaultGridSize, new List<Coordinate>())
    {
    }
    
    public Grid(List<Coordinate> obstacles)
        : this(DefaultGridSize, obstacles)
    {
    }
    
    public Grid(int gridSize, List<Coordinate> obstacles)
    {
        _obstacles = obstacles;
        _maximumIndex = gridSize - 1;
    }

    public Coordinate Move(Coordinate coordinate, CompassHeading heading)
    {
        int newX = coordinate.X;
        int newY = coordinate.Y;

        switch (heading)
        {
            case CompassHeading.N:
                newY = IncrementPositionIndex(coordinate.Y);
                break;
            case CompassHeading.E:
                newX = IncrementPositionIndex(coordinate.X);
                break;
            case CompassHeading.S:
                newY = DecrementPositionIndex(coordinate.Y);
                break;
            case CompassHeading.W:
                newX = DecrementPositionIndex(coordinate.X);
                break;    
        }

        var newCoordinate = new Coordinate(newX, newY);
        
        // check for obstacle
        foreach (Coordinate obstacle in _obstacles)
        {
            if (newCoordinate == obstacle)
            {
                // we found an obstacle so return original coordinate
                return coordinate;
            }
        }

        return newCoordinate;
    }
    
    private int IncrementPositionIndex(int index)
    {
        index++;
        
        if (index > _maximumIndex)
        {
            index = _minimumIndex;
        }

        return index;
    }
    
    private int DecrementPositionIndex(int index)
    {
        index--;
        
        if (index < _minimumIndex)
        {
            index = _maximumIndex;
        }

        return index;
    }
}