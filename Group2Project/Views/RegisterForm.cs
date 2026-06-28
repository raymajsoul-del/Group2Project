using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Group2Project.DataAccess;

namespace Group2Project.Views
{
    public partial class RegisterForm : Form
    {
        private TextBox txtID, txtName, txtPhone, txtAddress, txtEmail;
        private Label lblTitle, lblSubtitle;
        private Button btnRegister, btnCancel;

     
        private Color colorMujiWhite = Color.FromArgb(253, 253, 253);
        private Color colorMujiGray = Color.FromArgb(100, 100, 100);
        private Color colorMujiDark = Color.FromArgb(60, 60, 60);
        private Color colorMujiWood = Color.FromArgb(205, 190, 175);

        public RegisterForm()
        {
            InitializeComponent();
            SetupMujiUI();
        }

        private void SetupMujiUI()
        {
            this.Text = "CCMS - Sign Up";
            this.Size = new Size(450, 650);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = colorMujiWhite;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            lblTitle = new Label { Text = "Sign Up.", Font = new Font("Segoe UI Light", 32), ForeColor = colorMujiDark, AutoSize = true, Location = new Point(50, 40) };
            lblSubtitle = new Label { Text = "Join us as a valued customer.", Font = new Font("Segoe UI", 10), ForeColor = colorMujiGray, AutoSize = true, Location = new Point(55, 100) };

            int startY = 150;
            int spacing = 75;

            txtID = CreateMujiTextBox("Customer ID (e.g. C001)", startY);
            txtName = CreateMujiTextBox("Full Name", startY + spacing);
            txtPhone = CreateMujiTextBox("Phone Number (Used as Password)", startY + spacing * 2);
            txtEmail = CreateMujiTextBox("Email Address", startY + spacing * 3);
            txtAddress = CreateMujiTextBox("Delivery Address", startY + spacing * 4);
            txtEmail = CreateMujiTextBox("Email Address (For Password Reset)", startY + spacing * 4);

            btnRegister = new Button { Text = "Create Account", Font = new Font("Segoe UI", 12), BackColor = colorMujiWood, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Size = new Size(330, 45), Location = new Point(50, 560), Cursor = Cursors.Hand };
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Click += BtnRegister_Click;


            btnCancel = new Button { Text = "Back to Login", Font = new Font("Segoe UI", 10), BackColor = colorMujiWhite, ForeColor = colorMujiGray, FlatStyle = FlatStyle.Flat, Size = new Size(330, 45), Location = new Point(50, 540), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 1;
            btnCancel.FlatAppearance.BorderColor = colorMujiGray;
            btnCancel.Click += (s, e) => this.Close();

            this.Controls.Add(lblTitle); this.Controls.Add(lblSubtitle);
            this.Controls.Add(btnRegister); this.Controls.Add(btnCancel);
        }

        private TextBox CreateMujiTextBox(string placeholder, int y)
        {
            Label lbl = new Label { Text = placeholder, Font = new Font("Segoe UI", 9), ForeColor = colorMujiGray, AutoSize = true, Location = new Point(50, y) };
            TextBox txt = new TextBox { Font = new Font("Segoe UI", 12), ForeColor = colorMujiDark, BorderStyle = BorderStyle.None, BackColor = colorMujiWhite, Location = new Point(55, y + 25), Width = 320 };
            Panel line = new Panel { BackColor = colorMujiWood, Location = new Point(50, y + 50), Width = 330, Height = 2 };

            this.Controls.Add(lbl); this.Controls.Add(txt); this.Controls.Add(line);
            return txt;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string id = txtID.Text.Trim();
            string name = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please fill in your ID, Name, Phone Number, and Email Address.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO customers (customer_id, customer_name, contact_number, address, email) VALUES (@id, @name, @phone, @addr, @email)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@addr", address);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Account created successfully! You can now log in.", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error (ID might already exist): " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}