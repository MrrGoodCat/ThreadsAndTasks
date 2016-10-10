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
        public static ManualResetEvent mrs;
        private static object threadLock = new object();

        static void Main(string[] args)
        {
            Bounser = new Semaphore(1, 1);

            ExecuteInThread();
            ExecuteInTask();


            //Task first = Task.Run(() => Talk());
            //Task second = first.ContinueWith((Task) => Iss());
            //Task third = second.ContinueWith((Task) => Cheap());
            //Task fourth = third.ContinueWith((Task) => Show());
            //Task fifth = fourth.ContinueWith((Task) => Me());
            //Task sixth = fifth.ContinueWith((Task) => The());
            //Task seventh = sixth.ContinueWith((Task) => Code());


            Console.ReadLine();
        }

        static void ExecuteInThread()
        {
            Thread talk = new Thread(Talk);
            talk.Start();
            Thread Is = new Thread(Iss);
            Is.Start();
            Thread cheap = new Thread(Cheap);
            cheap.Start();
            Thread show = new Thread(Show);
            show.Start();
            Thread me = new Thread(Me);
            me.Start();
            Thread the = new Thread(The);
            the.Start();
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
            lock (threadLock)
            {
                Console.Write("Talk ");
            }
            //Thread thread = new Thread(() => Console.Write("Talk "));
            //thread.Start();

            //mrs.Set();
        }
        static void Iss()
        {
            lock (threadLock)
            {
                Console.Write("is ");
            }
            //Thread thread = new Thread(() => Console.Write("is "));
            //thread.Start();

        }
        static void Cheap()
        {
            lock (threadLock)
            {
                Console.Write("cheap. ");
            }
            //Thread thread = new Thread(() => Console.Write("cheap. "));
            //thread.Start();

        }
        static void Show()
        {
            lock (threadLock)
            {
                Console.Write("Show ");
            }
            //Thread thread = new Thread(() => Console.Write("Show "));
            //thread.Start();

        }
        static void Me()
        {
            lock (threadLock)
            {
                Console.Write("me ");
            }
            //Thread thread = new Thread(() => Console.Write("me "));
            //thread.Start();

        }
        static void The()
        {
            lock (threadLock)
            {
                Console.Write("the ");
            }
            //Thread thread = new Thread(() => Console.Write("the "));
            //thread.Start();

        }
        static void Code()
        {
            lock (threadLock)
            {
                Console.Write("code.\n");
            }
            //Thread thread = new Thread(() => Console.Write("code.\n"));
            //thread.Start();

        }
    }
}
