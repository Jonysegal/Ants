using System;

public static class RandomHelper
{
    static Random rand = new Random();
    public static int IntInRange(int minInc, int maxEx) => rand.Next(minInc, maxEx);

    public static double NextDouble() => rand.NextDouble();
}