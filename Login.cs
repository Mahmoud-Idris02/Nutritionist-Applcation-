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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
       

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender , EventArgs e  )
        {
            string usercheck = "0";
            string passcheck = "0";
            if (Username_textbox.Text != "")
            {
                if (Password_textbox.Text != "")
                {
                 
      
                    using (DataSet ds4 = datamanager.getdatasetstored("getpassword", "usernames_passwords", datamanager.createparameter("@password", SqlDbType.NVarChar, Password_textbox.Text)))
                    {
                        var table = ds4.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            passcheck = "1";
                        }
                        else
                        {
                            MessageBox.Show("Password Error");
                            this.Focus();
                        }
                    }

                    using (DataSet ds4 = datamanager.getdatasetstored("getusername", "usernames_passwords", datamanager.createparameter("@user", SqlDbType.NVarChar, Username_textbox.Text)))
                    {
                        var table = ds4.Tables[0];
                        if (table.Rows.Count > 0)
                        {
                            usercheck = "1";

                        }
                        else
                        {
                            MessageBox.Show("Username Error");
                            this.Focus();

                        }
                    }
                    if (passcheck == "1" && usercheck == "1")
                    {
                        UrFine.Home h = new UrFine.Home();
                        h.Show();
                        this.Hide();

                    }


                }
            }

        }
        private void cancelButton_Click(object sender , EventArgs e )
        {
            this.Close();
        }
    }

}
