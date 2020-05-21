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
    public partial class ViewUser : Form
    {
        public ViewUser()
        {
            InitializeComponent();
        }

        private void userBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.userBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.appntDataSet2);

        }

        private void ViewUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'appntDataSet2.user' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.appntDataSet2.user);
            using (SqlConnection con1 = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\User\Source\Repos\TIS147570\doctorappointmentsol1\doctorappointment\appnt.mdf; Integrated Security = True"))
            {

                string str2 = "SELECT * FROM user1";
                SqlCommand cmd2 = new SqlCommand(str2, con1);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);

                userDataGridView.DataSource = new BindingSource(dt, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con1 = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\User\Source\Repos\TIS147570\doctorappointmentsol1\doctorappointment\appnt.mdf; Integrated Security = True"))
            {

                string str2 = "SELECT * FROM user1 where id='" + textBox1.Text + "'";
                SqlCommand cmd2 = new SqlCommand(str2, con1);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);

                userDataGridView.DataSource = new BindingSource(dt, null);
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

            if (textBox1.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Please Enter Doctor's Id");
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text == string.Empty))
            {
                SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\User\Source\Repos\TIS147570\doctorappointmentsol1\doctorappointment\appnt.mdf; Integrated Security = True");
                
                string query = "Delete from user1 where Id= '" + this.textBox1.Text + "'";
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeAdmin obj2 = new doctorappointment.HomeAdmin();
            obj2.ShowDialog();
        }
    }
}
