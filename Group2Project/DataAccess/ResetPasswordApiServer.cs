using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Group2Project.DataAccess
{
    public class ResetPasswordApiServer : IDisposable
    {
        private HttpListener _listener;
        private Thread _listenerThread;
        private bool _disposed = false;

        private static readonly string[] _prefixes = new[] { "http://localhost:5233/" };

        public static ResetPasswordApiServer Instance { get; } = new ResetPasswordApiServer();

        private ResetPasswordApiServer() { }

        public void Start()
        {
            if (_listenerThread != null && _listenerThread.IsAlive) return;
            _listenerThread = new Thread(RunListener);
            _listenerThread.IsBackground = true;
            _listenerThread.Start();
        }

        private void RunListener()
        {
            _listener = new HttpListener();
            foreach (var prefix in _prefixes)
            {
                try { _listener.Prefixes.Add(prefix); }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ResetPasswordApiServer] Failed to register prefix {prefix}: {ex.Message}");
                }
            }

            try
            {
                _listener.Start();
                Console.WriteLine("[ResetPasswordApiServer] Running on http://localhost:5233/");

                while (!_disposed)
                {
                    var ctx = _listener.GetContext(); // blocking
                    _ = Task.Run(() => HandleRequest(ctx));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ResetPasswordApiServer] Error: {ex.Message}");
            }
        }

        private void HandleRequest(HttpListenerContext ctx)
        {
            try
            {
                var url = ctx.Request.Url;
                var path = url?.AbsolutePath ?? "";

                if (path.StartsWith("/api/login/resetpwd", StringComparison.OrdinalIgnoreCase))
                {
                    HandleResetPassword(ctx);
                }
                else
                {
                    Respond(ctx, 404, "text/plain", "Not Found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ResetPasswordApiServer] Request error: {ex.Message}");
                Respond(ctx, 500, "text/plain", "Internal Server Error");
            }
        }

        private void HandleResetPassword(HttpListenerContext ctx)
        {
            var url = ctx.Request.Url;
            var token = GetQueryParameter(url, "token");
            var lang = GetQueryParameter(url, "lang") ?? "en";
            var path = ctx.Request.Url?.AbsolutePath ?? "";

            // GET request - show the password reset form
            if (ctx.Request.HttpMethod == "GET")
            {
                if (string.IsNullOrEmpty(token))
                {
                    Respond(ctx, 400, "text/html; charset=utf-8", BuildErrorPage("Invalid reset link", lang));
                    return;
                }

                string html = BuildResetPasswordPage(token, lang);
                Respond(ctx, 200, "text/html; charset=utf-8", html);
            }
            // POST request - submit new password
            else if (ctx.Request.HttpMethod == "POST")
            {
                string body = ReadRequestBody(ctx);
                var formData = ParseFormUrlEncoded(body);
                string newPassword = formData.GetValueOrDefault("newPassword") ?? "";
                string confirmPassword = formData.GetValueOrDefault("confirmPassword") ?? "";
                string submitToken = url?.Query.Contains("token=") != true ? token : GetQueryParameter(url, "token");

                if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(submitToken))
                {
                    Respond(ctx, 400, "text/html; charset=utf-8", BuildErrorPage("Missing fields", lang));
                    return;
                }

                if (newPassword != confirmPassword)
                {
                    Respond(ctx, 400, "text/html; charset=utf-8",
                        BuildErrorPage(lang == "zh" ? "两次输入的密码不一致" : "Passwords do not match", lang));
                    return;
                }

                bool success = ResetPasswordInDatabase(submitToken, newPassword);
                if (success)
                {
                    string title = lang == "zh" ? "密码重置成功" : "Password Reset Successful";
                    string msg = lang == "zh"
                        ? "<p>您的密码已成功重置。请使用新密码登录系统。</p><p><a href='http://localhost:5233/' style='color:#4CAF50'>返回登录</a></p>"
                        : "<p>Your password has been reset successfully. Please use your new password to log in.</p><p><a href='http://localhost:5233/' style='color:#4CAF50'>Back to Login</a></p>";
                    Respond(ctx, 200, "text/html; charset=utf-8", BuildSuccessPage(title, msg, lang));
                }
                else
                {
                    string msg = lang == "zh" ? "重置链接无效或已过期" : "Invalid or expired reset link";
                    Respond(ctx, 400, "text/html; charset=utf-8", BuildErrorPage(msg, lang));
                }
            }
        }

        private bool ResetPasswordInDatabase(string token, string newPassword)
        {
            try
            {
                using (MySqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();

                    // Verify token and get staff_id
                    string checkSql = "SELECT staff_id, expires_at, is_used FROM password_reset_tokens WHERE token = @token";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@token", token);
                        using (MySqlDataReader reader = checkCmd.ExecuteReader())
                        {
                            if (!reader.Read())
                                return false;

                            DateTime expiresAt = reader.GetDateTime("expires_at");
                            bool isUsed = reader.GetBoolean("is_used");

                            if (DateTime.UtcNow > expiresAt || isUsed)
                                return false;

                            string staffId = reader.GetString("staff_id");

                            // Update password
                            string updateSql = "UPDATE staff SET password = @pwd WHERE staff_id = @sid";
                            using (MySqlCommand updateCmd = new MySqlCommand(updateSql, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@pwd", newPassword);
                                updateCmd.Parameters.AddWithValue("@sid", staffId);
                                updateCmd.ExecuteNonQuery();
                            }

                            // Mark token as used
                            string markSql = "UPDATE password_reset_tokens SET is_used = 1 WHERE token = @token";
                            using (MySqlCommand markCmd = new MySqlCommand(markSql, conn))
                            {
                                markCmd.Parameters.AddWithValue("@token", token);
                                markCmd.ExecuteNonQuery();
                            }

                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ResetPasswordApiServer] DB error: {ex.Message}");
                return false;
            }
        }

        private string BuildResetPasswordPage(string token, string lang)
        {
            string title = lang == "zh" ? "重置密码" : "Reset Password";
            string pwdLabel = lang == "zh" ? "新密码" : "Your new password";
            string confirmLabel = lang == "zh" ? "确认新密码" : "Confirm new password";
            string submitText = lang == "zh" ? "提交" : "Submit";

            return $@"
<!DOCTYPE html>
<html lang='{lang}'>
<head>
    <meta charset='utf-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>{title}</title>
    <style>
        * {{ margin: 0; padding: 0; box-sizing: border-box; }}
        body {{ font-family: 'Segoe UI', Arial, sans-serif; background: #1a1a1a; color: #fff; min-height: 100vh; display: flex; justify-content: center; align-items: center; }}
        .container {{ width: 100%; max-width: 450px; padding: 20px; }}
        h1 {{ text-align: center; color: #4CAF50; font-size: 28px; margin-bottom: 30px; }}
        input[type='text'], input[type='password'] {{ width: 100%; padding: 14px 16px; margin-bottom: 16px; border: 1px solid #555; border-radius: 6px; background: #fff; color: #333; font-size: 14px; outline: none; }}
        input:focus {{ border-color: #4CAF50; }}
        button {{ width: 100%; padding: 14px; background: #2e7d32; color: #fff; border: none; border-radius: 6px; font-size: 16px; font-weight: bold; cursor: pointer; margin-top: 10px; }}
        button:hover {{ background: #388e3c; }}
    </style>
</head>
<body>
    <div class='container'>
        <h1>{title}</h1>
        <form method='POST' action='/api/login/resetpwd?page?token={token}&lang={lang}'>
            <input type='password' name='newPassword' placeholder='{pwdLabel}' required>
            <input type='password' name='confirmPassword' placeholder='{confirmLabel}' required>
            <button type='submit'>{submitText}</button>
        </form>
    </div>
</body>
</html>";
        }

        private string BuildSuccessPage(string title, string message, string lang)
        {
            return $@"
<!DOCTYPE html>
<html><head><meta charset='utf-8'><title>{title}</title>
<style>
    body {{ font-family: 'Segoe UI', Arial, sans-serif; background: #1a1a1a; color: #fff; min-height: 100vh; display: flex; justify-content: center; align-items: center; }}
    .container {{ text-align: center; max-width: 500px; padding: 40px; }}
    h1 {{ color: #4CAF50; font-size: 28px; margin-bottom: 20px; }}
    p {{ font-size: 16px; margin: 10px 0; color: #ccc; }}
</style>
</head><body>
<div class='container'>
    <h1>{title}</h1>
    {message}
</div>
</body></html>";
        }

        private string BuildErrorPage(string message, string lang)
        {
            return $@"
<!DOCTYPE html>
<html><head><meta charset='utf-8'><title>Error</title>
<style>
    body {{ font-family: 'Segoe UI', Arial, sans-serif; background: #1a1a1a; color: #fff; min-height: 100vh; display: flex; justify-content: center; align-items: center; }}
    .container {{ text-align: center; max-width: 500px; padding: 40px; }}
    h1 {{ color: #f44336; font-size: 24px; margin-bottom: 20px; }}
    p {{ font-size: 16px; color: #ccc; }}
</style>
</head><body>
<div class='container'>
    <h1>Error</h1>
    <p>{message}</p>
</div>
</body></html>";
        }

        private void Respond(HttpListenerContext ctx, int statusCode, string contentType, string body)
        {
            ctx.Response.StatusCode = statusCode;
            ctx.Response.ContentType = contentType;
            byte[] buffer = Encoding.UTF8.GetBytes(body);
            ctx.Response.ContentLength64 = buffer.Length;
            ctx.Response.OutputStream.Write(buffer, 0, buffer.Length);
            ctx.Response.OutputStream.Close();
        }

        private string ReadRequestBody(HttpListenerContext ctx)
        {
            using (var reader = new StreamReader(ctx.Request.InputStream))
            {
                return reader.ReadToEnd();
            }
        }

        private System.Collections.Generic.Dictionary<string, string> ParseFormUrlEncoded(string formData)
        {
            var result = new System.Collections.Generic.Dictionary<string, string>();
            if (string.IsNullOrEmpty(formData)) return result;
            foreach (var pair in formData.Split('&'))
            {
                var parts = pair.Split('=');
                if (parts.Length == 2)
                {
                    result[Uri.UnescapeDataString(parts[0])] = Uri.UnescapeDataString(parts[1]);
                }
            }
            return result;
        }

        private static string GetQueryParameter(System.Uri url, string key)
        {
            if (url == null) return null;
            var query = url.Query;
            if (string.IsNullOrEmpty(query)) return null;
            // Handle complex query strings like "?page?token=xxx&lang=en"
            foreach (var segment in query.Split('?'))
            {
                foreach (var param in segment.Split('&'))
                {
                    if (param.StartsWith("=")) continue;
                    var parts = param.Split('=');
                    if (parts.Length == 2 && parts[0] == key)
                        return Uri.UnescapeDataString(parts[1]);
                }
            }
            return null;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            _listener?.Stop();
            _listener?.Close();
        }
    }
}