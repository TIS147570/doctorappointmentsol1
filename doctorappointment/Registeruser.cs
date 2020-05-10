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

namespace doctorappointment
{
    public partial class Registeruser : Form
    {
        public Registeruser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\doctorappointmentsol\doctorappointment\appnt.mdf;Integrated Security=True");
            con.Open();
            
            string gen = string.Empty;

            try
            {
                string str = "INSERT INTO user1(name,mobile,addr,pass) VALUES('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "'); ";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

                string str1 = "select max(Id) from user1;";

                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Inserted New User Information Successfully..");
                    textBox2.Text = "";
                    textBox4.Text = "";
                    textBox3.Text = "";
                    textBox5.Text = "";
                    textBox1.Text = "";


                }
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";

        }

        private void Registeruser_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\doctorappointmentsol\doctorappointment\appnt.mdf;Integrated Security=True");
            con.Open();
            string str1 = "select max(id) from user1;";

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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj6 = new Form1();
            obj6.ShowDialog();
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                errorProvider1.SetError(textBox2, "Please Enter A Name");
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
                errorProvider1.SetError(textBox3, "Please Enter A Mobile Number");
                errorProvider2.SetError(textBox3, "");
                errorProvider3.SetError(textBox3, "");
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
                errorProvider2.SetError(textBox3, "");
                errorProvider3.SetError(textBox3, "Correct");
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (textBox4.Text == string.Empty)
            {
                errorProvider1.SetError(textBox4, "Please Enter An Address");
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
            if (textBox2.Text == string.Empty)
            {
                errorProvider1.SetError(textBox5, "Please Enter A Password");
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
    }
}
