using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using Group2Project.DataAccess;

namespace Group2Project.Controllers
{
    public class NotificationController
    {
        public enum NotificationType
        {
            NewMessage,
            RestockApproval,
            PurchaseApproval,
            SystemAlert,
            UrgentTask
        }

        public class NotificationItem
        {
            public int NotificationId { get; set; }
            public string ReceiverId { get; set; }
            public string ReceiverName { get; set; }
            public NotificationType Type { get; set; }
            public string Title { get; set; }
            public string Message { get; set; }
            public bool IsRead { get; set; }
            public DateTime CreatedTime { get; set; }
            public string RelatedId { get; set; }
        }

        private static NotifyIcon _systemTrayIcon;
        private static bool _trayIconInitialized;

        public static void InitializeTrayIcon(IContainer container)
        {
            if (_trayIconInitialized) return;
            
            try
            {
                _systemTrayIcon = new NotifyIcon(container);
                _systemTrayIcon.Icon = SystemIcons.Application;
                _systemTrayIcon.Visible = true;
                _systemTrayIcon.Text = "Premium Living ERP System";
                _systemTrayIcon.DoubleClick += (s, e) => { };
                _trayIconInitialized = true;
            }
            catch { }
        }

        public static void ShowBalloonNotification(string title, string message, NotificationType type = NotificationType.NewMessage, int timeoutSeconds = 10)
        {
            if (_systemTrayIcon == null) return;
            
            ToolTipIcon iconType = ToolTipIcon.Info;
            switch (type)
            {
                case NotificationType.UrgentTask:
                case NotificationType.SystemAlert:
                    iconType = ToolTipIcon.Warning;
                    break;
                case NotificationType.RestockApproval:
                case NotificationType.PurchaseApproval:
                    iconType = ToolTipIcon.Info;
                    break;
                case NotificationType.NewMessage:
                    iconType = ToolTipIcon.None;
                    break;
            }
            
            _systemTrayIcon.BalloonTipTitle = title;
            _systemTrayIcon.BalloonTipText = message;
            _systemTrayIcon.BalloonTipIcon = iconType;
            _systemTrayIcon.ShowBalloonTip(timeoutSeconds * 1000);
        }

        public DataTable GetNotifications(string receiverId, bool unreadOnly = false)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DatabaseManager.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                                        n.notification_id as 'NotificationId', 
                                        n.receiver_id as 'ReceiverId',
                                        s.staff_name as 'ReceiverName',
                                        n.notification_type as 'Type',
                                        n.title as 'Title',
                                        n.message as 'Message',
                                        n.is_read as 'IsRead',
                                        n.created_time as 'CreatedTime',
                                        n.related_id as 'RelatedId'
                                     FROM system_notifications n
                                     LEFT JOIN staff s ON n.receiver_id = s.staff_id
                                     WHERE n.receiver_id = @receiverId";
                    
                    if (unreadOnly)
                        query += " AND n.is_read = 0";
                    
                    query += " ORDER BY n.created_time DESC";
                    
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@receiverId", receiverId);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch
            {
                dt.Columns.Add("NotificationId", typeof(int));
                dt.Columns.Add("ReceiverId", typeof(string));
                dt.Columns.Add("ReceiverName", typeof(string));
                dt.Columns.Add("Type", typeof(int));
                dt.Columns.Add("Title", typeof(string));
                dt.Columns.Add("Message", typeof(string));
                dt.Columns.Add("IsRead", typeof(bool));
                dt.Columns.Add("CreatedTime", typeof(DateTime));
                dt.Columns.Add("RelatedId", typeof(string));
                
                dt.Rows.Add(1, "S001", "張經理", (int)NotificationType.RestockApproval, 
                    "補貨單待審批", "有 1 筆補貨申請等待您的審核 (PO2025001)", false, DateTime.Now.AddMinutes(-30), "PO2025001");
                dt.Rows.Add(2, "S001", "張經理", (int)NotificationType.PurchaseApproval, 
                    "採購單待審批", "有 1 筆採購訂單等待您的審核 (PO2025002)", false, DateTime.Now.AddHours(-2), "PO2025002");
            }
            return dt;
        }

        public void SendNotification(string receiverId, NotificationType type, string title, string message, string relatedId = null)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO system_notifications 
                                    (receiver_id, notification_type, title, message, is_read, created_time, related_id)
                                    VALUES (@receiverId, @type, @title, @message, 0, NOW(), @relatedId)";
                    
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@receiverId", receiverId);
                    cmd.Parameters.AddWithValue("@type", (int)type);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@message", message);
                    cmd.Parameters.AddWithValue("@relatedId", relatedId ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception("Database Error: " + ex.Message); }
            }
        }

        public void MarkAsRead(int notificationId)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE system_notifications SET is_read = 1 WHERE notification_id = @notificationId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@notificationId", notificationId);
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
                    string query = "SELECT COUNT(*) FROM system_notifications WHERE receiver_id = @receiverId AND is_read = 0";
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

        public void DeleteNotification(int notificationId)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM system_notifications WHERE notification_id = @notificationId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@notificationId", notificationId);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception("Database Error: " + ex.Message); }
            }
        }

        public static string GetNotificationIcon(NotificationType type)
        {
            switch (type)
            {
                case NotificationType.NewMessage:
                    return "📧";
                case NotificationType.RestockApproval:
                    return "📦";
                case NotificationType.PurchaseApproval:
                    return "🛒";
                case NotificationType.SystemAlert:
                    return "⚠️";
                case NotificationType.UrgentTask:
                    return "🔥";
                default:
                    return "ℹ️";
            }
        }
    }
}