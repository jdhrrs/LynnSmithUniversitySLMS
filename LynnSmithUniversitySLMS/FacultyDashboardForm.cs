using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LynnSmithUniversitySLMS
{
    public partial class FacultyDashboardForm : Form
    {
        private int facultyID;
        private string facultyUsername;
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=LynnSmithUniversityDB;Trusted_Connection=True;";

        public FacultyDashboardForm(int facultyId)
        {
            InitializeComponent();
            facultyID = facultyId;
            facultyUsername = GetFacultyUsername(facultyID);

            // ✅ Debugging Message
            MessageBox.Show($"FacultyDashboardForm Loaded - Faculty ID: {facultyID}, Username: {facultyUsername}");

            if (facultyID <= 0 || string.IsNullOrEmpty(facultyUsername))
            {
                MessageBox.Show("Invalid Faculty ID or Username received!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnManageRoster_Click(object sender, EventArgs e)
        {
            if (facultyID <= 0 || string.IsNullOrEmpty(facultyUsername))
            {
                MessageBox.Show("Cannot open Manage Roster - Invalid Faculty ID or Username!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Opening ManageRosterForm with Faculty ID: {facultyID}, Username: {facultyUsername}");
            ManageRosterForm rosterForm = new ManageRosterForm(facultyID, facultyUsername);
            rosterForm.Show();
        }

        private string GetFacultyUsername(int facultyId)
        {
            string username = "";
            string query = "SELECT Username FROM Users WHERE Id = @FacultyID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FacultyID", facultyId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        username = result.ToString();
                    }
                }
            }
            return username;
        }
    }
}
