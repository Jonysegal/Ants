using System.Collections;
using System.Collections.Generic;


public class AntMemory
{
    public Point LastDestination;

    public Point Location;

    public List<(int, Direct.Direction)> directionsToIgnore = new List<(int, Direct.Direction)>();
}
