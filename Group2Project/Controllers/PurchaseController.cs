using System;
using System.Data;
using System.Drawing.Printing;
using MySql.Data.MySqlClient;
using Group2Project.DataAccess;

namespace Group2Project.Controllers
{
    public class PurchaseController
    {
        public enum POStatus
        {
            PendingAccountingApproval,
            PendingApproval,
            Approved,
            SentToSupplier,
            Received,
            Cancelled
        }

        public static string GetStatusText(POStatus status)
        {
            switch (status)
            {
                case POStatus.PendingAccountingApproval:
                    return "Pending Accounting Approval";
                case POStatus.PendingApproval:
                    return "Pending Approval";
                case POStatus.Approved:
                    return "Approved";
                case POStatus.SentToSupplier:
                    return "Sent to Supplier";
                case POStatus.Received:
                    return "Received";
                case POStatus.Cancelled:
                    return "Cancelled";
                default:
                    return "Unknown";
            }
        }

        public static string GetStatusTextTraditionalChinese(POStatus status)
        {
            switch (status)
            {
                case POStatus.PendingAccountingApproval:
                    return "送交會計部審批";
                case POStatus.PendingApproval:
                    return "待核准";
                case POStatus.Approved:
                    return "核准通過";
                case POStatus.SentToSupplier:
                    return "已發送給供應商";
                case POStatus.Received:
                    return "已收貨";
                case POStatus.Cancelled:
                    return "已取消";
                default:
                    return "未知";
            }
        }

