using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LynnSmithUniversitySLMS
{
    public partial class ManageRosterForm : Form
    {
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=LynnSmithUniversityDB;Trusted_Connection=True;";
        private int facultyID;

        public ManageRosterForm(int facultyId)
        {
            InitializeComponent();
            facultyID = facultyId;

            MessageBox.Show($"ManageRosterForm Loaded - Faculty ID: {facultyID}"); // ✅ Debugging
            LoadFacultyCourses();
        }
        private void LoadFacultyCourses()
        {
            lstCourses.Items.Clear();
            string facultyUsername = "";

            string usernameQuery = "SELECT Username FROM Users WHERE Id = @FacultyID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(usernameQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@FacultyID", facultyID);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        facultyUsername = result.ToString();
                        MessageBox.Show($"✅ Faculty Username Retrieved: {facultyUsername}"); // Debugging
                    }
                    else
                    {
                        MessageBox.Show("❌ No matching Faculty Username found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // 🔹 Debugging Course Retrieval
            string query = "SELECT CourseID, CourseName FROM Courses WHERE Instructor = @FacultyUsername";
            MessageBox.Show($"Executing SQL Query: \n{query} \nInstructor: {facultyUsername}");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FacultyUsername", facultyUsername);
                    SqlDataReader reader = cmd.ExecuteReader();
                    bool hasCourses = false;

                    while (reader.Read())
                    {
                        int courseID = Convert.ToInt32(reader["CourseID"]); // Ensure it's correctly converted
                        string courseName = reader["CourseName"].ToString();

                        MessageBox.Show($"✅ Course Retrieved: {courseName} (ID: {courseID})"); // Debugging

                        lstCourses.Items.Add(new CourseItem
                        {
                            CourseID = courseID,
                            CourseName = courseName
                        });

                        hasCourses = true;
                    }

                    if (!hasCourses)
                    {
                        MessageBox.Show("❌ No courses found for this faculty member.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void lstCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCourses.SelectedItem != null)
            {
                CourseItem selectedCourse = (CourseItem)lstCourses.SelectedItem;
                LoadRoster(selectedCourse.CourseID); // ✅ Now CourseID is an int, so this works
            }
        }

        private void LoadRoster(int courseID)
        {
            lstRoster.Items.Clear();
            MessageBox.Show($"🔍 Debug: Loading roster for Course ID: {courseID}"); // ✅ Debugging CourseID

            string query = @"
        SELECT u.Username 
        FROM Enrollments e
        JOIN Users u ON e.StudentID = u.Id
        WHERE e.CourseID = @CourseID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseID", courseID);
                    MessageBox.Show($"Executing SQL Query: \nSELECT u.Username FROM Enrollments JOIN Users ON Enrollments.StudentID = Users.Id WHERE Enrollments.CourseID = {courseID}"); // ✅ Debugging

                    SqlDataReader reader = cmd.ExecuteReader();

                    bool hasStudents = false;
                    while (reader.Read())
                    {
                        string studentName = reader["Username"].ToString();
                        MessageBox.Show($"✅ Found Student: {studentName}"); // ✅ Debugging Student Found
                        lstRoster.Items.Add(studentName);
                        hasStudents = true;
                    }

                    if (!hasStudents)
                    {
                        MessageBox.Show($"❌ No students found for Course ID: {courseID}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        public class CourseItem
        {
            public int CourseID { get; set; } // ✅ FIXED: Changed from string to int
            public string CourseName { get; set; }

            public override string ToString()
            {
                return CourseName;
            }
        }
    }
}
