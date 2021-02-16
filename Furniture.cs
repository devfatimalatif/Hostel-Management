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
    public partial class Furniture : Form
    {
        SqlConnection con = new System.Data.SqlClient.SqlConnection("Data Source=DESKTOP-BGLUEG0;Initial Catalog=project;Integrated Security=True");

        public Furniture()
        {
            InitializeComponent();
            populate();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void save()
        {
            con.Open();
            string fid = roomid.Text;
            string ftyp = hostelid.Text;
            string hst = status.Text;
            string rmt = textBox1.Text;
            string inertionvalue = "insert into FURNITURE values(@id1,@room,@fname,@fhst)";
            SqlCommand cmd = new SqlCommand(inertionvalue, con);
            cmd.Parameters.AddWithValue("@id1", fid);
            cmd.Parameters.AddWithValue("@room", ftyp);
            cmd.Parameters.AddWithValue("@fname", hst);
            cmd.Parameters.AddWithValue("@fhst", rmt);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Great Job! You are successfully saved in database");
            con.Close();
            populate();
        }
        private void roomid_TextChanged(object sender, EventArgs e)
        {

        }
        private void populate()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from FURNITURE", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                string fid = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                string ftyp = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                string hst = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                string rmt = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                DataGridViewRow row1 = new DataGridViewRow();
                row1.CreateCells(dataGridView1);
                row1.Cells[0].Value = fid;
                row1.Cells[1].Value = ftyp;
                row1.Cells[2].Value = hst;
                row1.Cells[3].Value = rmt;

                dataGridView1.Rows.Add(row1);
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new signup().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fid = roomid.Text;
            string ftyp = hostelid.Text;
            string hst = status.Text;
            string rmt = textBox1.Text;
            SqlCommand cmd = new SqlCommand("update FURNITURE set Furniture_ID=@id,furniture_type=@name where Furniture_ID=@id", con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", fid);
            cmd.Parameters.AddWithValue("@name", ftyp);
            cmd.Parameters.AddWithValue("@state", hst);
            cmd.Parameters.AddWithValue("@fhst", rmt);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
            con.Close();
            populate();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from FURNITURE where Furniture_ID like '" + search.Text + "%'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string fid = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                string ftyp = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                string hst = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                string rmt = ds.Tables[0].Rows[i].ItemArray[3].ToString();

                DataGridViewRow row1 = new DataGridViewRow();
                row1.CreateCells(dataGridView1);
                row1.Cells[0].Value = fid;
                row1.Cells[1].Value = ftyp;
                row1.Cells[2].Value = hst;
                row1.Cells[3].Value = rmt;
                dataGridView1.Rows.Add(row1);
                con.Close();
            }
        }
    }
}
