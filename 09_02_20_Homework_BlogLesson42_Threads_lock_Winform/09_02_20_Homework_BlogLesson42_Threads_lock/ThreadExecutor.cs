using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Diagnostics.Runtime;

namespace _09_02_20_Homework_BlogLesson42_Threads_lock
{
    class ThreadExecutor<T> where T : class
    {
        private Thread _globalThread;

        private bool _timerSwitch = true;
        public bool TimerSwitch
        {
            set 
            {
                _timerSwitch = value;
                if (_timerSwitch) _timer.Stop();
                else _timer.Start();
            }
            get => _timerSwitch;
        }

        private Queue<T> _queue = new System.Collections.Generic.Queue<T>();
        private Random _rnd = new Random();
        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        public event EventHandler<NumEventArgs> ExportNum;

        public event EventHandler<NumEventArgs> JoinEvent;

        public ThreadExecutor()
        {
            this.TimerSwitch = true;
            _timer.Enabled = true;
            _timer.Interval = 1000;
            int count = 0;

            System.Windows.Forms.Timer inThreadTimer = new System.Windows.Forms.Timer();
            inThreadTimer.Enabled = true;
            inThreadTimer.Interval = 10;

            
            _globalThread = new Thread(() => 
                {
                    _timer.Tick += (object sender, EventArgs e) => 
                        {
                            count++;
                            string countStr = count.ToString();
                            if (count == 5) countStr = $"{count}: Execute";
                            ExportNum?.Invoke(this, new NumEventArgs { NumString = countStr });
                            if (_queue.Count > 0 && count == 5)
                            {
                                Execute();                                
                            }
                            if (count == 5) count = 0;
                        };                                     
                });
            _globalThread.Name = "TickingThread";
            _globalThread.Start();
        }


        public void Add(T something)
        {
            lock (this)
            {
                _queue.Enqueue(something);
            }
        }

        public void Execute()
        {
            lock (this)
            {
                while (_queue.Count > 0)
                {
                    var thread = _queue.Dequeue();
                    if (thread is Thread && (thread as Thread).ThreadState == System.Threading.ThreadState.Unstarted)
                    {
                        (thread as Thread).Start(GenerateColor());
                        //(thread as Thread).Join();
                    }
                }


            }
        }

        public void JoinToTickingThread()
        {

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Enabled = true;
            timer.Interval = 1000;

            Thread thread = new Thread(() =>
                {
                    

                    JoinEvent?.Invoke(this, new NumEventArgs { NumString = Thread.CurrentThread.Name });
                    foreach(var s in _queue)
                    {
                        if (s is Thread && (s as Thread).ThreadState == System.Threading.ThreadState.Unstarted)
                        {
                            (s as Thread).Start(GenerateColor());
                            (s as Thread).Join();

                        }
                    }
                    
                    Thread.Sleep(1000);
                    JoinEvent?.Invoke(this, new NumEventArgs { NumString = Thread.CurrentThread.ThreadState.ToString() });
                    int count = 0;
                    timer.Tick += (object sender, EventArgs e) => 
                        {
                            JoinEvent?.Invoke(this, new NumEventArgs { NumString = $"{Thread.CurrentThread.ThreadState}, {count}" });
                            if (count == 10)
                            {
                                timer.Stop();
     
                            }
                            count++;
                        };
                    timer.Start();
                    Thread.CurrentThread.Abort();
                });
            thread.Name = "Super Duper Thread";
            thread.IsBackground = true;
            thread.Start();            
            JoinEvent?.Invoke(this, new NumEventArgs { NumString = $"{thread.ThreadState}, outside the thread" });
            
        }

        private Color GenerateColor()
        {
            var colorNumbers = Enum.GetValues(typeof(KnownColor));
            var clr = (KnownColor)_rnd.Next(0, colorNumbers.Length - 1);
            return Color.FromKnownColor(clr);
        }





    }
}
