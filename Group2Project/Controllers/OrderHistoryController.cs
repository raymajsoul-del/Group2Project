using System;
using System.Data;
using MySql.Data.MySqlClient;
using Group2Project.DataAccess;

namespace Group2Project.Controllers
{
    public class OrderHistoryController
    {
        public DataTable GetOrdersOverview()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                                        o.order_id AS 'Order ID', 
                                        o.order_customer_name AS 'Customer Name', 
                                        o.order_customer_contact AS 'Contact Number', 
                                        NULLIF(o.order_date, '0000-00-00 00:00:00') AS 'Date', 
                                        o.order_status AS 'Status',
                                        COALESCE(SUM(oi.ot_quantity * oi.ot_unit_price), 0) AS 'Total Amount'
                                     FROM orders o
                                     LEFT JOIN order_items oi ON o.order_id = oi.ot_order_id
                                     GROUP BY o.order_id, o.order_customer_name, o.order_customer_contact, o.order_date, o.order_status
                                     ORDER BY o.order_date DESC";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Database Error: " + ex.Message);
                }
            }
            return dt;
        }
        public DataTable GetOrderDetails(string orderId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                                        ot.ot_items_id AS 'Item ID',
                                        ot.ot_product_id AS 'Product ID',
                                        inv.inv_product_name AS 'Product Name',
                                        ot.ot_quantity AS 'Quantity',
                                        ot.ot_unit_price AS 'Unit Price',
                                        (ot.ot_quantity * ot.ot_unit_price) AS 'Subtotal'
                                     FROM order_items ot
                                     INNER JOIN inventory inv ON ot.ot_product_id = inv.inv_product_id
                                     WHERE ot.ot_order_id = @orderId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@orderId", orderId);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Database Error: " + ex.Message);
                }
            }
            return dt;
        }

        public DataTable SearchOrders(string keyword, string year, string status)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                                        o.order_id AS 'Order ID', 
                                        o.order_customer_name AS 'Customer Name', 
                                        o.order_customer_contact AS 'Contact Number', 
                                        NULLIF(o.order_date, '0000-00-00 00:00:00') AS 'Date', 
                                        o.order_status AS 'Status',
                                        COALESCE(SUM(oi.ot_quantity * oi.ot_unit_price), 0) AS 'Total Amount'
                                     FROM orders o
                                     LEFT JOIN order_items oi ON o.order_id = oi.ot_order_id
                                     WHERE 1=1 ";


                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query += " AND (o.order_id LIKE @kw OR o.order_customer_name LIKE @kw) ";
                    }

                    if (!string.IsNullOrWhiteSpace(year))
                    {
                        query += " AND YEAR(o.order_date) = @year ";
                    }


                    if (!string.IsNullOrWhiteSpace(status))
                    {
                        query += " AND o.order_status = @status ";
                    }

                    query += " GROUP BY o.order_id, o.order_customer_name, o.order_customer_contact, o.order_date, o.order_status ORDER BY o.order_date DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);


                    if (!string.IsNullOrWhiteSpace(keyword)) cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    if (!string.IsNullOrWhiteSpace(year)) cmd.Parameters.AddWithValue("@year", year);
                    if (!string.IsNullOrWhiteSpace(status)) cmd.Parameters.AddWithValue("@status", status);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Database Error: " + ex.Message);
                }
            }
            return dt;
        }

        public void CancelOrder(string orderId)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = "UPDATE orders SET order_status = 'Cancelled' WHERE order_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", orderId);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateOrderStatus(string orderId, string newStatus)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = "UPDATE orders SET order_status = @status WHERE order_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@id", orderId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}