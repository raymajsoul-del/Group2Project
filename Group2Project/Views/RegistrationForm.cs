using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Group2Project.Controllers;

namespace Group2Project.Views
{
    public partial class RegistrationForm : Form
    {
        private Form loginForm;
        private TextBox txtStaffId, txtStaffName, txtPassword, txtConfirmPassword, txtEmail;
        private Label lblTitle, lblSubtitle, lblStaffId, lblStaffName, lblPassword, lblConfirmPassword, lblEmail, lblRole;
        private Button btnRegister, btnLanguageToggle, btnCancel, btnClose;
        private ComboBox cboRole;
        private bool isEnglish = true;
        private string[] roles = { "Admin", "Accountant", "Inventory", "Purchase" };
        private Panel mainPanel;

        public RegistrationForm(Form loginForm)
        {
            this.loginForm = loginForm;
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Register New Staff";
            this.Size = new Size(680, 980);
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
                Size = new Size(45, 40),
                Location = new Point(620, 15),
                Font = new Font("Segoe UI", 16),
                BackColor = Color.Transparent,
                ForeColor = Color.FromArgb(70, 130, 120),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.MouseEnter += (s, e) => btnClose.ForeColor = Color.FromArgb(200, 80, 80);
            btnClose.MouseLeave += (s, e) => btnClose.ForeColor = Color.FromArgb(70, 130, 120);
            btnClose.Click += (s, e) => this.Close();

            // 語言切換按鈕
            btnLanguageToggle = new Button
            {
                Text = "中文",
                Size = new Size(100, 40),
                Location = new Point(500, 15),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.FromArgb(70, 130, 120),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnLanguageToggle.FlatAppearance.BorderSize = 0;
            btnLanguageToggle.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 70, 130, 120);
            btnLanguageToggle.Click += (s, e) =>
            {
                isEnglish = !isEnglish;
                UpdateUIText();
            };

            // Decorative header panel
            var headerPanel = new Panel
            {
                Size = new Size(680, 220),
                Location = new Point(0, 0),
                BackColor = Color.Transparent
            };
            headerPanel.Paint += HeaderPanel_Paint;

            // Title
            lblTitle = new Label
            {
                Text = "Create Account",
                Size = new Size(600, 60),
                Location = new Point(40, 130),
                Font = new Font("Segoe UI", 36, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };

            // Subtitle
            lblSubtitle = new Label
            {
                Text = "Join our team today",
                Size = new Size(600, 30),
                Location = new Point(45, 185),
                Font = new Font("Segoe UI", 14),
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.FromArgb(240, 245, 245),
                BackColor = Color.Transparent
            };

            // Registration card container
            var regCard = new Panel
            {
                Size = new Size(600, 720),
                Location = new Point(40, 220),
                BackColor = Color.White
            };
            regCard.Paint += RegCard_Paint;

            // Input fields - arranged in two columns for better visual flow
            int leftColX = 40;
            int rightColX = 340;
            int colWidth = 260;

            // Row 1: Staff ID (Left)
            lblStaffId = new Label
            {
                Text = "Staff ID",
                Size = new Size(colWidth, 25),
                Location = new Point(leftColX, 40),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60),
                BackColor = Color.White
            };

            txtStaffId = CreateStyledTextBox(new Point(leftColX, 70), colWidth);

            // Row 1: Staff Name (Right)
            lblStaffName = new Label
            {
                Text = "Staff Name",
                Size = new Size(colWidth, 25),
                Location = new Point(rightColX, 40),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60),
                BackColor = Color.White
            };

            txtStaffName = CreateStyledTextBox(new Point(rightColX, 70), colWidth);

            // Row 2: Email (Full width)
            lblEmail = new Label
            {
                Text = "Email",
                Size = new Size(520, 25),
                Location = new Point(leftColX, 140),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60),
                BackColor = Color.White
            };

            txtEmail = CreateStyledTextBox(new Point(leftColX, 170), 520);

