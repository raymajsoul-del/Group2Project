using System.Windows.Forms;

namespace Group2Project.Views.Sub02_Order
{
    partial class POSForm
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
            tcPOS = new TabControl();
            tbSearch = new TabPage();
            pnlCart = new Panel();
            btnClearCart = new Button();
            btnCheckout = new Button();
            lblTaxLabel = new Label();
            lblDiscountLabel = new Label();
            lblTotalAmount = new Label();
            lblSubtotalLabel = new Label();
            lblDiscount = new Label();
            lblTax = new Label();
            lblSubtotal = new Label();
            dgvCart = new DataGridView();
            lblCartTitle = new Label();
            splitContainer1 = new SplitContainer();
            pnlSearchResults = new Panel();
            dgvProducts = new DataGridView();
            lblSearchResults = new Label();
            pnlSearch = new Panel();
            txtSearch = new Button();
            txtDescription = new TextBox();
            txtMaxPrice = new TextBox();
            txtMinPrice = new TextBox();
            txtBarcode = new TextBox();
            cmbCategory = new ComboBox();
            txtProductId = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            lblSearchTitle = new Label();
            tbOrderHistory = new TabPage();
            tbDefectReport = new TabPage();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            tcPOS.SuspendLayout();
            tbSearch.SuspendLayout();
            pnlCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            pnlSearchResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            pnlSearch.SuspendLayout();
            SuspendLayout();
            // 
            // tcPOS
            // 
            tcPOS.Controls.Add(tbSearch);
            tcPOS.Controls.Add(tbOrderHistory);
            tcPOS.Controls.Add(tbDefectReport);
            tcPOS.Dock = DockStyle.Fill;
            tcPOS.Location = new Point(0, 0);
            tcPOS.Name = "tcPOS";
            tcPOS.SelectedIndex = 0;
            tcPOS.Size = new Size(1400, 900);
            tcPOS.TabIndex = 0;
            // 
            // tbSearch
            // 
            tbSearch.Controls.Add(pnlCart);
            tbSearch.Controls.Add(splitContainer1);
            tbSearch.Location = new Point(4, 28);
            tbSearch.Name = "tbSearch";
            tbSearch.Padding = new Padding(10);
            tbSearch.Size = new Size(1392, 868);
            tbSearch.TabIndex = 0;
            tbSearch.Text = "POS - Sales";
            // 
            // pnlCart
            // 
            pnlCart.BackColor = System.Drawing.Color.White;
            pnlCart.Controls.Add(btnClearCart);
            pnlCart.Controls.Add(btnCheckout);
            pnlCart.Controls.Add(lblTaxLabel);
            pnlCart.Controls.Add(lblDiscountLabel);
            pnlCart.Controls.Add(lblTotalAmount);
            pnlCart.Controls.Add(lblSubtotalLabel);
            pnlCart.Controls.Add(lblDiscount);
            pnlCart.Controls.Add(lblTax);
            pnlCart.Controls.Add(lblSubtotal);
            pnlCart.Controls.Add(dgvCart);
            pnlCart.Controls.Add(lblCartTitle);
            pnlCart.Dock = DockStyle.Right;
            pnlCart.Location = new Point(980, 10);
            pnlCart.Name = "pnlCart";
            pnlCart.Size = new Size(402, 858);
            // 
            // btnClearCart
            // 
            btnClearCart.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            btnClearCart.BackColor = System.Drawing.Color.LightCoral;
            btnClearCart.FlatStyle = FlatStyle.Flat;
            btnClearCart.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnClearCart.ForeColor = System.Drawing.Color.White;
            btnClearCart.Location = new Point(220, 770);
            btnClearCart.Name = "btnClearCart";
            btnClearCart.Size = new Size(160, 45);
            btnClearCart.TabIndex = 7;
            btnClearCart.Text = "Clear Cart";
            btnClearCart.UseVisualStyleBackColor = false;
            // 
            // btnCheckout
            // 
            btnCheckout.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            btnCheckout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            btnCheckout.ForeColor = System.Drawing.Color.White;
            btnCheckout.Location = new Point(20, 770);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(180, 45);
            btnCheckout.TabIndex = 6;
            btnCheckout.Text = "Checkout";
            btnCheckout.UseVisualStyleBackColor = false;
            // 
            // lblTaxLabel
            // 
            lblTaxLabel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            lblTaxLabel.AutoSize = true;
            lblTaxLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblTaxLabel.Location = new Point(20, 680);
            lblTaxLabel.Name = "lblTaxLabel";
            lblTaxLabel.Size = new Size(34, 20);
            lblTaxLabel.TabIndex = 5;
            lblTaxLabel.Text = "Tax:";
            // 
            // lblDiscountLabel
            // 
            lblDiscountLabel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            lblDiscountLabel.AutoSize = true;
            lblDiscountLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblDiscountLabel.Location = new Point(20, 640);
            lblDiscountLabel.Name = "lblDiscountLabel";
            lblDiscountLabel.Size = new Size(69, 20);
            lblDiscountLabel.TabIndex = 4;
            lblDiscountLabel.Text = "Discount:";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            lblTotalAmount.Location = new Point(20, 720);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(360, 35);
            lblTotalAmount.TabIndex = 3;
            lblTotalAmount.Text = "Total: $0.00";
            lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubtotalLabel
            // 
            lblSubtotalLabel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            lblSubtotalLabel.AutoSize = true;
            lblSubtotalLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblSubtotalLabel.Location = new Point(20, 600);
            lblSubtotalLabel.Name = "lblSubtotalLabel";
            lblSubtotalLabel.Size = new Size(68, 20);
            lblSubtotalLabel.TabIndex = 2;
            lblSubtotalLabel.Text = "Subtotal:";
            // 
            // lblDiscount
            // 
            lblDiscount.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            lblDiscount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblDiscount.Location = new Point(220, 640);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(160, 20);
            lblDiscount.TabIndex = 1;
            lblDiscount.Text = "$0.00";
            lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTax
            // 
            lblTax.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            lblTax.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblTax.Location = new Point(220, 680);
            lblTax.Name = "lblTax";
            lblTax.Size = new Size(160, 20);
            lblTax.TabIndex = 1;
            lblTax.Text = "$0.00";
            lblTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubtotal
            // 
            lblSubtotal.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblSubtotal.Location = new Point(220, 600);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(160, 20);
            lblSubtotal.TabIndex = 1;
            lblSubtotal.Text = "$0.00";
            lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(20, 60);
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(362, 520);
            dgvCart.TabIndex = 0;
            // 
            // lblCartTitle
            // 
            lblCartTitle.AutoSize = true;
            lblCartTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblCartTitle.Location = new Point(20, 20);
            lblCartTitle.Name = "lblCartTitle";
            lblCartTitle.Size = new Size(100, 30);
            lblCartTitle.TabIndex = 0;
            lblCartTitle.Text = "Shopping Cart";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(10, 10);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            splitContainer1.Size = new Size(970, 858);
            splitContainer1.SplitterDistance = 250;
            splitContainer1.TabIndex = 1;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pnlSearch);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pnlSearchResults);
            // 
            // pnlSearchResults
            // 
            pnlSearchResults.BackColor = System.Drawing.Color.White;
            pnlSearchResults.Controls.Add(dgvProducts);
            pnlSearchResults.Controls.Add(lblSearchResults);
            pnlSearchResults.Dock = DockStyle.Fill;
            pnlSearchResults.Location = new Point(0, 0);
            pnlSearchResults.Name = "pnlSearchResults";
            pnlSearchResults.Padding = new Padding(20);
            pnlSearchResults.Size = new Size(970, 604);
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(20, 50);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(930, 534);
            dgvProducts.TabIndex = 1;
            // 
            // lblSearchResults
            // 
            lblSearchResults.AutoSize = true;
            lblSearchResults.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblSearchResults.Location = new Point(20, 15);
            lblSearchResults.Name = "lblSearchResults";
            lblSearchResults.Size = new Size(150, 25);
            lblSearchResults.TabIndex = 0;
            lblSearchResults.Text = "Search Results";
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = System.Drawing.Color.White;
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(txtDescription);
            pnlSearch.Controls.Add(txtMaxPrice);
            pnlSearch.Controls.Add(txtMinPrice);
            pnlSearch.Controls.Add(txtBarcode);
            pnlSearch.Controls.Add(cmbCategory);
            pnlSearch.Controls.Add(txtProductId);
            pnlSearch.Controls.Add(label7);
            pnlSearch.Controls.Add(label6);
            pnlSearch.Controls.Add(label5);
            pnlSearch.Controls.Add(label4);
            pnlSearch.Controls.Add(label3);
            pnlSearch.Controls.Add(label2);
            pnlSearch.Controls.Add(lblSearchTitle);
            pnlSearch.Dock = DockStyle.Fill;
            pnlSearch.Location = new Point(0, 0);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Padding = new Padding(20);
            pnlSearch.Size = new Size(970, 250);
            // 
            // txtSearch
            // 
            txtSearch.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            txtSearch.FlatStyle = FlatStyle.Flat;
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            txtSearch.ForeColor = System.Drawing.Color.White;
            txtSearch.Location = new Point(770, 180);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(160, 40);
            txtSearch.TabIndex = 13;
            txtSearch.Text = "Search";
            txtSearch.UseVisualStyleBackColor = false;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(520, 100);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(200, 27);
            txtDescription.TabIndex = 12;
            // 
            // txtMaxPrice
            // 
            txtMaxPrice.Location = new Point(390, 100);
            txtMaxPrice.Name = "txtMaxPrice";
            txtMaxPrice.Size = new Size(100, 27);
            txtMaxPrice.TabIndex = 11;
            // 
            // txtMinPrice
            // 
            txtMinPrice.Location = new Point(280, 100);
            txtMinPrice.Name = "txtMinPrice";
            txtMinPrice.Size = new Size(100, 27);
            txtMinPrice.TabIndex = 10;
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(120, 100);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(140, 27);
            txtBarcode.TabIndex = 9;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(560, 50);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(160, 27);
            cmbCategory.TabIndex = 8;
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(120, 50);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(140, 27);
            txtProductId.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(520, 105);
            label7.Name = "label7";
            label7.Size = new Size(78, 19);
            label7.TabIndex = 6;
            label7.Text = "Description:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(350, 105);
            label6.Name = "label6";
            label6.Size = new Size(35, 19);
            label6.TabIndex = 5;
            label6.Text = "Max:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(280, 105);
            label5.Name = "label5";
            label5.Size = new Size(34, 19);
            label5.TabIndex = 4;
            label5.Text = "Min:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(280, 55);
            label4.Name = "label4";
            label4.Size = new Size(104, 19);
            label4.TabIndex = 3;
            label4.Text = "Price Range:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 105);
            label3.Name = "label3";
            label3.Size = new Size(60, 19);
            label3.TabIndex = 2;
            label3.Text = "Barcode:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(480, 55);
            label2.Name = "label2";
            label2.Size = new Size(70, 19);
            label2.TabIndex = 1;
            label2.Text = "Category:";
            // 
            // lblSearchTitle
            // 
            lblSearchTitle.AutoSize = true;
            lblSearchTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblSearchTitle.Location = new Point(20, 15);
            lblSearchTitle.Name = "lblSearchTitle";
            lblSearchTitle.Size = new Size(180, 30);
            lblSearchTitle.TabIndex = 0;
            lblSearchTitle.Text = "Product Search";
            // 
            // tbOrderHistory
            // 
            tbOrderHistory.Location = new Point(4, 28);
            tbOrderHistory.Name = "tbOrderHistory";
            tbOrderHistory.Padding = new Padding(10);
            tbOrderHistory.Size = new Size(1392, 868);
            tbOrderHistory.TabIndex = 1;
            tbOrderHistory.Text = "Order History";
            // 
            // tbDefectReport
            // 
            tbDefectReport.Location = new Point(4, 28);
            tbDefectReport.Name = "tbDefectReport";
            tbDefectReport.Padding = new Padding(10);
            tbDefectReport.Size = new Size(1392, 868);
            tbDefectReport.TabIndex = 2;
            tbDefectReport.Text = "Defect Report";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] {
            toolStripStatusLabel1
            });
            statusStrip1.Location = new Point(0, 878);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1400, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // POSForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 900);
            Controls.Add(statusStrip1);
            Controls.Add(tcPOS);
            Name = "POSForm";
            Text = "Point of Sale System";
            tcPOS.ResumeLayout(false);
            tbSearch.ResumeLayout(false);
            pnlCart.ResumeLayout(false);
            pnlCart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            pnlSearchResults.ResumeLayout(false);
            pnlSearchResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private TabControl tcPOS;
        private TabPage tbSearch;
        private TabPage tbOrderHistory;
        private TabPage tbDefectReport;
        private SplitContainer splitContainer1;
        private Panel pnlSearch;
        private Panel pnlSearchResults;
        private DataGridView dgvProducts;
        private Label lblSearchResults;
        private Label lblSearchTitle;
        private TextBox txtProductId;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtBarcode;
        private TextBox txtMinPrice;
        private TextBox txtMaxPrice;
        private TextBox txtDescription;
        private Button txtSearch;
        private ComboBox cmbCategory;
        private Panel pnlCart;
        private DataGridView dgvCart;
        private Label lblCartTitle;
        private Label lblDiscount;
        private Label lblSubtotal;
        private Label lblTotalAmount;
        private Label lblSubtotalLabel;
        private Label lblDiscountLabel;
        private Label lblTaxLabel;
        private Label lblTax;
        private Button btnCheckout;
        private Button btnClearCart;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}
