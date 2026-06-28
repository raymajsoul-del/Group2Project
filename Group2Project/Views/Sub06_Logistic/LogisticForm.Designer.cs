namespace Group2Project.Views.Sub06_Logistic
{
    partial class LogisticForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAssignDelivery = new System.Windows.Forms.Button();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbVehicle = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDriver = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvPendingDeliveries = new System.Windows.Forms.DataGridView();
            this.btnRefreshPending = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.headerLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingDeliveries)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAssignDelivery);
            this.groupBox1.Controls.Add(this.dtpDeliveryDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbVehicle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbDriver);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(26, 323);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(860, 205);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Assign Driver &amp; Vehicle";
            // 
            // btnAssignDelivery
            // 
            this.btnAssignDelivery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btnAssignDelivery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAssignDelivery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignDelivery.ForeColor = System.Drawing.Color.White;
            this.btnAssignDelivery.Location = new System.Drawing.Point(500, 102);
            this.btnAssignDelivery.Name = "btnAssignDelivery";
            this.btnAssignDelivery.Size = new System.Drawing.Size(175, 65);
            this.btnAssignDelivery.TabIndex = 6;
            this.btnAssignDelivery.Text = "Confirm";
            this.btnAssignDelivery.UseVisualStyleBackColor = false;
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpDeliveryDate.Location = new System.Drawing.Point(461, 40);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(300, 30);
            this.dtpDeliveryDate.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(400, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Date:";
            // 
            // cmbVehicle
            // 
            this.cmbVehicle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbVehicle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbVehicle.FormattingEnabled = true;
            this.cmbVehicle.Items.AddRange(new object[] {
            "Truck",
            "Van"});
            this.cmbVehicle.Location = new System.Drawing.Point(155, 102);
            this.cmbVehicle.Name = "cmbVehicle";
            this.cmbVehicle.Size = new System.Drawing.Size(182, 31);
            this.cmbVehicle.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select Vehicle:";
            // 
            // cmbDriver
            // 
            this.cmbDriver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDriver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDriver.FormattingEnabled = true;
            this.cmbDriver.Items.AddRange(new object[] {
            "D001",
            "D002",
            "D003",
            "D004",
            "D005",
            "D006",
            "D007",
            "D008",
            "D009",
            "D010",
            "D011",
            "D012",
            "D013",
            "D014",
            "D015",
            "D016",
            "D017",
            "D018",
            "D019",
            "D020"});
            this.cmbDriver.Location = new System.Drawing.Point(145, 43);
            this.cmbDriver.Name = "cmbDriver";
            this.cmbDriver.Size = new System.Drawing.Size(182, 31);
            this.cmbDriver.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select Driver:";
            // 
            // dgvPendingDeliveries
            // 
            this.dgvPendingDeliveries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendingDeliveries.Location = new System.Drawing.Point(26, 74);
            this.dgvPendingDeliveries.Name = "dgvPendingDeliveries";
            this.dgvPendingDeliveries.RowHeadersWidth = 62;
            this.dgvPendingDeliveries.Size = new System.Drawing.Size(860, 225);
            this.dgvPendingDeliveries.TabIndex = 2;
            // 
            // btnRefreshPending
            // 
            this.btnRefreshPending.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshPending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshPending.Location = new System.Drawing.Point(204, 23);
            this.btnRefreshPending.Name = "btnRefreshPending";
            this.btnRefreshPending.Size = new System.Drawing.Size(112, 34);
            this.btnRefreshPending.TabIndex = 1;
            this.btnRefreshPending.Text = "Refresh";
            this.btnRefreshPending.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pending Deliveries:";
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.headerLabel.Location = new System.Drawing.Point(26, -5);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(217, 32);
            this.headerLabel.TabIndex = 4;
            this.headerLabel.Text = "🚚 Logistics &amp; Dispatch";
            // 
            // LogisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 594);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvPendingDeliveries);
            this.Controls.Add(this.btnRefreshPending);
            this.Controls.Add(this.label1);
            this.Name = "LogisticForm";
            this.Text = "Logistics Management";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingDeliveries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAssignDelivery;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbVehicle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDriver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvPendingDeliveries;
        private System.Windows.Forms.Button btnRefreshPending;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label headerLabel;
    }
}
