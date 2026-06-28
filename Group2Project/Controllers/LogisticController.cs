﻿﻿﻿using System;
using System.Data;
using MySql.Data.MySqlClient;
using Group2Project.DataAccess;

namespace Group2Project.Controllers
{
    public class LogisticController
    {
        public enum DateFilterType
        {
            Today,
            Tomorrow,
            Custom
        }

        public DataTable GetPendingDeliveries()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                                        d.delivery_id AS 'Delivery ID', 
                                        d.order_id AS 'Order Ref.', 
                                        o.order_customer_name AS 'Customer',
                                        o.order_customer_phone AS 'Phone',
                                        o.order_customer_address AS 'Address',
                                        d.product_volume AS 'Volume',
                                        d.installation_required AS 'Installation',
                                        d.delivery_status AS 'Status',
                                        NULLIF(d.scheduled_date, '0000-00-00 00:00:00') AS 'Scheduled Date',
                                        NULLIF(d.created_at, '0000-00-00 00:00:00') AS 'Created On'
                                     FROM deliveries d
                                     INNER JOIN orders o ON d.order_id = o.order_id
                                     WHERE d.delivery_status = 'Pending Dispatch'
                                     ORDER BY d.scheduled_date ASC, d.created_at ASC";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
            }
            catch
            {
                dt.Columns.Add("Delivery ID", typeof(string));
                dt.Columns.Add("Order Ref.", typeof(string));
                dt.Columns.Add("Customer", typeof(string));
                dt.Columns.Add("Phone", typeof(string));
                dt.Columns.Add("Address", typeof(string));
                dt.Columns.Add("Volume", typeof(string));
                dt.Columns.Add("Installation", typeof(string));
                dt.Columns.Add("Status", typeof(string));
                dt.Columns.Add("Scheduled Date", typeof(DateTime));
                dt.Columns.Add("Created On", typeof(DateTime));
                
                dt.Rows.Add("DEL001", "ORD001", "張先生", "0912-345-678", "台北市信義區信義路五段7號", "大型沙發", "是", "Pending Dispatch", DateTime.Today.AddHours(10), DateTime.Today);
                dt.Rows.Add("DEL002", "ORD002", "李小姐", "0923-456-789", "新北市板橋區中山路一段100號", "餐桌椅組", "否", "Pending Dispatch", DateTime.Today.AddHours(14), DateTime.Today);
            }
            return dt;
        }

        public DataTable GetScheduledDeliveries(DateFilterType filterType, DateTime? customDate = null)
        {
            DataTable dt = new DataTable();
            DateTime targetDate = DateTime.Today;
            switch (filterType)
            {
                case DateFilterType.Tomorrow:
                    targetDate = DateTime.Today.AddDays(1);
                    break;
                case DateFilterType.Custom:
                    if (customDate.HasValue)
                        targetDate = customDate.Value.Date;
                    break;
            }
            
            try
            {
                using (MySqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                                        d.delivery_id AS 'Delivery ID', 
                                        d.order_id AS 'Order Ref.', 
                                        o.order_customer_name AS 'Customer',
                                        o.order_customer_phone AS 'Phone',
                                        o.order_customer_address AS 'Address',
                                        d.product_volume AS 'Volume',
                                        d.installation_required AS 'Installation',
                                        d.assigned_team AS 'Assigned Team',
                                        d.delivery_status AS 'Status',
                                        NULLIF(d.scheduled_date, '0000-00-00 00:00:00') AS 'Scheduled Date'
                                     FROM deliveries d
                                     INNER JOIN orders o ON d.order_id = o.order_id
                                     WHERE DATE(d.scheduled_date) = @targetDate
                                     ORDER BY d.scheduled_date ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@targetDate", targetDate);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch
            {
                dt.Columns.Add("Delivery ID", typeof(string));
                dt.Columns.Add("Order Ref.", typeof(string));
                dt.Columns.Add("Customer", typeof(string));
                dt.Columns.Add("Phone", typeof(string));
                dt.Columns.Add("Address", typeof(string));
                dt.Columns.Add("Volume", typeof(string));
                dt.Columns.Add("Installation", typeof(string));
                dt.Columns.Add("Assigned Team", typeof(string));
                dt.Columns.Add("Status", typeof(string));
                dt.Columns.Add("Scheduled Date", typeof(DateTime));
                
                dt.Rows.Add("DEL003", "ORD003", "王小明", "0934-567-890", "桃園市中壢區中北路一段200號", "辦公椅組", "否", "配送隊A", "Scheduled", targetDate.AddHours(9));
                dt.Rows.Add("DEL004", "ORD004", "陳美麗", "0945-678-901", "新竹市北區北大路二段300號", "系統櫃", "是", "技術隊1", "Scheduled", targetDate.AddHours(13));
            }
            return dt;
        }

        public DataTable GetTeams()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Team ID", typeof(string));
            dt.Columns.Add("Team Name", typeof(string));
            dt.Columns.Add("Team Type", typeof(string));
            dt.Columns.Add("Members", typeof(int));
            
            dt.Rows.Add("DEL-A", "配送隊A", "Delivery", 4);
            dt.Rows.Add("DEL-B", "配送隊B", "Delivery", 3);
            dt.Rows.Add("TECH-1", "技術隊1", "Technical", 3);
            dt.Rows.Add("TECH-2", "技術隊2", "Technical", 2);
            
            return dt;
        }

        public DataTable GetTeamWorkload(string teamId)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Time Slot", typeof(string));
            dt.Columns.Add("Delivery ID", typeof(string));
            dt.Columns.Add("Customer", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            
            if (teamId.StartsWith("DEL"))
            {
                dt.Rows.Add("09:00-10:30", "DEL001", "張先生", "Scheduled");
                dt.Rows.Add("11:00-12:30", "DEL005", "王先生", "Scheduled");
                dt.Rows.Add("14:00-15:30", "DEL006", "林小姐", "Scheduled");
            }
            else
            {
                dt.Rows.Add("09:00-10:30", "DEL004", "陳美麗", "Scheduled");
                dt.Rows.Add("13:00-14:30", "DEL007", "周先生", "Scheduled");
            }
            
            return dt;
        }

        public void AssignToTeam(string deliveryId, string teamId)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE deliveries 
                                     SET assigned_team = @team, 
                                         delivery_status = 'Assigned' 
                                     WHERE delivery_id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@team", teamId);
                    cmd.Parameters.AddWithValue("@id", deliveryId);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception("Database Error: " + ex.Message); }
            }
        }

        public void BulkAssignToTeam(string[] deliveryIds, string teamId)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (string deliveryId in deliveryIds)
                        {
                            string query = @"UPDATE deliveries 
                                             SET assigned_team = @team, 
                                                 delivery_status = 'Assigned' 
                                             WHERE delivery_id = @id";
                            MySqlCommand cmd = new MySqlCommand(query, conn, trans);
                            cmd.Parameters.AddWithValue("@team", teamId);
                            cmd.Parameters.AddWithValue("@id", deliveryId);
                            cmd.ExecuteNonQuery();
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

        public DataTable GetShipmentTracking()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                                        d.delivery_id AS 'Delivery ID', 
                                        d.order_id AS 'Order Ref.', 
                                        d.driver_id AS 'Driver', 
                                        d.vehicle_type AS 'Vehicle',
                                        d.assigned_team AS 'Team',
                                        NULLIF(d.delivery_date, '0000-00-00 00:00:00') AS 'Scheduled Date',
                                        d.delivery_status AS 'Current Status'
                                     FROM deliveries d
                                     ORDER BY d.delivery_id DESC";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
            }
            catch
            {
                dt.Columns.Add("Delivery ID", typeof(string));
                dt.Columns.Add("Order Ref.", typeof(string));
                dt.Columns.Add("Driver", typeof(string));
                dt.Columns.Add("Vehicle", typeof(string));
                dt.Columns.Add("Team", typeof(string));
                dt.Columns.Add("Scheduled Date", typeof(DateTime));
                dt.Columns.Add("Current Status", typeof(string));
                dt.Rows.Add("DEL001", "ORD001", "Driver 1", "Truck 1", "配送隊A", DateTime.Now, "Dispatched");
            }
            return dt;
        }

        public DataTable SearchShipments(string keyword)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                                        d.delivery_id AS 'Delivery ID', 
                                        d.order_id AS 'Order Ref.', 
                                        d.driver_id AS 'Driver', 
                                        d.vehicle_type AS 'Vehicle',
                                        d.delivery_date AS 'Scheduled Date',
                                        d.delivery_status AS 'Current Status'
                                     FROM deliveries d
                                     WHERE d.delivery_id LIKE @kw OR d.order_id LIKE @kw
                                     ORDER BY d.delivery_id DESC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch
            {
                dt = GetShipmentTracking();
            }
            return dt;
        }

        public void AssignDriverAndVehicle(string deliveryId, string driver, string vehicle, DateTime date)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE deliveries 
                                     SET driver_id = @driver, 
                                         vehicle_type = @vehicle, 
                                         delivery_date = @date, 
                                         delivery_status = 'Dispatched' 
                                     WHERE delivery_id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@driver", driver);
                    cmd.Parameters.AddWithValue("@vehicle", vehicle);
                    var dateParam = new MySqlParameter("@date", MySqlDbType.DateTime);
                    if (date == DateTime.MinValue || date.Year < 1000)
                        dateParam.Value = DBNull.Value;
                    else
                        dateParam.Value = date;
                    cmd.Parameters.Add(dateParam);
                    cmd.Parameters.AddWithValue("@id", deliveryId);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception("Database Error: " + ex.Message); }
            }
        }

        public void UpdateShipmentStatus(string deliveryId, string status)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE deliveries SET delivery_status = @status WHERE delivery_id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@id", deliveryId);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception("Database Error: " + ex.Message); }
            }
        }
    }
}