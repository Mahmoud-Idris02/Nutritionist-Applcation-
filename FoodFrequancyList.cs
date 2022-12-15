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
    public partial class FoodFrequancyList : Form
    {
        public FoodFrequancyList()
        {
            InitializeComponent();
        }


        private void FoodFrequancyList_Load(object sender, EventArgs e)
        {

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
        private void toolStripButton1_Click(object sender, EventArgs e)
        {


            if (ContactSearch_textBox.Text != "")
            {
                using (DataSet ds = datamanager.getdatasetstored("GetByContact_FFL", "Client", datamanager.createparameter("@mobile", SqlDbType.NVarChar, ContactSearch_textBox.Text)))
                {
                    var table = ds.Tables[0];
                    if (table.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = ds.Tables["Client"];
                    }
                    else { MessageBox.Show("No Data Found"); }

                }
            }
            else { MessageBox.Show("Please enter Client Name or Contact"); }

            Clear();
        }

        void Clear()
        {
            ContactSearch_textBox.Text = "";
        }


        private void Refresh_Click(object sender, EventArgs e)
        {
            foodFreqancyListToolStripMenuItem_Click(sender, e);


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Delete....
            if (MessageBox.Show("Do You Want To Delete This track ?", "Delete track ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewCell onecell in dataGridView1.SelectedCells)
                {
                    if (onecell.Selected)
                    {

                        datamanager.executenonqueryoutput("Delete_FFL", datamanager.createparameter("name", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
                        dataGridView1.Rows.RemoveAt(onecell.RowIndex);
                        MessageBox.Show("Successfully Deleted ");


                    }
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UrFine.Home h = new UrFine.Home();
            h.Show();
            this.Show();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            datamanager.executenonqueryoutput("Update_FFL", datamanager.createparameter("@name", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString())
              , datamanager.createparameter("@contact", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString())
              , datamanager.createparameter("@MealsPerDay", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString())
              , datamanager.createparameter("@MainMeal", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString())
              , datamanager.createparameter("@BreakFast", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString())
              , datamanager.createparameter("@Snacks", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString())
              , datamanager.createparameter("@F_vegetables", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString())
              , datamanager.createparameter("@C_vegetables", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString())
              , datamanager.createparameter("@F_fruits", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString())
              , datamanager.createparameter("@Canned_Juices", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString())
              , datamanager.createparameter("@Carbonated_drinks", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString())
              , datamanager.createparameter("@Stimulant_drinks", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString())
              , datamanager.createparameter("@Processed_foods", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString())
              , datamanager.createparameter("@Junk_Foods", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString())
              , datamanager.createparameter("@Balady_bread", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString())
              , datamanager.createparameter("@Fesh_seafoods", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString())
              , datamanager.createparameter("@Eggs", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString())
              , datamanager.createparameter("@Legumes", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString())
              , datamanager.createparameter("@Veg_oils", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString())
              , datamanager.createparameter("@Hedrogenated_oils", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[19].Value.ToString())
              , datamanager.createparameter("@Butter", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[20].Value.ToString())
              , datamanager.createparameter("@Veg_oils_mono", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString())
              , datamanager.createparameter("@White_bread", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[22].Value.ToString())
              , datamanager.createparameter("@RiceORmacaroni", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[23].Value.ToString())
              , datamanager.createparameter("@Whole_grains", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[24].Value.ToString())
              , datamanager.createparameter("@Milk_products", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[25].Value.ToString())
              , datamanager.createparameter("@Meat_poultry", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[26].Value.ToString())

              );
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // show all
            using (DataSet ds = datamanager.getdatasetstored("ShowFFL", "Client"))
            {
                var table = ds.Tables[0];

                dataGridView1.DataSource = ds.Tables["Client"];
            }

        }

    }

}
