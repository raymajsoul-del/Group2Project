﻿﻿﻿using System;
using System.Data;
using System.Drawing.Printing;
using System.Text;
using MySql.Data.MySqlClient;
using Group2Project.DataAccess;

namespace Group2Project.Controllers
{
    public class MasterDataController
    {
        // ==================== 員工管理 ====================
        // 保留原有方法 - 向後兼容
        public DataTable GetStaffList()
        {
            return GetStaffList("");
        }

        // 新的增強方法
        public DataTable GetStaffList(string searchKeyword = "")
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                                        staff_id AS 'Staff ID', 
                                        staff_name AS 'Name', 
                                        role AS 'Role'
                                     FROM staff ORDER BY staff_id ASC";
                    
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (!string.IsNullOrEmpty(searchKeyword))
                    {
                        query = @"SELECT 
                                    staff_id AS 'Staff ID', 
                                    staff_name AS 'Name', 
                                    role AS 'Role'
                                  FROM staff 
                                  WHERE staff_id LIKE @kw OR staff_name LIKE @kw 
                                  ORDER BY staff_id ASC";
                        cmd.Parameters.AddWithValue("@kw", "%" + searchKeyword + "%");
                    }
                    
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch
            {
                // 範例資料
                dt.Columns.Add("Staff ID", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Role", typeof(string));
                dt.Rows.Add("S001", "John Manager", "Manager");
                dt.Rows.Add("S002", "Mary Staff", "Staff");
            }
            return dt;
        }

