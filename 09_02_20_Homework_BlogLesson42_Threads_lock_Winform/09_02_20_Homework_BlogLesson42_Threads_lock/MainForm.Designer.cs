namespace _09_02_20_Homework_BlogLesson42_Threads_lock
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlWorkingArea = new System.Windows.Forms.Panel();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnAddThreadsForTicks = new System.Windows.Forms.Button();
            this.lblShowTicks = new System.Windows.Forms.Label();
            this.btmClearTheArea = new System.Windows.Forms.Button();
            this.btnStopStartTicking = new System.Windows.Forms.Button();
            this.btnJoin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlWorkingArea
            // 
            this.pnlWorkingArea.Location = new System.Drawing.Point(251, 12);
            this.pnlWorkingArea.Name = "pnlWorkingArea";
            this.pnlWorkingArea.Size = new System.Drawing.Size(537, 426);
            this.pnlWorkingArea.TabIndex = 0;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(23, 70);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(93, 26);
            this.btnExecute.TabIndex = 1;
            this.btnExecute.Text = "Execute Now";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnAddThreadsForTicks
            // 
            this.btnAddThreadsForTicks.Location = new System.Drawing.Point(23, 26);
            this.btnAddThreadsForTicks.Name = "btnAddThreadsForTicks";
            this.btnAddThreadsForTicks.Size = new System.Drawing.Size(93, 26);
            this.btnAddThreadsForTicks.TabIndex = 2;
            this.btnAddThreadsForTicks.Text = "Add threads =>";
            this.btnAddThreadsForTicks.UseVisualStyleBackColor = true;
            this.btnAddThreadsForTicks.Click += new System.EventHandler(this.btnAddThreads_Click);
            // 
            // lblShowTicks
            // 
            this.lblShowTicks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShowTicks.Location = new System.Drawing.Point(142, 72);
            this.lblShowTicks.Name = "lblShowTicks";
            this.lblShowTicks.Size = new System.Drawing.Size(66, 22);
            this.lblShowTicks.TabIndex = 3;
            this.lblShowTicks.Text = "label1";
            this.lblShowTicks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btmClearTheArea
            // 
            this.btmClearTheArea.Location = new System.Drawing.Point(23, 124);
            this.btmClearTheArea.Name = "btmClearTheArea";
            this.btmClearTheArea.Size = new System.Drawing.Size(93, 23);
            this.btmClearTheArea.TabIndex = 5;
            this.btmClearTheArea.Text = "Clear the area";
            this.btmClearTheArea.UseVisualStyleBackColor = true;
            this.btmClearTheArea.Click += new System.EventHandler(this.btmClearTheArea_Click);
            // 
            // btnStopStartTicking
            // 
            this.btnStopStartTicking.Location = new System.Drawing.Point(142, 124);
            this.btnStopStartTicking.Name = "btnStopStartTicking";
            this.btnStopStartTicking.Size = new System.Drawing.Size(75, 23);
            this.btnStopStartTicking.TabIndex = 6;
            this.btnStopStartTicking.Text = "Stop ticking";
            this.btnStopStartTicking.UseVisualStyleBackColor = true;
            this.btnStopStartTicking.Click += new System.EventHandler(this.btnStopStartTicking_Click);
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(13, 242);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(121, 23);
            this.btnJoin.TabIndex = 7;
            this.btnJoin.Text = "Join to a new thread";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.btnStopStartTicking);
            this.Controls.Add(this.btmClearTheArea);
            this.Controls.Add(this.lblShowTicks);
            this.Controls.Add(this.btnAddThreadsForTicks);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.pnlWorkingArea);
            this.Name = "MainForm";
            this.Text = "09_02_20_Homework_BlogLesson42_Threads_lock";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWorkingArea;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnAddThreadsForTicks;
        private System.Windows.Forms.Label lblShowTicks;
        private System.Windows.Forms.Button btmClearTheArea;
        private System.Windows.Forms.Button btnStopStartTicking;
        private System.Windows.Forms.Button btnJoin;
    }
}

