using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _09_02_20_Homework_BlogLesson42_Threads_lock_Console
{
    class Program
    {
        static private ThreadExecutor<Thread> _currentExecutor = new ThreadExecutor<Thread>();
        static private ConcurrentQueueThreadExecutor<Thread> _currentConcurrent = new ConcurrentQueueThreadExecutor<Thread>();
        static void Main(string[] args)
        {           
            _currentExecutor.Add(new Thread(PrintRandomString));
            _currentExecutor.Add(new Thread(PrintHelloWorld));
            _currentExecutor.Add(new Thread(CountUntilNumber));
            _currentExecutor.Add(new Thread(PrintTriangle));


            ThreadPool.QueueUserWorkItem(new WaitCallback(PrintRandomString));
            ThreadPool.QueueUserWorkItem(new WaitCallback(PrintHelloWorld));
            ThreadPool.QueueUserWorkItem(new WaitCallback(CountUntilNumber));
            ThreadPool.QueueUserWorkItem(new WaitCallback(PrintTriangle));

            /*_currentConcurrent.Add(new Thread(PrintRandomString));
            _currentConcurrent.Add(new Thread(PrintHelloWorld));
            _currentConcurrent.Add(new Thread(CountUntilNumber));
            _currentConcurrent.Add(new Thread(PrintTriangle));*/
           

            //_currentExecutor.Execute();







            Console.Read();
        }

        static private void PrintRandomString(object o)
        {
            Console.WriteLine(Statics.GetUniqueKeyOriginal_BIASED(new Random().Next(0, 20)));
        }
        static private void PrintHelloWorld(object o)
        {
            Console.WriteLine("Hello, World\n\n");
        }
        static private void CountUntilNumber(object o)
        {
            int n = 20;
            if ((int)n < 0) Math.Abs((int)n);
            for(int i = 0; i < (int)n; i++)
            {
                Console.WriteLine("The number: "+i);
            }
            Console.WriteLine("\n");
        }
        static private void PrintTriangle(object o)
        {
            int n = 40;           
            for(int i = 0; i < n; i++)
            {
                if (i % 2 != 0)
                {
                    
                    Console.WriteLine(new String('*', i).PadLeft(Math.Abs((i-1+50)/2)));
                }
            }
            Console.WriteLine("\n");
        }

    }
}
