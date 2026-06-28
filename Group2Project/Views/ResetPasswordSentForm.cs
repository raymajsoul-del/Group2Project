using System;
using System.Drawing;
using System.Windows.Forms;
using Group2Project.Utils;

namespace Group2Project.Views
{
    public partial class ResetPasswordSentForm : Form
    {
        private Label lblMessage;
        private Button btnResend, btnSignIn, btnLanguageToggle;
        private PictureBox pbIcon;

        private Color colorBrandGreen = Color.FromArgb(46, 125, 50);
        private Color colorBrandOrange = Color.FromArgb(242, 140, 20);
        private Color colorLightGray = Color.FromArgb(250, 250, 250);
        private Color colorTextDark = Color.FromArgb(40, 40, 40);

        private LoginForm parentLoginForm;
        private string username;
        private string email;

        public ResetPasswordSentForm(LoginForm parentForm, string user, string userEmail)
        {
            parentLoginForm = parentForm;
            username = user;
            email = userEmail;
            SetupUI();
            SubscribeLanguageChanged();
        }

        private void SubscribeLanguageChanged()
        {
            LanguageManager.LanguageChanged += UpdateUIWithLanguage;
        }

        private void SetupUI()
        {
            this.Text = "Reset Password Result";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ClientSize = new Size(800, 500);
            this.BackColor = colorLightGray;

            // 语言切换按钮
            btnLanguageToggle = new Button
            {
                Text = LanguageManager.GetString("Language_Chinese"),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                BackColor = Color.White,
                ForeColor = colorBrandGreen,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(100, 35),
                Location = new Point(670, 20),
                Cursor = Cursors.Hand
            };
            btnLanguageToggle.FlatAppearance.BorderSize = 0;
            btnLanguageToggle.Click += (s, e) =>
            {
                LanguageManager.ToggleLanguage();
                btnLanguageToggle.Text = LanguageManager.CurrentLanguage == "en" 
                    ? LanguageManager.GetString("Language_Chinese") 
                    : LanguageManager.GetString("Language_English");
            };

            // Email icon (drawn with Graphics)
            pbIcon = new PictureBox
            {
                Size = new Size(150, 120),
                Location = new Point(325, 50),
                BackColor = Color.Transparent
            };
            pbIcon.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Draw envelope
                Brush greenBrush = new SolidBrush(colorBrandGreen);
                Pen greenPen = new Pen(colorBrandGreen, 3);

                // Envelope body
                Rectangle envelopeRect = new Rectangle(10, 30, 130, 70);
                g.FillRectangle(greenBrush, envelopeRect);
                g.DrawRectangle(greenPen, envelopeRect);

                // Envelope flap (V shape)
                g.DrawLine(greenPen, 10, 30, 75, 75);
                g.DrawLine(greenPen, 140, 30, 75, 75);

                // @ symbol circle
                g.FillEllipse(greenBrush, 100, 0, 45, 45);
                Brush whiteBrush = new SolidBrush(Color.White);
                g.DrawString("@", new Font("Segoe UI", 24, FontStyle.Bold), whiteBrush, 110, -5);
            };

            // Message label
            lblMessage = new Label
            {
                Text = LanguageManager.GetString("ResetSent_EmailSent"),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = colorTextDark,
                AutoSize = false,
                Size = new Size(700, 80),
                Location = new Point(50, 190),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Resend Email button
            btnResend = new Button
            {
                Text = LanguageManager.GetString("ResetSent_Resend"),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                BackColor = colorBrandGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(150, 40),
                Location = new Point(200, 300),
                Cursor = Cursors.Hand
            };
            btnResend.FlatAppearance.BorderSize = 0;
            btnResend.Click += BtnResend_Click;

            // Sign In button
            btnSignIn = new Button
            {
                Text = LanguageManager.GetString("ResetSent_SignIn"),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                BackColor = colorBrandOrange,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(150, 40),
                Location = new Point(450, 300),
                Cursor = Cursors.Hand
            };
            btnSignIn.FlatAppearance.BorderSize = 0;
            btnSignIn.Click += BtnSignIn_Click;

            this.Controls.Add(btnLanguageToggle);
            this.Controls.Add(pbIcon);
            this.Controls.Add(lblMessage);
            this.Controls.Add(btnResend);
            this.Controls.Add(btnSignIn);

            UpdateUIWithLanguage();
        }

        private void UpdateUIWithLanguage()
        {
            this.Text = LanguageManager.GetString("ResetSent_Title");
            if (lblMessage != null) lblMessage.Text = LanguageManager.GetString("ResetSent_EmailSent");
            if (btnResend != null) btnResend.Text = LanguageManager.GetString("ResetSent_Resend");
            if (btnSignIn != null) btnSignIn.Text = LanguageManager.GetString("ResetSent_SignIn");
            if (btnLanguageToggle != null)
            {
                btnLanguageToggle.Text = LanguageManager.CurrentLanguage == "en" 
                    ? LanguageManager.GetString("Language_Chinese") 
                    : LanguageManager.GetString("Language_English");
            }
        }

        private void BtnResend_Click(object sender, EventArgs e)
        {
            Controllers.LoginController loginCtrl = new Controllers.LoginController();
            var (result, message) = loginCtrl.RequestPasswordReset(username, email);

            switch (result)
            {
                case "success":
                    MessageBox.Show(
                        $"{LanguageManager.GetString("ResetSent_EmailResent")}\n\n{message}", 
                        LanguageManager.GetString("ResetSent_EmailSentTitle"), 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "email_failed":
                    MessageBox.Show(
                        $"{LanguageManager.GetString("ForgotPassword_EmailFailed")}\n\n{message}", 
                        LanguageManager.GetString("ForgotPassword_EmailError"), 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    MessageBox.Show(
                        $"{LanguageManager.GetString("ForgotPassword_Error")}\n\n{message}", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            this.Close();
            parentLoginForm.Show();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                LanguageManager.LanguageChanged -= UpdateUIWithLanguage;
            }
            base.Dispose(disposing);
        }
    }
}
