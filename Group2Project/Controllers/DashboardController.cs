using System;
using System.Data;
using MySql.Data.MySqlClient;
using Group2Project.DataAccess;

namespace Group2Project.Controllers
{
    public class DashboardController
    {
        public class DashboardData
        {
            public int TotalOrders { get; set; }
            public int TotalSoldItems { get; set; }
            public decimal TotalRevenue { get; set; }
            public decimal TotalGrossProfit { get; set; }
            public DataTable SevenDayTrend { get; set; }
            public DataTable TopSellingProducts { get; set; }
            public int PendingOrders { get; set; }
            public int LowStockItems { get; set; }
            public int TodayOrders { get; set; }
            public decimal TodayRevenue { get; set; }
            public DataTable RecentOrders { get; set; }
        }

        public DashboardData GetDashboardData()
        {
            DashboardData data = new DashboardData();
            
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    
                    data.TotalOrders = GetTotalOrdersThisMonth(conn);
                    data.TotalSoldItems = GetTotalSoldItemsThisMonth(conn);
                    data.TotalRevenue = GetTotalRevenueThisMonth(conn);
                    data.TotalGrossProfit = GetTotalGrossProfitThisMonth(conn);
                    data.SevenDayTrend = GetSevenDayOrderTrend(conn);
                    data.TopSellingProducts = GetTopSellingProducts(conn);
                    data.PendingOrders = GetPendingOrders(conn);
                    data.LowStockItems = GetLowStockItems(conn);
                    data.TodayOrders = GetTodayOrders(conn);
                    data.TodayRevenue = GetTodayRevenue(conn);
                    data.RecentOrders = GetRecentOrders(conn);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DashboardController] Error loading dashboard: {ex.Message}");
                }
            }
            
            return data;
        }

        private int GetTotalOrdersThisMonth(MySqlConnection conn)
        {
            string query = @"SELECT COUNT(*) FROM orders 
                           WHERE MONTH(order_date) = MONTH(CURRENT_DATE()) 
                           AND YEAR(order_date) = YEAR(CURRENT_DATE())";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : 0;
        }

        private int GetTotalSoldItemsThisMonth(MySqlConnection conn)
        {
            string query = @"SELECT COALESCE(SUM(oi.ot_quantity), 0) 
                           FROM order_items oi
                           JOIN orders o ON oi.ot_order_id = o.order_id
                           WHERE MONTH(o.order_date) = MONTH(CURRENT_DATE()) 
                           AND YEAR(o.order_date) = YEAR(CURRENT_DATE())";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : 0;
        }

        private decimal GetTotalRevenueThisMonth(MySqlConnection conn)
        {
            string query = @"SELECT COALESCE(SUM(oi.ot_quantity * oi.ot_unit_price), 0) 
                           FROM order_items oi
                           JOIN orders o ON oi.ot_order_id = o.order_id
                           WHERE MONTH(o.order_date) = MONTH(CURRENT_DATE()) 
                           AND YEAR(o.order_date) = YEAR(CURRENT_DATE())";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToDecimal(result) : 0;
        }

        private decimal GetTotalGrossProfitThisMonth(MySqlConnection conn)
        {
            // Since inventory table doesn't have inv_cost column, 
            // we'll calculate gross profit using a simplified method (assuming 40% margin)
            string query = @"SELECT COALESCE(SUM(oi.ot_quantity * oi.ot_unit_price * 0.4), 0)
                           FROM order_items oi
                           JOIN orders o ON oi.ot_order_id = o.order_id
                           WHERE MONTH(o.order_date) = MONTH(CURRENT_DATE()) 
                           AND YEAR(o.order_date) = YEAR(CURRENT_DATE())";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToDecimal(result) : 0;
        }

        private DataTable GetSevenDayOrderTrend(MySqlConnection conn)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("OrderCount", typeof(int));
            
            string query = @"SELECT 
                            DATE(order_date) AS OrderDate, 
                            COUNT(*) AS OrderCount
                           FROM orders
                           WHERE order_date >= DATE_SUB(CURRENT_DATE(), INTERVAL 7 DAY)
                           GROUP BY DATE(order_date)
                           ORDER BY OrderDate";
            
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            adapter.Fill(dt);
            
            return dt;
        }

        private DataTable GetTopSellingProducts(MySqlConnection conn)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("TotalQuantity", typeof(int));
            dt.Columns.Add("TotalRevenue", typeof(decimal));
            
            string query = @"SELECT 
                            i.inv_product_name AS ProductName,
                            SUM(oi.ot_quantity) AS TotalQuantity,
                            SUM(oi.ot_quantity * oi.ot_unit_price) AS TotalRevenue
                           FROM order_items oi
                           JOIN inventory i ON oi.ot_product_id = i.inv_product_id
                           JOIN orders o ON oi.ot_order_id = o.order_id
                           WHERE MONTH(o.order_date) = MONTH(CURRENT_DATE()) 
                           AND YEAR(o.order_date) = YEAR(CURRENT_DATE())
                           GROUP BY i.inv_product_id, i.inv_product_name
                           ORDER BY TotalQuantity DESC
                           LIMIT 5";
            
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            adapter.Fill(dt);
            
            return dt;
        }

        private int GetPendingOrders(MySqlConnection conn)
        {
            string query = @"SELECT COUNT(*) FROM orders 
                           WHERE status = 'pending' OR status = 'processing'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : 0;
        }

        private int GetLowStockItems(MySqlConnection conn)
        {
            string query = @"SELECT COUNT(*) FROM inventory 
                           WHERE inv_quantity < 10";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : 0;
        }

        private int GetTodayOrders(MySqlConnection conn)
        {
            string query = @"SELECT COUNT(*) FROM orders 
                           WHERE DATE(order_date) = CURDATE()";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : 0;
        }

        private decimal GetTodayRevenue(MySqlConnection conn)
        {
            string query = @"SELECT COALESCE(SUM(oi.ot_quantity * oi.ot_unit_price), 0) 
                           FROM order_items oi
                           JOIN orders o ON oi.ot_order_id = o.order_id
                           WHERE DATE(o.order_date) = CURDATE()";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToDecimal(result) : 0;
        }

        private DataTable GetRecentOrders(MySqlConnection conn)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("OrderId", typeof(int));
            dt.Columns.Add("OrderDate", typeof(DateTime));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("Total", typeof(decimal));
            
            string query = @"SELECT 
                            o.order_id,
                            o.order_date,
                            o.status,
                            COALESCE(SUM(oi.ot_quantity * oi.ot_unit_price), 0) as total
                           FROM orders o
                           LEFT JOIN order_items oi ON o.order_id = oi.ot_order_id
                           GROUP BY o.order_id, o.order_date, o.status
                           ORDER BY o.order_date DESC
                           LIMIT 5";
            
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            adapter.Fill(dt);
            
            return dt;
        }
    }
}
