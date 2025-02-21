using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LynnSmithUniversitySLMS
{
    public partial class ApproveRegistrationsForm : Form
    {
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=LynnSmithUniversityDB;Trusted_Connection=True;";

        public ApproveRegistrationsForm()
        {
            InitializeComponent();
            LoadPendingRequests();
        }

        private void LoadPendingRequests()
        {
            lstRequests.Items.Clear();  // Clear previous data

            string query = @"
                SELECT pr.RegistrationID, u.Username, c.CourseName 
                FROM PendingRegistrations pr
                JOIN Users u ON pr.StudentID = u.Id
                JOIN Courses c ON pr.CourseID = c.CourseID
                WHERE pr.Status = 'Pending'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lstRequests.Items.Add(new RequestItem
                        {
                            RequestID = reader["RegistrationID"].ToString(), // ✅ Fixed column name
                            DisplayText = $"{reader["Username"]} requested {reader["CourseName"]}"
                        });
                    }
                }
            }

            // If no requests, show a message
            if (lstRequests.Items.Count == 0)
            {
                MessageBox.Show("No pending registration requests.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (lstRequests.SelectedItem != null)
            {
                RequestItem selectedRequest = (RequestItem)lstRequests.SelectedItem;
                ApproveRequest(selectedRequest.RequestID);
            }
        }

        private void btnDeny_Click(object sender, EventArgs e)
        {
            if (lstRequests.SelectedItem != null)
            {
                RequestItem selectedRequest = (RequestItem)lstRequests.SelectedItem;
                DenyRequest(selectedRequest.RequestID);
            }
        }

        private void ApproveRequest(string requestID)
        {
            string query = @"
                DECLARE @StudentID INT, @CourseID INT;
                SELECT @StudentID = StudentID, @CourseID = CourseID 
                FROM PendingRegistrations 
                WHERE RegistrationID = @RequestID;

                -- Insert into StudentCourses
                INSERT INTO StudentCourses (StudentID, CourseID) VALUES (@StudentID, @CourseID);

                -- Remove from PendingRegistrations
                DELETE FROM PendingRegistrations WHERE RegistrationID = @RequestID;
            ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RequestID", requestID);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Request approved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadPendingRequests();  // Refresh list after approval
        }

        private void DenyRequest(string requestID)
        {
            string query = "DELETE FROM PendingRegistrations WHERE RegistrationID = @RequestID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RequestID", requestID);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Request denied successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadPendingRequests();  // Refresh list after denial
        }
    }

    public class RequestItem
    {
        public string RequestID { get; set; }
        public string DisplayText { get; set; }

        public override string ToString()
        {
            return DisplayText; // This controls what appears in the ListBox
        }
    }
}
