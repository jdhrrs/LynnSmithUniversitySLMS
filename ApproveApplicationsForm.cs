using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LynnSmithUniversitySLMS
{
    public partial class ApproveApplicationsForm : Form
    {
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=LynnSmithUniversityDB;Trusted_Connection=True;";

        public ApproveApplicationsForm()
        {
            InitializeComponent();
            LoadPendingApplications();
        }

        private void LoadPendingApplications()
        {
            lstApplications.Items.Clear();  // Clear previous data

            string query = @"
                SELECT ApplicationID, FullName, Email 
                FROM Applications
                WHERE Status = 'Pending'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lstApplications.Items.Add(new ApplicationItem
                        {
                            ApplicationID = reader["ApplicationID"].ToString(),
                            DisplayText = $"{reader["FullName"]} ({reader["Email"]})"
                        });
                    }
                }
            }

            // Show message if no applications are found
            if (lstApplications.Items.Count == 0)
            {
                MessageBox.Show("No pending applications.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnApproveApp_Click(object sender, EventArgs e)
        {
            if (lstApplications.SelectedItem != null)
            {
                ApplicationItem selectedApp = (ApplicationItem)lstApplications.SelectedItem;
                ApproveApplication(selectedApp.ApplicationID);
            }
        }

        private void btnDenyApp_Click(object sender, EventArgs e)
        {
            if (lstApplications.SelectedItem != null)
            {
                ApplicationItem selectedApp = (ApplicationItem)lstApplications.SelectedItem;
                DenyApplication(selectedApp.ApplicationID);
            }
        }

        private void ApproveApplication(string applicationID)
        {
            string query = @"
                UPDATE Applications 
                SET Status = 'Approved' 
                WHERE ApplicationID = @ApplicationID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Application approved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadPendingApplications();  // Refresh list after approval
        }

        private void DenyApplication(string applicationID)
        {
            string query = "DELETE FROM Applications WHERE ApplicationID = @ApplicationID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Application denied successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadPendingApplications();  // Refresh list after denial
        }
    }

    public class ApplicationItem
    {
        public string ApplicationID { get; set; }
        public string DisplayText { get; set; }

        public override string ToString()
        {
            return DisplayText; // This controls what appears in the ListBox
        }
    }
}
