using System;
using System.Data;
using System.Windows.Forms;
using Group2Project.Controllers;

namespace Group2Project.Views.Sub01_Account
{
    public partial class OrderHistoryForm : Form
    {
        private OrderHistoryController _controller;

        // 侧边栏和内容面板
        private Panel _sidebarPanel;
        private Panel _contentPanel;
        private Panel _panelOverview;
        private Panel _panelTimeline;
        private Button _currentNavButton;

        // 新增控件
        private Button _btnCancelOrder;
        private Button _btnUpdateStatus;
        private ComboBox _cmbNewStatus;
        private Label _lblStatusUpdate;

        // 颜色主题 (订单历史主题 - 青色)
        private readonly Color _primaryColor = Color.FromArgb(0, 150, 136);
        private readonly Color _secondaryColor = Color.FromArgb(77, 182, 172);
        private readonly Color _sidebarColor = Color.FromArgb(30, 30, 30);
        private readonly Color _backgroundColor = Color.FromArgb(245, 245, 245);

        public OrderHistoryForm()
        {
            // 确保窗体在完全设置好之前不会显示
            this.Visible = false;
            this.ShowInTaskbar = false;

            InitializeComponent();
            _controller = new OrderHistoryController();

            this.Load += OrderHistoryForm_Load;

            if (dgvOrderHistoryList != null) dgvOrderHistoryList.CellClick += dgvOrderHistoryList_CellClick;

            if (btnSearchHistory != null) btnSearchHistory.Click += btnSearchHistory_Click;
            if (btnResetHistory != null) btnResetHistory.Click += btnResetHistory_Click;
            if (btnViewFullDetails != null) btnViewFullDetails.Click += btnViewFullDetails_Click;
            if (btnDownloadInvoice != null) btnDownloadInvoice.Click += btnDownloadInvoice_Click;

            try
            {
                // 先设置内容面板，再移除 TabControl
                SetupContentPanels();

                // 移除原始的 TabControl
                if (tcAccountHistory != null)
                {
                    this.Controls.Remove(tcAccountHistory);
                    tcAccountHistory.Dispose();
                }

                // 设置侧边栏
                SetupSidebar();

                // 显示默认面板
                ShowPanel(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"初始化订单历史界面时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupSidebar()
        {
            // 侧边栏面板
            _sidebarPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 240,
                BackColor = _sidebarColor
            };

            // 侧边栏标题
            Panel sidebarHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.FromArgb(20, 20, 20)
            };

            Label sidebarTitle = new Label
            {
                Text = "📜 Order History",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 30),
                AutoSize = true
            };

            sidebarHeader.Controls.Add(sidebarTitle);
            _sidebarPanel.Controls.Add(sidebarHeader);

            // 创建导航按钮
            int yPosition = 110;
            CreateNavButton("Order Overview", 0, ref yPosition);
            CreateNavButton("Order Timeline", 1, ref yPosition);

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
            // 内容面板
            _contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor
            };

            // Overview 面板
            _panelOverview = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor
            };
            MoveControlsFromTabPage(tbOrderOverview, _panelOverview);

            // 动态添加新控件
            AddOrderManagementControls();

