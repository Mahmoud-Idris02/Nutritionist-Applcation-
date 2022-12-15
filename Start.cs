using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrFine
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }
        int seconds = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
             
        }

        private void startTimer_Tick(object sender , EventArgs e)
        {
            seconds++;
            if (seconds >=10)
            {
                startTimer.Stop();
                UrFine.Login l = new Login();
                l.Show();
                this.Hide();
                
            }
        }

        private void startLoad(object sender , EventArgs e )
        {
            startTimer.Interval = 500;
            startTimer.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
