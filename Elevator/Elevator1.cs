namespace Elevator;

public class Elevator1
{
    public Trips Trips { get; private set; }

    public Elevator1(Floor startingFloor)
    {
        Trips = new Trips(startingFloor);
    }
    
    public void Call(Floor calledFromFloor, Floor destinationFloor)
    {
        var call = new Call
        {
            CalledFromFloor = calledFromFloor,
            DestinationFloor = destinationFloor
        };

        Trips.AddFrom(call);
    }
}