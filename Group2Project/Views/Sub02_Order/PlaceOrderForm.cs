using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using Group2Project.Controllers;

namespace Group2Project.Views.Sub02_Order
{
    public partial class PlaceOrderForm : Form
    {
        private OrderController _controller;
        private DataTable _cartTable;
        private decimal _totalAmount = 0;

        private System.Windows.Forms.Timer _statusTimer;

        private Panel _sidebarPanel;
        private Panel _contentPanel;
        private Panel _panelRegularOrder;
        private Panel _panelMadeOrder;
        private Panel _panelSearchManageOrder;
        private Button _currentNavButton;

        private readonly Color _primaryColor = Color.FromArgb(46, 125, 50);
        private readonly Color _secondaryColor = Color.FromArgb(76, 175, 80);
        private readonly Color _sidebarColor = Color.FromArgb(30, 30, 30);
        private readonly Color _backgroundColor = Color.FromArgb(245, 245, 245);

        public PlaceOrderForm()
        {
            InitializeComponent();
            _controller = new OrderController();
            this.Load += PlaceOrderForm_Load;

            if (btnSearchOrder != null) btnSearchOrder.Click += btnSearchOrder_Click;
            if (btnCancelOrder != null) btnCancelOrder.Click += btnCancelOrder_Click;
            if (btnRefresh != null) btnRefresh.Click += btnRefresh_Click;
            if (btnViewDetails != null) btnViewDetails.Click += btnViewDetails_Click;
            if (btnEditOrder != null) btnEditOrder.Click += btnEditOrder_Click;
            if (btnPrintInvoice != null) btnPrintInvoice.Click += btnPrintInvoice_Click;

            _statusTimer = new System.Windows.Forms.Timer();
            _statusTimer.Interval = 3000;
            _statusTimer.Tick += (s, e) =>
            {

                if (lblStatus != null) lblStatus.Text = "";
                _statusTimer.Stop();
            };

            SetupContentPanels();
            if (tcOrderManager != null)
            {
                this.Controls.Remove(tcOrderManager);
                tcOrderManager.Dispose();
            }
            SetupSidebar();
            ShowPanel(0);
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
                Text = "🛒 Order Processing",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 30),
                AutoSize = true
            };

            sidebarHeader.Controls.Add(sidebarTitle);
            _sidebarPanel.Controls.Add(sidebarHeader);

            int yPosition = 110;
            CreateNavButton("Regular Order", 0, ref yPosition);
            CreateNavButton("Tailor-made Order", 1, ref yPosition);
            CreateNavButton("Search & Manage", 2, ref yPosition);

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

