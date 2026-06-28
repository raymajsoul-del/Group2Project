using System;
using System.Data;
using MySql.Data.MySqlClient;
using Group2Project.DataAccess;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections.Generic;

namespace Group2Project.Controllers
{
    public class POSController
    {
        public class CartItem
        {
            public string ProductId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal Subtotal { get; set; }
        }

        public DataTable SearchProducts(string productId, string category, string barcode, decimal? minPrice, decimal? maxPrice, string description)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = @"SELECT inv_product_id AS 'Product ID', 
                                       inv_product_name AS 'Product Name', 
                                       inv_category AS 'Category',
                                       inv_price AS 'Unit Price', 
                                       inv_stock_quantity AS 'Stock Quantity'
                                FROM inventory 
                                WHERE 1=1";

                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (!string.IsNullOrWhiteSpace(productId))
                {
                    query += " AND inv_product_id LIKE @productId";
                    parameters.Add(new MySqlParameter("@productId", "%" + productId + "%"));
                }

                if (!string.IsNullOrWhiteSpace(category))
                {
                    query += " AND inv_category LIKE @category";
                    parameters.Add(new MySqlParameter("@category", "%" + category + "%"));
                }

                if (minPrice.HasValue)
                {
                    query += " AND inv_price >= @minPrice";
                    parameters.Add(new MySqlParameter("@minPrice", minPrice.Value));
                }

                if (maxPrice.HasValue)
                {
                    query += " AND inv_price <= @maxPrice";
                    parameters.Add(new MySqlParameter("@maxPrice", maxPrice.Value));
                }

                query += " ORDER BY inv_product_name";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddRange(parameters.ToArray());
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable GetAllCategories()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = "SELECT DISTINCT inv_category AS 'Category' FROM inventory WHERE inv_category IS NOT NULL ORDER BY inv_category";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        public decimal SubmitPOSOrder(DataTable cartItems, string paymentMethod, decimal discount, decimal paidAmount, bool requiresDelivery, string deliveryAddress, string deliveryContact, DateTime? deliveryDate, string installationTime)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    decimal totalAmount = 0;
                    foreach (DataRow row in cartItems.Rows)
                    {
                        totalAmount += Convert.ToDecimal(row["Subtotal"]);
                    }

                    decimal finalAmount = totalAmount - discount;

                    string orderQuery = @"INSERT INTO orders 
                                        (order_customer_name, order_customer_contact, order_date, order_status, order_total_amount, order_discount, order_payment_method) 
                                        VALUES 
                                        ('Walk-in Customer', 'Retail', NOW(), 'Completed', @totalAmount, @discount, @paymentMethod)";

                    MySqlCommand cmdOrder = new MySqlCommand(orderQuery, conn, transaction);
                    cmdOrder.Parameters.AddWithValue("@totalAmount", finalAmount);
                    cmdOrder.Parameters.AddWithValue("@discount", discount);
                    cmdOrder.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                    cmdOrder.ExecuteNonQuery();

                    long newOrderId = cmdOrder.LastInsertedId;

                    string itemQuery = "INSERT INTO order_items (ot_order_id, ot_product_id, ot_quantity, ot_unit_price) VALUES (@oId, @pId, @qty, @price)";
                    foreach (DataRow row in cartItems.Rows)
                    {
                        MySqlCommand cmdItem = new MySqlCommand(itemQuery, conn, transaction);
                        cmdItem.Parameters.AddWithValue("@oId", newOrderId);
                        cmdItem.Parameters.AddWithValue("@pId", row["Product ID"]);
                        cmdItem.Parameters.AddWithValue("@qty", row["Quantity"]);
                        cmdItem.Parameters.AddWithValue("@price", row["Unit Price"]);
                        cmdItem.ExecuteNonQuery();

                        string updateStockQuery = "UPDATE inventory SET inv_stock_quantity = inv_stock_quantity - @qty WHERE inv_product_id = @pId";
                        MySqlCommand cmdStock = new MySqlCommand(updateStockQuery, conn, transaction);
                        cmdStock.Parameters.AddWithValue("@qty", row["Quantity"]);
                        cmdStock.Parameters.AddWithValue("@pId", row["Product ID"]);
                        cmdStock.ExecuteNonQuery();
                    }

