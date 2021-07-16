using System;
using System.Collections.Generic;
using System.Text;

class SSTF
{
    List<Request> data = new List<Request>();
    int currentHeadPos = 1;

    public SSTF(List<Request> disks)
    {
        this.data = disks;
    }

    public int Run()
    {
        int elapsedTime = 0;
        Request temp = data[0];

        while (this.data.Count > 0)
        {
            temp = this.findShortestSeekTime(elapsedTime);
            elapsedTime += Math.Abs(temp.idx - this.currentHeadPos);
            currentHeadPos = temp.idx;
            this.data.Remove(temp);

        }
        return elapsedTime;
    }

    private Request findShortestSeekTime(int elapsedTime)
    {
        Request min = data[0];
        foreach (Request r in data)
        {
            if (r.arrival <= elapsedTime && Math.Abs(r.idx - currentHeadPos) < Math.Abs(min.idx - currentHeadPos)) min = r;
        }

        return min;
    }

}