        public void AddStaff(string id, string name, string password, string role)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO staff (staff_id, staff_name, password, role) VALUES (@id, @name, @pwd, @role)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@pwd", password);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception("Database Error: " + ex.Message); }
            }
        }

        public DataTable GetDepartments()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Department ID", typeof(string));
            dt.Columns.Add("Department Name", typeof(string));
            
            dt.Rows.Add("ADMIN", "管理部");
            dt.Rows.Add("SALES", "銷售部");
            dt.Rows.Add("TECH", "技術部");
            dt.Rows.Add("LOGISTICS", "物流部");
            dt.Rows.Add("WAREHOUSE", "倉庫管理部");
            
            return dt;
        }

        public DataTable GetJobTitles(string departmentId = "")
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Job Title ID", typeof(string));
            dt.Columns.Add("Job Title Name", typeof(string));
            dt.Columns.Add("Department ID", typeof(string));
            
            var allJobTitles = new[]
            {
                new { Id = "MGR", Name = "部門經理", Dept = "ADMIN" },
                new { Id = "ADMIN_ASSIST", Name = "行政助理", Dept = "ADMIN" },
                new { Id = "SALES_MANAGER", Name = "銷售經理", Dept = "SALES" },
                new { Id = "SALES_STAFF", Name = "銷售專員", Dept = "SALES" },
                new { Id = "CASHIER", Name = "收銀員", Dept = "SALES" },
                new { Id = "TECH_MANAGER", Name = "技術經理", Dept = "TECH" },
                new { Id = "TECH_SENIOR", Name = "資深技術員", Dept = "TECH" },
                new { Id = "TECH_JUNIOR", Name = "技術員", Dept = "TECH" },
                new { Id = "LOGISTICS_MANAGER", Name = "物流經理", Dept = "LOGISTICS" },
                new { Id = "DRIVER", Name = "司機", Dept = "LOGISTICS" },
                new { Id = "WAREHOUSE_MANAGER", Name = "倉庫經理", Dept = "WAREHOUSE" },
                new { Id = "WAREHOUSE_STAFF", Name = "倉管員", Dept = "WAREHOUSE" }
            };
            
            foreach (var jt in allJobTitles)
            {
                if (string.IsNullOrEmpty(departmentId) || jt.Dept == departmentId)
                {
                    dt.Rows.Add(jt.Id, jt.Name, jt.Dept);
                }
            }
            
            return dt;
        }

        public DataTable GetLocations()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Location ID", typeof(string));
            dt.Columns.Add("Location Name", typeof(string));
            dt.Columns.Add("Location Type", typeof(string));
            
            dt.Rows.Add("HQ", "總部", "Office");
            dt.Rows.Add("TAIPEI_SHOP", "台北門市", "Retail Shop");
            dt.Rows.Add("KAOHSIUNG_SHOP", "高雄門市", "Retail Shop");
            dt.Rows.Add("MAIN_WAREHOUSE", "主要倉庫", "Warehouse");
            dt.Rows.Add("DELIVERY_A", "配送隊A", "Delivery Team");
            dt.Rows.Add("DELIVERY_B", "配送隊B", "Delivery Team");
            dt.Rows.Add("TECH_TEAM_1", "技術隊1", "Technical Team");
            dt.Rows.Add("TECH_TEAM_2", "技術隊2", "Technical Team");
            
            return dt;
        }

        public void AddStaff(string id, string name, string password, string department, string jobTitle, 
                          string location, string role, string phone, string email, DateTime hireDate)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO staff 
                                    (staff_id, staff_name, password, department, job_title, location, 
                                     role, contact_phone, email, hire_date, status)
                                    VALUES (@id, @name, @pwd, @dept, @title, @loc, 
                                            @role, @phone, @email, @hireDate, 'Active')";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@pwd", password);
                    cmd.Parameters.AddWithValue("@dept", department);
                    cmd.Parameters.AddWithValue("@title", jobTitle);
                    cmd.Parameters.AddWithValue("@loc", location);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@hireDate", hireDate);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception("Database Error: " + ex.Message); }
            }
        }

        public void UpdateStaff(string id, string name, string department, string jobTitle, 
                             string location, string role, string phone, string email, 
                             DateTime hireDate, string status, string newPassword = null)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE staff 
                                    SET staff_name = @name, 
                                        department = @dept,
                                        job_title = @title,
                                        location = @loc,
                                        role = @role,
                                        contact_phone = @phone,
                                        email = @email,
                                        hire_date = @hireDate,
                                        status = @status";
                    
                    if (!string.IsNullOrEmpty(newPassword))
                    {
                        query += ", password = @pwd";
                    }
                    
                    query += " WHERE staff_id = @id";
                    
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@dept", department);
                    cmd.Parameters.AddWithValue("@title", jobTitle);
                    cmd.Parameters.AddWithValue("@loc", location);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@hireDate", hireDate);
                    cmd.Parameters.AddWithValue("@status", status);
                    
                    if (!string.IsNullOrEmpty(newPassword))
                    {
                        cmd.Parameters.AddWithValue("@pwd", newPassword);
                    }
                    
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception("Database Error: " + ex.Message); }
            }
        }

        // ==================== 供應商管理 ====================
        public DataTable GetSupplierList()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT supplier_id AS 'Supplier ID', supplier_name AS 'Company Name', 
                                            contact_person AS 'Contact Person', contact_number AS 'Contact Number',
                                            address AS 'Address', status AS 'Status'
                                     FROM suppliers ORDER BY supplier_id ASC";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
            }
            catch
            {
                // 範例資料
                dt.Columns.Add("Supplier ID", typeof(string));
                dt.Columns.Add("Company Name", typeof(string));
                dt.Columns.Add("Contact Person", typeof(string));
                dt.Columns.Add("Contact Number", typeof(string));
                dt.Columns.Add("Address", typeof(string));
                dt.Columns.Add("Status", typeof(string));
                dt.Rows.Add("SUP001", "Premium Furniture Co.", "Mr. Smith", "1234-5678", "123 Main St, HK", "Active");
                dt.Rows.Add("SUP002", "Quality Supplies Ltd", "Ms. Lee", "8765-4321", "456 Oak Ave, HK", "Active");
            }
            return dt;
        }

        // 原有方法 - 保持向後兼容
        public void AddSupplier(string id, string name, string contactPerson, string contactNum)
        {
            AddSupplier(id, name, contactPerson, contactNum, "", "Active");
        }

        public void AddSupplier(string id, string name, string contactPerson, string contactNum, string address, string status)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO suppliers (supplier_id, supplier_name, contact_person, contact_number, address, status) 
                                    VALUES (@id, @name, @person, @num, @address, @status)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@person", contactPerson);
                    cmd.Parameters.AddWithValue("@num", contactNum);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    // 如果數據庫表不完整，只記錄日誌（不報錯）
                }
            }
        }

        public void UpdateSupplier(string id, string name, string contactPerson, string contactNum, string address, string status)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE suppliers 
                                    SET supplier_name = @name, contact_person = @person, contact_number = @num, 
                                        address = @address, status = @status 
                                    WHERE supplier_id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@person", contactPerson);
                    cmd.Parameters.AddWithValue("@num", contactNum);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.ExecuteNonQuery();
                }
                catch { }
            }
        }

        // ==================== 客戶管理 ====================
        public DataTable GetCustomerList()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT customer_id AS 'Customer ID', customer_name AS 'Customer Name', contact_number AS 'Phone', address AS 'Address' FROM customers ORDER BY customer_id ASC";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
            }
            catch
            {
                dt.Columns.Add("Customer ID", typeof(string));
                dt.Columns.Add("Customer Name", typeof(string));
                dt.Columns.Add("Phone", typeof(string));
                dt.Columns.Add("Address", typeof(string));
                dt.Rows.Add("C001", "Mr. Customer", "9876-5432", "789 Pine Rd, HK");
            }
            return dt;
        }

        public void AddCustomer(string id, string name, string phone, string address)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO customers (customer_id, customer_name, contact_number, address) VALUES (@id, @name, @phone, @address)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception("Database Error: " + ex.Message); }
            }
        }

        // ==================== 司機管理 ====================
        public DataTable GetDriverList()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT driver_id AS 'Driver ID', driver_name AS 'Driver Name', license_type AS 'License Type' FROM drivers ORDER BY driver_id ASC";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
            }
            catch
            {
                dt.Columns.Add("Driver ID", typeof(string));
                dt.Columns.Add("Driver Name", typeof(string));
                dt.Columns.Add("License Type", typeof(string));
                dt.Rows.Add("D001", "Tom Driver", "Class 1");
            }
            return dt;
        }

        public void AddDriver(string id, string name, string license)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO drivers (driver_id, driver_name, license_type) VALUES (@id, @name, @license)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@license", license);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception("Database Error: " + ex.Message); }
            }
        }

        // ==================== 商品管理 ====================
        public DataTable GetProductList()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT item_id AS 'Item ID', item_name AS 'Item Name', 
                                            category AS 'Category', unit_price AS 'Unit Price',
                                            purchase_price AS 'Purchase Price', description AS 'Description',
                                            status AS 'Status'
                                     FROM products_master ORDER BY item_id ASC";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
            }
            catch
            {
                // 範例資料
                dt.Columns.Add("Item ID", typeof(string));
                dt.Columns.Add("Item Name", typeof(string));
                dt.Columns.Add("Category", typeof(string));
                dt.Columns.Add("Unit Price", typeof(decimal));
                dt.Columns.Add("Purchase Price", typeof(decimal));
                dt.Columns.Add("Description", typeof(string));
                dt.Columns.Add("Status", typeof(string));
                dt.Rows.Add("P001", "Luxury Sofa", "Furniture", 9999.99, 5000.00, "High quality fabric sofa", "Active");
                dt.Rows.Add("P002", "Dining Table", "Furniture", 5999.99, 3000.00, "Wooden dining table 6 seater", "Active");
                dt.Rows.Add("P003", "Office Chair", "Office", 1299.99, 600.00, "Ergonomic office chair", "Active");
            }
            return dt;
        }

        // 原有方法 - 保持向後兼容
        public void AddProduct(string id, string name, string category, decimal price)
        {
            AddProduct(id, name, category, price, price * 0.7m, "", "Active");
        }

        public void AddProduct(string id, string name, string category, decimal price, decimal purchasePrice, string description, string status)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO products_master (item_id, item_name, category, unit_price, purchase_price, description, status) 
                                    VALUES (@id, @name, @category, @price, @purchasePrice, @desc, @status)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@purchasePrice", purchasePrice);
                    cmd.Parameters.AddWithValue("@desc", description);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception("Database Error: " + ex.Message); }
            }
        }

        public void UpdateProduct(string id, string name, string category, decimal price, decimal purchasePrice, string description, string status)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE products_master 
                                    SET item_name = @name, category = @category, unit_price = @price, 
                                        purchase_price = @purchasePrice, description = @desc, status = @status 
                                    WHERE item_id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@purchasePrice", purchasePrice);
                    cmd.Parameters.AddWithValue("@desc", description);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.ExecuteNonQuery();
                }
                catch { }
            }
        }

        public void DeleteProduct(string id)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM products_master WHERE item_id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                catch { }
            }
        }

        // ==================== PDF 匯出功能 ====================
        public PrintDocument GenerateProductListPDF()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, e) =>
            {
                Graphics g = e.Graphics;
                Font titleFont = new Font("Arial", 20, FontStyle.Bold);
                Font headerFont = new Font("Arial", 12, FontStyle.Bold);
                Font contentFont = new Font("Arial", 10);
                Brush brush = Brushes.Black;
                int yPos = 50;
                int leftMargin = 50;

                // 抬頭
                g.DrawString("Premium Living Furniture - Product List", titleFont, brush, leftMargin, yPos);
                yPos += 40;
                g.DrawString($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm}", contentFont, brush, leftMargin, yPos);
                yPos += 30;

                // 分隔線
                g.DrawLine(Pens.Black, leftMargin, yPos, e.PageBounds.Width - leftMargin, yPos);
                yPos += 20;

                // 表頭
                g.DrawString("Item ID", headerFont, brush, leftMargin, yPos);
                g.DrawString("Item Name", headerFont, brush, 150, yPos);
                g.DrawString("Category", headerFont, brush, 350, yPos);
                g.DrawString("Retail Price", headerFont, brush, 480, yPos);
                g.DrawString("Purchase Price", headerFont, brush, 600, yPos);
                g.DrawString("Status", headerFont, brush, 750, yPos);
                yPos += 25;
                g.DrawLine(Pens.Gray, leftMargin, yPos, e.PageBounds.Width - leftMargin, yPos);
                yPos += 20;

                // 內容
                DataTable products = GetProductList();
                foreach (DataRow row in products.Rows)
                {
                    if (yPos > e.PageBounds.Height - 100)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                    g.DrawString(row["Item ID"].ToString(), contentFont, brush, leftMargin, yPos);
                    g.DrawString(row["Item Name"].ToString(), contentFont, brush, 150, yPos);
                    g.DrawString(row["Category"].ToString(), contentFont, brush, 350, yPos);
                    g.DrawString(Convert.ToDecimal(row["Unit Price"]).ToString("C2"), contentFont, brush, 480, yPos);
                    
                    string purchasePrice = row["Purchase Price"] != DBNull.Value ? 
                        Convert.ToDecimal(row["Purchase Price"]).ToString("C2") : "-";
                    g.DrawString(purchasePrice, contentFont, brush, 600, yPos);
                    
                    g.DrawString(row["Status"].ToString(), contentFont, brush, 750, yPos);
                    yPos += 20;
                }

                yPos += 20;
                g.DrawLine(Pens.Gray, leftMargin, yPos, e.PageBounds.Width - leftMargin, yPos);
                yPos += 20;
                g.DrawString($"Total Products: {products.Rows.Count}", headerFont, brush, leftMargin, yPos);
            };
            return pd;
        }

        public PrintDocument GenerateSupplierListPDF()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, e) =>
            {
                Graphics g = e.Graphics;
                Font titleFont = new Font("Arial", 20, FontStyle.Bold);
                Font headerFont = new Font("Arial", 12, FontStyle.Bold);
                Font contentFont = new Font("Arial", 10);
                Brush brush = Brushes.Black;
                int yPos = 50;
                int leftMargin = 50;

                g.DrawString("Premium Living Furniture - Supplier List", titleFont, brush, leftMargin, yPos);
                yPos += 40;
                g.DrawString($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm}", contentFont, brush, leftMargin, yPos);
                yPos += 30;
                g.DrawLine(Pens.Black, leftMargin, yPos, e.PageBounds.Width - leftMargin, yPos);
                yPos += 20;

                g.DrawString("Supplier ID", headerFont, brush, leftMargin, yPos);
                g.DrawString("Company Name", headerFont, brush, 150, yPos);
                g.DrawString("Contact Person", headerFont, brush, 350, yPos);
                g.DrawString("Contact Number", headerFont, brush, 500, yPos);
                g.DrawString("Status", headerFont, brush, 650, yPos);
                yPos += 25;
                g.DrawLine(Pens.Gray, leftMargin, yPos, e.PageBounds.Width - leftMargin, yPos);
                yPos += 20;

                DataTable suppliers = GetSupplierList();
                foreach (DataRow row in suppliers.Rows)
                {
                    if (yPos > e.PageBounds.Height - 100)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                    g.DrawString(row["Supplier ID"].ToString(), contentFont, brush, leftMargin, yPos);
                    g.DrawString(row["Company Name"].ToString(), contentFont, brush, 150, yPos);
                    g.DrawString(row["Contact Person"].ToString(), contentFont, brush, 350, yPos);
                    g.DrawString(row["Contact Number"].ToString(), contentFont, brush, 500, yPos);
                    g.DrawString(row["Status"].ToString(), contentFont, brush, 650, yPos);
                    yPos += 20;
                }

                yPos += 20;
                g.DrawLine(Pens.Gray, leftMargin, yPos, e.PageBounds.Width - leftMargin, yPos);
                yPos += 20;
                g.DrawString($"Total Suppliers: {suppliers.Rows.Count}", headerFont, brush, leftMargin, yPos);
            };
            return pd;
        }
    }
}