using Group2Project.Controllers;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Group2Project.Views.Sub05_Inventory
{
    public partial class InventoryForm : Form
    {
        private InventoryController _controller;
        private System.Windows.Forms.Timer _statusTimer;
        private string _currentLocation = "All";

        // New UI color scheme (purple/magenta theme for purchase module)
        private readonly Color _primaryColor = Color.FromArgb(147, 51, 234);
        private readonly Color _secondaryColor = Color.FromArgb(168, 85, 247);
        private readonly Color _accentColor = Color.FromArgb(196, 115, 255);
        private readonly Color _backgroundColor = Color.FromArgb(248, 245, 255);
        private readonly Color _cardColor = Color.White;
        private readonly Color _textColor = Color.FromArgb(51, 51, 51);
        private readonly Color _lightTextColor = Color.FromArgb(100, 100, 100);
        private readonly Color _sidebarColor = Color.FromArgb(45, 27, 78);

        // Sidebar controls
        private Panel _sidebarPanel;
        private Panel _contentPanel;
        private Label _titleLabel;
        private Button _currentNavButton;
        
        // Collapsible groups
        private bool _inventoryGroupExpanded = true;
        private System.Collections.Generic.List<Control> _inventoryControls = new System.Collections.Generic.List<Control>();

        // Content panels
        private Panel _panelStockStatus;
        private Panel _panelCreateOrder;
        private Panel _panelManageOrder;
        private Panel _panelQuotation;
        private Panel _panelMultiLocation;
        private Panel _panelRestock;
        private Panel _panelStockMovements;

        // Quotation controls
        private DataGridView dgvQuotations;
        private Button btnPrintQuotation;
        private Button btnMarkPicked;
        private Button btnRefreshQuotes;

        // Multi-Location inventory controls
        private DataGridView dgvLocationStock;
        private ComboBox cmbLocation;
        private Button btnRefreshLocation, btnCheckLowStock, btnRecordOutward;
        private TextBox txtOutwardItemId, txtOutwardQty, txtOutwardRef, txtOutwardNotes;

        // Restock requests controls
        private DataGridView dgvRestockRequests;
        private ComboBox cmbRestockLocation;
        private Button btnRefreshRestock, btnApproveRestock, btnRejectRestock;

        // Stock movements controls
        private DataGridView dgvStockMovements;
        private ComboBox cmbMovementProduct;
        private Button btnRefreshMovements;

        public InventoryForm() : this(0) { }

        public InventoryForm(int defaultTabIndex)
        {
            InitializeComponent();
            _controller = new InventoryController();

            // Setup content panels FIRST (move controls before removing TabControl)
            SetupContentPanels();

            // Remove the original TabControl
            if (tcInventoryManager != null)
            {
                this.Controls.Remove(tcInventoryManager);
                tcInventoryManager.Dispose();
            }

            // Setup sidebar navigation
            SetupSidebar();

            // Apply modern styling
            ApplyModernStyling();

            // Show default panel
            ShowPanel(defaultTabIndex);

            this.Load += (s, e) =>
            {
                InventoryForm_Load(s, e);
            };

            if (btnRefreshStock != null) btnRefreshStock.Click += btnRefreshStock_Click;
            if (btnRefreshProcList != null) btnRefreshProcList.Click += btnRefreshProcList_Click;
            if (btnRecordInward != null) btnRecordInward.Click += btnRecordInward_Click;
            if (btnSubmitProcurement != null) btnSubmitProcurement.Click += btnSubmitProcurement_Click;
            if (btnCancelProcurement != null) btnCancelProcurement.Click += btnCancelProcurement_Click;
            if (btnSearchProc != null) btnSearchProc.Click += btnSearchProc_Click;
            if (btnEditProcurement != null) btnEditProcurement.Click += btnEditProcurement_Click;
            if (btnUpdateProcStatus != null) btnUpdateProcStatus.Click += btnUpdateProcStatus_Click;

            _statusTimer = new System.Windows.Forms.Timer();
            _statusTimer.Interval = 3000;
            _statusTimer.Tick += (s, e) =>
            {
                if (lblStatus != null) lblStatus.Text = "";
                _statusTimer.Stop();
            };

            SetupQuotationPanel();
            SetupMultiLocationPanel();
            SetupRestockPanel();
            SetupStockMovementsPanel();
        }

        private void SetupSidebar()
        {
            // Sidebar panel
            _sidebarPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 260,
                BackColor = _sidebarColor
            };

            // Sidebar header
            Panel sidebarHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.FromArgb(30, 15, 60)
            };

            Label sidebarTitle = new Label
            {
                Text = "📦 INVENTORY\nMANAGEMENT",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(25, 25),
                AutoSize = true
            };

            sidebarHeader.Controls.Add(sidebarTitle);
            _sidebarPanel.Controls.Add(sidebarHeader);

            // Create group labels and navigation buttons
            int yPosition = 100;
            
            // Inventory Group
            CreateCollapsibleGroup("📦 INVENTORY", true, ref yPosition, _inventoryControls);
            CreateNavButton("Stock Status", 0, ref yPosition, _inventoryControls);
            CreateNavButton("Procurement Orders", 1, ref yPosition, _inventoryControls);
            CreateNavButton("Manage Orders", 2, ref yPosition, _inventoryControls);
            CreateNavButton("Quotations", 3, ref yPosition, _inventoryControls);
            CreateNavButton("Multi-Location", 4, ref yPosition, _inventoryControls);
            CreateNavButton("Restock Requests", 5, ref yPosition, _inventoryControls);
            CreateNavButton("Movements Ledger", 6, ref yPosition, _inventoryControls);

            this.Controls.Add(_sidebarPanel);
        }



        private void CreateCollapsibleGroup(string text, bool isExpanded, ref int yPosition, System.Collections.Generic.List<Control> controlList)
        {
            Button groupButton = new Button
            {
                Text = text,
                Tag = controlList,
                Location = new Point(15, yPosition),
                Size = new Size(230, 45),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.FromArgb(220, 220, 220),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(35, 0, 0, 0),
                Cursor = Cursors.Hand
            };

            groupButton.FlatAppearance.BorderSize = 0;
            groupButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 30, 85);
            groupButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 40, 95);
            groupButton.Paint += (s, e) =>
            {
                Button btn = s as Button;
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                
                // Draw arrow only - let button draw text itself
                string arrowText;
                arrowText = _inventoryGroupExpanded ? "▼" : "▶";
                Font arrowFont = new Font("Segoe UI", 10, FontStyle.Bold);
                Brush arrowBrush = new SolidBrush(Color.FromArgb(220, 220, 220));
                g.DrawString(arrowText, arrowFont, arrowBrush, 8, 14);
            };
            
            groupButton.Click += (s, e) =>
            {
                Button btn = s as Button;
                System.Collections.Generic.List<Control> controls = btn.Tag as System.Collections.Generic.List<Control>;
                
                _inventoryGroupExpanded = !_inventoryGroupExpanded;
                ToggleControlsVisibility(controls, _inventoryGroupExpanded);
                
                _sidebarPanel.Invalidate();
            };

            _sidebarPanel.Controls.Add(groupButton);
            yPosition += 50;
        }

        private void ToggleControlsVisibility(System.Collections.Generic.List<Control> controls, bool isVisible)
        {
            foreach (Control ctrl in controls)
            {
                ctrl.Visible = isVisible;
            }
        }

        private void CreateNavButton(string text, int index, ref int yPosition, System.Collections.Generic.List<Control> controlList)
        {
            Button btn = new Button
            {
                Text = text,
                Tag = index,
                Location = new Point(25, yPosition),
                Size = new Size(205, 50),
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

            // Set initial visibility based on group expansion state
            btn.Visible = _inventoryGroupExpanded;

            _sidebarPanel.Controls.Add(btn);
            controlList.Add(btn);
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
            // Content panel
            _contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 240, 255)
            };

            // Create a beautiful title area
            Panel titlePanel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(2000, 90),
                BackColor = _primaryColor,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            Label titleLabel = new Label
            {
                Text = "� Inventory Management",
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(35, 25),
                AutoSize = true
            };

            Label subtitleLabel = new Label
            {
                Text = "Manage your inventory and procurement",
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                ForeColor = Color.FromArgb(200, 200, 255),
                Location = new Point(35, 55),
                AutoSize = true
            };

            titlePanel.Controls.Add(titleLabel);
            titlePanel.Controls.Add(subtitleLabel);
            _contentPanel.Controls.Add(titlePanel);

            // Stock Status panel - add padding at top to make room for title
            _panelStockStatus = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 240, 255),
                Padding = new Padding(35, 110, 35, 35)
            };
            MoveControlsToPanel(tbStockStatus, _panelStockStatus);

            // Create Order panel
            _panelCreateOrder = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 240, 255),
                Padding = new Padding(35, 110, 35, 35)
            };
            MoveControlsToPanel(tbCreateOrder, _panelCreateOrder);

            // Manage Orders panel
            _panelManageOrder = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 240, 255),
                Padding = new Padding(35, 110, 35, 35)
            };
            MoveControlsToPanel(tbManageOrder, _panelManageOrder);

            // Initialize other panels
            _panelQuotation = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(245, 240, 255), Padding = new Padding(35, 110, 35, 35) };
            _panelMultiLocation = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(245, 240, 255), Padding = new Padding(35, 110, 35, 35) };
            _panelRestock = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(245, 240, 255), Padding = new Padding(35, 110, 35, 35) };
            _panelStockMovements = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(245, 240, 255), Padding = new Padding(35, 110, 35, 35) };

            // Add all panels to content panel
            _contentPanel.Controls.Add(_panelStockStatus);
            _contentPanel.Controls.Add(_panelCreateOrder);
            _contentPanel.Controls.Add(_panelManageOrder);
            _contentPanel.Controls.Add(_panelQuotation);
            _contentPanel.Controls.Add(_panelMultiLocation);
            _contentPanel.Controls.Add(_panelRestock);
            _contentPanel.Controls.Add(_panelStockMovements);

            // Bring title to front
            titlePanel.BringToFront();

            // Add content panel to form
            this.Controls.Add(_contentPanel);
            _contentPanel.BringToFront();
        }

        private void MoveControlsToPanel(TabPage fromPage, Panel toPanel)
        {
            if (fromPage == null || toPanel == null) return;

            Control[] controls = new Control[fromPage.Controls.Count];
            fromPage.Controls.CopyTo(controls, 0);

            foreach (Control ctrl in controls)
            {
                fromPage.Controls.Remove(ctrl);
                toPanel.Controls.Add(ctrl);
                
                // Set anchor properties to make controls resize with the panel
                ctrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                
                // Special handling for DataGridView - make it fill most of the space
                if (ctrl is DataGridView dgv)
                {
                    dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                }
            }
        }
        
        private void ShowPanel(int index)
        {
            // Hide all panels first
            _panelStockStatus.Visible = false;
            _panelCreateOrder.Visible = false;
            _panelManageOrder.Visible = false;
            _panelQuotation.Visible = false;
            _panelMultiLocation.Visible = false;
            _panelRestock.Visible = false;
            _panelStockMovements.Visible = false;

            // Reset all nav buttons
            foreach (Control ctrl in _sidebarPanel.Controls)
            {
                if (ctrl is Button btn && btn.Tag is int)
                {
                    btn.BackColor = Color.Transparent;
                    btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                    btn.Padding = new Padding(25, 0, 0, 0);
                }
            }

            // Highlight current button with left indicator
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

            // Show the selected panel
            switch (index)
            {
                case 0:
                    _panelStockStatus.Visible = true;
                    _panelStockStatus.BringToFront();
                    break;
                case 1:
                    _panelCreateOrder.Visible = true;
                    _panelCreateOrder.BringToFront();
                    break;
                case 2:
                    _panelManageOrder.Visible = true;
                    _panelManageOrder.BringToFront();
                    break;
                case 3:
                    _panelQuotation.Visible = true;
                    _panelQuotation.BringToFront();
                    break;
                case 4:
                    _panelMultiLocation.Visible = true;
                    _panelMultiLocation.BringToFront();
                    break;
                case 5:
                    _panelRestock.Visible = true;
                    _panelRestock.BringToFront();
                    break;
                case 6:
                    _panelStockMovements.Visible = true;
                    _panelStockMovements.BringToFront();
                    break;
            }
            
            _contentPanel.Invalidate();
        }

        private void ApplyModernStyling()
        {
            // Form styling
            this.BackColor = _backgroundColor;
            this.Font = new Font("Segoe UI", 10F);

            // Style all controls
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

                // Recursively style child controls
                if (control.Controls.Count > 0)
                {
                    StyleAllControls(control);
                }
            }
        }

        private void StyleButton(Button btn)
        {
            if (btn.Parent == _sidebarPanel) return;

            // Keep original button style to ensure text shows up
            btn.Cursor = Cursors.Hand;
            
            // Only change colors, don't change other style properties
            // Set default colors if not already set
            if (btn.BackColor == SystemColors.Control || btn.BackColor == Color.Empty || btn.BackColor == Color.Gold || btn.BackColor == Color.Gainsboro)
            {
                btn.BackColor = _primaryColor;
                btn.ForeColor = Color.White;
            }
            else if (btn.BackColor == Color.Salmon)
            {
                btn.BackColor = Color.FromArgb(239, 68, 68);
                btn.ForeColor = Color.White;
            }
            else if (btn.BackColor == Color.LightGreen)
            {
                btn.BackColor = Color.FromArgb(34, 197, 94);
                btn.ForeColor = Color.White;
            }
            else if (btn.BackColor == Color.LightSkyBlue)
            {
                btn.BackColor = _secondaryColor;
                btn.ForeColor = Color.White;
            }
            else if (btn.BackColor == Color.Orange)
            {
                btn.BackColor = Color.FromArgb(245, 158, 11);
                btn.ForeColor = Color.White;
            }
            else if (btn.BackColor == Color.LightCoral)
            {
                btn.BackColor = Color.FromArgb(239, 68, 68);
                btn.ForeColor = Color.White;
            }

            // Add hover effect
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
            txt.ForeColor = _textColor;
        }

        private void StyleComboBox(ComboBox cmb)
        {
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.Font = new Font("Segoe UI", 10F);
            cmb.BackColor = Color.FromArgb(245, 240, 255);
            cmb.ForeColor = _textColor;
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = _cardColor;
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
            dgv.DefaultCellStyle.ForeColor = _textColor;
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

                // Draw rounded background
                Rectangle rect = new Rectangle(0, 0, groupBox.Width, groupBox.Height);
                int radius = 12;

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                    path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                    path.CloseFigure();

                    using (Brush brush = new SolidBrush(_cardColor))
                    {
                        g.FillPath(brush, path);
                    }

                    // Draw subtle border
                    using (Pen pen = new Pen(Color.FromArgb(220, 210, 235), 1))
                    {
                        g.DrawPath(pen, path);
                    }
                }

                // Draw text
                SizeF textSize = g.MeasureString(groupBox.Text, groupBox.Font);
                Rectangle textRect = new Rectangle(15, 0, (int)textSize.Width + 10, (int)textSize.Height);

                using (Brush textBrush = new SolidBrush(_primaryColor))
                {
                    g.FillRectangle(new SolidBrush(_cardColor), textRect);
                    g.DrawString(groupBox.Text, groupBox.Font, textBrush, 15, 0);
                }
            };
        }

        private void StylePanel(Panel pnl)
        {
            pnl.BackColor = _cardColor;
        }

        private void StyleLabel(Label lbl)
        {
            lbl.Font = new Font("Segoe UI", 10F);
            lbl.ForeColor = _textColor;
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

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            LoadInventoryData();
            LoadProcurementData();
            LoadQuotations();
            LoadLocationData();
            LoadRestockRequests();
            LoadStockMovements();
        }

        private void SetupQuotationPanel()
        {
            Label lblTitle = new Label { Text = "Warehouse Quotation & Dispatch Proofs", Font = new Font("Segoe UI", 16, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true, ForeColor = _textColor };
            Label lblDesc = new Label { Text = "Generate official quotations for walk-in transactions or delivery notes for logistics verification.", Location = new Point(23, 60), AutoSize = true, ForeColor = _lightTextColor };

            dgvQuotations = new DataGridView { Location = new Point(25, 100), Size = new Size(600, 380), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, BackgroundColor = _cardColor, AllowUserToAddRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right };

            btnRefreshQuotes = new Button { Text = "Refresh List", Location = new Point(650, 100), Size = new Size(210, 40), FlatStyle = FlatStyle.Flat, BackColor = _primaryColor, ForeColor = Color.White, Cursor = Cursors.Hand, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            btnRefreshQuotes.Click += (s, e) => LoadQuotations();

            btnPrintQuotation = new Button { Text = "Print Quotation / Delivery Note", Location = new Point(650, 160), Size = new Size(210, 60), FlatStyle = FlatStyle.Flat, BackColor = _secondaryColor, ForeColor = Color.White, Cursor = Cursors.Hand, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            btnPrintQuotation.Click += BtnPrintQuotation_Click;

            btnMarkPicked = new Button { Text = "Verify Stock & Send to Logistics", Location = new Point(650, 240), Size = new Size(210, 60), FlatStyle = FlatStyle.Flat, BackColor = Color.FromArgb(34, 197, 94), ForeColor = Color.White, Cursor = Cursors.Hand, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            btnMarkPicked.Click += BtnMarkPicked_Click;

            _panelQuotation.Controls.Add(lblTitle);
            _panelQuotation.Controls.Add(lblDesc);
            _panelQuotation.Controls.Add(dgvQuotations);
            _panelQuotation.Controls.Add(btnRefreshQuotes);
            _panelQuotation.Controls.Add(btnPrintQuotation);
            _panelQuotation.Controls.Add(btnMarkPicked);

            StyleAllControls(_panelQuotation);
        }

        private void LoadQuotations()
        {
            try
            {
                dgvQuotations.DataSource = _controller.GetPendingOrdersForQuotation();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BtnPrintQuotation_Click(object sender, EventArgs e)
        {
            if (dgvQuotations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to generate the quotation.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string orderId = dgvQuotations.SelectedRows[0].Cells["Order Ref."].Value.ToString();
            string customer = dgvQuotations.SelectedRows[0].Cells["Customer"].Value.ToString();
            string date = dgvQuotations.SelectedRows[0].Cells["Date"].Value.ToString();

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                Graphics g = ev.Graphics;
                Font titleFont = new Font("Arial", 22, FontStyle.Bold);
                Font subFont = new Font("Arial", 14, FontStyle.Bold);
                Font regularFont = new Font("Arial", 12);
                Brush brush = Brushes.Black;
                int y = 50;

                g.DrawString("PREMIUM LIVING FURNITURE", titleFont, brush, 50, y);
                y += 40;
                g.DrawString("OFFICIAL QUOTATION & DELIVERY NOTE", subFont, brush, 50, y);
                y += 50;

                g.DrawString($"Order / Quote Ref: {orderId}", regularFont, brush, 50, y);
                y += 30;
                g.DrawString($"Customer Name: {customer}", regularFont, brush, 50, y);
                y += 30;
                g.DrawString($"Date Issued: {DateTime.Now.ToString("yyyy-MM-dd HH:mm")}", regularFont, brush, 50, y);
                y += 40;

                g.DrawString("-------------------------------------------------------------------------", regularFont, brush, 50, y);
                y += 30;
                g.DrawString("Product Name\t\t\t\tQty\tUnit Price", subFont, brush, 50, y);
                y += 30;
                g.DrawString("-------------------------------------------------------------------------", regularFont, brush, 50, y);
                y += 30;

                DataTable items = _controller.GetOrderItemsForQuotation(orderId);
                decimal grandTotal = 0;

                if (items.Rows.Count > 0)
                {
                    foreach (DataRow row in items.Rows)
                    {
                        string name = row["inv_product_name"].ToString();
                        if (name.Length > 25) name = name.Substring(0, 25) + "...";
                        int qty = Convert.ToInt32(row["ot_quantity"]);
                        decimal price = Convert.ToDecimal(row["ot_unit_price"]);
                        decimal subtotal = qty * price;
                        grandTotal += subtotal;

                        g.DrawString($"{name}", regularFont, brush, 50, y);
                        g.DrawString($"{qty}", regularFont, brush, 400, y);
                        g.DrawString($"${price:0.00}", regularFont, brush, 500, y);
                        y += 30;
                    }
                }
                else
                {
                    g.DrawString("* Custom Specification Order / No Standard Items *", regularFont, Brushes.Gray, 50, y);
                    y += 30;
                }

                y += 20;
                g.DrawString("-------------------------------------------------------------------------", regularFont, brush, 50, y);
                y += 30;
                g.DrawString($"GRAND TOTAL: ${grandTotal:0.00}", subFont, brush, 400, y);
                y += 60;

                g.DrawString("Terms & Conditions:", subFont, brush, 50, y);
                y += 30;
                g.DrawString("1. This document serves as a quotation and inventory dispatch proof.", regularFont, brush, 50, y);
                y += 25;
                g.DrawString("2. For walk-in customers, this validates on-site goods receipt.", regularFont, brush, 50, y);
                y += 25;
                g.DrawString("3. Any stock discrepancies must be reported within 24 hours.", regularFont, brush, 50, y);
                y += 80;

                g.DrawString("Warehouse Authorized Signature: _______________________", regularFont, brush, 50, y);
                y += 50;
                g.DrawString("Customer / Driver Signature: __________________________", regularFont, brush, 50, y);
            };

            PrintPreviewDialog preview = new PrintPreviewDialog { Document = pd, Width = 850, Height = 1000 };
            preview.ShowDialog();
            ShowSuccessStatus("Quotation printed successfully!");
        }

        private void BtnMarkPicked_Click(object sender, EventArgs e)
        {
            if (dgvQuotations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to verify stock.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string orderId = dgvQuotations.SelectedRows[0].Cells["Order Ref."].Value.ToString();

            DialogResult res = MessageBox.Show($"Have you verified the physical stock for Order {orderId}?\n\nClicking 'Yes' will mark it as Ready and push it directly to Logistics for delivery scheduling.", "Verify Stock & Dispatch", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                try
                {
                    _controller.MarkOrderAsPicked(orderId);
                    LoadQuotations();
                    ShowSuccessStatus($"Order {orderId} is packed and sent to Logistics!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefreshStock_Click(object sender, EventArgs e) { LoadInventoryData(); ShowSuccessStatus("Stock list refreshed."); }

        private void LoadInventoryData()
        {
            try { if (dgvStockList != null) { dgvStockList.DataSource = _controller.GetStockList(); dgvStockList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; } }
            catch (Exception ex) { MessageBox.Show("Error loading stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnRecordInward_Click(object sender, EventArgs e)
        {
            string id = txtInwardItemID.Text.Trim(); string qtyStr = textBtxtInwardQtyox2.Text.Trim();
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(qtyStr)) { MessageBox.Show("Please fill in both Item ID and Quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!int.TryParse(qtyStr, out int qty) || qty <= 0) { MessageBox.Show("Quantity must be a valid positive number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            try { _controller.RecordInward(id, qty); txtInwardItemID.Clear(); textBtxtInwardQtyox2.Clear(); LoadInventoryData(); ShowSuccessStatus($"Stock for Item {id} increased by {qty}!"); }
            catch (Exception ex) { MessageBox.Show("Failed to record inward: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnRefreshProcList_Click(object sender, EventArgs e) { LoadProcurementData(); txtSearchProcID.Clear(); ShowSuccessStatus("Procurement list refreshed."); }

        private void LoadProcurementData()
        {
            try { if (dgvProcurementList != null) { dgvProcurementList.DataSource = _controller.GetProcurementList(); dgvProcurementList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; } }
            catch (Exception ex) { MessageBox.Show("Error loading procurement data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnSubmitProcurement_Click(object sender, EventArgs e)
        {
            string supplier = cmbSupplier.Text; string item = cmbMaterialItem.Text; string qtyStr = txtProcureQty.Text.Trim(); string costStr = txtProcureCost.Text.Trim(); string notes = txtProcureNotes.Text.Trim();

            if (string.IsNullOrWhiteSpace(supplier) || string.IsNullOrWhiteSpace(item)) { MessageBox.Show("Please select a Supplier and a Material Item.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!int.TryParse(qtyStr, out int qty) || qty <= 0) { MessageBox.Show("Quantity must be a valid positive number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!decimal.TryParse(costStr, out decimal cost) || cost < 0) { MessageBox.Show("Estimated Cost must be a valid positive number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            try { _controller.CreateProcurement(supplier, item, qty, cost, notes); cmbSupplier.SelectedIndex = -1; cmbMaterialItem.SelectedIndex = -1; txtProcureQty.Clear(); txtProcureCost.Clear(); txtProcureNotes.Clear(); LoadProcurementData(); ShowSuccessStatus("Procurement order created successfully!"); }
            catch (Exception ex) { MessageBox.Show("Failed to create procurement order: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCancelProcurement_Click(object sender, EventArgs e)
        {
            if (dgvProcurementList.SelectedRows.Count == 0) { MessageBox.Show("Please select a procurement order to cancel.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            string procId = dgvProcurementList.SelectedRows[0].Cells["Proc. ID"].Value.ToString();
            string status = dgvProcurementList.SelectedRows[0].Cells["Status"].Value.ToString();

            if (status == "Cancelled") { MessageBox.Show("This order is already cancelled!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            DialogResult result = MessageBox.Show($"Are you sure you want to cancel Procurement ID: {procId}?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try { _controller.CancelProcurementOrder(procId); LoadProcurementData(); ShowSuccessStatus($"Procurement order {procId} cancelled."); }
                catch (Exception ex) { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnSearchProc_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchProcID.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword)) { LoadProcurementData(); return; }

            try { if (dgvProcurementList != null) { dgvProcurementList.DataSource = _controller.SearchProcurement(keyword); ShowSuccessStatus("Search completed."); } }
            catch (Exception ex) { MessageBox.Show("Search failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnEditProcurement_Click(object sender, EventArgs e)
        {
            if (dgvProcurementList.SelectedRows.Count == 0) { MessageBox.Show("Please select a procurement order to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            string procId = dgvProcurementList.SelectedRows[0].Cells["Proc. ID"].Value.ToString();
            string status = dgvProcurementList.SelectedRows[0].Cells["Status"].Value.ToString();

            if (status != "Pending") { MessageBox.Show($"This order is already '{status}' and cannot be modified. If there is an error, please cancel and create a new one.", "Modification Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            MessageBox.Show($"Entering Edit Mode for Procurement ID: {procId}.\n\n(System Note: Full modification interface is scheduled for next update.)", "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdateProcStatus_Click(object sender, EventArgs e)
        {
            if (dgvProcurementList.SelectedRows.Count == 0) { MessageBox.Show("Please select a procurement order to update its status.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            string procId = dgvProcurementList.SelectedRows[0].Cells["Proc. ID"].Value.ToString();
            string currentStatus = dgvProcurementList.SelectedRows[0].Cells["Status"].Value.ToString();
            string nextStatus = "";

            switch (currentStatus)
            {
                case "Pending": MessageBox.Show("This order is still 'Pending'. You must wait for the Finance Department to APPROVE it before ordering.", "Action Denied", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                case "Approved": nextStatus = "Ordered"; break;
                case "Ordered": nextStatus = "Received"; break;
                case "Received": MessageBox.Show("This order has already been 'Received' and is completed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                case "Cancelled":
                case "Rejected": MessageBox.Show($"This order is '{currentStatus}' and cannot proceed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                default: nextStatus = "Ordered"; break;
            }

            DialogResult result = MessageBox.Show($"Advance Procurement ID: {procId}\n\nFrom: [{currentStatus}]\nTo: [{nextStatus}]?", "Confirm Progress", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try { _controller.UpdateProcurementStatus(procId, nextStatus); LoadProcurementData(); ShowSuccessStatus($"Procurement {procId} advanced to '{nextStatus}'."); }
                catch (Exception ex) { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }

        private void SetupMultiLocationPanel()
        {
            Label lblLocTitle = new Label { Text = "Inventory by Location", Font = new Font("Segoe UI", 14, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true, ForeColor = _textColor };
            Label lblLocDesc = new Label { Text = "Switch between locations (e.g., Main Warehouse, Kowloon Bay Retail Shop) to manage stock.", Location = new Point(23, 50), AutoSize = true, ForeColor = _lightTextColor };

            Label lblLocation = new Label { Text = "Location:", Location = new Point(25, 80), AutoSize = true, ForeColor = _textColor };
            cmbLocation = new ComboBox { Location = new Point(100, 78), Size = new Size(200, 31), DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand, BackColor = Color.FromArgb(245, 240, 255), ForeColor = _textColor, Anchor = AnchorStyles.Top | AnchorStyles.Left };
            cmbLocation.SelectedIndexChanged += (s, e) => { _currentLocation = cmbLocation.SelectedItem.ToString(); LoadLocationData(); };

            btnRefreshLocation = new Button { Text = "Refresh Stock", Location = new Point(320, 75), Size = new Size(130, 34), FlatStyle = FlatStyle.Flat, BackColor = _primaryColor, ForeColor = Color.White, Cursor = Cursors.Hand, Anchor = AnchorStyles.Top | AnchorStyles.Left };
            btnRefreshLocation.Click += (s, e) => LoadLocationData();

            btnCheckLowStock = new Button { Text = "Check Low Stock & Auto Restock", Location = new Point(460, 75), Size = new Size(200, 34), FlatStyle = FlatStyle.Flat, BackColor = Color.FromArgb(245, 158, 11), ForeColor = Color.White, Cursor = Cursors.Hand, Anchor = AnchorStyles.Top | AnchorStyles.Left };
            btnCheckLowStock.Click += BtnCheckLowStock_Click;

            dgvLocationStock = new DataGridView { Location = new Point(25, 120), Size = new Size(650, 250), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, BackgroundColor = _cardColor, AllowUserToAddRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right };

            // Outward goods section
            GroupBox grpOutward = new GroupBox { Text = "Record Outbound (Outward)", Location = new Point(25, 380), Size = new Size(650, 130), TabIndex = 99, Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right };
            Label lblOutId = new Label { Text = "Item ID:", Location = new Point(20, 30), AutoSize = true, ForeColor = _textColor };
            txtOutwardItemId = new TextBox { Location = new Point(80, 27), Size = new Size(120, 30), BackColor = Color.FromArgb(245, 240, 255), ForeColor = _textColor, Anchor = AnchorStyles.Top | AnchorStyles.Left };
            Label lblOutQty = new Label { Text = "Quantity:", Location = new Point(220, 30), AutoSize = true, ForeColor = _textColor };
            txtOutwardQty = new TextBox { Location = new Point(280, 27), Size = new Size(100, 30), BackColor = Color.FromArgb(245, 240, 255), ForeColor = _textColor, Anchor = AnchorStyles.Top | AnchorStyles.Left };
            Label lblOutRef = new Label { Text = "Reference:", Location = new Point(20, 70), AutoSize = true, ForeColor = _textColor };
            txtOutwardRef = new TextBox { Location = new Point(80, 67), Size = new Size(120, 30), BackColor = Color.FromArgb(245, 240, 255), ForeColor = _textColor, Anchor = AnchorStyles.Top | AnchorStyles.Left };
            Label lblOutNotes = new Label { Text = "Notes:", Location = new Point(220, 70), AutoSize = true, ForeColor = _textColor };
            txtOutwardNotes = new TextBox { Location = new Point(280, 67), Size = new Size(100, 30), BackColor = Color.FromArgb(245, 240, 255), ForeColor = _textColor, Anchor = AnchorStyles.Top | AnchorStyles.Left };
            btnRecordOutward = new Button { Text = "Record Outward", Location = new Point(480, 90), Size = new Size(150, 34), FlatStyle = FlatStyle.Flat, BackColor = _primaryColor, ForeColor = Color.White, Cursor = Cursors.Hand, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            btnRecordOutward.Click += BtnRecordOutward_Click;
            grpOutward.Controls.AddRange(new Control[] { lblOutId, txtOutwardItemId, lblOutQty, txtOutwardQty, lblOutRef, txtOutwardRef, lblOutNotes, txtOutwardNotes, btnRecordOutward });

            _panelMultiLocation.Controls.AddRange(new Control[] { lblLocTitle, lblLocDesc, lblLocation, cmbLocation, btnRefreshLocation, btnCheckLowStock, dgvLocationStock, grpOutward });

            StyleAllControls(_panelMultiLocation);
        }

        private void LoadLocationData()
        {
            try
            {
                if (cmbLocation.Items.Count == 0)
                {
                    DataTable locations = _controller.GetLocations();
                    cmbLocation.Items.Add("All");
                    foreach (DataRow row in locations.Rows)
                        cmbLocation.Items.Add(row["Location"].ToString());
                    cmbLocation.SelectedItem = "All";
                    _currentLocation = "All";
                }

                if (_currentLocation == "All")
                    dgvLocationStock.DataSource = _controller.GetStockList();
                else
                    dgvLocationStock.DataSource = _controller.GetStockListByLocation(_currentLocation);
                dgvLocationStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex) { MessageBox.Show("Error loading location data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BtnCheckLowStock_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.CheckAndCreateRestockRequests(_currentLocation);
                ShowSuccessStatus("Low stock check completed. Restock requests auto-generated!");
                LoadRestockRequests();
            }
            catch (Exception ex) { MessageBox.Show("Failed to check low stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BtnRecordOutward_Click(object sender, EventArgs e)
        {
            string id = txtOutwardItemId.Text.Trim();
            string qtyStr = txtOutwardQty.Text.Trim();
            string refNo = txtOutwardRef.Text.Trim();
            string notes = txtOutwardNotes.Text.Trim();

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(qtyStr))
            { MessageBox.Show("Please fill in both Item ID and Quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!int.TryParse(qtyStr, out int qty) || qty <= 0)
            { MessageBox.Show("Quantity must be a valid positive number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            string location = (_currentLocation == "All") ? "Main Warehouse" : _currentLocation;

            try
            {
                _controller.RecordOutward(id, qty, location, refNo, "Operator", notes);
                txtOutwardItemId.Clear(); txtOutwardQty.Clear(); txtOutwardRef.Clear(); txtOutwardNotes.Clear();
                LoadLocationData(); LoadStockMovements();
                ShowSuccessStatus($"Outbound recorded: Item {id}, Qty {qty} from {location}!");
            }
            catch (Exception ex) { MessageBox.Show("Failed to record outward: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void SetupRestockPanel()
        {
            Label lblRestockTitle = new Label { Text = "Restock Request Approval Workflow", Font = new Font("Segoe UI", 14, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true, ForeColor = _textColor };
            Label lblRestockDesc = new Label { Text = "Three-level approval: Shop Manager → Inventory Manager → Purchase Department", Location = new Point(23, 50), AutoSize = true, ForeColor = _lightTextColor };

            Label lblRestockLoc = new Label { Text = "Filter by Location:", Location = new Point(25, 80), AutoSize = true, ForeColor = _textColor };
            cmbRestockLocation = new ComboBox { Location = new Point(140, 78), Size = new Size(180, 31), DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand, BackColor = Color.FromArgb(245, 240, 255), ForeColor = _textColor, Anchor = AnchorStyles.Top | AnchorStyles.Left };
            cmbRestockLocation.Items.Add("All");
            cmbRestockLocation.SelectedIndexChanged += (s, e) => LoadRestockRequests();

            btnRefreshRestock = new Button { Text = "Refresh", Location = new Point(340, 75), Size = new Size(100, 34), FlatStyle = FlatStyle.Flat, BackColor = _primaryColor, ForeColor = Color.White, Cursor = Cursors.Hand, Anchor = AnchorStyles.Top | AnchorStyles.Left };
            btnRefreshRestock.Click += (s, e) => LoadRestockRequests();

            btnApproveRestock = new Button { Text = "Approve (Next Level)", Location = new Point(460, 75), Size = new Size(160, 34), FlatStyle = FlatStyle.Flat, BackColor = Color.FromArgb(34, 197, 94), ForeColor = Color.White, Cursor = Cursors.Hand, Anchor = AnchorStyles.Top | AnchorStyles.Left };
            btnApproveRestock.Click += BtnApproveRestock_Click;

            btnRejectRestock = new Button { Text = "Reject Request", Location = new Point(640, 75), Size = new Size(140, 34), FlatStyle = FlatStyle.Flat, BackColor = Color.FromArgb(239, 68, 68), ForeColor = Color.White, Cursor = Cursors.Hand, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            btnRejectRestock.Click += BtnRejectRestock_Click;

            dgvRestockRequests = new DataGridView { Location = new Point(25, 120), Size = new Size(755, 400), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, BackgroundColor = _cardColor, AllowUserToAddRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right };

            _panelRestock.Controls.AddRange(new Control[] { lblRestockTitle, lblRestockDesc, lblRestockLoc, cmbRestockLocation, btnRefreshRestock, btnApproveRestock, btnRejectRestock, dgvRestockRequests });

            StyleAllControls(_panelRestock);
        }

        private void LoadRestockRequests()
        {
            try
            {
                string locFilter = "All";
                if (cmbRestockLocation.Items.Count > 0 && cmbRestockLocation.SelectedItem != null)
                {
                    if (cmbRestockLocation.Items.Count == 1)
                    {
                        DataTable locations = _controller.GetLocations();
                        foreach (DataRow row in locations.Rows)
                            cmbRestockLocation.Items.Add(row["Location"].ToString());
                    }
                    locFilter = cmbRestockLocation.SelectedItem.ToString();
                }
                dgvRestockRequests.DataSource = _controller.GetRestockRequests(locFilter);
                dgvRestockRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex) { MessageBox.Show("Error loading restock requests: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BtnApproveRestock_Click(object sender, EventArgs e)
        {
            if (dgvRestockRequests.SelectedRows.Count == 0)
            { MessageBox.Show("Please select a restock request to approve.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            int restockId = Convert.ToInt32(dgvRestockRequests.SelectedRows[0].Cells["Request ID"].Value);
            string status = dgvRestockRequests.SelectedRows[0].Cells["Status"].Value.ToString();

            string role = "";
            string nextLevel = "";
            switch (status)
            {
                case "Pending Shop Manager":
                    role = "shop_manager"; nextLevel = "Shop Manager"; break;
                case "Pending Inventory Manager":
                    role = "inventory_manager"; nextLevel = "Inventory Manager"; break;
                case "Pending Purchase Department":
                    role = "purchase_dept"; nextLevel = "Purchase Department"; break;
                default:
                    MessageBox.Show($"This request is '{status}' and cannot be approved further.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }

            DialogResult result = MessageBox.Show($"Approve Restock Request #{restockId} as {nextLevel}?\n\nThis will advance the approval to the next level.", "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.ApproveRestockRequest(restockId, role);
                    LoadRestockRequests(); LoadLocationData();
                    ShowSuccessStatus($"Request #{restockId} approved by {nextLevel}!");
                }
                catch (Exception ex) { MessageBox.Show("Approval failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void BtnRejectRestock_Click(object sender, EventArgs e)
        {
            if (dgvRestockRequests.SelectedRows.Count == 0)
            { MessageBox.Show("Please select a restock request to reject.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            int restockId = Convert.ToInt32(dgvRestockRequests.SelectedRows[0].Cells["Request ID"].Value);
            string status = dgvRestockRequests.SelectedRows[0].Cells["Status"].Value.ToString();

            if (status == "Rejected" || status == "Fully Approved")
            { MessageBox.Show($"This request is '{status}' and cannot be rejected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            string role = "";
            switch (status)
            {
                case "Pending Shop Manager": role = "shop_manager"; break;
                case "Pending Inventory Manager": role = "inventory_manager"; break;
                case "Pending Purchase Department": role = "purchase_dept"; break;
                default: role = "shop_manager"; break;
            }

            DialogResult result = MessageBox.Show($"Reject Restock Request #{restockId}?\n\nThis will permanently reject the request.", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.RejectRestockRequest(restockId, role);
                    LoadRestockRequests();
                    ShowSuccessStatus($"Request #{restockId} has been rejected.");
                }
                catch (Exception ex) { MessageBox.Show("Rejection failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void SetupStockMovementsPanel()
        {
            Label lblMovTitle = new Label { Text = "Stock Movements (Inbound & Outbound)", Font = new Font("Segoe UI", 14, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true, ForeColor = _textColor };
            Label lblMovDesc = new Label { Text = "Track all inventory movements for audit trail and accuracy verification.", Location = new Point(23, 50), AutoSize = true, ForeColor = _lightTextColor };

            Label lblMovProduct = new Label { Text = "Filter by Product:", Location = new Point(25, 80), AutoSize = true, ForeColor = _textColor };
            cmbMovementProduct = new ComboBox { Location = new Point(130, 78), Size = new Size(180, 31), DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand, BackColor = Color.FromArgb(245, 240, 255), ForeColor = _textColor, Anchor = AnchorStyles.Top | AnchorStyles.Left };
            cmbMovementProduct.Items.Add("All");
            cmbMovementProduct.SelectedIndexChanged += (s, e) => LoadStockMovements();

            btnRefreshMovements = new Button { Text = "Refresh", Location = new Point(330, 75), Size = new Size(100, 34), FlatStyle = FlatStyle.Flat, BackColor = _primaryColor, ForeColor = Color.White, Cursor = Cursors.Hand, Anchor = AnchorStyles.Top | AnchorStyles.Left };
            btnRefreshMovements.Click += (s, e) => LoadStockMovements();

            dgvStockMovements = new DataGridView { Location = new Point(25, 120), Size = new Size(755, 400), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, BackgroundColor = _cardColor, AllowUserToAddRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right };

            _panelStockMovements.Controls.AddRange(new Control[] { lblMovTitle, lblMovDesc, lblMovProduct, cmbMovementProduct, btnRefreshMovements, dgvStockMovements });

            StyleAllControls(_panelStockMovements);
        }

        private void LoadStockMovements()
        {
            try
            {
                if (cmbMovementProduct.Items.Count == 1)
                {
                    DataTable stock = _controller.GetStockList();
                    foreach (DataRow row in stock.Rows)
                    {
                        string pid = row.Table.Columns.Contains("Product ID") ? row["Product ID"].ToString() : "";
                        string pname = row.Table.Columns.Contains("Product Name") ? row["Product Name"].ToString() : "";
                        if (!string.IsNullOrEmpty(pid))
                            cmbMovementProduct.Items.Add($"{pid} - {pname}");
                    }
                }

                string prodFilter = "All";
                if (cmbMovementProduct.SelectedItem != null && cmbMovementProduct.SelectedItem.ToString() != "All")
                {
                    string selected = cmbMovementProduct.SelectedItem.ToString();
                    prodFilter = selected.Split(' ')[0];
                }
                dgvStockMovements.DataSource = _controller.GetStockMovements(prodFilter);
                dgvStockMovements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex) { MessageBox.Show("Error loading stock movements: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void SetupPlaceholderPanel(Panel panel, string title, string description)
        {
            Label lblTitle = new Label 
            { 
                Text = title, 
                Font = new Font("Segoe UI", 20, FontStyle.Bold), 
                Location = new Point(20, 20), 
                AutoSize = true, 
                ForeColor = _textColor 
            };
            
            Label lblDesc = new Label 
            { 
                Text = description, 
                Location = new Point(23, 70), 
                AutoSize = true, 
                ForeColor = _lightTextColor 
            };
            
            Label lblComingSoon = new Label 
            { 
                Text = "Coming Soon...", 
                Font = new Font("Segoe UI", 14, FontStyle.Italic), 
                Location = new Point(23, 130), 
                AutoSize = true, 
                ForeColor = Color.FromArgb(128, 128, 128) 
            };
            
            panel.Controls.AddRange(new Control[] { lblTitle, lblDesc, lblComingSoon });
            StyleAllControls(panel);
        }
    }
}
