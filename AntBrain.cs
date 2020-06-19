using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;


public static class AntBrain
{
    static Direct.Direction goal = Direct.Direction.Down;
    static bool set = false;

    public static void MoveAntToGoal(AntMemory ant)
    {

        var bestDirections = PointHelper.BestDirectionFrom(ant.Location, ant.LastDestination);
        if (AccessiblePointsFrom(PointHelper.PointsFromDirection(ant.Location, Direct.FullDirectionCircle.list)).Count < 8)
            ant.directionsToIgnore.Add((10, bestDirections[0]));
            
        FilterOutDirectionsToIgnore(bestDirections, ant);
        var possibleMoves = AccessiblePointsFrom(PointHelper.PointsFromDirection(ant.Location, bestDirections));
        
        if (possibleMoves.Any())
        {
           
            MoveAntToPoint(ant, possibleMoves[0]);
        }
    }
    static void FilterOutDirectionsToIgnore(List<Direct.Direction> filterFor, AntMemory filterFrom)
    {
        for(int i=filterFrom.directionsToIgnore.Count-1; i>= 0; i--)
        {
            //remove old ignore and decrement non-old ignore
            if (filterFrom.directionsToIgnore[i].Item1 <= 0)
            {
                filterFrom.directionsToIgnore.RemoveAt(i);
            }
            else
            {
                filterFrom.directionsToIgnore[i] = (filterFrom.directionsToIgnore[i].Item1 - 1, filterFrom.directionsToIgnore[i].Item2);
                //filter out the ones we want to ignore
                var xd = filterFor.Where(x => x == filterFrom.directionsToIgnore[i].Item2).ToList();
                if (xd.Any())
                    filterFor.Remove(xd[0]);
            }

           
        }
    }
    static void MoveAntInDirection(AntMemory ant, Direct.Direction direction)
    {
        Map.AddGroundAt(ant.Location);
        ant.Location = PointHelper.PointInDirection(ant.Location, direction);
        Map.AddAntAt(ant.Location);
    }

    static void MoveAntToPoint(AntMemory ant, Point point)
    {
        Map.AddGroundAt(ant.Location);
        ant.Location = point;
        Map.AddAntAt(ant.Location);
    }

    public static List<Point> AccessiblePointsFrom(List<Point> FilterFrom) => FilterFrom.Where(Map.PointIsAccessible).ToList();



}
