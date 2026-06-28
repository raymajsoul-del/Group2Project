using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Group2Project.Controllers;

namespace Group2Project.Views.Sub11_Purchase
{
    public partial class PurchaseForm : Form
    {
        private PurchaseController _controller;
        private Panel _sidebarPanel;
        private Panel _contentPanel;
        private Panel _panelPurchaseOrders;
        private Panel _panelCreatePO;
        private Panel _panelApprovePO;
        private Button _currentNavButton;

        private readonly Color _primaryColor = Color.FromArgb(147, 51, 234);
        private readonly Color _secondaryColor = Color.FromArgb(168, 85, 247);
        private readonly Color _sidebarColor = Color.FromArgb(45, 27, 78);
        private readonly Color _backgroundColor = Color.FromArgb(248, 245, 255);

        public PurchaseForm()
        {
            InitializeComponent();
            _controller = new PurchaseController();

            SetupContentPanels();
            if (tcPurchaseManager != null)
            {
                this.Controls.Remove(tcPurchaseManager);
                tcPurchaseManager.Dispose();
            }
            SetupSidebar();
            SetupDataGridViews();
            ShowPanel(0);

            this.Load += PurchaseForm_Load;
            BindEvents();
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
                BackColor = Color.FromArgb(30, 15, 60)
            };

            Label sidebarTitle = new Label
            {
                Text = "PURCHASE MANAGEMENT",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(25, 25),
                AutoSize = true
            };

            sidebarHeader.Controls.Add(sidebarTitle);
            _sidebarPanel.Controls.Add(sidebarHeader);

            int yPosition = 110;
            CreateNavButton("Purchase Orders", 0, ref yPosition);
            CreateNavButton("Create Purchase Order", 1, ref yPosition);
            CreateNavButton("Approve Purchase Orders", 2, ref yPosition);

            this.Controls.Add(_sidebarPanel);
        }

        private void CreateNavButton(string text, int index, ref int yPosition)
        {
            Button btn = new Button
            {
                Text = text,
                Tag = index,
                Location = new Point(15, yPosition),
                Size = new Size(230, 55),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(25, 0, 0, 0),
                Cursor = Cursors.Hand
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 35, 90);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 45, 110);
            btn.Click += NavButton_Click;

