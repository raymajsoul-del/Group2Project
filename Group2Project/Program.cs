namespace Group2Project
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Console.WriteLine("Starting application...");
                
                // Initialize Email Service (default to demo mode)
                Console.WriteLine("Initializing Email Service (demo mode)...");
                DataAccess.EmailService.SetEmailEnabled(false); // 默认为演示模式，不发送真实邮件
                
                // Start the password reset HTTP API server (optional)
                try
                {
                    Console.WriteLine("Starting ResetPasswordApiServer...");
                    DataAccess.ResetPasswordApiServer.Instance.Start();
                    Console.WriteLine("ResetPasswordApiServer started successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to start password reset server: {ex.Message}");
                    Console.WriteLine($"Stack trace: {ex.StackTrace}");
                    MessageBox.Show($"Failed to start password reset server: {ex.Message}", 
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Initialize application
                Console.WriteLine("Initializing application configuration...");
                ApplicationConfiguration.Initialize();
                
                // Create application context and run
                Console.WriteLine("Creating application context...");
                var context = new AppContext();
                Application.Run(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FATAL ERROR in Main: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                MessageBox.Show($"Application Error: {ex.Message}\n\nStack Trace: {ex.StackTrace}", 
                    "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    /// <summary>
    /// 自定义应用程序上下文，用于管理登录和主窗体的切换
    /// </summary>
    public class AppContext : ApplicationContext
    {
        private Views.LoginForm? loginForm;
        private Views.MainForm? mainForm;

        public AppContext()
        {
            ShowLoginForm();
        }

        public void ShowLoginForm()
        {
            Console.WriteLine("Showing LoginForm...");
            loginForm = new Views.LoginForm(this);
            loginForm.FormClosed += LoginForm_FormClosed;
            loginForm.Show();
            MainForm = loginForm;
        }

        public void ShowMainForm(Models.Staff user)
        {
            Console.WriteLine("Switching to MainForm...");
            if (loginForm != null)
            {
                loginForm.FormClosed -= LoginForm_FormClosed;
                loginForm.Hide();
            }

            mainForm = new Views.MainForm(user, this);
            mainForm.FormClosed += MainForm_FormClosed;
            mainForm.Show();
            MainForm = mainForm;

            if (loginForm != null)
            {
                loginForm.Dispose();
                loginForm = null;
            }
        }

        public void Logout()
        {
            Console.WriteLine("Logging out...");
            if (mainForm != null)
            {
                mainForm.FormClosed -= MainForm_FormClosed;
                mainForm.Hide();
            }

            ShowLoginForm();

            if (mainForm != null)
            {
                mainForm.Dispose();
                mainForm = null;
            }
        }

        private void LoginForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Console.WriteLine("LoginForm closed, exiting application...");
            ExitThread();
        }

        private void MainForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Console.WriteLine("MainForm closed, exiting application...");
            ExitThread();
        }
    }
}