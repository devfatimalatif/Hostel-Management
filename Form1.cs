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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-BGLUEG0;Initial Catalog=project;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }

      /*  private void button8_Click(object sender, EventArgs e)
        {
            new STDENT().Show();
            this.Hide();
        }

        internal static void SHOW()
        {
            throw new NotImplementedException();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            new ROOMs().Show();
            this.Hide();
                
        }

        private void button12_Click(object sender, EventArgs e)
        {
            new FURNITURE().Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new VISITORS().Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            new FEE().Show();
            this.Hide();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

       // private void button15_Click(object sender, EventArgs e)
        {/// <summary>
      
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

      //  }
      */

        private void button8_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("WELCOME!!!!!!!!!!!!!!!!!!!!",
                "You are successfully login to Hostel Management System");
            new signup().Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
      //      MessageBox.Show(" You are successfully signup to Hostel Management System ");
        }

        private void cpassword_TextChanged(object sender, EventArgs e)
        {
            // Creating and setting the properties of Lable1 
        //    Label Mylablel = new Label();
       //     Mylablel.Location = new Point(96, 54);
          //  Mylablel.Text = "Enter Password";
        //    Mylablel.AutoSize = true;
         //   Mylablel.BackColor = Color.LightGray;

            // Add this label to form 
           // this.Controls.Add(Mylablel);

            // Creating and setting the properties of TextBox1 
            //TextBox Mytextbox = new TextBox();
           // cpassword.Location = new Point(187, 51);
           cpassword.BackColor = Color.LightGray;
           cpassword.ForeColor = Color.DarkOliveGreen;
           cpassword.AutoSize = true;
            cpassword.Name = "text_box1";
            cpassword.UseSystemPasswordChar = true;

            // Add this textbox to form 
            Controls.Add(cpassword);
        }

        ////   internal class Show
        //  {
        ////     public Show()
        // {
        // }
        // }//





        // private object newHOSTELS()
        //   {
        //     throw new NotImplementedException();
        // }
    }
}
