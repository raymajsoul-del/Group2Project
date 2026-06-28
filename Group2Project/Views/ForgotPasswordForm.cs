using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Group2Project.Views
{
    public partial class ForgotPasswordForm : Form
    {
        private TextBox txtUsername, txtEmail;
        private Label lblTitle, lblSubtitle, lblUsername, lblEmail;
        private Button btnConfirmReset, btnLanguageToggle, btnBack, btnClose;
        private bool isEnglish = true;
        private Panel mainPanel;
        
        private LoginForm parentLoginForm;

        public ForgotPasswordForm(LoginForm parentForm)
        {
            try
            {
                parentLoginForm = parentForm;
                SetupUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading form: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupUI()
        {
            this.Text = "Reset Password";
            this.Size = new Size(650, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;

            // Main panel with gradient
            mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            mainPanel.Paint += MainPanel_Paint;
            this.Controls.Add(mainPanel);

            // Close button
            btnClose = new Button
            {
                Text = "✕",
                Size = new Size(40, 40),
                Location = new Point(595, 15),
                Font = new Font("Segoe UI", 14),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.MouseEnter += (s, e) => btnClose.ForeColor = Color.FromArgb(255, 100, 100);
            btnClose.MouseLeave += (s, e) => btnClose.ForeColor = Color.White;
            btnClose.Click += (s, e) => this.Close();

            // Language toggle button
            btnLanguageToggle = new Button
            {
                Text = "中文",
                Size = new Size(100, 40),
                Location = new Point(470, 15),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnLanguageToggle.FlatAppearance.BorderSize = 0;
            btnLanguageToggle.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            btnLanguageToggle.Click += (s, e) =>
            {
                isEnglish = !isEnglish;
                UpdateUIText();
            };

            // Back button
            btnBack = new Button
            {
                Text = "◀",
                Size = new Size(50, 40),
                Location = new Point(20, 15),
                Font = new Font("Segoe UI", 16),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.MouseEnter += (s, e) => btnBack.ForeColor = Color.FromArgb(200, 200, 255);
            btnBack.MouseLeave += (s, e) => btnBack.ForeColor = Color.White;
            btnBack.Click += (s, e) => this.Close();

            // Title
            lblTitle = new Label
            {
                Text = "Reset Password",
                Size = new Size(550, 50),
                Location = new Point(50, 100),
                Font = new Font("Segoe UI", 32, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };

            // Subtitle
            lblSubtitle = new Label
            {
                Text = "Enter your details to reset your password",
                Size = new Size(550, 30),
                Location = new Point(50, 150),
                Font = new Font("Segoe UI", 12),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(230, 230, 255),
                BackColor = Color.Transparent
            };

            // Decorative content panel
            var contentPanel = new Panel
            {
                Size = new Size(550, 300),
                Location = new Point(50, 200),
                BackColor = Color.Transparent
            };
            contentPanel.Paint += ContentPanel_Paint;

            // Staff ID
            lblUsername = new Label
            {
                Text = "Staff ID",
                Size = new Size(450, 25),
                Location = new Point(50, 30),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(80, 80, 120),
                BackColor = Color.White
            };

            txtUsername = CreateStyledTextBox(new Point(50, 60), 450);

            // Email
            lblEmail = new Label
            {
                Text = "Email",
                Size = new Size(450, 25),
                Location = new Point(50, 130),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(80, 80, 120),
                BackColor = Color.White
            };

            txtEmail = CreateStyledTextBox(new Point(50, 160), 450);

            // Confirm Reset Button
            btnConfirmReset = new Button
            {
                Text = "Confirm Reset",
                Size = new Size(450, 55),
                Location = new Point(50, 230),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                BackColor = Color.FromArgb(138, 43, 226),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnConfirmReset.FlatAppearance.BorderSize = 0;
            btnConfirmReset.Paint += RoundedButton_Paint;
            btnConfirmReset.MouseEnter += (s, e) => btnConfirmReset.BackColor = Color.FromArgb(153, 50, 204);
            btnConfirmReset.MouseLeave += (s, e) => btnConfirmReset.BackColor = Color.FromArgb(138, 43, 226);
            btnConfirmReset.Click += BtnConfirmReset_Click;

            // Add controls to content panel
            contentPanel.Controls.Add(lblUsername);
            contentPanel.Controls.Add(txtUsername);
            contentPanel.Controls.Add(lblEmail);
            contentPanel.Controls.Add(txtEmail);
            contentPanel.Controls.Add(btnConfirmReset);

            // Add controls to main panel
            mainPanel.Controls.Add(btnClose);
            mainPanel.Controls.Add(btnLanguageToggle);
            mainPanel.Controls.Add(btnBack);
            mainPanel.Controls.Add(lblTitle);
            mainPanel.Controls.Add(lblSubtitle);
            mainPanel.Controls.Add(contentPanel);
        }

        private TextBox CreateStyledTextBox(Point location, int width)
        {
            var textBox = new TextBox
            {
                Size = new Size(width, 45),
                Location = location,
                Font = new Font("Segoe UI", 12),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(248, 248, 255),
                ForeColor = Color.FromArgb(60, 60, 100)
            };
            return textBox;
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            // Beautiful purple-pink gradient background
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0), new Point(mainPanel.Width, mainPanel.Height),
                Color.FromArgb(75, 0, 130),
                Color.FromArgb(148, 0, 211)))
            {
                e.Graphics.FillRectangle(brush, mainPanel.ClientRectangle);
            }

            // Decorative circles
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (SolidBrush circleBrush1 = new SolidBrush(Color.FromArgb(30, 255, 255, 255)))
            {
                e.Graphics.FillEllipse(circleBrush1, -50, 50, 200, 200);
            }
            using (SolidBrush circleBrush2 = new SolidBrush(Color.FromArgb(20, 255, 255, 255)))
            {
                e.Graphics.FillEllipse(circleBrush2, 500, -30, 180, 180);
            }
            using (SolidBrush circleBrush3 = new SolidBrush(Color.FromArgb(15, 255, 255, 255)))
            {
                e.Graphics.FillEllipse(circleBrush3, 450, 400, 150, 150);
            }
        }

        private void ContentPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Shadow
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(20, 0, 0, 0)))
            {
                GraphicsPath shadowPath = new GraphicsPath();
                Rectangle shadowRect = new Rectangle(5, 5, p.Width, p.Height);
                int shadowRadius = 20;
                shadowPath.AddArc(shadowRect.X, shadowRect.Y, shadowRadius, shadowRadius, 180, 90);
                shadowPath.AddArc(shadowRect.Right - shadowRadius, shadowRect.Y, shadowRadius, shadowRadius, 270, 90);
                shadowPath.AddArc(shadowRect.Right - shadowRadius, shadowRect.Bottom - shadowRadius, shadowRadius, shadowRadius, 0, 90);
                shadowPath.AddArc(shadowRect.X, shadowRect.Bottom - shadowRadius, shadowRadius, shadowRadius, 90, 90);
                shadowPath.CloseFigure();
                e.Graphics.FillPath(shadowBrush, shadowPath);
            }

            // Main white card with rounded corners
            using (SolidBrush cardBrush = new SolidBrush(Color.White))
            {
                GraphicsPath cardPath = new GraphicsPath();
                Rectangle cardRect = new Rectangle(0, 0, p.Width - 1, p.Height - 1);
                int cardRadius = 20;
                cardPath.AddArc(cardRect.X, cardRect.Y, cardRadius, cardRadius, 180, 90);
                cardPath.AddArc(cardRect.Right - cardRadius, cardRect.Y, cardRadius, cardRadius, 270, 90);
                cardPath.AddArc(cardRect.Right - cardRadius, cardRect.Bottom - cardRadius, cardRadius, cardRadius, 0, 90);
                cardPath.AddArc(cardRect.X, cardRect.Bottom - cardRadius, cardRadius, cardRadius, 90, 90);
                cardPath.CloseFigure();
                e.Graphics.FillPath(cardBrush, cardPath);
            }
        }

        private void RoundedButton_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
            int radius = 15;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                btn.Region = new Region(path);
            }
        }

        private void BtnConfirmReset_Click(object sender, EventArgs e)
        {
            string staffId = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(staffId) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show(
                    isEnglish ? "Please enter both Staff ID and email." : "請輸入員工編號和電子郵件。",
                    isEnglish ? "Input Error" : "輸入錯誤",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Controllers.LoginController loginCtrl = new Controllers.LoginController();
                var (result, message) = loginCtrl.RequestPasswordReset(staffId, email);

                switch (result)
                {
                    case "success":
                        MessageBox.Show(
                            isEnglish ? 
                            $"Password reset request processed successfully!\n\n{message}" : 
                            $"密碼重置要求已成功處理！\n\n{message}",
                            isEnglish ? "Success" : "成功",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        this.Close();
                        break;
                    case "user_not_found":
                        MessageBox.Show(
                            isEnglish ? "User not found." : "找不到使用者。",
                            isEnglish ? "Error" : "錯誤",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        break;
                    case "email_mismatch":
                        MessageBox.Show(
                            isEnglish ? "Email does not match our records." : "電子郵件與我們的記錄不符。",
                            isEnglish ? "Error" : "錯誤",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        break;
                    case "email_failed":
                        MessageBox.Show(
                            isEnglish ? 
                            $"Password reset request processed, but email service failed.\n\n{message}" : 
                            $"密碼重置要求已處理，但電子郵件服務失敗。\n\n{message}",
                            isEnglish ? "Partial Success" : "部分成功",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        this.Close();
                        break;
                    default:
                        MessageBox.Show(
                            isEnglish ? 
                            $"An error occurred while processing your request.\n\n{message}" : 
                            $"處理您的要求時發生錯誤。\n\n{message}",
                            isEnglish ? "Error" : "錯誤",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    isEnglish ? 
                    $"Error: {ex.Message}\n\nThis may be due to database connection issues.\nFor testing, you can use the registration form to create a new account." : 
                    $"錯誤：{ex.Message}\n\n可能是因為資料庫連線問題。\n測試時，您可以使用註冊表單建立新帳號。",
                    isEnglish ? "Error" : "錯誤",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UpdateUIText()
        {
            this.Text = isEnglish ? "Reset Password" : "重置密碼";
            btnLanguageToggle.Text = isEnglish ? "中文" : "English";
            lblTitle.Text = isEnglish ? "Reset Password" : "重置密碼";
            lblSubtitle.Text = isEnglish ? "Enter your details to reset your password" : "輸入您的資料以重置密碼";
            lblUsername.Text = isEnglish ? "Staff ID" : "員工編號";
            lblEmail.Text = isEnglish ? "Email" : "電子郵件";
            btnConfirmReset.Text = isEnglish ? "Confirm Reset" : "確認重置";
        }
    }
}
