using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Group2Project.Controllers;

namespace Group2Project.Views.Sub03_Finance
{
    public partial class AccountingForm : Form
    {
        private FinanceController _controller;

        private Panel _sidebarPanel;
        private Panel _contentPanel;
        private Panel _panelCustomerInvoices;
        private Panel _panelProcurement;
        private Panel _panelFinancialStatements;
        private Panel _panelIncomeExpense;
        private Panel _panelLedger;
        private Button _currentNavButton;

        private readonly Color _primaryColor = Color.FromArgb(70, 130, 180);
        private readonly Color _secondaryColor = Color.FromArgb(176, 196, 222);
        private readonly Color _sidebarColor = Color.FromArgb(30, 30, 30);
        private readonly Color _backgroundColor = Color.FromArgb(245, 245, 245);

        public AccountingForm()
        {
            InitializeComponent();

            _controller = new FinanceController();

            this.Load += AccountingForm_Load;

            // 連接所有事件處理器
            if (btnRefreshStatements != null) btnRefreshStatements.Click += btnRefreshStatements_Click;
            if (btnRefreshIncomeExpense != null) btnRefreshIncomeExpense.Click += btnRefreshIncomeExpense_Click;
            if (btnRefreshLedger != null) btnRefreshLedger.Click += btnRefreshLedger_Click;
            if (btnRefreshInvoices != null) btnRefreshInvoices.Click += btnRefreshInvoices_Click;
            if (btnRefreshProcRequests != null) btnRefreshProcRequests.Click += btnRefreshProcRequests_Click;
            if (btnGenerateReport != null) btnGenerateReport.Click += btnGenerateReport_Click;
            if (btnAddTransaction != null) btnAddTransaction.Click += btnAddTransaction_Click;
            if (btnExportData != null) btnExportData.Click += btnExportData_Click;
            if (btnConfirmPayment != null) btnConfirmPayment.Click += btnConfirmPayment_Click;
            if (btnIssueRefund != null) btnIssueRefund.Click += btnIssueRefund_Click;
            if (btnPrintReceipt != null) btnPrintReceipt.Click += btnPrintReceipt_Click;
            if (btnApproveProcurement != null) btnApproveProcurement.Click += btnApproveProcurement_Click;
            if (btnRejectProcurement != null) btnRejectProcurement.Click += btnRejectProcurement_Click;

            SetupContentPanels();
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
                Text = "� Finance & Accounting",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 25),
                AutoSize = true
            };

            sidebarHeader.Controls.Add(sidebarTitle);
            _sidebarPanel.Controls.Add(sidebarHeader);

            int yPosition = 110;
            CreateNavButton("Customer Invoices", 0, ref yPosition);
            CreateNavButton("Procurement", 1, ref yPosition);
            CreateNavButton("Financial Statements", 2, ref yPosition);
            CreateNavButton("Income & Expense", 3, ref yPosition);
            CreateNavButton("General Ledger", 4, ref yPosition);

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

