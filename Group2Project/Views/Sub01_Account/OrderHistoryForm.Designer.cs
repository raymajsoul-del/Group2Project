namespace Group2Project.Views.Sub01_Account
{
    partial class OrderHistoryForm
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
            tcAccountHistory = new TabControl();
            tbOrderOverview = new TabPage();
            btnDownloadInvoice = new Button();
            btnViewFullDetails = new Button();
            dgvOrderHistoryList = new DataGridView();
            groupBox1 = new GroupBox();
            btnResetHistory = new Button();
            btnSearchHistory = new Button();
            cmbFinalStatusFilter = new ComboBox();
            label2 = new Label();
            txtYearFilter = new TextBox();
            txtSearchQuery = new TextBox();
            label1 = new Label();
            labelCOID = new Label();
            tbOrderTimeline = new TabPage();
            txtInternalNotes = new TextBox();
            label3 = new Label();
            dgvLifecycleTimeline = new DataGridView();
            lblSelectedOrderHint = new Label();
            tcAccountHistory.SuspendLayout();
            tbOrderOverview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrderHistoryList).BeginInit();
            groupBox1.SuspendLayout();
            tbOrderTimeline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLifecycleTimeline).BeginInit();
            SuspendLayout();
            // 
            // tcAccountHistory
            // 
            tcAccountHistory.Controls.Add(tbOrderOverview);
            tcAccountHistory.Controls.Add(tbOrderTimeline);
            tcAccountHistory.Dock = DockStyle.Fill;
            tcAccountHistory.Location = new Point(0, 0);
            tcAccountHistory.Margin = new Padding(2);
            tcAccountHistory.Name = "tcAccountHistory";
            tcAccountHistory.SelectedIndex = 0;
            tcAccountHistory.TabIndex = 0;
            tcAccountHistory.SelectedIndexChanged += tcAccountHistory_SelectedIndexChanged;
            // 
            // tbOrderOverview
            // 
            tbOrderOverview.Controls.Add(btnDownloadInvoice);
            tbOrderOverview.Controls.Add(btnViewFullDetails);
            tbOrderOverview.Controls.Add(dgvOrderHistoryList);
            tbOrderOverview.Controls.Add(groupBox1);
            tbOrderOverview.Location = new Point(4, 28);
            tbOrderOverview.Margin = new Padding(2);
            tbOrderOverview.Name = "tbOrderOverview";
            tbOrderOverview.Padding = new Padding(2);
            tbOrderOverview.TabIndex = 0;
            tbOrderOverview.Text = "Order History Overview";
            tbOrderOverview.UseVisualStyleBackColor = true;
            // 
            // btnDownloadInvoice
            // 
            btnDownloadInvoice.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            btnDownloadInvoice.BackColor = Color.Lime;
            btnDownloadInvoice.Cursor = Cursors.Hand;
            btnDownloadInvoice.FlatStyle = FlatStyle.Flat;
            btnDownloadInvoice.Location = new Point(680, 197);
            btnDownloadInvoice.Margin = new Padding(2);
            btnDownloadInvoice.Name = "btnDownloadInvoice";
            btnDownloadInvoice.Size = new Size(131, 71);
            btnDownloadInvoice.TabIndex = 3;
            btnDownloadInvoice.Text = "Download";
            btnDownloadInvoice.UseVisualStyleBackColor = false;
            // 
            // btnViewFullDetails
            // 
            btnViewFullDetails.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            btnViewFullDetails.BackColor = Color.Gold;
            btnViewFullDetails.Cursor = Cursors.Hand;
            btnViewFullDetails.FlatStyle = FlatStyle.Flat;
            btnViewFullDetails.Location = new Point(680, 45);
            btnViewFullDetails.Margin = new Padding(2);
            btnViewFullDetails.Name = "btnViewFullDetails";
            btnViewFullDetails.Size = new Size(131, 71);
            btnViewFullDetails.TabIndex = 2;
            btnViewFullDetails.Text = "View";
            btnViewFullDetails.UseVisualStyleBackColor = false;
            // 
            // dgvOrderHistoryList
            // 
            dgvOrderHistoryList.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            dgvOrderHistoryList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderHistoryList.Location = new Point(13, 230);
            dgvOrderHistoryList.Margin = new Padding(2);
            dgvOrderHistoryList.Name = "dgvOrderHistoryList";
            dgvOrderHistoryList.RowHeadersWidth = 62;
            dgvOrderHistoryList.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            groupBox1.Controls.Add(btnResetHistory);
            groupBox1.Controls.Add(btnSearchHistory);
            groupBox1.Controls.Add(cmbFinalStatusFilter);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtYearFilter);
            groupBox1.Controls.Add(txtSearchQuery);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(labelCOID);
            groupBox1.Location = new Point(13, 14);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search & Filter Filters";
            // 
            // btnResetHistory
            // 
            btnResetHistory.BackColor = Color.AliceBlue;
            btnResetHistory.Cursor = Cursors.Hand;
            btnResetHistory.FlatStyle = FlatStyle.Flat;
            btnResetHistory.Location = new Point(137, 147);
            btnResetHistory.Margin = new Padding(2);
            btnResetHistory.Name = "btnResetHistory";
            btnResetHistory.Size = new Size(92, 28);
            btnResetHistory.TabIndex = 7;
            btnResetHistory.Text = "Rest";
            btnResetHistory.UseVisualStyleBackColor = false;
            // 
            // btnSearchHistory
            // 
            btnSearchHistory.BackColor = Color.Aqua;
            btnSearchHistory.Cursor = Cursors.Hand;
            btnSearchHistory.FlatStyle = FlatStyle.Flat;
            btnSearchHistory.Location = new Point(14, 147);
            btnSearchHistory.Margin = new Padding(2);
            btnSearchHistory.Name = "btnSearchHistory";
            btnSearchHistory.Size = new Size(92, 28);
            btnSearchHistory.TabIndex = 6;
            btnSearchHistory.Text = "Search";
            btnSearchHistory.UseVisualStyleBackColor = false;
            // 
            // cmbFinalStatusFilter
            // 
            cmbFinalStatusFilter.Cursor = Cursors.Hand;
            cmbFinalStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFinalStatusFilter.FlatStyle = FlatStyle.Flat;
            cmbFinalStatusFilter.FormattingEnabled = true;
            cmbFinalStatusFilter.Items.AddRange(new object[] { "Completed", "Cancelled", "In Progress" });
            cmbFinalStatusFilter.Location = new Point(106, 102);
            cmbFinalStatusFilter.Margin = new Padding(2);
            cmbFinalStatusFilter.Name = "cmbFinalStatusFilter";
            cmbFinalStatusFilter.Size = new Size(150, 27);
            cmbFinalStatusFilter.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 102);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(92, 19);
            label2.TabIndex = 4;
            label2.Text = "Final Status:";
            // 
            // txtYearFilter
            // 
            txtYearFilter.Cursor = Cursors.IBeam;
            txtYearFilter.Location = new Point(106, 63);
            txtYearFilter.Margin = new Padding(2);
            txtYearFilter.Name = "txtYearFilter";
            txtYearFilter.Size = new Size(123, 27);
            txtYearFilter.TabIndex = 3;
            // 
            // txtSearchQuery
            // 
            txtSearchQuery.Cursor = Cursors.IBeam;
            txtSearchQuery.Location = new Point(193, 28);
            txtSearchQuery.Margin = new Padding(2);
            txtSearchQuery.Name = "txtSearchQuery";
            txtSearchQuery.Size = new Size(123, 27);
            txtSearchQuery.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 63);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(89, 19);
            label1.TabIndex = 1;
            label1.Text = "Order Year:";
            // 
            // labelCOID
            // 
            labelCOID.AutoSize = true;
            labelCOID.Location = new Point(14, 31);
            labelCOID.Margin = new Padding(2, 0, 2, 0);
            labelCOID.Name = "labelCOID";
            labelCOID.Size = new Size(174, 19);
            labelCOID.TabIndex = 0;
            labelCOID.Text = "Customer ID / Order ID:";
            // 
            // tbOrderTimeline
            // 
            tbOrderTimeline.Controls.Add(txtInternalNotes);
            tbOrderTimeline.Controls.Add(label3);
            tbOrderTimeline.Controls.Add(dgvLifecycleTimeline);
            tbOrderTimeline.Controls.Add(lblSelectedOrderHint);
            tbOrderTimeline.Location = new Point(4, 28);
            tbOrderTimeline.Margin = new Padding(2);
            tbOrderTimeline.Name = "tbOrderTimeline";
            tbOrderTimeline.Padding = new Padding(2);
            tbOrderTimeline.TabIndex = 1;
            tbOrderTimeline.Text = "Order Lifecycle Timeline";
            tbOrderTimeline.UseVisualStyleBackColor = true;
            // 
            // txtInternalNotes
            // 
            txtInternalNotes.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            txtInternalNotes.Location = new Point(242, 388);
            txtInternalNotes.Margin = new Padding(2);
            txtInternalNotes.Multiline = true;
            txtInternalNotes.Name = "txtInternalNotes";
            txtInternalNotes.ReadOnly = true;
            txtInternalNotes.TabIndex = 3;
            // 
            // label3
            // 
            label3.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            label3.AutoSize = true;
            label3.Location = new Point(18, 399);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(218, 19);
            label3.TabIndex = 2;
            label3.Text = "Customer Care Internal Notes:";
            // 
            // dgvLifecycleTimeline
            // 
            dgvLifecycleTimeline.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            dgvLifecycleTimeline.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLifecycleTimeline.Location = new Point(18, 64);
            dgvLifecycleTimeline.Margin = new Padding(2);
            dgvLifecycleTimeline.Name = "dgvLifecycleTimeline";
            dgvLifecycleTimeline.RowHeadersWidth = 62;
            dgvLifecycleTimeline.TabIndex = 1;
            // 
            // lblSelectedOrderHint
            // 
            lblSelectedOrderHint.AutoSize = true;
            lblSelectedOrderHint.Location = new Point(18, 22);
            lblSelectedOrderHint.Margin = new Padding(2, 0, 2, 0);
            lblSelectedOrderHint.Name = "lblSelectedOrderHint";
            lblSelectedOrderHint.Size = new Size(226, 19);
            lblSelectedOrderHint.TabIndex = 0;
            lblSelectedOrderHint.Text = "Showing Lifecycle for Order ID:";
            // 
            // OrderHistoryForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(855, 536);
            Controls.Add(tcAccountHistory);
            Margin = new Padding(2);
            Name = "OrderHistoryForm";
            Text = "Account & Order History";
            tcAccountHistory.ResumeLayout(false);
            tbOrderOverview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrderHistoryList).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tbOrderTimeline.ResumeLayout(false);
            tbOrderTimeline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLifecycleTimeline).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcAccountHistory;
        private TabPage tbOrderOverview;
        private TabPage tbOrderTimeline;
        private GroupBox groupBox1;
        private Label labelCOID;
        private Label label1;
        private Button btnResetHistory;
        private Button btnSearchHistory;
        private ComboBox cmbFinalStatusFilter;
        private Label label2;
        private TextBox txtYearFilter;
        private TextBox txtSearchQuery;
        private Button btnDownloadInvoice;
        private Button btnViewFullDetails;
        private DataGridView dgvOrderHistoryList;
        private TextBox txtInternalNotes;
        private Label label3;
        private DataGridView dgvLifecycleTimeline;
        private Label lblSelectedOrderHint;
    }
}