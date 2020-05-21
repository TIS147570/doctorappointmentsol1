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
    public partial class SearchDoctor : Form
    {
        public SearchDoctor()
        {
            InitializeComponent();
        }

        private void doctorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.doctorBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.appntDataSet);

        }

        private void SearchDoctor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'appntDataSet5.doctor' table. You can move, or remove it, as needed.
            this.doctorTableAdapter1.Fill(this.appntDataSet5.doctor);
            // TODO: This line of code loads data into the 'appntDataSet.doctor' table. You can move, or remove it, as needed.
            this.doctorTableAdapter.Fill(this.appntDataSet.doctor);
            using (SqlConnection con1 = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\User\Source\Repos\TIS147570\doctorappointmentsol1\doctorappointment\appnt.mdf; Integrated Security = True"))
            {

                string str2 = "SELECT * FROM doctor";
                SqlCommand cmd2 = new SqlCommand(str2, con1);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);

                doctorDataGridView.DataSource = new BindingSource(dt, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (SqlConnection con1 = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\User\Source\Repos\TIS147570\doctorappointmentsol1\doctorappointment\appnt.mdf; Integrated Security = True"))
            {

                string str2 = "SELECT * FROM doctor where id='" + textBox1.Text + "'";
                SqlCommand cmd2 = new SqlCommand(str2, con1);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);

                doctorDataGridView.DataSource = new BindingSource(dt, null);
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
            this.Hide();
            HomeUser obj6 = new HomeUser();
            obj6.ShowDialog();
        }
    }
}
