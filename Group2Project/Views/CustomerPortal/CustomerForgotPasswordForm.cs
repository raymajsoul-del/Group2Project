using System;
using System.Drawing;
using System.Windows.Forms;

namespace Group2Project.Views.CustomerPortal
{
    public partial class CustomerForgotPasswordForm : Form
    {
        private TextBox txtCustomerId, txtPhone, txtEmail;
        private Label lblTitle, lblCustomerId, lblPhone, lblEmail;
        private Button btnConfirmReset;

        private Color colorBrandOrange = Color.FromArgb(230, 126, 34);
        private Color colorLightGray = Color.FromArgb(245, 245, 245);
        private Color colorTextDark = Color.FromArgb(50, 50, 50);
        private Color colorTextGray = Color.FromArgb(120, 120, 120);

        private LoginForm parentLoginForm;

        public CustomerForgotPasswordForm(LoginForm parentForm)
        {
            parentLoginForm = parentForm;
            InitializeComponent();
            SetupUI();
        }

        private void InitializeComponent()
        {
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void SetupUI()
        {
            this.Text = "Better Limited (Reset Password)";
            this.ClientSize = new Size(800, 600);
            this.BackColor = colorLightGray;

            // Back button (orange circle with arrow)
            Button btnBack = new Button
            {
                Text = "◀",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = colorBrandOrange,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(40, 40),
                Location = new Point(20, 20),
                Cursor = Cursors.Hand
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Click += (s, e) =>
            {
                this.Close();
                parentLoginForm.Show();
            };

            // Title "Reset Password"
            lblTitle = new Label
            {
                Text = "Reset Password",
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = colorBrandOrange,
                AutoSize = true,
                Location = new Point(280, 40)
            };

            // Customer ID label
            lblCustomerId = new Label
            {
                Text = "Customer ID",
                Font = new Font("Segoe UI", 11),
                ForeColor = colorTextDark,
                AutoSize = true,
                Location = new Point(230, 130)
            };

            // Customer ID textbox
            Panel pnlCustomerId = new Panel
            {
                BackColor = Color.White,
                Size = new Size(400, 45),
                Location = new Point(230, 150),
                BorderStyle = BorderStyle.FixedSingle
            };

            txtCustomerId = new TextBox
            {
                Font = new Font("Segoe UI", 12),
                ForeColor = colorTextDark,
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Location = new Point(15, 12),
                Width = 370
            };
            pnlCustomerId.Controls.Add(txtCustomerId);

            // Phone Number label
            lblPhone = new Label
            {
                Text = "Phone Number",
                Font = new Font("Segoe UI", 11),
                ForeColor = colorTextDark,
                AutoSize = true,
                Location = new Point(230, 210)
            };

            // Phone Number textbox
            Panel pnlPhone = new Panel
            {
                BackColor = Color.White,
                Size = new Size(400, 45),
                Location = new Point(230, 230),
                BorderStyle = BorderStyle.FixedSingle
            };

            txtPhone = new TextBox
            {
                Font = new Font("Segoe UI", 12),
                ForeColor = colorTextDark,
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Location = new Point(15, 12),
                Width = 370
            };
            pnlPhone.Controls.Add(txtPhone);

            // Email label
            lblEmail = new Label
            {
                Text = "Email Address",
                Font = new Font("Segoe UI", 11),
                ForeColor = colorTextDark,
                AutoSize = true,
                Location = new Point(230, 290)
            };

            // Email textbox
            Panel pnlEmail = new Panel
            {
                BackColor = Color.White,
                Size = new Size(400, 45),
                Location = new Point(230, 310),
                BorderStyle = BorderStyle.FixedSingle
            };

            txtEmail = new TextBox
            {
                Font = new Font("Segoe UI", 12),
                ForeColor = colorTextDark,
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Location = new Point(15, 12),
                Width = 370
            };
            pnlEmail.Controls.Add(txtEmail);

            // Confirm Reset button
            btnConfirmReset = new Button
            {
                Text = "Confirm Reset",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                BackColor = colorBrandOrange,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(160, 42),
                Location = new Point(320, 400),
                Cursor = Cursors.Hand
            };
            btnConfirmReset.FlatAppearance.BorderSize = 0;
            btnConfirmReset.Click += BtnConfirmReset_Click;

            this.Controls.Add(btnBack);
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblCustomerId);
            this.Controls.Add(pnlCustomerId);
            this.Controls.Add(lblPhone);
            this.Controls.Add(pnlPhone);
            this.Controls.Add(lblEmail);
            this.Controls.Add(pnlEmail);
            this.Controls.Add(btnConfirmReset);
        }

        private void BtnConfirmReset_Click(object sender, EventArgs e)
        {
            string customerId = txtCustomerId.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(customerId) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter Customer ID, Phone Number, and Email Address.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Call LoginController to process customer password reset
            Controllers.LoginController loginCtrl = new Controllers.LoginController();
            string result = loginCtrl.RequestCustomerPasswordReset(customerId, phone, email);

            switch (result)
            {
                case "success":
                    this.Hide();
                    var sentForm = new ResetPasswordSentForm(parentLoginForm, customerId, email);
                    sentForm.FormClosed += (s, args) => this.Close();
                    sentForm.Show();
                    break;
                case "customer_not_found":
                    MessageBox.Show("Customer account not found. Please check your Customer ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "phone_mismatch":
                    MessageBox.Show("Phone number does not match our records. Please check and try again.", "Phone Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "email_mismatch":
                    MessageBox.Show("Email address does not match our records. Please check and try again.", "Email Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "email_failed":
                    MessageBox.Show("Failed to send email. Please try again later.", "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    MessageBox.Show("An error occurred. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}