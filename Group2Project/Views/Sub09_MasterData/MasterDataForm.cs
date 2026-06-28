using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Group2Project.Controllers;

namespace Group2Project.Views.Sub09_MasterData
{
    public partial class MasterDataForm : Form
    {
        private MasterDataController _controller;
        private System.Windows.Forms.Timer _statusTimer;

        // 侧边栏和内容面板
        private Panel _sidebarPanel;
        private Panel _contentPanel;
        private Panel _panelStaff;
        private Panel _panelSuppliers;
        private Panel _panelCustomers;
        private Panel _panelDrivers;
        private Panel _panelProducts;
        private Button _currentNavButton;

        // 当前选中的行
        private DataGridViewRow _selectedStaffRow;
        private DataGridViewRow _selectedSupplierRow;
        private DataGridViewRow _selectedCustomerRow;
        private DataGridViewRow _selectedDriverRow;
        private DataGridViewRow _selectedProductRow;

        // 搜索框
        private TextBox _txtStaffSearch;
        private TextBox _txtSupplierSearch;
        private TextBox _txtCustomerSearch;
        private TextBox _txtDriverSearch;
        private TextBox _txtProductSearch;

        // 颜色主题 (主数据主题 - 专业蓝)
        private readonly Color _primaryColor = Color.FromArgb(33, 150, 243);
        private readonly Color _secondaryColor = Color.FromArgb(100, 181, 246);
        private readonly Color _dangerColor = Color.FromArgb(244, 67, 54);
        private readonly Color _successColor = Color.FromArgb(76, 175, 80);
        private readonly Color _sidebarColor = Color.FromArgb(24, 30, 54);
        private readonly Color _backgroundColor = Color.FromArgb(245, 247, 250);

        public MasterDataForm()
        {
            // 确保窗体在完全设置好之前不会显示
            this.Visible = false;
            this.ShowInTaskbar = false;

            InitializeComponent();
            _controller = new MasterDataController();
            this.Load += MasterDataForm_Load;

            try
            {
                // 先设置内容面板，再移除 TabControl
                SetupContentPanels();

                // 移除原始的 TabControl
                if (tbMDForm != null)
                {
                    this.Controls.Remove(tbMDForm);
                    tbMDForm.Dispose();
                }

                // 设置侧边栏
                SetupSidebar();

                // 显示默认面板
                ShowPanel(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"初始化主数据界面时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // 侧边栏面板
            _sidebarPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 260,
                BackColor = _sidebarColor
            };

            // 侧边栏标题
            Panel sidebarHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.FromArgb(15, 20, 40)
            };

            Label sidebarTitle = new Label
            {
                Text = "📊 Master Data",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(25, 30),
                AutoSize = true
            };

            sidebarHeader.Controls.Add(sidebarTitle);
            _sidebarPanel.Controls.Add(sidebarHeader);

            // 创建导航按钮
            int yPosition = 110;
            CreateNavButton("👥 Staff Management", 0, ref yPosition);
            CreateNavButton("🏭 Suppliers", 1, ref yPosition);
            CreateNavButton("👤 Customers", 2, ref yPosition);
            CreateNavButton("🚚 Drivers", 3, ref yPosition);
            CreateNavButton("📦 Products", 4, ref yPosition);

            this.Controls.Add(_sidebarPanel);
        }

        private void CreateNavButton(string text, int index, ref int yPosition)
        {
            Button btn = new Button
            {
                Text = text,
                Tag = index,
                Location = new Point(15, yPosition),
                Size = new Size(230, 50),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0),
                Cursor = Cursors.Hand
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 50, 80);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 60, 100);
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

            // 设置各面板
            _panelStaff = SetupStaffPanel();
            _panelSuppliers = SetupSuppliersPanel();
            _panelCustomers = SetupCustomersPanel();
            _panelDrivers = SetupDriversPanel();
            _panelProducts = SetupProductsPanel();

            // 添加所有面板到内容面板
            _contentPanel.Controls.Add(_panelProducts);
            _contentPanel.Controls.Add(_panelDrivers);
            _contentPanel.Controls.Add(_panelCustomers);
            _contentPanel.Controls.Add(_panelSuppliers);
            _contentPanel.Controls.Add(_panelStaff);

