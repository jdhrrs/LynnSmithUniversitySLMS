using System;
using System.Windows.Forms;

namespace LynnSmithUniversitySLMS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
          
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            OpenLoginForm("Administrator");
        }

        private void btnFaculty_Click(object sender, EventArgs e)
        {
            OpenLoginForm("Faculty");
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            OpenLoginForm("Student");
        }

        private void OpenLoginForm(string userType)
        {
            LoginForm loginForm = new LoginForm(userType);
            loginForm.Show();
            this.Hide(); // Hide MainForm while login is active
        }
    }
}
