using System;
using System.Collections;
using System.Collections.Generic;


public static class FoodPileGenerator
{
    const int totalFood = 60;
    public static void GenerateFoodPileAt(Point start)
    {
        int radius = (int)Math.Ceiling(Math.Sqrt(totalFood / Math.PI));


        var pointsToAdd = PointHelper.PointsInDistanceAround(start, radius);

        for (var i = 0; i < totalFood; i++)
        {
            if(pointsToAdd.Count == 0)
            {
                Console.WriteLine("fuck");
                break;
            }
            var selected = ListHelper.RandomElementInList(pointsToAdd);
            pointsToAdd.Remove(selected);
            Map.AddFoodAt(selected);
        }
    }
}
