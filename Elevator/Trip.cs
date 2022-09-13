namespace Elevator;

public class Trip
{
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

        DoorsOpenedOnFloors = $"{(char)CalledFromFloor}{(char)GoToFloor}";
    }

    // private int CalculateTripTime()
    // {
    //     
    // }
}