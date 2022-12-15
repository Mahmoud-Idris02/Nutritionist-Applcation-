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
    public partial class InsertFoodFrequancy : Form
    {
        
        public InsertFoodFrequancy()
        {
            InitializeComponent();
        }
        public string name;
        public string contact;
        private void button2_Click(object sender, EventArgs e)
        {
            UrFine.MainForm m = new MainForm();
            m.Show();
            this.Close();
        }

        private void InsertFoodFrequancy_Load(object sender, EventArgs e)
        {
            namebox.Text = name;
            contactbox.Text = contact;

        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            datamanager.executenonqueryoutput("InsertFF", datamanager.createparameter("@name", SqlDbType.NVarChar, namebox.Text)
                , datamanager.createparameter("@contact", SqlDbType.NVarChar, contactbox.Text)
                , datamanager.createparameter("@MealsPerDay", SqlDbType.Int, textBox23.Text)
                , datamanager.createparameter("@MainMeal", SqlDbType.NVarChar, comboBox22.Text)
                , datamanager.createparameter("@BreakFast", SqlDbType.NVarChar, comboBox23.Text)
                , datamanager.createparameter("@Snacks", SqlDbType.NVarChar, textBox1.Text)
                , datamanager.createparameter("@F_vegetables", SqlDbType.NVarChar, (textBox2.Text+" "+ comboBox1.Text))
                , datamanager.createparameter("@C_vegetables", SqlDbType.NVarChar, (textBox11.Text + " " + comboBox11.Text))
                , datamanager.createparameter("@F_fruits", SqlDbType.NVarChar, (textBox10.Text+ " " + comboBox10.Text))
                , datamanager.createparameter("@Canned_Juices", SqlDbType.NVarChar, (textBox10.Text + " " + comboBox10.Text))
                , datamanager.createparameter("@Carbonated_drinks", SqlDbType.NVarChar, (textBox8.Text + " " + comboBox8.Text))
                , datamanager.createparameter("@Stimulant_drinks", SqlDbType.NVarChar, (textBox7.Text + " " + comboBox7.Text))
                , datamanager.createparameter("@Processed_foods", SqlDbType.NVarChar, (textBox6.Text + " " + comboBox6.Text))
                , datamanager.createparameter("@Junk_Foods", SqlDbType.NVarChar, (textBox5.Text + " " + comboBox5.Text))
                , datamanager.createparameter("@Balady_bread", SqlDbType.NVarChar, (textBox4.Text + " " + comboBox4.Text))
                , datamanager.createparameter("@Fesh_seafoods", SqlDbType.NVarChar, (textBox3.Text + " " + comboBox3.Text))
                , datamanager.createparameter("@Eggs", SqlDbType.NVarChar, (textBox12.Text + " " + comboBox12.Text))
                , datamanager.createparameter("@Legumes", SqlDbType.NVarChar, (textBox18.Text + " " + comboBox2.Text))
                , datamanager.createparameter("@Veg_oils", SqlDbType.NVarChar, (textBox17.Text + " " + comboBox17.Text))
                , datamanager.createparameter("@Hedrogenated_oils", SqlDbType.NVarChar, (textBox16.Text + " " + comboBox16.Text))
                , datamanager.createparameter("@Butter", SqlDbType.NVarChar, (textBox15.Text + " " + comboBox15.Text))
                , datamanager.createparameter("@Veg_oils_mono", SqlDbType.NVarChar, (textBox14.Text + " " + comboBox14.Text))
                , datamanager.createparameter("@White_bread", SqlDbType.NVarChar, (textBox13.Text + " " + comboBox13.Text))
                , datamanager.createparameter("@RiceORmacaroni", SqlDbType.NVarChar, (textBox21.Text + " " + comboBox20.Text))
                , datamanager.createparameter("@Whole_grains", SqlDbType.NVarChar, (textBox20.Text + " " + comboBox19.Text))
                , datamanager.createparameter("@Milk_products", SqlDbType.NVarChar, (textBox19.Text + " " + comboBox18.Text))
                , datamanager.createparameter("@Meat_poultry", SqlDbType.NVarChar, (textBox22.Text + " " + comboBox21.Text))

                );
                MessageBox.Show("Successfully Added");
            clear();
            UrFine.MainForm m =  new UrFine.MainForm();
            m.Show();
            this.Close();
        }

        void clear ()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = textBox10.Text = textBox11.Text = textBox12.Text = textBox13.Text = textBox14.Text = textBox15.Text = textBox16.Text = textBox17.Text = textBox18.Text = textBox19.Text = textBox20.Text = textBox21.Text= textBox22.Text = textBox23.Text =  null;
            comboBox1.SelectedItem = comboBox2.SelectedItem = comboBox3.SelectedItem= comboBox4.SelectedItem = comboBox5.SelectedItem= comboBox6.SelectedItem= comboBox7.SelectedItem= comboBox8.SelectedItem= comboBox9.SelectedItem = comboBox10.SelectedItem  = comboBox11.SelectedItem  = comboBox12.SelectedItem = comboBox13.SelectedItem= comboBox14.SelectedItem = comboBox15.SelectedItem= comboBox16.SelectedItem= comboBox17.SelectedItem = comboBox18.SelectedItem  = comboBox19.SelectedItem  = comboBox20.SelectedItem = comboBox21.SelectedItem = comboBox22.SelectedItem= comboBox23.SelectedItem = null;

        }
    }

}
