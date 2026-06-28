namespace Group2Project.Views.Sub02_Order
{
    partial class PlaceOrderForm
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
            tcOrderManager = new TabControl();
            tbRegularOrder = new TabPage();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            lblTotalAmount = new Label();
            dgvCart = new DataGridView();
            groupBox1 = new GroupBox();
            btnSubmitOrder = new Button();
            btnAddToCart = new Button();
            txtRegularQty = new TextBox();
            cmbRegularItems = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            tbMadeOrder = new TabPage();
            groupBox3 = new GroupBox();
            btnSubmitCustomOrder = new Button();
            txtBlueprintPath = new TextBox();
            btnBrowseBlueprint = new Button();
            groupBox2 = new GroupBox();
            txtLength = new TextBox();
            txtHeight = new TextBox();
            txtWidth = new TextBox();
            cmbCustomMaterial = new ComboBox();
            txtCustomCustID = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            tbSearchManageOrder = new TabPage();
            btnRefresh = new Button();
            btnPrintInvoice = new Button();
            btnCancelOrder = new Button();
            btnEditOrder = new Button();
            btnViewDetails = new Button();
            dgvOrderList = new DataGridView();
            btnSearchOrder = new Button();
            txtSearchKeyword = new TextBox();
            label6 = new Label();
            openFileDialog1 = new OpenFileDialog();
            tcOrderManager.SuspendLayout();
            tbRegularOrder.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            groupBox1.SuspendLayout();
            tbMadeOrder.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            tbSearchManageOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrderList).BeginInit();
            SuspendLayout();
            // 
            // tcOrderManager
            // 
            tcOrderManager.Controls.Add(tbRegularOrder);
            tcOrderManager.Controls.Add(tbMadeOrder);
            tcOrderManager.Controls.Add(tbSearchManageOrder);
            tcOrderManager.Dock = DockStyle.Fill;
            tcOrderManager.Location = new Point(0, 0);
            tcOrderManager.Margin = new Padding(2);
            tcOrderManager.Name = "tcOrderManager";
            tcOrderManager.SelectedIndex = 0;
            tcOrderManager.TabIndex = 0;
            // 
            // tbRegularOrder
            // 
            tbRegularOrder.Controls.Add(statusStrip1);
            tbRegularOrder.Controls.Add(lblTotalAmount);
            tbRegularOrder.Controls.Add(dgvCart);
            tbRegularOrder.Controls.Add(groupBox1);
            tbRegularOrder.Location = new Point(4, 28);
            tbRegularOrder.Margin = new Padding(2);
            tbRegularOrder.Name = "tbRegularOrder";
            tbRegularOrder.Padding = new Padding(2);
            tbRegularOrder.TabIndex = 0;
            tbRegularOrder.Text = "Regular Furniture Order";
            tbRegularOrder.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            statusStrip1.Dock = DockStyle.Bottom;
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(2, 415);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 11, 0);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 16);
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Location = new Point(566, 4);
            lblTotalAmount.Margin = new Padding(2, 0, 2, 0);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(149, 19);
            lblTotalAmount.TabIndex = 2;
            lblTotalAmount.Text = "Total Amount: $0.00";
            // 
            // dgvCart
            // 
            dgvCart.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(294, 26);
            dgvCart.Margin = new Padding(2);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersWidth = 62;
            dgvCart.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left)));
            groupBox1.Controls.Add(btnSubmitOrder);
            groupBox1.Controls.Add(btnAddToCart);
            groupBox1.Controls.Add(txtRegularQty);
            groupBox1.Controls.Add(cmbRegularItems);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(19, 17);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Select Item";
            // 
            // btnSubmitOrder
            // 
            btnSubmitOrder.BackColor = Color.Yellow;
            btnSubmitOrder.Cursor = Cursors.Hand;
            btnSubmitOrder.FlatStyle = FlatStyle.Flat;
            btnSubmitOrder.Location = new Point(131, 373);
            btnSubmitOrder.Margin = new Padding(2);
            btnSubmitOrder.Name = "btnSubmitOrder";
            btnSubmitOrder.Size = new Size(139, 28);
            btnSubmitOrder.TabIndex = 3;
            btnSubmitOrder.Text = "Place Order";
            btnSubmitOrder.UseVisualStyleBackColor = false;
            btnSubmitOrder.Click += btnSubmitOrder_Click;
            // 
            // btnAddToCart
            // 
            btnAddToCart.BackColor = Color.LightGreen;
            btnAddToCart.Cursor = Cursors.Hand;
            btnAddToCart.FlatStyle = FlatStyle.Flat;
            btnAddToCart.Location = new Point(16, 145);
            btnAddToCart.Margin = new Padding(2);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(97, 28);
            btnAddToCart.TabIndex = 4;
            btnAddToCart.Text = "Add to Cart";
            btnAddToCart.UseVisualStyleBackColor = false;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // txtRegularQty
            // 
            txtRegularQty.Cursor = Cursors.IBeam;
            txtRegularQty.Location = new Point(110, 88);
            txtRegularQty.Margin = new Padding(2);
            txtRegularQty.Name = "txtRegularQty";
            txtRegularQty.Size = new Size(123, 27);
            txtRegularQty.TabIndex = 3;
            // 
            // cmbRegularItems
            // 
            cmbRegularItems.Cursor = Cursors.IBeam;
            cmbRegularItems.FormattingEnabled = true;
            cmbRegularItems.Location = new Point(110, 37);
            cmbRegularItems.Margin = new Padding(2);
            cmbRegularItems.Name = "cmbRegularItems";
            cmbRegularItems.Size = new Size(150, 27);
            cmbRegularItems.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 88);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(72, 19);
            label2.TabIndex = 1;
            label2.Text = "Quantity:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(2, 37);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(111, 19);
            label1.TabIndex = 0;
            label1.Text = "Furniture Item:";
            // 
            // tbMadeOrder
            // 
            tbMadeOrder.Controls.Add(groupBox3);
            tbMadeOrder.Controls.Add(groupBox2);
            tbMadeOrder.Location = new Point(4, 28);
            tbMadeOrder.Margin = new Padding(2);
            tbMadeOrder.Name = "tbMadeOrder";
            tbMadeOrder.Padding = new Padding(2);
            tbMadeOrder.TabIndex = 1;
            tbMadeOrder.Text = "Tailor-made Order";
            tbMadeOrder.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            groupBox3.Controls.Add(btnSubmitCustomOrder);
            groupBox3.Controls.Add(txtBlueprintPath);
            groupBox3.Controls.Add(btnBrowseBlueprint);
            groupBox3.Location = new Point(26, 186);
            groupBox3.Margin = new Padding(2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(2);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Technical Design Diagram";
            // 
            // btnSubmitCustomOrder
            // 
            btnSubmitCustomOrder.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            btnSubmitCustomOrder.Cursor = Cursors.Hand;
            btnSubmitCustomOrder.FlatStyle = FlatStyle.Flat;
            btnSubmitCustomOrder.ForeColor = SystemColors.ControlText;
            btnSubmitCustomOrder.Location = new Point(414, 197);
            btnSubmitCustomOrder.Margin = new Padding(2);
            btnSubmitCustomOrder.Name = "btnSubmitCustomOrder";
            btnSubmitCustomOrder.Size = new Size(231, 28);
            btnSubmitCustomOrder.TabIndex = 2;
            btnSubmitCustomOrder.Text = "Submit Design & Request Quotation";
            btnSubmitCustomOrder.UseVisualStyleBackColor = true;
            // 
            // txtBlueprintPath
            // 
            txtBlueprintPath.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            txtBlueprintPath.Location = new Point(5, 90);
            txtBlueprintPath.Margin = new Padding(2);
            txtBlueprintPath.Name = "txtBlueprintPath";
            txtBlueprintPath.ReadOnly = true;
            txtBlueprintPath.TabIndex = 1;
            txtBlueprintPath.Text = "No file selected...";
            txtBlueprintPath.TextAlign = HorizontalAlignment.Center;
            txtBlueprintPath.TextChanged += txtBlueprintPath_TextChanged;
            // 
            // btnBrowseBlueprint
            // 
            btnBrowseBlueprint.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            btnBrowseBlueprint.Cursor = Cursors.Hand;
            btnBrowseBlueprint.FlatStyle = FlatStyle.Flat;
            btnBrowseBlueprint.Location = new Point(241, 197);
            btnBrowseBlueprint.Margin = new Padding(2);
            btnBrowseBlueprint.Name = "btnBrowseBlueprint";
            btnBrowseBlueprint.Size = new Size(168, 28);
            btnBrowseBlueprint.TabIndex = 0;
            btnBrowseBlueprint.Text = "Browse Blueprint...";
            btnBrowseBlueprint.UseVisualStyleBackColor = true;
            btnBrowseBlueprint.Click += btnBrowseBlueprint_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            groupBox2.Controls.Add(txtLength);
            groupBox2.Controls.Add(txtHeight);
            groupBox2.Controls.Add(txtWidth);
            groupBox2.Controls.Add(cmbCustomMaterial);
            groupBox2.Controls.Add(txtCustomCustID);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(26, 15);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Custom Specifications";
            // 
            // txtLength
            // 
            txtLength.Cursor = Cursors.IBeam;
            txtLength.Location = new Point(430, 83);
            txtLength.Margin = new Padding(2);
            txtLength.Name = "txtLength";
            txtLength.Size = new Size(49, 27);
            txtLength.TabIndex = 7;
            // 
            // txtHeight
            // 
            txtHeight.Cursor = Cursors.IBeam;
            txtHeight.Location = new Point(483, 83);
            txtHeight.Margin = new Padding(2);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(49, 27);
            txtHeight.TabIndex = 6;
            // 
            // txtWidth
            // 
            txtWidth.Cursor = Cursors.IBeam;
            txtWidth.Location = new Point(376, 83);
            txtWidth.Margin = new Padding(2);
            txtWidth.Name = "txtWidth";
            txtWidth.Size = new Size(49, 27);
            txtWidth.TabIndex = 5;
            // 
            // cmbCustomMaterial
            // 
            cmbCustomMaterial.Cursor = Cursors.IBeam;
            cmbCustomMaterial.FormattingEnabled = true;
            cmbCustomMaterial.Location = new Point(141, 102);
            cmbCustomMaterial.Margin = new Padding(2);
            cmbCustomMaterial.Name = "cmbCustomMaterial";
            cmbCustomMaterial.Size = new Size(150, 27);
            cmbCustomMaterial.TabIndex = 4;
            // 
            // txtCustomCustID
            // 
            txtCustomCustID.Cursor = Cursors.IBeam;
            txtCustomCustID.Location = new Point(141, 53);
            txtCustomCustID.Margin = new Padding(2);
            txtCustomCustID.Name = "txtCustomCustID";
            txtCustomCustID.Size = new Size(123, 27);
            txtCustomCustID.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(349, 53);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(197, 19);
            label5.TabIndex = 2;
            label5.Text = "Dimensions (W x L x H cm):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 105);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(106, 19);
            label4.TabIndex = 1;
            label4.Text = "Material Type:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 55);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(99, 19);
            label3.TabIndex = 0;
            label3.Text = "Customer ID:";
            // 
            // tbSearchManageOrder
            // 
            tbSearchManageOrder.Controls.Add(btnRefresh);
            tbSearchManageOrder.Controls.Add(btnPrintInvoice);
            tbSearchManageOrder.Controls.Add(btnCancelOrder);
            tbSearchManageOrder.Controls.Add(btnEditOrder);
            tbSearchManageOrder.Controls.Add(btnViewDetails);
            tbSearchManageOrder.Controls.Add(dgvOrderList);
            tbSearchManageOrder.Controls.Add(btnSearchOrder);
            tbSearchManageOrder.Controls.Add(txtSearchKeyword);
            tbSearchManageOrder.Controls.Add(label6);
            tbSearchManageOrder.Location = new Point(4, 28);
            tbSearchManageOrder.Margin = new Padding(2);
            tbSearchManageOrder.Name = "tbSearchManageOrder";
            tbSearchManageOrder.Padding = new Padding(2);
            tbSearchManageOrder.TabIndex = 2;
            tbSearchManageOrder.Text = "Search & Manage Orders";
            tbSearchManageOrder.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Location = new Point(529, 21);
            btnRefresh.Margin = new Padding(2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(92, 28);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnPrintInvoice
            // 
            btnPrintInvoice.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            btnPrintInvoice.Cursor = Cursors.Hand;
            btnPrintInvoice.FlatStyle = FlatStyle.Flat;
            btnPrintInvoice.Location = new Point(362, 401);
            btnPrintInvoice.Margin = new Padding(2);
            btnPrintInvoice.Name = "btnPrintInvoice";
            btnPrintInvoice.Size = new Size(92, 28);
            btnPrintInvoice.TabIndex = 7;
            btnPrintInvoice.Text = "Print";
            btnPrintInvoice.UseVisualStyleBackColor = true;
            // 
            // btnCancelOrder
            // 
            btnCancelOrder.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            btnCancelOrder.BackColor = Color.Salmon;
            btnCancelOrder.Cursor = Cursors.Hand;
            btnCancelOrder.FlatStyle = FlatStyle.Flat;
            btnCancelOrder.ForeColor = SystemColors.ControlText;
            btnCancelOrder.Location = new Point(529, 401);
            btnCancelOrder.Margin = new Padding(2);
            btnCancelOrder.Name = "btnCancelOrder";
            btnCancelOrder.Size = new Size(180, 28);
            btnCancelOrder.TabIndex = 6;
            btnCancelOrder.Text = "Cancel Selected Order";
            btnCancelOrder.UseVisualStyleBackColor = false;
            // 
            // btnEditOrder
            // 
            btnEditOrder.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            btnEditOrder.Cursor = Cursors.Hand;
            btnEditOrder.FlatStyle = FlatStyle.Flat;
            btnEditOrder.Location = new Point(158, 401);
            btnEditOrder.Margin = new Padding(2);
            btnEditOrder.Name = "btnEditOrder";
            btnEditOrder.Size = new Size(200, 28);
            btnEditOrder.TabIndex = 5;
            btnEditOrder.Text = "Modify Selected Order";
            btnEditOrder.UseVisualStyleBackColor = true;
            // 
            // btnViewDetails
            // 
            btnViewDetails.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            btnViewDetails.Cursor = Cursors.Hand;
            btnViewDetails.FlatStyle = FlatStyle.Flat;
            btnViewDetails.Location = new Point(44, 401);
            btnViewDetails.Margin = new Padding(2);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new Size(109, 28);
            btnViewDetails.TabIndex = 4;
            btnViewDetails.Text = "View Details";
            btnViewDetails.UseVisualStyleBackColor = true;
            // 
            // dgvOrderList
            // 
            dgvOrderList.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            dgvOrderList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderList.Location = new Point(13, 65);
            dgvOrderList.Margin = new Padding(2);
            dgvOrderList.Name = "dgvOrderList";
            dgvOrderList.ReadOnly = true;
            dgvOrderList.RowHeadersWidth = 62;
            dgvOrderList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderList.TabIndex = 3;
            // 
            // btnSearchOrder
            // 
            btnSearchOrder.Cursor = Cursors.Hand;
            btnSearchOrder.FlatStyle = FlatStyle.Flat;
            btnSearchOrder.Location = new Point(406, 21);
            btnSearchOrder.Margin = new Padding(2);
            btnSearchOrder.Name = "btnSearchOrder";
            btnSearchOrder.Size = new Size(92, 28);
            btnSearchOrder.TabIndex = 2;
            btnSearchOrder.Text = "Search";
            btnSearchOrder.UseVisualStyleBackColor = true;
            // 
            // txtSearchKeyword
            // 
            txtSearchKeyword.Cursor = Cursors.IBeam;
            txtSearchKeyword.Location = new Point(263, 21);
            txtSearchKeyword.Margin = new Padding(2);
            txtSearchKeyword.Name = "txtSearchKeyword";
            txtSearchKeyword.Size = new Size(123, 27);
            txtSearchKeyword.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 21);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(246, 19);
            label6.TabIndex = 0;
            label6.Text = "Search by Order ID / Customer ID:";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.pdf";
            // 
            // PlaceOrderForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(913, 531);
            Controls.Add(tcOrderManager);
            Margin = new Padding(2);
            Name = "PlaceOrderForm";
            Text = "Order Processing";
            tcOrderManager.ResumeLayout(false);
            tbRegularOrder.ResumeLayout(false);
            tbRegularOrder.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tbMadeOrder.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tbSearchManageOrder.ResumeLayout(false);
            tbSearchManageOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrderList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcOrderManager;
        private TabPage tbRegularOrder;
        private TabPage tbMadeOrder;
        private TabPage tbSearchManageOrder;
        private GroupBox groupBox1;
        private TextBox txtRegularQty;
        private ComboBox cmbRegularItems;
        private Label label2;
        private Label label1;
        private Button btnAddToCart;
        private DataGridView dgvCart;
        private Button btnSubmitOrder;
        private Label lblTotalAmount;
        private GroupBox groupBox2;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtLength;
        private TextBox txtHeight;
        private TextBox txtWidth;
        private ComboBox cmbCustomMaterial;
        private TextBox txtCustomCustID;
        private GroupBox groupBox3;
        private Button btnSubmitCustomOrder;
        private TextBox txtBlueprintPath;
        private Button btnBrowseBlueprint;
        private DataGridView dgvOrderList;
        private Button btnSearchOrder;
        private TextBox txtSearchKeyword;
        private Label label6;
        private Button btnPrintInvoice;
        private Button btnCancelOrder;
        private Button btnEditOrder;
        private Button btnViewDetails;
        private Button btnRefresh;
        private OpenFileDialog openFileDialog1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
    }
}