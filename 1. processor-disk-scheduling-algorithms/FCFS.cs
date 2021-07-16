using System;
using System.Collections.Generic;
using System.Text;

public class FCFS
{
    List<Request> data = new List<Request>();
    int currentHeadPos = 1;

    public FCFS(List<Request> disks)
    {
        this.data = disks;
    }

    public int Run()
    {
        int elapsedTime = 0;

        while (this.data.Count > 0)
        {
            elapsedTime += Math.Abs(this.data[0].idx - this.currentHeadPos);
            this.currentHeadPos = this.data[0].idx;
            this.data.Remove(this.data[0]);
        }

        return elapsedTime;
    }
}
