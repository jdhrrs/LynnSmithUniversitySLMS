using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LynnSmithUniversitySLMS
{
    public partial class LoginForm : Form
    {
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=LynnSmithUniversityDB;Trusted_Connection=True;";
        private int studentID; // Stores the logged-in student's ID
        private string userType;

        public LoginForm()
        {
            InitializeComponent();
        }

        // Fix: Ensure the login form initializes when using this constructor
        public LoginForm(string userType)
        {
            InitializeComponent();
            this.userType = userType;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string role;
            int userId;

            if (AuthenticateUser(username, password, out role, out userId))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();  // Hide the login form

                if (role == "Student")
                {
                    Dashboard studentDashboard = new Dashboard(userId);
                    studentDashboard.Show();
                }
                else if (role == "Administrator")
                {
                    AdminDashboardForm adminDashboard = new AdminDashboardForm();
                    adminDashboard.Show();
                }
                else if (role == "Faculty")
                {
                    FacultyDashboardForm facultyDashboard = new FacultyDashboardForm(userId);
                    facultyDashboard.Show();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AuthenticateUser(string username, string password, out string role, out int userId)
        {
            bool isAuthenticated = false;
            role = string.Empty;
            userId = 0;

            string query = "SELECT Id, Role FROM Users WHERE Username=@Username AND Password=@Password";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        userId = Convert.ToInt32(reader["Id"]);
                        role = reader["Role"].ToString();
                        isAuthenticated = true;
                    }
                }
            }
            return isAuthenticated;
        }
    }
}
