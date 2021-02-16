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
    public partial class FEE : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-BGLUEG0;Initial Catalog=project;Integrated Security=True");
        private object txt_SearchName;
        private string cs;
        private SqlDataAdapter adapt;
        private DataTable dt;

        public FEE()
        {
            InitializeComponent();
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            save();
        }
        private void save()
        {
            con.Open();
            string id = monthyear.Text;
            string name = status.Text;
            string room1 = studentid.Text;
           
            string inertionvalue = "insert into FEE values(@id1,@fname,@room)";
            SqlCommand cmd = new SqlCommand(inertionvalue, con);
            cmd.Parameters.AddWithValue("@id1", id);
            cmd.Parameters.AddWithValue("@fname", name);
            cmd.Parameters.AddWithValue("@room", room1);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Great Job! You are successfully saved in database");
            con.Close();
            populate();
        }

        private void populate()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from FEE", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                string id = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                string name = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                string room1 = ds.Tables[0].Rows[i].ItemArray[2].ToString();
              
                DataGridViewRow row1 = new DataGridViewRow();
                row1.CreateCells(dataGridView1);
                row1.Cells[0].Value = id;
                row1.Cells[1].Value = name;
                row1.Cells[2].Value = room1;
          
                dataGridView1.Rows.Add(row1);
            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new signup().Show();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            //  con = new SqlConnection(cs);
            //  con.Open();
            //  adapt = new SqlDataAdapter("select * from fee where Fee_month like '" + txt_SearchName.Text + "%'", con);
            //    dt = new DataTable();
            //    adapt.Fill(dt);
            //    dataGridView1.DataSource = dt;
            //   con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from FEE where Student_ID like '" + search.Text + "%'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string id = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                string name = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                string room1 = ds.Tables[0].Rows[i].ItemArray[2].ToString();

                DataGridViewRow row1 = new DataGridViewRow();
                row1.CreateCells(dataGridView1);
                row1.Cells[0].Value = id;
                row1.Cells[1].Value = name;
                row1.Cells[2].Value = room1;

                dataGridView1.Rows.Add(row1);
                con.Close();
            }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            con.Open();
            adapt = new SqlDataAdapter("select * from FEE where Student_ID like '" + search + "%'", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = monthyear.Text;
            string name = status.Text;
            string room1 = studentid.Text;
            SqlCommand cmd = new SqlCommand("update FEE set Fee_month=@id,Fee_status=@name where Student_ID=@state", con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@state", room1);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
            con.Close();
            populate();
        }
    }
}
