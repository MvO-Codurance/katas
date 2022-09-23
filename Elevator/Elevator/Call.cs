namespace Elevator;

public record struct Call(Floor CalledFromFloor, Floor DestinationFloor);