            _panelRegularOrder = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor
            };
            MoveControlsFromTabPage(tbRegularOrder, _panelRegularOrder);

            _panelMadeOrder = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };
            MoveControlsFromTabPage(tbMadeOrder, _panelMadeOrder);

            _panelSearchManageOrder = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };
            MoveControlsFromTabPage(tbSearchManageOrder, _panelSearchManageOrder);

            _contentPanel.Controls.Add(_panelSearchManageOrder);
            _contentPanel.Controls.Add(_panelMadeOrder);
            _contentPanel.Controls.Add(_panelRegularOrder);

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
            _panelRegularOrder.Visible = false;
            _panelMadeOrder.Visible = false;
            _panelSearchManageOrder.Visible = false;

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
                    _panelRegularOrder.Visible = true;
                    _panelRegularOrder.BringToFront();
                    break;
                case 1:
                    _panelMadeOrder.Visible = true;
                    _panelMadeOrder.BringToFront();
                    break;
                case 2:
                    _panelSearchManageOrder.Visible = true;
                    _panelSearchManageOrder.BringToFront();
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

        private void PlaceOrderForm_Load(object sender, EventArgs e)
        {
            RefreshOrderData();
            LoadFurnitureItems();
            InitializeCart();
        }

        private void InitializeCart()
        {
            _cartTable = new DataTable();
            _cartTable.Columns.Add("Product ID");
            _cartTable.Columns.Add("Product Name");
            _cartTable.Columns.Add("Quantity", typeof(int));
            _cartTable.Columns.Add("Unit Price", typeof(decimal));
            _cartTable.Columns.Add("Subtotal", typeof(decimal));

            if (dgvCart != null)
            {
                dgvCart.DataSource = _cartTable;
                dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCart.AllowUserToAddRows = false;
                dgvCart.ReadOnly = true;
            }
        }


        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbRegularItems.Text) || string.IsNullOrWhiteSpace(txtRegularQty.Text))
            {
                MessageBox.Show("Please select an item and enter quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtRegularQty.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Quantity must be a valid positive number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataRow productInfo = _controller.GetProductInfo(cmbRegularItems.Text);

                if (productInfo != null)
                {
                    string pId = productInfo["inv_product_id"].ToString();
                    decimal price = Convert.ToDecimal(productInfo["inv_price"]);
                    decimal subtotal = price * qty;

                    _cartTable.Rows.Add(pId, cmbRegularItems.Text, qty, price, subtotal);
                    _totalAmount += subtotal;
                    lblTotalAmount.Text = $"Total Amount: ${_totalAmount:0.00}";
                    cmbRegularItems.SelectedIndex = -1;
                    txtRegularQty.Clear();

                    ShowSuccessStatus("Item added to cart!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding to cart: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            if (_cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Your cart is empty! Please add items first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _controller.SubmitRegularOrder(_cartTable);

                _cartTable.Clear();
                _totalAmount = 0;
                lblTotalAmount.Text = "Total Amount: $0.00";
                RefreshOrderData();


                ShowSuccessStatus("Order placed successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Checkout Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnBrowseBlueprint_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtBlueprintPath.Text = openFileDialog1.FileName;
            }
        }

        private void btnSubmitCustomOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomCustID.Text) ||
                string.IsNullOrWhiteSpace(cmbCustomMaterial.Text) ||
                string.IsNullOrWhiteSpace(txtWidth.Text) ||
                string.IsNullOrWhiteSpace(txtLength.Text) ||
                string.IsNullOrWhiteSpace(txtHeight.Text))
            {
                MessageBox.Show("Please fill in all custom specifications!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _controller.SubmitCustomOrder(
                    txtCustomCustID.Text,
                    cmbCustomMaterial.Text,
                    txtWidth.Text,
                    txtLength.Text,
                    txtHeight.Text
                );

                txtCustomCustID.Clear();
                cmbCustomMaterial.SelectedIndex = -1;
                txtWidth.Clear(); txtLength.Clear(); txtHeight.Clear();
                txtBlueprintPath.Text = "No file selected...";

                RefreshOrderData();


                ShowSuccessStatus("Custom Order submitted successfully!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void LoadFurnitureItems()
        {
            try
            {
                var dt = _controller.GetFurnitureItems();
                if (cmbRegularItems != null)
                {
                    cmbRegularItems.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbRegularItems.Items.Add(row["inv_product_name"].ToString());
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void RefreshOrderData()
        {
            try
            {
                if (dgvOrderList != null)
                {
                    dgvOrderList.DataSource = _controller.GetAllOrders();
                    dgvOrderList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading orders: " + ex.Message); }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshOrderData();
            txtSearchKeyword.Clear();
            ShowSuccessStatus("List refreshed!");
        }

        private void btnSearchOrder_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchKeyword.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                RefreshOrderData();
                return;
            }

            try
            {
                dgvOrderList.DataSource = _controller.SearchOrders(keyword);
                ShowSuccessStatus("Search completed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrderList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order from the list to cancel.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string orderId = dgvOrderList.SelectedRows[0].Cells["Order ID"].Value.ToString();
            string status = dgvOrderList.SelectedRows[0].Cells["Status"].Value.ToString();

            if (status == "Cancelled")
            {
                MessageBox.Show("This order is already cancelled!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to cancel Order ID: {orderId}?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.CancelOrder(orderId);
                    if (!string.IsNullOrWhiteSpace(txtSearchKeyword.Text))
                    {
                        btnSearchOrder_Click(null, null);
                    }
                    else
                    {
                        RefreshOrderData();
                    }

                    ShowSuccessStatus($"Order {orderId} cancelled successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to cancel order: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvOrderList.CurrentCell == null)
            {
                MessageBox.Show("Please select an order to view its details.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dgvOrderList.CurrentCell.RowIndex;
            string orderId = dgvOrderList.Rows[rowIndex].Cells["Order ID"].Value.ToString();
            string customer = dgvOrderList.Rows[rowIndex].Cells["Customer Name"].Value.ToString();
            string contactSpecs = dgvOrderList.Rows[rowIndex].Cells["Contact Number"].Value.ToString();
            string status = dgvOrderList.Rows[rowIndex].Cells["Status"].Value.ToString();

            string details = $"--- Order Details ---\n\n" +
                             $"Order ID: {orderId}\n" +
                             $"Customer: {customer}\n" +
                             $"Contact/Specs: {contactSpecs}\n" +
                             $"Status: {status}\n\n" +
                             $"(Note: For full itemized breakdown, please visit the Account Module.)";

            MessageBox.Show(details, "Order Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrderList.CurrentCell == null)
            {
                MessageBox.Show("Please select an order to modify.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string orderId = dgvOrderList.CurrentCell.OwningRow.Cells["Order ID"].Value.ToString();
            string status = dgvOrderList.CurrentCell.OwningRow.Cells["Status"].Value.ToString();

            if (status == "Completed" || status == "Cancelled")
            {
                MessageBox.Show($"This order is already '{status}' and cannot be modified.", "Modification Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"Entering Edit Mode for Order ID: {orderId}.\n\n(System Note: Full modification interface is scheduled for Phase 2 deployment.)", "Modify Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (dgvOrderList.CurrentCell == null)
            {
                MessageBox.Show("Please select an order to print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string orderId = dgvOrderList.CurrentCell.OwningRow.Cells["Order ID"].Value.ToString();
            string customer = dgvOrderList.CurrentCell.OwningRow.Cells["Customer Name"].Value.ToString();
            string status = dgvOrderList.CurrentCell.OwningRow.Cells["Status"].Value.ToString();


            PrintDocument pd = new PrintDocument();


            pd.PrintPage += (s, printEvent) =>
            {
                Graphics g = printEvent.Graphics;


                Font titleFont = new Font("Arial", 22, FontStyle.Bold);
                Font subtitleFont = new Font("Arial", 14, FontStyle.Italic);
                Font regularFont = new Font("Arial", 12, FontStyle.Regular);
                Brush brush = Brushes.Black;


                int startX = 50;
                int startY = 50;
                int offset = 40;


                g.DrawString("PREMIUM LIVING FURNITURE", titleFont, brush, startX, startY);
                g.DrawString("Official Order Invoice", subtitleFont, brush, startX, startY + offset);

                g.DrawString("-------------------------------------------------------------------", regularFont, brush, startX, startY + (offset * 2));
                g.DrawString($"Order Reference ID: {orderId}", regularFont, brush, startX, startY + (offset * 3));
                g.DrawString($"Customer Name: {customer}", regularFont, brush, startX, startY + (offset * 4));
                g.DrawString($"Current Status: {status}", regularFont, brush, startX, startY + (offset * 5));
                g.DrawString($"Print Date: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}", regularFont, brush, startX, startY + (offset * 6));
                g.DrawString("-------------------------------------------------------------------", regularFont, brush, startX, startY + (offset * 7));

                g.DrawString("Thank you for your business!", subtitleFont, brush, startX, startY + (offset * 9));
                g.DrawString("Please contact our After-Sales department for any warranty claims.", regularFont, brush, startX, startY + (offset * 10));
            };


            try
            {
                PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                previewDialog.Document = pd;
                previewDialog.Width = 800;
                previewDialog.Height = 1000;
                previewDialog.ShowDialog();


                ShowSuccessStatus($"Invoice for Order {orderId} processed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Printing error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBlueprintPath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
