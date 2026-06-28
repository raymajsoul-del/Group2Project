using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Group2Project.Controllers;

namespace Group2Project.Views.Sub07_AfterSales
{
    public partial class AfterSalesForm : Form
    {
        private AfterSalesController _controller;
        private string _verifiedOrderId = "";

        private System.Windows.Forms.Timer _statusTimer;

        // 侧边栏和内容面板
        private Panel _sidebarPanel;
        private Panel _contentPanel;
        private Panel _panelLogCase;
        private Panel _panelManageCases;
        private Panel _panelDashboard;
        private Panel _panelReturns;
        private Button _currentNavButton;

        // 新增控件
        private DataGridView _statsGridView;
        private ComboBox _cmbPriorityFilter;
        private ComboBox _cmbCasePriority;
        private Button _btnCloseCase;
        private TextBox _txtSearchOrder;
        private Label _lblTotalCases;
        private Label _lblPendingCases;
        private Label _lblInProgressCases;
        private Label _lblResolvedCases;

        // 颜色主题 (售后主题 - 珊瑚红)
        private readonly Color _primaryColor = Color.FromArgb(239, 83, 80);
        private readonly Color _secondaryColor = Color.FromArgb(239, 108, 105);
        private readonly Color _sidebarColor = Color.FromArgb(30, 30, 30);
        private readonly Color _backgroundColor = Color.FromArgb(245, 245, 245);

        public AfterSalesForm()
        {
            this.Visible = false;
            this.ShowInTaskbar = false;

            InitializeComponent();
            _controller = new AfterSalesController();

            this.Load += AfterSalesForm_Load;

            if (btnRefreshCases != null) btnRefreshCases.Click += btnRefreshCases_Click;
            if (btnVerifyOrder != null) btnVerifyOrder.Click += btnVerifyOrder_Click;
            if (btnLogCase != null) btnLogCase.Click += btnLogCase_Click;
            if (btnAssignTech != null) btnAssignTech.Click += btnAssignTech_Click;
            if (btnMarkResolved != null) btnMarkResolved.Click += btnMarkResolved_Click;
            if (btnSearchCase != null) btnSearchCase.Click += btnSearchCase_Click;

            try
            {
                SetupContentPanels();

                if (tcAfterSalesManager != null)
                {
                    this.Controls.Remove(tcAfterSalesManager);
                    tcAfterSalesManager.Dispose();
                }

                SetupSidebar();
                ShowPanel(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"初始化售后界面时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _statusTimer = new System.Windows.Forms.Timer();
            _statusTimer.Interval = 3000;
            _statusTimer.Tick += (s, e) =>
            {
                if (lblStatus != null) lblStatus.Text = "";
                _statusTimer.Stop();
            };
        }

        private void SetupSidebar()
        {
            _sidebarPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 240,
                BackColor = _sidebarColor
            };

            Panel sidebarHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.FromArgb(20, 20, 20)
            };

            Label sidebarTitle = new Label
            {
                Text = "🔧 After Sales",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 30),
                AutoSize = true
            };

            sidebarHeader.Controls.Add(sidebarTitle);
            _sidebarPanel.Controls.Add(sidebarHeader);

            int yPosition = 110;
            CreateNavButton("📊 Dashboard", 0, ref yPosition);
            CreateNavButton("📝 Log Service Case", 1, ref yPosition);
            CreateNavButton("🔍 Manage & Track Cases", 2, ref yPosition);
            CreateNavButton("📦 Returns & Refunds", 3, ref yPosition);

            this.Controls.Add(_sidebarPanel);
        }

        private void CreateNavButton(string text, int index, ref int yPosition)
        {
            Button btn = new Button
            {
                Text = text,
                Tag = index,
                Location = new Point(15, yPosition),
                Size = new Size(210, 50),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0),
                Cursor = Cursors.Hand
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 60, 60);
            btn.Click += NavButton_Click;

