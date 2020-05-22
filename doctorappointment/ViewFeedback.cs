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
    public partial class ViewFeedback : Form
    {
        public ViewFeedback()
        {
            InitializeComponent();
        }

        private void feedbackBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.feedbackBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.appntDataSet1);

        }

        private void ViewFeedback_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'appntDataSet1.feedback' table. You can move, or remove it, as needed.
            this.feedbackTableAdapter.Fill(this.appntDataSet1.feedback);
            using (SqlConnection con1 = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\User\Source\Repos\TIS147570\doctorappointmentsol1\doctorappointment\appnt.mdf; Integrated Security = True"))
            {

                string str2 = "SELECT * FROM feedback";
                SqlCommand cmd2 = new SqlCommand(str2, con1);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);

                feedbackDataGridView.DataSource = new BindingSource(dt, null);
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
