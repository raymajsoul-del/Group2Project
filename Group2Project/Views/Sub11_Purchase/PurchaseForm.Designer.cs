namespace Group2Project.Views.Sub11_Purchase
{
    partial class PurchaseForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tcPurchaseManager = new System.Windows.Forms.TabControl();
            this.tbPurchaseOrders = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPrintPO = new System.Windows.Forms.Button();
            this.btnCancelPO = new System.Windows.Forms.Button();
            this.btnApprovePO = new System.Windows.Forms.Button();
            this.dgvPurchaseOrders = new System.Windows.Forms.DataGridView();
            this.btnRefreshPO = new System.Windows.Forms.Button();
            this.txtSearchPO = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbCreatePO = new System.Windows.Forms.TabPage();
            this.btnCreatePO = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvPOItems = new System.Windows.Forms.DataGridView();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPOID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tcPurchaseManager.SuspendLayout();
            this.tbPurchaseOrders.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseOrders)).BeginInit();
            this.tbCreatePO.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOItems)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPurchaseManager
            // 
            this.tcPurchaseManager.Controls.Add(this.tbPurchaseOrders);
            this.tcPurchaseManager.Controls.Add(this.tbCreatePO);
            this.tcPurchaseManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPurchaseManager.Location = new System.Drawing.Point(0, 0);
            this.tcPurchaseManager.Name = "tcPurchaseManager";
            this.tcPurchaseManager.SelectedIndex = 0;
            this.tcPurchaseManager.Size = new System.Drawing.Size(922, 562);
            this.tcPurchaseManager.TabIndex = 0;
            // 
            // tbPurchaseOrders
            // 
            this.tbPurchaseOrders.Controls.Add(this.groupBox3);
            this.tbPurchaseOrders.Controls.Add(this.dgvPurchaseOrders);
            this.tbPurchaseOrders.Controls.Add(this.btnRefreshPO);
            this.tbPurchaseOrders.Controls.Add(this.txtSearchPO);
            this.tbPurchaseOrders.Controls.Add(this.label10);
            this.tbPurchaseOrders.Location = new System.Drawing.Point(4, 32);
            this.tbPurchaseOrders.Name = "tbPurchaseOrders";
            this.tbPurchaseOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tbPurchaseOrders.Size = new System.Drawing.Size(914, 526);
            this.tbPurchaseOrders.TabIndex = 0;
            this.tbPurchaseOrders.Text = "Purchase Orders";
            this.tbPurchaseOrders.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnPrintPO);
            this.groupBox3.Controls.Add(this.btnCancelPO);
            this.groupBox3.Controls.Add(this.btnApprovePO);
            this.groupBox3.Location = new System.Drawing.Point(21, 447);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(879, 73);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Actions";
            // 
            // btnPrintPO
            // 
            this.btnPrintPO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(51)))), ((int)(((byte)(234)))));
            this.btnPrintPO.ForeColor = System.Drawing.Color.White;
            this.btnPrintPO.Location = new System.Drawing.Point(598, 23);
            this.btnPrintPO.Name = "btnPrintPO";
            this.btnPrintPO.Size = new System.Drawing.Size(146, 34);
            this.btnPrintPO.TabIndex = 2;
            this.btnPrintPO.Text = "Print PO";
            this.btnPrintPO.UseVisualStyleBackColor = false;
            // 
            // btnCancelPO
            // 
            this.btnCancelPO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnCancelPO.ForeColor = System.Drawing.Color.White;
            this.btnCancelPO.Location = new System.Drawing.Point(360, 23);
            this.btnCancelPO.Name = "btnCancelPO";
            this.btnCancelPO.Size = new System.Drawing.Size(146, 34);
            this.btnCancelPO.TabIndex = 1;
            this.btnCancelPO.Text = "Cancel PO";
            this.btnCancelPO.UseVisualStyleBackColor = false;
            // 
            // btnApprovePO
            // 
            this.btnApprovePO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnApprovePO.ForeColor = System.Drawing.Color.White;
            this.btnApprovePO.Location = new System.Drawing.Point(121, 23);
            this.btnApprovePO.Name = "btnApprovePO";
            this.btnApprovePO.Size = new System.Drawing.Size(146, 34);
            this.btnApprovePO.TabIndex = 0;
            this.btnApprovePO.Text = "Approve PO";
            this.btnApprovePO.UseVisualStyleBackColor = false;
            // 
            // dgvPurchaseOrders
            // 
            this.dgvPurchaseOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseOrders.Location = new System.Drawing.Point(21, 76);
            this.dgvPurchaseOrders.Name = "dgvPurchaseOrders";
            this.dgvPurchaseOrders.RowHeadersWidth = 62;
            this.dgvPurchaseOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchaseOrders.Size = new System.Drawing.Size(879, 349);
            this.dgvPurchaseOrders.TabIndex = 3;
            // 
            // btnRefreshPO
            // 
            this.btnRefreshPO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(51)))), ((int)(((byte)(234)))));
            this.btnRefreshPO.ForeColor = System.Drawing.Color.White;
            this.btnRefreshPO.Location = new System.Drawing.Point(683, 23);
            this.btnRefreshPO.Name = "btnRefreshPO";
            this.btnRefreshPO.Size = new System.Drawing.Size(217, 34);
            this.btnRefreshPO.TabIndex = 2;
            this.btnRefreshPO.Text = "Refresh";
            this.btnRefreshPO.UseVisualStyleBackColor = false;
            // 
            // txtSearchPO
            // 
            this.txtSearchPO.Location = new System.Drawing.Point(219, 26);
            this.txtSearchPO.Name = "txtSearchPO";
            this.txtSearchPO.Size = new System.Drawing.Size(438, 30);
            this.txtSearchPO.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(192, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "Search Purchase Order:";
            // 
            // tbCreatePO
            // 
            this.tbCreatePO.Controls.Add(this.btnCreatePO);
            this.tbCreatePO.Controls.Add(this.groupBox1);
            this.tbCreatePO.Location = new System.Drawing.Point(4, 32);
            this.tbCreatePO.Name = "tbCreatePO";
            this.tbCreatePO.Padding = new System.Windows.Forms.Padding(3);
            this.tbCreatePO.Size = new System.Drawing.Size(914, 526);
            this.tbCreatePO.TabIndex = 1;
            this.tbCreatePO.Text = "Create Purchase Order";
            this.tbCreatePO.UseVisualStyleBackColor = true;
            // 
            // btnCreatePO
            // 
            this.btnCreatePO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(51)))), ((int)(((byte)(234)))));
            this.btnCreatePO.ForeColor = System.Drawing.Color.White;
            this.btnCreatePO.Location = new System.Drawing.Point(648, 474);
            this.btnCreatePO.Name = "btnCreatePO";
            this.btnCreatePO.Size = new System.Drawing.Size(252, 36);
            this.btnCreatePO.TabIndex = 1;
            this.btnCreatePO.Text = "Create Purchase Order";
            this.btnCreatePO.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNotes);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTotalAmount);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dgvPOItems);
            this.groupBox1.Controls.Add(this.btnAddItem);
            this.groupBox1.Controls.Add(this.btnRemoveItem);
            this.groupBox1.Controls.Add(this.cmbSupplier);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSupplierName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPOID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(21, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(879, 444);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Purchase Order Details";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(21, 347);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(566, 85);
            this.txtNotes.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 321);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 23);
            this.label7.TabIndex = 10;
            this.label7.Text = "Notes:";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(677, 315);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(180, 30);
            this.txtTotalAmount.TabIndex = 9;
            this.txtTotalAmount.Text = "0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(557, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 23);
            this.label6.TabIndex = 8;
            this.label6.Text = "Total Amount:";
            // 
            // dgvPOItems
            // 
            this.dgvPOItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPOItems.Location = new System.Drawing.Point(21, 142);
            this.dgvPOItems.Name = "dgvPOItems";
            this.dgvPOItems.RowHeadersWidth = 62;
            this.dgvPOItems.Size = new System.Drawing.Size(836, 158);
            this.dgvPOItems.TabIndex = 7;
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(51)))), ((int)(((byte)(234)))));
            this.btnAddItem.ForeColor = System.Drawing.Color.White;
            this.btnAddItem.Location = new System.Drawing.Point(707, 98);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(150, 34);
            this.btnAddItem.TabIndex = 6;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = false;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnRemoveItem.ForeColor = System.Drawing.Color.White;
            this.btnRemoveItem.Location = new System.Drawing.Point(536, 98);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(150, 34);
            this.btnRemoveItem.TabIndex = 5;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = false;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Items.AddRange(new object[] {
            "SUP001 - Premium Furniture Co.",
            "SUP002 - Quality Supplies Ltd.",
            "SUP003 - Global Materials Inc."});
            this.cmbSupplier.Location = new System.Drawing.Point(160, 46);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(262, 31);
            this.cmbSupplier.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "Supplier ID:";
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(598, 46);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(259, 30);
            this.txtSupplierName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(444, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Supplier Name:";
            // 
            // txtPOID
            // 
            this.txtPOID.Location = new System.Drawing.Point(160, 98);
            this.txtPOID.Name = "txtPOID";
            this.txtPOID.ReadOnly = true;
            this.txtPOID.Size = new System.Drawing.Size(262, 30);
            this.txtPOID.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "PO ID:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 537);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(922, 30);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(60, 25);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 567);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tcPurchaseManager);
            this.Name = "PurchaseForm";
            this.Text = "Purchase Management";
            this.tcPurchaseManager.ResumeLayout(false);
            this.tbPurchaseOrders.ResumeLayout(false);
            this.tbPurchaseOrders.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseOrders)).EndInit();
            this.tbCreatePO.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOItems)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tcPurchaseManager;
        private System.Windows.Forms.TabPage tbPurchaseOrders;
        private System.Windows.Forms.TabPage tbCreatePO;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnPrintPO;
        private System.Windows.Forms.Button btnCancelPO;
        private System.Windows.Forms.Button btnApprovePO;
        private System.Windows.Forms.DataGridView dgvPurchaseOrders;
        private System.Windows.Forms.Button btnRefreshPO;
        private System.Windows.Forms.TextBox txtSearchPO;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCreatePO;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvPOItems;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPOID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}
