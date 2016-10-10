using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace ThreadsAndTasks
{
    class Program
    {
        public static Semaphore Bounser { get; set; }
        public static ManualResetEvent mrs = new ManualResetEvent(false);
        public static ManualResetEvent mrs1 = new ManualResetEvent(false);
        public static ManualResetEvent mrs2 = new ManualResetEvent(false);
        public static ManualResetEvent mrs3 = new ManualResetEvent(false);
        public static ManualResetEvent mrs4 = new ManualResetEvent(false);
        public static ManualResetEvent mrs5 = new ManualResetEvent(false);
        private static object threadLock = new object();

        static void Main(string[] args)
        {
            Bounser = new Semaphore(1, 1);

            ExecuteInThread();
            ExecuteInTask();

            Console.ReadLine();
        }

        static void ExecuteInThread()
        {
            
            Thread talk = new Thread(Talk);
            talk.Start();
            mrs.WaitOne();

            Thread Is = new Thread(Iss);
            Is.Start();
            mrs1.WaitOne();

            Thread cheap = new Thread(Cheap);
            cheap.Start();
            mrs2.WaitOne();

            Thread show = new Thread(Show);
            show.Start();
            mrs3.WaitOne();

            Thread me = new Thread(Me);
            me.Start();
            mrs4.WaitOne();

            Thread the = new Thread(The);
            the.Start();
            mrs5.WaitOne();

            Thread code = new Thread(Code);
            code.Start();
            Thread.Sleep(500);
        }

        static void ExecuteInTask()
        {
            Task first = new Task(Talk);
            Task second = new Task(Iss);
            Task third = new Task(Cheap);
            Task fourth = new Task(Show);
            Task fifth = new Task(Me);
            Task sixth = new Task(The);
            Task seventh = new Task(Code);

            first.Start();
            first.ContinueWith((Task) => second.Start());
            second.ContinueWith((Task) => third.Start());
            third.ContinueWith((Task) => fourth.Start());
            fourth.ContinueWith((Task) => fifth.Start());
            fifth.ContinueWith((Task) => sixth.Start());
            sixth.ContinueWith((Task) => seventh.Start());
        }
        static void Talk()
        {
            Console.Write("Talk ");
            mrs.Set();
        }
        static void Iss()
        {
            mrs.Reset();
            Console.Write("is ");
            mrs1.Set();
        }
        static void Cheap()
        {
            mrs1.Reset();
            Console.Write("cheap. ");
            mrs2.Set();
        }
        static void Show()
        {
            mrs2.Reset();
            Console.Write("Show ");
            mrs3.Set();

        }
        static void Me()
        {
            mrs3.Reset();
            Console.Write("me ");
            mrs4.Set();
        }
        static void The()
        {
            mrs4.Reset();
            Console.Write("the ");
            mrs5.Set();
        }
        static void Code()
        {
            mrs5.Reset();
            Console.Write("code.\n");
        }
    }
}
