using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;

namespace Group2Project.DataAccess
{
    public class EmailService
    {
        // SMTP configuration - modify these for your email provider
        // 注意：对于 Gmail，您需要创建一个 App Password
        // 请查看说明文档了解如何配置
        private static string SmtpServer = "smtp.gmail.com";
        private static int SmtpPort = 587;
        private static string SenderEmail = "noreply@betterlimited.com";
        private static string SenderPassword = "your-app-password-here";
        private static bool EnableSsl = true;

        // 配置标志：是否启用真实邮件发送
        private static bool EnableEmailEnabled = false; // 默认关闭演示模式
        
        // 配置文件路径
        private static string ConfigFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "email_config.json");

        /// <summary>
        /// Email configuration class for JSON serialization
        /// </summary>
        private class EmailConfig
        {
            public string SmtpServer { get; set; } = "smtp.gmail.com";
            public int SmtpPort { get; set; } = 587;
            public string SenderEmail { get; set; } = "noreply@betterlimited.com";
            public string SenderPassword { get; set; } = "";
            public bool EnableSsl { get; set; } = true;
            public bool EnableEmailEnabled { get; set; } = false;
        }

        /// <summary>
        /// Static constructor - load configuration when app starts
        /// </summary>
        static EmailService()
        {
            LoadConfig();
        }

        /// <summary>
        /// Load configuration from file
        /// </summary>
        private static void LoadConfig()
        {
            try
            {
                if (File.Exists(ConfigFilePath))
                {
                    string json = File.ReadAllText(ConfigFilePath);
                    var config = JsonSerializer.Deserialize<EmailConfig>(json);
                    if (config != null)
                    {
                        SmtpServer = config.SmtpServer;
                        SmtpPort = config.SmtpPort;
                        SenderEmail = config.SenderEmail;
                        SenderPassword = config.SenderPassword;
                        EnableSsl = config.EnableSsl;
                        EnableEmailEnabled = config.EnableEmailEnabled;
                        Console.WriteLine("[EmailService] Configuration loaded from file");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EmailService] Error loading config: {ex.Message}");
                // Use default values if load fails
            }
        }

        /// <summary>
        /// Save configuration to file
        /// </summary>
        private static void SaveConfig()
        {
            try
            {
                var config = new EmailConfig
                {
                    SmtpServer = SmtpServer,
                    SmtpPort = SmtpPort,
                    SenderEmail = SenderEmail,
                    SenderPassword = SenderPassword,
                    EnableSsl = EnableSsl,
                    EnableEmailEnabled = EnableEmailEnabled
                };
                
                string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(ConfigFilePath, json);
                Console.WriteLine("[EmailService] Configuration saved to file");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EmailService] Error saving config: {ex.Message}");
            }
        }

        /// <summary>
        /// Configure the email service settings and save to file
        /// </summary>
        public static void Configure(string smtpServer, int smtpPort, string senderEmail, string senderPassword, bool enableSsl, bool enableEmail)
        {
            SmtpServer = smtpServer;
            SmtpPort = smtpPort;
            SenderEmail = senderEmail;
            SenderPassword = senderPassword;
            EnableSsl = enableSsl;
            EnableEmailEnabled = enableEmail;
            SaveConfig();
        }

        /// <summary>
        /// Enable or disable real email sending and save to file
        /// </summary>
        public static void SetEmailEnabled(bool enabled)
        {
            EnableEmailEnabled = enabled;
            SaveConfig();
        }

        /// <summary>
        /// Get current configuration for UI
        /// </summary>
        public static (string smtpServer, int smtpPort, string senderEmail, string senderPassword, bool enableSsl, bool enableEmail) GetConfig()
        {
            return (SmtpServer, SmtpPort, SenderEmail, SenderPassword, EnableSsl, EnableEmailEnabled);
        }

