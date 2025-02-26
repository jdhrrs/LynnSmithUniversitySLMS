using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LynnSmithUniversitySLMS
{
    public partial class StudentRegistrationForm : Form
    {
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=LynnSmithUniversityDB;Trusted_Connection=True;";
        private int studentID; // This should be set when the student logs in

        public StudentRegistrationForm(int studentId)
        {
            InitializeComponent();
            studentID = studentId;
            LoadCourses();
        }

        private void LoadCourses()
        {
            string query = "SELECT CourseID, CourseName, AvailableSeats FROM Courses WHERE AvailableSeats > 0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lstCourses.Items.Add(new CourseItem
                        {
                            CourseID = reader["CourseID"].ToString(),  // Ensure CourseID is treated as string
                            CourseName = $"{reader["CourseName"]} - Seats Left: {reader["AvailableSeats"]}"
                        });
                    }
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (lstCourses.SelectedItem != null)
            {
                CourseItem selectedCourse = (CourseItem)lstCourses.SelectedItem;
                RegisterStudent(studentID, selectedCourse.CourseID);
            }
        }

        private void RegisterStudent(int studentID, string courseID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Debugging: Show a message before executing the query
                    MessageBox.Show($"Attempting to insert StudentID: {studentID}, CourseID: {courseID}");

                    // Insert into PendingRegistrations instead of StudentCourses
                    string query = "INSERT INTO PendingRegistrations (StudentID, CourseID, Status) VALUES (@StudentID, @CourseID, 'Pending')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentID", studentID);
                        cmd.Parameters.AddWithValue("@CourseID", courseID);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Debugging: Show success or failure
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registration request submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error: No rows affected. Check query.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting registration: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool HasScheduleConflict(int studentID, string newCourseID)  // Changed newCourseID to string
        {
            string query = @"
                SELECT COUNT(*) FROM StudentCourses sc
                JOIN Courses c1 ON sc.CourseID = c1.CourseID
                JOIN Courses c2 ON c2.CourseID = @NewCourseID
                WHERE sc.StudentID = @StudentID
                AND (
                    (c1.StartTime < c2.EndTime AND c1.EndTime > c2.StartTime)  -- Overlapping times
                )";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@NewCourseID", newCourseID);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0; // True if there is a schedule conflict
                }
            }
        }

        private bool IsAlreadyEnrolled(int studentID, string courseID)
        {
            string query = "SELECT COUNT(*) FROM StudentCourses WHERE StudentID = @StudentID AND CourseID = @CourseID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@CourseID", courseID);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0; // True if the student is already in the course
                }
            }
        }


        public class CourseItem
        {
            public string CourseID { get; set; }  // Changed CourseID to string
            public string CourseName { get; set; }

            public override string ToString()
            {
                return CourseName; // This controls what appears in the ListBox
            }
        }
    }
}
