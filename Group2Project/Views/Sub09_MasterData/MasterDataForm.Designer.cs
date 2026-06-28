namespace Group2Project.Views.Sub09_MasterData
{
    partial class MasterDataForm
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
            tbMDForm = new TabControl();
            tbMangeStaff = new TabPage();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnAddStaff = new Button();
            cmbRole = new ComboBox();
            txtStaffName = new TextBox();
            txtPassword = new TextBox();
            txtStaffID = new TextBox();
            dgvStaff = new DataGridView();
            tbManageSuppliers = new TabPage();
            dgvSuppliers = new DataGridView();
            btnAddSupplier = new Button();
            txtSupplierName = new TextBox();
            txtContact = new TextBox();
            txtContactNumber = new TextBox();
            txtSupplierID = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            tbManageCustomers = new TabPage();
            btnAddCustomer = new Button();
            txtCustAddress = new TextBox();
            txtCustPhone = new TextBox();
            txtCustName = new TextBox();
            txtCustID = new TextBox();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            dgvCustomers = new DataGridView();
            tbManageDriversVehicles = new TabPage();
            btnAddDriver = new Button();
            cmbLicense = new ComboBox();
            txtDriverName = new TextBox();
            txtDriverID = new TextBox();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            dgvDrivers = new DataGridView();
            tbManageMaterialsProducts = new TabPage();
            btnAddProduct = new Button();
            txtProdPrice = new TextBox();
            txtProdName = new TextBox();
            txtProdID = new TextBox();
            label19 = new Label();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            cmbProdCategory = new ComboBox();
            dgvProducts = new DataGridView();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            tbMDForm.SuspendLayout();
            tbMangeStaff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStaff).BeginInit();
            tbManageSuppliers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).BeginInit();
            tbManageCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            tbManageDriversVehicles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDrivers).BeginInit();
            tbManageMaterialsProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tbMDForm
            // 
            tbMDForm.Controls.Add(tbMangeStaff);
            tbMDForm.Controls.Add(tbManageSuppliers);
            tbMDForm.Controls.Add(tbManageCustomers);
            tbMDForm.Controls.Add(tbManageDriversVehicles);
            tbMDForm.Controls.Add(tbManageMaterialsProducts);
            tbMDForm.Dock = DockStyle.Fill;
            tbMDForm.Location = new Point(0, 0);
            tbMDForm.Margin = new Padding(2, 2, 2, 2);
            tbMDForm.Name = "tbMDForm";
            tbMDForm.SelectedIndex = 0;
            tbMDForm.TabIndex = 0;
            // 
            // tbMangeStaff
            // 
            tbMangeStaff.Controls.Add(label4);
            tbMangeStaff.Controls.Add(label3);
            tbMangeStaff.Controls.Add(label2);
            tbMangeStaff.Controls.Add(label1);
            tbMangeStaff.Controls.Add(btnAddStaff);
            tbMangeStaff.Controls.Add(cmbRole);
            tbMangeStaff.Controls.Add(txtStaffName);
            tbMangeStaff.Controls.Add(txtPassword);
            tbMangeStaff.Controls.Add(txtStaffID);
            tbMangeStaff.Controls.Add(dgvStaff);
            tbMangeStaff.Location = new Point(4, 28);
            tbMangeStaff.Margin = new Padding(2, 2, 2, 2);
            tbMangeStaff.Name = "tbMangeStaff";
            tbMangeStaff.Padding = new Padding(2, 2, 2, 2);
            tbMangeStaff.Size = new Size(732, 439);
            tbMangeStaff.TabIndex = 0;
            tbMangeStaff.Text = "Manage Staff";
            tbMangeStaff.UseVisualStyleBackColor = true;
            tbMangeStaff.Click += tbMangeStaff_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(335, 88);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(43, 19);
            label4.TabIndex = 9;
            label4.Text = "Role:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(88, 88);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(80, 19);
            label3.TabIndex = 8;
            label3.Text = "Password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(335, 25);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(54, 19);
            label2.TabIndex = 7;
            label2.Text = "Name:";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 25);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(63, 19);
            label1.TabIndex = 6;
            label1.Text = "Staff ID:";
            // 
            // btnAddStaff
            // 
            btnAddStaff.BackColor = Color.Bisque;
            btnAddStaff.Cursor = Cursors.Hand;
            btnAddStaff.FlatStyle = FlatStyle.Flat;
            btnAddStaff.Location = new Point(584, 88);
            btnAddStaff.Margin = new Padding(2, 2, 2, 2);
            btnAddStaff.Name = "btnAddStaff";
            btnAddStaff.Size = new Size(92, 28);
            btnAddStaff.TabIndex = 5;
            btnAddStaff.Text = "Add";
            btnAddStaff.UseVisualStyleBackColor = false;
            // 
            // cmbRole
            // 
            cmbRole.Cursor = Cursors.Hand;
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FlatStyle = FlatStyle.Flat;
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Manager", "Staff" });
            cmbRole.Location = new Point(394, 88);
            cmbRole.Margin = new Padding(2, 2, 2, 2);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(150, 27);
            cmbRole.TabIndex = 4;
            // 
            // txtStaffName
            // 
            txtStaffName.Cursor = Cursors.IBeam;
            txtStaffName.Location = new Point(170, 88);
            txtStaffName.Margin = new Padding(2, 2, 2, 2);
            txtStaffName.Name = "txtStaffName";
            txtStaffName.Size = new Size(123, 27);
            txtStaffName.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Cursor = Cursors.IBeam;
            txtPassword.Location = new Point(394, 22);
            txtPassword.Margin = new Padding(2, 2, 2, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(123, 27);
            txtPassword.TabIndex = 2;
            // 
            // txtStaffID
            // 
            txtStaffID.Cursor = Cursors.IBeam;
            txtStaffID.Location = new Point(170, 19);
            txtStaffID.Margin = new Padding(2, 2, 2, 2);
            txtStaffID.Name = "txtStaffID";
            txtStaffID.Size = new Size(123, 27);
            txtStaffID.TabIndex = 1;
            // 
            // dgvStaff
            // 
            dgvStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStaff.Location = new Point(5, 166);
            dgvStaff.Margin = new Padding(2, 2, 2, 2);
            dgvStaff.Name = "dgvStaff";
            dgvStaff.RowHeadersWidth = 62;
            dgvStaff.Size = new Size(723, 270);
            dgvStaff.TabIndex = 0;
            // 
            // tbManageSuppliers
            // 
            tbManageSuppliers.Controls.Add(dgvSuppliers);
            tbManageSuppliers.Controls.Add(btnAddSupplier);
            tbManageSuppliers.Controls.Add(txtSupplierName);
            tbManageSuppliers.Controls.Add(txtContact);
            tbManageSuppliers.Controls.Add(txtContactNumber);
            tbManageSuppliers.Controls.Add(txtSupplierID);
            tbManageSuppliers.Controls.Add(label8);
            tbManageSuppliers.Controls.Add(label7);
            tbManageSuppliers.Controls.Add(label6);
            tbManageSuppliers.Controls.Add(label5);
            tbManageSuppliers.Location = new Point(4, 28);
            tbManageSuppliers.Margin = new Padding(2, 2, 2, 2);
            tbManageSuppliers.Name = "tbManageSuppliers";
            tbManageSuppliers.Padding = new Padding(2, 2, 2, 2);
            tbManageSuppliers.Size = new Size(732, 439);
            tbManageSuppliers.TabIndex = 1;
            tbManageSuppliers.Text = "Manage Suppliers";
            tbManageSuppliers.UseVisualStyleBackColor = true;
            // 
            // dgvSuppliers
            // 
            dgvSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSuppliers.Location = new Point(5, 166);
            dgvSuppliers.Margin = new Padding(2, 2, 2, 2);
            dgvSuppliers.Name = "dgvSuppliers";
            dgvSuppliers.RowHeadersWidth = 62;
            dgvSuppliers.Size = new Size(723, 270);
            dgvSuppliers.TabIndex = 9;
            // 
            // btnAddSupplier
            // 
            btnAddSupplier.BackColor = Color.Bisque;
            btnAddSupplier.Cursor = Cursors.Hand;
            btnAddSupplier.FlatStyle = FlatStyle.Flat;
            btnAddSupplier.Location = new Point(625, 83);
            btnAddSupplier.Margin = new Padding(2, 2, 2, 2);
            btnAddSupplier.Name = "btnAddSupplier";
            btnAddSupplier.Size = new Size(92, 28);
            btnAddSupplier.TabIndex = 8;
            btnAddSupplier.Text = "Add";
            btnAddSupplier.UseVisualStyleBackColor = false;
            // 
            // txtSupplierName
            // 
            txtSupplierName.Cursor = Cursors.IBeam;
            txtSupplierName.Location = new Point(485, 19);
            txtSupplierName.Margin = new Padding(2, 2, 2, 2);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.Size = new Size(123, 27);
            txtSupplierName.TabIndex = 7;
            // 
            // txtContact
            // 
            txtContact.Cursor = Cursors.IBeam;
            txtContact.Location = new Point(211, 86);
            txtContact.Margin = new Padding(2, 2, 2, 2);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(123, 27);
            txtContact.TabIndex = 6;
            // 
            // txtContactNumber
            // 
            txtContactNumber.Cursor = Cursors.IBeam;
            txtContactNumber.Location = new Point(485, 83);
            txtContactNumber.Margin = new Padding(2, 2, 2, 2);
            txtContactNumber.Name = "txtContactNumber";
            txtContactNumber.Size = new Size(123, 27);
            txtContactNumber.TabIndex = 5;
            // 
            // txtSupplierID
            // 
            txtSupplierID.Cursor = Cursors.IBeam;
            txtSupplierID.Location = new Point(211, 22);
            txtSupplierID.Margin = new Padding(2, 2, 2, 2);
            txtSupplierID.Name = "txtSupplierID";
            txtSupplierID.Size = new Size(123, 27);
            txtSupplierID.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(352, 88);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(127, 19);
            label8.TabIndex = 3;
            label8.Text = "Contact Number:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(88, 88);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(117, 19);
            label7.TabIndex = 2;
            label7.Text = "Contact Person:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(356, 25);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(125, 19);
            label6.TabIndex = 1;
            label6.Text = "Company Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(118, 25);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(89, 19);
            label5.TabIndex = 0;
            label5.Text = "Supplier ID:";
            // 
            // tbManageCustomers
            // 
            tbManageCustomers.Controls.Add(btnAddCustomer);
            tbManageCustomers.Controls.Add(txtCustAddress);
            tbManageCustomers.Controls.Add(txtCustPhone);
            tbManageCustomers.Controls.Add(txtCustName);
            tbManageCustomers.Controls.Add(txtCustID);
            tbManageCustomers.Controls.Add(label12);
            tbManageCustomers.Controls.Add(label11);
            tbManageCustomers.Controls.Add(label10);
            tbManageCustomers.Controls.Add(label9);
            tbManageCustomers.Controls.Add(dgvCustomers);
            tbManageCustomers.Location = new Point(4, 28);
            tbManageCustomers.Margin = new Padding(2, 2, 2, 2);
            tbManageCustomers.Name = "tbManageCustomers";
            tbManageCustomers.Padding = new Padding(2, 2, 2, 2);
            tbManageCustomers.Size = new Size(732, 439);
            tbManageCustomers.TabIndex = 2;
            tbManageCustomers.Text = "Manage Customers";
            tbManageCustomers.UseVisualStyleBackColor = true;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.BackColor = Color.Bisque;
            btnAddCustomer.Cursor = Cursors.Hand;
            btnAddCustomer.FlatStyle = FlatStyle.Flat;
            btnAddCustomer.Location = new Point(587, 122);
            btnAddCustomer.Margin = new Padding(2, 2, 2, 2);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(92, 28);
            btnAddCustomer.TabIndex = 9;
            btnAddCustomer.Text = "Add";
            btnAddCustomer.UseVisualStyleBackColor = false;
            // 
            // txtCustAddress
            // 
            txtCustAddress.Cursor = Cursors.IBeam;
            txtCustAddress.Location = new Point(556, 77);
            txtCustAddress.Margin = new Padding(2, 2, 2, 2);
            txtCustAddress.Name = "txtCustAddress";
            txtCustAddress.Size = new Size(123, 27);
            txtCustAddress.TabIndex = 8;
            // 
            // txtCustPhone
            // 
            txtCustPhone.Cursor = Cursors.IBeam;
            txtCustPhone.Location = new Point(268, 77);
            txtCustPhone.Margin = new Padding(2, 2, 2, 2);
            txtCustPhone.Name = "txtCustPhone";
            txtCustPhone.Size = new Size(123, 27);
            txtCustPhone.TabIndex = 7;
            // 
            // txtCustName
            // 
            txtCustName.Cursor = Cursors.IBeam;
            txtCustName.Location = new Point(525, 19);
            txtCustName.Margin = new Padding(2, 2, 2, 2);
            txtCustName.Name = "txtCustName";
            txtCustName.Size = new Size(123, 27);
            txtCustName.TabIndex = 6;
            // 
            // txtCustID
            // 
            txtCustID.Cursor = Cursors.IBeam;
            txtCustID.Location = new Point(167, 16);
            txtCustID.Margin = new Padding(2, 2, 2, 2);
            txtCustID.Name = "txtCustID";
            txtCustID.Size = new Size(123, 27);
            txtCustID.TabIndex = 5;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(413, 83);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(142, 19);
            label12.TabIndex = 4;
            label12.Text = "Customer Address:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(63, 83);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(199, 19);
            label11.TabIndex = 3;
            label11.Text = "Customer Contact Number:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(394, 21);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(126, 19);
            label10.TabIndex = 2;
            label10.Text = "Customer Name:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(63, 21);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(99, 19);
            label9.TabIndex = 1;
            label9.Text = "Customer ID:";
            // 
            // dgvCustomers
            // 
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(5, 166);
            dgvCustomers.Margin = new Padding(2, 2, 2, 2);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersWidth = 62;
            dgvCustomers.Size = new Size(723, 270);
            dgvCustomers.TabIndex = 0;
            // 
            // tbManageDriversVehicles
            // 
            tbManageDriversVehicles.Controls.Add(btnAddDriver);
            tbManageDriversVehicles.Controls.Add(cmbLicense);
            tbManageDriversVehicles.Controls.Add(txtDriverName);
            tbManageDriversVehicles.Controls.Add(txtDriverID);
            tbManageDriversVehicles.Controls.Add(label15);
            tbManageDriversVehicles.Controls.Add(label14);
            tbManageDriversVehicles.Controls.Add(label13);
            tbManageDriversVehicles.Controls.Add(dgvDrivers);
            tbManageDriversVehicles.Location = new Point(4, 28);
            tbManageDriversVehicles.Margin = new Padding(2, 2, 2, 2);
            tbManageDriversVehicles.Name = "tbManageDriversVehicles";
            tbManageDriversVehicles.Padding = new Padding(2, 2, 2, 2);
            tbManageDriversVehicles.Size = new Size(732, 439);
            tbManageDriversVehicles.TabIndex = 3;
            tbManageDriversVehicles.Text = "Manage Drivers";
            tbManageDriversVehicles.UseVisualStyleBackColor = true;
            // 
            // btnAddDriver
            // 
            btnAddDriver.BackColor = Color.Bisque;
            btnAddDriver.Cursor = Cursors.Hand;
            btnAddDriver.FlatStyle = FlatStyle.Flat;
            btnAddDriver.Location = new Point(551, 88);
            btnAddDriver.Margin = new Padding(2, 2, 2, 2);
            btnAddDriver.Name = "btnAddDriver";
            btnAddDriver.Size = new Size(92, 28);
            btnAddDriver.TabIndex = 7;
            btnAddDriver.Text = "Add";
            btnAddDriver.UseVisualStyleBackColor = false;
            // 
            // cmbLicense
            // 
            cmbLicense.Cursor = Cursors.Hand;
            cmbLicense.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLicense.FlatStyle = FlatStyle.Flat;
            cmbLicense.FormattingEnabled = true;
            cmbLicense.Items.AddRange(new object[] { "LGV", "HGV" });
            cmbLicense.Location = new Point(253, 91);
            cmbLicense.Margin = new Padding(2, 2, 2, 2);
            cmbLicense.Name = "cmbLicense";
            cmbLicense.Size = new Size(150, 27);
            cmbLicense.TabIndex = 6;
            // 
            // txtDriverName
            // 
            txtDriverName.Location = new Point(520, 22);
            txtDriverName.Margin = new Padding(2, 2, 2, 2);
            txtDriverName.Name = "txtDriverName";
            txtDriverName.Size = new Size(123, 27);
            txtDriverName.TabIndex = 5;
            // 
            // txtDriverID
            // 
            txtDriverID.Location = new Point(253, 22);
            txtDriverID.Margin = new Padding(2, 2, 2, 2);
            txtDriverID.Name = "txtDriverID";
            txtDriverID.Size = new Size(123, 27);
            txtDriverID.TabIndex = 4;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(174, 91);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(63, 19);
            label15.TabIndex = 3;
            label15.Text = "License:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(414, 25);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(101, 19);
            label14.TabIndex = 2;
            label14.Text = "Driver Name:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(174, 25);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(74, 19);
            label13.TabIndex = 1;
            label13.Text = "Driver ID:";
            // 
            // dgvDrivers
            // 
            dgvDrivers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDrivers.Location = new Point(5, 166);
            dgvDrivers.Margin = new Padding(2, 2, 2, 2);
            dgvDrivers.Name = "dgvDrivers";
            dgvDrivers.RowHeadersWidth = 62;
            dgvDrivers.Size = new Size(723, 270);
            dgvDrivers.TabIndex = 0;
            // 
            // tbManageMaterialsProducts
            // 
            tbManageMaterialsProducts.Controls.Add(btnAddProduct);
            tbManageMaterialsProducts.Controls.Add(txtProdPrice);
            tbManageMaterialsProducts.Controls.Add(txtProdName);
            tbManageMaterialsProducts.Controls.Add(txtProdID);
            tbManageMaterialsProducts.Controls.Add(label19);
            tbManageMaterialsProducts.Controls.Add(label18);
            tbManageMaterialsProducts.Controls.Add(label17);
            tbManageMaterialsProducts.Controls.Add(label16);
            tbManageMaterialsProducts.Controls.Add(cmbProdCategory);
            tbManageMaterialsProducts.Controls.Add(dgvProducts);
            tbManageMaterialsProducts.Location = new Point(4, 28);
            tbManageMaterialsProducts.Margin = new Padding(2, 2, 2, 2);
            tbManageMaterialsProducts.Name = "tbManageMaterialsProducts";
            tbManageMaterialsProducts.Padding = new Padding(2, 2, 2, 2);
            tbManageMaterialsProducts.Size = new Size(732, 439);
            tbManageMaterialsProducts.TabIndex = 4;
            tbManageMaterialsProducts.Text = "Manage Products";
            tbManageMaterialsProducts.UseVisualStyleBackColor = true;
            // 
            // btnAddProduct
            // 
            btnAddProduct.BackColor = Color.Bisque;
            btnAddProduct.Cursor = Cursors.Hand;
            btnAddProduct.FlatStyle = FlatStyle.Flat;
            btnAddProduct.Location = new Point(552, 122);
            btnAddProduct.Margin = new Padding(2, 2, 2, 2);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(92, 28);
            btnAddProduct.TabIndex = 9;
            btnAddProduct.Text = "Add";
            btnAddProduct.UseVisualStyleBackColor = false;
            // 
            // txtProdPrice
            // 
            txtProdPrice.Location = new Point(214, 78);
            txtProdPrice.Margin = new Padding(2, 2, 2, 2);
            txtProdPrice.Name = "txtProdPrice";
            txtProdPrice.Size = new Size(123, 27);
            txtProdPrice.TabIndex = 8;
            txtProdPrice.Tag = "HK$";
            // 
            // txtProdName
            // 
            txtProdName.Location = new Point(495, 28);
            txtProdName.Margin = new Padding(2, 2, 2, 2);
            txtProdName.Name = "txtProdName";
            txtProdName.Size = new Size(123, 27);
            txtProdName.TabIndex = 7;
            // 
            // txtProdID
            // 
            txtProdID.Location = new Point(214, 26);
            txtProdID.Margin = new Padding(2, 2, 2, 2);
            txtProdID.Name = "txtProdID";
            txtProdID.Size = new Size(123, 27);
            txtProdID.TabIndex = 6;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(357, 84);
            label19.Margin = new Padding(2, 0, 2, 0);
            label19.Name = "label19";
            label19.Size = new Size(135, 19);
            label19.TabIndex = 5;
            label19.Text = "Product Category:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(104, 82);
            label18.Margin = new Padding(2, 0, 2, 0);
            label18.Name = "label18";
            label18.Size = new Size(105, 19);
            label18.TabIndex = 4;
            label18.Text = "Product Price:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(357, 28);
            label17.Margin = new Padding(2, 0, 2, 0);
            label17.Name = "label17";
            label17.Size = new Size(113, 19);
            label17.TabIndex = 3;
            label17.Text = "Product Name:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(123, 28);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(86, 19);
            label16.TabIndex = 2;
            label16.Text = "Product ID:";
            // 
            // cmbProdCategory
            // 
            cmbProdCategory.Cursor = Cursors.Hand;
            cmbProdCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProdCategory.FlatStyle = FlatStyle.Flat;
            cmbProdCategory.FormattingEnabled = true;
            cmbProdCategory.Items.AddRange(new object[] { "Finished Furniture", "Raw Materials" });
            cmbProdCategory.Location = new Point(495, 78);
            cmbProdCategory.Margin = new Padding(2, 2, 2, 2);
            cmbProdCategory.Name = "cmbProdCategory";
            cmbProdCategory.Size = new Size(150, 27);
            cmbProdCategory.TabIndex = 1;
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(5, 166);
            dgvProducts.Margin = new Padding(2, 2, 2, 2);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 62;
            dgvProducts.Size = new Size(723, 270);
            dgvProducts.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 469);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 11, 0);
            statusStrip1.Size = new Size(759, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 16);
            // 
            // MasterDataForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(759, 491);
            Controls.Add(statusStrip1);
            Controls.Add(tbMDForm);
            Margin = new Padding(2, 2, 2, 2);
            Name = "MasterDataForm";
            Text = "MasterDataForm";
            tbMDForm.ResumeLayout(false);
            tbMangeStaff.ResumeLayout(false);
            tbMangeStaff.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStaff).EndInit();
            tbManageSuppliers.ResumeLayout(false);
            tbManageSuppliers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).EndInit();
            tbManageCustomers.ResumeLayout(false);
            tbManageCustomers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            tbManageDriversVehicles.ResumeLayout(false);
            tbManageDriversVehicles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDrivers).EndInit();
            tbManageMaterialsProducts.ResumeLayout(false);
            tbManageMaterialsProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tbMDForm;
        private TabPage tbMangeStaff;
        private DataGridView dgvStaff;
        private TabPage tbManageSuppliers;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnAddStaff;
        private ComboBox cmbRole;
        private TextBox txtStaffName;
        private TextBox txtPassword;
        private TextBox txtStaffID;
        private DataGridView dgvSuppliers;
        private Button btnAddSupplier;
        private TextBox txtSupplierName;
        private TextBox txtContact;
        private TextBox txtContactNumber;
        private TextBox txtSupplierID;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private TabPage tbManageCustomers;
        private TabPage tbManageDriversVehicles;
        private TabPage tbManageMaterialsProducts;
        private DataGridView dgvCustomers;
        private DataGridView dgvDrivers;
        private DataGridView dgvProducts;
        private TextBox txtCustAddress;
        private TextBox txtCustPhone;
        private TextBox txtCustName;
        private TextBox txtCustID;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private ComboBox cmbLicense;
        private TextBox txtDriverName;
        private TextBox txtDriverID;
        private Label label15;
        private Label label14;
        private Label label13;
        private TextBox txtProdPrice;
        private TextBox txtProdName;
        private TextBox txtProdID;
        private Label label19;
        private Label label18;
        private Label label17;
        private Label label16;
        private ComboBox cmbProdCategory;
        private Button btnAddCustomer;
        private Button btnAddDriver;
        private Button btnAddProduct;
    }
}