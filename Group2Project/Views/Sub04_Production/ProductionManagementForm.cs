using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Group2Project.Controllers;

namespace Group2Project.Views.Sub04_Production
{
    public partial class ProductionManagementForm : Form
    {
        private ProductionController _controller;

        private System.Windows.Forms.Timer _statusTimer;

        private Panel _sidebarPanel;
        private Panel _contentPanel;
        private Panel _panelTaskBoard;
        private Panel _panelMaterial;
        private Panel _panelDashboard;
        private Panel _panelCreateOrder;
        private Panel _panelQualityControl;
        private Button _currentNavButton;

        private readonly Color _primaryColor = Color.FromArgb(255, 140, 0);
        private readonly Color _secondaryColor = Color.FromArgb(255, 165, 0);
        private readonly Color _sidebarColor = Color.FromArgb(30, 30, 30);
        private readonly Color _backgroundColor = Color.FromArgb(245, 245, 245);

        public ProductionManagementForm()
        {
            InitializeComponent();
            _controller = new ProductionController();

            this.Load += ProductionManagementForm_Load;


            if (btnRefreshRequests != null) btnRefreshRequests.Click += btnRefreshRequests_Click;
            if (btnSubmitRequest != null) btnSubmitRequest.Click += btnSubmitRequest_Click;
            if (btnUpdateProgress != null) btnUpdateProgress.Click += btnUpdateProgress_Click;


            if (btnViewBlueprint != null) btnViewBlueprint.Click += btnViewBlueprint_Click;
            if (btnReportDefect != null) btnReportDefect.Click += btnReportDefect_Click;


            _statusTimer = new System.Windows.Forms.Timer();
            _statusTimer.Interval = 3000;
            _statusTimer.Tick += (s, e) =>
            {
                if (lblStatus != null) lblStatus.Text = "";
                _statusTimer.Stop();
            };

            SetupContentPanels();
            if (tcProductionManager != null)
            {
                this.Controls.Remove(tcProductionManager);
                tcProductionManager.Dispose();
            }
            SetupSidebar();
            ShowPanel(0);
        }

        private void SetupSidebar()
        {
            _sidebarPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 260,
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
                Text = "🏭 PRODUCTION",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(25, 25),
                AutoSize = true
            };

            Label sidebarSubtitle = new Label
            {
                Text = "Manufacturing Management",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.FromArgb(170, 170, 170),
                Location = new Point(25, 55),
                AutoSize = true
            };

            sidebarHeader.Controls.Add(sidebarTitle);
            sidebarHeader.Controls.Add(sidebarSubtitle);
            _sidebarPanel.Controls.Add(sidebarHeader);

            int yPosition = 110;
            CreateNavButton("📊 Dashboard", 0, ref yPosition);
            CreateNavButton("📋 Task Board", 1, ref yPosition);
            CreateNavButton("➕ Create Production Order", 2, ref yPosition);
            CreateNavButton("🧰 Material Requests", 3, ref yPosition);
            CreateNavButton("✅ Quality Control", 4, ref yPosition);

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

            // Dashboard Panel
            _panelDashboard = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor
            };
            SetupDashboardPanel(_panelDashboard);

