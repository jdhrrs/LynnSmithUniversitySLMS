namespace LynnSmithUniversitySLMS
{
    partial class Dashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnRegisterForClass;
        private System.Windows.Forms.Button btnApplyToUniversity; // Add Apply button

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
            this.btnRegisterForClass = new System.Windows.Forms.Button();
            this.btnApplyToUniversity = new System.Windows.Forms.Button(); // Initialize Apply button
            this.SuspendLayout();

            // btnRegisterForClass
            this.btnRegisterForClass.Location = new System.Drawing.Point(50, 100);
            this.btnRegisterForClass.Name = "btnRegisterForClass";
            this.btnRegisterForClass.Size = new System.Drawing.Size(150, 30);
            this.btnRegisterForClass.TabIndex = 0;
            this.btnRegisterForClass.Text = "Register for Class";
            this.btnRegisterForClass.UseVisualStyleBackColor = true;
            this.btnRegisterForClass.Click += new System.EventHandler(this.btnRegisterForClass_Click);

            // btnApplyToUniversity
            this.btnApplyToUniversity.Location = new System.Drawing.Point(50, 150); // Position Apply button below Register
            this.btnApplyToUniversity.Name = "btnApplyToUniversity";
            this.btnApplyToUniversity.Size = new System.Drawing.Size(150, 30);
            this.btnApplyToUniversity.TabIndex = 1;
            this.btnApplyToUniversity.Text = "Apply to University";
            this.btnApplyToUniversity.UseVisualStyleBackColor = true;
            this.btnApplyToUniversity.Click += new System.EventHandler(this.btnApplyToUniversity_Click);

            // Dashboard
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300); // Increased height
            this.Controls.Add(this.btnRegisterForClass);
            this.Controls.Add(this.btnApplyToUniversity); // Add Apply button to form
            this.Name = "Dashboard";
            this.Text = "Student Dashboard";
            this.ResumeLayout(false);
        }
    }
}
