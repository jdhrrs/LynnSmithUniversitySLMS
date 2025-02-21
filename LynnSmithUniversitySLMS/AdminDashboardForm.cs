using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace LynnSmithUniversitySLMS
{
    public partial class AdminDashboardForm : Form
    {
        private string connString = "Server=(localdb)\\MSSQLLocalDB;Database=LynnSmithUniversityDB;Trusted_Connection=True;";
        private PrintDocument printDocument = new PrintDocument();
        private DataTable reportTable; // Stores report data for printing

        public AdminDashboardForm()
        {
            InitializeComponent();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }

        private void btnManageRequests_Click(object sender, EventArgs e)
        {
            ApproveRegistrationsForm approveForm = new ApproveRegistrationsForm();
            approveForm.Show();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            reportTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                                e.EnrollmentID, 
                                s.FirstName + ' ' + s.LastName AS StudentName,  
                                c.CourseName, 
                                e.EnrollmentDate, 
                                COALESCE(sp.Grade, 'N/A') AS Grade, 
                                COALESCE(sp.GPA, 0) AS GPA
                            FROM Enrollments e
                            JOIN Students s ON e.StudentID = s.StudentID
                            JOIN Courses c ON e.CourseID = c.CourseID
                            LEFT JOIN StudentProgress sp ON e.StudentID = sp.StudentID AND e.CourseID = sp.CourseID
                            ORDER BY e.EnrollmentDate DESC;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(reportTable);
                    }

                    if (reportTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No data found. Check database contents.", "Report Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    dataGridViewReport.DataSource = null;
                    dataGridViewReport.AutoGenerateColumns = true;
                    dataGridViewReport.DataSource = reportTable;
                    dataGridViewReport.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            if (reportTable == null || reportTable.Rows.Count == 0)
            {
                MessageBox.Show("No reports available to print.");
                return;
            }

            MessageBox.Show("Print button clicked! Starting print process...", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PrintDialog printDialog = new PrintDialog
            {
                Document = printDocument
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 10);
            float yPos = e.MarginBounds.Top;
            float xPos = e.MarginBounds.Left;
            int rowHeight = 20;
            int columnSpacing = 100;

            foreach (DataColumn col in reportTable.Columns)
            {
                e.Graphics.DrawString(col.ColumnName, font, Brushes.Black, xPos, yPos);
                xPos += columnSpacing;
            }

            yPos += rowHeight;

            foreach (DataRow row in reportTable.Rows)
            {
                xPos = e.MarginBounds.Left;
                foreach (DataColumn col in reportTable.Columns)
                {
                    string text = row[col].ToString();
                    e.Graphics.DrawString(text, font, Brushes.Black, xPos, yPos);
                    xPos += columnSpacing;
                }
                yPos += rowHeight;

                if (yPos + rowHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
        }

        private void btnPendingApplications_Click(object sender, EventArgs e)
        {
            ApproveApplicationsForm approveApplicationsForm = new ApproveApplicationsForm();
            approveApplicationsForm.Show();
        }

        private void dataGridViewReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
