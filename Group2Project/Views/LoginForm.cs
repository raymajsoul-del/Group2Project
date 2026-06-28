using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Group2Project.Models;
using Group2Project.Controllers;
using Group2Project;

namespace Group2Project.Views
{
    public partial class LoginForm : Form
    {
        private TextBox txtUsername, txtPassword;
        private Label lblTitle, lblUsername, lblPassword;
        private Button btnLogin, btnLanguageToggle, btnSettings, btnClose;
        private LinkLabel btnForgotPassword, btnRegister;
        private bool isEnglish = true;
        private Panel mainPanel;
        private AppContext? appContext;

        public LoginForm()
        {
            SetupUI();
        }

        public LoginForm(AppContext context) : this()
        {
            appContext = context;
        }

        private void SetupUI()
        {
            this.Text = "ERP System - Login";
            this.Size = new Size(550, 680);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.None; // Remove default border
            this.Padding = new Padding(0);

            // Main container panel with gradient
            mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            mainPanel.Paint += MainPanel_Paint;
            this.Controls.Add(mainPanel);

            // Settings button
            btnSettings = new Button
            {
                Text = "⚙️",
                Size = new Size(45, 40),
                Location = new Point(20, 20),
                Font = new Font("Segoe UI", 18),
                BackColor = Color.Transparent,
                ForeColor = Color.FromArgb(255, 255, 255),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.MouseEnter += (s, e) => btnSettings.ForeColor = Color.FromArgb(200, 200, 200);
            btnSettings.MouseLeave += (s, e) => btnSettings.ForeColor = Color.White;
            btnSettings.Click += BtnSettings_Click;

            // Close button
            btnClose = new Button
            {
                Text = "✕",
                Size = new Size(40, 40),
                Location = new Point(490, 20),
                Font = new Font("Segoe UI", 16),
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
                Size = new Size(120, 40),
                Location = new Point(350, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnLanguageToggle.FlatAppearance.BorderSize = 0;
            btnLanguageToggle.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 255, 255, 255);
            btnLanguageToggle.Click += (s, e) =>
            {
                isEnglish = !isEnglish;
                UpdateUIText();
            };

            // Title
            lblTitle = new Label
            {
                Text = "Welcome Back",
                Size = new Size(480, 50),
                Location = new Point(35, 180),
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };

            // Subtitle
            var lblSubtitle = new Label
            {
                Text = "Sign in to continue",
                Size = new Size(480, 30),
                Location = new Point(35, 230),
                Font = new Font("Segoe UI", 12),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(220, 220, 220),
                BackColor = Color.Transparent
            };

            // Furniture Image
            var furnitureImage = new PictureBox
            {
                Size = new Size(400, 140),
                Location = new Point(75, 50),
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            
            // Draw a furniture icon using GDI+ since loading external images may be problematic
            furnitureImage.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                
                // Draw some modern furniture shapes
                
                // 1. Sofa
                Color sofaColor = Color.FromArgb(240, 140, 100);
                using (var brush = new SolidBrush(sofaColor))
                {
                    // Sofa base
                    g.FillRectangle(brush, 30, 60, 140, 50);
                    // Sofa back
                    g.FillRectangle(brush, 40, 30, 120, 35);
                    // Sofa arms
                    g.FillRectangle(brush, 30, 40, 15, 40);
                    g.FillRectangle(brush, 155, 40, 15, 40);
                    
                    // Sofa cushions
                    using (var cushionBrush = new SolidBrush(Color.FromArgb(250, 160, 120)))
                    {
                        g.FillRectangle(cushionBrush, 55, 65, 40, 30);
                        g.FillRectangle(cushionBrush, 105, 65, 40, 30);
                    }
                }
                
                // 2. Coffee table
                Color tableColor = Color.FromArgb(139, 90, 43);
                using (var brush = new SolidBrush(tableColor))
                {
                    // Table top
                    g.FillRectangle(brush, 220, 80, 150, 10);
                    // Table legs
                    g.FillRectangle(brush, 230, 90, 8, 30);
                    g.FillRectangle(brush, 352, 90, 8, 30);
                    g.FillRectangle(brush, 260, 90, 8, 30);
                    g.FillRectangle(brush, 322, 90, 8, 30);
                }
                
                // 3. Lamp
                Color lampColor = Color.FromArgb(100, 100, 100);
                using (var brush = new SolidBrush(lampColor))
                {
                    // Lamp stand
                    g.FillRectangle(brush, 385, 70, 8, 50);
                    // Lamp shade
                    Color shadeColor = Color.FromArgb(255, 240, 220);
                    using (var shadeBrush = new SolidBrush(shadeColor))
                    {
                        Point[] points = new Point[]
                        {
                            new Point(370, 70),
                            new Point(398, 70),
                            new Point(408, 45),
                            new Point(360, 45)
                        };
                        g.FillPolygon(shadeBrush, points);
                    }
                }
                
                // 4. Plant
                using (var potBrush = new SolidBrush(Color.FromArgb(160, 110, 70)))
                {
                    g.FillRectangle(potBrush, 180, 95, 30, 25);
                }
                
                using (var plantBrush = new SolidBrush(Color.FromArgb(60, 140, 60)))
                {
                    g.FillEllipse(plantBrush, 175, 60, 40, 40);
                }
            };

            // Login card container
            var loginCard = new Panel
            {
                Size = new Size(440, 400),
                Location = new Point(55, 270),
                BackColor = Color.White,
                Cursor = Cursors.Default
            };
            loginCard.Paint += (s, e) =>
            {
                // Draw rounded corners
                GraphicsPath path = new GraphicsPath();
                Rectangle rect = new Rectangle(0, 0, loginCard.Width, loginCard.Height);
                int radius = 15;
                
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();
                
                loginCard.Region = new Region(path);
            };

            // Staff ID Label
            lblUsername = new Label
            {
                Text = "Staff ID",
                Size = new Size(380, 25),
                Location = new Point(30, 30),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(51, 51, 51),
                BackColor = Color.White
            };

            // Staff ID TextBox
            txtUsername = new TextBox
            {
                Size = new Size(380, 45),
                Location = new Point(30, 55),
                Font = new Font("Segoe UI", 12),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(245, 247, 250),
                ForeColor = Color.FromArgb(51, 51, 51)
            };

            // Password Label
            lblPassword = new Label
            {
                Text = "Password",
                Size = new Size(380, 25),
                Location = new Point(30, 120),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(51, 51, 51),
                BackColor = Color.White
            };

            // Password TextBox
            txtPassword = new TextBox
            {
                Size = new Size(380, 45),
                Location = new Point(30, 145),
                Font = new Font("Segoe UI", 12),
                BorderStyle = BorderStyle.FixedSingle,
                UseSystemPasswordChar = true,
                BackColor = Color.FromArgb(245, 247, 250),
                ForeColor = Color.FromArgb(51, 51, 51)
            };

            // Login Button
            btnLogin = new Button
            {
                Text = "Sign In",
                Size = new Size(380, 55),
                Location = new Point(30, 215),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                BackColor = Color.FromArgb(232, 106, 16),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Paint += BtnLogin_Paint;
            btnLogin.MouseEnter += (s, e) => btnLogin.BackColor = Color.FromArgb(255, 130, 40);
            btnLogin.MouseLeave += (s, e) => btnLogin.BackColor = Color.FromArgb(232, 106, 16);
            btnLogin.Click += BtnLogin_Click;

            // Forgot Password Button
            btnForgotPassword = new LinkLabel();
            btnForgotPassword.Text = "Forgot Password?";
            btnForgotPassword.Size = new Size(380, 25);
            btnForgotPassword.Location = new Point(30, 280);
            btnForgotPassword.Font = new Font("Segoe UI", 10);
            btnForgotPassword.TextAlign = ContentAlignment.MiddleCenter;
            btnForgotPassword.LinkColor = Color.FromArgb(232, 106, 16);
            btnForgotPassword.VisitedLinkColor = Color.FromArgb(232, 106, 16);
            btnForgotPassword.BackColor = Color.White;
            btnForgotPassword.Click += BtnForgotPassword_Click;

            // Register Button
            btnRegister = new LinkLabel();
            btnRegister.Text = "Don't have an account? Register now";
            btnRegister.Size = new Size(380, 25);
            btnRegister.Location = new Point(30, 310);
            btnRegister.Font = new Font("Segoe UI", 10);
            btnRegister.TextAlign = ContentAlignment.MiddleCenter;
            btnRegister.LinkColor = Color.FromArgb(46, 125, 50);
            btnRegister.VisitedLinkColor = Color.FromArgb(46, 125, 50);
            btnRegister.BackColor = Color.White;
            btnRegister.Click += BtnRegister_Click;

            // Add controls to login card
            loginCard.Controls.Add(lblUsername);
            loginCard.Controls.Add(txtUsername);
            loginCard.Controls.Add(lblPassword);
            loginCard.Controls.Add(txtPassword);
            loginCard.Controls.Add(btnLogin);
            loginCard.Controls.Add(btnForgotPassword);
            loginCard.Controls.Add(btnRegister);

            // Add controls to main panel
            mainPanel.Controls.Add(btnSettings);
            mainPanel.Controls.Add(btnLanguageToggle);
            mainPanel.Controls.Add(btnClose);
            mainPanel.Controls.Add(furnitureImage);
            mainPanel.Controls.Add(lblTitle);
            mainPanel.Controls.Add(lblSubtitle);
            mainPanel.Controls.Add(loginCard);
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            // Draw gradient background
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0), new Point(0, mainPanel.Height),
                Color.FromArgb(26, 43, 76),
                Color.FromArgb(15, 25, 50)))
            {
                e.Graphics.FillRectangle(brush, mainPanel.ClientRectangle);
            }

            // Draw decorative circles
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            
            // Top right circle - using SolidBrush for simplicity
            using (SolidBrush circleBrush1 = new SolidBrush(Color.FromArgb(60, 255, 255, 255)))
            {
                e.Graphics.FillEllipse(circleBrush1, 300, -50, 250, 250);
            }
            
            // Bottom left circle
            using (SolidBrush circleBrush2 = new SolidBrush(Color.FromArgb(40, 255, 255, 255)))
            {
                e.Graphics.FillEllipse(circleBrush2, -50, 400, 200, 200);
            }
        }

