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
    public partial class changePassword : Form
    {
        public changePassword()
        {
            InitializeComponent();
        }
        bool passcheck = false ;
        bool usercheck= false;
        bool chechIdentical = false;


        private void button2_Click(object sender, EventArgs e)
        {
            UrFine.MainForm m = new MainForm();
            m.Show();
            this.Close();
        }

        private void changePassword_Load(object sender, EventArgs e)
        {
            
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            using (DataSet ds4 = datamanager.getdatasetstored("getpassword", "usernames_passwords", datamanager.createparameter("@password", SqlDbType.NVarChar, textBox1.Text)))
            {
                var table = ds4.Tables[0];
                if (table.Rows.Count > 0)
                {
                    passcheck = true;
                }
                else
                {
                    MessageBox.Show("check your current password");
                    this.Focus();
                }
            }
            using (DataSet ds4 = datamanager.getdatasetstored("getusername", "usernames_passwords", datamanager.createparameter("@user", SqlDbType.NVarChar, textBox4.Text)))
            {
                var table = ds4.Tables[0];
                if (table.Rows.Count > 0)
                {
                    usercheck = true;

                }
                else
                {
                    MessageBox.Show(" check your username");
                    this.Focus();

                }
            }
            if(newpass.Text == Repeatpass.Text) { chechIdentical = true; }else { chechIdentical = false; }

            if (passcheck== true && usercheck== true&& chechIdentical== true )
            {
                datamanager.executenonqueryoutput("ChangePassword", datamanager.createparameter("@pass", SqlDbType.NVarChar, newpass.Text)
                    ,datamanager.createparameter("@user",SqlDbType.NVarChar,textBox4.Text));

            }

            MessageBox.Show("Your password successfully");
            clear();
            UrFine.MainForm m = new UrFine.MainForm();
            m.Show();
            this.Close();
        }


        void clear()
        {
            textBox4.Text = textBox1.Text = newpass.Text = Repeatpass.Text = null;
        }
    }
}
