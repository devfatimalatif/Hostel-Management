using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management_System
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        private void signup_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new STDENT().Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            new ROOMs().Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
           // new VISITORS().Show();
          //  this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            new FEE().Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            new Furniture().Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Great Job! You are successfully Log Out from Hostel Management System ");

            this.Hide();
            new Form1().Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new Contact().Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
