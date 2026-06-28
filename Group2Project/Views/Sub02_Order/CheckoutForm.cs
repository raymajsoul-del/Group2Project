using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Group2Project.Utils;

namespace Group2Project.Views.Sub02_Order
{
    public partial class CheckoutForm : Form
    {
        private DataTable _cartData;
        private RadioButton _selectedPayment;
        
        public string PaymentMethod { get; private set; }
        public decimal Discount { get; private set; }
        public decimal PaidAmount { get; private set; }
        public bool PrintReceipt { get; private set; }
        public bool RequiresDelivery { get; private set; }
        public string DeliveryAddress { get; private set; }
        public string DeliveryContact { get; private set; }
        public DateTime? DeliveryDate { get; private set; }
        public string InstallationTime { get; private set; }
        
        public CheckoutForm(DataTable cart, string userRole)
        {
            InitializeComponent();
            _cartData = cart;
            SetupCart();
            SetupPaymentMethods();
            CalculateTotal();
            ApplyLanguage();
            
            LanguageManager.LanguageChanged += OnLanguageChanged;
        }

        private void OnLanguageChanged()
        {
            ApplyLanguage();
        }

        private void ApplyLanguage()
        {
            this.Text = LanguageManager.GetString("CheckoutForm_Title");
            lblTitle.Text = LanguageManager.GetString("CheckoutForm_Title");
            label1.Text = LanguageManager.GetString("CheckoutForm_Cart");
            label2.Text = LanguageManager.GetString("CheckoutForm_PaymentMethod");
            label3.Text = LanguageManager.GetString("CheckoutForm_Total");
            label4.Text = LanguageManager.GetString("CheckoutForm_Discount");
            label5.Text = LanguageManager.GetString("CheckoutForm_PaidAmount");
            chkPrintReceipt.Text = LanguageManager.GetString("CheckoutForm_PrintReceipt");
            label6.Text = LanguageManager.GetString("CheckoutForm_DeliveryOptions");
            chkDelivery.Text = LanguageManager.GetString("CheckoutForm_RequireDelivery");
            label7.Text = LanguageManager.GetString("CheckoutForm_Address");
            label8.Text = LanguageManager.GetString("CheckoutForm_Contact");
            label9.Text = LanguageManager.GetString("CheckoutForm_DeliveryDate");
            label10.Text = LanguageManager.GetString("CheckoutForm_InstallationTime");
            btnConfirm.Text = LanguageManager.GetString("CheckoutForm_ConfirmOrder");
            btnCancel.Text = LanguageManager.GetString("CheckoutForm_Cancel");
            
            cmbInstallationTime.Items.Clear();
            cmbInstallationTime.Items.Add(LanguageManager.GetString("CheckoutForm_Morning"));
            cmbInstallationTime.Items.Add(LanguageManager.GetString("CheckoutForm_Afternoon"));
            cmbInstallationTime.Items.Add(LanguageManager.GetString("CheckoutForm_Evening"));
        }
        
        private void SetupCart()
        {
            dgvCart.DataSource = _cartData;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.ReadOnly = true;
        }
        
        private void SetupPaymentMethods()
        {
            string[] methods = { "Cash", "Visa", "MasterCard", "Apple Pay", "Google Pay", "Alipay" };
            Color[] colors = { 
                Color.FromArgb(46, 125, 50), 
                Color.FromArgb(25, 118, 210), 
                Color.FromArgb(244, 67, 54), 
                Color.FromArgb(0, 0, 0), 
                Color.FromArgb(66, 133, 244), 
                Color.FromArgb(0, 163, 224) 
            };
            
            int x = 20;
            int y = 10;
            for (int i = 0; i < methods.Length; i++)
            {
                RadioButton rb = new RadioButton();
                rb.Text = methods[i];
                rb.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                rb.Location = new Point(x, y);
                rb.Size = new Size(150, 30);
                rb.CheckedChanged += PaymentMethod_CheckedChanged;
                if (i == 0) 
                {
                    rb.Checked = true;
                    _selectedPayment = rb;
                    PaymentMethod = methods[i];
                }
                
                pnlPaymentMethods.Controls.Add(rb);
                
                x += 170;
                if (x > 500) 
                {
                    x = 20;
                    y += 35;
                }
            }
        }
        
        private void CalculateTotal()
        {
            decimal subtotal = 0;
            foreach (DataRow row in _cartData.Rows)
            {
                subtotal += Convert.ToDecimal(row["Subtotal"]);
            }
            
            decimal tax = subtotal * 0.08m;
            decimal discount = 0;
            if (decimal.TryParse(txtDiscount.Text, out decimal disc))
            {
                discount = disc;
            }
            
            decimal total = subtotal + tax - discount;
            lblTotal.Text = $"${total:F2}";
            txtPaidAmount.Text = $"{total:F2}";
        }
        
        private void PaymentMethod_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                _selectedPayment = rb;
                PaymentMethod = rb.Text;
            }
        }
        
        private void ChkDelivery_CheckStateChanged(object sender, EventArgs e)
        {
            bool enabled = chkDelivery.Checked;
            txtDeliveryAddress.Enabled = enabled;
            txtDeliveryContact.Enabled = enabled;
            dtpDeliveryDate.Enabled = enabled;
            cmbInstallationTime.Enabled = enabled;
        }
        
        private void TxtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }
        
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PaymentMethod))
            {
                MessageBox.Show(LanguageManager.GetString("CheckoutForm_SelectPayment"), 
                    LanguageManager.GetString("POSForm_Error"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (!decimal.TryParse(txtPaidAmount.Text, out decimal paid) || paid <= 0)
            {
                MessageBox.Show(LanguageManager.GetString("CheckoutForm_ValidPaidAmount"), 
                    LanguageManager.GetString("POSForm_Error"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            decimal discount = 0;
            if (!decimal.TryParse(txtDiscount.Text, out discount))
            {
                discount = 0;
            }
            
            Discount = discount;
            PaidAmount = paid;
            PrintReceipt = chkPrintReceipt.Checked;
            RequiresDelivery = chkDelivery.Checked;
            
            if (RequiresDelivery)
            {
                if (string.IsNullOrWhiteSpace(txtDeliveryAddress.Text) || string.IsNullOrWhiteSpace(txtDeliveryContact.Text))
                {
                    MessageBox.Show(LanguageManager.GetString("CheckoutForm_FillDelivery"), 
                        LanguageManager.GetString("POSForm_Error"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                DeliveryAddress = txtDeliveryAddress.Text;
                DeliveryContact = txtDeliveryContact.Text;
                DeliveryDate = dtpDeliveryDate.Value;
                InstallationTime = cmbInstallationTime.SelectedItem?.ToString() ?? "";
            }
            
            DialogResult = DialogResult.OK;
            Close();
        }
        
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // 注意：Dispose 方法已經在 CheckoutForm.Designer.cs 中定義
        // 我們需要手動更新那個文件來取消事件訂閱
        // 這裡不再重複定義
    }
}
