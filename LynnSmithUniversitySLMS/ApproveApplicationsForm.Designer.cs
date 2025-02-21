namespace LynnSmithUniversitySLMS
{
    partial class ApproveApplicationsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstApplications;
        private System.Windows.Forms.Button btnApproveApp;
        private System.Windows.Forms.Button btnDenyApp;

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
            this.lstApplications = new System.Windows.Forms.ListBox();
            this.btnApproveApp = new System.Windows.Forms.Button();
            this.btnDenyApp = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // lstApplications
            // 
            this.lstApplications.FormattingEnabled = true;
            this.lstApplications.ItemHeight = 20;
            this.lstApplications.Location = new System.Drawing.Point(20, 20);
            this.lstApplications.Name = "lstApplications";
            this.lstApplications.Size = new System.Drawing.Size(350, 200);
            this.lstApplications.TabIndex = 0;

            // 
            // btnApproveApp
            // 
            this.btnApproveApp.Location = new System.Drawing.Point(20, 240);
            this.btnApproveApp.Name = "btnApproveApp";
            this.btnApproveApp.Size = new System.Drawing.Size(160, 40);
            this.btnApproveApp.TabIndex = 1;
            this.btnApproveApp.Text = "Approve Application";
            this.btnApproveApp.UseVisualStyleBackColor = true;
            this.btnApproveApp.Click += new System.EventHandler(this.btnApproveApp_Click);

            // 
            // btnDenyApp
            // 
            this.btnDenyApp.Location = new System.Drawing.Point(210, 240);
            this.btnDenyApp.Name = "btnDenyApp";
            this.btnDenyApp.Size = new System.Drawing.Size(160, 40);
            this.btnDenyApp.TabIndex = 2;
            this.btnDenyApp.Text = "Deny Application";
            this.btnDenyApp.UseVisualStyleBackColor = true;
            this.btnDenyApp.Click += new System.EventHandler(this.btnDenyApp_Click);

            // 
            // ApproveApplicationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.btnDenyApp);
            this.Controls.Add(this.btnApproveApp);
            this.Controls.Add(this.lstApplications);
            this.Name = "ApproveApplicationsForm";
            this.Text = "Pending Applications";
            this.ResumeLayout(false);
        }
    }
}
