using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace _09_02_20_Homework_BlogLesson42_Threads_lock_Console
{
    class ConcurrentQueueThreadExecutor<T> where T : class
    {
        private ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();
        private System.Timers.Timer _timer = new System.Timers.Timer();

        public ConcurrentQueueThreadExecutor()
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
            _queue.Enqueue(thread);            
        }

        public void Execute()
        {
            while (_queue.Count > 0)
            {
                lock(this)
                {
                    _queue.TryDequeue(out T thread);
                    if(thread is Thread)
                    {
                        (thread as Thread).Start();
                        (thread as Thread).Join();
                    }
                }
            }
        }
    }
}
