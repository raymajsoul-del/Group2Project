namespace Group2Project.Views
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            pnlSidebar = new Panel();
            btnMasterData = new Button();
            btnReports = new Button();
            btnLogistics = new Button();
            btnProduction = new Button();
            btnFinance = new Button();
            btnOrderProcessing = new Button();
            btnOrderHistory = new Button();
            btnAfterSales = new Button();
            btnShipping = new Button();
            btnPurchase = new Button();
            btnInventory = new Button();
            btnPOSSales = new Button();
            btnDashboard = new Button();
            pnlTopBar = new Panel();
            lblAppTitle = new Label();
            lblAppIcon = new Label();
            btnLogout = new Button();
            lblUser = new Label();
            pnlMainContent = new Panel();
            pnlDashboard = new Panel();
            pnlRecentOrders = new Panel();
            lblRecentOrders = new Label();
            chartTopProducts = new Panel();
            chartOrderTrend = new Panel();
            lblTopSelling = new Label();
            lblOrderTrend = new Label();
            pnlCard8 = new Panel();
            lblTodayRevenue = new Label();
            lblTodayRevenueTitle = new Label();
            pnlCard7 = new Panel();
            lblTodayOrders = new Label();
            lblTodayOrdersTitle = new Label();
            pnlCard6 = new Panel();
            lblLowStockItems = new Label();
            lblLowStockTitle = new Label();
            pnlCard5 = new Panel();
            lblPendingOrders = new Label();
            lblPendingOrdersTitle = new Label();
            pnlCard4 = new Panel();
            lblGrossProfit = new Label();
            lblGrossProfitTitle = new Label();
            pnlCard3 = new Panel();
            lblTotalRevenue = new Label();
            lblTotalRevenueTitle = new Label();
            pnlCard2 = new Panel();
            lblTotalSoldItems = new Label();
            lblTotalSoldTitle = new Label();
            pnlCard1 = new Panel();
            lblTotalOrders = new Label();
            lblTotalOrdersTitle = new Label();
            lblDashboardTitle = new Label();
            pnlContent = new Panel();
            pnlSidebar.SuspendLayout();
            pnlTopBar.SuspendLayout();
            pnlMainContent.SuspendLayout();
            pnlDashboard.SuspendLayout();
            pnlCard4.SuspendLayout();
            pnlCard3.SuspendLayout();
            pnlCard2.SuspendLayout();
            pnlCard1.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 30000;
            timer1.Tick += timer1_Tick;
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(45, 45, 48);
            pnlSidebar.Controls.Add(btnMasterData);
            pnlSidebar.Controls.Add(btnReports);
            pnlSidebar.Controls.Add(btnLogistics);
            pnlSidebar.Controls.Add(btnProduction);
            pnlSidebar.Controls.Add(btnFinance);
            pnlSidebar.Controls.Add(btnAfterSales);
            pnlSidebar.Controls.Add(btnOrderHistory);
            pnlSidebar.Controls.Add(btnOrderProcessing);
            pnlSidebar.Controls.Add(btnShipping);
            pnlSidebar.Controls.Add(btnPurchase);
            pnlSidebar.Controls.Add(btnInventory);
            pnlSidebar.Controls.Add(btnPOSSales);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 89);
            pnlSidebar.Margin = new Padding(4, 4, 4, 4);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(283, 861);
            pnlSidebar.TabIndex = 0;
            // 
            // btnMasterData
            // 
            btnMasterData.FlatAppearance.BorderSize = 0;
            btnMasterData.FlatStyle = FlatStyle.Flat;
            btnMasterData.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMasterData.ForeColor = Color.White;
            btnMasterData.Location = new Point(0, 581);
            btnMasterData.Margin = new Padding(4, 4, 4, 4);
            btnMasterData.Name = "btnMasterData";
            btnMasterData.Padding = new Padding(26, 0, 0, 0);
            btnMasterData.Size = new Size(283, 63);
            btnMasterData.TabIndex = 13;
            btnMasterData.Text = "Master Data";
            btnMasterData.TextAlign = ContentAlignment.MiddleLeft;
            btnMasterData.UseVisualStyleBackColor = true;
            btnMasterData.Click += btnMasterData_Click;
            // 
            // btnReports
            // 
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReports.ForeColor = Color.White;
            btnReports.Location = new Point(0, 518);
            btnReports.Margin = new Padding(4, 4, 4, 4);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(26, 0, 0, 0);
            btnReports.Size = new Size(283, 63);
            btnReports.TabIndex = 12;
            btnReports.Text = "Reports";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnLogistics
            // 
            btnLogistics.FlatAppearance.BorderSize = 0;
            btnLogistics.FlatStyle = FlatStyle.Flat;
            btnLogistics.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogistics.ForeColor = Color.White;
            btnLogistics.Location = new Point(0, 455);
            btnLogistics.Margin = new Padding(4, 4, 4, 4);
            btnLogistics.Name = "btnLogistics";
            btnLogistics.Padding = new Padding(26, 0, 0, 0);
            btnLogistics.Size = new Size(283, 63);
            btnLogistics.TabIndex = 11;
            btnLogistics.Text = "Logistics";
            btnLogistics.TextAlign = ContentAlignment.MiddleLeft;
            btnLogistics.UseVisualStyleBackColor = true;
            btnLogistics.Click += btnLogistics_Click;
            // 
            // btnProduction
            // 
            btnProduction.FlatAppearance.BorderSize = 0;
            btnProduction.FlatStyle = FlatStyle.Flat;
            btnProduction.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProduction.ForeColor = Color.White;
            btnProduction.Location = new Point(0, 392);
            btnProduction.Margin = new Padding(4, 4, 4, 4);
            btnProduction.Name = "btnProduction";
            btnProduction.Padding = new Padding(26, 0, 0, 0);
            btnProduction.Size = new Size(283, 63);
            btnProduction.TabIndex = 10;
            btnProduction.Text = "Production";
            btnProduction.TextAlign = ContentAlignment.MiddleLeft;
            btnProduction.UseVisualStyleBackColor = true;
            btnProduction.Click += btnProduction_Click;
            // 
            // btnFinance
            // 
            btnFinance.FlatAppearance.BorderSize = 0;
            btnFinance.FlatStyle = FlatStyle.Flat;
            btnFinance.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFinance.ForeColor = Color.White;
            btnFinance.Location = new Point(0, 455);
            btnFinance.Margin = new Padding(4, 4, 4, 4);
            btnFinance.Name = "btnFinance";
            btnFinance.Padding = new Padding(26, 0, 0, 0);
            btnFinance.Size = new Size(283, 63);
            btnFinance.TabIndex = 9;
            btnFinance.Text = "Finance & Accounting";
            btnFinance.TextAlign = ContentAlignment.MiddleLeft;
            btnFinance.UseVisualStyleBackColor = true;
            btnFinance.Click += btnFinance_Click;
            // 
            // btnOrderProcessing
            // 
            btnOrderProcessing.FlatAppearance.BorderSize = 0;
            btnOrderProcessing.FlatStyle = FlatStyle.Flat;
            btnOrderProcessing.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOrderProcessing.ForeColor = Color.White;
            btnOrderProcessing.Location = new Point(0, 266);
            btnOrderProcessing.Margin = new Padding(4, 4, 4, 4);
            btnOrderProcessing.Name = "btnOrderProcessing";
            btnOrderProcessing.Padding = new Padding(26, 0, 0, 0);
            btnOrderProcessing.Size = new Size(283, 63);
            btnOrderProcessing.TabIndex = 5;
            btnOrderProcessing.Text = "Order Processing";
            btnOrderProcessing.TextAlign = ContentAlignment.MiddleLeft;
            btnOrderProcessing.UseVisualStyleBackColor = true;
            btnOrderProcessing.Click += btnOrderProcessing_Click;
            // 
            // btnOrderHistory
            // 
            btnOrderHistory.FlatAppearance.BorderSize = 0;
            btnOrderHistory.FlatStyle = FlatStyle.Flat;
            btnOrderHistory.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOrderHistory.ForeColor = Color.White;
            btnOrderHistory.Location = new Point(0, 329);
            btnOrderHistory.Margin = new Padding(4, 4, 4, 4);
            btnOrderHistory.Name = "btnOrderHistory";
            btnOrderHistory.Padding = new Padding(26, 0, 0, 0);
            btnOrderHistory.Size = new Size(283, 63);
            btnOrderHistory.TabIndex = 6;
            btnOrderHistory.Text = "Order History";
            btnOrderHistory.TextAlign = ContentAlignment.MiddleLeft;
            btnOrderHistory.UseVisualStyleBackColor = true;
            btnOrderHistory.Click += btnOrderHistory_Click;
            // 
            // btnAfterSales
            // 
            btnAfterSales.FlatAppearance.BorderSize = 0;
            btnAfterSales.FlatStyle = FlatStyle.Flat;
            btnAfterSales.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAfterSales.ForeColor = Color.White;
            btnAfterSales.Location = new Point(0, 392);
            btnAfterSales.Margin = new Padding(4, 4, 4, 4);
            btnAfterSales.Name = "btnAfterSales";
            btnAfterSales.Padding = new Padding(26, 0, 0, 0);
            btnAfterSales.Size = new Size(283, 63);
            btnAfterSales.TabIndex = 7;
            btnAfterSales.Text = "After Sales";
            btnAfterSales.TextAlign = ContentAlignment.MiddleLeft;
            btnAfterSales.UseVisualStyleBackColor = true;
            btnAfterSales.Click += btnAfterSales_Click;
            // 
            // btnShipping
            // 
            btnShipping.FlatAppearance.BorderSize = 0;
            btnShipping.FlatStyle = FlatStyle.Flat;
            btnShipping.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnShipping.ForeColor = Color.White;
            btnShipping.Location = new Point(0, 203);
            btnShipping.Margin = new Padding(4, 4, 4, 4);
            btnShipping.Name = "btnShipping";
            btnShipping.Padding = new Padding(26, 0, 0, 0);
            btnShipping.Size = new Size(283, 63);
            btnShipping.TabIndex = 4;
            btnShipping.Text = "Shipping";
            btnShipping.TextAlign = ContentAlignment.MiddleLeft;
            btnShipping.UseVisualStyleBackColor = true;
            btnShipping.Click += btnShipping_Click;
            // 
            // btnPurchase
            // 
            btnPurchase.FlatAppearance.BorderSize = 0;
            btnPurchase.FlatStyle = FlatStyle.Flat;
            btnPurchase.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPurchase.ForeColor = Color.White;
            btnPurchase.Location = new Point(0, 139);
            btnPurchase.Margin = new Padding(4, 4, 4, 4);
            btnPurchase.Name = "btnPurchase";
            btnPurchase.Padding = new Padding(26, 0, 0, 0);
            btnPurchase.Size = new Size(283, 63);
            btnPurchase.TabIndex = 3;
            btnPurchase.Text = "Purchase";
            btnPurchase.TextAlign = ContentAlignment.MiddleLeft;
            btnPurchase.UseVisualStyleBackColor = true;
            btnPurchase.Click += btnPurchase_Click;
            // 
            // btnInventory
            // 
            btnInventory.FlatAppearance.BorderSize = 0;
            btnInventory.FlatStyle = FlatStyle.Flat;
            btnInventory.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInventory.ForeColor = Color.White;
            btnInventory.Location = new Point(0, 76);
            btnInventory.Margin = new Padding(4, 4, 4, 4);
            btnInventory.Name = "btnInventory";
            btnInventory.Padding = new Padding(26, 0, 0, 0);
            btnInventory.Size = new Size(283, 63);
            btnInventory.TabIndex = 2;
            btnInventory.Text = "Inventory";
            btnInventory.TextAlign = ContentAlignment.MiddleLeft;
            btnInventory.UseVisualStyleBackColor = true;
            btnInventory.Click += btnInventory_Click;
            // 
            // btnPOSSales
            // 
            btnPOSSales.FlatAppearance.BorderSize = 0;
            btnPOSSales.FlatStyle = FlatStyle.Flat;
            btnPOSSales.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPOSSales.ForeColor = Color.White;
            btnPOSSales.Location = new Point(0, 13);
            btnPOSSales.Margin = new Padding(4, 4, 4, 4);
            btnPOSSales.Name = "btnPOSSales";
            btnPOSSales.Padding = new Padding(26, 0, 0, 0);
            btnPOSSales.Size = new Size(283, 63);
            btnPOSSales.TabIndex = 1;
            btnPOSSales.Text = "POS Sales";
            btnPOSSales.TextAlign = ContentAlignment.MiddleLeft;
            btnPOSSales.UseVisualStyleBackColor = true;
            btnPOSSales.Click += btnPOSSales_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(0, -51);
            btnDashboard.Margin = new Padding(4, 4, 4, 4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(26, 0, 0, 0);
            btnDashboard.Size = new Size(283, 63);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // pnlTopBar
            // 
            pnlTopBar.BackColor = Color.FromArgb(53, 53, 56);
            pnlTopBar.Controls.Add(lblAppTitle);
            pnlTopBar.Controls.Add(lblAppIcon);
            pnlTopBar.Controls.Add(btnLogout);
            pnlTopBar.Controls.Add(lblUser);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(0, 0);
            pnlTopBar.Margin = new Padding(4, 4, 4, 4);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(1671, 89);
            pnlTopBar.TabIndex = 1;
            // 
            // lblAppIcon
            // 
            lblAppIcon.AutoSize = true;
            lblAppIcon.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            lblAppIcon.ForeColor = Color.White;
            lblAppIcon.Location = new Point(25, 20);
            lblAppIcon.Name = "lblAppIcon";
            lblAppIcon.Size = new Size(45, 45);
            lblAppIcon.TabIndex = 2;
            lblAppIcon.Text = "⚙";
            // 
            // lblAppTitle
            // 
            lblAppTitle.AutoSize = true;
            lblAppTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            lblAppTitle.ForeColor = Color.White;
            lblAppTitle.Location = new Point(80, 25);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(450, 41);
            lblAppTitle.TabIndex = 3;
            lblAppTitle.Text = "Enterprise Resource Management";
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1430, 22);
            btnLogout.Margin = new Padding(4, 4, 4, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(200, 45);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Log Out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUser.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUser.ForeColor = Color.White;
            lblUser.Location = new Point(1100, 32);
            lblUser.Margin = new Padding(4, 0, 4, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(320, 25);
            lblUser.TabIndex = 0;
            lblUser.Text = "User: Guest";
            lblUser.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlMainContent
            // 
            pnlMainContent.BackColor = Color.FromArgb(245, 245, 245);
            pnlMainContent.Controls.Add(pnlDashboard);
            pnlMainContent.Controls.Add(pnlContent);
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(283, 89);
            pnlMainContent.Margin = new Padding(4, 4, 4, 4);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(1388, 861);
            pnlMainContent.TabIndex = 2;
            // 
            // pnlDashboard
            // 
            pnlDashboard.Controls.Add(pnlRecentOrders);
            pnlDashboard.Controls.Add(chartTopProducts);
            pnlDashboard.Controls.Add(chartOrderTrend);
            pnlDashboard.Controls.Add(lblTopSelling);
            pnlDashboard.Controls.Add(lblOrderTrend);
            pnlDashboard.Controls.Add(lblRecentOrders);
            pnlDashboard.Controls.Add(pnlCard8);
            pnlDashboard.Controls.Add(pnlCard7);
            pnlDashboard.Controls.Add(pnlCard6);
            pnlDashboard.Controls.Add(pnlCard5);
            pnlDashboard.Controls.Add(pnlCard4);
            pnlDashboard.Controls.Add(pnlCard3);
            pnlDashboard.Controls.Add(pnlCard2);
            pnlDashboard.Controls.Add(pnlCard1);
            pnlDashboard.Controls.Add(lblDashboardTitle);
            pnlDashboard.Dock = DockStyle.Fill;
            pnlDashboard.Location = new Point(0, 0);
            pnlDashboard.Margin = new Padding(4, 4, 4, 4);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(1388, 861);
            pnlDashboard.TabIndex = 0;
            // 

            // 
            // chartOrderTrend
            // 
            chartOrderTrend.BackColor = Color.White;
            chartOrderTrend.Location = new Point(64, 870);
            chartOrderTrend.Margin = new Padding(4, 4, 4, 4);
            chartOrderTrend.Name = "chartOrderTrend";
            chartOrderTrend.Size = new Size(617, 350);
            chartOrderTrend.TabIndex = 15;
            chartOrderTrend.Paint += chartOrderTrend_Paint;
            // 
            // lblTopSelling
            // 
            lblTopSelling.AutoSize = true;
            lblTopSelling.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTopSelling.Location = new Point(707, 830);
            lblTopSelling.Margin = new Padding(4, 0, 4, 0);
            lblTopSelling.Name = "lblTopSelling";
            lblTopSelling.Size = new Size(205, 28);
            lblTopSelling.TabIndex = 16;
            lblTopSelling.Text = "Top Selling Products";
            // 
            // chartTopProducts
            // 
            chartTopProducts.BackColor = Color.White;
            chartTopProducts.Location = new Point(707, 870);
            chartTopProducts.Margin = new Padding(4, 4, 4, 4);
            chartTopProducts.Name = "chartTopProducts";
            chartTopProducts.Size = new Size(617, 350);
            chartTopProducts.TabIndex = 17;
            chartTopProducts.Paint += chartTopProducts_Paint;
            // 
            // pnlCard4
            // 
            pnlCard4.BackColor = Color.White;
            pnlCard4.Controls.Add(lblGrossProfit);
            pnlCard4.Controls.Add(lblGrossProfitTitle);
            pnlCard4.Location = new Point(1067, 101);
            pnlCard4.Margin = new Padding(4, 4, 4, 4);
            pnlCard4.Name = "pnlCard4";
            pnlCard4.Size = new Size(257, 228);
            pnlCard4.TabIndex = 8;
            // 
            // lblGrossProfit
            // 
            lblGrossProfit.AutoSize = true;
            lblGrossProfit.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGrossProfit.ForeColor = Color.FromArgb(102, 126, 234);
            lblGrossProfit.Location = new Point(26, 101);
            lblGrossProfit.Margin = new Padding(4, 0, 4, 0);
            lblGrossProfit.Name = "lblGrossProfit";
            lblGrossProfit.Size = new Size(69, 54);
            lblGrossProfit.TabIndex = 1;
            lblGrossProfit.Text = "$0";
            // 
            // lblGrossProfitTitle
            // 
            lblGrossProfitTitle.AutoSize = true;
            lblGrossProfitTitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGrossProfitTitle.ForeColor = Color.Gray;
            lblGrossProfitTitle.Location = new Point(26, 51);
            lblGrossProfitTitle.Margin = new Padding(4, 0, 4, 0);
            lblGrossProfitTitle.Name = "lblGrossProfitTitle";
            lblGrossProfitTitle.Size = new Size(155, 25);
            lblGrossProfitTitle.TabIndex = 0;
            lblGrossProfitTitle.Text = "Total Gross Profit";
            // 
            // pnlCard5
            // 
            pnlCard5.BackColor = Color.White;
            pnlCard5.Controls.Add(lblPendingOrders);
            pnlCard5.Controls.Add(lblPendingOrdersTitle);
            pnlCard5.Location = new Point(64, 360);
            pnlCard5.Margin = new Padding(4, 4, 4, 4);
            pnlCard5.Name = "pnlCard5";
            pnlCard5.Size = new Size(257, 140);
            pnlCard5.TabIndex = 9;
            // 
            // lblPendingOrders
            // 
            lblPendingOrders.AutoSize = true;
            lblPendingOrders.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPendingOrders.ForeColor = Color.FromArgb(255, 107, 107);
            lblPendingOrders.Location = new Point(26, 60);
            lblPendingOrders.Margin = new Padding(4, 0, 4, 0);
            lblPendingOrders.Name = "lblPendingOrders";
            lblPendingOrders.Size = new Size(46, 54);
            lblPendingOrders.TabIndex = 1;
            lblPendingOrders.Text = "0";
            // 
            // lblPendingOrdersTitle
            // 
            lblPendingOrdersTitle.AutoSize = true;
            lblPendingOrdersTitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPendingOrdersTitle.ForeColor = Color.Gray;
            lblPendingOrdersTitle.Location = new Point(26, 25);
            lblPendingOrdersTitle.Margin = new Padding(4, 0, 4, 0);
            lblPendingOrdersTitle.Name = "lblPendingOrdersTitle";
            lblPendingOrdersTitle.Size = new Size(132, 25);
            lblPendingOrdersTitle.TabIndex = 0;
            lblPendingOrdersTitle.Text = "Pending Orders";
            // 
            // pnlCard6
            // 
            pnlCard6.BackColor = Color.White;
            pnlCard6.Controls.Add(lblLowStockItems);
            pnlCard6.Controls.Add(lblLowStockTitle);
            pnlCard6.Location = new Point(399, 360);
            pnlCard6.Margin = new Padding(4, 4, 4, 4);
            pnlCard6.Name = "pnlCard6";
            pnlCard6.Size = new Size(257, 140);
            pnlCard6.TabIndex = 10;
            // 
            // lblLowStockItems
            // 
            lblLowStockItems.AutoSize = true;
            lblLowStockItems.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLowStockItems.ForeColor = Color.FromArgb(255, 159, 67);
            lblLowStockItems.Location = new Point(26, 60);
            lblLowStockItems.Margin = new Padding(4, 0, 4, 0);
            lblLowStockItems.Name = "lblLowStockItems";
            lblLowStockItems.Size = new Size(46, 54);
            lblLowStockItems.TabIndex = 1;
            lblLowStockItems.Text = "0";
            // 
            // lblLowStockTitle
            // 
            lblLowStockTitle.AutoSize = true;
            lblLowStockTitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLowStockTitle.ForeColor = Color.Gray;
            lblLowStockTitle.Location = new Point(26, 25);
            lblLowStockTitle.Margin = new Padding(4, 0, 4, 0);
            lblLowStockTitle.Name = "lblLowStockTitle";
            lblLowStockTitle.Size = new Size(129, 25);
            lblLowStockTitle.TabIndex = 0;
            lblLowStockTitle.Text = "Low Stock Items";
            // 
            // pnlCard7
            // 
            pnlCard7.BackColor = Color.White;
            pnlCard7.Controls.Add(lblTodayOrders);
            pnlCard7.Controls.Add(lblTodayOrdersTitle);
            pnlCard7.Location = new Point(733, 360);
            pnlCard7.Margin = new Padding(4, 4, 4, 4);
            pnlCard7.Name = "pnlCard7";
            pnlCard7.Size = new Size(257, 140);
            pnlCard7.TabIndex = 11;
            // 
            // lblTodayOrders
            // 
            lblTodayOrders.AutoSize = true;
            lblTodayOrders.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTodayOrders.ForeColor = Color.FromArgb(78, 205, 196);
            lblTodayOrders.Location = new Point(26, 60);
            lblTodayOrders.Margin = new Padding(4, 0, 4, 0);
            lblTodayOrders.Name = "lblTodayOrders";
            lblTodayOrders.Size = new Size(46, 54);
            lblTodayOrders.TabIndex = 1;
            lblTodayOrders.Text = "0";
            // 
            // lblTodayOrdersTitle
            // 
            lblTodayOrdersTitle.AutoSize = true;
            lblTodayOrdersTitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTodayOrdersTitle.ForeColor = Color.Gray;
            lblTodayOrdersTitle.Location = new Point(26, 25);
            lblTodayOrdersTitle.Margin = new Padding(4, 0, 4, 0);
            lblTodayOrdersTitle.Name = "lblTodayOrdersTitle";
            lblTodayOrdersTitle.Size = new Size(115, 25);
            lblTodayOrdersTitle.TabIndex = 0;
            lblTodayOrdersTitle.Text = "Today Orders";
            // 
            // pnlCard8
            // 
            pnlCard8.BackColor = Color.White;
            pnlCard8.Controls.Add(lblTodayRevenue);
            pnlCard8.Controls.Add(lblTodayRevenueTitle);
            pnlCard8.Location = new Point(1067, 360);
            pnlCard8.Margin = new Padding(4, 4, 4, 4);
            pnlCard8.Name = "pnlCard8";
            pnlCard8.Size = new Size(257, 140);
            pnlCard8.TabIndex = 12;
            // 
            // lblTodayRevenue
            // 
            lblTodayRevenue.AutoSize = true;
            lblTodayRevenue.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTodayRevenue.ForeColor = Color.FromArgb(69, 183, 209);
            lblTodayRevenue.Location = new Point(26, 60);
            lblTodayRevenue.Margin = new Padding(4, 0, 4, 0);
            lblTodayRevenue.Name = "lblTodayRevenue";
            lblTodayRevenue.Size = new Size(69, 54);
            lblTodayRevenue.TabIndex = 1;
            lblTodayRevenue.Text = "$0";
            // 
            // lblTodayRevenueTitle
            // 
            lblTodayRevenueTitle.AutoSize = true;
            lblTodayRevenueTitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTodayRevenueTitle.ForeColor = Color.Gray;
            lblTodayRevenueTitle.Location = new Point(26, 25);
            lblTodayRevenueTitle.Margin = new Padding(4, 0, 4, 0);
            lblTodayRevenueTitle.Name = "lblTodayRevenueTitle";
            lblTodayRevenueTitle.Size = new Size(128, 25);
            lblTodayRevenueTitle.TabIndex = 0;
            lblTodayRevenueTitle.Text = "Today Revenue";
            // 
            // lblRecentOrders
            // 
            lblRecentOrders.AutoSize = true;
            lblRecentOrders.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecentOrders.Location = new Point(64, 520);
            lblRecentOrders.Margin = new Padding(4, 0, 4, 0);
            lblRecentOrders.Name = "lblRecentOrders";
            lblRecentOrders.Size = new Size(138, 28);
            lblRecentOrders.TabIndex = 13;
            lblRecentOrders.Text = "Recent Orders";
            // 
            // pnlRecentOrders
            // 
            pnlRecentOrders.BackColor = Color.White;
            pnlRecentOrders.Location = new Point(64, 560);
            pnlRecentOrders.Margin = new Padding(4, 4, 4, 4);
            pnlRecentOrders.Name = "pnlRecentOrders";
            pnlRecentOrders.Size = new Size(1260, 250);
            pnlRecentOrders.TabIndex = 14;
            pnlRecentOrders.Paint += pnlRecentOrders_Paint;
            // 
            // pnlCard3
            // 
            pnlCard3.BackColor = Color.White;
            pnlCard3.Controls.Add(lblTotalRevenue);
            pnlCard3.Controls.Add(lblTotalRevenueTitle);
            pnlCard3.Location = new Point(733, 101);
            pnlCard3.Margin = new Padding(4, 4, 4, 4);
            pnlCard3.Name = "pnlCard3";
            pnlCard3.Size = new Size(257, 228);
            pnlCard3.TabIndex = 7;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalRevenue.ForeColor = Color.FromArgb(46, 204, 113);
            lblTotalRevenue.Location = new Point(26, 101);
            lblTotalRevenue.Margin = new Padding(4, 0, 4, 0);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(69, 54);
            lblTotalRevenue.TabIndex = 1;
            lblTotalRevenue.Text = "$0";
            // 
            // lblTotalRevenueTitle
            // 
            lblTotalRevenueTitle.AutoSize = true;
            lblTotalRevenueTitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalRevenueTitle.ForeColor = Color.Gray;
            lblTotalRevenueTitle.Location = new Point(26, 51);
            lblTotalRevenueTitle.Margin = new Padding(4, 0, 4, 0);
            lblTotalRevenueTitle.Name = "lblTotalRevenueTitle";
            lblTotalRevenueTitle.Size = new Size(128, 25);
            lblTotalRevenueTitle.TabIndex = 0;
            lblTotalRevenueTitle.Text = "Total Revenue";
            // 
            // pnlCard2
            // 
            pnlCard2.BackColor = Color.White;
            pnlCard2.Controls.Add(lblTotalSoldItems);
            pnlCard2.Controls.Add(lblTotalSoldTitle);
            pnlCard2.Location = new Point(399, 101);
            pnlCard2.Margin = new Padding(4, 4, 4, 4);
            pnlCard2.Name = "pnlCard2";
            pnlCard2.Size = new Size(257, 228);
            pnlCard2.TabIndex = 6;
            // 
            // lblTotalSoldItems
            // 
            lblTotalSoldItems.AutoSize = true;
            lblTotalSoldItems.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalSoldItems.ForeColor = Color.FromArgb(245, 158, 11);
            lblTotalSoldItems.Location = new Point(26, 101);
            lblTotalSoldItems.Margin = new Padding(4, 0, 4, 0);
            lblTotalSoldItems.Name = "lblTotalSoldItems";
            lblTotalSoldItems.Size = new Size(46, 54);
            lblTotalSoldItems.TabIndex = 1;
            lblTotalSoldItems.Text = "0";
            // 
            // lblTotalSoldTitle
            // 
            lblTotalSoldTitle.AutoSize = true;
            lblTotalSoldTitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalSoldTitle.ForeColor = Color.Gray;
            lblTotalSoldTitle.Location = new Point(26, 51);
            lblTotalSoldTitle.Margin = new Padding(4, 0, 4, 0);
            lblTotalSoldTitle.Name = "lblTotalSoldTitle";
            lblTotalSoldTitle.Size = new Size(144, 25);
            lblTotalSoldTitle.TabIndex = 0;
            lblTotalSoldTitle.Text = "Total Sold Items";
            // 
            // pnlCard1
            // 
            pnlCard1.BackColor = Color.White;
            pnlCard1.Controls.Add(lblTotalOrders);
            pnlCard1.Controls.Add(lblTotalOrdersTitle);
            pnlCard1.Location = new Point(64, 101);
            pnlCard1.Margin = new Padding(4, 4, 4, 4);
            pnlCard1.Name = "pnlCard1";
            pnlCard1.Size = new Size(257, 228);
            pnlCard1.TabIndex = 5;
            // 
            // lblTotalOrders
            // 
            lblTotalOrders.AutoSize = true;
            lblTotalOrders.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalOrders.ForeColor = Color.FromArgb(239, 68, 68);
            lblTotalOrders.Location = new Point(26, 101);
            lblTotalOrders.Margin = new Padding(4, 0, 4, 0);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(46, 54);
            lblTotalOrders.TabIndex = 1;
            lblTotalOrders.Text = "0";
            // 
            // lblTotalOrdersTitle
            // 
            lblTotalOrdersTitle.AutoSize = true;
            lblTotalOrdersTitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalOrdersTitle.ForeColor = Color.Gray;
            lblTotalOrdersTitle.Location = new Point(26, 51);
            lblTotalOrdersTitle.Margin = new Padding(4, 0, 4, 0);
            lblTotalOrdersTitle.Name = "lblTotalOrdersTitle";
            lblTotalOrdersTitle.Size = new Size(114, 25);
            lblTotalOrdersTitle.TabIndex = 0;
            lblTotalOrdersTitle.Text = "Total Orders";
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.AutoSize = true;
            lblDashboardTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDashboardTitle.Location = new Point(64, 38);
            lblDashboardTitle.Margin = new Padding(4, 0, 4, 0);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(352, 46);
            lblDashboardTitle.TabIndex = 0;
            lblDashboardTitle.Text = "Executive Dashboard";
            // 
            // pnlContent
            // 
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 0);
            pnlContent.Margin = new Padding(4, 4, 4, 4);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1388, 861);
            pnlContent.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1671, 1300);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlSidebar);
            Controls.Add(pnlTopBar);
            Margin = new Padding(4, 4, 4, 4);
            Name = "MainForm";
            Text = "Enterprise Resource Management Panel";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            pnlSidebar.ResumeLayout(false);
            pnlTopBar.ResumeLayout(false);
            pnlMainContent.ResumeLayout(false);
            pnlDashboard.ResumeLayout(false);
            pnlDashboard.PerformLayout();
            pnlCard4.ResumeLayout(false);
            pnlCard4.PerformLayout();
            pnlCard3.ResumeLayout(false);
            pnlCard3.PerformLayout();
            pnlCard2.ResumeLayout(false);
            pnlCard2.PerformLayout();
            pnlCard1.ResumeLayout(false);
            pnlCard1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnShipping;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnPOSSales;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnMasterData;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnLogistics;
        private System.Windows.Forms.Button btnProduction;
        private System.Windows.Forms.Button btnFinance;
        private System.Windows.Forms.Button btnOrderProcessing;
        private System.Windows.Forms.Button btnOrderHistory;
        private System.Windows.Forms.Button btnAfterSales;
        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label lblTotalOrdersTitle;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblTotalSoldItems;
        private System.Windows.Forms.Label lblTotalSoldTitle;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label lblTotalRevenueTitle;
        private System.Windows.Forms.Panel pnlCard4;
        private System.Windows.Forms.Label lblGrossProfit;
        private System.Windows.Forms.Label lblGrossProfitTitle;
        private System.Windows.Forms.Label lblTopSelling;
        private System.Windows.Forms.Label lblOrderTrend;
        private System.Windows.Forms.Panel chartOrderTrend;
        private System.Windows.Forms.Panel chartTopProducts;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblAppIcon;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Panel pnlCard5;
        private System.Windows.Forms.Label lblPendingOrders;
        private System.Windows.Forms.Label lblPendingOrdersTitle;
        private System.Windows.Forms.Panel pnlCard6;
        private System.Windows.Forms.Label lblLowStockItems;
        private System.Windows.Forms.Label lblLowStockTitle;
        private System.Windows.Forms.Panel pnlCard7;
        private System.Windows.Forms.Label lblTodayOrders;
        private System.Windows.Forms.Label lblTodayOrdersTitle;
        private System.Windows.Forms.Panel pnlCard8;
        private System.Windows.Forms.Label lblTodayRevenue;
        private System.Windows.Forms.Label lblTodayRevenueTitle;
        private System.Windows.Forms.Label lblRecentOrders;
        private System.Windows.Forms.Panel pnlRecentOrders;
    }
}
