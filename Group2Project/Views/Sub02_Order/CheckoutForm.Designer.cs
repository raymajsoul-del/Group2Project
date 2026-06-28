using System.Windows.Forms;

namespace Group2Project.Views.Sub02_Order
{
    partial class CheckoutForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Group2Project.Utils.LanguageManager.LanguageChanged -= OnLanguageChanged;
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            splitContainer1 = new SplitContainer();
            pnlPayment = new Panel();
            chkPrintReceipt = new CheckBox();
            txtPaidAmount = new TextBox();
            label5 = new Label();
            txtDiscount = new TextBox();
            label4 = new Label();
            lblTotal = new Label();
            label3 = new Label();
            pnlPaymentMethods = new Panel();
            label2 = new Label();
            pnlCart = new Panel();
            dgvCart = new DataGridView();
            label1 = new Label();
            pnlDelivery = new Panel();
            dtpDeliveryDate = new DateTimePicker();
            cmbInstallationTime = new ComboBox();
            label10 = new Label();
            label9 = new Label();
            txtDeliveryContact = new TextBox();
            label8 = new Label();
            txtDeliveryAddress = new TextBox();
            label7 = new Label();
            chkDelivery = new CheckBox();
            label6 = new Label();
            btnConfirm = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            pnlPayment.SuspendLayout();
            pnlCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            pnlDelivery.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblTitle.Location = new System.Drawing.Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(200, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Checkout";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 80);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Size = new System.Drawing.Size(1200, 620);
            splitContainer1.SplitterDistance = 600;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pnlCart);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pnlDelivery);
            splitContainer1.Panel2.Controls.Add(pnlPayment);
            // 
            // pnlPayment
            // 
            pnlPayment.BackColor = System.Drawing.Color.White;
            pnlPayment.Controls.Add(chkPrintReceipt);
            pnlPayment.Controls.Add(txtPaidAmount);
            pnlPayment.Controls.Add(label5);
            pnlPayment.Controls.Add(txtDiscount);
            pnlPayment.Controls.Add(label4);
            pnlPayment.Controls.Add(lblTotal);
            pnlPayment.Controls.Add(label3);
            pnlPayment.Controls.Add(pnlPaymentMethods);
            pnlPayment.Controls.Add(label2);
            pnlPayment.Dock = DockStyle.Top;
            pnlPayment.Location = new System.Drawing.Point(0, 0);
            pnlPayment.Name = "pnlPayment";
            pnlPayment.Size = new System.Drawing.Size(596, 350);
            pnlPayment.TabIndex = 0;
            // 
            // chkPrintReceipt
            // 
            chkPrintReceipt.AutoSize = true;
            chkPrintReceipt.Checked = true;
            chkPrintReceipt.CheckState = CheckState.Checked;
            chkPrintReceipt.Font = new System.Drawing.Font("Segoe UI", 11F);
            chkPrintReceipt.Location = new System.Drawing.Point(20, 300);
            chkPrintReceipt.Name = "chkPrintReceipt";
            chkPrintReceipt.Size = new System.Drawing.Size(130, 28);
            chkPrintReceipt.TabIndex = 7;
            chkPrintReceipt.Text = "Print Receipt";
            // 
            // txtPaidAmount
            // 
            txtPaidAmount.Font = new System.Drawing.Font("Segoe UI", 14F);
            txtPaidAmount.Location = new System.Drawing.Point(350, 250);
            txtPaidAmount.Name = "txtPaidAmount";
            txtPaidAmount.Size = new System.Drawing.Size(200, 39);
            txtPaidAmount.TabIndex = 6;
            txtPaidAmount.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 11F);
            label5.Location = new System.Drawing.Point(350, 220);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(110, 25);
            label5.TabIndex = 5;
            label5.Text = "Paid Amount:";
            // 
            // txtDiscount
            // 
            txtDiscount.Font = new System.Drawing.Font("Segoe UI", 14F);
            txtDiscount.Location = new System.Drawing.Point(350, 170);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new System.Drawing.Size(200, 39);
            txtDiscount.TabIndex = 4;
            txtDiscount.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 11F);
            label4.Location = new System.Drawing.Point(350, 140);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(80, 25);
            label4.TabIndex = 3;
            label4.Text = "Discount:";
            // 
            // lblTotal
            // 
            lblTotal.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            lblTotal.Location = new System.Drawing.Point(20, 170);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new System.Drawing.Size(300, 50);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "$0.00";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 11F);
            label3.Location = new System.Drawing.Point(20, 140);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(60, 25);
            label3.TabIndex = 1;
            label3.Text = "Total:";
            // 
            // pnlPaymentMethods
            // 
            pnlPaymentMethods.Location = new System.Drawing.Point(20, 60);
            pnlPaymentMethods.Name = "pnlPaymentMethods";
            pnlPaymentMethods.Size = new System.Drawing.Size(550, 70);
            pnlPaymentMethods.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(20, 20);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(170, 28);
            label2.TabIndex = 0;
            label2.Text = "Payment Method";
            // 
            // pnlCart
            // 
            pnlCart.BackColor = System.Drawing.Color.White;
            pnlCart.Controls.Add(dgvCart);
            pnlCart.Controls.Add(label1);
            pnlCart.Dock = DockStyle.Fill;
            pnlCart.Location = new System.Drawing.Point(0, 0);
            pnlCart.Name = "pnlCart";
            pnlCart.Padding = new Padding(20);
            pnlCart.Size = new System.Drawing.Size(600, 620);
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Dock = DockStyle.Fill;
            dgvCart.Location = new System.Drawing.Point(20, 70);
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersWidth = 62;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new System.Drawing.Size(560, 530);
            dgvCart.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(20, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(140, 28);
            label1.TabIndex = 0;
            label1.Text = "Shopping Cart";
            // 
            // pnlDelivery
            // 
            pnlDelivery.BackColor = System.Drawing.Color.White;
            pnlDelivery.Controls.Add(dtpDeliveryDate);
            pnlDelivery.Controls.Add(cmbInstallationTime);
            pnlDelivery.Controls.Add(label10);
            pnlDelivery.Controls.Add(label9);
            pnlDelivery.Controls.Add(txtDeliveryContact);
            pnlDelivery.Controls.Add(label8);
            pnlDelivery.Controls.Add(txtDeliveryAddress);
            pnlDelivery.Controls.Add(label7);
            pnlDelivery.Controls.Add(chkDelivery);
            pnlDelivery.Controls.Add(label6);
            pnlDelivery.Dock = DockStyle.Bottom;
            pnlDelivery.Location = new System.Drawing.Point(0, 360);
            pnlDelivery.Name = "pnlDelivery";
            pnlDelivery.Size = new System.Drawing.Size(596, 260);
            // 
            // dtpDeliveryDate
            // 
            dtpDeliveryDate.Enabled = false;
            dtpDeliveryDate.Location = new System.Drawing.Point(180, 120);
            dtpDeliveryDate.Name = "dtpDeliveryDate";
            dtpDeliveryDate.Size = new System.Drawing.Size(350, 31);
            dtpDeliveryDate.TabIndex = 7;
            // 
            // cmbInstallationTime
            // 
            cmbInstallationTime.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInstallationTime.Enabled = false;
            cmbInstallationTime.FormattingEnabled = true;
            cmbInstallationTime.Items.AddRange(new object[] {
            "Morning (9AM - 12PM)",
            "Afternoon (12PM - 5PM)",
            "Evening (5PM - 8PM)"});
            cmbInstallationTime.Location = new System.Drawing.Point(180, 170);
            cmbInstallationTime.Name = "cmbInstallationTime";
            cmbInstallationTime.Size = new System.Drawing.Size(350, 33);
            cmbInstallationTime.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Segoe UI", 10F);
            label10.Location = new System.Drawing.Point(20, 175);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(140, 23);
            label10.TabIndex = 5;
            label10.Text = "Installation Time:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Segoe UI", 10F);
            label9.Location = new System.Drawing.Point(20, 125);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(120, 23);
            label9.TabIndex = 4;
            label9.Text = "Delivery Date:";
            // 
            // txtDeliveryContact
            // 
            txtDeliveryContact.Enabled = false;
            txtDeliveryContact.Location = new System.Drawing.Point(180, 80);
            txtDeliveryContact.Name = "txtDeliveryContact";
            txtDeliveryContact.Size = new System.Drawing.Size(350, 31);
            txtDeliveryContact.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 10F);
            label8.Location = new System.Drawing.Point(20, 85);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(150, 23);
            label8.TabIndex = 2;
            label8.Text = "Contact Number:";
            // 
            // txtDeliveryAddress
            // 
            txtDeliveryAddress.Enabled = false;
            txtDeliveryAddress.Location = new System.Drawing.Point(180, 40);
            txtDeliveryAddress.Name = "txtDeliveryAddress";
            txtDeliveryAddress.Size = new System.Drawing.Size(350, 31);
            txtDeliveryAddress.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            label7.Location = new System.Drawing.Point(20, 45);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(80, 23);
            label7.TabIndex = 0;
            label7.Text = "Address:";
            // 
            // chkDelivery
            // 
            chkDelivery.AutoSize = true;
            chkDelivery.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            chkDelivery.Location = new System.Drawing.Point(20, 10);
            chkDelivery.Name = "chkDelivery";
            chkDelivery.Size = new System.Drawing.Size(280, 29);
            chkDelivery.TabIndex = 0;
            chkDelivery.Text = "Require Delivery & Installation";
            chkDelivery.CheckStateChanged += ChkDelivery_CheckStateChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label6.Location = new System.Drawing.Point(20, 10);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(150, 28);
            label6.TabIndex = 0;
            label6.Text = "Delivery Options";
            // 
            // btnConfirm
            // 
            btnConfirm.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            btnConfirm.ForeColor = System.Drawing.Color.White;
            btnConfirm.Location = new System.Drawing.Point(1000, 720);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new System.Drawing.Size(160, 50);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "Confirm Order";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += BtnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            btnCancel.BackColor = System.Drawing.Color.LightCoral;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.Location = new System.Drawing.Point(820, 720);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(160, 50);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // CheckoutForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1200, 800);
            Controls.Add(btnConfirm);
            Controls.Add(btnCancel);
            Controls.Add(splitContainer1);
            Controls.Add(lblTitle);
            Name = "CheckoutForm";
            Padding = new Padding(0, 0, 0, 20);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Checkout";
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.ResumeLayout(false);
            pnlPayment.ResumeLayout(false);
            pnlPayment.PerformLayout();
            pnlCart.ResumeLayout(false);
            pnlCart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            pnlDelivery.ResumeLayout(false);
            pnlDelivery.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private SplitContainer splitContainer1;
        private Panel pnlCart;
        private DataGridView dgvCart;
        private Label label1;
        private Panel pnlPayment;
        private Label label2;
        private Panel pnlPaymentMethods;
        private Label lblTotal;
        private Label label3;
        private TextBox txtDiscount;
        private Label label4;
        private TextBox txtPaidAmount;
        private Label label5;
        private CheckBox chkPrintReceipt;
        private Panel pnlDelivery;
        private Label label6;
        private CheckBox chkDelivery;
        private Label label7;
        private TextBox txtDeliveryAddress;
        private Label label8;
        private TextBox txtDeliveryContact;
        private Label label9;
        private Label label10;
        private ComboBox cmbInstallationTime;
        private DateTimePicker dtpDeliveryDate;
        private Button btnConfirm;
        private Button btnCancel;
    }
}
