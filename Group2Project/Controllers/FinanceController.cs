using System;
using System.Data;
using MySql.Data.MySqlClient;
using Group2Project.DataAccess;

namespace Group2Project.Controllers
{
    public class FinanceController
    {
        public DataTable GetCustomerInvoices()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                // Convert zero DATETIME to NULL to avoid provider conversion errors
                string query = @"SELECT 
                                    order_id AS 'Invoice ID', 
                                    order_customer_name AS 'Customer Name', 
                                    NULLIF(order_date, '0000-00-00 00:00:00') AS 'Billing Date', 
                                    order_status AS 'Payment Status' 
                                 FROM orders 
                                 ORDER BY order_date DESC";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable GetProcurementRequests()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = @"SELECT 
                                    proc_id AS 'Request ID', 
                                    proc_supplier AS 'Supplier', 
                                    proc_item AS 'Material Item', 
                                    proc_qty AS 'Quantity', 
                                    proc_cost AS 'Total Cost ($)', 
                                    proc_status AS 'Approval Status'
                                 FROM procurement
                                 ORDER BY proc_id DESC";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }
        public void UpdatePaymentStatus(string invoiceId, string newStatus)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE orders SET order_status = @status WHERE order_id = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@status", newStatus);
                    cmd.Parameters.AddWithValue("@id", invoiceId);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Database Error: " + ex.Message);
                }
            }
        }
        public void UpdateProcurementStatus(string procId, string newStatus)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE procurement SET proc_status = @status WHERE proc_id = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@status", newStatus);
                    cmd.Parameters.AddWithValue("@id", procId);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Database Error: " + ex.Message);
                }
            }
        }

        public DataTable GetFinancialStatements()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Statement ID", typeof(string));
            dt.Columns.Add("Statement Type", typeof(string));
            dt.Columns.Add("Period", typeof(string));
            dt.Columns.Add("Total Revenue", typeof(decimal));
            dt.Columns.Add("Total Expenses", typeof(decimal));
            dt.Columns.Add("Net Profit", typeof(decimal));
            dt.Columns.Add("Status", typeof(string));

            dt.Rows.Add("FS-2024-06", "Balance Sheet", "June 2024", 150000.00m, 95000.00m, 55000.00m, "Finalized");
            dt.Rows.Add("FS-2024-05", "Income Statement", "May 2024", 180000.00m, 105000.00m, 75000.00m, "Finalized");
            dt.Rows.Add("FS-2024-04", "Cash Flow", "April 2024", 165000.00m, 98000.00m, 67000.00m, "Finalized");

            return dt;
        }

        public DataTable GetIncomeExpenseData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Transaction ID", typeof(string));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Amount", typeof(decimal));

            dt.Rows.Add("TRX-001", DateTime.Now.AddDays(-10), "Income", "Sales", "Product Sales", 5000.00m);
            dt.Rows.Add("TRX-002", DateTime.Now.AddDays(-9), "Expense", "Supplies", "Office Supplies", -500.00m);
            dt.Rows.Add("TRX-003", DateTime.Now.AddDays(-8), "Income", "Services", "Consulting Services", 3000.00m);
            dt.Rows.Add("TRX-004", DateTime.Now.AddDays(-7), "Expense", "Salaries", "Employee Salaries", -4000.00m);
            dt.Rows.Add("TRX-005", DateTime.Now.AddDays(-6), "Income", "Sales", "Product Sales", 7500.00m);

            return dt;
        }

        public DataTable GetGeneralLedger()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Entry ID", typeof(string));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Account", typeof(string));
            dt.Columns.Add("Debit", typeof(decimal));
            dt.Columns.Add("Credit", typeof(decimal));
            dt.Columns.Add("Description", typeof(string));

            dt.Rows.Add("GL-001", DateTime.Now.AddDays(-10), "Cash", 5000.00m, 0.00m, "Product Sales Revenue");
            dt.Rows.Add("GL-002", DateTime.Now.AddDays(-10), "Sales Revenue", 0.00m, 5000.00m, "Product Sales Revenue");
            dt.Rows.Add("GL-003", DateTime.Now.AddDays(-9), "Office Supplies Expense", 500.00m, 0.00m, "Purchase Office Supplies");
            dt.Rows.Add("GL-004", DateTime.Now.AddDays(-9), "Cash", 0.00m, 500.00m, "Purchase Office Supplies");
            dt.Rows.Add("GL-005", DateTime.Now.AddDays(-8), "Cash", 3000.00m, 0.00m, "Consulting Services Revenue");

            return dt;
        }
    }
}