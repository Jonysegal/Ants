using System.Collections;
using System.Collections.Generic;


public static class ListHelper
{
    public static T RandomElementInList<T>(List<T> getFrom) => getFrom[RandomHelper.IntInRange(0, getFrom.Count)];

    public static T FirstElementOf<T>(List<T> getFrom) => getFrom[0];

    public static T LastElementOf<T>(List<T> getFrom) => getFrom[getFrom.Count-1];
}