            // Row 3: Role (Full width)
            lblRole = new Label
            {
                Text = "Role",
                Size = new Size(520, 25),
                Location = new Point(leftColX, 240),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60),
                BackColor = Color.White
            };

            cboRole = new ComboBox
            {
                Size = new Size(520, 45),
                Location = new Point(leftColX, 270),
                Font = new Font("Segoe UI", 12),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(248, 250, 252),
                ForeColor = Color.FromArgb(60, 60, 60),
                FlatStyle = FlatStyle.Flat
            };
            cboRole.Items.AddRange(roles);
            cboRole.SelectedIndex = 0;

            // Row 4: Password (Left)
            lblPassword = new Label
            {
                Text = "Password",
                Size = new Size(colWidth, 25),
                Location = new Point(leftColX, 340),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60),
                BackColor = Color.White
            };

            txtPassword = CreateStyledTextBox(new Point(leftColX, 370), colWidth);
            txtPassword.UseSystemPasswordChar = true;

            // Row 4: Confirm Password (Right)
            lblConfirmPassword = new Label
            {
                Text = "Confirm Password",
                Size = new Size(colWidth, 25),
                Location = new Point(rightColX, 340),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60),
                BackColor = Color.White
            };

            txtConfirmPassword = CreateStyledTextBox(new Point(rightColX, 370), colWidth);
            txtConfirmPassword.UseSystemPasswordChar = true;

            // Decorative divider
            var divider = new Panel
            {
                Size = new Size(520, 1),
                Location = new Point(leftColX, 450),
                BackColor = Color.FromArgb(230, 235, 235)
            };

            // Buttons
            btnCancel = new Button
            {
                Text = "Cancel",
                Size = new Size(250, 55),
                Location = new Point(leftColX, 490),
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                BackColor = Color.FromArgb(240, 245, 245),
                ForeColor = Color.FromArgb(70, 130, 120),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Paint += RoundedButton_Paint;
            btnCancel.MouseEnter += (s, e) => btnCancel.BackColor = Color.FromArgb(225, 235, 235);
            btnCancel.MouseLeave += (s, e) => btnCancel.BackColor = Color.FromArgb(240, 245, 245);
            btnCancel.Click += BtnCancel_Click;

            btnRegister = new Button
            {
                Text = "Create Account",
                Size = new Size(250, 55),
                Location = new Point(310, 490),
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                BackColor = Color.FromArgb(70, 130, 120),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Paint += RoundedButton_Paint;
            btnRegister.MouseEnter += (s, e) => btnRegister.BackColor = Color.FromArgb(90, 150, 140);
            btnRegister.MouseLeave += (s, e) => btnRegister.BackColor = Color.FromArgb(70, 130, 120);
            btnRegister.Click += BtnRegister_Click;

            // Add decorative elements to card
            AddDecorativeElements(regCard);

            // Add controls to registration card
            regCard.Controls.Add(lblStaffId);
            regCard.Controls.Add(txtStaffId);
            regCard.Controls.Add(lblStaffName);
            regCard.Controls.Add(txtStaffName);
            regCard.Controls.Add(lblEmail);
            regCard.Controls.Add(txtEmail);
            regCard.Controls.Add(lblRole);
            regCard.Controls.Add(cboRole);
            regCard.Controls.Add(lblPassword);
            regCard.Controls.Add(txtPassword);
            regCard.Controls.Add(lblConfirmPassword);
            regCard.Controls.Add(txtConfirmPassword);
            regCard.Controls.Add(divider);
            regCard.Controls.Add(btnCancel);
            regCard.Controls.Add(btnRegister);

            // Add controls to header panel
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(lblSubtitle);
            
            // Add controls to main panel
            mainPanel.Controls.Add(btnClose);
            mainPanel.Controls.Add(btnLanguageToggle);
            mainPanel.Controls.Add(headerPanel);
            mainPanel.Controls.Add(regCard);
        }

        private TextBox CreateStyledTextBox(Point location, int width)
        {
            // Simple and reliable textbox with custom styling
            var textBox = new TextBox
            {
                Size = new Size(width, 45),
                Location = location,
                Font = new Font("Segoe UI", 12),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(248, 250, 252),
                ForeColor = Color.FromArgb(60, 60, 60)
            };
            return textBox;
        }

        private void AddDecorativeElements(Panel parent)
        {
            // Abstract decorative shape 1
            var shape1 = new Panel
            {
                Size = new Size(120, 120),
                Location = new Point(520, 580),
                BackColor = Color.Transparent
            };
            shape1.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Brush brush = new SolidBrush(Color.FromArgb(30, 70, 130, 120)))
                {
                    e.Graphics.FillEllipse(brush, 0, 0, 120, 120);
                }
            };

            // Abstract decorative shape 2
            var shape2 = new Panel
            {
                Size = new Size(60, 60),
                Location = new Point(560, 620),
                BackColor = Color.Transparent
            };
            shape2.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Brush brush = new SolidBrush(Color.FromArgb(20, 70, 130, 120)))
                {
                    e.Graphics.FillRectangle(brush, 0, 0, 60, 60);
                }
            };

            parent.Controls.Add(shape1);
            parent.Controls.Add(shape2);
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            // Warm, soft gradient background
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0), new Point(mainPanel.Width, mainPanel.Height),
                Color.FromArgb(250, 252, 252),
                Color.FromArgb(240, 248, 248)))
            {
                e.Graphics.FillRectangle(brush, mainPanel.ClientRectangle);
            }
        }

        private void HeaderPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            // Teal gradient header
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0), new Point(p.Width, 0),
                Color.FromArgb(70, 130, 120),
                Color.FromArgb(100, 160, 150)))
            {
                e.Graphics.FillRectangle(brush, 0, 0, p.Width, p.Height);
            }

            // Decorative geometric shapes
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Circle 1
            using (Brush circleBrush = new SolidBrush(Color.FromArgb(40, 255, 255, 255)))
            {
                e.Graphics.FillEllipse(circleBrush, -30, 80, 100, 100);
            }

            // Circle 2
            using (Brush circleBrush = new SolidBrush(Color.FromArgb(25, 255, 255, 255)))
            {
                e.Graphics.FillEllipse(circleBrush, 550, 30, 150, 150);
            }

            // Triangle
            using (Brush triangleBrush = new SolidBrush(Color.FromArgb(30, 255, 255, 255)))
            {
                Point[] points = new Point[] { new Point(450, 180), new Point(520, 120), new Point(580, 180) };
                e.Graphics.FillPolygon(triangleBrush, points);
            }
        }

        private void RegCard_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            // Draw rounded card with shadow effect
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Shadow
            using (Brush shadowBrush = new SolidBrush(Color.FromArgb(15, 0, 0, 0)))
            {
                GraphicsPath shadowPath = new GraphicsPath();
                Rectangle shadowRect = new Rectangle(5, 5, p.Width, p.Height);
                int shadowRadius = 15;
                shadowPath.AddArc(shadowRect.X, shadowRect.Y, shadowRadius, shadowRadius, 180, 90);
                shadowPath.AddArc(shadowRect.Right - shadowRadius, shadowRect.Y, shadowRadius, shadowRadius, 270, 90);
                shadowPath.AddArc(shadowRect.Right - shadowRadius, shadowRect.Bottom - shadowRadius, shadowRadius, shadowRadius, 0, 90);
                shadowPath.AddArc(shadowRect.X, shadowRect.Bottom - shadowRadius, shadowRadius, shadowRadius, 90, 90);
                shadowPath.CloseFigure();
                e.Graphics.FillPath(shadowBrush, shadowPath);
            }

            // Card background
            using (Brush cardBrush = new SolidBrush(Color.White))
            {
                GraphicsPath cardPath = new GraphicsPath();
                Rectangle cardRect = new Rectangle(0, 0, p.Width - 1, p.Height - 1);
                int cardRadius = 15;
                cardPath.AddArc(cardRect.X, cardRect.Y, cardRadius, cardRadius, 180, 90);
                cardPath.AddArc(cardRect.Right - cardRadius, cardRect.Y, cardRadius, cardRadius, 270, 90);
                cardPath.AddArc(cardRect.Right - cardRadius, cardRect.Bottom - cardRadius, cardRadius, cardRadius, 0, 90);
                cardPath.AddArc(cardRect.X, cardRect.Bottom - cardRadius, cardRadius, cardRadius, 90, 90);
                cardPath.CloseFigure();
                e.Graphics.FillPath(cardBrush, cardPath);

                // Subtle border
                using (Pen borderPen = new Pen(Color.FromArgb(230, 240, 240), 1))
                {
                    e.Graphics.DrawPath(borderPen, cardPath);
                }
            }
        }

        private void RoundedButton_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
            int radius = 12;

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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string staffId = txtStaffId.Text.Trim();
            string staffName = txtStaffName.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string email = txtEmail.Text.Trim();
            string role = cboRole.SelectedItem?.ToString();

            Console.WriteLine("[RegistrationForm] BtnRegister_Click called!");
            Console.WriteLine($"  - staffId: '{staffId}'");
            Console.WriteLine($"  - staffName: '{staffName}'");
            Console.WriteLine($"  - password: '{password}' (length: {password?.Length ?? 0})");
            Console.WriteLine($"  - confirmPassword: '{confirmPassword}' (length: {confirmPassword?.Length ?? 0})");
            Console.WriteLine($"  - email: '{email}'");
            Console.WriteLine($"  - role: '{role}'");

            // Validate inputs
            if (string.IsNullOrWhiteSpace(staffId) || string.IsNullOrWhiteSpace(staffName) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(role))
            {
                Console.WriteLine("[RegistrationForm] Validation failed: some fields are empty!");
                MessageBox.Show(
                    isEnglish ? "Please fill in all fields." : "請填寫所有欄位。",
                    isEnglish ? "Input Error" : "輸入錯誤",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                Console.WriteLine("[RegistrationForm] Validation failed: passwords don't match!");
                MessageBox.Show(
                    isEnglish ? "Passwords do not match." : "密碼不匹配。",
                    isEnglish ? "Input Error" : "輸入錯誤",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 8)
            {
                Console.WriteLine("[RegistrationForm] Validation failed: password too short!");
                MessageBox.Show(
                    isEnglish ? "Password must be at least 8 characters long." : "密碼至少需要 8 個字符。",
                    isEnglish ? "Input Error" : "輸入錯誤",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Console.WriteLine("[RegistrationForm] Calling LoginController.RegisterStaff...");
                LoginController controller = new LoginController();
                string result = controller.RegisterStaff(staffId, staffName, password, email, role);
                Console.WriteLine($"[RegistrationForm] RegisterStaff returned: '{result}'");

                switch (result)
                {
                    case "success":
                        MessageBox.Show(
                            isEnglish ? "Registration successful! You can now login with your new account." : "註冊成功！您現在可以使用新帳號登入了。",
                            isEnglish ? "Success" : "成功",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        this.Close();
                        break;
                    case "user_exists":
                        MessageBox.Show(
                            isEnglish ? "Staff ID already exists. Please choose a different ID." : "員工 ID 已存在，請選擇不同的 ID。",
                            isEnglish ? "Registration Failed" : "註冊失敗",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        break;
                    case "error":
                        MessageBox.Show(
                            isEnglish ? 
                            "Registration failed. This may be due to database connection issues.\nFor testing, you can still try to login with existing accounts or contact IT support." : 
                            "註冊失敗，可能是因為資料庫連線問題。\n測試時，您仍然可以使用已存在的帳號登入，或聯繫 IT 支援。",
                            isEnglish ? "Registration Failed" : "註冊失敗",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[RegistrationForm] Exception: {ex.Message}");
                Console.WriteLine($"[RegistrationForm] Stack trace: {ex.StackTrace}");
                MessageBox.Show(
                    isEnglish ? 
                    $"Error: {ex.Message}\n\nStack Trace: {ex.StackTrace}\n\nThis may be due to database connection issues.\nFor testing, you can still try to login with existing accounts." : 
                    $"錯誤：{ex.Message}\n\n堆疊追蹤：{ex.StackTrace}\n\n可能是因為資料庫連線問題。\n測試時，您仍然可以使用已存在的帳號登入。",
                    isEnglish ? "Error" : "錯誤",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UpdateUIText()
        {
            this.Text = isEnglish ? "Register New Staff" : "註冊新員工";
            btnLanguageToggle.Text = isEnglish ? "中文" : "English";
            lblTitle.Text = isEnglish ? "Create Account" : "建立帳號";
            
            // Update subtitle
            if (lblSubtitle != null)
            {
                lblSubtitle.Text = isEnglish ? "Join our team today" : "今天就加入我們";
            }
            
            lblStaffId.Text = isEnglish ? "Staff ID" : "員工 ID";
            lblStaffName.Text = isEnglish ? "Staff Name" : "員工姓名";
            lblEmail.Text = isEnglish ? "Email" : "電子郵件";
            lblRole.Text = isEnglish ? "Role" : "職位";
            lblPassword.Text = isEnglish ? "Password" : "密碼";
            lblConfirmPassword.Text = isEnglish ? "Confirm Password" : "確認密碼";
            btnRegister.Text = isEnglish ? "Create Account" : "建立帳號";
            btnCancel.Text = isEnglish ? "Cancel" : "取消";
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (loginForm != null)
            {
                loginForm.Show();
            }
        }
    }
}
