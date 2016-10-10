using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadsAndTasks
{
    public delegate void MethodDelegate();
    public class MyThread
    {
        ManualResetEvent manualReset;
        public Thread MyThreadOne;
        public MyThread(ManualResetEvent myEvent)
        {
            //MyThreadOne = new Thread();
            
        }
    }
}
