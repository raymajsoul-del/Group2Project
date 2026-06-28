namespace Group2Project.Views.Sub05_Inventory
{
    partial class InventoryForm
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
            tcInventoryManager = new TabControl();
            tbStockStatus = new TabPage();
            groupBox1 = new GroupBox();
            btnRecordInward = new Button();
            textBtxtInwardQtyox2 = new TextBox();
            txtInwardItemID = new TextBox();
            label3 = new Label();
            label2 = new Label();
            dgvStockList = new DataGridView();
            btnRefreshStock = new Button();
            cmbStockCategory = new ComboBox();
            label1 = new Label();
            tbCreateOrder = new TabPage();
            btnSubmitProcurement = new Button();
            txtProcureNotes = new TextBox();
            label8 = new Label();
            groupBox2 = new GroupBox();
            txtProcureCost = new TextBox();
            txtProcureQty = new TextBox();
            cmbMaterialItem = new ComboBox();
            cmbSupplier = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            tbManageOrder = new TabPage();
            btnCancelProcurement = new Button();
            btnEditProcurement = new Button();
            btnUpdateProcStatus = new Button();
            dgvProcurementList = new DataGridView();
            btnRefreshProcList = new Button();
            btnSearchProc = new Button();
            txtSearchProcID = new TextBox();
            label9 = new Label();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            tcInventoryManager.SuspendLayout();
            tbStockStatus.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStockList).BeginInit();
            tbCreateOrder.SuspendLayout();
            groupBox2.SuspendLayout();
            tbManageOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProcurementList).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tcInventoryManager
            // 
            tcInventoryManager.Controls.Add(tbStockStatus);
            tcInventoryManager.Controls.Add(tbCreateOrder);
            tcInventoryManager.Controls.Add(tbManageOrder);
            tcInventoryManager.Dock = DockStyle.Fill;
            tcInventoryManager.Location = new Point(0, 0);
            tcInventoryManager.Name = "tcInventoryManager";
            tcInventoryManager.SelectedIndex = 0;
            tcInventoryManager.TabIndex = 0;
            // 
            // tbStockStatus
            // 
            tbStockStatus.Controls.Add(groupBox1);
            tbStockStatus.Controls.Add(dgvStockList);
            tbStockStatus.Controls.Add(btnRefreshStock);
            tbStockStatus.Controls.Add(cmbStockCategory);
            tbStockStatus.Controls.Add(label1);
            tbStockStatus.Location = new Point(4, 32);
            tbStockStatus.Name = "tbStockStatus";
            tbStockStatus.Padding = new Padding(3);
            tbStockStatus.Size = new Size(896, 534);
            tbStockStatus.TabIndex = 0;
            tbStockStatus.Text = "Stock Status & Inward Goods";
            tbStockStatus.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnRecordInward);
            groupBox1.Controls.Add(textBtxtInwardQtyox2);
            groupBox1.Controls.Add(txtInwardItemID);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(26, 347);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(632, 170);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "StockList";
            // 
            // btnRecordInward
            // 
            btnRecordInward.BackColor = Color.FromArgb(34, 197, 94);
            btnRecordInward.ForeColor = Color.White;
            btnRecordInward.Cursor = Cursors.Hand;
            btnRecordInward.FlatStyle = FlatStyle.Flat;
            btnRecordInward.Location = new Point(425, 130);
            btnRecordInward.Name = "btnRecordInward";
            btnRecordInward.Size = new Size(151, 34);
            btnRecordInward.TabIndex = 4;
            btnRecordInward.Text = "Record Inward";
            btnRecordInward.UseVisualStyleBackColor = false;
            // 
            // textBtxtInwardQtyox2
            // 
            textBtxtInwardQtyox2.Cursor = Cursors.IBeam;
            textBtxtInwardQtyox2.Location = new Point(212, 80);
            textBtxtInwardQtyox2.Name = "textBtxtInwardQtyox2";
            textBtxtInwardQtyox2.Size = new Size(150, 30);
            textBtxtInwardQtyox2.TabIndex = 3;
            // 
            // txtInwardItemID
            // 
            txtInwardItemID.Cursor = Cursors.IBeam;
            txtInwardItemID.Location = new Point(119, 40);
            txtInwardItemID.Name = "txtInwardItemID";
            txtInwardItemID.Size = new Size(150, 30);
            txtInwardItemID.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 80);
            label3.Name = "label3";
            label3.Size = new Size(170, 23);
            label3.TabIndex = 1;
            label3.Text = "Quantity Received:";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 43);
            label2.Name = "label2";
            label2.Size = new Size(77, 23);
            label2.TabIndex = 0;
            label2.Text = "Item ID:";
            // 
            // dgvStockList
            // 
            dgvStockList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStockList.Location = new Point(26, 76);
            dgvStockList.Name = "dgvStockList";
            dgvStockList.RowHeadersWidth = 62;
            dgvStockList.Size = new Size(632, 251);
            dgvStockList.TabIndex = 3;
            // 
            // btnRefreshStock
            // 
            btnRefreshStock.BackColor = Color.FromArgb(147, 51, 234);
            btnRefreshStock.ForeColor = Color.White;
            btnRefreshStock.Cursor = Cursors.Hand;
            btnRefreshStock.FlatStyle = FlatStyle.Flat;
            btnRefreshStock.Location = new Point(385, 26);
            btnRefreshStock.Name = "btnRefreshStock";
            btnRefreshStock.Size = new Size(217, 34);
            btnRefreshStock.TabIndex = 2;
            btnRefreshStock.Text = "Refresh Stock Level";
            btnRefreshStock.UseVisualStyleBackColor = false;
            btnRefreshStock.Click += btnRefreshStock_Click;
            // 
            // cmbStockCategory
            // 
            cmbStockCategory.Cursor = Cursors.IBeam;
            cmbStockCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStockCategory.FlatStyle = FlatStyle.Flat;
            cmbStockCategory.FormattingEnabled = true;
            cmbStockCategory.Items.AddRange(new object[] { "Finished Furniture", "Raw Materials" });
            cmbStockCategory.Location = new Point(175, 23);
            cmbStockCategory.Name = "cmbStockCategory";
            cmbStockCategory.Size = new Size(182, 31);
            cmbStockCategory.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 26);
            label1.Name = "label1";
            label1.Size = new Size(143, 23);
            label1.TabIndex = 0;
            label1.Text = "Stock Category:";
            // 
            // tbCreateOrder
            // 
            tbCreateOrder.Controls.Add(btnSubmitProcurement);
            tbCreateOrder.Controls.Add(txtProcureNotes);
            tbCreateOrder.Controls.Add(label8);
            tbCreateOrder.Controls.Add(groupBox2);
            tbCreateOrder.Location = new Point(4, 32);
            tbCreateOrder.Name = "tbCreateOrder";
            tbCreateOrder.Padding = new Padding(3);
            tbCreateOrder.Size = new Size(896, 534);
            tbCreateOrder.TabIndex = 1;
            tbCreateOrder.Text = "Create Procurement Order";
            tbCreateOrder.UseVisualStyleBackColor = true;
            // 
            // btnSubmitProcurement
            // 
            btnSubmitProcurement.BackColor = Color.FromArgb(147, 51, 234);
            btnSubmitProcurement.ForeColor = Color.White;
            btnSubmitProcurement.Cursor = Cursors.Hand;
            btnSubmitProcurement.FlatStyle = FlatStyle.Flat;
            btnSubmitProcurement.Location = new Point(547, 473);
            btnSubmitProcurement.Name = "btnSubmitProcurement";
            btnSubmitProcurement.Size = new Size(271, 36);
            btnSubmitProcurement.TabIndex = 3;
            btnSubmitProcurement.Text = "Create Procurement Order";
            btnSubmitProcurement.UseVisualStyleBackColor = false;
            // 
            // txtProcureNotes
            // 
            txtProcureNotes.Cursor = Cursors.IBeam;
            txtProcureNotes.Location = new Point(547, 49);
            txtProcureNotes.Multiline = true;
            txtProcureNotes.Name = "txtProcureNotes";
            txtProcureNotes.Size = new Size(271, 396);
            txtProcureNotes.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(547, 23);
            label8.Name = "label8";
            label8.Size = new Size(271, 23);
            label8.TabIndex = 1;
            label8.Text = "Remarks / Special Instructions:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtProcureCost);
            groupBox2.Controls.Add(txtProcureQty);
            groupBox2.Controls.Add(cmbMaterialItem);
            groupBox2.Controls.Add(cmbSupplier);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(20, 27);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(466, 482);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "New Procurement Details";
            // 
            // txtProcureCost
            // 
            txtProcureCost.Location = new Point(252, 197);
            txtProcureCost.Name = "txtProcureCost";
            txtProcureCost.Size = new Size(150, 30);
            txtProcureCost.TabIndex = 7;
            // 
            // txtProcureQty
            // 
            txtProcureQty.Location = new Point(179, 135);
            txtProcureQty.Name = "txtProcureQty";
            txtProcureQty.Size = new Size(150, 30);
            txtProcureQty.TabIndex = 6;
            // 
            // cmbMaterialItem
            // 
            cmbMaterialItem.Cursor = Cursors.Hand;
            cmbMaterialItem.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaterialItem.FlatStyle = FlatStyle.Flat;
            cmbMaterialItem.FormattingEnabled = true;
            cmbMaterialItem.Items.AddRange(new object[] { "RM-W01 (Oak Wood Panel)", "RM-W02 (Pine Wood Panel)", "RM-L01 (Black Leather Roll)", "RM-M01 (Steel Screws Pack)", "RM-G01 (Tempered Glass 5mm)" });
            cmbMaterialItem.Location = new Point(164, 89);
            cmbMaterialItem.Name = "cmbMaterialItem";
            cmbMaterialItem.Size = new Size(182, 31);
            cmbMaterialItem.TabIndex = 5;
            // 
            // cmbSupplier
            // 
            cmbSupplier.Cursor = Cursors.Hand;
            cmbSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSupplier.FlatStyle = FlatStyle.Flat;
            cmbSupplier.FormattingEnabled = true;
            cmbSupplier.Items.AddRange(new object[] { "S001 - Timberland Woodworks", "S002 - Premium Leather Co.", "S003 - Steel Fabricators Inc.", "S004 - Glass & Mirror Supplies" });
            cmbSupplier.Location = new Point(175, 47);
            cmbSupplier.Name = "cmbSupplier";
            cmbSupplier.Size = new Size(182, 31);
            cmbSupplier.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(29, 197);
            label7.Name = "label7";
            label7.Size = new Size(217, 23);
            label7.TabIndex = 3;
            label7.Text = "Estimated Total Cost ($):";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 135);
            label6.Name = "label6";
            label6.Size = new Size(144, 23);
            label6.TabIndex = 2;
            label6.Text = "Order Quantity:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 89);
            label5.Name = "label5";
            label5.Size = new Size(129, 23);
            label5.TabIndex = 1;
            label5.Text = "Material Item:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 47);
            label4.Name = "label4";
            label4.Size = new Size(140, 23);
            label4.TabIndex = 0;
            label4.Text = "Select Supplier:";
            label4.Click += label4_Click;
            // 
            // tbManageOrder
            // 
            tbManageOrder.Controls.Add(btnCancelProcurement);
            tbManageOrder.Controls.Add(btnEditProcurement);
            tbManageOrder.Controls.Add(btnUpdateProcStatus);
            tbManageOrder.Controls.Add(dgvProcurementList);
            tbManageOrder.Controls.Add(btnRefreshProcList);
            tbManageOrder.Controls.Add(btnSearchProc);
            tbManageOrder.Controls.Add(txtSearchProcID);
            tbManageOrder.Controls.Add(label9);
            tbManageOrder.Location = new Point(4, 32);
            tbManageOrder.Name = "tbManageOrder";
            tbManageOrder.Padding = new Padding(3);
            tbManageOrder.Size = new Size(896, 534);
            tbManageOrder.TabIndex = 2;
            tbManageOrder.Text = "Manage Procurement Orders";
            tbManageOrder.UseVisualStyleBackColor = true;
            // 
            // btnCancelProcurement
            // 
            btnCancelProcurement.BackColor = Color.FromArgb(239, 68, 68);
            btnCancelProcurement.ForeColor = Color.White;
            btnCancelProcurement.Cursor = Cursors.Hand;
            btnCancelProcurement.FlatStyle = FlatStyle.Flat;
            btnCancelProcurement.Location = new Point(637, 359);
            btnCancelProcurement.Name = "btnCancelProcurement";
            btnCancelProcurement.Size = new Size(240, 70);
            btnCancelProcurement.TabIndex = 7;
            btnCancelProcurement.Text = "Cancel Procurement";
            btnCancelProcurement.UseVisualStyleBackColor = false;
            // 
            // btnEditProcurement
            // 
            btnEditProcurement.BackColor = Color.FromArgb(168, 85, 247);
            btnEditProcurement.ForeColor = Color.White;
            btnEditProcurement.Cursor = Cursors.Hand;
            btnEditProcurement.FlatStyle = FlatStyle.Flat;
            btnEditProcurement.Location = new Point(661, 226);
            btnEditProcurement.Name = "btnEditProcurement";
            btnEditProcurement.Size = new Size(199, 66);
            btnEditProcurement.TabIndex = 6;
            btnEditProcurement.Text = "Modify Order Details";
            btnEditProcurement.UseVisualStyleBackColor = false;
            // 
            // btnUpdateProcStatus
            // 
            btnUpdateProcStatus.BackColor = Color.FromArgb(34, 197, 94);
            btnUpdateProcStatus.ForeColor = Color.White;
            btnUpdateProcStatus.Cursor = Cursors.Hand;
            btnUpdateProcStatus.FlatStyle = FlatStyle.Flat;
            btnUpdateProcStatus.Location = new Point(674, 117);
            btnUpdateProcStatus.Name = "btnUpdateProcStatus";
            btnUpdateProcStatus.Size = new Size(169, 58);
            btnUpdateProcStatus.TabIndex = 5;
            btnUpdateProcStatus.Text = "Update Status";
            btnUpdateProcStatus.UseVisualStyleBackColor = false;
            // 
            // dgvProcurementList
            // 
            dgvProcurementList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProcurementList.Location = new Point(27, 81);
            dgvProcurementList.Name = "dgvProcurementList";
            dgvProcurementList.RowHeadersWidth = 62;
            dgvProcurementList.Size = new Size(590, 437);
            dgvProcurementList.TabIndex = 4;
            // 
            // btnRefreshProcList
            // 
            btnRefreshProcList.BackColor = Color.FromArgb(147, 51, 234);
            btnRefreshProcList.ForeColor = Color.White;
            btnRefreshProcList.Cursor = Cursors.Hand;
            btnRefreshProcList.FlatStyle = FlatStyle.Flat;
            btnRefreshProcList.Location = new Point(664, 18);
            btnRefreshProcList.Name = "btnRefreshProcList";
            btnRefreshProcList.Size = new Size(112, 34);
            btnRefreshProcList.TabIndex = 3;
            btnRefreshProcList.Text = "Refresh";
            btnRefreshProcList.UseVisualStyleBackColor = false;
            btnRefreshProcList.Click += btnRefreshProcList_Click;
            // 
            // btnSearchProc
            // 
            btnSearchProc.BackColor = Color.FromArgb(168, 85, 247);
            btnSearchProc.ForeColor = Color.White;
            btnSearchProc.Cursor = Cursors.Hand;
            btnSearchProc.FlatStyle = FlatStyle.Flat;
            btnSearchProc.Location = new Point(532, 18);
            btnSearchProc.Name = "btnSearchProc";
            btnSearchProc.Size = new Size(112, 34);
            btnSearchProc.TabIndex = 2;
            btnSearchProc.Text = "Search";
            btnSearchProc.UseVisualStyleBackColor = false;
            btnSearchProc.Click += btnSearchProc_Click;
            // 
            // txtSearchProcID
            // 
            txtSearchProcID.Cursor = Cursors.IBeam;
            txtSearchProcID.Location = new Point(357, 18);
            txtSearchProcID.Name = "txtSearchProcID";
            txtSearchProcID.Size = new Size(150, 30);
            txtSearchProcID.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(27, 21);
            label9.Name = "label9";
            label9.Size = new Size(324, 23);
            label9.TabIndex = 0;
            label9.Text = "Search by Procurement ID / Supplier:";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 566);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(928, 28);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 21);
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(928, 594);
            Controls.Add(statusStrip1);
            Controls.Add(tcInventoryManager);
            Name = "InventoryForm";
            Text = "Inventory Management";
            tcInventoryManager.ResumeLayout(false);
            tbStockStatus.ResumeLayout(false);
            tbStockStatus.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStockList).EndInit();
            tbCreateOrder.ResumeLayout(false);
            tbCreateOrder.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tbManageOrder.ResumeLayout(false);
            tbManageOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProcurementList).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tcInventoryManager;
        private TabPage tbStockStatus;
        private TabPage tbCreateOrder;
        private Button btnRefreshStock;
        private ComboBox cmbStockCategory;
        private Label label1;
        private TabPage tbManageOrder;
        private DataGridView dgvStockList;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Button btnRecordInward;
        private TextBox textBtxtInwardQtyox2;
        private TextBox txtInwardItemID;
        private GroupBox groupBox2;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtProcureCost;
        private TextBox txtProcureQty;
        private ComboBox cmbMaterialItem;
        private ComboBox cmbSupplier;
        private Button btnSubmitProcurement;
        private TextBox txtProcureNotes;
        private Label label8;
        private Button btnRefreshProcList;
        private Button btnSearchProc;
        private TextBox txtSearchProcID;
        private Label label9;
        private Button btnCancelProcurement;
        private Button btnEditProcurement;
        private Button btnUpdateProcStatus;
        private DataGridView dgvProcurementList;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
    }
}