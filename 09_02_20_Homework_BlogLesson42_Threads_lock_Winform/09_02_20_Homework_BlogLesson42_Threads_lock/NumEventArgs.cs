using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_02_20_Homework_BlogLesson42_Threads_lock
{
    class NumEventArgs : EventArgs
    { 
        public int Number { get; set; }
        public string NumString { get; set; }
    }
}