        /// <summary>
        /// Send a password reset email to the user.
        /// </summary>
        /// <param name="toEmail">Recipient email address</param>
        /// <param name="userName">Staff username for personalization</param>
        /// <param name="resetToken">Unique token for password reset</param>
        /// <param name="lang">Language: "en" or "zh" (default "en")</param>
        /// <returns>Tuple indicating success and a detailed message</returns>
        public static (bool success, string message) SendPasswordResetEmail(string toEmail, string userName, string resetToken, string lang = "en")
        {
            Console.WriteLine($"[EmailService] Sending password reset email to {toEmail}");
            
            // 如果邮件功能未启用，返回演示模式状态
            if (!EnableEmailEnabled)
            {
                string msg = $"Email sending is DISABLED (demo mode).\n\nReset token: {resetToken}\n\nTo enable real emails, click the settings button (⚙) on the login screen and check 'Enable Real Email Sending'.";
                Console.WriteLine($"[EmailService] {msg}");
                return (true, msg);
            }

            string resetLink = $"http://localhost:5233/api/login/resetpwd?token={resetToken}&lang={lang}";
            string subject = lang == "zh" ? "重置您的密码 - The Better Limited" : "Reset Your Password - The Better Limited";
            string body = BuildEmailBody(userName, resetLink, resetToken, lang);

            try
            {
                string configInfo = $"SMTP: {SmtpServer}:{SmtpPort}\nFrom: {SenderEmail}\nSSL: {(EnableSsl ? "Yes" : "No")}";
                Console.WriteLine($"[EmailService] Using SMTP: {configInfo}");
                
                var smtp = new SmtpClient(SmtpServer)
                {
                    Port = SmtpPort,
                    Credentials = new NetworkCredential(SenderEmail, SenderPassword),
                    EnableSsl = EnableSsl,
                    Timeout = 10000 // 10 seconds timeout
                };

                MailMessage message = new MailMessage
                {
                    From = new MailAddress(SenderEmail, "TheBetterLimited -- IT Team"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                message.To.Add(toEmail);

                Console.WriteLine("[EmailService] Sending email...");
                smtp.Send(message);
                Console.WriteLine("[EmailService] Email sent successfully!");
                return (true, $"Email sent successfully!\n\n{configInfo}");
            }
            catch (Exception ex)
            {
                string errorMsg = $"Failed to send email:\n\nError: {ex.Message}\n\nPlease check your email settings (click ⚙ on login screen).";
                Console.WriteLine($"[EmailService] {errorMsg}");
                Console.WriteLine($"[EmailService] Stack trace: {ex.StackTrace}");
                return (false, errorMsg);
            }
        }

        private static string BuildEmailBody(string userName, string resetLink, string token, string lang)
        {
            if (lang == "zh")
            {
                return $@"
<!DOCTYPE html>
<html>
<head><meta charset='utf-8'><title>重置密码</title></head>
<body style='font-family: Arial, sans-serif; background-color: #f5f5f5; color: #333333; margin: 0; padding: 40px 20px;'>
<div style='max-width: 600px; margin: auto; background: #ffffff; padding: 40px; border-radius: 8px; box-shadow: 0 2px 10px rgba(0,0,0,0.1);'>
    <h1 style='color: #2e7d32; text-align: center; margin-top: 0;'>重置密码请求</h1>
    <div style='background: #f9f9f9; padding: 25px; border-radius: 4px; border: 1px solid #eeeeee;'>
        <p style='font-size: 16px; line-height: 1.6;'>
            您好，{userName}！</p>
        <p style='font-size: 16px; line-height: 1.6;'>
            我们收到了您的密码重置请求。请点击下面的按钮重置您的密码：</p>
        <div style='text-align: center; margin: 30px 0;'>
            <a href='{resetLink}' style='background: #2e7d32; color: #ffffff; padding: 14px 40px; text-decoration: none; border-radius: 4px; display: inline-block; font-size: 16px; font-weight: bold;'>
                重置密码
            </a>
        </div>
        <p style='font-size: 14px; line-height: 1.6; color: #666666;'>
            您的重置令牌（Token）：<code style='background: #eeeeee; padding: 2px 6px; border-radius: 3px;'>{token}</code>
        </p>
        <p style='font-size: 14px; line-height: 1.6; color: #666666;'>
            此链接将在 <strong>10 分钟</strong> 后过期。
        </p>
        <p style='font-size: 14px; line-height: 1.6; color: #666666;'>
            如果您没有请求重置密码，请忽略此邮件，您的密码不会更改。
        </p>
        <p style='font-size: 14px; line-height: 1.6; margin-top: 30px; padding-top: 20px; border-top: 1px solid #eeeeee; color: #888888;'>
            此致<br>
            The Better Limited 管理团队
        </p>
    </div>
</div>
</body>
</html>";
            }
            else
            {
                return $@"
<!DOCTYPE html>
<html>
<head><meta charset='utf-8'><title>Reset Password</title></head>
<body style='font-family: Arial, sans-serif; background-color: #f5f5f5; color: #333333; margin: 0; padding: 40px 20px;'>
<div style='max-width: 600px; margin: auto; background: #ffffff; padding: 40px; border-radius: 8px; box-shadow: 0 2px 10px rgba(0,0,0,0.1);'>
    <h1 style='color: #2e7d32; text-align: center; margin-top: 0;'>Password Reset Request</h1>
    <div style='background: #f9f9f9; padding: 25px; border-radius: 4px; border: 1px solid #eeeeee;'>
        <p style='font-size: 16px; line-height: 1.6;'>
            Hello, {userName}!</p>
        <p style='font-size: 16px; line-height: 1.6;'>
            We received a request to reset your password. Click the button below to reset your password:
        </p>
        <div style='text-align: center; margin: 30px 0;'>
            <a href='{resetLink}' style='background: #2e7d32; color: #ffffff; padding: 14px 40px; text-decoration: none; border-radius: 4px; display: inline-block; font-size: 16px; font-weight: bold;'>
                Reset Password
            </a>
        </div>
        <p style='font-size: 14px; line-height: 1.6; color: #666666;'>
            Your reset token: <code style='background: #eeeeee; padding: 2px 6px; border-radius: 3px;'>{token}</code>
        </p>
        <p style='font-size: 14px; line-height: 1.6; color: #666666;'>
            This link will expire in <strong>10 minutes</strong>.
        </p>
        <p style='font-size: 14px; line-height: 1.6; color: #666666;'>
            If you didn't request this, please ignore this email. Your password won't change.
        </p>
        <p style='font-size: 14px; line-height: 1.6; margin-top: 30px; padding-top: 20px; border-top: 1px solid #eeeeee; color: #888888;'>
            Regards,<br>
            The Better Limited Management Team
        </p>
    </div>
</div>
</body>
</html>";
            }
        }
    }
}