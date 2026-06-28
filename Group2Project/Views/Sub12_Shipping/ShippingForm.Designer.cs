namespace Group2Project.Views.Sub12_Shipping
{
    partial class ShippingForm
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
            this.btnReturnToInventory = new System.Windows.Forms.Button();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.cmbUpdateStatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvTrackingList = new System.Windows.Forms.DataGridView();
            this.btnRefreshTracking = new System.Windows.Forms.Button();
            this.btnSearchDelivery = new System.Windows.Forms.Button();
            this.cmbDeliveryStatusFilter = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSearchDeliveryID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrackingList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReturnToInventory
            // 
            this.btnReturnToInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturnToInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnToInventory.Location = new System.Drawing.Point(354, 473);
            this.btnReturnToInventory.Name = "btnReturnToInventory";
            this.btnReturnToInventory.Size = new System.Drawing.Size(248, 34);
            this.btnReturnToInventory.TabIndex = 10;
            this.btnReturnToInventory.Text = "Log Delivery Failure";
            this.btnReturnToInventory.UseVisualStyleBackColor = true;
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(85)))), ((int)(((byte)(247)))));
            this.btnUpdateStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStatus.ForeColor = System.Drawing.Color.White;
            this.btnUpdateStatus.Location = new System.Drawing.Point(37, 473);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(273, 34);
            this.btnUpdateStatus.TabIndex = 9;
            this.btnUpdateStatus.Text = "Update Shipment Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = false;
            // 
            // cmbUpdateStatus
            // 
            this.cmbUpdateStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbUpdateStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUpdateStatus.FormattingEnabled = true;
            this.cmbUpdateStatus.Items.AddRange(new object[] {
            "In Transit",
            "Delivered",
            "Failed (Refused)",
            "Failed (No Answer)"});
            this.cmbUpdateStatus.Location = new System.Drawing.Point(200, 414);
            this.cmbUpdateStatus.Name = "cmbUpdateStatus";
            this.cmbUpdateStatus.Size = new System.Drawing.Size(182, 31);
            this.cmbUpdateStatus.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 417);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 23);
            this.label7.TabIndex = 7;
            this.label7.Text = "Update Status to:";
            // 
            // dgvTrackingList
            // 
            this.dgvTrackingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrackingList.Location = new System.Drawing.Point(24, 122);
            this.dgvTrackingList.Name = "dgvTrackingList";
            this.dgvTrackingList.RowHeadersWidth = 62;
            this.dgvTrackingList.Size = new System.Drawing.Size(860, 267);
            this.dgvTrackingList.TabIndex = 6;
            // 
            // btnRefreshTracking
            // 
            this.btnRefreshTracking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshTracking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshTracking.Location = new System.Drawing.Point(490, 70);
            this.btnRefreshTracking.Name = "btnRefreshTracking";
            this.btnRefreshTracking.Size = new System.Drawing.Size(112, 34);
            this.btnRefreshTracking.TabIndex = 5;
            this.btnRefreshTracking.Text = "Refresh";
            this.btnRefreshTracking.UseVisualStyleBackColor = true;
            // 
            // btnSearchDelivery
            // 
            this.btnSearchDelivery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchDelivery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchDelivery.Location = new System.Drawing.Point(316, 70);
            this.btnSearchDelivery.Name = "btnSearchDelivery";
            this.btnSearchDelivery.Size = new System.Drawing.Size(112, 34);
            this.btnSearchDelivery.TabIndex = 4;
            this.btnSearchDelivery.Text = "Search";
            this.btnSearchDelivery.UseVisualStyleBackColor = true;
            // 
            // cmbDeliveryStatusFilter
            // 
            this.cmbDeliveryStatusFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbDeliveryStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeliveryStatusFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDeliveryStatusFilter.FormattingEnabled = true;
            this.cmbDeliveryStatusFilter.Items.AddRange(new object[] {
            "All",
            "Dispatched",
            "In Transit",
            "Delivered",
            "Failed"});
            this.cmbDeliveryStatusFilter.Location = new System.Drawing.Point(97, 70);
            this.cmbDeliveryStatusFilter.Name = "cmbDeliveryStatusFilter";
            this.cmbDeliveryStatusFilter.Size = new System.Drawing.Size(182, 31);
            this.cmbDeliveryStatusFilter.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "Status:";
            // 
            // txtSearchDeliveryID
            // 
            this.txtSearchDeliveryID.Location = new System.Drawing.Point(316, 22);
            this.txtSearchDeliveryID.Name = "txtSearchDeliveryID";
            this.txtSearchDeliveryID.Size = new System.Drawing.Size(150, 30);
            this.txtSearchDeliveryID.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(286, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Search by Delivery ID / Order ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(85)))), ((int)(((byte)(247)))));
            this.label1.Location = new System.Drawing.Point(24, -5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 32);
            this.label1.TabIndex = 11;
            this.label1.Text = "📦 Shipping &amp; Tracking";
            // 
            // ShippingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 594);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReturnToInventory);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.cmbUpdateStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvTrackingList);
            this.Controls.Add(this.btnRefreshTracking);
            this.Controls.Add(this.btnSearchDelivery);
            this.Controls.Add(this.cmbDeliveryStatusFilter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSearchDeliveryID);
            this.Controls.Add(this.label5);
            this.Name = "ShippingForm";
            this.Text = "Shipping Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrackingList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReturnToInventory;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.ComboBox cmbUpdateStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvTrackingList;
        private System.Windows.Forms.Button btnRefreshTracking;
        private System.Windows.Forms.Button btnSearchDelivery;
        private System.Windows.Forms.ComboBox cmbDeliveryStatusFilter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSearchDeliveryID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
    }
}
