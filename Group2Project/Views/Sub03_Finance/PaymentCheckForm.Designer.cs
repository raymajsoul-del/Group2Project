namespace Group2Project.Views.Sub03_Finance
{
    partial class PaymentCheckForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tcFinanceManager = new TabControl();
            tbCustomerPay = new TabPage();
            btnIssueRefund = new Button();
            btnPrintReceipt = new Button();
            btnConfirmPayment = new Button();
            dgvInvoiceList = new DataGridView();
            btnRefreshInvoices = new Button();
            cmbPaymentStatusFilter = new ComboBox();
            label1 = new Label();
            tbProcurement = new TabPage();
            btnRejectProcurement = new Button();
            btnApproveProcurement = new Button();
            dataGridView1 = new DataGridView();
            btnRefreshProcRequests = new Button();
            label2 = new Label();
            tcFinanceManager.SuspendLayout();
            tbCustomerPay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoiceList).BeginInit();
            tbProcurement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tcFinanceManager
            // 
            tcFinanceManager.Controls.Add(tbCustomerPay);
            tcFinanceManager.Controls.Add(tbProcurement);
            tcFinanceManager.Dock = DockStyle.Fill;
            tcFinanceManager.Location = new Point(0, 0);
            tcFinanceManager.Margin = new Padding(2);
            tcFinanceManager.Name = "tcFinanceManager";
            tcFinanceManager.SelectedIndex = 0;
            tcFinanceManager.TabIndex = 0;
            // 
            // tbCustomerPay
            // 
            tbCustomerPay.Controls.Add(btnIssueRefund);
            tbCustomerPay.Controls.Add(btnPrintReceipt);
            tbCustomerPay.Controls.Add(btnConfirmPayment);
            tbCustomerPay.Controls.Add(dgvInvoiceList);
            tbCustomerPay.Controls.Add(btnRefreshInvoices);
            tbCustomerPay.Controls.Add(cmbPaymentStatusFilter);
            tbCustomerPay.Controls.Add(label1);
            tbCustomerPay.Location = new Point(4, 28);
            tbCustomerPay.Margin = new Padding(2);
            tbCustomerPay.Name = "tbCustomerPay";
            tbCustomerPay.Padding = new Padding(2);
            tbCustomerPay.TabIndex = 0;
            tbCustomerPay.Text = "Customer Invoices & Payments";
            tbCustomerPay.UseVisualStyleBackColor = true;
            // 
            // btnIssueRefund
            // 
            btnIssueRefund.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            btnIssueRefund.BackColor = Color.Salmon;
            btnIssueRefund.Cursor = Cursors.Hand;
            btnIssueRefund.FlatStyle = FlatStyle.Flat;
            btnIssueRefund.Location = new Point(583, 368);
            btnIssueRefund.Margin = new Padding(2);
            btnIssueRefund.Name = "btnIssueRefund";
            btnIssueRefund.Size = new Size(124, 49);
            btnIssueRefund.TabIndex = 6;
            btnIssueRefund.Text = "Process Refund";
            btnIssueRefund.UseVisualStyleBackColor = false;
            // 
            // btnPrintReceipt
            // 
            btnPrintReceipt.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            btnPrintReceipt.Cursor = Cursors.Hand;
            btnPrintReceipt.FlatStyle = FlatStyle.Flat;
            btnPrintReceipt.Location = new Point(276, 378);
            btnPrintReceipt.Margin = new Padding(2);
            btnPrintReceipt.Name = "btnPrintReceipt";
            btnPrintReceipt.Size = new Size(206, 28);
            btnPrintReceipt.TabIndex = 5;
            btnPrintReceipt.Text = "Print Tax Invoice / Receipt";
            btnPrintReceipt.UseVisualStyleBackColor = true;
            // 
            // btnConfirmPayment
            // 
            btnConfirmPayment.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            btnConfirmPayment.Cursor = Cursors.Hand;
            btnConfirmPayment.FlatStyle = FlatStyle.Flat;
            btnConfirmPayment.Location = new Point(12, 378);
            btnConfirmPayment.Margin = new Padding(2);
            btnConfirmPayment.Name = "btnConfirmPayment";
            btnConfirmPayment.Size = new Size(227, 28);
            btnConfirmPayment.TabIndex = 4;
            btnConfirmPayment.Text = "Record Payment / Collect";
            btnConfirmPayment.UseVisualStyleBackColor = true;
            // 
            // dgvInvoiceList
            // 
            dgvInvoiceList.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            dgvInvoiceList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInvoiceList.Location = new Point(12, 60);
            dgvInvoiceList.Margin = new Padding(2);
            dgvInvoiceList.Name = "dgvInvoiceList";
            dgvInvoiceList.RowHeadersWidth = 62;
            dgvInvoiceList.TabIndex = 3;
            // 
            // btnRefreshInvoices
            // 
            btnRefreshInvoices.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            btnRefreshInvoices.Cursor = Cursors.Hand;
            btnRefreshInvoices.Location = new Point(309, 19);
            btnRefreshInvoices.Margin = new Padding(2);
            btnRefreshInvoices.Name = "btnRefreshInvoices";
            btnRefreshInvoices.Size = new Size(92, 28);
            btnRefreshInvoices.TabIndex = 2;
            btnRefreshInvoices.Text = "Refresh";
            btnRefreshInvoices.UseVisualStyleBackColor = true;
            btnRefreshInvoices.Click += btnRefreshInvoices_Click;
            // 
            // cmbPaymentStatusFilter
            // 
            cmbPaymentStatusFilter.Cursor = Cursors.Hand;
            cmbPaymentStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentStatusFilter.FormattingEnabled = true;
            cmbPaymentStatusFilter.Items.AddRange(new object[] { "Unpaid", "Partially Paid", "Paid", "Refunded" });
            cmbPaymentStatusFilter.Location = new Point(137, 19);
            cmbPaymentStatusFilter.Margin = new Padding(2);
            cmbPaymentStatusFilter.Name = "cmbPaymentStatusFilter";
            cmbPaymentStatusFilter.Size = new Size(150, 27);
            cmbPaymentStatusFilter.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(120, 19);
            label1.TabIndex = 0;
            label1.Text = "Payment Status:";
            // 
            // tbProcurement
            // 
            tbProcurement.Controls.Add(btnRejectProcurement);
            tbProcurement.Controls.Add(btnApproveProcurement);
            tbProcurement.Controls.Add(dataGridView1);
            tbProcurement.Controls.Add(btnRefreshProcRequests);
            tbProcurement.Controls.Add(label2);
            tbProcurement.Location = new Point(4, 28);
            tbProcurement.Margin = new Padding(2);
            tbProcurement.Name = "tbProcurement";
            tbProcurement.Padding = new Padding(2);
            tbProcurement.TabIndex = 1;
            tbProcurement.Text = "Procurement Cost Approval";
            tbProcurement.UseVisualStyleBackColor = true;
            // 
            // btnRejectProcurement
            // 
            btnRejectProcurement.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            btnRejectProcurement.BackColor = Color.Salmon;
            btnRejectProcurement.Cursor = Cursors.Hand;
            btnRejectProcurement.FlatStyle = FlatStyle.Flat;
            btnRejectProcurement.Location = new Point(452, 383);
            btnRejectProcurement.Margin = new Padding(2);
            btnRejectProcurement.Name = "btnRejectProcurement";
            btnRejectProcurement.Size = new Size(101, 45);
            btnRejectProcurement.TabIndex = 4;
            btnRejectProcurement.Text = "Reject";
            btnRejectProcurement.UseVisualStyleBackColor = false;
            // 
            // btnApproveProcurement
            // 
            btnApproveProcurement.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            btnApproveProcurement.BackColor = Color.PaleGreen;
            btnApproveProcurement.Cursor = Cursors.Hand;
            btnApproveProcurement.FlatStyle = FlatStyle.Flat;
            btnApproveProcurement.Location = new Point(83, 382);
            btnApproveProcurement.Margin = new Padding(2);
            btnApproveProcurement.Name = "btnApproveProcurement";
            btnApproveProcurement.Size = new Size(99, 46);
            btnApproveProcurement.TabIndex = 3;
            btnApproveProcurement.Text = "Approve";
            btnApproveProcurement.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(13, 58);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.TabIndex = 2;
            // 
            // btnRefreshProcRequests
            // 
            btnRefreshProcRequests.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            btnRefreshProcRequests.BackColor = Color.Transparent;
            btnRefreshProcRequests.Cursor = Cursors.Hand;
            btnRefreshProcRequests.FlatStyle = FlatStyle.Flat;
            btnRefreshProcRequests.Location = new Point(452, 15);
            btnRefreshProcRequests.Margin = new Padding(2);
            btnRefreshProcRequests.Name = "btnRefreshProcRequests";
            btnRefreshProcRequests.Size = new Size(92, 28);
            btnRefreshProcRequests.TabIndex = 1;
            btnRefreshProcRequests.Text = "Refresh";
            btnRefreshProcRequests.UseVisualStyleBackColor = false;
            btnRefreshProcRequests.Click += btnRefreshProcRequests_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 15);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(439, 19);
            label2.TabIndex = 0;
            label2.Text = "Pending Procurement Requests Requesting Budget Approval:";
            // 
            // PaymentCheckForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 563);
            Controls.Add(tcFinanceManager);
            Margin = new Padding(2);
            Name = "PaymentCheckForm";
            Text = "Finance & Payments";
            tcFinanceManager.ResumeLayout(false);
            tbCustomerPay.ResumeLayout(false);
            tbCustomerPay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoiceList).EndInit();
            tbProcurement.ResumeLayout(false);
            tbProcurement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcFinanceManager;
        private TabPage tbCustomerPay;
        private TabPage tbProcurement;
        private ComboBox cmbPaymentStatusFilter;
        private Label label1;
        private Button btnIssueRefund;
        private Button btnPrintReceipt;
        private Button btnConfirmPayment;
        private DataGridView dgvInvoiceList;
        private Button btnRefreshInvoices;
        private Button btnRefreshProcRequests;
        private Label label2;
        private Button btnRejectProcurement;
        private Button btnApproveProcurement;
        private DataGridView dataGridView1;
    }
}