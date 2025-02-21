namespace LynnSmithUniversitySLMS
{
    partial class AdminDashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnManageRequests;
        private System.Windows.Forms.Button btnGenerateReport;  // ✅ Added
        private System.Windows.Forms.DataGridView dataGridViewReport; // ✅ Added

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
            btnGenerateReport.Location = new Point(86, 174);
            btnGenerateReport.Margin = new Padding(4, 5, 4, 5);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(270, 48);
            btnGenerateReport.TabIndex = 1;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // dataGridViewReport
            // 
            dataGridViewReport.Location = new Point(48, 296);
            dataGridViewReport.Margin = new Padding(4, 5, 4, 5);
            dataGridViewReport.Name = "dataGridViewReport";
            dataGridViewReport.Size = new Size(581, 314);
            dataGridViewReport.TabIndex = 2;
            dataGridViewReport.CellContentClick += dataGridViewReport_CellContentClick;
            // 
            // AdminDashboardForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 888);
            Controls.Add(btnManageRequests);
            Controls.Add(btnGenerateReport);
            Controls.Add(dataGridViewReport);
            Margin = new Padding(4, 5, 4, 5);
            Name = "AdminDashboardForm";
            Text = "Admin Dashboard";
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport).EndInit();
            ResumeLayout(false);
        }
    }
}
