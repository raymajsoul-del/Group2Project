namespace Group2Project.Views.Sub04_Production
{
    partial class ProductionManagementForm
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
            tcProductionManager = new TabControl();
            tbTaskBoard = new TabPage();
            btnReportDefect = new Button();
            btnViewBlueprint = new Button();
            btnUpdateProgress = new Button();
            dgvProductionTasks = new DataGridView();
            cmbTaskStatus = new ComboBox();
            label1 = new Label();
            tbMaterial = new TabPage();
            btnRefreshRequests = new Button();
            dgvMaterialRequests = new DataGridView();
            label5 = new Label();
            groupBox1 = new GroupBox();
            btnSubmitRequest = new Button();
            cmbUrgency = new ComboBox();
            label4 = new Label();
            txtRequestQty = new TextBox();
            label3 = new Label();
            cmbRequestMaterial = new ComboBox();
            label2 = new Label();
            lblStatus = new ToolStripStatusLabel();
            statusStrip1 = new StatusStrip();
            tcProductionManager.SuspendLayout();
            tbTaskBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductionTasks).BeginInit();
            tbMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaterialRequests).BeginInit();
            groupBox1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tcProductionManager
            // 
            tcProductionManager.Controls.Add(tbTaskBoard);
            tcProductionManager.Controls.Add(tbMaterial);
            tcProductionManager.Dock = DockStyle.Fill;
            tcProductionManager.Location = new Point(0, 0);
            tcProductionManager.Name = "tcProductionManager";
            tcProductionManager.SelectedIndex = 0;
            tcProductionManager.TabIndex = 0;
            // 
            // tbTaskBoard
            // 
            tbTaskBoard.Controls.Add(statusStrip1);
            tbTaskBoard.Controls.Add(btnReportDefect);
            tbTaskBoard.Controls.Add(btnViewBlueprint);
            tbTaskBoard.Controls.Add(btnUpdateProgress);
            tbTaskBoard.Controls.Add(dgvProductionTasks);
            tbTaskBoard.Controls.Add(cmbTaskStatus);
            tbTaskBoard.Controls.Add(label1);
            tbTaskBoard.Location = new Point(4, 32);
            tbTaskBoard.Name = "tbTaskBoard";
            tbTaskBoard.Padding = new Padding(3);
            tbTaskBoard.TabIndex = 0;
            tbTaskBoard.Text = "Production Task Board";
            tbTaskBoard.UseVisualStyleBackColor = true;
            // 
            // btnReportDefect
            // 
            btnReportDefect.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            btnReportDefect.BackColor = Color.Salmon;
            btnReportDefect.Cursor = Cursors.Hand;
            btnReportDefect.FlatStyle = FlatStyle.Flat;
            btnReportDefect.ForeColor = Color.Black;
            btnReportDefect.Location = new Point(618, 461);
            btnReportDefect.Name = "btnReportDefect";
            btnReportDefect.Size = new Size(227, 34);
            btnReportDefect.TabIndex = 5;
            btnReportDefect.Text = "Report Defect / Issue";
            btnReportDefect.UseVisualStyleBackColor = false;
            // 
            // btnViewBlueprint
            // 
            btnViewBlueprint.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            btnViewBlueprint.Cursor = Cursors.Hand;
            btnViewBlueprint.FlatStyle = FlatStyle.Flat;
            btnViewBlueprint.Location = new Point(306, 461);
            btnViewBlueprint.Name = "btnViewBlueprint";
            btnViewBlueprint.Size = new Size(261, 34);
            btnViewBlueprint.TabIndex = 4;
            btnViewBlueprint.Text = "View Custom Blueprint";
            btnViewBlueprint.UseVisualStyleBackColor = true;
            // 
            // btnUpdateProgress
            // 
            btnUpdateProgress.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            btnUpdateProgress.Cursor = Cursors.Hand;
            btnUpdateProgress.FlatStyle = FlatStyle.Flat;
            btnUpdateProgress.Location = new Point(20, 461);
            btnUpdateProgress.Name = "btnUpdateProgress";
            btnUpdateProgress.Size = new Size(262, 34);
            btnUpdateProgress.TabIndex = 3;
            btnUpdateProgress.Text = "Update Production Status";
            btnUpdateProgress.UseVisualStyleBackColor = true;
            // 
            // dgvProductionTasks
            // 
            dgvProductionTasks.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            dgvProductionTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductionTasks.Location = new Point(20, 67);
            dgvProductionTasks.Name = "dgvProductionTasks";
            dgvProductionTasks.RowHeadersWidth = 62;
            dgvProductionTasks.TabIndex = 2;
            // 
            // cmbTaskStatus
            // 
            cmbTaskStatus.Cursor = Cursors.Hand;
            cmbTaskStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTaskStatus.FlatStyle = FlatStyle.Flat;
            cmbTaskStatus.FormattingEnabled = true;
            cmbTaskStatus.Items.AddRange(new object[] { "Pending", "In Production", "Quality Check", "Completed" });
            cmbTaskStatus.Location = new Point(215, 16);
            cmbTaskStatus.Name = "cmbTaskStatus";
            cmbTaskStatus.Size = new Size(182, 31);
            cmbTaskStatus.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 16);
            label1.Name = "label1";
            label1.Size = new Size(183, 23);
            label1.TabIndex = 0;
            label1.Text = "Filter by Task Status:";
            // 
            // tbMaterial
            // 
            tbMaterial.Controls.Add(btnRefreshRequests);
            tbMaterial.Controls.Add(dgvMaterialRequests);
            tbMaterial.Controls.Add(label5);
            tbMaterial.Controls.Add(groupBox1);
            tbMaterial.Location = new Point(4, 32);
            tbMaterial.Name = "tbMaterial";
            tbMaterial.Padding = new Padding(3);
            tbMaterial.TabIndex = 1;
            tbMaterial.Text = "Material Request to Inventory";
            tbMaterial.UseVisualStyleBackColor = true;
            // 
            // btnRefreshRequests
            // 
            btnRefreshRequests.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            btnRefreshRequests.Location = new Point(602, 106);
            btnRefreshRequests.Name = "btnRefreshRequests";
            btnRefreshRequests.Size = new Size(112, 34);
            btnRefreshRequests.TabIndex = 3;
            btnRefreshRequests.Text = "Refresh";
            btnRefreshRequests.UseVisualStyleBackColor = true;
            btnRefreshRequests.Click += btnRefreshRequests_Click;
            // 
            // dgvMaterialRequests
            // 
            dgvMaterialRequests.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            dgvMaterialRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaterialRequests.Location = new Point(475, 187);
            dgvMaterialRequests.Name = "dgvMaterialRequests";
            dgvMaterialRequests.RowHeadersWidth = 62;
            dgvMaterialRequests.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(502, 54);
            label5.Name = "label5";
            label5.Size = new Size(288, 23);
            label5.TabIndex = 1;
            label5.Text = "Material Request History & Status:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSubmitRequest);
            groupBox1.Controls.Add(cmbUrgency);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtRequestQty);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cmbRequestMaterial);
            groupBox1.Controls.Add(label2);
            groupBox1.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left)));
            groupBox1.Location = new Point(28, 22);
            groupBox1.Name = "groupBox1";
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Create Material Request";
            // 
            // btnSubmitRequest
            // 
            btnSubmitRequest.BackColor = Color.Turquoise;
            btnSubmitRequest.Cursor = Cursors.Hand;
            btnSubmitRequest.FlatStyle = FlatStyle.Flat;
            btnSubmitRequest.Location = new Point(80, 315);
            btnSubmitRequest.Name = "btnSubmitRequest";
            btnSubmitRequest.Size = new Size(231, 110);
            btnSubmitRequest.TabIndex = 6;
            btnSubmitRequest.Text = "Submit Material Request";
            btnSubmitRequest.UseVisualStyleBackColor = false;
            // 
            // cmbUrgency
            // 
            cmbUrgency.Cursor = Cursors.Hand;
            cmbUrgency.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUrgency.FlatStyle = FlatStyle.Flat;
            cmbUrgency.FormattingEnabled = true;
            cmbUrgency.Items.AddRange(new object[] { "Normal", "High", "Critical" });
            cmbUrgency.Location = new Point(159, 165);
            cmbUrgency.Name = "cmbUrgency";
            cmbUrgency.Size = new Size(182, 31);
            cmbUrgency.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 165);
            label4.Name = "label4";
            label4.Size = new Size(132, 23);
            label4.TabIndex = 4;
            label4.Text = "Urgency Level:";
            label4.Click += label4_Click;
            // 
            // txtRequestQty
            // 
            txtRequestQty.Cursor = Cursors.IBeam;
            txtRequestQty.Location = new Point(207, 95);
            txtRequestQty.Name = "txtRequestQty";
            txtRequestQty.Size = new Size(150, 30);
            txtRequestQty.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 95);
            label3.Name = "label3";
            label3.Size = new Size(171, 23);
            label3.TabIndex = 2;
            label3.Text = "Quantity Required:";
            label3.Click += label3_Click;
            // 
            // cmbRequestMaterial
            // 
            cmbRequestMaterial.Cursor = Cursors.Hand;
            cmbRequestMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRequestMaterial.FlatStyle = FlatStyle.Flat;
            cmbRequestMaterial.FormattingEnabled = true;
            cmbRequestMaterial.Items.AddRange(new object[] { "RM-W01", "RM-W02", "RM-L01", "RM-M01", "RM-G01" });
            cmbRequestMaterial.Location = new Point(207, 32);
            cmbRequestMaterial.Name = "cmbRequestMaterial";
            cmbRequestMaterial.Size = new Size(182, 31);
            cmbRequestMaterial.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 32);
            label2.Name = "label2";
            label2.Size = new Size(180, 23);
            label2.TabIndex = 0;
            label2.Text = "Requested Material:";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 21);
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(3, 503);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(890, 28);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // ProductionManagementForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(928, 594);
            Controls.Add(tcProductionManager);
            Name = "ProductionManagementForm";
            Text = "Production Management";
            tcProductionManager.ResumeLayout(false);
            tbTaskBoard.ResumeLayout(false);
            tbTaskBoard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductionTasks).EndInit();
            tbMaterial.ResumeLayout(false);
            tbMaterial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaterialRequests).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcProductionManager;
        private TabPage tbTaskBoard;
        private TabPage tbMaterial;
        private Button btnReportDefect;
        private Button btnViewBlueprint;
        private Button btnUpdateProgress;
        private DataGridView dgvProductionTasks;
        private ComboBox cmbTaskStatus;
        private Label label1;
        private GroupBox groupBox1;
        private ComboBox cmbRequestMaterial;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtRequestQty;
        private ComboBox cmbUrgency;
        private Button btnSubmitRequest;
        private Button btnRefreshRequests;
        private DataGridView dgvMaterialRequests;
        private Label label5;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
    }
}