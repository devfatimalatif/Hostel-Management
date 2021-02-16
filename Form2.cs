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
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-BGLUEG0;Initial Catalog=project;Integrated Security=True");

        public Form2()
        {
            InitializeComponent();
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }
        private void save()
        {
            con.Open();
            string id = hostelbox.Text;
            string name = hostelnamebox.Text;
            string room1 = roombox.Text;
            string student1 = studentbox.Text;
            string inertionvalue = "insert into HOSTEL values(@id1,@fname,@room,@student)";
            SqlCommand cmd = new SqlCommand(inertionvalue, con);
            cmd.Parameters.AddWithValue("@id1", id);
            cmd.Parameters.AddWithValue("@fname", name);
            cmd.Parameters.AddWithValue("@room", room1);
            cmd.Parameters.AddWithValue("@student", student1);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Great Job! You are successfully saved in database");
            con.Close();
            populate();
        }

        private void populate()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from HOSTEL", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                string hostelid = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                string hostelname = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                string room = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                string student = ds.Tables[0].Rows[i].ItemArray[3].ToString();

                DataGridViewRow row1 = new DataGridViewRow();
                row1.CreateCells(dataGridView1);
                row1.Cells[0].Value = hostelid;
                row1.Cells[1].Value = hostelname;
                row1.Cells[2].Value = room;
                row1.Cells[3].Value = student;
                dataGridView1.Rows.Add(row1);
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            new signup().Show();
            this.Hide();
        }
        private void update()
        {
            string id = hostelbox.Text;
            string name = hostelnamebox.Text;
            string room1 = roombox.Text;
            string student1 = studentbox.Text;
            con.Open();
            string updatevalue = "update  HOSTEL set Hostel_ID=@fid,Hostel_NAME=@fname,No_Of_Rooms=@froom1 where  Hostel_ID=@fid";
            SqlCommand cmd = new SqlCommand(updatevalue, con);
            cmd.Parameters.AddWithValue("@fid", id);
            cmd.Parameters.AddWithValue("@fname", name);
            cmd.Parameters.AddWithValue("@froom1", room1);
            cmd.Parameters.AddWithValue("@fstudent", student1);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Great Job! You are successfully updtae data in database");
            con.Close();
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            
            con.Open();
              SqlCommand cmd = new SqlCommand("select * from HOSTEL where Hostel_ID like '" + searchbox.Text + "%'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string id= ds.Tables[0].Rows[i].ItemArray[0].ToString();
                string name = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                string room1 = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                string student1 = ds.Tables[0].Rows[i].ItemArray[3].ToString();

                DataGridViewRow row1 = new DataGridViewRow();
                row1.CreateCells(dataGridView1);
                row1.Cells[0].Value = id;
                row1.Cells[1].Value = name;
                row1.Cells[2].Value = room1;
                row1.Cells[3].Value = student1;
                dataGridView1.Rows.Add(row1);
                con.Close();
            }
    }
    
    }
}
