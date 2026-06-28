using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Group2Project.Services
{
    public class DiscordNotificationService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private const string _defaultWebhookUrl = "YOUR_DISCORD_WEBHOOK_URL"; // 用户可配置为占位符

        public static async Task<bool> SendPasswordResetNotification(string username, string email, string token)
        {
            try
            {
                var notification = new DiscordMessage
                {
                    username = "CCMS Password Reset Bot",
                    embeds = new List<DiscordEmbed>
                    {
                        new DiscordEmbed
                        {
                            title = Utils.LanguageManager.GetString("Discord_Notification_Title"),
                            color = 16753920, // 橙色
                            fields = new List<DiscordField>
                            {
                                new DiscordField { name = Utils.LanguageManager.GetString("Discord_Notification_Username"), value = username, inline = true },
                                new DiscordField { name = Utils.LanguageManager.GetString("Discord_Notification_Email"), value = email, inline = true },
                                new DiscordField { name = Utils.LanguageManager.GetString("Discord_Notification_Time"), value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), inline = false },
                                new DiscordField { name = Utils.LanguageManager.GetString("Discord_Notification_Token"), value = $"`{token}`", inline = false }
                            },
                            footer = new DiscordFooter { text = Utils.LanguageManager.GetString("Discord_Notification_Footer") },
                            timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ")
                        }
                    }
                };

                var json = JsonSerializer.Serialize(notification);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // 注意：这里使用默认的webhook URL，实际使用时应该从配置文件读取
                var response = await _httpClient.PostAsync(_defaultWebhookUrl, content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DiscordNotificationService] Error sending notification: {ex.Message}");
                return false;
            }
        }

        public class DiscordMessage
        {
            public string username { get; set; }
            public List<DiscordEmbed> embeds { get; set; }
        }

        public class DiscordEmbed
        {
            public string title { get; set; }
            public int color { get; set; }
            public List<DiscordField> fields { get; set; }
            public DiscordFooter footer { get; set; }
            public string timestamp { get; set; }
        }

        public class DiscordField
        {
            public string name { get; set; }
            public string value { get; set; }
            public bool inline { get; set; }
        }

        public class DiscordFooter
        {
            public string text { get; set; }
        }
    }
}
