using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Group2Project.Controllers;
using Group2Project.Utils;

namespace Group2Project.Views.Sub02_Order
{
    public partial class POSForm : Form
    {
        private POSController _posController;
        private DataTable _cartTable;
        private DataTable _currentUser;
        private string _currentUserRole;

        // 侧边栏和内容面板
        private Panel _sidebarPanel;
        private Panel _contentPanel;
        private Panel _panelSales;
        private Panel _panelDefectReport;
        private Panel _panelDefectHistory;
        private Button _currentNavButton;
        
        // 缺陷报告控件引用
        private DataGridView _dgvDefectHistory;
        private TextBox _txtSearchDefect;

        // 颜色主题 (POS 主题色)
        private readonly Color _primaryColor = Color.FromArgb(46, 125, 50);
        private readonly Color _secondaryColor = Color.FromArgb(76, 175, 80);
        private readonly Color _sidebarColor = Color.FromArgb(30, 30, 30);
        private readonly Color _backgroundColor = Color.FromArgb(245, 245, 245);

        public POSForm(DataTable user)
        {
            // 确保窗体在完全设置好之前不会显示
            this.Visible = false;
            this.ShowInTaskbar = false;
            
            InitializeComponent();
            
            _posController = new POSController();
            _currentUser = user;
            _currentUserRole = "Staff";
            
            try
            {
                // 先设置内容面板，再移除 TabControl
                SetupContentPanels();
                
                // 移除原始的 TabControl
                if (tcPOS != null)
                {
                    this.Controls.Remove(tcPOS);
                    tcPOS.Dispose();
                }

                // 设置侧边栏
                SetupSidebar();
                
                InitializeCart();
            LoadCategories();
            LoadAllProducts();
            SetupEventHandlers();
            LoadDefectReportPanel();
            try
            {
                LoadDefectHistoryPanel();
            }
                catch (Exception ex)
                {
                    // If defect history panel fails (e.g., missing table), still show the form
                    Label errorLabel = new Label
                    {
                        Text = "缺陷历史功能不可用。\n请运行 add_missing_tables.sql 来创建缺失的数据库表。",
                        AutoSize = true,
                        Location = new Point(20, 20),
                        ForeColor = Color.Red
                    };
                    _panelDefectHistory.Controls.Add(errorLabel);
                }
                ApplyLanguage();

                // 显示默认面板
                ShowPanel(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"初始化 POS 界面时出错: {ex.Message}\n\n请运行项目目录中的 add_missing_tables.sql 脚本来创建缺失的数据库表。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            LanguageManager.LanguageChanged += OnLanguageChanged;
        }

        private void OnLanguageChanged()
        {
            ApplyLanguage();
        }

        private void ApplyLanguage()
        {
            this.Text = LanguageManager.GetString("POSForm_Title");
            
            lblSearchTitle.Text = LanguageManager.GetString("POSForm_SearchTitle");
            label2.Text = LanguageManager.GetString("POSForm_Category");
            label3.Text = LanguageManager.GetString("POSForm_Barcode");
            label4.Text = LanguageManager.GetString("POSForm_PriceRange");
            label5.Text = LanguageManager.GetString("POSForm_Min");
            label6.Text = LanguageManager.GetString("POSForm_Max");
            label7.Text = LanguageManager.GetString("POSForm_Description");
            txtSearch.Text = LanguageManager.GetString("POSForm_Search");
            lblSearchResults.Text = LanguageManager.GetString("POSForm_SearchResults");
            
            lblCartTitle.Text = LanguageManager.GetString("POSForm_CartTitle");
            lblSubtotalLabel.Text = LanguageManager.GetString("POSForm_Subtotal");
            lblDiscountLabel.Text = LanguageManager.GetString("POSForm_Discount");
            lblTaxLabel.Text = LanguageManager.GetString("POSForm_Tax");
            btnClearCart.Text = LanguageManager.GetString("POSForm_ClearCart");
            btnCheckout.Text = LanguageManager.GetString("POSForm_Checkout");
            
            UpdateCartTotal();
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
                Text = "🛒 POS System",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 30),
                AutoSize = true
            };

            sidebarHeader.Controls.Add(sidebarTitle);
            _sidebarPanel.Controls.Add(sidebarHeader);

            // 创建导航按钮
            int yPosition = 110;
            CreateNavButton("Sales", 0, ref yPosition);
            CreateNavButton("Defect Report", 1, ref yPosition);
            CreateNavButton("Defect History", 2, ref yPosition);

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

            // 销售面板 - 从 tbSearch 移动控件
            _panelSales = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor
            };
            MoveControlsFromTabPage(tbSearch, _panelSales);

