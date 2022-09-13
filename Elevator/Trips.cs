using System.Text;

namespace Elevator;

public class Trips
{
    private Floor _currentFloor;
    private List<Trip> _tripList;

    public Trips(Floor startingFloor)
    {
        _currentFloor = startingFloor;
        _tripList = new List<Trip>();
    }

    public Trip AddFrom(Call call)
    {
        var trip = new Trip(_currentFloor, call);
        _tripList.Add(trip);

        _currentFloor = call.DestinationFloor;
        
        return trip;
    }
    
    public string DoorsOpenedOnFloors()
    {
        var sb = new StringBuilder();
        foreach (var trip in _tripList)
        {
            sb.Append(trip.DoorsOpenedOnFloors);
        }

        return sb.ToString();
    }

    public int TimeTaken()
    {
        return _tripList.Sum(trip => trip.TimeTaken);
    }
}