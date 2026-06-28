using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Group2Project.Controllers;

namespace Group2Project.Views.Sub03_Finance
{
    public partial class PaymentCheckForm : Form
    {
        private FinanceController _controller;

        private Panel _sidebarPanel;
        private Panel _contentPanel;
        private Panel _panelCustomerPay;
        private Panel _panelProcurement;
        private Button _currentNavButton;

        private readonly Color _primaryColor = Color.FromArgb(70, 130, 180);
        private readonly Color _secondaryColor = Color.FromArgb(176, 196, 222);
        private readonly Color _sidebarColor = Color.FromArgb(30, 30, 30);
        private readonly Color _backgroundColor = Color.FromArgb(245, 245, 245);

        public PaymentCheckForm()
        {
            InitializeComponent();

            _controller = new FinanceController();

            this.Load += PaymentCheckForm_Load;

            if (btnRefreshInvoices != null)
            {
                btnRefreshInvoices.Click += btnRefreshInvoices_Click;
            }

            if (btnRefreshProcRequests != null)
            {
                btnRefreshProcRequests.Click += btnRefreshProcRequests_Click;
            }

           
            if (btnConfirmPayment != null) btnConfirmPayment.Click += btnConfirmPayment_Click;
            if (btnIssueRefund != null) btnIssueRefund.Click += btnIssueRefund_Click;
            if (btnPrintReceipt != null) btnPrintReceipt.Click += btnPrintReceipt_Click;
            if (btnApproveProcurement != null) btnApproveProcurement.Click += btnApproveProcurement_Click;
            if (btnRejectProcurement != null) btnRejectProcurement.Click += btnRejectProcurement_Click;

            SetupContentPanels();
            if (tcFinanceManager != null)
            {
                this.Controls.Remove(tcFinanceManager);
                tcFinanceManager.Dispose();
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
                Text = "💰 Finance",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 30),
                AutoSize = true
            };

            sidebarHeader.Controls.Add(sidebarTitle);
            _sidebarPanel.Controls.Add(sidebarHeader);

            int yPosition = 110;
            CreateNavButton("Customer Invoices", 0, ref yPosition);
            CreateNavButton("Procurement", 1, ref yPosition);

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

            _panelCustomerPay = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor
            };
            MoveControlsFromTabPage(tbCustomerPay, _panelCustomerPay);

            _panelProcurement = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };
            MoveControlsFromTabPage(tbProcurement, _panelProcurement);

            _contentPanel.Controls.Add(_panelProcurement);
            _contentPanel.Controls.Add(_panelCustomerPay);

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
            _panelCustomerPay.Visible = false;
            _panelProcurement.Visible = false;

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
                    _panelCustomerPay.Visible = true;
                    _panelCustomerPay.BringToFront();
                    break;
                case 1:
                    _panelProcurement.Visible = true;
                    _panelProcurement.BringToFront();
                    break;
            }
        }

        private void PaymentCheckForm_Load(object sender, EventArgs e)
        {
            LoadCustomerInvoices();
            LoadProcurementRequests();
        }

        private void btnRefreshInvoices_Click(object sender, EventArgs e)
        {
            LoadCustomerInvoices();
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

        private void btnRefreshProcRequests_Click(object sender, EventArgs e)
        {
            LoadProcurementRequests();
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


            DialogResult result = MessageBox.Show($"Confirm receipt of payment for Invoice ID: {invoiceId}?", "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

            DialogResult result = MessageBox.Show($"Are you sure you want to issue a refund for Invoice ID: {invoiceId}? This action cannot be undone.", "Confirm Refund", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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

            string receiptContent = $"--- OFFICIAL TAX INVOICE ---\n\n" +
                                    $"Invoice ID: {invoiceId}\n" +
                                    $"Customer: {customerName}\n" +
                                    $"Date: {date}\n" +
                                    $"Status: {status.ToUpper()}\n\n" +
                                    $"Connecting to printer... Done!";

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
                MessageBox.Show($"This request has already been processed (Current Status: {status}).", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           
            DialogResult result = MessageBox.Show($"Are you sure you want to APPROVE procurement request ID: {procId}?", "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                MessageBox.Show($"This request has already been processed (Current Status: {status}).", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show($"Are you sure you want to REJECT procurement request ID: {procId}?", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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
    }
}
