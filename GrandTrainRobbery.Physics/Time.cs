using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandTrainRobbery.Physics
{
    public class Stopper
    {
        int t;
        static object locker=new object();
        public Stopper()
        {
            t = 0;
            new Task(()=>
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(1000);
                    lock(locker)
                        t++;
                }
            },TaskCreationOptions.LongRunning).Start();
        }
        public void Reset()
        {
            lock (locker)
                t = 1;
        }
        public int Seconds()
        {
            return t;
        }
    }
}
