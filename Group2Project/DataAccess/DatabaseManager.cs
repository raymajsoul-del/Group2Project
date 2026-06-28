using System;
using MySql.Data.MySqlClient;
namespace Group2Project.DataAccess
{
    public class DatabaseManager
    {
        // Allow and convert MySQL "zero" dates (e.g. '0000-00-00 00:00:00') so they don't throw when mapping to System.DateTime
        // Use the canonical keys "Allow Zero DateTime" and "Convert Zero DateTime" expected by MySQL Connector/NET
        private static string connectionString = "Server=localhost;Database=g2db;Uid=root;Pwd=;Allow Zero DateTime=True;Convert Zero DateTime=True;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}