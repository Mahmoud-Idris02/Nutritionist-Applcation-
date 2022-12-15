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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //clients 

            UrFine.MainForm m = new UrFine.MainForm();
            m.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // new client
            UrFine.newClient n = new UrFine.newClient();
            n.Show();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // progress list

            UrFine.progressList p = new UrFine.progressList();
            p.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // FF list
            UrFine.FoodFrequancyList f = new FoodFrequancyList();
            f.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // changePassword
            UrFine.changePassword c= new UrFine.changePassword();
            c.Show();
            this.Close();
        }
    }
}
