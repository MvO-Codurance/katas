namespace Elevator;

public record struct Call(Floor CalledFromFloor, Floor GoToFloor);