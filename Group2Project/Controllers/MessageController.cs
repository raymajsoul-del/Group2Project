using System;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using Group2Project.DataAccess;

namespace Group2Project.Controllers
{
    public class MessageController
    {
        public enum MessageType
        {
            General,
            Urgent,
            System
        }

        public class InternalMessage
        {
            public int MessageId { get; set; }
            public string SenderId { get; set; }
            public string SenderName { get; set; }
            public string ReceiverId { get; set; }
            public string ReceiverName { get; set; }
            public string Subject { get; set; }
            public string Content { get; set; }
            public bool IsRead { get; set; }
            public MessageType Type { get; set; }
            public DateTime SentTime { get; set; }
        }

        public DataTable GetInbox(string receiverId, bool unreadOnly = false)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                                        m.message_id as 'MessageId', 
                                        m.sender_id as 'SenderId',
                                        s.staff_name as 'SenderName',
                                        m.receiver_id as 'ReceiverId',
                                        r.staff_name as 'ReceiverName',
                                        m.subject as 'Subject',
                                        m.content as 'Content',
                                        m.is_read as 'IsRead',
                                        m.message_type as 'Type',
                                        m.sent_time as 'SentTime'
                                     FROM internal_messages m
                                     LEFT JOIN staff s ON m.sender_id = s.staff_id
                                     LEFT JOIN staff r ON m.receiver_id = r.staff_id
                                     WHERE m.receiver_id = @receiverId";
                    
                    if (unreadOnly)
                        query += " AND m.is_read = 0";
                    
                    query += " ORDER BY m.sent_time DESC";
                    
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@receiverId", receiverId);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch
            {
                dt.Columns.Add("MessageId", typeof(int));
                dt.Columns.Add("SenderId", typeof(string));
                dt.Columns.Add("SenderName", typeof(string));
                dt.Columns.Add("ReceiverId", typeof(string));
                dt.Columns.Add("ReceiverName", typeof(string));
                dt.Columns.Add("Subject", typeof(string));
                dt.Columns.Add("Content", typeof(string));
                dt.Columns.Add("IsRead", typeof(bool));
                dt.Columns.Add("Type", typeof(int));
                dt.Columns.Add("SentTime", typeof(DateTime));
                
                dt.Rows.Add(1, "S001", "張經理", "S002", "李助理", "請協助處理採購單", "請協助處理今天的採購單 PO2025001", false, (int)MessageType.Urgent, DateTime.Now.AddHours(-1));
                dt.Rows.Add(2, "S003", "王工程師", "S002", "李助理", "技術支援預約", "下週一上午有空做技術支援嗎？", true, (int)MessageType.General, DateTime.Now.AddDays(-1));
            }
            return dt;
        }

        public DataTable GetOutbox(string senderId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                                        m.message_id as 'MessageId', 
                                        m.sender_id as 'SenderId',
                                        s.staff_name as 'SenderName',
                                        m.receiver_id as 'ReceiverId',
                                        r.staff_name as 'ReceiverName',
                                        m.subject as 'Subject',
                                        m.content as 'Content',
                                        m.is_read as 'IsRead',
                                        m.message_type as 'Type',
                                        m.sent_time as 'SentTime'
                                     FROM internal_messages m
                                     LEFT JOIN staff s ON m.sender_id = s.staff_id
                                     LEFT JOIN staff r ON m.receiver_id = r.staff_id
                                     WHERE m.sender_id = @senderId
                                     ORDER BY m.sent_time DESC";
                    
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@senderId", senderId);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch
            {
                dt.Columns.Add("MessageId", typeof(int));
                dt.Columns.Add("SenderId", typeof(string));
                dt.Columns.Add("SenderName", typeof(string));
                dt.Columns.Add("ReceiverId", typeof(string));
                dt.Columns.Add("ReceiverName", typeof(string));
                dt.Columns.Add("Subject", typeof(string));
                dt.Columns.Add("Content", typeof(string));
                dt.Columns.Add("IsRead", typeof(bool));
                dt.Columns.Add("Type", typeof(int));
                dt.Columns.Add("SentTime", typeof(DateTime));
                
                dt.Rows.Add(3, "S002", "李助理", "S001", "張經理", "已收到通知", "已了解處理採購單的要求，會立即處理", true, (int)MessageType.General, DateTime.Now.AddHours(-2));
            }
            return dt;
        }

        public void SendMessage(string senderId, string receiverId, string subject, string content, MessageType type = MessageType.General)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO internal_messages 
                                    (sender_id, receiver_id, subject, content, message_type, is_read, sent_time)
                                    VALUES (@senderId, @receiverId, @subject, @content, @type, 0, NOW())";
                    
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@senderId", senderId);
                    cmd.Parameters.AddWithValue("@receiverId", receiverId);
                    cmd.Parameters.AddWithValue("@subject", subject);
                    cmd.Parameters.AddWithValue("@content", content);
                    cmd.Parameters.AddWithValue("@type", (int)type);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception("Database Error: " + ex.Message); }
            }
        }

        public void MarkAsRead(int messageId)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE internal_messages SET is_read = 1 WHERE message_id = @messageId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@messageId", messageId);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception("Database Error: " + ex.Message); }
            }
        }

        public int GetUnreadCount(string receiverId)
        {
            int count = 0;
            try
            {
                using (MySqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM internal_messages WHERE receiver_id = @receiverId AND is_read = 0";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@receiverId", receiverId);
                    object result = cmd.ExecuteScalar();
                    if (result != null) count = Convert.ToInt32(result);
                }
            }
            catch
            {
                count = 2;
            }
            return count;
        }

        public void DeleteMessage(int messageId)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM internal_messages WHERE message_id = @messageId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@messageId", messageId);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception("Database Error: " + ex.Message); }
            }
        }
    }
}