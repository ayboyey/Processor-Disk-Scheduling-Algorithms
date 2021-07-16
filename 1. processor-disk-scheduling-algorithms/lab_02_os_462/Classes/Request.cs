using System;
using System.Collections.Generic;
using System.Text;

class Request : IComparable<Request>
{

    public int idx;
    public int arrival;
    int deadLine;


    public Request(int idx, int arrival)
    {
        this.idx = idx;
        this.arrival = arrival;

    }

    public int CompareTo(Request obj)
    {
        return (this.idx.CompareTo(obj.idx));
    }

    public void setDeadLine(int time)
    {
        this.deadLine = time;
    }

    public int getDeadLine()
    {
        return this.deadLine;
    }
}
