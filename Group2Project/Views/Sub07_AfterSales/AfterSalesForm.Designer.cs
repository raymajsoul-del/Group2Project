namespace Group2Project.Views.Sub07_AfterSales
{
    partial class AfterSalesForm
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
            tcAfterSalesManager = new TabControl();
            tbLogNewServiceCase = new TabPage();
            groupBox2 = new GroupBox();
            btnLogCase = new Button();
            txtCaseDescription = new TextBox();
            label4 = new Label();
            cmbCaseType = new ComboBox();
            label3 = new Label();
            groupBox1 = new GroupBox();
            btnVerifyOrder = new Button();
            txtVerifyCustID = new TextBox();
            txtVerifyOrderID = new TextBox();
            label2 = new Label();
            label1 = new Label();
            tbMangeTrackCases = new TabPage();
            btnMarkResolved = new Button();
            label7 = new Label();
            btnAssignTech = new Button();
            cmbTechnician = new ComboBox();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            btnRefreshCases = new Button();
            btnSearchCase = new Button();
            cmbCaseStatusFilter = new ComboBox();
            label5 = new Label();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            tcAfterSalesManager.SuspendLayout();
            tbLogNewServiceCase.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tbMangeTrackCases.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tcAfterSalesManager
            // 
            tcAfterSalesManager.Controls.Add(tbLogNewServiceCase);
            tcAfterSalesManager.Controls.Add(tbMangeTrackCases);
            tcAfterSalesManager.Location = new Point(12, 12);
            tcAfterSalesManager.Name = "tcAfterSalesManager";
            tcAfterSalesManager.SelectedIndex = 0;
            tcAfterSalesManager.Size = new Size(904, 570);
            tcAfterSalesManager.TabIndex = 0;
            // 
            // tbLogNewServiceCase
            // 
            tbLogNewServiceCase.Controls.Add(groupBox2);
            tbLogNewServiceCase.Controls.Add(groupBox1);
            tbLogNewServiceCase.Location = new Point(4, 32);
            tbLogNewServiceCase.Name = "tbLogNewServiceCase";
            tbLogNewServiceCase.Padding = new Padding(3);
            tbLogNewServiceCase.Size = new Size(896, 534);
            tbLogNewServiceCase.TabIndex = 0;
            tbLogNewServiceCase.Text = "Log New Service Case";
            tbLogNewServiceCase.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnLogCase);
            groupBox2.Controls.Add(txtCaseDescription);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(cmbCaseType);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(518, 20);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(372, 508);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Case Details";
            // 
            // btnLogCase
            // 
            btnLogCase.BackColor = Color.DarkSeaGreen;
            btnLogCase.Cursor = Cursors.Hand;
            btnLogCase.FlatStyle = FlatStyle.Flat;
            btnLogCase.Location = new Point(97, 364);
            btnLogCase.Name = "btnLogCase";
            btnLogCase.Size = new Size(207, 85);
            btnLogCase.TabIndex = 4;
            btnLogCase.Text = "Register Service Case";
            btnLogCase.UseVisualStyleBackColor = false;
            // 
            // txtCaseDescription
            // 
            txtCaseDescription.Location = new Point(17, 154);
            txtCaseDescription.Multiline = true;
            txtCaseDescription.Name = "txtCaseDescription";
            txtCaseDescription.Size = new Size(334, 161);
            txtCaseDescription.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 107);
            label4.Name = "label4";
            label4.Size = new Size(159, 23);
            label4.TabIndex = 2;
            label4.Text = "Issue Description:";
            // 
            // cmbCaseType
            // 
            cmbCaseType.Cursor = Cursors.Hand;
            cmbCaseType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCaseType.FlatStyle = FlatStyle.Flat;
            cmbCaseType.FormattingEnabled = true;
            cmbCaseType.Items.AddRange(new object[] { "Furniture Defect", "Wrong Item Delivered", "Warranty Repair", "Return Request" });
            cmbCaseType.Location = new Point(122, 40);
            cmbCaseType.Name = "cmbCaseType";
            cmbCaseType.Size = new Size(182, 31);
            cmbCaseType.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 43);
            label3.Name = "label3";
            label3.Size = new Size(99, 23);
            label3.TabIndex = 0;
            label3.Text = "Case Type:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnVerifyOrder);
            groupBox1.Controls.Add(txtVerifyCustID);
            groupBox1.Controls.Add(txtVerifyOrderID);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(15, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(468, 508);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Order Verification";
            // 
            // btnVerifyOrder
            // 
            btnVerifyOrder.BackColor = Color.LightGray;
            btnVerifyOrder.Cursor = Cursors.Hand;
            btnVerifyOrder.FlatStyle = FlatStyle.Flat;
            btnVerifyOrder.Location = new Point(29, 174);
            btnVerifyOrder.Name = "btnVerifyOrder";
            btnVerifyOrder.Size = new Size(244, 70);
            btnVerifyOrder.TabIndex = 4;
            btnVerifyOrder.Text = "Verify Warranty Status";
            btnVerifyOrder.UseVisualStyleBackColor = false;
            // 
            // txtVerifyCustID
            // 
            txtVerifyCustID.Cursor = Cursors.IBeam;
            txtVerifyCustID.Location = new Point(156, 104);
            txtVerifyCustID.Name = "txtVerifyCustID";
            txtVerifyCustID.Size = new Size(150, 30);
            txtVerifyCustID.TabIndex = 3;
            txtVerifyCustID.TextChanged += textBox2_TextChanged;
            // 
            // txtVerifyOrderID
            // 
            txtVerifyOrderID.Cursor = Cursors.IBeam;
            txtVerifyOrderID.Location = new Point(123, 43);
            txtVerifyOrderID.Name = "txtVerifyOrderID";
            txtVerifyOrderID.Size = new Size(150, 30);
            txtVerifyOrderID.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 111);
            label2.Name = "label2";
            label2.Size = new Size(121, 23);
            label2.TabIndex = 1;
            label2.Text = "Customer ID:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 46);
            label1.Name = "label1";
            label1.Size = new Size(88, 23);
            label1.TabIndex = 0;
            label1.Text = "Order ID:";
            // 
            // tbMangeTrackCases
            // 
            tbMangeTrackCases.Controls.Add(btnMarkResolved);
            tbMangeTrackCases.Controls.Add(label7);
            tbMangeTrackCases.Controls.Add(btnAssignTech);
            tbMangeTrackCases.Controls.Add(cmbTechnician);
            tbMangeTrackCases.Controls.Add(label6);
            tbMangeTrackCases.Controls.Add(dataGridView1);
            tbMangeTrackCases.Controls.Add(btnRefreshCases);
            tbMangeTrackCases.Controls.Add(btnSearchCase);
            tbMangeTrackCases.Controls.Add(cmbCaseStatusFilter);
            tbMangeTrackCases.Controls.Add(label5);
            tbMangeTrackCases.Location = new Point(4, 32);
            tbMangeTrackCases.Name = "tbMangeTrackCases";
            tbMangeTrackCases.Padding = new Padding(3);
            tbMangeTrackCases.Size = new Size(896, 534);
            tbMangeTrackCases.TabIndex = 1;
            tbMangeTrackCases.Text = "Manage & Track Cases";
            tbMangeTrackCases.UseVisualStyleBackColor = true;
            // 
            // btnMarkResolved
            // 
            btnMarkResolved.BackColor = Color.LightGreen;
            btnMarkResolved.Cursor = Cursors.Hand;
            btnMarkResolved.FlatStyle = FlatStyle.Flat;
            btnMarkResolved.Location = new Point(604, 350);
            btnMarkResolved.Name = "btnMarkResolved";
            btnMarkResolved.Size = new Size(216, 90);
            btnMarkResolved.TabIndex = 9;
            btnMarkResolved.Text = "Mark as Resolved";
            btnMarkResolved.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(510, 266);
            label7.Name = "label7";
            label7.Size = new Size(378, 23);
            label7.TabIndex = 8;
            label7.Text = "----------------------------------------------";
            // 
            // btnAssignTech
            // 
            btnAssignTech.BackColor = Color.DarkOrange;
            btnAssignTech.Cursor = Cursors.Hand;
            btnAssignTech.FlatStyle = FlatStyle.Flat;
            btnAssignTech.Location = new Point(692, 156);
            btnAssignTech.Name = "btnAssignTech";
            btnAssignTech.Size = new Size(182, 34);
            btnAssignTech.TabIndex = 7;
            btnAssignTech.Text = "Assign & Dispatch";
            btnAssignTech.UseVisualStyleBackColor = false;
            // 
            // cmbTechnician
            // 
            cmbTechnician.Cursor = Cursors.IBeam;
            cmbTechnician.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTechnician.FlatStyle = FlatStyle.Flat;
            cmbTechnician.FormattingEnabled = true;
            cmbTechnician.Items.AddRange(new object[] { "T001", "T002" });
            cmbTechnician.Location = new Point(692, 89);
            cmbTechnician.Name = "cmbTechnician";
            cmbTechnician.Size = new Size(182, 31);
            cmbTechnician.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(521, 89);
            label6.Name = "label6";
            label6.Size = new Size(165, 23);
            label6.TabIndex = 5;
            label6.Text = "Assign Technician:";
            label6.Click += label6_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(22, 89);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(482, 426);
            dataGridView1.TabIndex = 4;
            // 
            // btnRefreshCases
            // 
            btnRefreshCases.Location = new Point(457, 24);
            btnRefreshCases.Name = "btnRefreshCases";
            btnRefreshCases.Size = new Size(112, 34);
            btnRefreshCases.TabIndex = 3;
            btnRefreshCases.Text = "Refresh";
            btnRefreshCases.UseVisualStyleBackColor = true;
            btnRefreshCases.Click += btnRefreshCases_Click;
            // 
            // btnSearchCase
            // 
            btnSearchCase.Location = new Point(328, 24);
            btnSearchCase.Name = "btnSearchCase";
            btnSearchCase.Size = new Size(112, 34);
            btnSearchCase.TabIndex = 2;
            btnSearchCase.Text = "Search";
            btnSearchCase.UseVisualStyleBackColor = true;
            btnSearchCase.Click += btnSearchCase_Click;
            // 
            // cmbCaseStatusFilter
            // 
            cmbCaseStatusFilter.Cursor = Cursors.IBeam;
            cmbCaseStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCaseStatusFilter.FlatStyle = FlatStyle.Flat;
            cmbCaseStatusFilter.FormattingEnabled = true;
            cmbCaseStatusFilter.Items.AddRange(new object[] { "Pending", "Technician Assigned", "In Progress", "Resolved", "Closed" });
            cmbCaseStatusFilter.Location = new Point(140, 24);
            cmbCaseStatusFilter.Name = "cmbCaseStatusFilter";
            cmbCaseStatusFilter.Size = new Size(182, 31);
            cmbCaseStatusFilter.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 24);
            label5.Name = "label5";
            label5.Size = new Size(112, 23);
            label5.TabIndex = 0;
            label5.Text = "Case Status:";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 572);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(928, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            // 
            // AfterSalesForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(928, 594);
            Controls.Add(statusStrip1);
            Controls.Add(tcAfterSalesManager);
            Name = "AfterSalesForm";
            Text = "Customer After-Sales & Warranty Management System";
            Load += AfterSalesForm_Load_1;
            tcAfterSalesManager.ResumeLayout(false);
            tbLogNewServiceCase.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tbMangeTrackCases.ResumeLayout(false);
            tbMangeTrackCases.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tcAfterSalesManager;
        private TabPage tbLogNewServiceCase;
        private TabPage tbMangeTrackCases;
        private GroupBox groupBox1;
        private TextBox txtVerifyCustID;
        private TextBox txtVerifyOrderID;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private Label label4;
        private ComboBox cmbCaseType;
        private Label label3;
        private Button btnVerifyOrder;
        private Button btnLogCase;
        private TextBox txtCaseDescription;
        private DataGridView dataGridView1;
        private Button btnRefreshCases;
        private Button btnSearchCase;
        private ComboBox cmbCaseStatusFilter;
        private Label label5;
        private Label label6;
        private Button btnMarkResolved;
        private Label label7;
        private Button btnAssignTech;
        private ComboBox cmbTechnician;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
    }
}