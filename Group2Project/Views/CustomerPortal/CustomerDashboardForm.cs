using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using MySql.Data.MySqlClient;
using Group2Project.DataAccess;
using Group2Project.Models;

namespace Group2Project.Views.CustomerPortal
{
    public class CartItem
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string ImageName { get; set; }
    }

    public partial class CustomerDashboardForm : Form
    {
        private Staff _currentCustomer;
        private List<CartItem> _shoppingCart = new List<CartItem>();
        private int _totalOrdersCount = 0;

        private Panel pnlTopNav, pnlContent, pnlNavButtons;
        private Label lblLogo;
        private Button btnShop, btnCart, btnMyOrders, btnSupport, btnLogout;

        private Color colorWhite = Color.FromArgb(255, 255, 255);
        private Color colorBlackText = Color.FromArgb(20, 20, 20);
        private Color colorGrayText = Color.FromArgb(150, 150, 150);
        private Color colorAccent = Color.FromArgb(113, 160, 138);

        public CustomerDashboardForm(Staff customer)
        {
            InitializeComponent();
            _currentCustomer = customer;
            SetupQuattisUI();
            LoadInitialOrderCount();
        }

        private void SetupQuattisUI()
        {
            this.Text = "PREMIUM LIVING - Customer Portal";
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = colorWhite;

            pnlTopNav = new Panel { Dock = DockStyle.Top, Height = 80, BackColor = colorWhite };
            Panel pnlLine = new Panel { Dock = DockStyle.Bottom, Height = 1, BackColor = Color.FromArgb(230, 230, 230) };
            pnlTopNav.Controls.Add(pnlLine);

            lblLogo = new Label { Text = "PREMIUM LIVING", Font = new Font("Arial", 18, FontStyle.Bold), ForeColor = colorAccent, AutoSize = true, Location = new Point(50, 25), UseCompatibleTextRendering = false };

            pnlNavButtons = new Panel { Dock = DockStyle.Right, Width = 650, BackColor = colorWhite };

            btnShop = CreateNavButton("SHOP", 0);
            btnCart = CreateNavButton("CART (0)", 120);
            btnMyOrders = CreateNavButton("MY ORDERS", 250);
            btnSupport = CreateNavButton("SUPPORT", 390);
            btnLogout = CreateNavButton("LOGOUT", 510);

            btnShop.Click += (s, e) => LoadShopPage();
            btnCart.Click += (s, e) => LoadCartPage();
            btnMyOrders.Click += (s, e) => LoadOrdersPage();
            btnSupport.Click += (s, e) => LoadSupportPage();
            btnLogout.Click += (s, e) => { this.Close(); };

            btnMyOrders.Paint += (s, e) =>
            {
                if (_totalOrdersCount > 0)
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    string countText = _totalOrdersCount.ToString();
                    Font badgeFont = new Font("Arial", 8, FontStyle.Bold);
                    SizeF textSize = e.Graphics.MeasureString(countText, badgeFont);

                    int circleSize = Math.Max(18, (int)textSize.Width + 6);
                    int x = btnMyOrders.Width - circleSize - 10;
                    int y = 2;

                    e.Graphics.FillEllipse(Brushes.Red, x, y, circleSize, circleSize);
                    e.Graphics.DrawString(countText, badgeFont, Brushes.White, x + (circleSize - textSize.Width) / 2, y + (circleSize - textSize.Height) / 2 + 1);
                }
            };

            pnlNavButtons.Controls.Add(btnShop); pnlNavButtons.Controls.Add(btnCart); pnlNavButtons.Controls.Add(btnMyOrders);
            pnlNavButtons.Controls.Add(btnSupport); pnlNavButtons.Controls.Add(btnLogout);

            pnlTopNav.Controls.Add(lblLogo);
            pnlTopNav.Controls.Add(pnlNavButtons);

            pnlContent = new Panel { Dock = DockStyle.Fill, BackColor = colorWhite, AutoScroll = true };
            this.Controls.Add(pnlContent);
            this.Controls.Add(pnlTopNav);
            this.Shown += (s, e) => LoadShopPage();
        }

        private Button CreateNavButton(string text, int x)
        {
            Button btn = new Button
            {
                Text = text,
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = colorGrayText,
                BackColor = colorWhite,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(120, 30),
                Location = new Point(x, 25),
                Cursor = Cursors.Hand,
                UseCompatibleTextRendering = false
            };
            btn.FlatAppearance.BorderSize = 0; btn.FlatAppearance.MouseOverBackColor = colorWhite;
            btn.MouseEnter += (s, e) => { btn.ForeColor = colorBlackText; };
            btn.MouseLeave += (s, e) => { btn.ForeColor = colorGrayText; };
            return btn;
        }

        private void LoadInitialOrderCount()
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM orders WHERE customer_id = @cid", conn);
                    cmd.Parameters.AddWithValue("@cid", _currentCustomer.StaffName);
                    _totalOrdersCount = Convert.ToInt32(cmd.ExecuteScalar());
                    btnMyOrders.Invalidate();
                }
                catch { }
            }
        }

        private void UpdateCartButton()
        {
            int totalItems = _shoppingCart.Sum(item => item.Quantity);
            btnCart.Text = $"CART ({totalItems})";
            btnCart.ForeColor = totalItems > 0 ? colorAccent : colorGrayText;
        }


        private void LoadShopPage()
        {
            pnlContent.Controls.Clear();

            PictureBox pbHero = new PictureBox { Dock = DockStyle.Top, Height = 450, BackColor = Color.FromArgb(245, 245, 245) };
            string heroPath = Path.Combine(Application.StartupPath, "hero_banner.jpg");
            Image heroImg = File.Exists(heroPath) ? Image.FromFile(heroPath) : null;
            pbHero.Paint += (s, e) =>
            {
                if (heroImg != null)
                {
                    e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    float scale = Math.Max((float)pbHero.Width / heroImg.Width, (float)pbHero.Height / heroImg.Height);
                    int w = (int)(heroImg.Width * scale), h = (int)(heroImg.Height * scale);
                    e.Graphics.DrawImage(heroImg, (pbHero.Width - w) / 2, (pbHero.Height - h) / 2, w, h);
                }
            };
            pbHero.Resize += (s, e) => pbHero.Invalidate();

            Panel pnlTitle = new Panel { Dock = DockStyle.Top, Height = 120, BackColor = colorWhite };
            Label lblTitle = new Label { Text = "NEW ARRIVALS", Font = new Font("Segoe UI Light", 24), ForeColor = colorBlackText, AutoSize = true, Location = new Point(45, 50) };
            pnlTitle.Controls.Add(lblTitle);

            FlowLayoutPanel flpProducts = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(50, 0, 50, 50),
                WrapContents = true,
                BackColor = colorWhite
            };

            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT item_id, item_name, unit_price FROM products_master LIMIT 9", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    int imgIndex = 1;

                    while (reader.Read())
                    {
                        string pId = reader["item_id"].ToString();
                        string pName = reader["item_name"].ToString();
                        decimal pPrice = Convert.ToDecimal(reader["unit_price"]);
                        string imgName = $"prod_{imgIndex}.jpg";

                        Panel card = CreateProductCard(pId, pName, pPrice, imgName);
                        flpProducts.Controls.Add(card);
                        imgIndex = (imgIndex % 9) + 1;
                    }
                }
                catch (Exception ex) { MessageBox.Show("Failed to load products: " + ex.Message); }
            }

            pnlContent.Controls.Add(flpProducts);
            pnlContent.Controls.Add(pnlTitle);
            pnlContent.Controls.Add(pbHero);
        }

        private Panel CreateProductCard(string id, string name, decimal price, string imgName)
        {
            Panel pnl = new Panel { Size = new Size(320, 400), Margin = new Padding(0, 0, 40, 50) };
            PictureBox pb = new PictureBox { Size = new Size(320, 260), Location = new Point(0, 0), SizeMode = PictureBoxSizeMode.Zoom, BackColor = Color.FromArgb(250, 250, 250) };
            string imgPath = Path.Combine(Application.StartupPath, imgName);
            if (File.Exists(imgPath)) pb.Image = Image.FromFile(imgPath);

            Label lblName = new Label { Text = name, Font = new Font("Segoe UI", 12), ForeColor = colorBlackText, Location = new Point(0, 275), AutoSize = true };


            Label lblPrice = new Label { Text = $" HK${price:0.00}", Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = colorGrayText, Location = new Point(0, 305), AutoSize = true };

            Button btnBuy = new Button { Text = "ADD TO CART", Font = new Font("Segoe UI", 9, FontStyle.Bold), BackColor = colorBlackText, ForeColor = colorWhite, FlatStyle = FlatStyle.Flat, Size = new Size(120, 35), Location = new Point(0, 345), Cursor = Cursors.Hand };
            btnBuy.FlatAppearance.BorderSize = 0;

            btnBuy.Click += (s, e) => {
                var existingItem = _shoppingCart.FirstOrDefault(x => x.ItemId == id);
                if (existingItem != null) { existingItem.Quantity++; }
                else { _shoppingCart.Add(new CartItem { ItemId = id, ItemName = name, UnitPrice = price, Quantity = 1, ImageName = imgName }); }

                UpdateCartButton();
                btnBuy.Text = "ADDED ✓";
                btnBuy.BackColor = colorAccent;
                System.Windows.Forms.Timer t = new System.Windows.Forms.Timer { Interval = 1000 };
                t.Tick += (ts, te) => { btnBuy.Text = "ADD TO CART"; btnBuy.BackColor = colorBlackText; t.Stop(); };
                t.Start();
            };

            pnl.Controls.Add(pb); pnl.Controls.Add(lblName); pnl.Controls.Add(lblPrice); pnl.Controls.Add(btnBuy);
            return pnl;
        }


        private void LoadCartPage()
        {
            pnlContent.Controls.Clear();

            Label lblTitle = new Label { Text = "SHOPPING CART", Font = new Font("Segoe UI Light", 24), ForeColor = colorBlackText, AutoSize = true, Location = new Point(50, 50) };
            pnlContent.Controls.Add(lblTitle);

            if (_shoppingCart.Count == 0)
            {
                Label lblEmpty = new Label { Text = "Your cart is currently empty. Go add some beautiful furniture!", Font = new Font("Segoe UI", 12), ForeColor = colorGrayText, AutoSize = true, Location = new Point(55, 120) };
                pnlContent.Controls.Add(lblEmpty);
                return;
            }

            int startY = 130;
            decimal grandTotal = 0;

            foreach (var item in _shoppingCart.ToList())
            {
                Panel pnlItem = new Panel { Size = new Size(1000, 100), Location = new Point(50, startY), BackColor = Color.White };

                PictureBox pb = new PictureBox { Size = new Size(100, 100), Location = new Point(0, 0), SizeMode = PictureBoxSizeMode.Zoom };
                string imgPath = Path.Combine(Application.StartupPath, item.ImageName);
                if (File.Exists(imgPath)) pb.Image = Image.FromFile(imgPath);

                Label lblName = new Label { Text = item.ItemName, Font = new Font("Segoe UI", 14), Location = new Point(120, 20), AutoSize = true };


                Label lblPrice = new Label { Text = $" HK${item.UnitPrice:0.00}", Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = colorGrayText, Location = new Point(120, 50), AutoSize = true };

                Button btnMinus = new Button { Text = "-", Font = new Font("Arial", 12), Size = new Size(35, 35), Location = new Point(550, 32), FlatStyle = FlatStyle.Flat };
                Label lblQty = new Label { Text = item.Quantity.ToString(), Font = new Font("Segoe UI", 14), Location = new Point(605, 38), AutoSize = true };
                Button btnPlus = new Button { Text = "+", Font = new Font("Arial", 12), Size = new Size(35, 35), Location = new Point(650, 32), FlatStyle = FlatStyle.Flat };

                Label lblSubTotal = new Label { Text = $" HK${(item.UnitPrice * item.Quantity):0.00}", Font = new Font("Segoe UI", 14, FontStyle.Bold), Location = new Point(730, 38), AutoSize = true };

                Button btnRemove = new Button { Text = "✕", ForeColor = Color.Red, Font = new Font("Arial", 14), Size = new Size(40, 40), Location = new Point(900, 30), FlatStyle = FlatStyle.Flat };
                btnRemove.FlatAppearance.BorderSize = 0;

                btnMinus.Click += (s, e) => { if (item.Quantity > 1) { item.Quantity--; UpdateCartButton(); LoadCartPage(); } };
                btnPlus.Click += (s, e) => { item.Quantity++; UpdateCartButton(); LoadCartPage(); };
                btnRemove.Click += (s, e) => { _shoppingCart.Remove(item); UpdateCartButton(); LoadCartPage(); };

                pnlItem.Controls.Add(pb); pnlItem.Controls.Add(lblName); pnlItem.Controls.Add(lblPrice);
                pnlItem.Controls.Add(btnMinus); pnlItem.Controls.Add(lblQty); pnlItem.Controls.Add(btnPlus);
                pnlItem.Controls.Add(lblSubTotal); pnlItem.Controls.Add(btnRemove);
                pnlContent.Controls.Add(pnlItem);

                startY += 120;
                grandTotal += (item.UnitPrice * item.Quantity);
            }

            Panel pnlLine = new Panel { Size = new Size(1000, 2), Location = new Point(50, startY), BackColor = Color.Black };
            Label lblTotalText = new Label { Text = "GRAND TOTAL:", Font = new Font("Segoe UI", 16, FontStyle.Bold), Location = new Point(550, startY + 20), AutoSize = true };


            Label lblGrandTotal = new Label { Text = $" HK${grandTotal:0.00}", Font = new Font("Segoe UI", 20, FontStyle.Bold), ForeColor = colorAccent, Location = new Point(750, startY + 15), AutoSize = true };

            Button btnCheckout = new Button { Text = "CHECKOUT", Font = new Font("Segoe UI", 14, FontStyle.Bold), BackColor = colorBlackText, ForeColor = colorWhite, FlatStyle = FlatStyle.Flat, Size = new Size(250, 50), Location = new Point(700, startY + 80), Cursor = Cursors.Hand };
            btnCheckout.FlatAppearance.BorderSize = 0;

            btnCheckout.Click += (s, e) =>
            {
                using (MySqlConnection conn = DatabaseManager.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string newOrderId = "ORD" + DateTime.Now.ToString("yyyyMMddHHmmss");

                        string query = "INSERT INTO orders (order_id, customer_id, total_amount, status) VALUES (@oid, @cid, @total, 'Pending')";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@oid", newOrderId);
                        cmd.Parameters.AddWithValue("@cid", _currentCustomer.StaffName);
                        cmd.Parameters.AddWithValue("@total", grandTotal);
                        cmd.ExecuteNonQuery();


                        foreach (var item in _shoppingCart)
                        {
                            string itemQuery = "INSERT INTO order_items (ot_order_id, ot_product_id, ot_quantity, ot_unit_price) VALUES (@oid, @pid, @qty, @price)";
                            MySqlCommand itemCmd = new MySqlCommand(itemQuery, conn);
                            itemCmd.Parameters.AddWithValue("@oid", newOrderId);
                            itemCmd.Parameters.AddWithValue("@pid", item.ItemId);
                            itemCmd.Parameters.AddWithValue("@qty", item.Quantity);
                            itemCmd.Parameters.AddWithValue("@price", item.UnitPrice);
                            itemCmd.ExecuteNonQuery();
                        }

                        _shoppingCart.Clear();
                        UpdateCartButton();
                        LoadInitialOrderCount();
                        LoadOrdersPage();
                    }
                    catch (Exception ex) { MessageBox.Show("Checkout Failed: " + ex.Message); }
                }
            };

            pnlContent.Controls.Add(pnlLine); pnlContent.Controls.Add(lblTotalText);
            pnlContent.Controls.Add(lblGrandTotal); pnlContent.Controls.Add(btnCheckout);
        }


        private void LoadOrdersPage()
        {
            pnlContent.Controls.Clear();
            Label lblTitle = new Label { Text = "YOUR ORDERS", Font = new Font("Segoe UI Light", 24), ForeColor = colorBlackText, AutoSize = true, Location = new Point(50, 50) };
            pnlContent.Controls.Add(lblTitle);

            DataGridView dgv = new DataGridView
            {
                Location = new Point(50, 120),
                Size = new Size(pnlContent.ClientSize.Width - 100, 500),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                BackgroundColor = colorWhite,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                EnableHeadersVisualStyles = false,
                ColumnHeadersHeight = 45,
                RowTemplate = { Height = 40 },
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                GridColor = Color.FromArgb(230, 230, 230)
            };
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = colorBlackText;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dgv.DefaultCellStyle.Font = new Font("Arial", 10);
            dgv.DefaultCellStyle.SelectionBackColor = colorAccent;
            dgv.DefaultCellStyle.SelectionForeColor = colorWhite;

            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            order_id AS 'Order Ref.', 
                            DATE_FORMAT(order_date, '%Y-%m-%d %H:%i') AS 'Date', 
                            total_amount AS 'Total (HKD)', 
                            status AS 'Status',
                            IFNULL(DATE_FORMAT(delivery_date, '%Y-%m-%d'), 'Pending...') AS 'Est. Delivery',
                            IFNULL(delivery_staff, 'Not Assigned Yet') AS 'Delivery By'
                        FROM orders 
                        WHERE customer_id = @cid 
                        ORDER BY order_date DESC";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@cid", _currentCustomer.StaffName);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dt.Columns.Add("No.", typeof(int)).SetOrdinal(0);
                        int totalCount = dt.Rows.Count;
                        for (int i = 0; i < totalCount; i++)
                        {
                            dt.Rows[i]["No."] = totalCount - i;
                        }

                        dgv.DataSource = dt;

                      
                        pnlContent.Controls.Add(dgv);

                        
                        dgv.Columns[0].Width = 60;
                    }
                    else
                    {
                        Label lblEmpty = new Label { Text = "You don't have any orders yet.", Font = new Font("Segoe UI", 12), ForeColor = colorGrayText, AutoSize = true, Location = new Point(55, 120) };
                        pnlContent.Controls.Add(lblEmpty);
                    }
                }
                catch (Exception ex)
                {
                    Label lblErr = new Label { Text = "Error loading orders: " + ex.Message, ForeColor = Color.Red, AutoSize = true, Location = new Point(55, 120) };
                    pnlContent.Controls.Add(lblErr);
                }
            }
        }


        private void LoadSupportPage()
        {
            pnlContent.Controls.Clear();
            Label lblTitle = new Label { Text = "CUSTOMER SUPPORT", Font = new Font("Segoe UI Light", 24), ForeColor = colorBlackText, AutoSize = true, Location = new Point(50, 50) };

            Label lblSub = new Label { Text = "Need help with an order? Send us a message.", Font = new Font("Segoe UI", 10), ForeColor = colorGrayText, AutoSize = true, Location = new Point(55, 115) };

            Label lblOrder = new Label { Text = "Order Ref. (e.g. ORD...)", Font = new Font("Segoe UI", 10), Location = new Point(50, 165) };
            TextBox txtOrder = new TextBox { Font = new Font("Segoe UI", 12), Size = new Size(300, 30), Location = new Point(50, 190) };

            Label lblIssue = new Label { Text = "Describe the Issue", Font = new Font("Segoe UI", 10), Location = new Point(50, 235) };
            TextBox txtIssue = new TextBox { Font = new Font("Segoe UI", 12), Size = new Size(pnlContent.ClientSize.Width - 100, 150), Location = new Point(50, 260), Multiline = true, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };

            Button btnSubmit = new Button { Text = "SUBMIT REQUEST", Font = new Font("Segoe UI", 10, FontStyle.Bold), BackColor = colorBlackText, ForeColor = colorWhite, FlatStyle = FlatStyle.Flat, Size = new Size(200, 45), Location = new Point(50, 435), Cursor = Cursors.Hand };
            btnSubmit.FlatAppearance.BorderSize = 0;

            btnSubmit.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtOrder.Text) || string.IsNullOrWhiteSpace(txtIssue.Text)) { MessageBox.Show("Please fill all fields."); return; }
                using (MySqlConnection conn = DatabaseManager.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "INSERT INTO after_sales_requests (customer_id, order_id, issue_description) VALUES (@cid, @oid, @issue)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@cid", _currentCustomer.StaffName);
                        cmd.Parameters.AddWithValue("@oid", txtOrder.Text);
                        cmd.Parameters.AddWithValue("@issue", txtIssue.Text);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Request submitted. Our team will contact you soon.", "Success");
                        txtOrder.Clear(); txtIssue.Clear();
                    }
                    catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                }
            };

            pnlContent.Controls.Add(lblTitle); pnlContent.Controls.Add(lblSub);
            pnlContent.Controls.Add(lblOrder); pnlContent.Controls.Add(txtOrder);
            pnlContent.Controls.Add(lblIssue); pnlContent.Controls.Add(txtIssue);
            pnlContent.Controls.Add(btnSubmit);
        }
    }
}