            // 缺陷报告面板
            _panelDefectReport = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };

            // 缺陷历史面板
            _panelDefectHistory = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };

            // 添加所有面板到内容面板
            _contentPanel.Controls.Add(_panelDefectHistory);
            _contentPanel.Controls.Add(_panelDefectReport);
            _contentPanel.Controls.Add(_panelSales);

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
                ctrl.Dock = DockStyle.Fill;
            }
        }

        private void ShowPanel(int index)
        {
            // 隐藏所有面板
            _panelSales.Visible = false;
            _panelDefectReport.Visible = false;
            _panelDefectHistory.Visible = false;

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
                    _panelSales.Visible = true;
                    _panelSales.BringToFront();
                    break;
                case 1:
                    _panelDefectReport.Visible = true;
                    _panelDefectReport.BringToFront();
                    break;
                case 2:
                    _panelDefectHistory.Visible = true;
                    _panelDefectHistory.BringToFront();
                    break;
            }
        }

        private void InitializeCart()
        {
            _cartTable = new DataTable();
            _cartTable.Columns.Add("Product ID");
            _cartTable.Columns.Add("Product Name");
            _cartTable.Columns.Add("Quantity", typeof(int));
            _cartTable.Columns.Add("Unit Price", typeof(decimal));
            _cartTable.Columns.Add("Subtotal", typeof(decimal));
            
            dgvCart.DataSource = _cartTable;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadCategories()
        {
            try
            {
                DataTable categories = _posController.GetAllCategories();
                cmbCategory.Items.Clear();
                cmbCategory.Items.Add("");
                foreach (DataRow row in categories.Rows)
                {
                    cmbCategory.Items.Add(row["Category"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(LanguageManager.GetString("POSForm_LoadProductsError") + ex.Message, 
                    LanguageManager.GetString("POSForm_Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllProducts()
        {
            try
            {
                DataTable products = _posController.SearchProducts("", "", "", null, null, "");
                SetupProductGrid(products);
            }
            catch (Exception ex)
            {
                MessageBox.Show(LanguageManager.GetString("POSForm_LoadProductsError") + ex.Message, 
                    LanguageManager.GetString("POSForm_Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupProductGrid(DataTable products)
        {
            dgvProducts.DataSource = products;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            if (!dgvProducts.Columns.Contains("Add"))
            {
                foreach (DataGridViewColumn col in dgvProducts.Columns)
                {
                    if (col.Name == "Cost") col.Visible = false;
                    if (col.Name == "Is Large Item") col.Visible = false;
                }
                
                DataGridViewButtonColumn addBtnColumn = new DataGridViewButtonColumn();
                addBtnColumn.Name = "Add";
                addBtnColumn.Text = LanguageManager.GetString("POSForm_AddToCart");
                addBtnColumn.UseColumnTextForButtonValue = true;
                dgvProducts.Columns.Add(addBtnColumn);
            }
            else
            {
                if (dgvProducts.Columns["Add"] is DataGridViewButtonColumn btnColumn)
                {
                    btnColumn.Text = LanguageManager.GetString("POSForm_AddToCart");
                }
            }
        }

        private void SetupEventHandlers()
        {
            txtSearch.Click += Search_Click;
            dgvProducts.CellClick += DgvProducts_CellClick;
            btnCheckout.Click += BtnCheckout_Click;
            btnClearCart.Click += BtnClearCart_Click;
            dgvCart.CellDoubleClick += DgvCart_CellDoubleClick;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                string productId = txtProductId.Text.Trim();
                string category = cmbCategory.SelectedIndex > 0 ? cmbCategory.SelectedItem.ToString() : "";
                string barcode = txtBarcode.Text.Trim();
                string description = txtDescription.Text.Trim();
                
                decimal? minPrice = null;
                decimal? maxPrice = null;
                
                if (!string.IsNullOrWhiteSpace(txtMinPrice.Text) && decimal.TryParse(txtMinPrice.Text, out decimal minP))
                {
                    minPrice = minP;
                }
                
                if (!string.IsNullOrWhiteSpace(txtMaxPrice.Text) && decimal.TryParse(txtMaxPrice.Text, out decimal maxP))
                {
                    maxPrice = maxP;
                }

                DataTable results = _posController.SearchProducts(productId, category, barcode, minPrice, maxPrice, description);
                SetupProductGrid(results);
                
                toolStripStatusLabel1.Text = string.Format(LanguageManager.GetString("POSForm_FoundProducts"), results.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(LanguageManager.GetString("POSForm_SearchProductsError") + ex.Message, 
                    LanguageManager.GetString("POSForm_Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvProducts.Columns["Add"].Index)
            {
                try
                {
                    DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
                    string productId = row.Cells["Product ID"].Value.ToString();
                    string productName = row.Cells["Product Name"].Value.ToString();
                    decimal price = Convert.ToDecimal(row.Cells["Unit Price"].Value);
                    int stock = Convert.ToInt32(row.Cells["Stock Quantity"].Value);
                    
                    if (stock <= 0)
                    {
                        MessageBox.Show(LanguageManager.GetString("POSForm_OutOfStock"), 
                            LanguageManager.GetString("POSForm_Warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
                    using (var qtyForm = new Form())
                    {
                        qtyForm.Text = LanguageManager.GetString("POSForm_EnterQuantity");
                        qtyForm.Size = new Size(300, 150);
                        qtyForm.StartPosition = FormStartPosition.CenterParent;
                        
                        Label lbl = new Label() { Text = LanguageManager.GetString("POSForm_Quantity"), Location = new Point(20, 20) };
                        TextBox txtQty = new TextBox() { Location = new Point(100, 20), Width = 150, Text = "1" };
                        Button btnOk = new Button() { Text = LanguageManager.GetString("POSForm_OK"), DialogResult = DialogResult.OK, Location = new Point(50, 60), Size = new Size(80, 30) };
                        Button btnCancel = new Button() { Text = LanguageManager.GetString("POSForm_Cancel"), DialogResult = DialogResult.Cancel, Location = new Point(150, 60), Size = new Size(80, 30) };
                        
                        qtyForm.Controls.AddRange(new Control[] { lbl, txtQty, btnOk, btnCancel });
                        qtyForm.AcceptButton = btnOk;
                        qtyForm.CancelButton = btnCancel;
                        
                        if (qtyForm.ShowDialog() == DialogResult.OK)
                        {
                            if (int.TryParse(txtQty.Text, out int qty) && qty > 0 && qty <= stock)
                            {
                                AddToCart(productId, productName, qty, price);
                            }
                            else
                            {
                                MessageBox.Show(LanguageManager.GetString("POSForm_InvalidQuantity"), 
                                    LanguageManager.GetString("POSForm_Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(LanguageManager.GetString("POSForm_AddToCartError") + ex.Message, 
                        LanguageManager.GetString("POSForm_Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddToCart(string productId, string productName, int quantity, decimal unitPrice)
        {
            decimal subtotal = quantity * unitPrice;
            _cartTable.Rows.Add(productId, productName, quantity, unitPrice, subtotal);
            UpdateCartTotal();
            toolStripStatusLabel1.Text = string.Format(LanguageManager.GetString("POSForm_AddedToCart"), quantity, productName);
        }

        private void UpdateCartTotal()
        {
            decimal subtotal = 0;
            foreach (DataRow row in _cartTable.Rows)
            {
                subtotal += Convert.ToDecimal(row["Subtotal"]);
            }
            
            decimal discount = 0;
            decimal tax = subtotal * 0.08m;
            decimal total = subtotal - discount + tax;
            
            lblSubtotal.Text = $"${subtotal:F2}";
            lblDiscount.Text = $"${discount:F2}";
            lblTax.Text = $"${tax:F2}";
            lblTotalAmount.Text = $"Total: ${total:F2}";
        }

        private void BtnClearCart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(LanguageManager.GetString("POSForm_ClearCartConfirm"), 
                LanguageManager.GetString("POSForm_Confirm"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _cartTable.Clear();
                UpdateCartTotal();
                toolStripStatusLabel1.Text = LanguageManager.GetString("POSForm_CartCleared");
            }
        }

        private void DgvCart_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (MessageBox.Show(LanguageManager.GetString("POSForm_RemoveItemConfirm"), 
                    LanguageManager.GetString("POSForm_Confirm"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _cartTable.Rows.RemoveAt(e.RowIndex);
                    UpdateCartTotal();
                }
            }
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (_cartTable.Rows.Count == 0)
            {
                MessageBox.Show(LanguageManager.GetString("POSForm_CartEmpty"), 
                    LanguageManager.GetString("POSForm_Warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            using (CheckoutForm checkout = new CheckoutForm(_cartTable.Copy(), _currentUserRole))
            {
                if (checkout.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string paymentMethod = checkout.PaymentMethod;
                        decimal discount = checkout.Discount;
                        decimal paidAmount = checkout.PaidAmount;
                        bool requiresDelivery = checkout.RequiresDelivery;
                        string deliveryAddress = checkout.DeliveryAddress;
                        string deliveryContact = checkout.DeliveryContact;
                        DateTime? deliveryDate = checkout.DeliveryDate;
                        string installationTime = checkout.InstallationTime;
                        
                        decimal finalAmount = _posController.SubmitPOSOrder(_cartTable, paymentMethod, discount, paidAmount, requiresDelivery, deliveryAddress, deliveryContact, deliveryDate, installationTime);
                        
                        if (checkout.PrintReceipt)
                        {
                            var pd = _posController.GenerateReceipt("New Order", _cartTable, finalAmount, discount, paidAmount, paymentMethod);
                            PrintPreviewDialog preview = new PrintPreviewDialog();
                            preview.Document = pd;
                            preview.ShowDialog();
                        }
                        
                        _cartTable.Clear();
                        UpdateCartTotal();
                        toolStripStatusLabel1.Text = LanguageManager.GetString("POSForm_CheckoutComplete");
                        MessageBox.Show(LanguageManager.GetString("POSForm_CheckoutComplete"), 
                            LanguageManager.GetString("POSForm_Success"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(LanguageManager.GetString("POSForm_CheckoutError") + ex.Message, 
                            LanguageManager.GetString("POSForm_Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void LoadDefectReportPanel()
        {
            Panel pnlDefect = new Panel();
            pnlDefect.Dock = DockStyle.Fill;
            pnlDefect.BackColor = Color.White;
            pnlDefect.Padding = new Padding(20);

            Label lblTitle = new Label() { Text = "Defect Report", Font = new Font("Segoe UI", 16, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true };

            Label lblProductId = new Label() { Text = "Product ID:", Location = new Point(20, 60), AutoSize = true };
            TextBox txtProductId = new TextBox() { Location = new Point(150, 55), Width = 300 };

            Label lblProductName = new Label() { Text = "Product Name:", Location = new Point(20, 100), AutoSize = true };
            TextBox txtProductName = new TextBox() { Location = new Point(150, 95), Width = 300 };

            Label lblDefect = new Label() { Text = "Defect Description:", Location = new Point(20, 140), AutoSize = true };
            TextBox txtDefect = new TextBox() { Location = new Point(150, 135), Width = 400, Height = 150, Multiline = true };

            Button btnSubmitDefect = new Button() { Text = "Submit Report", Location = new Point(150, 300), Size = new Size(150, 40), BackColor = Color.FromArgb(46, 125, 50), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 11, FontStyle.Bold) };

            btnSubmitDefect.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtProductId.Text) || string.IsNullOrWhiteSpace(txtDefect.Text))
                {
                    MessageBox.Show("Please fill in Product ID and Defect Description.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                try
                {
                    string reportedBy = _currentUser != null ? _currentUserRole : "Staff";
                    _posController.SubmitDefectReport(txtProductId.Text, txtProductName.Text, txtDefect.Text, reportedBy);
                    MessageBox.Show("Defect report submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProductId.Clear();
                    txtProductName.Clear();
                    txtDefect.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error submitting report: " + ex.Message + "\n\n请运行 add_missing_tables.sql 来创建缺失的数据库表。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            pnlDefect.Controls.AddRange(new Control[] { lblTitle, lblProductId, txtProductId, lblProductName, txtProductName, lblDefect, txtDefect, btnSubmitDefect });
            _panelDefectReport.Controls.Add(pnlDefect);
        }

        private void LoadDefectHistoryPanel()
        {
            Panel pnlDefectHistory = new Panel();
            pnlDefectHistory.Dock = DockStyle.Fill;
            pnlDefectHistory.BackColor = Color.White;
            pnlDefectHistory.Padding = new Padding(20);

            Label lblTitle = new Label() { Text = "Defect Report History", Font = new Font("Segoe UI", 16, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true };

            _txtSearchDefect = new TextBox() { Location = new Point(20, 60), Width = 300 };
            Button btnSearchDefect = new Button() { Text = "Search", Location = new Point(330, 55), Size = new Size(100, 35) };
            Button btnRefreshDefect = new Button() { Text = "Refresh", Location = new Point(440, 55), Size = new Size(100, 35) };

            _dgvDefectHistory = new DataGridView();
            _dgvDefectHistory.Location = new Point(20, 100);
            _dgvDefectHistory.Size = new Size(1000, 550);
            _dgvDefectHistory.AllowUserToAddRows = false;
            _dgvDefectHistory.ReadOnly = true;
            _dgvDefectHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvDefectHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgvDefectHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            Button btnUpdateStatus = new Button() { Text = "Update Status", Location = new Point(20, 670), Size = new Size(120, 35), BackColor = Color.LightBlue };
            ComboBox cmbStatus = new ComboBox() { Location = new Point(150, 670), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbStatus.Items.AddRange(new string[] { "Pending Review", "In Progress", "Resolved", "Closed" });
            cmbStatus.SelectedIndex = 0;

            btnUpdateStatus.Click += (s, e) =>
            {
                if (_dgvDefectHistory.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Update status to: " + cmbStatus.SelectedItem, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            int reportId = Convert.ToInt32(_dgvDefectHistory.SelectedRows[0].Cells["Report ID"].Value);
                            _posController.UpdateDefectReportStatus(reportId, cmbStatus.SelectedItem.ToString());
                            _dgvDefectHistory.DataSource = _posController.GetDefectReportHistory("");
                            MessageBox.Show("Status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating status: " + ex.Message);
                        }
                    }
                }
            };

            btnSearchDefect.Click += (s, e) =>
            {
                try
                {
                    _dgvDefectHistory.DataSource = _posController.GetDefectReportHistory(_txtSearchDefect.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error searching defect reports: " + ex.Message);
                }
            };

            btnRefreshDefect.Click += (s, e) =>
            {
                try
                {
                    _dgvDefectHistory.DataSource = _posController.GetDefectReportHistory("");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error refreshing defect reports: " + ex.Message);
                }
            };

            pnlDefectHistory.Controls.AddRange(new Control[] { lblTitle, _txtSearchDefect, btnSearchDefect, btnRefreshDefect, _dgvDefectHistory, btnUpdateStatus, cmbStatus });
            _panelDefectHistory.Controls.Add(pnlDefectHistory);
            _dgvDefectHistory.DataSource = _posController.GetDefectReportHistory("");
        }
    }
}