                    if (requiresDelivery)
                    {
                        string deliveryQuery = @"INSERT INTO delivery_requests 
                                             (order_id, delivery_address, contact_phone, delivery_date, installation_time, status) 
                                             VALUES 
                                             (@orderId, @address, @contact, @deliveryDate, @installation, 'Scheduled')";
                        MySqlCommand cmdDelivery = new MySqlCommand(deliveryQuery, conn, transaction);
                        cmdDelivery.Parameters.AddWithValue("@orderId", newOrderId);
                        cmdDelivery.Parameters.AddWithValue("@address", deliveryAddress ?? "");
                        cmdDelivery.Parameters.AddWithValue("@contact", deliveryContact ?? "");
                        cmdDelivery.Parameters.AddWithValue("@deliveryDate", deliveryDate.HasValue ? (object)deliveryDate.Value : DBNull.Value);
                        cmdDelivery.Parameters.AddWithValue("@installation", installationTime ?? "");
                        cmdDelivery.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return finalAmount;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Transaction failed: " + ex.Message);
                }
            }
        }

        public void SubmitDefectReport(string productId, string productName, string defectDescription, string reportedBy)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO defect_reports 
                                   (product_id, product_name, defect_description, reported_by, report_date, status) 
                                   VALUES 
                                   (@productId, @productName, @description, @reportedBy, NOW(), 'Pending Review')";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@productId", productId);
                    cmd.Parameters.AddWithValue("@productName", productName);
                    cmd.Parameters.AddWithValue("@description", defectDescription);
                    cmd.Parameters.AddWithValue("@reportedBy", reportedBy);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to submit defect report: " + ex.Message);
                }
            }
        }

        public DataTable GetOrderHistory(string keyword)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = @"SELECT order_id AS 'Order ID', 
                                       order_customer_name AS 'Customer Name', 
                                       order_customer_contact AS 'Contact', 
                                       NULLIF(order_date, '0000-00-00 00:00:00') AS 'Order Date', 
                                       order_status AS 'Status'
                                FROM orders 
                                WHERE order_id LIKE @keyword OR order_customer_name LIKE @keyword
                                ORDER BY order_date DESC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable GetOrderDetails(string orderId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = @"SELECT oi.ot_quantity AS 'Quantity', 
                                       i.inv_product_name AS 'Product Name',
                                       oi.ot_unit_price AS 'Unit Price',
                                       oi.ot_quantity * oi.ot_unit_price AS 'Subtotal'
                                FROM order_items oi
                                JOIN inventory i ON oi.ot_product_id = i.inv_product_id
                                WHERE oi.ot_order_id = @orderId";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orderId", orderId);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        public void DeleteOrder(string orderId)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string deleteItemsQuery = "DELETE FROM order_items WHERE ot_order_id = @orderId";
                    MySqlCommand cmdItems = new MySqlCommand(deleteItemsQuery, conn, transaction);
                    cmdItems.Parameters.AddWithValue("@orderId", orderId);
                    cmdItems.ExecuteNonQuery();

                    string deleteOrderQuery = "DELETE FROM orders WHERE order_id = @orderId";
                    MySqlCommand cmdOrder = new MySqlCommand(deleteOrderQuery, conn, transaction);
                    cmdOrder.Parameters.AddWithValue("@orderId", orderId);
                    cmdOrder.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Failed to delete order: " + ex.Message);
                }
            }
        }

        public PrintDocument GenerateReceipt(string orderId, DataTable orderItems, decimal totalAmount, decimal discount, decimal paidAmount, string paymentMethod)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, printEvent) =>
            {
                Graphics g = printEvent.Graphics;
                Font titleFont = new Font("Arial", 22, FontStyle.Bold);
                Font subtitleFont = new Font("Arial", 14, FontStyle.Italic);
                Font regularFont = new Font("Arial", 12, FontStyle.Regular);
                Font boldFont = new Font("Arial", 12, FontStyle.Bold);
                Brush brush = Brushes.Black;

                int startX = 50;
                int startY = 50;
                int offset = 40;

                g.DrawString("PREMIUM LIVING FURNITURE", titleFont, brush, startX, startY);
                g.DrawString("Official Sales Receipt", subtitleFont, brush, startX, startY + offset);

                g.DrawString("-------------------------------------------------------------------", regularFont, brush, startX, startY + (offset * 2));
                g.DrawString($"Order ID: {orderId}", regularFont, brush, startX, startY + (offset * 3));
                g.DrawString($"Date: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}", regularFont, brush, startX, startY + (offset * 4));
                g.DrawString($"Payment Method: {paymentMethod}", regularFont, brush, startX, startY + (offset * 5));
                g.DrawString("-------------------------------------------------------------------", regularFont, brush, startX, startY + (offset * 6));

                int itemOffset = startY + (offset * 7);
                g.DrawString("Qty | Item Description | Unit Price | Subtotal", boldFont, brush, startX, itemOffset);
                itemOffset += 35;

                foreach (DataRow row in orderItems.Rows)
                {
                    string line = $"{row["Quantity"],4} | {row["Product Name"],-30} | ${row["Unit Price"],8} | ${row["Subtotal"],8}";
                    g.DrawString(line, regularFont, brush, startX, itemOffset);
                    itemOffset += 30;
                }

                itemOffset += 20;
                g.DrawString("-------------------------------------------------------------------", regularFont, brush, startX, itemOffset);
                itemOffset += 30;
                g.DrawString($"Subtotal: ${totalAmount + discount,10:F2}", regularFont, brush, startX + 400, itemOffset);
                itemOffset += 30;
                g.DrawString($"Discount: ${discount,10:F2}", regularFont, brush, startX + 400, itemOffset);
                itemOffset += 30;
                g.DrawString($"Total: ${totalAmount,10:F2}", boldFont, brush, startX + 400, itemOffset);
                itemOffset += 30;
                g.DrawString($"Paid: ${paidAmount,10:F2}", regularFont, brush, startX + 400, itemOffset);
                itemOffset += 40;
                g.DrawString("Thank you for your business!", subtitleFont, brush, startX, itemOffset);
                itemOffset += 30;
                g.DrawString("Please contact our After-Sales department for any warranty claims.", regularFont, brush, startX, itemOffset);
            };

            return pd;
        }

        public DataTable GetDefectReportHistory(string keyword)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = @"SELECT report_id AS 'Report ID', 
                                       product_id AS 'Product ID', 
                                       product_name AS 'Product Name',
                                       defect_description AS 'Defect Description',
                                       reported_by AS 'Reported By',
                                       report_date AS 'Report Date',
                                       status AS 'Status'
                                FROM defect_reports 
                                WHERE product_id LIKE @keyword OR product_name LIKE @keyword
                                ORDER BY report_date DESC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        public void UpdateDefectReportStatus(int reportId, string newStatus)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = "UPDATE defect_reports SET status = @status WHERE report_id = @reportId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@reportId", reportId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
