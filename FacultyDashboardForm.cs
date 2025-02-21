using System;
using System.Windows.Forms;

namespace LynnSmithUniversitySLMS
{
    public partial class FacultyDashboardForm : Form
    {
        private int facultyID; // Stores the logged-in faculty member's ID

        public FacultyDashboardForm(int facultyId)
        {
            InitializeComponent();
            facultyID = facultyId;

            // ✅ Debugging Message
            MessageBox.Show($"FacultyDashboardForm Loaded - Faculty ID: {facultyID}");

            if (facultyID <= 0)
            {
                MessageBox.Show("Invalid Faculty ID received!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnManageRoster_Click(object sender, EventArgs e)
        {
            if (facultyID <= 0)
            {
                MessageBox.Show("Cannot open Manage Roster - Invalid Faculty ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Opening ManageRosterForm with Faculty ID: {facultyID}");
            ManageRosterForm rosterForm = new ManageRosterForm(facultyID);
            rosterForm.Show();
        }
    }
}
