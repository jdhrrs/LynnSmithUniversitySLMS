using System;
using System.Windows.Forms;

namespace LynnSmithUniversitySLMS
{
    public partial class Dashboard : Form
    {
        private int studentID;

        public Dashboard(int studentId)
        {
            InitializeComponent();
            studentID = studentId; // Store student ID for registration
        }

        private void btnRegisterForClass_Click(object sender, EventArgs e)
        {
            StudentRegistrationForm registrationForm = new StudentRegistrationForm(studentID);
            registrationForm.Show();
        }

        private void btnApplyToUniversity_Click(object sender, EventArgs e)
        {
            StudentApplicationForm applicationForm = new StudentApplicationForm();
            applicationForm.Show();
        }
    }
}