        public DataTable GetPurchaseOrders()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT po_id AS 'PO ID', supplier_id AS 'Supplier ID', supplier_name AS 'Supplier Name',
                                            total_amount AS 'Total Amount', status AS 'Status', 
                                            created_date AS 'Created Date', created_by AS 'Created By',
                                            notes AS 'Notes'
                                     FROM purchase_orders ORDER BY created_date DESC";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
            }
            catch
            {
                // 範例資料
                dt.Columns.Add("PO ID", typeof(string));
                dt.Columns.Add("Supplier ID", typeof(string));
                dt.Columns.Add("Supplier Name", typeof(string));
                dt.Columns.Add("Total Amount", typeof(decimal));
                dt.Columns.Add("Status", typeof(string));
                dt.Columns.Add("Created Date", typeof(DateTime));
                dt.Columns.Add("Created By", typeof(string));
                dt.Columns.Add("Notes", typeof(string));

                dt.Rows.Add("PO2025001", "SUP001", "Premium Furniture Co.", 15000.00, 
                    GetStatusText(POStatus.PendingAccountingApproval), DateTime.Now.AddDays(-2), "Admin", "Initial order");
                dt.Rows.Add("PO2025002", "SUP002", "Quality Supplies Ltd.", 8500.50, 
                    GetStatusText(POStatus.Approved), DateTime.Now.AddDays(-1), "Manager", "Urgent order");
            }
            return dt;
        }

        public DataTable GetPurchaseOrderItems(string poId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT po_item_id AS 'Item ID', product_id AS 'Product ID', 
                                            product_name AS 'Product Name', quantity AS 'Quantity', 
                                            unit_price AS 'Unit Price', line_total AS 'Line Total'
                                     FROM purchase_order_items WHERE po_id = @poId ORDER BY po_item_id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@poId", poId);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch
            {
                dt.Columns.Add("Item ID", typeof(int));
                dt.Columns.Add("Product ID", typeof(string));
                dt.Columns.Add("Product Name", typeof(string));
                dt.Columns.Add("Quantity", typeof(int));
                dt.Columns.Add("Unit Price", typeof(decimal));
                dt.Columns.Add("Line Total", typeof(decimal));

                if (poId == "PO2025001")
                {
                    dt.Rows.Add(1, "P001", "Luxury Sofa", 2, 5000.00, 10000.00);
                    dt.Rows.Add(2, "P002", "Dining Table", 1, 5000.00, 5000.00);
                }
            }
            return dt;
        }

        public void CreatePurchaseOrder(string poId, string supplierId, string supplierName, 
            DataTable items, string createdBy, string notes)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        decimal total = 0;
                        foreach (DataRow row in items.Rows)
                        {
                            total += Convert.ToDecimal(row["Line Total"]);
                        }

                        string poQuery = @"INSERT INTO purchase_orders 
                                          (po_id, supplier_id, supplier_name, total_amount, status, 
                                           created_date, created_by, notes)
                                          VALUES (@poId, @supplierId, @supplierName, @total, @status, 
                                                  NOW(), @createdBy, @notes)";
                        MySqlCommand poCmd = new MySqlCommand(poQuery, conn, trans);
                        poCmd.Parameters.AddWithValue("@poId", poId);
                        poCmd.Parameters.AddWithValue("@supplierId", supplierId);
                        poCmd.Parameters.AddWithValue("@supplierName", supplierName);
                        poCmd.Parameters.AddWithValue("@total", total);
                        poCmd.Parameters.AddWithValue("@status", GetStatusText(POStatus.PendingAccountingApproval));
                        poCmd.Parameters.AddWithValue("@createdBy", createdBy);
                        poCmd.Parameters.AddWithValue("@notes", notes);
                        poCmd.ExecuteNonQuery();

                        int itemId = 1;
                        foreach (DataRow row in items.Rows)
                        {
                            string itemQuery = @"INSERT INTO purchase_order_items 
                                                (po_id, po_item_id, product_id, product_name, quantity, 
                                                 unit_price, line_total)
                                                VALUES (@poId, @itemId, @productId, @productName, 
                                                        @quantity, @unitPrice, @lineTotal)";
                            MySqlCommand itemCmd = new MySqlCommand(itemQuery, conn, trans);
                            itemCmd.Parameters.AddWithValue("@poId", poId);
                            itemCmd.Parameters.AddWithValue("@itemId", itemId++);
                            itemCmd.Parameters.AddWithValue("@productId", row["Product ID"].ToString());
                            itemCmd.Parameters.AddWithValue("@productName", row["Product Name"].ToString());
                            itemCmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(row["Quantity"]));
                            itemCmd.Parameters.AddWithValue("@unitPrice", Convert.ToDecimal(row["Unit Price"]));
                            itemCmd.Parameters.AddWithValue("@lineTotal", Convert.ToDecimal(row["Line Total"]));
                            itemCmd.ExecuteNonQuery();
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public void UpdatePurchaseOrderStatus(string poId, POStatus newStatus)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE purchase_orders SET status = @status WHERE po_id = @poId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@status", GetStatusText(newStatus));
                    cmd.Parameters.AddWithValue("@poId", poId);
                    cmd.ExecuteNonQuery();
                }
                catch { }
            }
        }

        public void ApprovePurchaseOrder(string poId, string role)
        {
            DataTable dt = GetPurchaseOrders();
            DataRow[] rows = dt.Select($"[PO ID] = '{poId}'");
            if (rows.Length == 0) return;

            string currentStatus = rows[0]["Status"].ToString();
            POStatus newStatus = POStatus.PendingAccountingApproval;

            if (currentStatus == GetStatusText(POStatus.PendingAccountingApproval))
            {
                newStatus = POStatus.PendingApproval;
            }
            else if (currentStatus == GetStatusText(POStatus.PendingApproval))
            {
                newStatus = POStatus.Approved;
            }
            else if (currentStatus == GetStatusText(POStatus.Approved))
            {
                newStatus = POStatus.SentToSupplier;
            }

            UpdatePurchaseOrderStatus(poId, newStatus);
        }

        public void CancelPurchaseOrder(string poId)
        {
            UpdatePurchaseOrderStatus(poId, POStatus.Cancelled);
        }

        public PrintDocument GeneratePurchaseOrderPDF(string poId)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, e) =>
            {
                Graphics g = e.Graphics;
                Font titleFont = new Font("Arial", 18, FontStyle.Bold);
                Font headerFont = new Font("Arial", 12, FontStyle.Bold);
                Font contentFont = new Font("Arial", 10);
                Brush brush = Brushes.Black;
                int yPos = 50;
                int leftMargin = 50;

                g.DrawString("Premium Living Furniture - Purchase Order", titleFont, brush, leftMargin, yPos);
                yPos += 40;

                DataTable orders = GetPurchaseOrders();
                DataRow[] orderRows = orders.Select($"[PO ID] = '{poId}'");
                if (orderRows.Length > 0)
                {
                    g.DrawString($"PO ID: {orderRows[0]["PO ID"]}", headerFont, brush, leftMargin, yPos);
                    yPos += 25;
                    g.DrawString($"Supplier: {orderRows[0]["Supplier Name"]}", contentFont, brush, leftMargin, yPos);
                    yPos += 20;
                    g.DrawString($"Status: {orderRows[0]["Status"]}", contentFont, brush, leftMargin, yPos);
                    yPos += 20;
                    g.DrawString($"Date: {Convert.ToDateTime(orderRows[0]["Created Date"]):yyyy-MM-dd HH:mm}", contentFont, brush, leftMargin, yPos);
                    yPos += 30;

                    g.DrawLine(Pens.Black, leftMargin, yPos, e.PageBounds.Width - leftMargin, yPos);
                    yPos += 20;

                    g.DrawString("Product ID", headerFont, brush, leftMargin, yPos);
                    g.DrawString("Product Name", headerFont, brush, 180, yPos);
                    g.DrawString("Qty", headerFont, brush, 400, yPos);
                    g.DrawString("Unit Price", headerFont, brush, 480, yPos);
                    g.DrawString("Total", headerFont, brush, 600, yPos);
                    yPos += 25;
                    g.DrawLine(Pens.Gray, leftMargin, yPos, e.PageBounds.Width - leftMargin, yPos);
                    yPos += 20;

                    DataTable items = GetPurchaseOrderItems(poId);
                    decimal grandTotal = 0;
                    foreach (DataRow row in items.Rows)
                    {
                        if (yPos > e.PageBounds.Height - 100)
                        {
                            e.HasMorePages = true;
                            return;
                        }

                        g.DrawString(row["Product ID"].ToString(), contentFont, brush, leftMargin, yPos);
                        g.DrawString(row["Product Name"].ToString(), contentFont, brush, 180, yPos);
                        g.DrawString(row["Quantity"].ToString(), contentFont, brush, 400, yPos);
                        g.DrawString(Convert.ToDecimal(row["Unit Price"]).ToString("C2"), contentFont, brush, 480, yPos);
                        g.DrawString(Convert.ToDecimal(row["Line Total"]).ToString("C2"), contentFont, brush, 600, yPos);
                        grandTotal += Convert.ToDecimal(row["Line Total"]);
                        yPos += 20;
                    }

                    yPos += 20;
                    g.DrawLine(Pens.Black, leftMargin, yPos, e.PageBounds.Width - leftMargin, yPos);
                    yPos += 20;

                    g.DrawString($"Grand Total: {grandTotal:C2}", headerFont, brush, 500, yPos);
                }
                else
                {
                    g.DrawString("Purchase Order not found.", headerFont, brush, leftMargin, yPos);
                }
            };
            return pd;
        }
    }
}
