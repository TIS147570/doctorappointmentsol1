using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doctorappointment
{
    public partial class HomeUser : Form
    {
        
        public HomeUser()
        {
            InitializeComponent();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj2 = new doctorappointment.Form1();
            obj2.ShowDialog();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            new SearchDoctor().Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Appoint1().Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new ViewAppointmment().Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            new MyDetails().Show();
            this.Hide();
        }
    }
}
