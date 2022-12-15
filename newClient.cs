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
    public partial class newClient : Form
    {
        public newClient()
        {
            InitializeComponent();
        }
        public bool update = false;
        public string id,name,age, contact, job, gender, pathologicalCase, maretalStatus, Activity, Exercising, sportName, Medicines, notes,  wt, ht, wst, hip, wst_hip, bmi,package,remainig,deposite,bd;
       

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UrFine .Home h = new UrFine .Home();
            h.Show();
            this.Close();
        }

        private void newClient_Load(object sender, EventArgs e)
        {
           
            if (update)
            {
                label14.Text = "Updated date";
                Insert.Text = "Update";
                textBox1.Text = name; textBox2.Text = age; textBox9.Text = contact; textBox10.Text = job ; comboBox1.SelectedItem=gender ; textBox14.Text=pathologicalCase;comboBox2.SelectedItem = maretalStatus;comboBox3.SelectedItem = Activity; comboBox4.SelectedItem = Exercising; textBox11.Text = sportName; textBox13.Text = Medicines;  textBox12.Text = notes;textBox3.Text = wt; textBox5.Text=ht; textBox4.Text=wst;textBox15.Text = hip;textBox6.Text = wst_hip; textBox7.Text = bmi; comboBox5.SelectedItem = package; textBox16.Text = deposite;textBox17.Text = remainig;
            }

        }

        private void insertNewClientToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            UrFine.newClient s = new newClient();
            s.Show();
            this.Close();




        }

        private void mainFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UrFine.MainForm s = new MainForm();
            s.Show();
            this.Close();


        }

        private void progressListToolStripMenuItem_Click(object sender, EventArgs e)
        {

            UrFine.progressList s = new progressList();
            s.Show();
            this.Close();




        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            UrFine.changePassword s = new changePassword();
            s.Show();
            this.Close();



        }
        private void foodFreqancyListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UrFine.FoodFrequancyList f = new FoodFrequancyList();
            f.Show();
            this.Close();

        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
           float a = float.Parse(textBox3.Text);
           float b = float.Parse(textBox5.Text)/100;
           float c = (a / (b * b));
           float wst = float.Parse(textBox4.Text);
           float hip = float.Parse(textBox15.Text);
           textBox6.Text = (wst/hip).ToString();

           

           textBox7.Text = c.ToString();
           if (c < 18.5) { textBox8.Text = "Underweight"; }
           else if (c>18.5 && c<24.5) {textBox8.Text = "Normal";}
           else if (c > 25 && c < 29.9) { textBox8.Text = "OverWeight"; }
           else if (c > 30 && c < 34.9) { textBox8.Text = "obese 1"; }
           else if (c > 35 && c < 39.9) { textBox8.Text = "obese 2"; }
           else if(c >= 40) { textBox8.Text = "obese3"; }





        }


        private void Cancel_Click(object sender, EventArgs e)
        {
            Clear();
            UrFine.MainForm m = new UrFine.MainForm();
            m.Show();
            this.Close();

        }

        private void Insert_Click(object sender, EventArgs e)
        {
            if (!update)
            {
                datamanager.executenonqueryoutput("InsertClient", datamanager.createparameter("@name", SqlDbType.NVarChar, textBox1.Text)
                    , datamanager.createparameter("@age", SqlDbType.NVarChar, textBox2.Text)
                    , datamanager.createparameter("@wt", SqlDbType.Float, textBox3.Text)
                    , datamanager.createparameter("@ht", SqlDbType.Float, textBox5.Text)
                    , datamanager.createparameter("@wst", SqlDbType.Float, textBox4.Text)
                    , datamanager.createparameter("@wst_hip", SqlDbType.Float, textBox6.Text)
                    , datamanager.createparameter("@bmi", SqlDbType.Float, textBox7.Text)
                    , datamanager.createparameter("@contact", SqlDbType.NVarChar, textBox9.Text)
                    , datamanager.createparameter("@job", SqlDbType.NVarChar, textBox10.Text)
                    , datamanager.createparameter("@startingDate", SqlDbType.DateTime, dateTimePicker2.Text)
                    , datamanager.createparameter("@birthDate", SqlDbType.DateTime, dateTimePicker1.Text)
                    , datamanager.createparameter("@gender", SqlDbType.NVarChar, comboBox1.Text)
                    , datamanager.createparameter("@pathologicalCase", SqlDbType.NVarChar, textBox14.Text)
                    , datamanager.createparameter("@maretalStatus", SqlDbType.NVarChar, comboBox2.Text)
                    , datamanager.createparameter("@activity", SqlDbType.NVarChar, comboBox3.Text)
                    , datamanager.createparameter("@exercising", SqlDbType.NVarChar, comboBox4.Text)
                    , datamanager.createparameter("@sportName", SqlDbType.NVarChar, textBox11.Text)
                    , datamanager.createparameter("@medicines", SqlDbType.NVarChar, textBox13.Text)
                    , datamanager.createparameter("@note", SqlDbType.NVarChar, textBox12.Text)
                    , datamanager.createparameter("@hip", SqlDbType.NVarChar, textBox15.Text)
                    , datamanager.createparameter("@package", SqlDbType.NVarChar, comboBox5.SelectedItem)
                    , datamanager.createparameter("@deposite", SqlDbType.NVarChar, textBox16.Text)
                    , datamanager.createparameter("@remaining", SqlDbType.NVarChar, textBox17.Text));
                MessageBox.Show("Successfully Inserted");

                UrFine.InsertFoodFrequancy s = new InsertFoodFrequancy();
                s.name = textBox1.Text;
                s.contact = textBox9.Text;
                s.Show();
                this.Close();

                Clear();
            }
            if(update)
            {
                 datamanager.executenonqueryoutput("Update_MF",datamanager.createparameter("id",SqlDbType.Int,id)
               , datamanager.createparameter("@name", SqlDbType.NVarChar, textBox1.Text)
               , datamanager.createparameter("@age", SqlDbType.NVarChar, textBox2.Text)
               , datamanager.createparameter("@wt", SqlDbType.Float, textBox3.Text)
               , datamanager.createparameter("@ht", SqlDbType.Float, textBox5.Text)
               , datamanager.createparameter("@wst", SqlDbType.Float, textBox4.Text)
               , datamanager.createparameter("@wst_hip", SqlDbType.Float, textBox6.Text)
               , datamanager.createparameter("@bmi", SqlDbType.Float, textBox7.Text)
               , datamanager.createparameter("@contact", SqlDbType.NVarChar, textBox9.Text)
               , datamanager.createparameter("@job", SqlDbType.NVarChar, textBox10.Text)
               , datamanager.createparameter("@startingDate", SqlDbType.DateTime, dateTimePicker2.Text)
               , datamanager.createparameter("@gender", SqlDbType.NVarChar, comboBox1.Text)
               , datamanager.createparameter("@pathologicalCase", SqlDbType.NVarChar, textBox14.Text)
               , datamanager.createparameter("@maretalStatus", SqlDbType.NVarChar, comboBox2.Text)
               , datamanager.createparameter("@activity", SqlDbType.NVarChar, comboBox3.Text)
               , datamanager.createparameter("@exercising", SqlDbType.NVarChar, comboBox4.Text)
               , datamanager.createparameter("@sportName", SqlDbType.NVarChar, textBox11.Text)
               , datamanager.createparameter("@medicines", SqlDbType.NVarChar, textBox13.Text)
               , datamanager.createparameter("@note", SqlDbType.NVarChar, textBox12.Text)
               , datamanager.createparameter("@hip", SqlDbType.NVarChar, textBox15.Text)
               , datamanager.createparameter("@package", SqlDbType.NVarChar, comboBox5.SelectedItem)
               , datamanager.createparameter("@deposite", SqlDbType.NVarChar, textBox16.Text)
               , datamanager.createparameter("@remaining", SqlDbType.NVarChar, textBox17.Text)
               , datamanager.createparameter("@BD", SqlDbType.DateTime, dateTimePicker1.Text)
               );
                MessageBox.Show("Successfully updated");

                // confiramtion for adding to PL
                if (MessageBox.Show("Do You Want To add This to Progress List", "Adding to progress list ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { 
                    datamanager.executenonqueryoutput("insertprogress",datamanager.createparameter("name",SqlDbType.NVarChar,textBox1.Text)
                        , datamanager.createparameter("@contact", SqlDbType.NVarChar, textBox9.Text)
                        , datamanager.createparameter("@startingDate", SqlDbType.DateTime, dateTimePicker2.Text)
                        , datamanager.createparameter("@wt", SqlDbType.Float, textBox3.Text)
                        , datamanager.createparameter("@ht", SqlDbType.Float, textBox5.Text)
                        , datamanager.createparameter("@wst", SqlDbType.Float, textBox4.Text)
                        , datamanager.createparameter("@wst_hip", SqlDbType.Float, textBox6.Text)
                        , datamanager.createparameter("@bmi", SqlDbType.Float, textBox7.Text)
                        , datamanager.createparameter("@hip", SqlDbType.NVarChar, textBox15.Text));

                }
                   
                
                UrFine.MainForm m = new UrFine.MainForm();
                m.Show();
                this.Close();
                Clear();

            }
        }
        void Clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = textBox10.Text = textBox11.Text = textBox12.Text = textBox13.Text = textBox14.Text = textBox15.Text = null;
            comboBox1.SelectedItem = comboBox2.SelectedItem = comboBox3.SelectedItem= comboBox4.SelectedItem = null;
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }


    }
}
