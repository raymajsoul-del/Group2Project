using System;
using System.Data;
using MySql.Data.MySqlClient;
using Group2Project.DataAccess;

namespace Group2Project.Controllers
{
    public class ReportingController
    {
        public DataTable GetSalesTrendData()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = "SELECT order_status, COUNT(*) as count FROM orders GROUP BY order_status";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable GetTopProductsData()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = "SELECT inv_category, COUNT(*) as count FROM inventory GROUP BY inv_category";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }


        public DataTable GetOperationalReport(string reportType)
        {
            string query = "";


            switch (reportType)
            {
                case "Monthly Sales Revenue":
                    query = "SELECT order_status AS 'Order Status', COUNT(*) AS 'Total Orders' FROM orders GROUP BY order_status";
                    break;
                case "Inventory Shortage Alert":
                    query = "SELECT inv_product_name AS 'Product Name', inv_category AS 'Category', inv_stock_quantity AS 'Current Stock' FROM inventory ORDER BY inv_stock_quantity ASC";
                    break;
                case "Logistics Performance":
                    query = "SELECT delivery_status AS 'Delivery Status', COUNT(*) AS 'Total Deliveries' FROM deliveries GROUP BY delivery_status";
                    break;
                case "After-Sales Resolution Rate":
                    query = "SELECT case_status AS 'Service Status', COUNT(*) AS 'Total Cases' FROM service_cases GROUP BY case_status";
                    break;
                default:
                    throw new ArgumentException("Invalid report type selected.");
            }

            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
