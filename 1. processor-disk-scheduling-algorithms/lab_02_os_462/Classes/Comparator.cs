using System;
using System.Collections.Generic;
using System.Text;

enum SortOrd
{
    ArrivalTime,
    Position
}


class Comparator : IComparer<Request>
{
    SortOrd sort;

    public Comparator(SortOrd arg)
    {
        this.sort = arg;
    }

    public int Compare(Request obj1, Request obj2)
    {
        switch (this.sort)
        {
            case SortOrd.ArrivalTime:
                return obj1.arrival.CompareTo(obj2.arrival);
        }
        return 0;
    }
}
