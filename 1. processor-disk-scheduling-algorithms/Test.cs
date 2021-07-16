using System;
using System.Collections.Generic;
using System.Text;

class Test
{

    int[] outputs = new int[6];

    public Test(int fcfs, int sstf, int scan, int cscan, int edf, int fdscan)
    {
        this.outputs[0] = fcfs;
        this.outputs[1] = sstf;
        this.outputs[2] = scan;
        this.outputs[3] = cscan;
        this.outputs[4] = edf;
        this.outputs[5] = fdscan;

    }

    public int[] getOutput()
    {
        return this.outputs;
    }

    public String returnData()
    {
        return $"{this.outputs[0]}, {this.outputs[1]}, {this.outputs[2]}, {this.outputs[3]}, {this.outputs[4]}, {this.outputs[5]}";
    }
}