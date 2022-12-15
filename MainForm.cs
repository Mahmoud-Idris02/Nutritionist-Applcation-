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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        public string id;
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UrFine.newClient n = new UrFine.newClient();

            // vars to be sent to update form
            n.update = true;
            n.id= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            n.name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            n.age = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            n.contact = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            n.wt = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            n.ht = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            n.wst = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            n.hip = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            n.wst_hip = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            n.bmi = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();    
            n.job = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            n.bd = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            n.gender = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
            n.pathologicalCase = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
            n.maretalStatus = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
            n.Activity = dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString();
            n.Exercising = dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString();
            n.sportName = dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString();
            n.Medicines = dataGridView1.Rows[e.RowIndex].Cells[19].Value.ToString();
            n.notes = dataGridView1.Rows[e.RowIndex].Cells[20].Value.ToString();
            n.package= dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString();
            n.deposite = dataGridView1.Rows[e.RowIndex].Cells[22].Value.ToString();
            n.remainig = dataGridView1.Rows[e.RowIndex].Cells[23].Value.ToString();
            n.Show();
            this.Close();

        }


        private void insertNewClientToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            UrFine.newClient s = new newClient();
            s.Show();
            this.Close();




        }

        private void mainFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
           UrFine.MainForm s= new MainForm();
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


        private void Refresh_Click(object sender, EventArgs e)
        {
            mainFormToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {


             if(ContactSearch_textBox.Text != "")
            {
                using (DataSet ds = datamanager.getdatasetstored("GetByContact", "Client", datamanager.createparameter("@mobile", SqlDbType.NVarChar, ContactSearch_textBox.Text)))
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

        private void DeleteButton_Click(object sender, EventArgs e)
        {


            

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Delete....
            if (MessageBox.Show("Do You Want To Delete This client", "Delete client ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewCell onecell in dataGridView1.SelectedCells)
                {
                    if (onecell.Selected)
                    {
                        id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        datamanager.executenonqueryoutput("Delete_MF", datamanager.createparameter("id", SqlDbType.Int, id));
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

        private void button2_Click(object sender, EventArgs e)
        {
            // show all clients
            using (DataSet ds = datamanager.getdatasetstored("ShowAllClients", "Client"))
            {
                var table = ds.Tables[0];

                dataGridView1.DataSource = ds.Tables["Client"];

            }

        }

       
    }
}
