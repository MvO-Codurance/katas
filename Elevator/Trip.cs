namespace Elevator;

public class Trip
{
    private const int TimeTakenBetweenFloors = 1;
    private const int TimeTakenAtFloor = 3;
    
    public Floor StartingFloor { get; private set; }
    public Floor CalledFromFloor { get; private set; }
    public Floor GoToFloor { get; private set; }
    public int TimeTaken { get; private set; }
    public string DoorsOpenedOnFloors { get; private set; }

    public Trip(Floor startingFloor, Call call)
    {
        StartingFloor = startingFloor;
        CalledFromFloor = call.CalledFromFloor;
        GoToFloor = call.GoToFloor;
        TimeTaken = CalculateTripTime();
        DoorsOpenedOnFloors = GetDoorsOpenedOnFloors();
    }

    private int CalculateTripTime()
    {
        var startingToCalled = Math.Abs(StartingFloor - CalledFromFloor);
        var calledToDestination = Math.Abs(CalledFromFloor - GoToFloor);

        return (startingToCalled * TimeTakenBetweenFloors) +
               TimeTakenAtFloor +
               (calledToDestination * TimeTakenBetweenFloors) +
               TimeTakenAtFloor;
    }

    private string GetDoorsOpenedOnFloors()
    {
        return $"{GetFloorLetter(CalledFromFloor)}{GetFloorLetter(GoToFloor)}";
    }
    
    private char GetFloorLetter(Floor floor)
    {
        return floor switch
        {
            Floor.Basement => 'B',
            Floor.Ground => 'G',
            Floor.One => '1',
            Floor.Two => '2',
            Floor.Three => '3',
            _ => ' '
        };
    }
}