        private void BtnLogin_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
            int radius = 10;
            
            // Draw rounded button
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

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string staffId = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(staffId) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    isEnglish ? "Please enter both Staff ID and password." : "請輸入員工編號和密碼。",
                    isEnglish ? "Input Error" : "輸入錯誤",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                LoginController controller = new LoginController();
                Console.WriteLine($"Attempting login for Staff ID: {staffId}");
                
                Staff user = controller.Authenticate(staffId, password);

                if (user != null)
                {
                    Console.WriteLine($"Login successful! User: {user.StaffName}, Role: {user.Role}, Status: {user.Status}");
                    // 登入成功
                    if (appContext != null)
                    {
                        appContext.ShowMainForm(user);
                    }
                    else
                    {
                        // Fallback to old behavior if no context is provided
                        this.Hide();
                        Console.WriteLine("Creating MainForm instance...");
                        MainForm mainForm = new MainForm(user);
                        Console.WriteLine("MainForm instance created");
                        mainForm.FormClosed += MainForm_FormClosed;
                        Console.WriteLine("Showing MainForm...");
                        mainForm.Show();
                        Console.WriteLine("MainForm shown");
                    }
                }
                else
                {
                    Console.WriteLine("Login failed: Invalid Staff ID or password (returned null)");
                    MessageBox.Show(
                        isEnglish ? "Invalid Staff ID or password." : "無效的員工編號或密碼。",
                        isEnglish ? "Login Failed" : "登入失敗",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Login exception: {ex.Message}\nStack trace: {ex.StackTrace}");
                MessageBox.Show(
                    isEnglish ? $"Login error: {ex.Message}\n\nStack trace: {ex.StackTrace}" : $"登入錯誤：{ex.Message}\n\n堆疊追蹤：{ex.StackTrace}",
                    isEnglish ? "Error" : "錯誤",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 只有在正常关闭MainForm时检查是否应该关闭LoginForm
            if (!shouldKeepLoginFormOpen)
            {
                this.Close();
            }
        }

        private bool shouldKeepLoginFormOpen = false;

        public void ShowAndReset()
        {
            // 标记LoginForm不应该被关闭
            shouldKeepLoginFormOpen = true;
            
            // 清空输入框
            txtUsername.Clear();
            txtPassword.Clear();
            
            // 显示LoginForm
            this.Show();
            this.BringToFront();
            
            // 焦点放在用户名输入框
            txtUsername.Focus();
        }

        private void BtnForgotPassword_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                ForgotPasswordForm forgotForm = new ForgotPasswordForm(this);
                forgotForm.FormClosed += (s, args) => this.Show();
                forgotForm.Show();
            }
            catch (Exception ex)
            {
                this.Show();
                MessageBox.Show(
                    isEnglish ? $"Error opening forgot password form: {ex.Message}" : $"開啟忘記密碼表單時發生錯誤：{ex.Message}",
                    isEnglish ? "Error" : "錯誤",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                EmailSettingsForm settingsForm = new EmailSettingsForm();
                settingsForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    isEnglish ? $"Error opening settings: {ex.Message}" : $"開啟設定時發生錯誤：{ex.Message}",
                    isEnglish ? "Error" : "錯誤",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm regForm = new RegistrationForm(this);
            regForm.FormClosed += (s, args) => this.Show();
            regForm.Show();
        }

        private void UpdateUIText()
        {
            this.Text = isEnglish ? "ERP System - Login" : "ERP 系統 - 登入";
            btnLanguageToggle.Text = isEnglish ? "中文" : "English";
            lblTitle.Text = isEnglish ? "Welcome Back" : "歡迎回來";
            
            // Find subtitle and update it (now it's index 4)
            if (mainPanel.Controls.Count > 5)
            {
                Label subtitle = mainPanel.Controls[4] as Label;
                if (subtitle != null)
                {
                    subtitle.Text = isEnglish ? "Sign in to continue" : "登入以繼續";
                }
            }
            
            lblUsername.Text = isEnglish ? "Staff ID" : "員工編號";
            lblPassword.Text = isEnglish ? "Password" : "密碼";
            btnLogin.Text = isEnglish ? "Sign In" : "登入";
            btnForgotPassword.Text = isEnglish ? "Forgot Password?" : "忘記密碼？";
            btnRegister.Text = isEnglish ? "Don't have an account? Register now" : "沒有帳號？立即註冊";
        }
    }
}