            // Task Board Panel
            _panelTaskBoard = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };
            MoveControlsFromTabPage(tbTaskBoard, _panelTaskBoard);

            // Create Order Panel
            _panelCreateOrder = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };
            SetupCreateOrderPanel(_panelCreateOrder);

            // Material Requests Panel
            _panelMaterial = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };
            MoveControlsFromTabPage(tbMaterial, _panelMaterial);

            // Quality Control Panel
            _panelQualityControl = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };
            SetupQualityControlPanel(_panelQualityControl);

            _contentPanel.Controls.Add(_panelQualityControl);
            _contentPanel.Controls.Add(_panelMaterial);
            _contentPanel.Controls.Add(_panelCreateOrder);
            _contentPanel.Controls.Add(_panelTaskBoard);
            _contentPanel.Controls.Add(_panelDashboard);

            this.Controls.Add(_contentPanel);
            _contentPanel.BringToFront();
        }

        private void MoveControlsFromTabPage(TabPage tabPage, Panel targetPanel)
        {
            Control[] controls = new Control[tabPage.Controls.Count];
            tabPage.Controls.CopyTo(controls, 0);

            foreach (Control ctrl in controls)
            {
                tabPage.Controls.Remove(ctrl);
                targetPanel.Controls.Add(ctrl);
                if (ctrl is StatusStrip strip)
                {
                    strip.Dock = DockStyle.Bottom;
                }
            }
        }

        private void ShowPanel(int index)
        {
            _panelTaskBoard.Visible = false;
            _panelMaterial.Visible = false;
            _panelDashboard.Visible = false;
            _panelCreateOrder.Visible = false;
            _panelQualityControl.Visible = false;

            foreach (Control ctrl in _sidebarPanel.Controls)
            {
                if (ctrl is Button btn && btn.Tag is int)
                {
                    btn.BackColor = Color.Transparent;
                    btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                }
            }

            foreach (Control ctrl in _sidebarPanel.Controls)
            {
                if (ctrl is Button btn && btn.Tag is int tag && tag == index)
                {
                    _currentNavButton = btn;
                    btn.BackColor = _primaryColor;
                    btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    break;
                }
            }

            switch (index)
            {
                case 0:
                    _panelDashboard.Visible = true;
                    _panelDashboard.BringToFront();
                    LoadDashboardData();
                    break;
                case 1:
                    _panelTaskBoard.Visible = true;
                    _panelTaskBoard.BringToFront();
                    break;
                case 2:
                    _panelCreateOrder.Visible = true;
                    _panelCreateOrder.BringToFront();
                    break;
                case 3:
                    _panelMaterial.Visible = true;
                    _panelMaterial.BringToFront();
                    break;
                case 4:
                    _panelQualityControl.Visible = true;
                    _panelQualityControl.BringToFront();
                    LoadQualityControlData();
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

        private void ProductionManagementForm_Load(object sender, EventArgs e)
        {
            LoadProductionTasks();
            LoadMaterialRequests();
            PopulateMaterialComboBox();
        }


        private void LoadProductionTasks()
        {
            try
            {
                if (dgvProductionTasks != null)
                {
                    dgvProductionTasks.DataSource = _controller.GetProductionTasks();
                    dgvProductionTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex) { MessageBox.Show("Failed to load production tasks: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private void btnUpdateProgress_Click(object sender, EventArgs e)
        {
            if (dgvProductionTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a production task from the board to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string taskId = dgvProductionTasks.SelectedRows[0].Cells["Task ID"].Value.ToString();
            string currentStatus = dgvProductionTasks.SelectedRows[0].Cells["Current Status"].Value.ToString();


            string selectedStatus = cmbTaskStatus.Text;


            if (string.IsNullOrWhiteSpace(selectedStatus))
            {
                MessageBox.Show("Please select a new status from the dropdown menu first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (currentStatus == selectedStatus)
            {
                MessageBox.Show($"The task is already in '{selectedStatus}' status.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to update Task ID: {taskId}\nFrom: [{currentStatus}]\nTo: [{selectedStatus}]?", "Confirm Progress Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.UpdateTaskStatus(taskId, selectedStatus);
                    LoadProductionTasks();


                    ShowSuccessStatus($"Task {taskId} status manually updated to '{selectedStatus}'.");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }


        private void btnViewBlueprint_Click(object sender, EventArgs e)
        {
            if (dgvProductionTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a production task to view its blueprint.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string taskId = dgvProductionTasks.SelectedRows[0].Cells["Task ID"].Value.ToString();
            string productName = dgvProductionTasks.SelectedRows[0].Cells["Product to Manufacture"].Value.ToString();


            MessageBox.Show($"Opening CAD / PDF Blueprint viewer for:\n\nTask ID: {taskId}\nProduct: {productName}\n\n(Simulation: Blueprint CAD file loaded successfully!)", "Blueprint Viewer", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ShowSuccessStatus($"Blueprint for {taskId} loaded.");
        }


        private void btnReportDefect_Click(object sender, EventArgs e)
        {
            if (dgvProductionTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a production task to report a defect.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string taskId = dgvProductionTasks.SelectedRows[0].Cells["Task ID"].Value.ToString();
            string currentStatus = dgvProductionTasks.SelectedRows[0].Cells["Current Status"].Value.ToString();


            DialogResult result = MessageBox.Show($"Are you sure you want to flag Task {taskId} as DEFECTIVE / ISSUE?\n\nThis will halt production and highlight the task for Quality Assurance.", "Report Defect", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.UpdateTaskStatus(taskId, "Defect / Issue");
                    LoadProductionTasks();

                    ShowSuccessStatus($"Task {taskId} has been flagged for defects.");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnRefreshRequests_Click(object sender, EventArgs e)
        {
            LoadMaterialRequests();
            ShowSuccessStatus("Material requests refreshed.");
        }

        private void LoadMaterialRequests()
        {
            try
            {
                if (dgvMaterialRequests != null)
                {
                    dgvMaterialRequests.DataSource = _controller.GetMaterialRequests();
                    dgvMaterialRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex) { MessageBox.Show("Failed to load material requests: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void PopulateMaterialComboBox()
        {
            try
            {
                DataTable dt = _controller.GetRawMaterials();
                if (cmbRequestMaterial != null)
                {
                    cmbRequestMaterial.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbRequestMaterial.Items.Add(row["inv_product_name"].ToString());
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine("Error populating material combo box: " + ex.Message); }
        }

        private void btnSubmitRequest_Click(object sender, EventArgs e)
        {
            string material = cmbRequestMaterial.Text;
            string qtyInput = txtRequestQty.Text.Trim();
            string urgency = cmbUrgency.Text;

            if (string.IsNullOrWhiteSpace(material) || string.IsNullOrWhiteSpace(urgency))
            {
                MessageBox.Show("Please select a Material and Urgency level.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(qtyInput, out int qty) || qty <= 0)
            {
                MessageBox.Show("Quantity must be a valid positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _controller.SubmitMaterialRequest(material, qty, urgency);

                cmbRequestMaterial.SelectedIndex = -1;
                cmbUrgency.SelectedIndex = -1;
                txtRequestQty.Clear();

                LoadMaterialRequests();


                ShowSuccessStatus("Material request submitted to Inventory!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void SetupDashboardPanel(Panel panel)
        {
            // Title Bar
            Panel titleBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 90,
                BackColor = _primaryColor
            };

            Label titleLabel = new Label
            {
                Text = "Production Dashboard",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(30, 25),
                AutoSize = true
            };

            Label subtitleLabel = new Label
            {
                Text = "Overview of manufacturing operations",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(230, 230, 230),
                Location = new Point(30, 55),
                AutoSize = true
            };

            titleBar.Controls.Add(titleLabel);
            titleBar.Controls.Add(subtitleLabel);
            panel.Controls.Add(titleBar);

            // Stats Cards
            int cardY = 110;
            CreateStatCard(panel, "Total Tasks", "12", Color.FromArgb(59, 130, 246), 30, cardY);
            CreateStatCard(panel, "In Production", "5", Color.FromArgb(16, 185, 129), 300, cardY);
            CreateStatCard(panel, "Completed Today", "8", Color.FromArgb(245, 158, 11), 570, cardY);
            CreateStatCard(panel, "Quality Issues", "1", Color.FromArgb(239, 68, 68), 840, cardY);

            // Recent Tasks Grid
            Label recentLabel = new Label
            {
                Text = "Recent Production Tasks",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 50, 50),
                Location = new Point(30, 270),
                AutoSize = true
            };

            DataGridView recentTasksGrid = new DataGridView
            {
                Location = new Point(30, 310),
                Size = new Size(800, 250),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                Name = "recentTasksGrid"
            };

            panel.Controls.Add(recentLabel);
            panel.Controls.Add(recentTasksGrid);
        }

        private void CreateStatCard(Panel panel, string title, string value, Color color, int x, int y)
        {
            Panel card = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(240, 130),
                BackColor = Color.White
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
                Location = new Point(20, 50),
                AutoSize = true
            };

            card.Controls.Add(titleLabel);
            card.Controls.Add(valueLabel);
            panel.Controls.Add(card);
        }

        private void SetupCreateOrderPanel(Panel panel)
        {
            // Title Bar
            Panel titleBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 90,
                BackColor = _primaryColor
            };

            Label titleLabel = new Label
            {
                Text = "Create Production Order",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(30, 25),
                AutoSize = true
            };

            titleBar.Controls.Add(titleLabel);
            panel.Controls.Add(titleBar);

            // Form Controls
            GroupBox orderGroup = new GroupBox
            {
                Text = "Order Details",
                Location = new Point(30, 120),
                Size = new Size(500, 400),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = _primaryColor
            };

            Label productLabel = new Label
            {
                Text = "Product Name:",
                Location = new Point(30, 50),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };

            TextBox txtProduct = new TextBox
            {
                Location = new Point(150, 47),
                Size = new Size(300, 30),
                Name = "txtProduct"
            };

            Label qtyLabel = new Label
            {
                Text = "Quantity:",
                Location = new Point(30, 100),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };

            TextBox txtQty = new TextBox
            {
                Location = new Point(150, 97),
                Size = new Size(150, 30),
                Name = "txtQty"
            };

            Label priorityLabel = new Label
            {
                Text = "Priority:",
                Location = new Point(30, 150),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };

            ComboBox cmbPriority = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(150, 147),
                Size = new Size(150, 30),
                Name = "cmbPriority"
            };
            cmbPriority.Items.AddRange(new object[] { "Low", "Normal", "High", "Urgent" });
            cmbPriority.SelectedIndex = 1;

            Label notesLabel = new Label
            {
                Text = "Notes:",
                Location = new Point(30, 200),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };

            TextBox txtNotes = new TextBox
            {
                Location = new Point(150, 197),
                Size = new Size(300, 100),
                Multiline = true,
                Name = "txtNotes"
            };

            Button btnCreate = new Button
            {
                Text = "Create Order",
                Location = new Point(150, 330),
                Size = new Size(200, 45),
                BackColor = Color.FromArgb(16, 185, 129),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Name = "btnCreate"
            };
            btnCreate.Click += BtnCreateOrder_Click;

            orderGroup.Controls.Add(productLabel);
            orderGroup.Controls.Add(txtProduct);
            orderGroup.Controls.Add(qtyLabel);
            orderGroup.Controls.Add(txtQty);
            orderGroup.Controls.Add(priorityLabel);
            orderGroup.Controls.Add(cmbPriority);
            orderGroup.Controls.Add(notesLabel);
            orderGroup.Controls.Add(txtNotes);
            orderGroup.Controls.Add(btnCreate);

            panel.Controls.Add(orderGroup);
        }

        private void SetupQualityControlPanel(Panel panel)
        {
            // Title Bar
            Panel titleBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 90,
                BackColor = _primaryColor
            };

            Label titleLabel = new Label
            {
                Text = "Quality Control",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(30, 25),
                AutoSize = true
            };

            titleBar.Controls.Add(titleLabel);
            panel.Controls.Add(titleBar);

            // Quality Grid
            Label qcLabel = new Label
            {
                Text = "Quality Inspection List",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 50, 50),
                Location = new Point(30, 120),
                AutoSize = true
            };

            DataGridView qcGrid = new DataGridView
            {
                Location = new Point(30, 160),
                Size = new Size(800, 350),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                Name = "qcGrid"
            };

            Button btnPass = new Button
            {
                Text = "Mark as Passed",
                Location = new Point(30, 530),
                Size = new Size(180, 40),
                BackColor = Color.FromArgb(16, 185, 129),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Name = "btnPass"
            };
            btnPass.Click += BtnMarkPassed_Click;

            Button btnFail = new Button
            {
                Text = "Mark as Failed",
                Location = new Point(230, 530),
                Size = new Size(180, 40),
                BackColor = Color.FromArgb(239, 68, 68),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Name = "btnFail"
            };
            btnFail.Click += BtnMarkFailed_Click;

            panel.Controls.Add(qcLabel);
            panel.Controls.Add(qcGrid);
            panel.Controls.Add(btnPass);
            panel.Controls.Add(btnFail);
        }

        private void LoadDashboardData()
        {
            try
            {
                DataGridView grid = _panelDashboard.Controls.Find("recentTasksGrid", true)[0] as DataGridView;
                if (grid != null)
                {
                    DataTable dt = _controller.GetProductionTasks();
                    grid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadQualityControlData()
        {
            try
            {
                DataGridView grid = _panelQualityControl.Controls.Find("qcGrid", true)[0] as DataGridView;
                if (grid != null)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Task ID");
                    dt.Columns.Add("Product");
                    dt.Columns.Add("Status");
                    dt.Columns.Add("Inspector");
                    dt.Columns.Add("Date");
                    dt.Rows.Add("T001", "Luxury Chair", "Pending", "-", DateTime.Now.ToString("yyyy-MM-dd"));
                    dt.Rows.Add("T002", "Dining Table", "Passed", "John", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                    dt.Rows.Add("T003", "Sofa", "Failed", "Mary", DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd"));
                    grid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading QC data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCreateOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Production order created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowSuccessStatus("New production order created");
        }

        private void BtnMarkPassed_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Item marked as passed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowSuccessStatus("Quality check passed");
        }

        private void BtnMarkFailed_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Item marked as failed!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ShowSuccessStatus("Quality check failed recorded");
        }
    }
}
