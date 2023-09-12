using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public SynchronizationContext uiContext;
        Thread thread = null;
        public Form1()
        {
            InitializeComponent();

            uiContext = SynchronizationContext.Current;
        }

        private void ThreadFunk()
        {

            uiContext.Send(d => progressBar1.Minimum = 0, null);
            uiContext.Send(d => progressBar1.Maximum = 230, null);
            uiContext.Send(d => progressBar1.Value = 0, null);
            uiContext.Send(d => progressBar1.ForeColor = Color.FromArgb(255, 0, 0), null);
            uiContext.Send(d => progressBar1.BackColor = Color.FromArgb(150, 0, 0), null);
            uiContext.Send(d => button1.Enabled = false, null);

            uiContext.Send(d => progressBar2.Minimum = 0, null);
            uiContext.Send(d => progressBar2.Maximum = 230, null);
            uiContext.Send(d => progressBar2.Value = 0, null);
            uiContext.Send(d => progressBar2.ForeColor = Color.FromArgb(255, 0, 0), null);
            uiContext.Send(d => progressBar2.BackColor = Color.FromArgb(150, 0, 0), null);
            uiContext.Send(d => button1.Enabled = false, null);

            uiContext.Send(d => progressBar3.Minimum = 0, null);
            uiContext.Send(d => progressBar3.Maximum = 230, null);
            uiContext.Send(d => progressBar3.Value = 0, null);
            uiContext.Send(d => progressBar3.ForeColor = Color.FromArgb(255, 0, 0), null);
            uiContext.Send(d => progressBar3.BackColor = Color.FromArgb(150, 0, 0), null);
            uiContext.Send(d => button1.Enabled = false, null);

            uiContext.Send(d => progressBar4.Minimum = 0, null);
            uiContext.Send(d => progressBar4.Maximum = 230, null);
            uiContext.Send(d => progressBar4.Value = 0, null);
            uiContext.Send(d => progressBar4.ForeColor = Color.FromArgb(255, 0, 0), null);
            uiContext.Send(d => progressBar4.BackColor = Color.FromArgb(150, 0, 0), null);
            uiContext.Send(d => button1.Enabled = false, null);

            uiContext.Send(d => progressBar5.Minimum = 0, null);
            uiContext.Send(d => progressBar5.Maximum = 230, null);
            uiContext.Send(d => progressBar5.Value = 0, null);
            uiContext.Send(d => progressBar5.ForeColor = Color.FromArgb(255, 0, 0), null);
            uiContext.Send(d => progressBar5.BackColor = Color.FromArgb(150, 0, 0), null);
            uiContext.Send(d => button1.Enabled = false, null);

            Random random = new Random();
            

            for (int i = 0; i < 230; i++)
            {

                int randomNumber1 = random.Next(0, 230);

                int randomNumber2 = random.Next(0, 230);

                int randomNumber3 = random.Next(0, 230);

                int randomNumber4 = random.Next(0, 230);

                int randomNumber5 = random.Next(0, 230);
                Thread.Sleep(500);

                uiContext.Send(d => progressBar1.Value = (int)d /* Вызываемый делегат SendOrPostCallback */,
                    randomNumber1 /* Объект, переданный делегату */); // добавляем в список имя клиента
                uiContext.Send(d => progressBar2.Value = (int)d /* Вызываемый делегат SendOrPostCallback */,
                    randomNumber2 /* Объект, переданный делегату */); // добавляем в список имя клиента
                uiContext.Send(d => progressBar3.Value = (int)d /* Вызываемый делегат SendOrPostCallback */,
                    randomNumber3 /* Объект, переданный делегату */); // добавляем в список имя клиента
                uiContext.Send(d => progressBar4.Value = (int)d /* Вызываемый делегат SendOrPostCallback */,
                    randomNumber4 /* Объект, переданный делегату */); // добавляем в список имя клиента
                uiContext.Send(d => progressBar5.Value = (int)d /* Вызываемый делегат SendOrPostCallback */,
                    randomNumber5 /* Объект, переданный делегату */); // добавляем в список имя клиента
            }
            uiContext.Send(d => button1.Enabled = true, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ThreadStart MethodThread = new ThreadStart(ThreadFunk);

            thread = new Thread(MethodThread);

            thread.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (thread != null)
                thread.Abort();
        }
    }
}
