namespace MarsRover;

public class Compass
{
    public CompassHeading Heading { get; private set; }

    public Compass(CompassHeading initialHeading)
    {
        Heading = initialHeading;
    }

    public CompassHeading TurnLeft()
    {
        switch (Heading)
        {
            case CompassHeading.N:
                Heading = CompassHeading.W;
                break;
            case CompassHeading.W:
                Heading = CompassHeading.S;
                break;
            case CompassHeading.S:
                Heading = CompassHeading.E;
                break;
            case CompassHeading.E:
                Heading = CompassHeading.N;
                break;
        }

        return Heading;
    }

    public CompassHeading TurnRight()
    {
        switch (Heading)
        {
            case CompassHeading.N:
                Heading = CompassHeading.E;
                break;
            case CompassHeading.E:
                Heading = CompassHeading.S;
                break;
            case CompassHeading.S:
                Heading = CompassHeading.W;
                break;
            case CompassHeading.W:
                Heading = CompassHeading.N;
                break;
        }

        return Heading;
    }
}