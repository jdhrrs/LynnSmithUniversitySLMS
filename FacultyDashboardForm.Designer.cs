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
            this.btnManageRoster = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // btnManageRoster
            this.btnManageRoster.Location = new System.Drawing.Point(50, 100);
            this.btnManageRoster.Name = "btnManageRoster";
            this.btnManageRoster.Size = new System.Drawing.Size(180, 30);
            this.btnManageRoster.TabIndex = 0;
            this.btnManageRoster.Text = "Manage Course Roster";
            this.btnManageRoster.UseVisualStyleBackColor = true;
            this.btnManageRoster.Click += new System.EventHandler(this.btnManageRoster_Click);

            // FacultyDashboardForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 250);
            this.Controls.Add(this.btnManageRoster);
            this.Name = "FacultyDashboardForm";
            this.Text = "Faculty Dashboard";
            this.ResumeLayout(false);
        }
    }
}
