using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management_System
{
    public partial class ROOMs : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-BGLUEG0;Initial Catalog=project;Integrated Security=True");
        public ROOMs()
        {
            InitializeComponent();
            populate();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            save();
        }
        private void save()
        {
            con.Open();
            string id = roomid.Text;
            string name = hostelid.Text;
            string roomst = status.Text;
          
            string inertionvalue = "insert into ROOM values(@id1,@room,@fname)";
            SqlCommand cmd = new SqlCommand(inertionvalue, con);
            cmd.Parameters.AddWithValue("@id1", id);
            cmd.Parameters.AddWithValue("@fname", name);
            cmd.Parameters.AddWithValue("@room", roomst);
    
            cmd.ExecuteNonQuery();
            MessageBox.Show("Great Job! You are successfully saved in database");
            con.Close();
            populate();
        }
        private void populate()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from ROOM", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                string id = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                string name = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                string roomst = ds.Tables[0].Rows[i].ItemArray[2].ToString();

                DataGridViewRow row1 = new DataGridViewRow();
                row1.CreateCells(dataGridView1);
                row1.Cells[0].Value = id;
                row1.Cells[1].Value = name;
                row1.Cells[2].Value = roomst;
                dataGridView1.Rows.Add(row1);
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new signup().Show();
        }

        private void status_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = roomid.Text;
            string name = hostelid.Text;
            string roomst = status.Text;
            SqlCommand cmd = new SqlCommand("update ROOM set Room_Id=@id,Room_status=@state where Room_id=@id", con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@state", roomst);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
            con.Close();
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ROOMs_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void roomid_TextChanged(object sender, EventArgs e)
        {

        }

        private void hostelid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from ROOM where Room_ID like '" + search.Text + "%'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string id = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                string name = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                string roomst = ds.Tables[0].Rows[i].ItemArray[2].ToString();

                DataGridViewRow row1 = new DataGridViewRow();
                row1.CreateCells(dataGridView1);
                row1.Cells[0].Value = id;
                row1.Cells[1].Value = name;
                row1.Cells[2].Value = roomst;

                dataGridView1.Rows.Add(row1);
                con.Close();
            }
        }
    }
}
