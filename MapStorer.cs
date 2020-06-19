using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;


public static class Map
{
    public const int Min = -500, Max = 500;

    public static Dictionary<Point, Tile.Type> map = new Dictionary<Point, Tile.Type>();

    public static List<Point> ModifiedPoints = new List<Point>();

    public static Dictionary<Tile.Type, List<Point>> listsOfPointsByType = new Dictionary<Tile.Type, List<Point>>()
    {
        {Tile.Type.Ant, new List<Point>() },
        {Tile.Type.AntHill, new List<Point>() },
        {Tile.Type.AntWithFood, new List<Point>() },
        {Tile.Type.Food, new List<Point>() },
        {Tile.Type.Ground, new List<Point>() },
        {Tile.Type.Water, new List<Point>() }
    };

    static void AddTile(Point addTo, Tile.Type toAdd)
    {
        
        listsOfPointsByType[toAdd].Add(addTo);
        map[addTo] = toAdd;
        ModifiedPoints.Add(addTo);
        
    }

    public static Tile.Type TypeOfPoint(Point point)
    {
        foreach(var val in map)
        {
            if (val.Key.Equals(point))
                return val.Value;
        }
        return Tile.Type.Ground;
    }
    public static bool PointIsAccessible(Point point) => Tile.AccessableTypes.Contains(TypeOfPoint(point));

    public static void AddWaterAt(Point at) => AddTile(at, Tile.Type.Water);
    public static void AddGroundAt(Point at) => AddTile(at, Tile.Type.Ground);
    public static void AddFoodAt(Point at) => AddTile(at, Tile.Type.Food);
    public static void AddAntAt(Point at) => AddTile(at, Tile.Type.Ant);
    public static void AddAntHillAt(Point at) => AddTile(at, Tile.Type.AntHill);
    public static void AddAntWithFoodAt(Point at) => AddTile(at, Tile.Type.AntWithFood);

}


public class Point
{
    public int x, y;
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public override bool Equals(object obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        Point compareTo = (Point)obj;
        return compareTo.x == x && compareTo.y == y;
    }
    public override string ToString()
    {
        return "(" + x + ", " + y + ")";
    }
}

public static class PointHelper
{
    public static Point PointOffsetBy(Point p, Point offset) => new Point(p.x + offset.x, p.y + offset.y);

    public static Point PointExbandedBy(Point p, int expandBy) => new Point(p.x * expandBy, p.y * expandBy);

    public static Point PointInDirectionBy(Point point, Direct.Direction direction, int moveBy) => PointOffsetBy(point, PointExbandedBy(Direct.DirectionPointMap[direction], moveBy));

    public static Point PointInDirection(Point point, Direct.Direction direction) => PointInDirectionBy(point, direction, 1);

    public static List<Point> PointsInSquareAround(Point origin, int radius)
    {
        List<Point> toReturn = new List<Point>();

        for(int i = -radius; i <= radius; i++)
        {
            for(int j = -radius; j <= radius; j++)
            {
                toReturn.Add(PointOffsetBy(origin, new Point(i, j)));
            }
        }
        return toReturn;
    }

    public static List<Point> PointsInDistanceAround(Point origin, int radius) => PointsInSquareAround(origin, radius).Where(x => DistanceBetweenPoints(origin, x) <= radius).ToList();
   
    public static double DistanceBetweenPoints(Point a, Point b) => Math.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y));

    public static List<Direct.Direction> BestDirectionFrom(Point a, Point b)
    {
        if (a == b)
        {
            Console.WriteLine("kill me");
            return null;

        }//iterate through all 8 of the directions
         //if ever better than last then worse than next, return that as local max
         //if ever worse on first look, reveres

        List<(double, Direct.Direction)> distancesFromDirections = new List<(double, Direct.Direction)>();
        foreach (var d in Direct.FullDirectionCircle.list)
        {
            int expandBy = 7;
            if (Direct.CardinalDirectionCircle.list.Contains(d))
            {
                expandBy = 10;
            }
            distancesFromDirections.Add((DistanceBetweenPoints(PointOffsetBy(a, PointExbandedBy(Direct.DirectionPointMap[d], expandBy)), b), d));


        }
        distancesFromDirections.Sort((x, y) => x.Item1.CompareTo(y.Item1));
        return distancesFromDirections.Select(x => x.Item2).ToList();
    }

    public static List<Point> PointsFromDirection(Point start, List<Direct.Direction> directions) => directions.Select(x => PointInDirection(start, x)).ToList();


}
