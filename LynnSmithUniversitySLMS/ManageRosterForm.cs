using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LynnSmithUniversitySLMS
{
    public partial class ManageRosterForm : Form
    {
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=LynnSmithUniversityDB;Trusted_Connection=True;";
        private int facultyID;
        private string facultyUsername;

        public ManageRosterForm(int facultyId, string username)
        {
            InitializeComponent();
            facultyID = facultyId;
            facultyUsername = username;

            MessageBox.Show($"ManageRosterForm Loaded - Faculty ID: {facultyID}, Username: {facultyUsername}");
            LoadFacultyCourses();
        }

        private void LoadFacultyCourses()
        {
            lstCourses.Items.Clear();

            string query = "SELECT CourseID, CourseName FROM Courses WHERE Instructor = @FacultyUsername";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FacultyUsername", facultyUsername);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int courseID = Convert.ToInt32(reader["CourseID"]);
                        string courseName = reader["CourseName"].ToString();
                        lstCourses.Items.Add(new CourseItem { CourseID = courseID, CourseName = courseName });
                    }
                }
            }
        }

        private void lstCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCourses.SelectedItem != null)
            {
                CourseItem selectedCourse = (CourseItem)lstCourses.SelectedItem;
                LoadRoster(selectedCourse.CourseID);
            }
        }

        private void LoadRoster(int courseID)
        {
            lstRoster.Items.Clear();

            string query = "SELECT s.StudentID, s.FirstName, s.LastName FROM Enrollments e JOIN Students s ON e.StudentID = s.StudentID WHERE e.CourseID = @CourseID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseID", courseID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int studentID = Convert.ToInt32(reader["StudentID"]);
                        string fullName = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                        lstRoster.Items.Add(new StudentItem { StudentID = studentID, FullName = fullName });
                    }
                }
            }
        }

        public class CourseItem
        {
            public int CourseID { get; set; }
            public string CourseName { get; set; }
            public override string ToString() { return CourseName; }
        }

        public class StudentItem
        {
            public int StudentID { get; set; }
            public string FullName { get; set; }
            public override string ToString() { return FullName; }
        }
    }
}
