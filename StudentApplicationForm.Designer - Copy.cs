namespace LynnSmithUniversitySLMS
{
    partial class StudentApplicationForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox fullNameTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.TextBox stateTextBox;
        private System.Windows.Forms.Label zipLabel;
        private System.Windows.Forms.TextBox zipTextBox;
        private System.Windows.Forms.Label highSchoolLabel;
        private System.Windows.Forms.TextBox highSchoolTextBox;
        private System.Windows.Forms.Label hsContactLabel;
        private System.Windows.Forms.TextBox hsContactTextBox;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label fileStatusLabel;

        private void InitializeComponent()
        {
            nameLabel = new Label();
            fullNameTextBox = new TextBox();
            emailLabel = new Label();
            emailTextBox = new TextBox();
            addressLabel = new Label();
            addressTextBox = new TextBox();
            cityLabel = new Label();
            cityTextBox = new TextBox();
            stateLabel = new Label();
            stateTextBox = new TextBox();
            zipLabel = new Label();
            zipTextBox = new TextBox();
            highSchoolLabel = new Label();
            highSchoolTextBox = new TextBox();
            hsContactLabel = new Label();
            hsContactTextBox = new TextBox();
            uploadButton = new Button();
            submitButton = new Button();
            fileStatusLabel = new Label();
            SuspendLayout();

            // Name Label
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(20, 20);
            nameLabel.Text = "Full Name:";
            // Full Name TextBox
            fullNameTextBox.Location = new Point(150, 20);
            fullNameTextBox.Size = new Size(200, 20);
            // Email Label
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(20, 50);
            emailLabel.Text = "Email:";
            // Email TextBox
            emailTextBox.Location = new Point(150, 50);
            emailTextBox.Size = new Size(200, 20);
            // Address Label
            addressLabel.AutoSize = true;
            addressLabel.Location = new Point(20, 80);
            addressLabel.Text = "Address:";
            // Address TextBox
            addressTextBox.Location = new Point(150, 80);
            addressTextBox.Size = new Size(200, 20);
            // City Label
            cityLabel.AutoSize = true;
            cityLabel.Location = new Point(20, 110);
            cityLabel.Text = "City:";
            // City TextBox
            cityTextBox.Location = new Point(150, 110);
            cityTextBox.Size = new Size(200, 20);
            // State Label
            stateLabel.AutoSize = true;
            stateLabel.Location = new Point(20, 140);
            stateLabel.Text = "State:";
            // State TextBox
            stateTextBox.Location = new Point(150, 140);
            stateTextBox.Size = new Size(50, 20);
            // Zip Label
            zipLabel.AutoSize = true;
            zipLabel.Location = new Point(220, 140);
            zipLabel.Text = "ZIP:";
            // Zip TextBox
            zipTextBox.Location = new Point(260, 140);
            zipTextBox.Size = new Size(90, 20);
            // High School Label
            highSchoolLabel.AutoSize = true;
            highSchoolLabel.Location = new Point(20, 170);
            highSchoolLabel.Text = "High School:";
            // High School TextBox
            highSchoolTextBox.Location = new Point(150, 170);
            highSchoolTextBox.Size = new Size(200, 20);
            // High School Contact Label
            hsContactLabel.AutoSize = true;
            hsContactLabel.Location = new Point(20, 200);
            hsContactLabel.Text = "HS Contact Info:";
            // High School Contact TextBox
            hsContactTextBox.Location = new Point(150, 200);
            hsContactTextBox.Size = new Size(200, 20);
            // Upload Button
            uploadButton.Location = new Point(150, 230);
            uploadButton.Size = new Size(120, 30);
            uploadButton.Text = "Upload Document";
            uploadButton.Click += uploadButton_Click;
            // File Status Label
            fileStatusLabel.AutoSize = true;
            fileStatusLabel.Location = new Point(150, 270);
            fileStatusLabel.Size = new Size(150, 20);
            // Submit Button
            submitButton.Location = new Point(150, 300);
            submitButton.Size = new Size(120, 30);
            submitButton.Text = "Submit Application";
            submitButton.Click += submitButton_Click;
            // StudentApplicationForm
            ClientSize = new Size(400, 350);
            Controls.Add(nameLabel);
            Controls.Add(fullNameTextBox);
            Controls.Add(emailLabel);
            Controls.Add(emailTextBox);
            Controls.Add(addressLabel);
            Controls.Add(addressTextBox);
            Controls.Add(cityLabel);
            Controls.Add(cityTextBox);
            Controls.Add(stateLabel);
            Controls.Add(stateTextBox);
            Controls.Add(zipLabel);
            Controls.Add(zipTextBox);
            Controls.Add(highSchoolLabel);
            Controls.Add(highSchoolTextBox);
            Controls.Add(hsContactLabel);
            Controls.Add(hsContactTextBox);
            Controls.Add(uploadButton);
            Controls.Add(fileStatusLabel);
            Controls.Add(submitButton);
            Name = "StudentApplicationForm";
            Text = "University Application Form";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
