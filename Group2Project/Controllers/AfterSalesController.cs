using System;
using System.Data;
using MySql.Data.MySqlClient;
using Group2Project.DataAccess;

namespace Group2Project.Controllers
{
    public class AfterSalesController
    {
        public DataTable GetServiceCases()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = @"SELECT 
                                    case_id AS 'Case ID', 
                                    order_id AS 'Order Ref.', 
                                    case_type AS 'Issue Type', 
                                    case_status AS 'Current Status', 
                                    technician_id AS 'Assigned Tech',
                                    created_at AS 'Logged Date',
                                    case_description AS 'Description'
                                 FROM service_cases 
                                 ORDER BY created_at DESC";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        public bool VerifyOrder(string orderId)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(1) FROM orders WHERE order_id = @oId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@oId", orderId);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        public void LogServiceCase(string orderId, string caseType, string description, string priority = "Normal")
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO service_cases (order_id, case_type, case_description, case_status, priority, created_at) 
                                     VALUES (@oId, @type, @desc, 'Pending', @priority, NOW())";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@oId", orderId);
                    cmd.Parameters.AddWithValue("@type", caseType);
                    cmd.Parameters.AddWithValue("@desc", description);
                    cmd.Parameters.AddWithValue("@priority", priority);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception("Database Error: " + ex.Message); }
            }
        }
        
        public void AssignTechnician(string caseId, string technicianId)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE service_cases SET technician_id = @tech, case_status = 'In Progress' WHERE case_id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tech", technicianId);
                    cmd.Parameters.AddWithValue("@id", caseId);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception("Database Error: " + ex.Message); }
            }
        }

        public void ResolveCase(string caseId, string resolutionNotes = "")
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE service_cases SET case_status = 'Resolved', resolved_at = NOW() WHERE case_id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", caseId);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception("Database Error: " + ex.Message); }
            }
        }
        
        public void CloseCase(string caseId)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE service_cases SET case_status = 'Closed', closed_at = NOW() WHERE case_id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", caseId);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception("Database Error: " + ex.Message); }
            }
        }

        public DataTable SearchServiceCases(string statusFilter, string priorityFilter = "All")
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = @"SELECT 
                                    case_id AS 'Case ID', 
                                    order_id AS 'Order Ref.', 
                                    case_type AS 'Issue Type', 
                                    case_status AS 'Current Status', 
                                    technician_id AS 'Assigned Tech',
                                    priority AS 'Priority',
                                    created_at AS 'Logged Date'
                                 FROM service_cases WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(statusFilter) && statusFilter != "All")
                {
                    query += " AND case_status = @status ";
                }
                
                if (!string.IsNullOrWhiteSpace(priorityFilter) && priorityFilter != "All")
                {
                    query += " AND priority = @priority ";
                }

                query += " ORDER BY created_at DESC";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                if (!string.IsNullOrWhiteSpace(statusFilter) && statusFilter != "All")
                {
                    cmd.Parameters.AddWithValue("@status", statusFilter);
                }
                
                if (!string.IsNullOrWhiteSpace(priorityFilter) && priorityFilter != "All")
                {
                    cmd.Parameters.AddWithValue("@priority", priorityFilter);
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }
        
        public DataTable GetCaseStatistics()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = @"SELECT 
                                    'Total Cases' AS Metric, COUNT(*) AS Value FROM service_cases
                                    UNION ALL
                                    SELECT 'Pending', COUNT(*) FROM service_cases WHERE case_status = 'Pending'
                                    UNION ALL
                                    SELECT 'In Progress', COUNT(*) FROM service_cases WHERE case_status = 'In Progress'
                                    UNION ALL
                                    SELECT 'Resolved', COUNT(*) FROM service_cases WHERE case_status = 'Resolved'
                                    UNION ALL
                                    SELECT 'Closed', COUNT(*) FROM service_cases WHERE case_status = 'Closed'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }
        
        public DataTable GetCaseDetails(string caseId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                string query = @"SELECT * FROM service_cases WHERE case_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", caseId);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }
        
        public void AddCaseNote(string caseId, string note, string userId)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO case_notes (case_id, note, created_by, created_at) 
                                     VALUES (@caseId, @note, @userId, NOW())";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@caseId", caseId);
                    cmd.Parameters.AddWithValue("@note", note);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception("Database Error: " + ex.Message); }
            }
        }
    }
}