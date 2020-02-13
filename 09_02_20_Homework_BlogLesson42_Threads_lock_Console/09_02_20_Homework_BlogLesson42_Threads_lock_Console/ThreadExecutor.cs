using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace _09_02_20_Homework_BlogLesson42_Threads_lock_Console
{
    class ThreadExecutor<T> where T : class
    {
        private Queue<T> _queue = new System.Collections.Generic.Queue<T>();
        private System.Timers.Timer _timer = new System.Timers.Timer();

        public ThreadExecutor()
        {
            _timer.Enabled = true;
            _timer.Interval = 1000;
            Thread th = new Thread(() => 
                {
                    int count = 0;
                    _timer.Elapsed += (object sender, ElapsedEventArgs e) => 
                        {
                            if (_queue.Count > 0) this.Execute();

                            Console.WriteLine($"count: {count}");
                            count++;
                        };
                    _timer.Start();
                });
            
            th.Name = "WakingUpThread";
            th.Start();
        }


        public void Add(T thread)
        {
            lock (this)
            {
                _queue.Enqueue(thread);
            }
        }

        public void Execute()
        {
            while (_queue.Count > 0)
            {
                lock(this)
                {
                    T thread = _queue.Dequeue();
                    if(thread is Thread)
                    {
                        (thread as Thread).Start();
                        //(thread as Thread).Join();
                    }
                }
            }
        }
    }
}
