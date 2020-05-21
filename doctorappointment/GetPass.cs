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
    public partial class GetPass : Form
    {
        public GetPass()
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
            
            if (comboBox1.SelectedIndex == 1)
            {
                SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\User\Source\Repos\TIS147570\doctorappointmentsol1\doctorappointment\appnt.mdf; Integrated Security = True");
                con.Open();

                if (textBox1.Text != "")
                {
                    try
                    {
                        string getCust = "select pass from user1 where name = '" + textBox1.Text + "' and mobile = '" + textBox2.Text + "'";

                        SqlCommand cmd = new SqlCommand(getCust, con);
                        SqlDataReader dr;
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {

                            
                            textBox3.Text = dr.GetValue(0).ToString();
                           

                        }
                        else
                        {
                            MessageBox.Show(" Enter Correct Input");
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
           else if (comboBox1.SelectedIndex == 0)
            {
                SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\User\Source\Repos\TIS147570\doctorappointmentsol1\doctorappointment\appnt.mdf; Integrated Security = True");
                con.Open();

                if (textBox1.Text != "")
                {
                    try
                    {
                        string getCust = "select pass from doctor where name = '" + textBox1.Text + "' and speciality = '" + textBox2.Text + "'";

                        SqlCommand cmd = new SqlCommand(getCust, con);
                        SqlDataReader dr;
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {


                            textBox3.Text = dr.GetValue(0).ToString();


                        }
                        else
                        {
                            MessageBox.Show(" Enter Correct Input");
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
            else
            {
                MessageBox.Show("Select User Please");
            }
        }
    }
    }

        
