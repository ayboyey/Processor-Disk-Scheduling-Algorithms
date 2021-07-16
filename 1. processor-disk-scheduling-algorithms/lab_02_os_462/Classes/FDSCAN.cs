using System;
using System.Collections.Generic;
using System.Text;


    class FDSCAN
    {
        List<Request> data = new List<Request>();
        int currentHeadPos = 1;
        public int test = 0;
        bool down = true;
            
    public FDSCAN(List<Request> disks, int pos)
        {
            this.data = disks;
            this.generateDeadlines();
            this.currentHeadPos = pos;
    }

        public int Run()
        {
            int elapsedTime = 0;
            Request temp = data[0];

            while (this.data.Count > 0)
            {
                temp = this.findNextValid(elapsedTime);
                elapsedTime += Math.Abs(temp.idx - this.currentHeadPos);
                currentHeadPos = temp.idx;
                this.data.Remove(temp);
            }
            return elapsedTime;
        }

        private Request findNextValid(int elapsedTime)
        {
            Request min = data[0];

            if (this.currentHeadPos == 16 && this.down == true) this.down = false;

            if (this.currentHeadPos == 1 && this.down == false) this.down = true;

            if (this.down == true)
            {
                foreach (Request r in data) if (r.arrival <= elapsedTime && r.getDeadLine() < min.getDeadLine() && this.currentHeadPos < r.idx) min = r;
                return min;
            }

            if (this.down == false)
            {
                foreach (Request r in data) if (r.arrival <= elapsedTime && r.getDeadLine() < min.getDeadLine() && this.currentHeadPos > r.idx) min = r;
                return min;
            }

            return null;
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

