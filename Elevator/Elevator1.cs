namespace Elevator;

public class Elevator1
{
    private List<Floor> _doorsOpenOnFloor = new();
    
    public string Call(Floor calledFromFloor, Floor goToFloor)
    {
        _doorsOpenOnFloor.Add(calledFromFloor);
        _doorsOpenOnFloor.Add(goToFloor);

        return string.Join(string.Empty, _doorsOpenOnFloor.Select(x => (char)x));
    }
}