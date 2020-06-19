using System;
using System.Collections;
using System.Collections.Generic;


public class CirclularList<T>
{
    public List<T> list;

    public void Add(T toAdd) => list.Add(toAdd);

    public T ClockwiseNeighborOf(T searchFor)
    {
        if (!list.Contains(searchFor))
            return default(T);
        if (IsLastElement(searchFor))
            return ListHelper.FirstElementOf(list);
        return list[list.IndexOf(searchFor) + 1];
    }
    
    public T CounterClockwiseNeighborOf(T searchFor)
    {
        if (!list.Contains(searchFor))
            return default(T);
        if (IsFirstElement(searchFor))
            return ListHelper.LastElementOf(list);
        return list[list.IndexOf(searchFor) - 1];
    }

    public T TraverseFromBy(T start, int by)
    {
        var bySign = (int)Math.Sign(by);
        if(Math.Abs(by) != 1)
        {
            return TraverseFromBy(start, by - bySign);
        }
        else
        {
            if(bySign == 1)
            {
                return ClockwiseNeighborOf(start);
            }
            else
            {
                return CounterClockwiseNeighborOf(start);
            }
        }
    }

    bool IsLastElement(T check) => list.IndexOf(check) == list.Count - 1;
    bool IsFirstElement(T check) => list.IndexOf(check) == 0;

}
