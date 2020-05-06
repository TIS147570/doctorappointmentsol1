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
            // TODO: This line of code loads data into the 'appntDataSet.doctor' table. You can move, or remove it, as needed.
            this.doctorTableAdapter.Fill(this.appntDataSet.doctor);
            using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\doctorappointmentsol\doctorappointment\appnt.mdf;Integrated Security=True"))
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

            using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\doctorappointmentsol\doctorappointment\appnt.mdf;Integrated Security=True"))
            {

                string str2 = "SELECT * FROM doctor where id='" + textBox1.Text + "'";
                SqlCommand cmd2 = new SqlCommand(str2, con1);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);

                doctorDataGridView.DataSource = new BindingSource(dt, null);
            }
        }
    }
}
