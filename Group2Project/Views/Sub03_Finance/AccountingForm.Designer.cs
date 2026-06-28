namespace Group2Project.Views.Sub03_Finance
{
    partial class AccountingForm
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
            tcAccountingManager = new TabControl();
            tbFinancialStatements = new TabPage();
            btnGenerateReport = new Button();
            cmbReportType = new ComboBox();
            dgvFinancialStatements = new DataGridView();
            btnRefreshStatements = new Button();
            label3 = new Label();
            tbIncomeExpense = new TabPage();
            btnAddTransaction = new Button();
            dgvIncomeExpense = new DataGridView();
            btnRefreshIncomeExpense = new Button();
            label4 = new Label();
            tbLedger = new TabPage();
            btnExportData = new Button();
            dgvLedger = new DataGridView();
            btnRefreshLedger = new Button();
            label5 = new Label();
            // 新增的標籤頁
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
            tcAccountingManager.SuspendLayout();
            tbFinancialStatements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFinancialStatements).BeginInit();
            tbIncomeExpense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIncomeExpense).BeginInit();
            tbLedger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLedger).BeginInit();
            tbCustomerPay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoiceList).BeginInit();
            tbProcurement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tcAccountingManager
            // 
            tcAccountingManager.Controls.Add(tbCustomerPay);
            tcAccountingManager.Controls.Add(tbProcurement);
            tcAccountingManager.Controls.Add(tbFinancialStatements);
            tcAccountingManager.Controls.Add(tbIncomeExpense);
            tcAccountingManager.Controls.Add(tbLedger);
            tcAccountingManager.Dock = DockStyle.Fill;
            tcAccountingManager.Location = new Point(0, 0);
            tcAccountingManager.Margin = new Padding(2);
            tcAccountingManager.Name = "tcAccountingManager";
            tcAccountingManager.SelectedIndex = 0;
            tcAccountingManager.TabIndex = 0;
            // 
            // tbFinancialStatements
            // 
            tbFinancialStatements.Controls.Add(btnGenerateReport);
            tbFinancialStatements.Controls.Add(cmbReportType);
            tbFinancialStatements.Controls.Add(dgvFinancialStatements);
            tbFinancialStatements.Controls.Add(btnRefreshStatements);
            tbFinancialStatements.Controls.Add(label3);
            tbFinancialStatements.Location = new Point(4, 28);
            tbFinancialStatements.Margin = new Padding(2);
            tbFinancialStatements.Name = "tbFinancialStatements";
            tbFinancialStatements.Padding = new Padding(2);
            tbFinancialStatements.TabIndex = 0;
            tbFinancialStatements.Text = "Financial Statements";
            tbFinancialStatements.UseVisualStyleBackColor = true;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            btnGenerateReport.BackColor = Color.FromArgb(138, 43, 226);
            btnGenerateReport.Cursor = Cursors.Hand;
            btnGenerateReport.FlatStyle = FlatStyle.Flat;
            btnGenerateReport.ForeColor = Color.White;
            btnGenerateReport.Location = new Point(452, 378);
            btnGenerateReport.Margin = new Padding(2);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(155, 32);
            btnGenerateReport.TabIndex = 5;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.UseVisualStyleBackColor = false;
            // 
            // cmbReportType
            // 
            cmbReportType.Cursor = Cursors.Hand;
            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportType.FormattingEnabled = true;
            cmbReportType.Items.AddRange(new object[] { "Balance Sheet", "Income Statement", "Cash Flow Statement", "Profit & Loss", "Trial Balance" });
            cmbReportType.Location = new Point(137, 19);
            cmbReportType.Margin = new Padding(2);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new Size(200, 27);
            cmbReportType.TabIndex = 3;
            // 
            // dgvFinancialStatements
            // 
            dgvFinancialStatements.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            dgvFinancialStatements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFinancialStatements.Location = new Point(12, 60);
            dgvFinancialStatements.Margin = new Padding(2);
            dgvFinancialStatements.Name = "dgvFinancialStatements";
            dgvFinancialStatements.RowHeadersWidth = 62;
            dgvFinancialStatements.TabIndex = 3;
            // 
            // btnRefreshStatements
            // 
            btnRefreshStatements.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            btnRefreshStatements.Cursor = Cursors.Hand;
            btnRefreshStatements.Location = new Point(359, 19);
            btnRefreshStatements.Margin = new Padding(2);
            btnRefreshStatements.Name = "btnRefreshStatements";
            btnRefreshStatements.Size = new Size(92, 28);
            btnRefreshStatements.TabIndex = 2;
            btnRefreshStatements.Text = "Refresh";
            btnRefreshStatements.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 18);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(90, 19);
            label3.TabIndex = 0;
            label3.Text = "Report Type:";
            // 
            // tbIncomeExpense
            // 
            tbIncomeExpense.Controls.Add(btnAddTransaction);
            tbIncomeExpense.Controls.Add(dgvIncomeExpense);
            tbIncomeExpense.Controls.Add(btnRefreshIncomeExpense);
            tbIncomeExpense.Controls.Add(label4);
            tbIncomeExpense.Location = new Point(4, 28);
            tbIncomeExpense.Margin = new Padding(2);
            tbIncomeExpense.Name = "tbIncomeExpense";
            tbIncomeExpense.Padding = new Padding(2);
            tbIncomeExpense.TabIndex = 1;
            tbIncomeExpense.Text = "Income & Expense";
            tbIncomeExpense.UseVisualStyleBackColor = true;
            // 
            // btnAddTransaction
            // 
            btnAddTransaction.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            btnAddTransaction.BackColor = Color.PaleGreen;
            btnAddTransaction.Cursor = Cursors.Hand;
            btnAddTransaction.FlatStyle = FlatStyle.Flat;
            btnAddTransaction.Location = new Point(12, 378);
            btnAddTransaction.Margin = new Padding(2);
            btnAddTransaction.Name = "btnAddTransaction";
            btnAddTransaction.Size = new Size(150, 32);
            btnAddTransaction.TabIndex = 4;
            btnAddTransaction.Text = "Add Transaction";
            btnAddTransaction.UseVisualStyleBackColor = false;
            // 
            // dgvIncomeExpense
            // 
            dgvIncomeExpense.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            dgvIncomeExpense.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIncomeExpense.Location = new Point(13, 58);
            dgvIncomeExpense.Margin = new Padding(2);
            dgvIncomeExpense.Name = "dgvIncomeExpense";
            dgvIncomeExpense.RowHeadersWidth = 62;
            dgvIncomeExpense.TabIndex = 2;
            // 
            // btnRefreshIncomeExpense
            // 
            btnRefreshIncomeExpense.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            btnRefreshIncomeExpense.Cursor = Cursors.Hand;
            btnRefreshIncomeExpense.FlatStyle = FlatStyle.Flat;
            btnRefreshIncomeExpense.Location = new Point(452, 15);
            btnRefreshIncomeExpense.Margin = new Padding(2);
            btnRefreshIncomeExpense.Name = "btnRefreshIncomeExpense";
            btnRefreshIncomeExpense.Size = new Size(92, 28);
            btnRefreshIncomeExpense.TabIndex = 1;
            btnRefreshIncomeExpense.Text = "Refresh";
            btnRefreshIncomeExpense.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 15);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(336, 19);
            label4.TabIndex = 0;
            label4.Text = "Income and Expense Transactions Overview:";
            // 
            // tbLedger
            // 
            tbLedger.Controls.Add(btnExportData);
            tbLedger.Controls.Add(dgvLedger);
            tbLedger.Controls.Add(btnRefreshLedger);
            tbLedger.Controls.Add(label5);
            tbLedger.Location = new Point(4, 28);
            tbLedger.Margin = new Padding(2);
            tbLedger.Name = "tbLedger";
            tbLedger.Padding = new Padding(2);
            tbLedger.TabIndex = 2;
            tbLedger.Text = "General Ledger";
            tbLedger.UseVisualStyleBackColor = true;
            // 
            // btnExportData
            // 
            btnExportData.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            btnExportData.BackColor = Color.FromArgb(100, 149, 237);
            btnExportData.Cursor = Cursors.Hand;
            btnExportData.FlatStyle = FlatStyle.Flat;
            btnExportData.ForeColor = Color.White;
            btnExportData.Location = new Point(452, 378);
            btnExportData.Margin = new Padding(2);
            btnExportData.Name = "btnExportData";
            btnExportData.Size = new Size(155, 32);
            btnExportData.TabIndex = 4;
            btnExportData.Text = "Export Data";
            btnExportData.UseVisualStyleBackColor = false;
            // 
            // dgvLedger
            // 
            dgvLedger.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            dgvLedger.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLedger.Location = new Point(13, 58);
            dgvLedger.Margin = new Padding(2);
            dgvLedger.Name = "dgvLedger";
            dgvLedger.RowHeadersWidth = 62;
            dgvLedger.TabIndex = 2;
            // 
            // btnRefreshLedger
            // 
            btnRefreshLedger.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            btnRefreshLedger.Cursor = Cursors.Hand;
            btnRefreshLedger.FlatStyle = FlatStyle.Flat;
            btnRefreshLedger.Location = new Point(452, 15);
            btnRefreshLedger.Margin = new Padding(2);
            btnRefreshLedger.Name = "btnRefreshLedger";
            btnRefreshLedger.Size = new Size(92, 28);
            btnRefreshLedger.TabIndex = 1;
            btnRefreshLedger.Text = "Refresh";
            btnRefreshLedger.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 15);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(380, 19);
            label5.TabIndex = 0;
            label5.Text = "General Ledger - All Accounting Entries:";
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
            // AccountingForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 563);
            Controls.Add(tcAccountingManager);
            Margin = new Padding(2);
            Name = "AccountingForm";
            Text = "Finance & Accounting Management";
            tcAccountingManager.ResumeLayout(false);
            tbFinancialStatements.ResumeLayout(false);
            tbFinancialStatements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFinancialStatements).EndInit();
            tbIncomeExpense.ResumeLayout(false);
            tbIncomeExpense.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIncomeExpense).EndInit();
            tbLedger.ResumeLayout(false);
            tbLedger.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLedger).EndInit();
            tbCustomerPay.ResumeLayout(false);
            tbCustomerPay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoiceList).EndInit();
            tbProcurement.ResumeLayout(false);
            tbProcurement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcAccountingManager;
        private TabPage tbFinancialStatements;
        private TabPage tbIncomeExpense;
        private TabPage tbLedger;
        private DataGridView dgvFinancialStatements;
        private Button btnRefreshStatements;
        private ComboBox cmbReportType;
        private Label label3;
        private DataGridView dgvIncomeExpense;
        private Button btnRefreshIncomeExpense;
        private Label label4;
        private DataGridView dgvLedger;
        private Button btnRefreshLedger;
        private Label label5;
        private Button btnGenerateReport;
        private Button btnAddTransaction;
        private Button btnExportData;
        // 新增的控件
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