            // 從 PaymentCheckForm 遷移的面板
            _panelCustomerInvoices = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor
            };
            MoveControlsFromTabPage(tbCustomerPay, _panelCustomerInvoices);

            _panelProcurement = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };
            MoveControlsFromTabPage(tbProcurement, _panelProcurement);

            // 原始 AccountingForm 的面板
            _panelFinancialStatements = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };
            MoveControlsFromTabPage(tbFinancialStatements, _panelFinancialStatements);

            _panelIncomeExpense = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };
            MoveControlsFromTabPage(tbIncomeExpense, _panelIncomeExpense);

            _panelLedger = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };
            MoveControlsFromTabPage(tbLedger, _panelLedger);

            // 添加所有面板到內容區域
            _contentPanel.Controls.Add(_panelLedger);
            _contentPanel.Controls.Add(_panelIncomeExpense);
            _contentPanel.Controls.Add(_panelFinancialStatements);
            _contentPanel.Controls.Add(_panelProcurement);
            _contentPanel.Controls.Add(_panelCustomerInvoices);

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
            }
        }

        private void ShowPanel(int index)
        {
            // 隱藏所有面板
            _panelCustomerInvoices.Visible = false;
            _panelProcurement.Visible = false;
            _panelFinancialStatements.Visible = false;
            _panelIncomeExpense.Visible = false;
            _panelLedger.Visible = false;

            // 重置所有導航按鈕樣式
            foreach (Control ctrl in _sidebarPanel.Controls)
            {
                if (ctrl is Button btn && btn.Tag is int)
                {
                    btn.BackColor = Color.Transparent;
                    btn.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
                }
            }

            // 高亮當前按鈕
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

            // 顯示對應的面板
            switch (index)
            {
                case 0:
                    _panelCustomerInvoices.Visible = true;
                    _panelCustomerInvoices.BringToFront();
                    break;
                case 1:
                    _panelProcurement.Visible = true;
                    _panelProcurement.BringToFront();
                    break;
                case 2:
                    _panelFinancialStatements.Visible = true;
                    _panelFinancialStatements.BringToFront();
                    break;
                case 3:
                    _panelIncomeExpense.Visible = true;
                    _panelIncomeExpense.BringToFront();
                    break;
                case 4:
                    _panelLedger.Visible = true;
                    _panelLedger.BringToFront();
                    break;
            }
        }

        private void AccountingForm_Load(object sender, EventArgs e)
        {
            LoadCustomerInvoices();
            LoadProcurementRequests();
            LoadFinancialStatements();
            LoadIncomeExpense();
            LoadLedger();
        }

        private void LoadCustomerInvoices()
        {
            try
            {
                if (dgvInvoiceList != null)
                {
                    dgvInvoiceList.DataSource = _controller.GetCustomerInvoices();
                    dgvInvoiceList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load invoice data: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProcurementRequests()
        {
            try
            {
                if (dataGridView1 != null)
                {
                    dataGridView1.DataSource = _controller.GetProcurementRequests();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load procurement data: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshInvoices_Click(object sender, EventArgs e)
        {
            LoadCustomerInvoices();
        }

        private void btnRefreshProcRequests_Click(object sender, EventArgs e)
        {
            LoadProcurementRequests();
        }

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {

            if (dgvInvoiceList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an invoice to record payment.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string invoiceId = dgvInvoiceList.SelectedRows[0].Cells["Invoice ID"].Value.ToString();
            string status = dgvInvoiceList.SelectedRows[0].Cells["Payment Status"].Value.ToString();

            if (status == "Paid" || status == "Completed")
            {
                MessageBox.Show("This invoice is already fully paid!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            DialogResult result = MessageBox.Show("Confirm receipt of payment for Invoice ID: " + invoiceId + "?", "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {

                    _controller.UpdatePaymentStatus(invoiceId, "Paid");



                    LoadCustomerInvoices();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnIssueRefund_Click(object sender, EventArgs e)
        {
            if (dgvInvoiceList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an invoice to issue a refund.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string invoiceId = dgvInvoiceList.SelectedRows[0].Cells["Invoice ID"].Value.ToString();
            string status = dgvInvoiceList.SelectedRows[0].Cells["Payment Status"].Value.ToString();

            if (status != "Paid" && status != "Completed")
            {
                MessageBox.Show("You can only issue a refund for fully paid invoices.", "Finance Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to issue a refund for Invoice ID: " + invoiceId + "? This action cannot be undone.", "Confirm Refund", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.UpdatePaymentStatus(invoiceId, "Refunded");


                    LoadCustomerInvoices();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            if (dgvInvoiceList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an invoice to print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string invoiceId = dgvInvoiceList.SelectedRows[0].Cells["Invoice ID"].Value.ToString();
            string customerName = dgvInvoiceList.SelectedRows[0].Cells["Customer Name"].Value.ToString();
            string status = dgvInvoiceList.SelectedRows[0].Cells["Payment Status"].Value.ToString();
            string date = dgvInvoiceList.SelectedRows[0].Cells["Billing Date"].Value.ToString();

            string receiptContent = "--- OFFICIAL TAX INVOICE ---\n\n" +
                                    "Invoice ID: " + invoiceId + "\n" +
                                    "Customer: " + customerName + "\n" +
                                    "Date: " + date + "\n" +
                                    "Status: " + status.ToUpper() + "\n\n" +
                                    "Connecting to printer... Done!";

            MessageBox.Show(receiptContent, "Print Simulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnApproveProcurement_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a procurement request to approve.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string procId = dataGridView1.SelectedRows[0].Cells["Request ID"].Value.ToString();
            string status = dataGridView1.SelectedRows[0].Cells["Approval Status"].Value.ToString();


            if (status != "Pending")
            {
                MessageBox.Show("This request has already been processed (Current Status: " + status + ").", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            DialogResult result = MessageBox.Show("Are you sure you want to APPROVE procurement request ID: " + procId + "?", "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {

                    _controller.UpdateProcurementStatus(procId, "Approved");


                    LoadProcurementRequests();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnRejectProcurement_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a procurement request to reject.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string procId = dataGridView1.SelectedRows[0].Cells["Request ID"].Value.ToString();
            string status = dataGridView1.SelectedRows[0].Cells["Approval Status"].Value.ToString();

            if (status != "Pending")
            {
                MessageBox.Show("This request has already been processed (Current Status: " + status + ").", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure you want to REJECT procurement request ID: " + procId + "?", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.UpdateProcurementStatus(procId, "Rejected");


                    LoadProcurementRequests();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnRefreshStatements_Click(object sender, EventArgs e)
        {
            LoadFinancialStatements();
        }

        private void LoadFinancialStatements()
        {
            try
            {
                if (dgvFinancialStatements != null)
                {
                    dgvFinancialStatements.DataSource = _controller.GetFinancialStatements();
                    dgvFinancialStatements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load financial statements: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshIncomeExpense_Click(object sender, EventArgs e)
        {
            LoadIncomeExpense();
        }

        private void LoadIncomeExpense()
        {
            try
            {
                if (dgvIncomeExpense != null)
                {
                    dgvIncomeExpense.DataSource = _controller.GetIncomeExpenseData();
                    dgvIncomeExpense.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load income/expense data: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshLedger_Click(object sender, EventArgs e)
        {
            LoadLedger();
        }

        private void LoadLedger()
        {
            try
            {
                if (dgvLedger != null)
                {
                    dgvLedger.DataSource = _controller.GetGeneralLedger();
                    dgvLedger.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load ledger data: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            if (cmbReportType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a report type to generate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reportType = cmbReportType.SelectedItem.ToString();
            DialogResult result = MessageBox.Show($"Generate {reportType} report for the selected period?", "Confirm Report Generation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    MessageBox.Show($"Successfully generated {reportType} report!\n\nReport is ready for download.", "Report Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Transaction entry form would open here.\n\nThis is a placeholder for the transaction entry feature.", "Add Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportData_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Exporting accounting data to Excel/CSV...\n\nData export completed successfully!", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
