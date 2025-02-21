namespace LynnSmithUniversitySLMS
{
    partial class ManageRosterForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstCourses;
        private System.Windows.Forms.ListBox lstRoster;

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
            this.lstCourses = new System.Windows.Forms.ListBox();
            this.lstRoster = new System.Windows.Forms.ListBox();
            this.SuspendLayout();

            // lstCourses
            this.lstCourses.FormattingEnabled = true;
            this.lstCourses.Location = new System.Drawing.Point(20, 20);
            this.lstCourses.Size = new System.Drawing.Size(260, 80);
            this.lstCourses.TabIndex = 0;
            this.lstCourses.SelectedIndexChanged += new System.EventHandler(this.lstCourses_SelectedIndexChanged);

            // lstRoster
            this.lstRoster.FormattingEnabled = true;
            this.lstRoster.Location = new System.Drawing.Point(20, 120);
            this.lstRoster.Size = new System.Drawing.Size(260, 100);
            this.lstRoster.TabIndex = 1;

            // ManageRosterForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 250);
            this.Controls.Add(this.lstCourses);
            this.Controls.Add(this.lstRoster);
            this.Name = "ManageRosterForm";
            this.Text = "Manage Course Roster";
            this.ResumeLayout(false);
        }
    }
}
