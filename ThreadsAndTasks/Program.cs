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
            Thread thread = new Thread(() => Console.Write("Talk "));
            thread.Start();
            //Console.Write("Talk ");
            mrs.Set();
        }
        static void Iss()
        {
            Thread thread = new Thread(() => Console.Write("is "));
            thread.Start();          
        }
        static void Cheap()
        {
            Thread thread = new Thread(() => Console.Write("cheap. "));
            thread.Start();           
        }
        static void Show()
        {
            Thread thread = new Thread(() => Console.Write("Show "));
            thread.Start();
        }
        static void Me()
        {
            Thread thread = new Thread(() => Console.Write("me "));
            thread.Start();
        }
        static void The()
        {
            Thread thread = new Thread(() => Console.Write("the "));
            thread.Start();
        }
        static void Code()
        {
            Thread thread = new Thread(() => Console.Write("code.\n"));
            thread.Start();
        }
    }
}
