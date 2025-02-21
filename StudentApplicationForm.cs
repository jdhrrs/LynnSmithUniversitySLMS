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
            string fullName = fullNameTextBox.Text;
            string email = emailTextBox.Text;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            using (SqlConnection conn = new SqlConnection("your_connection_string"))
            {
                conn.Open();
                string query = "INSERT INTO Applications (FullName, Email, DocumentPath, Status) VALUES (@FullName, @Email, @DocumentPath, 'Pending')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@DocumentPath", documentPath);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Application submitted successfully!");
            }
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files|*.pdf|Image Files|*.jpg;*.png|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string destinationPath = Path.Combine("C:\\UniversityDocuments\\Applications", Path.GetFileName(openFileDialog.FileName));
                File.Copy(openFileDialog.FileName, destinationPath, true);
                documentPath = destinationPath;
                MessageBox.Show("File uploaded successfully!");
            }
        }
    }
}
