using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Group2Project.Models;
using Group2Project.Controllers;
using Group2Project.Utils;

namespace Group2Project.Views
{
    public partial class MainForm : Form
    {
        private Staff _currentUser;
        private DashboardController _dashboardController;
        private DashboardController.DashboardData _dashboardData;
        private AppContext _appContext;

        public MainForm(Staff user, AppContext appContext = null)
        {
            try
            {
                Console.WriteLine("MainForm constructor starting...");
                InitializeComponent();
                Console.WriteLine("MainForm InitializeComponent done");
                _currentUser = user;
                _appContext = appContext;
                _dashboardController = new DashboardController();
                Console.WriteLine("MainForm constructor done");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MainForm constructor exception: {ex.Message}\nStack trace: {ex.StackTrace}");
                MessageBox.Show($"MainForm constructor error: {ex.Message}\n\nStack trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("MainForm_Load starting...");
                if (_currentUser != null)
                {
                    lblUser.Text = $"User: {_currentUser.StaffName} ({_currentUser.Role})";
                    ApplyAccessControl();
                }
                else
                {
                    lblUser.Text = "User: Guest";
                }

                // 设置登出按钮的文本
                btnLogout.Text = LanguageManager.GetString("MainForm_Logout");

                // Load dashboard data
                LoadDashboardData();
                pnlDashboard.BringToFront();
                Console.WriteLine("MainForm_Load done");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MainForm_Load exception: {ex.Message}\nStack trace: {ex.StackTrace}");
                MessageBox.Show($"MainForm_Load error: {ex.Message}\n\nStack trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyAccessControl()
        {
            // Hide all buttons first
            btnDashboard.Visible = true; // Dashboard is always visible
            btnOrderProcessing.Visible = false;
            btnOrderHistory.Visible = false;
            btnAfterSales.Visible = false;
            btnFinance.Visible = false;
            btnProduction.Visible = false;
            btnInventory.Visible = false;
            btnLogistics.Visible = false;
            btnReports.Visible = false;
            btnMasterData.Visible = false;
            btnPOSSales.Visible = false;
            btnPurchase.Visible = false;
            btnShipping.Visible = false;

            // Reset sidebar and button colors to default
            ResetSidebarStyle();

            // Show buttons based on role
            switch (_currentUser.Role?.ToLower())
            {
                case "admin":
            case "manager":
                // Full access
                btnOrderProcessing.Visible = true;
                btnOrderHistory.Visible = true;
                btnAfterSales.Visible = true;
                btnFinance.Visible = true;
                btnProduction.Visible = true;
                btnInventory.Visible = true;
                btnLogistics.Visible = true;
                btnReports.Visible = true;
                btnMasterData.Visible = true;
                btnPOSSales.Visible = true;
                btnPurchase.Visible = true;
                btnShipping.Visible = true;
                break;

                case "sales":
                    btnPOSSales.Visible = true;
                    btnOrderProcessing.Visible = true;
                    btnOrderHistory.Visible = true;
                    break;

                case "finance":
                case "accountant":
                    btnFinance.Visible = true;
                    btnReports.Visible = true;
                    btnInventory.Visible = true;
                    btnPurchase.Visible = true;
                    // Apply accountant-specific styling
                    ApplyAccountantSidebarStyle();
                    break;

                case "inventory":
                    btnInventory.Visible = true;
                    btnShipping.Visible = true;
                    break;
                    
                case "purchase":
                    btnPurchase.Visible = true;
                    break;

                case "production":
                    btnProduction.Visible = true;
                    break;

                case "logistics":
                    btnLogistics.Visible = true;
                    btnShipping.Visible = true;
                    break;

                case "aftersales":
                case "after sales":
                    // Show relevant modules for after sales
                    break;

                case "staff":
                    btnPOSSales.Visible = true;
                    break;
            }

            // Dynamically rearrange visible buttons
            RearrangeSidebarButtons();
        }

        private void ResetSidebarStyle()
        {
            pnlSidebar.BackColor = Color.FromArgb(45, 45, 48);
        }

        private void ApplyAccountantSidebarStyle()
        {
            // Apply unique styling for accountant role - professional teal/blue theme
            pnlSidebar.BackColor = Color.FromArgb(26, 78, 85);
            
            // Style buttons with accountant-specific colors
            Color buttonHoverColor = Color.FromArgb(37, 109, 119);
            Color buttonTextColor = Color.White;
            
            foreach (Control control in pnlSidebar.Controls)
            {
                if (control is Button btn && btn.Visible)
                {
                    btn.ForeColor = buttonTextColor;
                    // We'll handle hover effects via MouseEnter/MouseLeave events if needed
                }
            }
        }

        private void RearrangeSidebarButtons()
        {
            // List of buttons in desired order (top to bottom) - Dashboard related first
            var buttonOrder = new List<Button>
            {
                btnDashboard,
                btnPOSSales,
                btnOrderProcessing,
                btnOrderHistory,
                btnAfterSales,
                btnInventory,
                btnPurchase,
                btnShipping,
                btnFinance,
                btnProduction,
                btnLogistics,
                btnReports,
                btnMasterData
            };

            int yPosition = 13; // Starting Y position
            const int buttonHeight = 63;
            const int buttonSpacing = 0;

            foreach (var button in buttonOrder)
            {
                if (button.Visible)
                {
                    button.Location = new Point(0, yPosition);
                    yPosition += buttonHeight + buttonSpacing;
                }
            }
        }

        private void LoadDashboardData()
        {
            try
            {
                _dashboardData = _dashboardController.GetDashboardData();
                UpdateDashboardUI();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading dashboard data: {ex.Message}");
                // Use sample data if database fails
                LoadSampleData();
            }
        }

        private void LoadSampleData()
        {
            // Create sample data for demonstration
            _dashboardData = new DashboardController.DashboardData
            {
                TotalOrders = 47,
                TotalSoldItems = 156,
                TotalRevenue = 28450.75m,
                TotalGrossProfit = 12780.50m,
                PendingOrders = 8,
                LowStockItems = 3,
                TodayOrders = 12,
                TodayRevenue = 4580.25m
            };

            // Create sample trend data
            _dashboardData.SevenDayTrend = new DataTable();
            _dashboardData.SevenDayTrend.Columns.Add("Date", typeof(DateTime));
            _dashboardData.SevenDayTrend.Columns.Add("OrderCount", typeof(int));

            for (int i = 6; i >= 0; i--)
            {
                _dashboardData.SevenDayTrend.Rows.Add(DateTime.Now.AddDays(-i), 5 + new Random().Next(10));
            }

            // Create sample top products data
            _dashboardData.TopSellingProducts = new DataTable();
            _dashboardData.TopSellingProducts.Columns.Add("ProductName", typeof(string));
            _dashboardData.TopSellingProducts.Columns.Add("TotalQuantity", typeof(int));
            _dashboardData.TopSellingProducts.Columns.Add("TotalRevenue", typeof(decimal));

            _dashboardData.TopSellingProducts.Rows.Add("Classic Chair", 45, 4500.00);
            _dashboardData.TopSellingProducts.Rows.Add("Modern Desk", 32, 6400.00);
            _dashboardData.TopSellingProducts.Rows.Add("Wooden Table", 28, 5600.00);
            _dashboardData.TopSellingProducts.Rows.Add("Office Lamp", 35, 1750.00);
            _dashboardData.TopSellingProducts.Rows.Add("Bookshelf", 16, 3200.00);

            // Create sample recent orders
            _dashboardData.RecentOrders = new DataTable();
            _dashboardData.RecentOrders.Columns.Add("OrderId", typeof(int));
            _dashboardData.RecentOrders.Columns.Add("OrderDate", typeof(DateTime));
            _dashboardData.RecentOrders.Columns.Add("Status", typeof(string));
            _dashboardData.RecentOrders.Columns.Add("Total", typeof(decimal));

            _dashboardData.RecentOrders.Rows.Add(1001, DateTime.Now.AddHours(-2), "Processing", 1250.50m);
            _dashboardData.RecentOrders.Rows.Add(1000, DateTime.Now.AddHours(-5), "Shipped", 890.25m);
            _dashboardData.RecentOrders.Rows.Add(999, DateTime.Now.AddDays(-1), "Completed", 2100.00m);
            _dashboardData.RecentOrders.Rows.Add(998, DateTime.Now.AddDays(-1), "Pending", 450.75m);
            _dashboardData.RecentOrders.Rows.Add(997, DateTime.Now.AddDays(-2), "Completed", 1680.00m);

            UpdateDashboardUI();
        }

        private void UpdateDashboardUI()
        {
            if (_dashboardData == null) return;

            // Update KPI cards
            lblTotalOrders.Text = _dashboardData.TotalOrders.ToString("N0");
            lblTotalSoldItems.Text = _dashboardData.TotalSoldItems.ToString("N0");
            lblTotalRevenue.Text = "$" + _dashboardData.TotalRevenue.ToString("N2");
            lblGrossProfit.Text = "$" + _dashboardData.TotalGrossProfit.ToString("N2");
            lblPendingOrders.Text = _dashboardData.PendingOrders.ToString("N0");
            lblLowStockItems.Text = _dashboardData.LowStockItems.ToString("N0");
            lblTodayOrders.Text = _dashboardData.TodayOrders.ToString("N0");
            lblTodayRevenue.Text = "$" + _dashboardData.TodayRevenue.ToString("N2");

            // Refresh charts and recent orders
            chartOrderTrend.Invalidate();
            chartTopProducts.Invalidate();
            pnlRecentOrders.Invalidate();
        }

        private void ShowSubForm(Form subForm)
        {
            try
            {
                // 首先确保子表单不会意外显示为独立窗口
                subForm.Visible = false;
                subForm.TopLevel = false;
                subForm.FormBorderStyle = FormBorderStyle.None;
                subForm.Dock = DockStyle.Fill;
                
                // 关闭并移除现有表单
                if (pnlContent.Controls.Count > 0)
                {
                    if (pnlContent.Controls[0] is Form oldForm)
                    {
                        oldForm.Close();
                    }
                    pnlContent.Controls.Clear();
                }

                // 添加新表单
                pnlContent.Controls.Add(subForm);
                subForm.Show();
                pnlContent.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法加载界面: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
            pnlDashboard.BringToFront();
        }

        private void btnPOSSales_Click(object sender, EventArgs e)
        {
            DataTable userTable = new DataTable();
            if (_currentUser != null)
            {
                userTable.Columns.Add("StaffName", typeof(string));
                userTable.Columns.Add("Role", typeof(string));
                userTable.Rows.Add(_currentUser.StaffName, _currentUser.Role);
            }
            ShowSubForm(new Sub02_Order.POSForm(userTable));
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Sub05_Inventory.InventoryForm(0));
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Sub11_Purchase.PurchaseForm());
        }

        private void btnShipping_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Sub12_Shipping.ShippingForm());
        }

        private void btnOrderProcessing_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Sub02_Order.PlaceOrderForm());
        }