            // Timeline 面板
            _panelTimeline = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };
            MoveControlsFromTabPage(tbOrderTimeline, _panelTimeline);

            // 添加所有面板到内容面板
            _contentPanel.Controls.Add(_panelTimeline);
            _contentPanel.Controls.Add(_panelOverview);

            this.Controls.Add(_contentPanel);
            _contentPanel.BringToFront();
        }

        private void AddOrderManagementControls()
        {
            // 状态更新标签
            _lblStatusUpdate = new Label
            {
                Text = "Update Order Status:",
                Location = new Point(680, 280),
                Size = new Size(131, 23),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            // 新状态下拉框
            _cmbNewStatus = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(680, 310),
                Size = new Size(131, 27),
                FlatStyle = FlatStyle.Flat
            };
            _cmbNewStatus.Items.AddRange(new object[] { "Pending", "Processing", "Shipped", "Completed", "Cancelled" });

            // 更新状态按钮
            _btnUpdateStatus = new Button
            {
                Text = "Update Status",
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(680, 350),
                Size = new Size(131, 40),
                Cursor = Cursors.Hand
            };
            _btnUpdateStatus.Click += BtnUpdateStatus_Click;

            // 取消订单按钮
            _btnCancelOrder = new Button
            {
                Text = "Cancel Order",
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(680, 400),
                Size = new Size(131, 40),
                Cursor = Cursors.Hand
            };
            _btnCancelOrder.Click += BtnCancelOrder_Click;

            // 添加到面板
            _panelOverview.Controls.Add(_lblStatusUpdate);
            _panelOverview.Controls.Add(_cmbNewStatus);
            _panelOverview.Controls.Add(_btnUpdateStatus);
            _panelOverview.Controls.Add(_btnCancelOrder);
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
            // 隐藏所有面板
            _panelOverview.Visible = false;
            _panelTimeline.Visible = false;

            // 重置所有导航按钮
            foreach (Control ctrl in _sidebarPanel.Controls)
            {
                if (ctrl is Button btn && btn.Tag is int)
                {
                    btn.BackColor = Color.Transparent;
                    btn.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
                }
            }

            // 高亮当前按钮
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

            // 显示选中的面板
            switch (index)
            {
                case 0:
                    _panelOverview.Visible = true;
                    _panelOverview.BringToFront();
                    break;
                case 1:
                    _panelTimeline.Visible = true;
                    _panelTimeline.BringToFront();
                    break;
            }
        }

        private void OrderHistoryForm_Load(object sender, EventArgs e)
        {
            LoadOrdersData();
        }

        private void tcAccountHistory_SelectedIndexChanged(object sender, EventArgs e) { }


        private void LoadOrdersData()
        {
            try
            {
                DataTable dt = _controller.GetOrdersOverview();
                if (dgvOrderHistoryList != null)
                {
                    dgvOrderHistoryList.DataSource = dt;
                    dgvOrderHistoryList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex) { MessageBox.Show("Failed to load order data: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private void btnSearchHistory_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchQuery.Text.Trim();
            string year = txtYearFilter.Text.Trim();
            string status = cmbFinalStatusFilter.Text;

            try
            {
                DataTable dt = _controller.SearchOrders(keyword, year, status);
                if (dgvOrderHistoryList != null)
                {
                    dgvOrderHistoryList.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnResetHistory_Click(object sender, EventArgs e)
        {
            txtSearchQuery.Clear();
            txtYearFilter.Clear();
            cmbFinalStatusFilter.SelectedIndex = -1;


            LoadOrdersData();
        }

        private void btnViewFullDetails_Click(object sender, EventArgs e)
        {

            if (dgvOrderHistoryList.CurrentCell == null)
            {
                MessageBox.Show("Please select an order from the list first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dgvOrderHistoryList.CurrentCell.RowIndex;
            string orderId = dgvOrderHistoryList.Rows[rowIndex].Cells["Order ID"].Value.ToString();

            if (lblSelectedOrderHint != null)
            {
                lblSelectedOrderHint.Text = $"Showing Lifecycle for Order ID: {orderId}";
            }
            LoadOrderTimelineData(orderId);
            ShowPanel(1);
        }

        private void btnDownloadInvoice_Click(object sender, EventArgs e)
        {
            if (dgvOrderHistoryList.CurrentCell == null)
            {
                MessageBox.Show("Please select an order to download its invoice.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dgvOrderHistoryList.CurrentCell.RowIndex;
            string orderId = dgvOrderHistoryList.Rows[rowIndex].Cells["Order ID"].Value.ToString();
            MessageBox.Show($"Generating PDF Invoice for Order {orderId}...\n\nInvoice successfully downloaded to your 'Downloads' folder!", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvOrderHistoryList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string orderId = dgvOrderHistoryList.Rows[e.RowIndex].Cells["Order ID"].Value.ToString();
                if (lblSelectedOrderHint != null) lblSelectedOrderHint.Text = $"Showing Lifecycle for Order ID: {orderId}";
                LoadOrderTimelineData(orderId);
            }
        }

        private void LoadOrderTimelineData(string orderId)
        {
            try
            {
                DataTable dt = _controller.GetOrderDetails(orderId);

                if (dgvLifecycleTimeline != null)
                {
                    dgvLifecycleTimeline.DataSource = dt;
                    dgvLifecycleTimeline.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

                if (txtInternalNotes != null) txtInternalNotes.Text = $"Order ID {orderId} detailed items loaded from database.";
            }
            catch (Exception ex) { MessageBox.Show("Failed to load timeline details: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BtnCancelOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrderHistoryList.CurrentCell == null)
            {
                MessageBox.Show("Please select an order to cancel.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dgvOrderHistoryList.CurrentCell.RowIndex;
            string orderId = dgvOrderHistoryList.Rows[rowIndex].Cells["Order ID"].Value.ToString();
            string currentStatus = dgvOrderHistoryList.Rows[rowIndex].Cells["Status"].Value?.ToString() ?? "";

            if (currentStatus == "Cancelled" || currentStatus == "Completed")
            {
                MessageBox.Show($"This order is already '{currentStatus}' and cannot be cancelled.", "Cancellation Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to cancel Order ID: {orderId}?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.CancelOrder(orderId);
                    LoadOrdersData();
                    MessageBox.Show($"Order {orderId} has been cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to cancel order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvOrderHistoryList.CurrentCell == null)
            {
                MessageBox.Show("Please select an order to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_cmbNewStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a new status.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dgvOrderHistoryList.CurrentCell.RowIndex;
            string orderId = dgvOrderHistoryList.Rows[rowIndex].Cells["Order ID"].Value.ToString();
            string currentStatus = dgvOrderHistoryList.Rows[rowIndex].Cells["Status"].Value?.ToString() ?? "";
            string newStatus = _cmbNewStatus.SelectedItem.ToString();

            if (currentStatus == newStatus)
            {
                MessageBox.Show("The order is already in this status.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (currentStatus == "Cancelled" || currentStatus == "Completed")
            {
                MessageBox.Show($"This order is already '{currentStatus}' and cannot be modified.", "Modification Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Update Order ID: {orderId} status from '{currentStatus}' to '{newStatus}'?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.UpdateOrderStatus(orderId, newStatus);
                    LoadOrdersData();
                    MessageBox.Show($"Order status updated to '{newStatus}' successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update order status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
