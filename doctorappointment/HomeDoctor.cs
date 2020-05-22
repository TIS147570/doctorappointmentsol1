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
    public partial class HomeDoctor : Form
    {
        public HomeDoctor()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            ViewAppointmment1 obj = new doctorappointment.ViewAppointmment1();
            obj.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj2 = new doctorappointment.Form1();
            obj2.ShowDialog();

        }

        private void button8_Click(object sender, EventArgs e)
        {

            new DoctorDetails().Show();
            this.Hide();
        }
    }
}
