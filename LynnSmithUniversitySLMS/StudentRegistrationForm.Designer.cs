namespace LynnSmithUniversitySLMS
{
    partial class StudentRegistrationForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstCourses;
        private System.Windows.Forms.Button btnRegister;

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
            this.btnRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lstCourses
            this.lstCourses.FormattingEnabled = true;
            this.lstCourses.Location = new System.Drawing.Point(30, 30);
            this.lstCourses.Name = "lstCourses";
            this.lstCourses.Size = new System.Drawing.Size(240, 150);
            this.lstCourses.TabIndex = 0;

            // btnRegister
            this.btnRegister.Location = new System.Drawing.Point(90, 200);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(120, 30);
            this.btnRegister.TabIndex = 1;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // StudentRegistrationForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 250);
            this.Controls.Add(this.lstCourses);
            this.Controls.Add(this.btnRegister);
            this.Name = "StudentRegistrationForm";
            this.Text = "Student Course Registration";
            this.ResumeLayout(false);
        }
    }
}
