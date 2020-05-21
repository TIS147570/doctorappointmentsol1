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
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
        }



        private void Appointment_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\User\Source\Repos\TIS147570\doctorappointmentsol1\doctorappointment\appnt.mdf; Integrated Security = True");
            con.Open();
            string str1 = "select max(id) from appointment;";

            SqlCommand cmd1 = new SqlCommand(str1, con);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    textBox1.Text = "1";
                }
                else
                {
                    int a;
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    textBox1.Text = a.ToString();
                }
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\User\Source\Repos\TIS147570\doctorappointmentsol1\doctorappointment\appnt.mdf; Integrated Security = True");
            con.Open();
            string gen = string.Empty;
           
            
                try
                {
                    string str2 = "INSERT INTO appointment(cate,did,date,time,p_id,p_name) VALUES('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "'); ";

                    SqlCommand cmd2 = new SqlCommand(str2, con);
                    cmd2.ExecuteNonQuery();

                    string str1 = "select max(Id) from appointment;";

                    SqlCommand cmd1 = new SqlCommand(str1, con);
                    SqlDataReader da = cmd1.ExecuteReader();
                    if (da.Read())
                    {
                        MessageBox.Show("Inserted Appointment Information Successfully..");
                        textBox2.Text = "";
                        textBox4.Text = "";
                        textBox3.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";


                    }
                    // dr.Close();
                }
                catch (SqlException excep)
                {
                    MessageBox.Show(excep.Message);
                }
            
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                errorProvider1.SetError(textBox2, "Please Enter A Category");
                errorProvider2.SetError(textBox2, "");
                errorProvider3.SetError(textBox2, "");
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
                errorProvider2.SetError(textBox2, "");
                errorProvider3.SetError(textBox2, "Correct");
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {

            if (textBox3.Text == string.Empty)
            {
                errorProvider1.SetError(textBox3, "Please Enter Doctor's Id");
                errorProvider2.SetError(textBox3, "");
                errorProvider3.SetError(textBox3, "");
            }
            else
            {
                Regex numberchk = new Regex(@"^([0-9]*|\d*)$");
                if (numberchk.IsMatch(textBox3.Text))
                {
                    errorProvider1.SetError(textBox3, "");
                    errorProvider2.SetError(textBox3, "");
                    errorProvider3.SetError(textBox3, "Correct");
                }
                else
                {
                    errorProvider1.SetError(textBox3, "");
                    errorProvider2.SetError(textBox3, "Wrong format");
                    errorProvider3.SetError(textBox3, "");
                }
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (textBox4.Text == string.Empty)
            {
                errorProvider1.SetError(textBox4, "Please Enter a Date");
                errorProvider2.SetError(textBox4, "");
                errorProvider3.SetError(textBox4, "");
            }
            else
            {
                errorProvider1.SetError(textBox4, "");
                errorProvider2.SetError(textBox4, "");
                errorProvider3.SetError(textBox4, "Correct");
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (textBox5.Text == string.Empty)
            {
                errorProvider1.SetError(textBox5, "Please Enter Preferred Time");
                errorProvider2.SetError(textBox5, "");
                errorProvider3.SetError(textBox5, "");
            }
            else
            {
                errorProvider1.SetError(textBox5, "");
                errorProvider2.SetError(textBox5, "");
                errorProvider3.SetError(textBox5, "Correct");
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {

            if (textBox6.Text == string.Empty)
            {
                errorProvider1.SetError(textBox6, "Please Provide Your Patient/User ID");
                errorProvider2.SetError(textBox6, "");
                errorProvider3.SetError(textBox6, "");
            }
            else
            {
                Regex numberchk = new Regex(@"^([0-9]*|\d*)$");
                if (numberchk.IsMatch(textBox6.Text))
                {
                    errorProvider1.SetError(textBox6, "");
                    errorProvider2.SetError(textBox6, "");
                    errorProvider3.SetError(textBox6, "Correct");
                }
                else
                {
                    errorProvider1.SetError(textBox6, "");
                    errorProvider2.SetError(textBox6, "Wrong format");
                    errorProvider3.SetError(textBox6, "");
                }
            }
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (textBox7.Text == string.Empty)
            {
                errorProvider1.SetError(textBox7, "Please Enter Patient Name");
                errorProvider2.SetError(textBox7, "");
                errorProvider3.SetError(textBox7, "");
            }
            else
            {
                errorProvider1.SetError(textBox7, "");
                errorProvider2.SetError(textBox7, "");
                errorProvider3.SetError(textBox7, "Correct");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeAdmin obj6 = new HomeAdmin();
            obj6.ShowDialog();
        }
    }
}
