using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LynnSmithUniversitySLMS
{
    public partial class AdminDashboardForm : Form
    {
        private string connString = "Server=(localdb)\\MSSQLLocalDB;Database=LynnSmithUniversityDB;Trusted_Connection=True;";


        public AdminDashboardForm()
        {
            InitializeComponent();
        }

        private void btnManageRequests_Click(object sender, EventArgs e)
        {
            // Open the approval form
            ApproveRegistrationsForm approveForm = new ApproveRegistrationsForm();
            approveForm.Show();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                                e.EnrollmentID, 
                                s.FirstName + ' ' + s.LastName AS StudentName,  
                                c.CourseName, 
                                e.EnrollmentDate, 
                                COALESCE(sp.Grade, 'N/A') AS Grade, 
                                COALESCE(sp.GPA, 0) AS GPA
                            FROM Enrollments e
                            JOIN Students s ON e.StudentID = s.StudentID
                            JOIN Courses c ON e.CourseID = c.CourseID
                            LEFT JOIN StudentProgress sp ON e.StudentID = sp.StudentID AND e.CourseID = sp.CourseID
                            ORDER BY e.EnrollmentDate DESC;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }

                    // 🔹 Debugging: Check if Data is Retrieved
                    MessageBox.Show($"Rows Retrieved: {dt.Rows.Count}", "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No data found. Check database contents.", "Report Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // 🔹 Ensure DataGridView is Reset and Bound
                    dataGridViewReport.DataSource = null;
                    dataGridViewReport.AutoGenerateColumns = true;
                    dataGridViewReport.DataSource = dt;
                    dataGridViewReport.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void dataGridViewReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