            _sidebarPanel.Controls.Add(btn);
            yPosition += 55;
        }

        private void NavButton_Click(object sender, EventArgs e)
        {
            Button clickedBtn = sender as Button;
            if (clickedBtn == null) return;

            int index = (int)clickedBtn.Tag;
            ShowPanel(index);
        }

        private void SetupContentPanels()
        {
            _contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor
            };

            // Dashboard 面板
            _panelDashboard = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor
            };
            SetupDashboardPanel();

            // Log Case 面板
            _panelLogCase = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };
            MoveControlsFromTabPage(tbLogNewServiceCase, _panelLogCase);
            EnhanceLogCasePanel();

            // Manage Cases 面板
            _panelManageCases = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };
            MoveControlsFromTabPage(tbMangeTrackCases, _panelManageCases);
            EnhanceManageCasesPanel();

            // Returns 面板
            _panelReturns = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };
            SetupReturnsPanel();

            _contentPanel.Controls.Add(_panelReturns);
            _contentPanel.Controls.Add(_panelManageCases);
            _contentPanel.Controls.Add(_panelLogCase);
            _contentPanel.Controls.Add(_panelDashboard);

            this.Controls.Add(_contentPanel);
            _contentPanel.BringToFront();
        }

        private void SetupDashboardPanel()
        {
            Label titleLabel = new Label
            {
                Text = "After-Sales Dashboard",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                Location = new Point(30, 20),
                AutoSize = true,
                ForeColor = Color.FromArgb(50, 50, 50)
            };

            // 统计卡片
            _lblTotalCases = CreateStatCard("Total Cases", "0", Color.FromArgb(102, 126, 234), 30, 80);
            _lblPendingCases = CreateStatCard("Pending", "0", Color.FromArgb(255, 107, 107), 300, 80);
            _lblInProgressCases = CreateStatCard("In Progress", "0", Color.FromArgb(255, 159, 67), 570, 80);
            _lblResolvedCases = CreateStatCard("Resolved", "0", Color.FromArgb(78, 205, 196), 840, 80);

            _statsGridView = new DataGridView
            {
                Location = new Point(30, 250),
                Size = new Size(800, 350),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            Button refreshStatsBtn = new Button
            {
                Text = "Refresh Statistics",
                Location = new Point(30, 620),
                Size = new Size(180, 40),
                BackColor = _primaryColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            refreshStatsBtn.Click += RefreshStatsBtn_Click;

            _panelDashboard.Controls.Add(titleLabel);
            _panelDashboard.Controls.Add(_lblTotalCases);
            _panelDashboard.Controls.Add(_lblPendingCases);
            _panelDashboard.Controls.Add(_lblInProgressCases);
            _panelDashboard.Controls.Add(_lblResolvedCases);
            _panelDashboard.Controls.Add(_statsGridView);
            _panelDashboard.Controls.Add(refreshStatsBtn);
        }

        private Label CreateStatCard(string title, string value, Color color, int x, int y)
        {
            Panel cardPanel = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(240, 140),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                Location = new Point(20, 20),
                AutoSize = true
            };

            Label valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(20, 55),
                AutoSize = true
            };

            cardPanel.Controls.Add(titleLabel);
            cardPanel.Controls.Add(valueLabel);
            _panelDashboard.Controls.Add(cardPanel);

            return valueLabel;
        }

        private void EnhanceLogCasePanel()
        {
            if (groupBox2 != null)
            {
                Label priorityLabel = new Label
                {
                    Text = "Priority:",
                    Location = new Point(17, 330),
                    AutoSize = true
                };

                _cmbCasePriority = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Location = new Point(122, 327),
                    Size = new Size(182, 31),
                    FlatStyle = FlatStyle.Flat
                };
                _cmbCasePriority.Items.AddRange(new object[] { "Low", "Normal", "High", "Urgent" });
                _cmbCasePriority.SelectedIndex = 1;

                if (btnLogCase != null)
                {
                    btnLogCase.Location = new Point(97, 390);
                }

                groupBox2.Controls.Add(priorityLabel);
                groupBox2.Controls.Add(_cmbCasePriority);
            }
        }

        private void EnhanceManageCasesPanel()
        {
            if (label5 != null)
            {
                Label priorityFilterLabel = new Label
                {
                    Text = "Priority:",
                    Location = new Point(521, 24),
                    AutoSize = true
                };

                _cmbPriorityFilter = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Location = new Point(600, 21),
                    Size = new Size(120, 31),
                    FlatStyle = FlatStyle.Flat
                };
                _cmbPriorityFilter.Items.AddRange(new object[] { "All", "Low", "Normal", "High", "Urgent" });
                _cmbPriorityFilter.SelectedIndex = 0;

                _btnCloseCase = new Button
                {
                    Text = "Close Case",
                    BackColor = Color.FromArgb(100, 100, 100),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(604, 450),
                    Size = new Size(216, 40),
                    Cursor = Cursors.Hand
                };
                _btnCloseCase.Click += BtnCloseCase_Click;

                _panelManageCases.Controls.Add(priorityFilterLabel);
                _panelManageCases.Controls.Add(_cmbPriorityFilter);
                _panelManageCases.Controls.Add(_btnCloseCase);
            }
        }

        private void SetupReturnsPanel()
        {
            Label titleLabel = new Label
            {
                Text = "Returns & Refunds Management",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                Location = new Point(30, 20),
                AutoSize = true,
                ForeColor = Color.FromArgb(50, 50, 50)
            };

            Label searchLabel = new Label
            {
                Text = "Search Order ID:",
                Location = new Point(30, 80),
                AutoSize = true
            };

            _txtSearchOrder = new TextBox
            {
                Location = new Point(150, 77),
                Size = new Size(200, 30)
            };

            Button searchBtn = new Button
            {
                Text = "Search",
                Location = new Point(360, 75),
                Size = new Size(100, 35),
                BackColor = _primaryColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            searchBtn.Click += (s, e) => MessageBox.Show("Return search functionality would query the database here.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            GroupBox returnFormGroup = new GroupBox
            {
                Text = "Process Return",
                Location = new Point(30, 130),
                Size = new Size(500, 300)
            };

            Label returnReasonLabel = new Label
            {
                Text = "Return Reason:",
                Location = new Point(20, 40),
                AutoSize = true
            };

            ComboBox cmbReturnReason = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(150, 37),
                Size = new Size(300, 31),
                FlatStyle = FlatStyle.Flat
            };
            cmbReturnReason.Items.AddRange(new object[] { "Defective Product", "Wrong Item", "Size Issue", "Changed Mind", "Other" });

            Label refundAmountLabel = new Label
            {
                Text = "Refund Amount:",
                Location = new Point(20, 90),
                AutoSize = true
            };

            TextBox txtRefundAmount = new TextBox
            {
                Location = new Point(150, 87),
                Size = new Size(200, 30)
            };

            Label notesLabel = new Label
            {
                Text = "Notes:",
                Location = new Point(20, 140),
                AutoSize = true
            };

            TextBox txtReturnNotes = new TextBox
            {
                Location = new Point(150, 137),
                Size = new Size(320, 80),
                Multiline = true
            };

            Button processReturnBtn = new Button
            {
                Text = "Process Return",
                Location = new Point(150, 230),
                Size = new Size(200, 45),
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            processReturnBtn.Click += (s, e) =>
            {
                MessageBox.Show("Return processed successfully! (This would update the database in a real implementation.)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowSuccessStatus("Return processed!");
            };

            returnFormGroup.Controls.Add(returnReasonLabel);
            returnFormGroup.Controls.Add(cmbReturnReason);
            returnFormGroup.Controls.Add(refundAmountLabel);
            returnFormGroup.Controls.Add(txtRefundAmount);
            returnFormGroup.Controls.Add(notesLabel);
            returnFormGroup.Controls.Add(txtReturnNotes);
            returnFormGroup.Controls.Add(processReturnBtn);

            _panelReturns.Controls.Add(titleLabel);
            _panelReturns.Controls.Add(searchLabel);
            _panelReturns.Controls.Add(_txtSearchOrder);
            _panelReturns.Controls.Add(searchBtn);
            _panelReturns.Controls.Add(returnFormGroup);
        }

        private void RefreshStatsBtn_Click(object sender, EventArgs e)
        {
            LoadStatistics();
            ShowSuccessStatus("Statistics refreshed!");
        }

        private void LoadStatistics()
        {
            try
            {
                DataTable stats = _controller.GetCaseStatistics();
                _statsGridView.DataSource = stats;

                foreach (DataRow row in stats.Rows)
                {
                    string metric = row["Metric"].ToString();
                    string value = row["Value"].ToString();

                    switch (metric)
                    {
                        case "Total Cases":
                            _lblTotalCases.Text = value;
                            break;
                        case "Pending":
                            _lblPendingCases.Text = value;
                            break;
                        case "In Progress":
                            _lblInProgressCases.Text = value;
                            break;
                        case "Resolved":
                            _lblResolvedCases.Text = value;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load statistics: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCloseCase_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0 || dataGridView1.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Please select a case to close.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string caseId = dataGridView1.SelectedRows[0].Cells["Case ID"].Value.ToString();
            string status = dataGridView1.SelectedRows[0].Cells["Current Status"].Value.ToString();

            if (status != "Resolved")
            {
                MessageBox.Show("Only resolved cases can be closed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to close Case {caseId}?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.CloseCase(caseId);
                    LoadServiceCases();
                    ShowSuccessStatus($"Case {caseId} has been closed.");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void MoveControlsFromTabPage(TabPage tabPage, Panel targetPanel)
        {
            Control[] controls = new Control[tabPage.Controls.Count];
            tabPage.Controls.CopyTo(controls, 0);

            foreach (Control ctrl in controls)
            {
                tabPage.Controls.Remove(ctrl);
                targetPanel.Controls.Add(ctrl);
            }
        }

        private void ShowPanel(int index)
        {
            _panelLogCase.Visible = false;
            _panelManageCases.Visible = false;
            _panelDashboard.Visible = false;
            _panelReturns.Visible = false;

            foreach (Control ctrl in _sidebarPanel.Controls)
            {
                if (ctrl is Button btn && btn.Tag is int)
                {
                    btn.BackColor = Color.Transparent;
                    btn.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
                }
            }

            foreach (Control ctrl in _sidebarPanel.Controls)
            {
                if (ctrl is Button btn && btn.Tag is int tag && tag == index)
                {
                    _currentNavButton = btn;
                    btn.BackColor = _primaryColor;
                    btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    break;
                }
            }

            switch (index)
            {
                case 0:
                    _panelDashboard.Visible = true;
                    _panelDashboard.BringToFront();
                    LoadStatistics();
                    break;
                case 1:
                    _panelLogCase.Visible = true;
                    _panelLogCase.BringToFront();
                    break;
                case 2:
                    _panelManageCases.Visible = true;
                    _panelManageCases.BringToFront();
                    break;
                case 3:
                    _panelReturns.Visible = true;
                    _panelReturns.BringToFront();
                    break;
            }
        }

        private void ShowSuccessStatus(string message)
        {
            if (lblStatus != null)
            {
                lblStatus.Text = "✅ " + message;
                lblStatus.ForeColor = Color.Green;
                _statusTimer.Stop();
                _statusTimer.Start();
            }
        }

        private void AfterSalesForm_Load(object sender, EventArgs e)
        {
            LoadServiceCases();
            LoadStatistics();
        }

        private void btnVerifyOrder_Click(object sender, EventArgs e)
        {
            string orderId = txtVerifyOrderID.Text.Trim();
            if (string.IsNullOrWhiteSpace(orderId))
            {
                MessageBox.Show("Please enter an Order ID to verify.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool isValid = _controller.VerifyOrder(orderId);
                if (isValid)
                {
                    _verifiedOrderId = orderId;
                    ShowSuccessStatus($"Order {orderId} verified! Warranty valid.");
                }
                else
                {
                    _verifiedOrderId = "";
                    MessageBox.Show($"Order {orderId} not found in the database. Please check the ID.", "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnLogCase_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_verifiedOrderId))
            {
                MessageBox.Show("Please verify an Order ID first before logging a case.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string caseType = cmbCaseType.Text;
            string description = txtCaseDescription.Text.Trim();
            string priority = _cmbCasePriority?.SelectedItem?.ToString() ?? "Normal";

            if (string.IsNullOrWhiteSpace(caseType) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please select a Case Type and provide a Description.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _controller.LogServiceCase(_verifiedOrderId, caseType, description, priority);

                txtVerifyOrderID.Clear();
                txtVerifyCustID.Clear();
                cmbCaseType.SelectedIndex = -1;
                txtCaseDescription.Clear();
                if (_cmbCasePriority != null) _cmbCasePriority.SelectedIndex = 1;
                _verifiedOrderId = "";

                LoadServiceCases();
                LoadStatistics();

                ShowSuccessStatus("Service case logged successfully!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnRefreshCases_Click(object sender, EventArgs e)
        {
            LoadServiceCases();
            ShowSuccessStatus("Case list refreshed.");
        }

        private void LoadServiceCases()
        {
            try
            {
                if (dataGridView1 != null)
                {
                    dataGridView1.DataSource = _controller.GetServiceCases();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnAssignTech_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0 || dataGridView1.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Please select a case to assign a technician.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tech = cmbTechnician.Text;
            if (string.IsNullOrWhiteSpace(tech))
            {
                MessageBox.Show("Please select a Technician from the dropdown.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string caseId = dataGridView1.SelectedRows[0].Cells["Case ID"].Value.ToString();
            string status = dataGridView1.SelectedRows[0].Cells["Current Status"].Value.ToString();

            if (status == "Resolved" || status == "Closed")
            {
                MessageBox.Show("Cannot assign a technician to a resolved/closed case.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                _controller.AssignTechnician(caseId, tech);
                LoadServiceCases();
                ShowSuccessStatus($"Technician {tech} assigned to Case {caseId}.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnMarkResolved_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0 || dataGridView1.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Please select a case to mark as resolved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string caseId = dataGridView1.SelectedRows[0].Cells["Case ID"].Value.ToString();
            string status = dataGridView1.SelectedRows[0].Cells["Current Status"].Value.ToString();

            if (status == "Resolved" || status == "Closed")
            {
                MessageBox.Show("This case is already resolved or closed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to mark Case {caseId} as RESOLVED?", "Confirm Resolve", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.ResolveCase(caseId);
                    LoadServiceCases();
                    LoadStatistics();
                    ShowSuccessStatus($"Case {caseId} has been marked as Resolved.");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnSearchCase_Click(object sender, EventArgs e)
        {
            string status = cmbCaseStatusFilter.Text;
            string priority = _cmbPriorityFilter?.SelectedItem?.ToString() ?? "All";

            try
            {
                if (dataGridView1 != null)
                {
                    dataGridView1.DataSource = _controller.SearchServiceCases(status, priority);
                    ShowSuccessStatus("Search filter applied.");
                }
            }
            catch (Exception ex) { MessageBox.Show("Search failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void AfterSalesForm_Load_1(object sender, EventArgs e) { }
    }
}
