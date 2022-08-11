using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace StraightenUp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //icon in tray -----------------------------------------------------------------------
        
        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipText  = "Application minimized";
            notifyIcon1.BalloonTipTitle = "Straighten Up!";
            notifyIcon1.Text            = "Straighten Up!";
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false; 
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //icon in tray -----------------------------------------------------------------------

        //change button text, turn on|off timer
        
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;

            if (timer1.Enabled == true)
            {
                button1.Text = "Stop";
                Voice();
                timer1.Interval = (1000 * 60) * 5;
            }

            else
            {
                button1.Text = "Start";
                timer1.Stop();
            }
        }

        //text that will be spoken
        
        static void Voice()
        {
            SpeechSynthesizer _SS = new SpeechSynthesizer();
            _SS.Speak("Тримай спину рівно!");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Voice();
        }
    }
}
