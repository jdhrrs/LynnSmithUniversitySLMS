using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace LynnSmithUniversitySLMS
{
    public partial class StudentApplicationForm : Form
    {
        private string documentPath = "";

        public StudentApplicationForm()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string fullName = fullNameTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim();

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Database connection
            string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LynnSmithUniversityDB;Integrated Security=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query = "INSERT INTO Applications (FullName, Email, DocumentPath, Status) VALUES (@FullName, @Email, @DocumentPath, 'Pending')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@DocumentPath", documentPath);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Application submitted successfully!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
            }
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files|*.pdf|Image Files|*.jpg;*.png|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string uploadFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ApplicationUploads");

                    // Ensure directory exists
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    string destinationPath = Path.Combine(uploadFolder, Path.GetFileName(openFileDialog.FileName));

                    File.Copy(openFileDialog.FileName, destinationPath, true);
                    documentPath = destinationPath;

                    MessageBox.Show("File uploaded successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File upload failed: " + ex.Message);
                }
            }
        }

        private void StudentApplicationForm_Load(object sender, EventArgs e)
        {
            // Form load logic if needed
        }
    }
}