            _sidebarPanel.Controls.Add(btn);
            yPosition += 60;
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
                BackColor = Color.FromArgb(245, 240, 255)
            };

            Panel titlePanel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(2000, 90),
                BackColor = _primaryColor,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            Label titleLabel = new Label
            {
                Text = "Purchase Management",
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(35, 25),
                AutoSize = true
            };

            Label subtitleLabel = new Label
            {
                Text = "Manage your purchase orders and supplier relationships",
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                ForeColor = Color.FromArgb(200, 200, 255),
                Location = new Point(35, 55),
                AutoSize = true
            };

            titlePanel.Controls.Add(titleLabel);
            titlePanel.Controls.Add(subtitleLabel);
            _contentPanel.Controls.Add(titlePanel);

            _panelPurchaseOrders = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 240, 255),
                Padding = new Padding(35, 110, 35, 35)
            };
            MoveControlsFromTabPage(tbPurchaseOrders, _panelPurchaseOrders);

            _panelCreatePO = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 240, 255),
                Padding = new Padding(35, 110, 35, 35),
                Visible = false
            };
            MoveControlsFromTabPage(tbCreatePO, _panelCreatePO);

            _panelApprovePO = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 240, 255),
                Padding = new Padding(35, 110, 35, 35),
                Visible = false
            };
            SetupApprovePanel(_panelApprovePO);

            _contentPanel.Controls.Add(_panelPurchaseOrders);
            _contentPanel.Controls.Add(_panelCreatePO);
            _contentPanel.Controls.Add(_panelApprovePO);

            titlePanel.BringToFront();
            this.Controls.Add(_contentPanel);
            _contentPanel.BringToFront();
        }

        private void MoveControlsFromTabPage(TabPage tabPage, Panel targetPanel)
        {
            if (tabPage == null || targetPanel == null) return;

            Control[] controls = new Control[tabPage.Controls.Count];
            tabPage.Controls.CopyTo(controls, 0);

            foreach (Control ctrl in controls)
            {
                tabPage.Controls.Remove(ctrl);
                targetPanel.Controls.Add(ctrl);
                ctrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                if (ctrl is DataGridView dgv)
                {
                    dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                }
            }
        }

        private void SetupApprovePanel(Panel panel)
        {
            Label lblTitle = new Label
            {
                Text = "Approve Purchase Orders",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true,
                ForeColor = _primaryColor
            };

            DataGridView dgvApprove = new DataGridView
            {
                Location = new Point(20, 70),
                Size = new Size(800, 400),
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };
            dgvApprove.Name = "dgvApprove";

            Button btnApprove = new Button
            {
                Text = "Approve Selected",
                Location = new Point(20, 490),
                Size = new Size(200, 40),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(34, 197, 94),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };
            btnApprove.Name = "btnApproveSelected";
            btnApprove.Click += BtnApproveSelected_Click;

            Button btnReject = new Button
            {
                Text = "Reject Selected",
                Location = new Point(240, 490),
                Size = new Size(200, 40),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(239, 68, 68),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };
            btnReject.Name = "btnRejectSelected";
            btnReject.Click += BtnRejectSelected_Click;

            panel.Controls.AddRange(new Control[] { lblTitle, dgvApprove, btnApprove, btnReject });
            StyleAllControls(panel);
        }

        private void ShowPanel(int index)
        {
            _panelPurchaseOrders.Visible = false;
            _panelCreatePO.Visible = false;
            _panelApprovePO.Visible = false;

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
                    _panelPurchaseOrders.Visible = true;
                    _panelPurchaseOrders.BringToFront();
                    break;
                case 1:
                    _panelCreatePO.Visible = true;
                    _panelCreatePO.BringToFront();
                    break;
                case 2:
                    _panelApprovePO.Visible = true;
                    _panelApprovePO.BringToFront();
                    LoadApproveData();
                    break;
            }

            _contentPanel.Invalidate();
        }

        private void SetupDataGridViews()
        {
            dgvPurchaseOrders.AutoGenerateColumns = false;
            dgvPurchaseOrders.Columns.Clear();
            dgvPurchaseOrders.Columns.Add("POID", "PO ID");
            dgvPurchaseOrders.Columns.Add("Supplier", "Supplier");
            dgvPurchaseOrders.Columns.Add("Total", "Total Amount");
            dgvPurchaseOrders.Columns.Add("Status", "Status");
            dgvPurchaseOrders.Columns.Add("Date", "Created Date");

            dgvPOItems.AutoGenerateColumns = false;
            dgvPOItems.Columns.Clear();
            dgvPOItems.Columns.Add("ProductID", "Product ID");
            dgvPOItems.Columns.Add("ProductName", "Product Name");
            dgvPOItems.Columns.Add("Quantity", "Quantity");
            dgvPOItems.Columns.Add("UnitPrice", "Unit Price");
            dgvPOItems.Columns.Add("LineTotal", "Line Total");

            dgvPOItems.AllowUserToAddRows = true;
            dgvPOItems.CellEndEdit += DgvPOItems_CellEndEdit;
        }

        private void BindEvents()
        {
            btnRefreshPO.Click += BtnRefreshPO_Click;
            btnApprovePO.Click += BtnApprovePO_Click;
            btnCancelPO.Click += BtnCancelPO_Click;
            btnPrintPO.Click += BtnPrintPO_Click;
            btnCreatePO.Click += BtnCreatePO_Click;
            btnAddItem.Click += BtnAddItem_Click;
            btnRemoveItem.Click += BtnRemoveItem_Click;
            cmbSupplier.SelectedIndexChanged += CmbSupplier_SelectedIndexChanged;
        }

        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            LoadPurchaseOrders();
            GenerateNewPOID();
            LoadSamplePOItems();
            ApplyModernStyling();
        }

        private void ApplyModernStyling()
        {
            this.BackColor = _backgroundColor;
            this.Font = new Font("Segoe UI", 10F);
            StyleAllControls(this);
        }

        private void StyleAllControls(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is Button btn)
                {
                    StyleButton(btn);
                }
                else if (control is TextBox txt)
                {
                    StyleTextBox(txt);
                }
                else if (control is ComboBox cmb)
                {
                    StyleComboBox(cmb);
                }
                else if (control is DataGridView dgv)
                {
                    StyleDataGridView(dgv);
                }
                else if (control is GroupBox grp)
                {
                    StyleGroupBox(grp);
                }
                else if (control is Panel pnl && pnl != _sidebarPanel && pnl != _contentPanel)
                {
                    StylePanel(pnl);
                }
                else if (control is Label lbl)
                {
                    StyleLabel(lbl);
                }

                if (control.Controls.Count > 0)
                {
                    StyleAllControls(control);
                }
            }
        }

        private void StyleButton(Button btn)
        {
            if (btn.Parent == _sidebarPanel) return;

            btn.Cursor = Cursors.Hand;

            if (btn.BackColor == SystemColors.Control || btn.BackColor == Color.Empty || btn.BackColor == Color.Gold || btn.BackColor == Color.Gainsboro)
            {
                btn.BackColor = _primaryColor;
                btn.ForeColor = Color.White;
            }

            Color originalBackColor = btn.BackColor;
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = ControlPaint.Light(originalBackColor, 0.1f);
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = originalBackColor;
            };
        }

        private void StyleTextBox(TextBox txt)
        {
            txt.Font = new Font("Segoe UI", 10F);
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = Color.FromArgb(245, 240, 255);
        }

        private void StyleComboBox(ComboBox cmb)
        {
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.Font = new Font("Segoe UI", 10F);
            cmb.BackColor = Color.FromArgb(245, 240, 255);
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(230, 220, 240);
            dgv.Font = new Font("Segoe UI", 9F);
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = _primaryColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.DefaultCellStyle.SelectionBackColor = _secondaryColor;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 245, 255);
        }

        private void StyleGroupBox(GroupBox grp)
        {
            grp.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grp.ForeColor = _primaryColor;
            grp.Paint += (s, e) =>
            {
                GroupBox groupBox = s as GroupBox;
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(0, 0, groupBox.Width, groupBox.Height);
                int radius = 12;

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                    path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                    path.CloseFigure();

                    using (Brush brush = new SolidBrush(Color.White))
                    {
                        g.FillPath(brush, path);
                    }

                    using (Pen pen = new Pen(Color.FromArgb(220, 210, 235), 1))
                    {
                        g.DrawPath(pen, path);
                    }
                }

                SizeF textSize = g.MeasureString(groupBox.Text, groupBox.Font);
                Rectangle textRect = new Rectangle(15, 0, (int)textSize.Width + 10, (int)textSize.Height);

                using (Brush textBrush = new SolidBrush(_primaryColor))
                {
                    g.FillRectangle(new SolidBrush(Color.White), textRect);
                    g.DrawString(groupBox.Text, groupBox.Font, textBrush, 15, 0);
                }
            };
        }

        private void StylePanel(Panel pnl)
        {
            pnl.BackColor = Color.White;
        }

        private void StyleLabel(Label lbl)
        {
            lbl.Font = new Font("Segoe UI", 10F);
        }

        private void LoadPurchaseOrders()
        {
            try
            {
                DataTable dt = _controller.GetPurchaseOrders();
                dgvPurchaseOrders.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    dgvPurchaseOrders.Rows.Add(
                        row["PO ID"],
                        row["Supplier Name"],
                        Convert.ToDecimal(row["Total Amount"]).ToString("C2"),
                        row["Status"],
                        Convert.ToDateTime(row["Created Date"]).ToString("yyyy-MM-dd")
                    );
                }
                UpdateStatus("Purchase orders loaded successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading purchase orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadApproveData()
        {
            try
            {
                DataGridView dgv = _panelApprovePO.Controls.Find("dgvApprove", true)[0] as DataGridView;
                if (dgv == null) return;

                dgv.AutoGenerateColumns = false;
                dgv.Columns.Clear();
                dgv.Columns.Add("POID", "PO ID");
                dgv.Columns.Add("Supplier", "Supplier");
                dgv.Columns.Add("Total", "Total Amount");
                dgv.Columns.Add("Status", "Status");

                DataTable dt = _controller.GetPurchaseOrders();
                dgv.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    string status = row["Status"].ToString();
                    if (status.Contains("Pending"))
                    {
                        dgv.Rows.Add(
                            row["PO ID"],
                            row["Supplier Name"],
                            Convert.ToDecimal(row["Total Amount"]).ToString("C2"),
                            status
                        );
                    }
                }
                StyleDataGridView(dgv);
                UpdateStatus("Approval list loaded");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading approval data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateNewPOID()
        {
            string newPOID = "PO" + DateTime.Now.ToString("yyyyMMddHHmmss");
            txtPOID.Text = newPOID;
        }

        private void LoadSamplePOItems()
        {
            dgvPOItems.Rows.Add("P001", "Luxury Sofa", 2, 5000.00, 10000.00);
            dgvPOItems.Rows.Add("P002", "Dining Table", 1, 5000.00, 5000.00);
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvPOItems.Rows)
            {
                if (row.Cells["LineTotal"].Value != null && decimal.TryParse(row.Cells["LineTotal"].Value.ToString(), out decimal lineTotal))
                {
                    total += lineTotal;
                }
            }
            txtTotalAmount.Text = total.ToString("F2");
        }

        private void UpdateStatus(string message)
        {
            if (toolStripStatusLabel1 != null)
            {
                toolStripStatusLabel1.Text = message;
            }
        }

        private void BtnRefreshPO_Click(object sender, EventArgs e)
        {
            LoadPurchaseOrders();
        }

        private void BtnApprovePO_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a purchase order to approve", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string poID = dgvPurchaseOrders.SelectedRows[0].Cells["POID"].Value.ToString();
            DialogResult result = MessageBox.Show("Approve Purchase Order " + poID + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.ApprovePurchaseOrder(poID, "");
                    LoadPurchaseOrders();
                    UpdateStatus("Purchase Order " + poID + " approved");
                    MessageBox.Show("Purchase Order " + poID + " has been approved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error approving PO: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnCancelPO_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a purchase order to cancel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string poID = dgvPurchaseOrders.SelectedRows[0].Cells["POID"].Value.ToString();
            DialogResult result = MessageBox.Show("Cancel Purchase Order " + poID + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.CancelPurchaseOrder(poID);
                    LoadPurchaseOrders();
                    UpdateStatus("Purchase Order " + poID + " cancelled");
                    MessageBox.Show("Purchase Order " + poID + " has been cancelled", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error cancelling PO: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnPrintPO_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a purchase order to print", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string poID = dgvPurchaseOrders.SelectedRows[0].Cells["POID"].Value.ToString();
            try
            {
                var printDoc = _controller.GeneratePurchaseOrderPDF(poID);
                PrintPreviewDialog preview = new PrintPreviewDialog();
                preview.Document = printDoc;
                preview.ShowDialog();
                UpdateStatus("Print preview for PO " + poID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error printing PO: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCreatePO_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbSupplier.Text))
            {
                MessageBox.Show("Please select a supplier", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvPOItems.Rows.Count == 0)
            {
                MessageBox.Show("Please add at least one item", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable items = new DataTable();
                items.Columns.Add("Product ID");
                items.Columns.Add("Product Name");
                items.Columns.Add("Quantity", typeof(int));
                items.Columns.Add("Unit Price", typeof(decimal));
                items.Columns.Add("Line Total", typeof(decimal));

                foreach (DataGridViewRow row in dgvPOItems.Rows)
                {
                    if (row.IsNewRow) continue;
                    items.Rows.Add(
                        row.Cells["ProductID"].Value?.ToString(),
                        row.Cells["ProductName"].Value?.ToString(),
                        Convert.ToInt32(row.Cells["Quantity"].Value ?? 0),
                        Convert.ToDecimal(row.Cells["UnitPrice"].Value ?? 0),
                        Convert.ToDecimal(row.Cells["LineTotal"].Value ?? 0)
                    );
                }

                string supplierID = cmbSupplier.Text.Split('-')[0].Trim();
                _controller.CreatePurchaseOrder(
                    txtPOID.Text,
                    supplierID,
                    txtSupplierName.Text,
                    items,
                    "CurrentUser",
                    txtNotes.Text
                );

                MessageBox.Show("Purchase Order " + txtPOID.Text + " created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GenerateNewPOID();
                dgvPOItems.Rows.Clear();
                txtNotes.Clear();
                LoadPurchaseOrders();
                ShowPanel(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating PO: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            dgvPOItems.Rows.Add();
        }

        private void BtnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvPOItems.SelectedRows.Count > 0 && !dgvPOItems.SelectedRows[0].IsNewRow)
            {
                dgvPOItems.Rows.Remove(dgvPOItems.SelectedRows[0]);
                CalculateTotal();
            }
        }

        private void CmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSupplier.SelectedItem != null)
            {
                string supplierText = cmbSupplier.SelectedItem.ToString();
                string[] parts = supplierText.Split('-');
                if (parts.Length > 1)
                {
                    txtSupplierName.Text = parts[1].Trim();
                }
            }
        }

        private void DgvPOItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                DataGridViewRow row = dgvPOItems.Rows[e.RowIndex];
                if (int.TryParse(row.Cells["Quantity"].Value?.ToString(), out int qty) &&
                    decimal.TryParse(row.Cells["UnitPrice"].Value?.ToString(), out decimal price))
                {
                    row.Cells["LineTotal"].Value = (qty * price).ToString("F2");
                    CalculateTotal();
                }
            }
        }

        private void BtnApproveSelected_Click(object sender, EventArgs e)
        {
            DataGridView dgv = _panelApprovePO.Controls.Find("dgvApprove", true)[0] as DataGridView;
            if (dgv?.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a purchase order to approve", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string poID = dgv.SelectedRows[0].Cells["POID"].Value.ToString();
            DialogResult result = MessageBox.Show("Approve Purchase Order " + poID + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.ApprovePurchaseOrder(poID, "");
                    LoadApproveData();
                    LoadPurchaseOrders();
                    UpdateStatus("Purchase Order " + poID + " approved");
                    MessageBox.Show("Purchase Order " + poID + " has been approved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error approving PO: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnRejectSelected_Click(object sender, EventArgs e)
        {
            DataGridView dgv = _panelApprovePO.Controls.Find("dgvApprove", true)[0] as DataGridView;
            if (dgv?.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a purchase order to reject", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string poID = dgv.SelectedRows[0].Cells["POID"].Value.ToString();
            DialogResult result = MessageBox.Show("Reject Purchase Order " + poID + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.CancelPurchaseOrder(poID);
                    LoadApproveData();
                    LoadPurchaseOrders();
                    UpdateStatus("Purchase Order " + poID + " rejected");
                    MessageBox.Show("Purchase Order " + poID + " has been rejected", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error rejecting PO: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
