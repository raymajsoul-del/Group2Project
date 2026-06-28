using System;
using System.Data;
using MySql.Data.MySqlClient;
using Group2Project.DataAccess;

namespace Group2Project.Controllers
{
    public class OrderController
    {
        public DataTable GetAllOrders()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                // Convert MySQL zero DATETIME to NULL to avoid provider conversion errors when filling DataTable
                string query = "SELECT order_id AS 'Order ID', order_customer_name AS 'Customer Name', order_customer_contact AS 'Contact Number', NULLIF(order_date, '0000-00-00 00:00:00') AS 'Order Date', order_status AS 'Status' FROM orders ORDER BY order_date DESC";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }
        public DataTable GetFurnitureItems()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = "SELECT inv_product_name FROM inventory";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }
        public void SubmitCustomOrder(string customerId, string material, string width, string length, string height)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO orders (order_customer_name, order_customer_contact, order_date, order_status) 
                                     VALUES (@name, @specs, NOW(), 'Pending Approval')";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", customerId);
                    string specifications = $"Material: {material} | W:{width} L:{length} H:{height}";
                    cmd.Parameters.AddWithValue("@specs", specifications);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Database Error: " + ex.Message);
                }
            }
        }
        public DataRow GetProductInfo(string productName)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = "SELECT inv_product_id, inv_price FROM inventory WHERE inv_product_name = @name";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", productName);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public void SubmitRegularOrder(DataTable cartItems)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string orderQuery = "INSERT INTO orders (order_customer_name, order_customer_contact, order_date, order_status) VALUES ('Walk-in Customer', 'Retail', NOW(), 'Completed')";
                    MySqlCommand cmdOrder = new MySqlCommand(orderQuery, conn, transaction);
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
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Transaction failed: " + ex.Message);
                }
            }
        }
        public DataTable SearchOrders(string keyword)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = @"SELECT order_id AS 'Order ID', 
                                        order_customer_name AS 'Customer Name', 
                                        order_customer_contact AS 'Contact Number', 
                                        order_date AS 'Order Date', 
                                        order_status AS 'Status' 
                                 FROM orders 
                                 WHERE order_id LIKE @kw OR order_customer_name LIKE @kw 
                                 ORDER BY order_date DESC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
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
    }
}
