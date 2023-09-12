using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SynchronizationContext uiContext;
        private List<ProgressBar> progressBars;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            uiContext = SynchronizationContext.Current;
            progressBars = new List<ProgressBar> { progressBar1, progressBar2, progressBar3, progressBar4, progressBar5 };
        }
        private void UpdateProgressBar(ProgressBar progressBar, int value)
        {
            uiContext.Send(d => progressBar.Value = (int)d, value);
        }
        private void EnableButton(bool enabled)
        {
            uiContext.Send(d => button1.Enabled = enabled, null);
        }
        private void ThreadFunk()
        {
            foreach (var progressBar in progressBars)
            {
                uiContext.Send(d => progressBar.Minimum = 0, null);
                uiContext.Send(d => progressBar.Maximum = 230, null);
                uiContext.Send(d => progressBar.Value = 0, null);
                uiContext.Send(d => progressBar.ForeColor = Color.FromArgb(255, 0, 0), null);
                uiContext.Send(d => progressBar.BackColor = Color.FromArgb(150, 0, 0), null);
            }

            EnableButton(false);

            int[] progressValues = new int[progressBars.Count];

            for (int i = 0; i < 230; i++)
            {
                for (int j = 0; j < progressBars.Count; j++)
                {
                    progressValues[j] += random.Next(0, 10);
                    UpdateProgressBar(progressBars[j], progressValues[j]);
                    Thread.Sleep(10);
                }
            }

            int winnerIndex = Array.IndexOf(progressValues, progressValues.Max());
            EnableButton(true);
            MessageBox.Show($"ProgressBar {winnerIndex + 1} won the race!");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ThreadStart methodThread = new ThreadStart(ThreadFunk);
            Thread thread = new Thread(methodThread);
            thread.Start();
        }
    }
}
