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
    public partial class STDENT : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-BGLUEG0;Initial Catalog=project;Integrated Security=True");
        private string cs;
        private SqlDataAdapter adapt;
        private DataTable dt;

        public SqlConnection STUDENT { get; private set; }

        public STDENT()
        {
            InitializeComponent();
            populate();
        }

       private void button5_Click(object sender, EventArgs e)
       {

        }

        // internal static void show()
        //{ 
        //
        // throw new NotImplementedException();
        //}

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }



      private void populate()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from STUDENT", con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapter.Fill(ds);
        dataGridView1.Rows.Clear();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            string studentid= ds.Tables[0].Rows[i].ItemArray[0].ToString();
            string  name= ds.Tables[0].Rows[i].ItemArray[1].ToString();
            string fname = ds.Tables[0].Rows[i].ItemArray[2].ToString();
            string age = ds.Tables[0].Rows[i].ItemArray[3].ToString();
            string address = ds.Tables[0].Rows[i].ItemArray[4].ToString();
            string department = ds.Tables[0].Rows[i].ItemArray[5].ToString();
            string hostelid = ds.Tables[0].Rows[i].ItemArray[6].ToString();
            string roomid = ds.Tables[0].Rows[i].ItemArray[7].ToString();
                DataGridViewRow row1 = new DataGridViewRow();


            row1.CreateCells(dataGridView1);
            row1.Cells[0].Value = studentid;
          
            row1.Cells[1].Value = name;
            row1.Cells[2].Value = fname;
            row1.Cells[3].Value = age;
            row1.Cells[4].Value = address;
            row1.Cells[5].Value = department;
            row1.Cells[6].Value = hostelid;
                row1.Cells[7].Value = roomid;
                dataGridView1.Rows.Add(row1);
        }
        con.Close();
    }
        private void save()
        {
            con.Open();
             string studentiid = studentid.Text;
            string hosteliid = hostelid.Text;
            string roomiid = roomid.Text;
            string name = studentname.Text;
            string fname = fathername.Text;
            string address1 = address.Text;
            string department1 = department.Text;
            string age1 = age.Text;
  
            string inertionvalue = "insert into STUDENT values(@stid,@name,@fname,@age,@add,@dep,@htid,@rmid)";
            SqlCommand cmd = new SqlCommand(inertionvalue, con);
            cmd.Parameters.AddWithValue("@stid", studentiid);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@age", age1);
            cmd.Parameters.AddWithValue("@add", address1);
            cmd.Parameters.AddWithValue("@dep", department1);
            cmd.Parameters.AddWithValue("@htid", hosteliid);
            cmd.Parameters.AddWithValue("@rmid", roomiid);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Great Job! You are successfully saved in database");
            con.Close();
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save();
            
        }

        internal class show
        {
            public show()
            {
            }
        }

        private void studentid_TextChanged(object sender, EventArgs e)
        {

        }

        private void STDENT_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new signup().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string studentiid = studentid.Text;
            string hosteliid = hostelid.Text;
            string roomiid = roomid.Text;
            string name = studentname.Text;
            string fname = fathername.Text;
            string address1 = address.Text;
            string department1 = department.Text;
            string age1 = age.Text;
            SqlCommand cmd = new SqlCommand("update STUDENT set Student_Id=@stid,Student_name=@name, Student_father_name=@fname ,Student_age=@age,Student_address=@add , Student_department= @dep where Student_ID=@stid", con);
            con.Open();
            cmd.Parameters.AddWithValue("@stid", studentiid);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@age", age1);
            cmd.Parameters.AddWithValue("@add", address1);
            cmd.Parameters.AddWithValue("@dep", department1);
            cmd.Parameters.AddWithValue("@htid", hosteliid);
            cmd.Parameters.AddWithValue("@rmid", roomiid);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
            con.Close();
            populate();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from STUDENT where Student_ID like '" + search.Text + "%'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string studentid = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                string name = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                string fname = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                string age = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                string address = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                string department = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                string hostelid = ds.Tables[0].Rows[i].ItemArray[6].ToString();
                string roomid = ds.Tables[0].Rows[i].ItemArray[7].ToString();

                DataGridViewRow row1 = new DataGridViewRow();
                row1.CreateCells(dataGridView1);
                row1.Cells[0].Value = studentid;

                row1.Cells[1].Value = name;
                row1.Cells[2].Value = fname;
                row1.Cells[3].Value = age;
                row1.Cells[4].Value = address;
                row1.Cells[5].Value = department;
                row1.Cells[6].Value = hostelid;
                row1.Cells[7].Value = roomid;
                dataGridView1.Rows.Add(row1);
                con.Close();
            }
            }

        private void button4_Click(object sender, EventArgs e)
        {

         //   con = new SqlConnection(cs);
           // con.Open();
         //   adapt = new SqlDataAdapter("select * from FEE where FirstName like '" + txt_SearchName.Text + "%'", con);
        //    dt = new DataTable();
        //    adapt.Fill(dt);
         //   dataGridView1.DataSource = dt;
         //   con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE STUDENT from STUDENT where Student_ID like '" + studentid.Text + "%'", con);
         //   SqlCommand cmd = new SqlCommand("DELETE HOSTEl from STUDENT where Student_ID like '" + studentid + "%'", con);

            MessageBox.Show("Record deleted Successfully");
            con.Close();
            populate();
        }
    }
}
