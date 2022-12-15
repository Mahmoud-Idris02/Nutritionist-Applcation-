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
    public partial class progressList : Form
    {
        public progressList()
        {
            InitializeComponent();
        }
        

        private void progressList_Load(object sender, EventArgs e)
        { }
        



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
                using (DataSet ds = datamanager.getdatasetstored("GetByContact_PL", "Client", datamanager.createparameter("@mobile", SqlDbType.NVarChar, ContactSearch_textBox.Text)))
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
            UrFine.progressList l = new UrFine.progressList();
            l.Show();
            this.Close();
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
                         
                        datamanager.executenonqueryoutput("Delete_PL", datamanager.createparameter("name", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
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
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // show all 
            using (DataSet ds = datamanager.getdatasetstored("ShowPL", "Client"))
            {
                var table = ds.Tables[0];

                dataGridView1.DataSource = ds.Tables["Client"];
            }

        }

        /* 

         private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
         {
         }

         private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
         {
             datamanager.executenonqueryoutput("Update_PL", datamanager.createparameter("@name", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString())
               , datamanager.createparameter("@contact", SqlDbType.NVarChar, dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString())
               , datamanager.createparameter("@wt", SqlDbType.Float, dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString())
               , datamanager.createparameter("@ht", SqlDbType.Float, dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString())
               , datamanager.createparameter("@wst", SqlDbType.Float, dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString())
               , datamanager.createparameter("@hip", SqlDbType.Float, dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString())
               , datamanager.createparameter("@wst_hip", SqlDbType.Float, dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString())
               , datamanager.createparameter("@bmi", SqlDbType.Float, dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString())
               , datamanager.createparameter("@date", SqlDbType.DateTime, dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString())
               );

         }*/
    }

}
