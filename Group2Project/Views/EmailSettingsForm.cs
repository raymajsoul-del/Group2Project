using System;
using System.Drawing;
using System.Windows.Forms;

namespace Group2Project.Views
{
    public class EmailSettingsForm : Form
    {
        private TextBox txtSmtpServer, txtSmtpPort, txtSenderEmail, txtSenderPassword;
        private CheckBox chkEnableEmail, chkEnableSsl;
        private Button btnSave, btnCancel, btnTest;
        private Label lblTitle, lblStatus;
        private bool isEnglish = true;

        public EmailSettingsForm()
        {
            SetupUI();
            LoadCurrentSettings();
        }

        private void SetupUI()
        {
            this.Text = "Email Settings";
            this.Size = new Size(500, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Title
            lblTitle = new Label
            {
                Text = "Email Configuration",
                Size = new Size(440, 40),
                Location = new Point(30, 20),
                Font = new Font("Microsoft YaHei", 18, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(46, 125, 50)
            };

            // Quick Presets
            var lblQuickPreset = new Label
            {
                Text = "Quick Preset (select to auto-configure):",
                Size = new Size(440, 22),
                Location = new Point(30, 70),
                Font = new Font("Microsoft YaHei", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(80, 80, 80)
            };
            var cmbPreset = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Size = new Size(440, 30),
                Location = new Point(30, 95),
                Font = new Font("Microsoft YaHei", 10)
            };
            cmbPreset.Items.AddRange(new object[] { 
                "Demo Mode (No Emails)", 
                "Gmail", 
                "Outlook / Hotmail", 
                "Yahoo Mail",
                "Custom (Manual Setup)"
            });
            cmbPreset.SelectedIndex = 0;
            cmbPreset.SelectedIndexChanged += (s, e) =>
            {
                switch (cmbPreset.SelectedIndex)
                {
                    case 0: // Demo
                        chkEnableEmail.Checked = false;
                        txtSmtpServer.Text = "smtp.gmail.com";
                        txtSmtpPort.Text = "587";
                        txtSenderEmail.Text = "noreply@betterlimited.com";
                        txtSenderPassword.Text = "";
                        chkEnableSsl.Checked = true;
                        break;
                    case 1: // Gmail
                        chkEnableEmail.Checked = true;
                        txtSmtpServer.Text = "smtp.gmail.com";
                        txtSmtpPort.Text = "587";
                        txtSenderEmail.Text = "yourname@gmail.com";
                        txtSenderPassword.Text = "";
                        chkEnableSsl.Checked = true;
                        break;
                    case 2: // Outlook
                        chkEnableEmail.Checked = true;
                        txtSmtpServer.Text = "smtp.office365.com";
                        txtSmtpPort.Text = "587";
                        txtSenderEmail.Text = "yourname@outlook.com";
                        txtSenderPassword.Text = "";
                        chkEnableSsl.Checked = true;
                        break;
                    case 3: // Yahoo
                        chkEnableEmail.Checked = true;
                        txtSmtpServer.Text = "smtp.mail.yahoo.com";
                        txtSmtpPort.Text = "587";
                        txtSenderEmail.Text = "yourname@yahoo.com";
                        txtSenderPassword.Text = "";
                        chkEnableSsl.Checked = true;
                        break;
                }
                ToggleSettingsEnabled();
            };

            // Enable Email Checkbox
            chkEnableEmail = new CheckBox
            {
                Text = "Enable Real Email Sending (Disable for Demo Mode)",
                Size = new Size(440, 25),
                Location = new Point(30, 135),
                Font = new Font("Microsoft YaHei", 10),
                Checked = false // 默认为演示模式
            };
            chkEnableEmail.CheckedChanged += (s, e) => ToggleSettingsEnabled();

            // SMTP Server
            AddLabel("SMTP Server", 175);
            txtSmtpServer = new TextBox
            {
                Text = "smtp.gmail.com",
                Size = new Size(440, 30),
                Location = new Point(30, 200),
                Font = new Font("Microsoft YaHei", 11),
                BorderStyle = BorderStyle.FixedSingle,
                Enabled = false
            };

            // SMTP Port
            AddLabel("SMTP Port", 240);
            txtSmtpPort = new TextBox
            {
                Text = "587",
                Size = new Size(440, 30),
                Location = new Point(30, 265),
                Font = new Font("Microsoft YaHei", 11),
                BorderStyle = BorderStyle.FixedSingle,
                Enabled = false
            };

            // Sender Email
            AddLabel("Sender Email", 305);
            txtSenderEmail = new TextBox
            {
                Text = "noreply@betterlimited.com",
                Size = new Size(440, 30),
                Location = new Point(30, 330),
                Font = new Font("Microsoft YaHei", 11),
                BorderStyle = BorderStyle.FixedSingle,
                Enabled = false
            };

            // Sender Password
            AddLabel("Sender Password / App Password", 370);
            txtSenderPassword = new TextBox
            {
                Text = "",
                Size = new Size(440, 30),
                Location = new Point(30, 395),
                Font = new Font("Microsoft YaHei", 11),
                BorderStyle = BorderStyle.FixedSingle,
                UseSystemPasswordChar = true,
                Enabled = false
            };

            // Enable SSL
            chkEnableSsl = new CheckBox
            {
                Text = "Enable SSL / TLS",
                Size = new Size(440, 25),
                Location = new Point(30, 435),
                Font = new Font("Microsoft YaHei", 10),
                Checked = true,
                Enabled = false
            };

            // Status Label
            lblStatus = new Label
            {
                Text = "",
                Size = new Size(440, 30),
                Location = new Point(30, 465),
                Font = new Font("Microsoft YaHei", 9),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Buttons
            btnTest = new Button
            {
                Text = "Test Connection",
                Size = new Size(140, 40),
                Location = new Point(30, 505),
                Font = new Font("Microsoft YaHei", 10),
                BackColor = Color.FromArgb(232, 106, 16),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Enabled = false
            };
            btnTest.FlatAppearance.BorderSize = 0;
            btnTest.Click += BtnTest_Click;

            btnSave = new Button
            {
                Text = "Save",
                Size = new Size(140, 40),
                Location = new Point(180, 505),
                Font = new Font("Microsoft YaHei", 10),
                BackColor = Color.FromArgb(46, 125, 50),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button
            {
                Text = "Cancel",
                Size = new Size(140, 40),
                Location = new Point(330, 505),
                Font = new Font("Microsoft YaHei", 10),
                BackColor = Color.FromArgb(150, 150, 150),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => this.Close();

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblQuickPreset);
            this.Controls.Add(cmbPreset);
            this.Controls.Add(chkEnableEmail);
            this.Controls.Add(txtSmtpServer);
            this.Controls.Add(txtSmtpPort);
            this.Controls.Add(txtSenderEmail);
            this.Controls.Add(txtSenderPassword);
            this.Controls.Add(chkEnableSsl);
            this.Controls.Add(lblStatus);
            this.Controls.Add(btnTest);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);
        }

        private void AddLabel(string text, int top)
        {
            Label lbl = new Label
            {
                Text = text,
                Size = new Size(440, 22),
                Location = new Point(30, top),
                Font = new Font("Microsoft YaHei", 9),
                ForeColor = Color.FromArgb(80, 80, 80)
            };
            this.Controls.Add(lbl);
        }

        private void LoadCurrentSettings()
        {
            // 从 EmailService 加载当前设置
            var config = DataAccess.EmailService.GetConfig();
            
            txtSmtpServer.Text = config.smtpServer;
            txtSmtpPort.Text = config.smtpPort.ToString();
            txtSenderEmail.Text = config.senderEmail;
            txtSenderPassword.Text = config.senderPassword;
            chkEnableSsl.Checked = config.enableSsl;
            chkEnableEmail.Checked = config.enableEmail;
            
            // 初始化状态
            ToggleSettingsEnabled();
        }

        private void ToggleSettingsEnabled()
        {
            bool enabled = chkEnableEmail.Checked;
            txtSmtpServer.Enabled = enabled;
            txtSmtpPort.Enabled = enabled;
            txtSenderEmail.Enabled = enabled;
            txtSenderPassword.Enabled = enabled;
            chkEnableSsl.Enabled = enabled;
            btnTest.Enabled = enabled;
            
            if (enabled)
            {
                lblStatus.Text = "Configure your SMTP settings below. For Gmail, use an App Password.";
                lblStatus.ForeColor = Color.FromArgb(46, 125, 50);
            }
            else
            {
                lblStatus.Text = "Email sending is disabled (demo mode).";
                lblStatus.ForeColor = Color.Gray;
            }
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            try
            {
                // 验证输入
                if (string.IsNullOrWhiteSpace(txtSmtpServer.Text))
                {
                    MessageBox.Show("Please enter SMTP Server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!int.TryParse(txtSmtpPort.Text, out int port))
                {
                    MessageBox.Show("Please enter a valid SMTP Port number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtSenderEmail.Text))
                {
                    MessageBox.Show("Please enter Sender Email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtSenderPassword.Text))
                {
                    MessageBox.Show("Please enter Sender Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 临时保存配置进行测试
                DataAccess.EmailService.Configure(
                    txtSmtpServer.Text.Trim(),
                    port,
                    txtSenderEmail.Text.Trim(),
                    txtSenderPassword.Text,
                    chkEnableSsl.Checked,
                    true
                );

                MessageBox.Show(
                    "Configuration validated!\n\n" +
                    "The settings are saved temporarily.\n" +
                    "Now try a password reset to test email sending!\n\n" +
                    "Don't forget to click Save to keep these settings.",
                    "Test Passed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Configuration test failed:\n\n{ex.Message}",
                    "Test Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkEnableEmail.Checked)
                {
                    // 验证输入
                    if (string.IsNullOrWhiteSpace(txtSmtpServer.Text))
                    {
                        MessageBox.Show("Please enter SMTP Server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!int.TryParse(txtSmtpPort.Text, out int port))
                    {
                        MessageBox.Show("Please enter a valid SMTP Port number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtSenderEmail.Text))
                    {
                        MessageBox.Show("Please enter Sender Email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtSenderPassword.Text))
                    {
                        MessageBox.Show("Please enter Sender Password / App Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 保存到 EmailService
                    DataAccess.EmailService.Configure(
                        txtSmtpServer.Text.Trim(),
                        port,
                        txtSenderEmail.Text.Trim(),
                        txtSenderPassword.Text,
                        chkEnableSsl.Checked,
                        true
                    );

                    MessageBox.Show(
                        "Email settings saved successfully!\n" +
                        "Real email sending is now enabled.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    // 禁用邮件发送
                    DataAccess.EmailService.SetEmailEnabled(false);
                    MessageBox.Show(
                        "Email sending has been disabled (demo mode).",
                        "Saved",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}