using doctorappointment.appntappoimtmentDataSetTableAdapters;
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
    public partial class HomeAdmin : Form
    {
        public HomeAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Appointment().Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AddDoctors().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new SearchDoctor().Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj6 = new Form1();
            obj6.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new ViewUser().Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            new ViewAppointmment().Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new ViewFeedback().Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new UpdateDoctor().Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new UpdateAppointment().Show();
            this.Hide();
        }
    }
}
