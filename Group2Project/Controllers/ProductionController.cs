using System;
using System.Data;
using MySql.Data.MySqlClient;
using Group2Project.DataAccess;

namespace Group2Project.Controllers
{
    public class ProductionController
    {
        public DataTable GetProductionTasks()
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add("Task ID");
                dt.Columns.Add("Order Ref.");
                dt.Columns.Add("Product to Manufacture");
                dt.Columns.Add("Target Qty.");
                dt.Columns.Add("Current Status");
                dt.Columns.Add("Start Date");

                // 添加示例数据
                dt.Rows.Add("T001", "ORD-20250628", "Luxury Chair", "100", "In Production", DateTime.Now.ToString("yyyy-MM-dd"));
                dt.Rows.Add("T002", "ORD-20250627", "Dining Table", "50", "Pending", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                dt.Rows.Add("T003", "ORD-20250626", "Sofa", "30", "Quality Check", DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd"));
                dt.Rows.Add("T004", "ORD-20250625", "Coffee Table", "80", "Completed", DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd"));
            }
            catch
            {
                // 如果数据库不可用时，使用示例数据
            }
            return dt;
        }

        public DataTable GetMaterialRequests()
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add("Req. ID");
                dt.Columns.Add("Material Code");
                dt.Columns.Add("Qty.");
                dt.Columns.Add("Urgency");
                dt.Columns.Add("Status");
                dt.Rows.Add("MR001", "Wood-Type A", "50", "High", "Pending");
                dt.Rows.Add("MR002", "Fabric-Red", "100", "Normal", "Approved");
                dt.Rows.Add("MR003", "Screws", "500", "Low", "Delivered");
            }
            catch
            {
            }
            return dt;
        }

        public DataTable GetRawMaterials()
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add("inv_product_name");
                dt.Rows.Add("Wood-Type A");
                dt.Rows.Add("Wood-Type B");
                dt.Rows.Add("Fabric-Red");
                dt.Rows.Add("Fabric-Blue");
                dt.Rows.Add("Screws");
            }
            catch
            {
            }
            return dt;
        }

        public void SubmitMaterialRequest(string materialCode, int qty, string urgency)
        {
            // 模拟数据库操作，这里简化为日志
        }

        public void UpdateTaskStatus(string taskId, string newStatus)
        {
            // 模拟数据库操作
        }

        public DataTable GetDashboardStats()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Metric");
            dt.Columns.Add("Value");
            dt.Rows.Add("Total Tasks", "12");
            dt.Rows.Add("In Production", "5");
            dt.Rows.Add("Completed Today", "8");
            dt.Rows.Add("Quality Issues", "1");
            return dt;
        }

        public void CreateProductionOrder(string productName, int quantity, string priority, string notes)
        {
            // 模拟创建生产订单
        }

        public void UpdateQualityControl(string taskId, string result, string inspector)
        {
            // 模拟质量检查更新
        }
    }
}