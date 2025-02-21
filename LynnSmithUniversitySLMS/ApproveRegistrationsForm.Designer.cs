namespace LynnSmithUniversitySLMS
{
    partial class ApproveRegistrationsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstRequests;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnDeny;

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
            this.lstRequests = new System.Windows.Forms.ListBox();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnDeny = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lstRequests
            this.lstRequests.FormattingEnabled = true;
            this.lstRequests.Location = new System.Drawing.Point(20, 20);
            this.lstRequests.Size = new System.Drawing.Size(260, 120);
            this.lstRequests.TabIndex = 0;

            // btnApprove
            this.btnApprove.Location = new System.Drawing.Point(20, 150);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(100, 30);
            this.btnApprove.TabIndex = 1;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);

            // btnDeny
            this.btnDeny.Location = new System.Drawing.Point(180, 150);
            this.btnDeny.Name = "btnDeny";
            this.btnDeny.Size = new System.Drawing.Size(100, 30);
            this.btnDeny.TabIndex = 2;
            this.btnDeny.Text = "Deny";
            this.btnDeny.UseVisualStyleBackColor = true;
            this.btnDeny.Click += new System.EventHandler(this.btnDeny_Click);

            // ApproveRegistrationsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.lstRequests);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnDeny);
            this.Name = "ApproveRegistrationsForm";
            this.Text = "Approve Registrations";
            this.ResumeLayout(false);
        }
    }
}
