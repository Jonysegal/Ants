using System.Collections;
using System.Collections.Generic;


public static class MathHelper
{
    public static bool RandomChance(double chance) => RandomHelper.NextDouble() <= chance;
}
