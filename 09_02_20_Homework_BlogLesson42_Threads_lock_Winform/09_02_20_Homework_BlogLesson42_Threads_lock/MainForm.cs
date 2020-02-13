using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09_02_20_Homework_BlogLesson42_Threads_lock
{
    public partial class MainForm : Form
    {
        private Random _rnd = new Random();

        private ThreadExecutor<Thread> _executioner = new ThreadExecutor<Thread>();        
        private const int THREADS_NUMBER = 10;        
        public MainForm()
        {
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            btnJoin.AutoSize = true;
            
            _executioner.ExportNum += (object sender, NumEventArgs e) => { lblShowTicks.Text = e.NumString; };            
            _executioner.JoinEvent += (object sender, NumEventArgs e) => 
            {
                if(btnJoin.InvokeRequired)
                {
                    btnJoin.Invoke((Action)delegate { btnJoin.Text = e.NumString; });
                }
                else btnJoin.Text = e.NumString; 
            };



            lblShowTicks.Text = string.Empty;
            pnlWorkingArea.drawBorder(4, Color.Black);
            //lblShowTicks.drawBorder(1, Color.Black);
        }

        private void Prepare(int n)
        {
            for(int i = 0; i < n; i++)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(PrintRectangleThreadWorker));
                this._executioner.Add(thread);
            }
        }

        private void PrintRectangleThreadWorker(Object objColor)
        {
            var color = (Color)objColor;
            int width = _rnd.Next(10, pnlWorkingArea.Width - (pnlWorkingArea.Width - 100));
            int height = _rnd.Next(10, pnlWorkingArea.Height - (pnlWorkingArea.Height - 100));

            PictureBox pbx = new PictureBox();
            pbx.Width = width;
            pbx.Height = height;
            pbx.Location = new Point(_rnd.Next(5, pnlWorkingArea.Width - width - 5), _rnd.Next(5, pnlWorkingArea.Height - height - 5));

            
            Bitmap btmp = new Bitmap(pbx.Width, pbx.Height);
            Graphics graphicProvider = Graphics.FromImage(btmp);

            SolidBrush sb = new SolidBrush(color);
            graphicProvider.FillRectangle(sb, 0, 0, pbx.Width, pbx.Height);
            graphicProvider.Dispose();

            pbx.Image = btmp;

            if(pnlWorkingArea.InvokeRequired)
            {
                pnlWorkingArea.Invoke((Action)delegate { pnlWorkingArea.Controls.Add(pbx); });
            }
            else pnlWorkingArea.Controls.Add(pbx);
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            _executioner.Execute();
        }

        private void btnAddThreads_Click(object sender, EventArgs e)
        {
            Prepare(THREADS_NUMBER);
        }

        private void btmClearTheArea_Click(object sender, EventArgs e)
        {
            pnlWorkingArea.Controls.Clear();
        }

        private void btnAddThreadsForButtonPress_Click(object sender, EventArgs e)
        {
            Prepare(THREADS_NUMBER);
        }

        private void btnStopStartTicking_Click(object sender, EventArgs e)
        {
            var r = _executioner.TimerSwitch;
            if (_executioner.TimerSwitch)
            {
                _executioner.TimerSwitch = false;
                (sender as Button).Text = "Stop ticking";
            }
            else 
            {
                _executioner.TimerSwitch = true;
                (sender as Button).Text = "Start ticking"; 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _executioner.JoinToTickingThread();
        }
    }
}
