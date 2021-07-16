using System;
using System.Collections.Generic;
using System.Text;

public class EDF
{
    class EDF
    {
        List<Request> data = new List<Request>();
        int currentHeadPos = 1;
        public int test = 0;

        public EDF(List<Request> disks)
        {
            this.data = disks;
            this.generateDeadlines();
        }

        public int Run()
        {
            int elapsedTime = 0;
            Request temp = data[0];

            while (this.data.Count > 0)
            {
                temp = this.findClosestDeadLine(elapsedTime);
                elapsedTime += Math.Abs(temp.idx - this.currentHeadPos);
                currentHeadPos = temp.idx;
                this.data.Remove(temp);
            }
            return elapsedTime;
        }

        private Request findClosestDeadLine(int elapsedTime)
        {
            Request min = data[0];
            foreach (Request r in data)
            {
                if (r.arrival <= elapsedTime && r.getDeadLine() < min.getDeadLine()) min = r;
            }

            return min;
        }

        private void generateDeadlines()
        {
            Random random = new Random();
            foreach (Request r in this.data)
            {
                r.setDeadLine(r.arrival + random.Next(0, 25));
            }
        }

    }
}