            this.Controls.Add(_contentPanel);
            _contentPanel.BringToFront();
        }

        private Panel SetupStaffPanel()
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = true
            };

            // 标题区域
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.White
            };

            Label titleLabel = new Label
            {
                Text = "👥 Staff Management",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 30),
                Location = new Point(30, 25),
                AutoSize = true
            };

            // 搜索框
            _txtStaffSearch = new TextBox
            {
                PlaceholderText = "🔍 Search staff...",
                Font = new Font("Segoe UI", 10),
                Location = new Point(400, 25),
                Size = new Size(300, 35),
                BorderStyle = BorderStyle.FixedSingle
            };
            _txtStaffSearch.TextChanged += (s, e) => LoadStaffData(_txtStaffSearch.Text);

            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(_txtStaffSearch);
            panel.Controls.Add(headerPanel);

            // DataGridView
            if (dgvStaff != null)
            {
                dgvStaff.Parent = null;
                dgvStaff.Dock = DockStyle.Fill;
                dgvStaff.BackgroundColor = _backgroundColor;
                dgvStaff.BorderStyle = BorderStyle.None;
                dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvStaff.AllowUserToAddRows = false;
                dgvStaff.ReadOnly = true;
                dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvStaff.MultiSelect = false;
                dgvStaff.RowHeadersVisible = false;
                dgvStaff.ColumnHeadersHeight = 40;
                dgvStaff.RowTemplate.Height = 35;
                dgvStaff.CellClick += (s, e) =>
                {
                    if (e.RowIndex >= 0)
                    {
                        _selectedStaffRow = dgvStaff.Rows[e.RowIndex];
                        PopulateStaffFields(_selectedStaffRow);
                    }
                };
                panel.Controls.Add(dgvStaff);
                dgvStaff.BringToFront();
            }

            return panel;
        }

        private Panel SetupSuppliersPanel()
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };

            // 标题区域
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.White
            };

            Label titleLabel = new Label
            {
                Text = "🏭 Supplier Management",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 30),
                Location = new Point(30, 25),
                AutoSize = true
            };

            _txtSupplierSearch = new TextBox
            {
                PlaceholderText = "🔍 Search suppliers...",
                Font = new Font("Segoe UI", 10),
                Location = new Point(450, 25),
                Size = new Size(300, 35),
                BorderStyle = BorderStyle.FixedSingle
            };
            _txtSupplierSearch.TextChanged += (s, e) => LoadSupplierData(_txtSupplierSearch.Text);

            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(_txtSupplierSearch);
            panel.Controls.Add(headerPanel);

            if (dgvSuppliers != null)
            {
                dgvSuppliers.Parent = null;
                dgvSuppliers.Dock = DockStyle.Fill;
                dgvSuppliers.BackgroundColor = _backgroundColor;
                dgvSuppliers.BorderStyle = BorderStyle.None;
                dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSuppliers.AllowUserToAddRows = false;
                dgvSuppliers.ReadOnly = true;
                dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvSuppliers.MultiSelect = false;
                dgvSuppliers.RowHeadersVisible = false;
                dgvSuppliers.ColumnHeadersHeight = 40;
                dgvSuppliers.RowTemplate.Height = 35;
                dgvSuppliers.CellClick += (s, e) =>
                {
                    if (e.RowIndex >= 0)
                    {
                        _selectedSupplierRow = dgvSuppliers.Rows[e.RowIndex];
                        PopulateSupplierFields(_selectedSupplierRow);
                    }
                };
                panel.Controls.Add(dgvSuppliers);
                dgvSuppliers.BringToFront();
            }

            return panel;
        }

        private Panel SetupCustomersPanel()
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };

            // 标题区域
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.White
            };

            Label titleLabel = new Label
            {
                Text = "👤 Customer Management",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 30),
                Location = new Point(30, 25),
                AutoSize = true
            };

            _txtCustomerSearch = new TextBox
            {
                PlaceholderText = "🔍 Search customers...",
                Font = new Font("Segoe UI", 10),
                Location = new Point(450, 25),
                Size = new Size(300, 35),
                BorderStyle = BorderStyle.FixedSingle
            };
            _txtCustomerSearch.TextChanged += (s, e) => LoadCustomerData(_txtCustomerSearch.Text);

            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(_txtCustomerSearch);
            panel.Controls.Add(headerPanel);

            if (dgvCustomers != null)
            {
                dgvCustomers.Parent = null;
                dgvCustomers.Dock = DockStyle.Fill;
                dgvCustomers.BackgroundColor = _backgroundColor;
                dgvCustomers.BorderStyle = BorderStyle.None;
                dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCustomers.AllowUserToAddRows = false;
                dgvCustomers.ReadOnly = true;
                dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCustomers.MultiSelect = false;
                dgvCustomers.RowHeadersVisible = false;
                dgvCustomers.ColumnHeadersHeight = 40;
                dgvCustomers.RowTemplate.Height = 35;
                dgvCustomers.CellClick += (s, e) =>
                {
                    if (e.RowIndex >= 0)
                    {
                        _selectedCustomerRow = dgvCustomers.Rows[e.RowIndex];
                        PopulateCustomerFields(_selectedCustomerRow);
                    }
                };
                panel.Controls.Add(dgvCustomers);
                dgvCustomers.BringToFront();
            }

            return panel;
        }

        private Panel SetupDriversPanel()
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };

            // 标题区域
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.White
            };

            Label titleLabel = new Label
            {
                Text = "🚚 Driver Management",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 30),
                Location = new Point(30, 25),
                AutoSize = true
            };

            _txtDriverSearch = new TextBox
            {
                PlaceholderText = "🔍 Search drivers...",
                Font = new Font("Segoe UI", 10),
                Location = new Point(420, 25),
                Size = new Size(300, 35),
                BorderStyle = BorderStyle.FixedSingle
            };
            _txtDriverSearch.TextChanged += (s, e) => LoadDriverData(_txtDriverSearch.Text);

            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(_txtDriverSearch);
            panel.Controls.Add(headerPanel);

            if (dgvDrivers != null)
            {
                dgvDrivers.Parent = null;
                dgvDrivers.Dock = DockStyle.Fill;
                dgvDrivers.BackgroundColor = _backgroundColor;
                dgvDrivers.BorderStyle = BorderStyle.None;
                dgvDrivers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDrivers.AllowUserToAddRows = false;
                dgvDrivers.ReadOnly = true;
                dgvDrivers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvDrivers.MultiSelect = false;
                dgvDrivers.RowHeadersVisible = false;
                dgvDrivers.ColumnHeadersHeight = 40;
                dgvDrivers.RowTemplate.Height = 35;
                dgvDrivers.CellClick += (s, e) =>
                {
                    if (e.RowIndex >= 0)
                    {
                        _selectedDriverRow = dgvDrivers.Rows[e.RowIndex];
                        PopulateDriverFields(_selectedDriverRow);
                    }
                };
                panel.Controls.Add(dgvDrivers);
                dgvDrivers.BringToFront();
            }

            return panel;
        }

        private Panel SetupProductsPanel()
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };

            // 标题区域
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.White
            };

            Label titleLabel = new Label
            {
                Text = "📦 Product Management",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 30),
                Location = new Point(30, 25),
                AutoSize = true
            };

            _txtProductSearch = new TextBox
            {
                PlaceholderText = "🔍 Search products...",
                Font = new Font("Segoe UI", 10),
                Location = new Point(430, 25),
                Size = new Size(300, 35),
                BorderStyle = BorderStyle.FixedSingle
            };
            _txtProductSearch.TextChanged += (s, e) => LoadProductData(_txtProductSearch.Text);

            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(_txtProductSearch);
            panel.Controls.Add(headerPanel);

            if (dgvProducts != null)
            {
                dgvProducts.Parent = null;
                dgvProducts.Dock = DockStyle.Fill;
                dgvProducts.BackgroundColor = _backgroundColor;
                dgvProducts.BorderStyle = BorderStyle.None;
                dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvProducts.AllowUserToAddRows = false;
                dgvProducts.ReadOnly = true;
                dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvProducts.MultiSelect = false;
                dgvProducts.RowHeadersVisible = false;
                dgvProducts.ColumnHeadersHeight = 40;
                dgvProducts.RowTemplate.Height = 35;
                dgvProducts.CellClick += (s, e) =>
                {
                    if (e.RowIndex >= 0)
                    {
                        _selectedProductRow = dgvProducts.Rows[e.RowIndex];
                        PopulateProductFields(_selectedProductRow);
                    }
                };
                panel.Controls.Add(dgvProducts);
                dgvProducts.BringToFront();
            }

            return panel;
        }

        private void ShowPanel(int index)
        {
            // 隐藏所有面板
            _panelStaff.Visible = false;
            _panelSuppliers.Visible = false;
            _panelCustomers.Visible = false;
            _panelDrivers.Visible = false;
            _panelProducts.Visible = false;

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
                    _panelStaff.Visible = true;
                    _panelStaff.BringToFront();
                    LoadStaffData();
                    break;
                case 1:
                    _panelSuppliers.Visible = true;
                    _panelSuppliers.BringToFront();
                    LoadSupplierData();
                    break;
                case 2:
                    _panelCustomers.Visible = true;
                    _panelCustomers.BringToFront();
                    LoadCustomerData();
                    break;
                case 3:
                    _panelDrivers.Visible = true;
                    _panelDrivers.BringToFront();
                    LoadDriverData();
                    break;
                case 4:
                    _panelProducts.Visible = true;
                    _panelProducts.BringToFront();
                    LoadProductData();
                    break;
            }
        }

        private void ShowSuccessStatus(string message)
        {
            if (lblStatus != null)
            {
                lblStatus.Text = "✅ " + message;
                lblStatus.ForeColor = _successColor;
                _statusTimer.Stop();
                _statusTimer.Start();
            }
        }

        private void ShowErrorStatus(string message)
        {
            if (lblStatus != null)
            {
                lblStatus.Text = "❌ " + message;
                lblStatus.ForeColor = _dangerColor;
                _statusTimer.Stop();
                _statusTimer.Start();
            }
        }

        private void MasterDataForm_Load(object sender, EventArgs e)
        {
            LoadStaffData();
            LoadSupplierData();
            LoadCustomerData();
            LoadDriverData();
            LoadProductData();
        }

        // ==================== Staff Methods ====================
        private void LoadStaffData(string searchKeyword = "")
        {
            try
            {
                if (dgvStaff != null)
                {
                    dgvStaff.DataSource = _controller.GetStaffList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load staff: " + ex.Message);
            }
        }

        private void PopulateStaffFields(DataGridViewRow row)
        {
            if (row == null) return;
            txtStaffID.Text = row.Cells["Staff ID"]?.Value?.ToString() ?? "";
            txtStaffName.Text = row.Cells["Name"]?.Value?.ToString() ?? "";
            txtPassword.Text = "";
            cmbRole.SelectedItem = row.Cells["Role"]?.Value?.ToString();
        }

        private void ClearStaffFields()
        {
            txtStaffID.Clear();
            txtStaffName.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = -1;
            _selectedStaffRow = null;
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            string id = txtStaffID.Text.Trim();
            string name = txtStaffName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cmbRole.Text;

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _controller.AddStaff(id, name, password, role);
                ClearStaffFields();
                LoadStaffData();
                ShowSuccessStatus("Staff member added successfully!");
            }
            catch (Exception ex)
            {
                ShowErrorStatus(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== Supplier Methods ====================
        private void LoadSupplierData(string searchKeyword = "")
        {
            try
            {
                if (dgvSuppliers != null)
                {
                    dgvSuppliers.DataSource = _controller.GetSupplierList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load suppliers: " + ex.Message);
            }
        }

        private void PopulateSupplierFields(DataGridViewRow row)
        {
            if (row == null) return;
            txtSupplierID.Text = row.Cells["Supplier ID"]?.Value?.ToString() ?? "";
            txtSupplierName.Text = row.Cells["Company Name"]?.Value?.ToString() ?? "";
            txtContact.Text = row.Cells["Contact Person"]?.Value?.ToString() ?? "";
            txtContactNumber.Text = row.Cells["Contact Number"]?.Value?.ToString() ?? "";
        }

        private void ClearSupplierFields()
        {
            txtSupplierID.Clear();
            txtSupplierName.Clear();
            txtContact.Clear();
            txtContactNumber.Clear();
            _selectedSupplierRow = null;
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            string id = txtSupplierID.Text.Trim();
            string name = txtSupplierName.Text.Trim();
            string contact = txtContact.Text.Trim();
            string num = txtContactNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please fill in required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _controller.AddSupplier(id, name, contact, num);
                ClearSupplierFields();
                LoadSupplierData();
                ShowSuccessStatus("Supplier added successfully!");
            }
            catch (Exception ex)
            {
                ShowErrorStatus(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== Customer Methods ====================
        private void LoadCustomerData(string searchKeyword = "")
        {
            try
            {
                if (dgvCustomers != null)
                {
                    dgvCustomers.DataSource = _controller.GetCustomerList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load customers: " + ex.Message);
            }
        }

        private void PopulateCustomerFields(DataGridViewRow row)
        {
            if (row == null) return;
            txtCustID.Text = row.Cells["Customer ID"]?.Value?.ToString() ?? "";
            txtCustName.Text = row.Cells["Customer Name"]?.Value?.ToString() ?? "";
            txtCustPhone.Text = row.Cells["Phone"]?.Value?.ToString() ?? "";
            txtCustAddress.Text = row.Cells["Address"]?.Value?.ToString() ?? "";
        }

        private void ClearCustomerFields()
        {
            txtCustID.Clear();
            txtCustName.Clear();
            txtCustPhone.Clear();
            txtCustAddress.Clear();
            _selectedCustomerRow = null;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string id = txtCustID.Text.Trim();
            string name = txtCustName.Text.Trim();
            string phone = txtCustPhone.Text.Trim();
            string address = txtCustAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please fill in required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _controller.AddCustomer(id, name, phone, address);
                ClearCustomerFields();
                LoadCustomerData();
                ShowSuccessStatus("Customer added successfully!");
            }
            catch (Exception ex)
            {
                ShowErrorStatus(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== Driver Methods ====================
        private void LoadDriverData(string searchKeyword = "")
        {
            try
            {
                if (dgvDrivers != null)
                {
                    dgvDrivers.DataSource = _controller.GetDriverList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load drivers: " + ex.Message);
            }
        }

        private void PopulateDriverFields(DataGridViewRow row)
        {
            if (row == null) return;
            txtDriverID.Text = row.Cells["Driver ID"]?.Value?.ToString() ?? "";
            txtDriverName.Text = row.Cells["Driver Name"]?.Value?.ToString() ?? "";
            cmbLicense.SelectedItem = row.Cells["License Type"]?.Value?.ToString();
        }

        private void ClearDriverFields()
        {
            txtDriverID.Clear();
            txtDriverName.Clear();
            cmbLicense.SelectedIndex = -1;
            _selectedDriverRow = null;
        }

        private void btnAddDriver_Click(object sender, EventArgs e)
        {
            string id = txtDriverID.Text.Trim();
            string name = txtDriverName.Text.Trim();
            string license = cmbLicense.Text;

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please fill in required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _controller.AddDriver(id, name, license);
                ClearDriverFields();
                LoadDriverData();
                ShowSuccessStatus("Driver added successfully!");
            }
            catch (Exception ex)
            {
                ShowErrorStatus(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== Product Methods ====================
        private void LoadProductData(string searchKeyword = "")
        {
            try
            {
                if (dgvProducts != null)
                {
                    dgvProducts.DataSource = _controller.GetProductList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load products: " + ex.Message);
            }
        }

        private void PopulateProductFields(DataGridViewRow row)
        {
            if (row == null) return;
            txtProdID.Text = row.Cells["Item ID"]?.Value?.ToString() ?? "";
            txtProdName.Text = row.Cells["Item Name"]?.Value?.ToString() ?? "";
            cmbProdCategory.SelectedItem = row.Cells["Category"]?.Value?.ToString();
            txtProdPrice.Text = row.Cells["Unit Price"]?.Value?.ToString() ?? "";
        }

        private void ClearProductFields()
        {
            txtProdID.Clear();
            txtProdName.Clear();
            txtProdPrice.Clear();
            cmbProdCategory.SelectedIndex = -1;
            _selectedProductRow = null;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string id = txtProdID.Text.Trim();
            string name = txtProdName.Text.Trim();
            string category = cmbProdCategory.Text;
            string priceStr = txtProdPrice.Text.Trim();

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name) || !decimal.TryParse(priceStr, out decimal price))
            {
                MessageBox.Show("Please enter valid product details and price.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _controller.AddProduct(id, name, category, price);
                ClearProductFields();
                LoadProductData();
                ShowSuccessStatus("Product added successfully!");
            }
            catch (Exception ex)
            {
                ShowErrorStatus(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 为了兼容旧代码保留的方法
        private void label2_Click(object sender, EventArgs e) { }
        private void tbMangeStaff_Click(object sender, EventArgs e) { }
    }
}
