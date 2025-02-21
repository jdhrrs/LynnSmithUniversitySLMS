namespace LynnSmithUniversitySLMS
{
    partial class AdminDashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnManageRequests;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnPrintReport; // ✅ Print button added
        private System.Windows.Forms.Button btnPendingApplications;
        private System.Windows.Forms.DataGridView dataGridViewReport;

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
            btnManageRequests = new Button();
            btnGenerateReport = new Button();
            btnPrintReport = new Button();
            btnPendingApplications = new Button();
            dataGridViewReport = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport).BeginInit();
            SuspendLayout();
            // 
            // btnManageRequests
            // 
            btnManageRequests.Location = new Point(86, 64);
            btnManageRequests.Margin = new Padding(4, 5, 4, 5);
            btnManageRequests.Name = "btnManageRequests";
            btnManageRequests.Size = new Size(270, 48);
            btnManageRequests.TabIndex = 0;
            btnManageRequests.Text = "Approve/Deny Registrations";
            btnManageRequests.UseVisualStyleBackColor = true;
            btnManageRequests.Click += btnManageRequests_Click;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Location = new Point(430, 223);
            btnGenerateReport.Margin = new Padding(4, 5, 4, 5);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(146, 58);
            btnGenerateReport.TabIndex = 1;
            btnGenerateReport.Text = "Generate Progress Report";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // btnPrintReport
            // 
            btnPrintReport.Location = new Point(883, 223);
            btnPrintReport.Margin = new Padding(4, 5, 4, 5);
            btnPrintReport.Name = "btnPrintReport";
            btnPrintReport.Size = new Size(136, 58);
            btnPrintReport.TabIndex = 3;
            btnPrintReport.Text = "Print Progress Report";
            btnPrintReport.UseVisualStyleBackColor = true;
            btnPrintReport.Click += btnPrintReport_Click;
            // 
            // btnPendingApplications
            // 
            btnPendingApplications.Location = new Point(86, 179);
            btnPendingApplications.Margin = new Padding(4, 5, 4, 5);
            btnPendingApplications.Name = "btnPendingApplications";
            btnPendingApplications.Size = new Size(270, 48);
            btnPendingApplications.TabIndex = 4;
            btnPendingApplications.Text = "Pending Applications";
            btnPendingApplications.UseVisualStyleBackColor = true;
            btnPendingApplications.Click += btnPendingApplications_Click;
            // 
            // dataGridViewReport
            // 
            dataGridViewReport.Location = new Point(393, 21);
            dataGridViewReport.Name = "dataGridViewReport";
            dataGridViewReport.Size = new Size(645, 180);
            dataGridViewReport.TabIndex = 5;
            // 
            // AdminDashboardForm
            // 
            ClientSize = new Size(1050, 888);
            Controls.Add(btnManageRequests);
            Controls.Add(btnGenerateReport);
            Controls.Add(btnPrintReport);
            Controls.Add(btnPendingApplications);
            Controls.Add(dataGridViewReport);
            Name = "AdminDashboardForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport).EndInit();
            ResumeLayout(false);
        }
    }
}
