using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace doctorappointment
{
    public partial class MyDetails : Form
    {
        public MyDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NCS\Downloads\doctorappointmentsol\doctorappointmentsol\doctorappointment\appnt.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NCS\Downloads\doctorappointmentsol\doctorappointmentsol\doctorappointment\appnt.mdf;Integrated Security=True");
            con.Open();
            if (textBox1.Text != "")
            {
                try
                {
                    string getCust = "select name,mobile,addr,pass from user1 where id=" + Convert.ToInt32(textBox1.Text) + " ;";

                    SqlCommand cmd = new SqlCommand(getCust, con);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {

                        textBox2.Text = dr.GetValue(0).ToString();
                        textBox3.Text = dr.GetValue(1).ToString();
                        textBox4.Text = dr.GetValue(2).ToString();
                        textBox5.Text = dr.GetValue(3).ToString();


                    }
                    else
                    {
                        MessageBox.Show(" Sorry, This ID, " + textBox1.Text + " User Details Record is not Available.   ");
                        textBox1.Text = "";
                    }
                }
                catch (SqlException excep)
                {
                    MessageBox.Show(excep.Message);
                }
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Please provide age");
                errorProvider2.SetError(textBox1, "");
                errorProvider3.SetError(textBox1, "");
            }
            else
            {
                Regex numberchk = new Regex(@"^([0-9]*|\d*)$");
                if (numberchk.IsMatch(textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "");
                    errorProvider2.SetError(textBox1, "");
                    errorProvider3.SetError(textBox1, "Correct");
                }
                else
                {
                    errorProvider1.SetError(textBox1, "");
                    errorProvider2.SetError(textBox1, "Wrong format");
                    errorProvider3.SetError(textBox1, "");
                }
            }
        }
    }
}

