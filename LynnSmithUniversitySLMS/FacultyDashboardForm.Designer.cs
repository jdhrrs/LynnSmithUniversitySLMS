namespace LynnSmithUniversitySLMS
{
    partial class FacultyDashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnManageRoster;

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
            btnManageRoster = new Button();
            SuspendLayout();
            // 
            // btnManageRoster
            // 
            btnManageRoster.Location = new Point(75, 162);
            btnManageRoster.Margin = new Padding(4, 5, 4, 5);
            btnManageRoster.Name = "btnManageRoster";
            btnManageRoster.Size = new Size(270, 48);
            btnManageRoster.TabIndex = 0;
            btnManageRoster.Text = "Load Course Roster";
            btnManageRoster.UseVisualStyleBackColor = true;
            btnManageRoster.Click += btnManageRoster_Click;
            // 
            // FacultyDashboardForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 404);
            Controls.Add(btnManageRoster);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FacultyDashboardForm";
            Text = "Faculty Dashboard";
            ResumeLayout(false);
        }
    }
}
