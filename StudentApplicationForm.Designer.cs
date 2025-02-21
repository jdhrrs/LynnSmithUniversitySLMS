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
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(20, 20);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(84, 21);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Full Name:";
            // 
            // fullNameTextBox
            // 
            fullNameTextBox.Location = new Point(150, 20);
            fullNameTextBox.Name = "fullNameTextBox";
            fullNameTextBox.Size = new Size(200, 29);
            fullNameTextBox.TabIndex = 1;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(20, 50);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(51, 21);
            emailLabel.TabIndex = 2;
            emailLabel.Text = "Email:";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(150, 50);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(200, 29);
            emailTextBox.TabIndex = 3;
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new Point(20, 80);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(69, 21);
            addressLabel.TabIndex = 4;
            addressLabel.Text = "Address:";
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(150, 80);
            addressTextBox.Name = "addressTextBox";
            addressTextBox.Size = new Size(200, 29);
            addressTextBox.TabIndex = 5;
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new Point(20, 110);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new Size(40, 21);
            cityLabel.TabIndex = 6;
            cityLabel.Text = "City:";
            // 
            // cityTextBox
            // 
            cityTextBox.Location = new Point(150, 110);
            cityTextBox.Name = "cityTextBox";
            cityTextBox.Size = new Size(200, 29);
            cityTextBox.TabIndex = 7;
            // 
            // stateLabel
            // 
            stateLabel.AutoSize = true;
            stateLabel.Location = new Point(20, 140);
            stateLabel.Name = "stateLabel";
            stateLabel.Size = new Size(47, 21);
            stateLabel.TabIndex = 8;
            stateLabel.Text = "State:";
            // 
            // stateTextBox
            // 
            stateTextBox.Location = new Point(150, 140);
            stateTextBox.Name = "stateTextBox";
            stateTextBox.Size = new Size(50, 29);
            stateTextBox.TabIndex = 9;
            // 
            // zipLabel
            // 
            zipLabel.AutoSize = true;
            zipLabel.Location = new Point(220, 140);
            zipLabel.Name = "zipLabel";
            zipLabel.Size = new Size(35, 21);
            zipLabel.TabIndex = 10;
            zipLabel.Text = "ZIP:";
            // 
            // zipTextBox
            // 
            zipTextBox.Location = new Point(260, 140);
            zipTextBox.Name = "zipTextBox";
            zipTextBox.Size = new Size(90, 29);
            zipTextBox.TabIndex = 11;
            // 
            // highSchoolLabel
            // 
            highSchoolLabel.AutoSize = true;
            highSchoolLabel.Location = new Point(20, 170);
            highSchoolLabel.Name = "highSchoolLabel";
            highSchoolLabel.Size = new Size(97, 21);
            highSchoolLabel.TabIndex = 12;
            highSchoolLabel.Text = "High School:";
            // 
            // highSchoolTextBox
            // 
            highSchoolTextBox.Location = new Point(150, 170);
            highSchoolTextBox.Name = "highSchoolTextBox";
            highSchoolTextBox.Size = new Size(200, 29);
            highSchoolTextBox.TabIndex = 13;
            // 
            // hsContactLabel
            // 
            hsContactLabel.AutoSize = true;
            hsContactLabel.Location = new Point(20, 200);
            hsContactLabel.Name = "hsContactLabel";
            hsContactLabel.Size = new Size(121, 21);
            hsContactLabel.TabIndex = 14;
            hsContactLabel.Text = "HS Contact Info:";
            // 
            // hsContactTextBox
            // 
            hsContactTextBox.Location = new Point(150, 200);
            hsContactTextBox.Name = "hsContactTextBox";
            hsContactTextBox.Size = new Size(200, 29);
            hsContactTextBox.TabIndex = 15;
            // 
            // uploadButton
            // 
            uploadButton.Location = new Point(150, 230);
            uploadButton.Name = "uploadButton";
            uploadButton.Size = new Size(120, 30);
            uploadButton.TabIndex = 16;
            uploadButton.Text = "Upload Document";
            uploadButton.Click += uploadButton_Click;
            // 
            // submitButton
            // 
            submitButton.Location = new Point(150, 300);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(120, 30);
            submitButton.TabIndex = 18;
            submitButton.Text = "Submit Application";
            submitButton.Click += submitButton_Click;
            // 
            // fileStatusLabel
            // 
            fileStatusLabel.AutoSize = true;
            fileStatusLabel.Location = new Point(150, 270);
            fileStatusLabel.Name = "fileStatusLabel";
            fileStatusLabel.Size = new Size(0, 21);
            fileStatusLabel.TabIndex = 17;
            // 
            // StudentApplicationForm
            // 
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
            Load += StudentApplicationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