        private void btnFinance_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Sub03_Finance.AccountingForm());
        }

        private void btnProduction_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Sub04_Production.ProductionManagementForm());
        }

        private void btnLogistics_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Sub06_Logistic.LogisticForm());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Sub08_Reporting.ReportForm());
        }

        private void btnMasterData_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Sub09_MasterData.MasterDataForm());
        }

        private void btnOrderHistory_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Sub01_Account.OrderHistoryForm());
        }

        private void btnAfterSales_Click(object sender, EventArgs e)
        {
            ShowSubForm(new Sub07_AfterSales.AfterSalesForm());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Auto-refresh dashboard data every 30 seconds
            LoadDashboardData();
        }

        private void chartOrderTrend_Paint(object sender, PaintEventArgs e)
        {
            DrawOrderTrendChart(e.Graphics, chartOrderTrend.ClientRectangle);
        }

        private void DrawOrderTrendChart(Graphics g, Rectangle bounds)
        {
            try
            {
                if (_dashboardData?.SevenDayTrend == null || _dashboardData.SevenDayTrend.Rows.Count == 0)
                    return;

                // Set up chart dimensions
                int padding = 40;
                int chartWidth = bounds.Width - padding * 2;
                int chartHeight = bounds.Height - padding * 2;

                // Draw background
                g.Clear(Color.White);

                // Get data
                int maxOrders = 0;
                foreach (DataRow row in _dashboardData.SevenDayTrend.Rows)
                {
                    int orders = SafeConvertToInt32(row["OrderCount"], 0);
                    if (orders > maxOrders) maxOrders = orders;
                }
                if (maxOrders == 0) maxOrders = 1;

                // Draw axes
                Pen axisPen = new Pen(Color.LightGray, 1);
                g.DrawLine(axisPen, padding, bounds.Height - padding, bounds.Width - padding, bounds.Height - padding);
                g.DrawLine(axisPen, padding, padding, padding, bounds.Height - padding);

                // Draw grid lines
                Pen gridPen = new Pen(Color.FromArgb(240, 240, 240), 1);
                for (int i = 0; i <= 5; i++)
                {
                    int y = bounds.Height - padding - (i * chartHeight / 5);
                    g.DrawLine(gridPen, padding, y, bounds.Width - padding, y);

                    // Y-axis labels
                    string label = ((int)(maxOrders * i / 5)).ToString();
                    SizeF labelSize = g.MeasureString(label, new Font("Segoe UI", 8));
                    g.DrawString(label, new Font("Segoe UI", 8), Brushes.Gray, 
                        padding - labelSize.Width - 5, y - labelSize.Height / 2);
                }

                // Draw bars
                int barCount = _dashboardData.SevenDayTrend.Rows.Count;
                float barWidth = (float)chartWidth / barCount * 0.6f;
                float barSpacing = (float)chartWidth / barCount;

                Color[] barColors = { Color.FromArgb(239, 68, 68), Color.FromArgb(245, 158, 11), 
                                      Color.FromArgb(46, 204, 113), Color.FromArgb(102, 126, 234),
                                      Color.FromArgb(168, 85, 247), Color.FromArgb(236, 72, 153),
                                      Color.FromArgb(20, 184, 166) };

                for (int i = 0; i < barCount; i++)
                {
                    DataRow row = _dashboardData.SevenDayTrend.Rows[i];
                    int orders = SafeConvertToInt32(row["OrderCount"], 0);
                    DateTime date = SafeConvertToDateTime(row["Date"], DateTime.Now.AddDays(-(barCount - 1 - i)));

                    float barHeight = (float)orders / maxOrders * chartHeight;
                    float x = padding + i * barSpacing + barSpacing * 0.2f;
                    float y = bounds.Height - padding - barHeight;

                    // Draw bar
                    using (Brush barBrush = new SolidBrush(barColors[i % barColors.Length]))
                    {
                        g.FillRectangle(barBrush, x, y, barWidth, barHeight);
                    }

                    // Draw X-axis label
                    string dateLabel = date.ToString("MM/dd");
                    SizeF dateLabelSize = g.MeasureString(dateLabel, new Font("Segoe UI", 8));
                    g.DrawString(dateLabel, new Font("Segoe UI", 8), Brushes.Gray,
                        x + barWidth / 2 - dateLabelSize.Width / 2, bounds.Height - padding + 5);

                    // Draw value on top of bar
                    string valueLabel = orders.ToString();
                    SizeF valueLabelSize = g.MeasureString(valueLabel, new Font("Segoe UI", 9, FontStyle.Bold));
                    g.DrawString(valueLabel, new Font("Segoe UI", 9, FontStyle.Bold), Brushes.DarkGray,
                        x + barWidth / 2 - valueLabelSize.Width / 2, y - valueLabelSize.Height - 2);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error drawing order trend chart: {ex.Message}");
                g.Clear(Color.White);
                g.DrawString("Error loading chart data", new Font("Segoe UI", 10), Brushes.Red, 10, 10);
            }
        }

        private int SafeConvertToInt32(object value, int defaultValue)
        {
            if (value == null || value == DBNull.Value)
                return defaultValue;
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return defaultValue;
            }
        }

        private DateTime SafeConvertToDateTime(object value, DateTime defaultValue)
        {
            if (value == null || value == DBNull.Value)
                return defaultValue;
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return defaultValue;
            }
        }

        private void chartTopProducts_Paint(object sender, PaintEventArgs e)
        {
            DrawTopProductsChart(e.Graphics, chartTopProducts.ClientRectangle);
        }

        private void DrawTopProductsChart(Graphics g, Rectangle bounds)
        {
            try
            {
                if (_dashboardData?.TopSellingProducts == null || _dashboardData.TopSellingProducts.Rows.Count == 0)
                    return;

                g.Clear(Color.White);

                // Calculate total quantity
                int totalQuantity = 0;
                foreach (DataRow row in _dashboardData.TopSellingProducts.Rows)
                {
                    totalQuantity += SafeConvertToInt32(row["TotalQuantity"], 0);
                }
                if (totalQuantity == 0) totalQuantity = 1;

                // Pie chart settings
                int centerX = bounds.Width / 2;
                int centerY = bounds.Height / 2;
                int radius = Math.Min(centerX, centerY) - 80;

                // Colors for pie slices
                Color[] sliceColors = { Color.FromArgb(239, 68, 68), Color.FromArgb(245, 158, 11), 
                                        Color.FromArgb(46, 204, 113), Color.FromArgb(102, 126, 234),
                                        Color.FromArgb(168, 85, 247) };

                // Draw pie slices
                float startAngle = -90;
                for (int i = 0; i < _dashboardData.TopSellingProducts.Rows.Count; i++)
                {
                    DataRow row = _dashboardData.TopSellingProducts.Rows[i];
                    int quantity = SafeConvertToInt32(row["TotalQuantity"], 0);
                    float sweepAngle = (float)quantity / totalQuantity * 360;

                    using (Brush sliceBrush = new SolidBrush(sliceColors[i % sliceColors.Length]))
                    {
                        g.FillPie(sliceBrush, centerX - radius, centerY - radius, radius * 2, radius * 2, 
                            startAngle, sweepAngle);
                    }

                    // Draw percentage label
                    float midAngle = startAngle + sweepAngle / 2;
                    float labelRadius = radius * 0.65f;
                    float labelX = centerX + (float)Math.Cos(midAngle * Math.PI / 180) * labelRadius;
                    float labelY = centerY + (float)Math.Sin(midAngle * Math.PI / 180) * labelRadius;
                    string percentage = ((float)quantity / totalQuantity * 100).ToString("0") + "%";
                    SizeF labelSize = g.MeasureString(percentage, new Font("Segoe UI", 10, FontStyle.Bold));
                    g.DrawString(percentage, new Font("Segoe UI", 10, FontStyle.Bold), Brushes.White,
                        labelX - labelSize.Width / 2, labelY - labelSize.Height / 2);

                    startAngle += sweepAngle;
                }

                // Draw legend
                int legendY = bounds.Height - 100;
                for (int i = 0; i < _dashboardData.TopSellingProducts.Rows.Count; i++)
                {
                    DataRow row = _dashboardData.TopSellingProducts.Rows[i];
                    string productName = SafeConvertToString(row["ProductName"], "Unknown Product");
                    int quantity = SafeConvertToInt32(row["TotalQuantity"], 0);

                    // Color square
                    using (Brush colorBrush = new SolidBrush(sliceColors[i % sliceColors.Length]))
                    {
                        g.FillRectangle(colorBrush, 50, legendY + i * 30, 20, 20);
                    }

                    // Product name and quantity
                    string legendText = $"{productName} ({quantity} units)";
                    g.DrawString(legendText, new Font("Segoe UI", 9), Brushes.DarkGray, 
                        80, legendY + i * 30 + 2);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error drawing top products chart: {ex.Message}");
                g.Clear(Color.White);
                g.DrawString("Error loading chart data", new Font("Segoe UI", 10), Brushes.Red, 10, 10);
            }
        }

        private string SafeConvertToString(object value, string defaultValue)
        {
            if (value == null || value == DBNull.Value)
                return defaultValue;
            try
            {
                return value.ToString() ?? defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                // 显示确认对话框
                var result = MessageBox.Show(
                    LanguageManager.GetString("MainForm_LogoutConfirm"),
                    LanguageManager.GetString("MainForm_LogoutConfirmTitle"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    // 使用 AppContext 进行登出
                    if (_appContext != null)
                    {
                        _appContext.Logout();
                    }
                    else
                    {
                        // 如果没有 AppContext 引用，尝试使用旧方式
                        this.Close();
                        LoginForm newLoginForm = new LoginForm();
                        newLoginForm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Logout exception: {ex.Message}\nStack trace: {ex.StackTrace}");
                MessageBox.Show($"Logout error: {ex.Message}\n\nStack trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlRecentOrders_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (_dashboardData?.RecentOrders == null || _dashboardData.RecentOrders.Rows.Count == 0)
                {
                    e.Graphics.DrawString("No recent orders", new Font("Segoe UI", 12), Brushes.Gray, 20, 20);
                    return;
                }

                Graphics g = e.Graphics;
                g.Clear(Color.White);

                // Headers
                Font headerFont = new Font("Segoe UI", 10, FontStyle.Bold);
                Font rowFont = new Font("Segoe UI", 9);
                Brush headerBrush = Brushes.White;
                Brush rowBrush = Brushes.Black;
                Brush alternateRowBrush = Brushes.Gray;

                int y = 10;
                int rowHeight = 40;
                int padding = 15;

                // Draw header background
                using (Brush headerBg = new SolidBrush(Color.FromArgb(70, 130, 180)))
                {
                    g.FillRectangle(headerBg, 0, y, pnlRecentOrders.Width, rowHeight);
                }

                // Draw headers
                g.DrawString("Order ID", headerFont, headerBrush, padding, y + 10);
                g.DrawString("Date", headerFont, headerBrush, 150, y + 10);
                g.DrawString("Status", headerFont, headerBrush, 400, y + 10);
                g.DrawString("Total", headerFont, headerBrush, 600, y + 10);

                y += rowHeight;

                // Draw rows
                for (int i = 0; i < _dashboardData.RecentOrders.Rows.Count; i++)
                {
                    DataRow row = _dashboardData.RecentOrders.Rows[i];
                    
                    // Alternate row background
                    if (i % 2 == 1)
                    {
                        using (Brush altBg = new SolidBrush(Color.FromArgb(245, 245, 245)))
                        {
                            g.FillRectangle(altBg, 0, y, pnlRecentOrders.Width, rowHeight);
                        }
                    }

                    // Get status color
                    Brush statusBrush = Brushes.Gray;
                    string status = SafeConvertToString(row["Status"], "");
                    switch (status.ToLower())
                    {
                        case "pending":
                            statusBrush = Brushes.Orange;
                            break;
                        case "processing":
                            statusBrush = Brushes.Blue;
                            break;
                        case "shipped":
                            statusBrush = Brushes.Purple;
                            break;
                        case "completed":
                            statusBrush = Brushes.Green;
                            break;
                    }

                    // Draw row data
                    g.DrawString("#" + SafeConvertToInt32(row["OrderId"], 0).ToString(), rowFont, rowBrush, padding, y + 10);
                    g.DrawString(SafeConvertToDateTime(row["OrderDate"], DateTime.Now).ToString("MM/dd/yyyy HH:mm"), rowFont, rowBrush, 150, y + 10);
                    g.DrawString(status, rowFont, statusBrush, 400, y + 10);
                    g.DrawString("$" + SafeConvertToDecimal(row["Total"], 0).ToString("N2"), rowFont, rowBrush, 600, y + 10);

                    y += rowHeight;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error drawing recent orders: {ex.Message}");
                e.Graphics.Clear(Color.White);
                e.Graphics.DrawString("Error loading orders", new Font("Segoe UI", 10), Brushes.Red, 20, 20);
            }
        }

        private decimal SafeConvertToDecimal(object value, decimal defaultValue)
        {
            if (value == null || value == DBNull.Value)
                return defaultValue;
            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}
