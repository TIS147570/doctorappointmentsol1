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
    public partial class UpdateAppointment : Form
    {
        public UpdateAppointment()
        {
            InitializeComponent();
        }

        private void appointmentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.appointmentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.appntDataSet6);

        }

        private void UpdateAppointment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'appntDataSet6.appointment' table. You can move, or remove it, as needed.
            this.appointmentTableAdapter.Fill(this.appntDataSet6.appointment);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\User\Source\Repos\TIS147570\doctorappointmentsol1\doctorappointment\appnt.mdf; Integrated Security = True");
            con.Open();
            if (textBox1.Text != "")
            {
                try
                {
                    string getCust = "select cate,did,date,time,p_id,p_name from appointment where id=" + Convert.ToInt32(textBox1.Text) + " ;";

                    SqlCommand cmd = new SqlCommand(getCust, con);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {

                        textBox2.Text = dr.GetValue(0).ToString();
                        textBox3.Text = dr.GetValue(1).ToString();
                        textBox4.Text = dr.GetValue(2).ToString();
                        textBox5.Text = dr.GetValue(3).ToString();
                        textBox6.Text = dr.GetValue(4).ToString();
                        textBox7.Text = dr.GetValue(5).ToString();

                    }
                    else
                    {
                        MessageBox.Show(" Sorry, This ID, " + textBox1.Text + " Appointment Details Record is not Available.   ");
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
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\User\Source\Repos\TIS147570\doctorappointmentsol1\doctorappointment\appnt.mdf; Integrated Security = True");
            con.Open();
            try
            {
                string str = " Update appointment set cate='" + textBox2.Text + "',did='" + textBox3.Text + "',date='" + textBox4.Text + "',time='" + textBox5.Text + "',p_id='" + textBox6.Text + "',p_name='" + textBox7.Text + "' where id='" + textBox1.Text + "'";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

                string str1 = "select max(id) from appointment;";

                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("" + textBox7.Text + "'s Appointment Details is Updated Successfully.. ", "Important Message");
                    textBox2.Text = "";
                    textBox4.Text = "";
                    textBox3.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox1.Text = "";
                    using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\documents\visual studio 2015\Projects\DoctorAppointmentBookingSystemCSharp\DoctorAppointmentBookingSystemCSharp\appnmt.mdf;Integrated Security=True"))
                    {
                        string str2 = "SELECT * FROM appoitment";
                        SqlCommand cmd2 = new SqlCommand(str2, con1);
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        appointmentDataGridView.DataSource = new BindingSource(dt, null);
                    }
                }
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeAdmin obj2 = new doctorappointment.HomeAdmin();
            obj2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text == string.Empty))
            {
                SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\User\Source\Repos\TIS147570\doctorappointmentsol1\doctorappointment\appnt.mdf; Integrated Security = True");

                string query = "Delete from appointment where Id= '" + this.textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader myreader;
                try
                {
                    con.Open();
                    myreader = cmd.ExecuteReader();
                    MessageBox.Show("successfully data Deleted", "user information");
                    while (myreader.Read())
                    {
                    }
                    con.Close();
                }
                catch (Exception ec)
                {
                    MessageBox.Show(ec.Message);
                }
            }
            else
            {
                MessageBox.Show("enter ID which you want to delete", "User information");
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Please Enter Your Id");
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

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                errorProvider1.SetError(textBox2, "Please Enter Category");
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
                errorProvider1.SetError(textBox3, "Please Enter A Doctor's ID");
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
                errorProvider1.SetError(textBox5, "Please Enter Appoint time");
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
                errorProvider1.SetError(textBox6, "Please Enter Patient Id/User Id");
                errorProvider2.SetError(textBox6, "");
                errorProvider3.SetError(textBox6, "");
            }
            else
            {
                errorProvider1.SetError(textBox6, "");
                errorProvider2.SetError(textBox6, "");
                errorProvider3.SetError(textBox6, "Correct");
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

        private void appointmentBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.appointmentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.appntDataSet6);

        }
    }
}
