using System.Collections;
using System.Collections.Generic;
using System.Linq;


public static class Direct
{
    public static Point LeftPoint = new Point(-1, 0);
    public static Point UpPoint = new Point(0, 1);
    public static Point RightPoint = new Point(1, 0);
    public static Point DownPoint = new Point(0, -1);
    public static Point UpLeftPoint = new Point(-1, 1);
    public static Point UpRightPoint = new Point(1, 1);
    public static Point DownRightPoint = new Point(1, -1);
    public static Point DownLeftPoint = new Point(-1, -1);


    public static CirclularList<Direction> FullDirectionCircle = new CirclularList<Direction>()
    {
        list = new List<Direction>()
    {
        Direction.Up,
        Direction.UpRight,
        Direction.Right,
        Direction.DownRight,
        Direction.Down,
        Direction.DownLeft,
        Direction.Left,
        Direction.UpLeft
    }
    };
    public static CirclularList<Direction> CardinalDirectionCircle = new CirclularList<Direction>()
    {
        list = new List<Direction>()
    {
        Direction.Up,
        Direction.Right,
        Direction.Down,
        Direction.Left,
    }
    };

    public static Dictionary<Direction, Point> DirectionPointMap = new Dictionary<Direction, Point>()
    {
        { Direction.Left, LeftPoint },
        { Direction.Up, UpPoint },
        { Direction.Right, RightPoint },
        { Direction.Down, DownPoint },
        { Direction.UpLeft, UpLeftPoint },
        { Direction.UpRight, UpRightPoint },
        { Direction.DownRight, DownRightPoint },
        { Direction.DownLeft, DownLeftPoint }
    };

    public enum Direction
    {
        Left,
        Up,
        Right,
        Down,
        UpLeft,
        UpRight,
        DownRight,
        DownLeft
    };

    public static List<Direction> FullNeighborsOfWith(Direction getFor) => new List<Direction>()
    {
        getFor,
        FullDirectionCircle.ClockwiseNeighborOf(getFor),
        FullDirectionCircle.CounterClockwiseNeighborOf(getFor),
    };
    public static List<Direction> CardinalNeighborsOfWith(Direction getFor) => new List<Direction>()
    {
        getFor,
        CardinalDirectionCircle.ClockwiseNeighborOf(getFor),
        CardinalDirectionCircle.CounterClockwiseNeighborOf(getFor),
    };
    public static List<Direction> FullNeighborsOfWithout(Direction getFor) => new List<Direction>()
    {
        FullDirectionCircle.ClockwiseNeighborOf(getFor),
        FullDirectionCircle.CounterClockwiseNeighborOf(getFor),
    };
    public static List<Direction> CardinalNeighborsOfWithout(Direction getFor) => new List<Direction>()
    {
        CardinalDirectionCircle.ClockwiseNeighborOf(getFor),
        CardinalDirectionCircle.CounterClockwiseNeighborOf(getFor),
    };
    public static Direction RandomFullDirection() => ListHelper.RandomElementInList(FullDirectionCircle.list);
    public static Direction RandomCardinalDirection() => ListHelper.RandomElementInList(CardinalDirectionCircle.list);




}
