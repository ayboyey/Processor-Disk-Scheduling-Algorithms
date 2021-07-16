using System;
using System.Collections.Generic;
using System.Text;

class SCAN
{
    List<Request> data = new List<Request>();
    int currentHeadPos = 1;
    bool down = true;

    public SCAN(List<Request> disks)
    {
        this.data = disks;
    }

    public int Run()
    {
        int elapsedTime = 0;

        while (this.data.Count > 0)
        {
            if (this.hasRequestAt(this.currentHeadPos, elapsedTime)) this.data.Remove(atIndex(this.currentHeadPos));
            elapsedTime += 1;
            this.Next();
        }

        return elapsedTime;
    }

    private bool hasRequestAt(int idx, int elapsedTime)
    {
        foreach (Request r in this.data) if (r.idx == idx && r.arrival <= elapsedTime) return true;
        return false;
    }

    private Request atIndex(int idx)
    {
        foreach (Request r in this.data) if (r.idx == idx) return r;
        return null;
    }

    private void Next()
    {
        if (this.currentHeadPos == 16 && this.down == true) this.down = false;

        if (this.currentHeadPos == 1 && this.down == false) this.down = true;

        if (this.down == true)
        {
            this.currentHeadPos += 1;
            return;
        }

        if (this.down == false)
        {
            this.currentHeadPos -= 1;
            return;
        }

    }

}
