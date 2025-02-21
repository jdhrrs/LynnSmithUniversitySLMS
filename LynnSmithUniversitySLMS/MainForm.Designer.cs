namespace LynnSmithUniversitySLMS
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnFaculty;
        private System.Windows.Forms.Button btnStudent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnFaculty = new System.Windows.Forms.Button();
            this.btnStudent = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Label Title
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(60, 30);
            this.lblTitle.Text = "Lynn Smith University SLMS";

            // Administrator Button
            this.btnAdmin.Location = new System.Drawing.Point(100, 80);
            this.btnAdmin.Size = new System.Drawing.Size(200, 40);
            this.btnAdmin.Text = "Administrator";
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);

            // Faculty Button
            this.btnFaculty.Location = new System.Drawing.Point(100, 140);
            this.btnFaculty.Size = new System.Drawing.Size(200, 40);
            this.btnFaculty.Text = "Faculty";
            this.btnFaculty.Click += new System.EventHandler(this.btnFaculty_Click);

            // Student Button
            this.btnStudent.Location = new System.Drawing.Point(100, 200);
            this.btnStudent.Size = new System.Drawing.Size(200, 40);
            this.btnStudent.Text = "Student";
            this.btnStudent.Click += new System.EventHandler(this.btnStudent_Click);

            // MainForm
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnFaculty);
            this.Controls.Add(this.btnStudent);
            this.Text = "Landing Page";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
