namespace LynnSmithUniversitySLMS
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblUserType;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;

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
            this.lblUserType = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Label UserType
            this.lblUserType.AutoSize = true;
            this.lblUserType.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblUserType.Location = new System.Drawing.Point(120, 20);
            this.lblUserType.Text = "Login";

            // Label Username
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(50, 60);
            this.lblUsername.Text = "Username:";

            // TextBox Username
            this.txtUsername.Location = new System.Drawing.Point(140, 60);
            this.txtUsername.Size = new System.Drawing.Size(180, 20);

            // Label Password
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(50, 100);
            this.lblPassword.Text = "Password:";

            // TextBox Password
            this.txtPassword.Location = new System.Drawing.Point(140, 100);
            this.txtPassword.Size = new System.Drawing.Size(180, 20);
            this.txtPassword.UseSystemPasswordChar = true;

            // Login Button
            this.btnLogin.Location = new System.Drawing.Point(50, 140);
            this.btnLogin.Size = new System.Drawing.Size(100, 30);
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // Cancel Button
            this.btnCancel.Location = new System.Drawing.Point(180, 140);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Text = "Cancel";

            // LoginForm
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.lblUserType);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnCancel);
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
