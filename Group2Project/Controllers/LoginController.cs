using System;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using Group2Project.DataAccess;
using Group2Project.Models;
using Group2Project.Services;

namespace Group2Project.Controllers
{
    public class LoginController
    {

        public Staff Authenticate(string staffId, string password)
        {
            Console.WriteLine($"Authenticate called for Staff ID: '{staffId}', password length: {password?.Length ?? 0}");
            
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    Console.WriteLine("Attempting to open database connection...");
                    conn.Open();
                    Console.WriteLine("Database connection opened successfully!");
                    
                    string query = "SELECT staff_id, staff_name, role, status, password FROM staff WHERE staff_id = @staffId";
                    Console.WriteLine($"Executing query: {query}");

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@staffId", staffId);
                    Console.WriteLine($"Parameter @staffId = '{staffId}'");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine("Found a matching user in database!");
                            
                            string dbPassword = reader["password"]?.ToString() ?? "";
                            Console.WriteLine($"Database password: '{dbPassword}' (length: {dbPassword.Length})");
                            Console.WriteLine($"Input password: '{password}' (length: {password?.Length ?? 0})");
                            
                            if (dbPassword != password)
                            {
                                Console.WriteLine("Password does not match!");
                                return null;
                            }
                            
                            string status = reader["status"]?.ToString() ?? "";
                            Console.WriteLine($"User status: '{status}'");
                            
                            if (status != "Active")
                            {
                                throw new Exception("This account has been disabled. Please contact the administrator.");
                            }
                            
                            Staff staff = new Staff
                            {
                                StaffId = reader["staff_id"]?.ToString() ?? "",
                                StaffName = reader["staff_name"]?.ToString() ?? "",
                                Role = reader["role"]?.ToString() ?? "",
                                Status = status
                            };
                            
                            Console.WriteLine($"Staff created: {staff.StaffId}, {staff.StaffName}, {staff.Role}");
                            return staff;
                        }
                        else
                        {
                            Console.WriteLine("No matching user found in database!");
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception in Authenticate: {ex.Message}\nStack trace: {ex.StackTrace}");
                    throw new Exception("Database connection failed: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Request a password reset: verify username+email match, generate token, store in DB, and send email.
        /// Returns: Tuple with status code and detailed message
        /// </summary>
        public (string status, string message) RequestPasswordReset(string staffId, string email)
        {
            Console.WriteLine($"[LoginController] RequestPasswordReset called for staffId: '{staffId}', email: '{email}'");
            
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    Console.WriteLine("[LoginController] RequestPasswordReset: Opening database connection...");
                    conn.Open();
                    Console.WriteLine("[LoginController] RequestPasswordReset: Database connection opened!");

                    // 1. Check if user exists and email matches
                    string checkQuery = "SELECT staff_id, staff_name, email FROM staff WHERE staff_id = @staffId";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@staffId", staffId);

                    string staffName = "";
                    using (MySqlDataReader reader = checkCmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            Console.WriteLine("[LoginController] RequestPasswordReset: User not found!");
                            return ("user_not_found", "User not found.");
                        }

                        string dbEmail = reader["email"] != null ? reader["email"].ToString() : "";
                        staffName = reader["staff_name"].ToString();
                        Console.WriteLine($"[LoginController] RequestPasswordReset: Found user: {staffName}, DB email: {dbEmail}");

                        if (string.IsNullOrEmpty(dbEmail) || !dbEmail.Equals(email, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("[LoginController] RequestPasswordReset: Email mismatch!");
                            return ("email_mismatch", "Email does not match our records.");
                        }
                    }

                    // 2. Invalidate any existing tokens for this user
                    string invalidateQuery = "UPDATE password_reset_tokens SET is_used = 1 WHERE staff_id = @staffId AND is_used = 0";
                    MySqlCommand invalidateCmd = new MySqlCommand(invalidateQuery, conn);
                    invalidateCmd.Parameters.AddWithValue("@staffId", staffId);
                    invalidateCmd.ExecuteNonQuery();
                    Console.WriteLine("[LoginController] RequestPasswordReset: Invalidated existing tokens!");

                    // 3. Generate new token
                    string token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32)).Replace("+", "-").Replace("/", "_").Replace("=", "");
                    Console.WriteLine($"[LoginController] RequestPasswordReset: Generated token: {token}");

                    // 4. Insert token into database (expires in 10 minutes)
                    string insertQuery = "INSERT INTO password_reset_tokens (token, staff_id, expires_at, is_used, created_at) VALUES (@token, @staffId, DATE_ADD(NOW(), INTERVAL 10 MINUTE), 0, NOW())";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@token", token);
                    insertCmd.Parameters.AddWithValue("@staffId", staffId);
                    insertCmd.ExecuteNonQuery();
                    Console.WriteLine("[LoginController] RequestPasswordReset: Token stored in database!");

                    // 5. Send email
                    Console.WriteLine("[LoginController] RequestPasswordReset: Sending reset email...");
                    var emailResult = EmailService.SendPasswordResetEmail(email, staffName, token, "en");
                    
                    // 6. Send Discord notification to IT team
                    try
                    {
                        var discordTask = DiscordNotificationService.SendPasswordResetNotification(staffId, email, token);
                        discordTask.Wait();
                    }
                    catch
                    {
                        // 即使Discord通知失败，也不影响主流程
                        Console.WriteLine("[LoginController] RequestPasswordReset: Discord notification failed (but that's okay)");
                    }
                    
                    Console.WriteLine($"[LoginController] RequestPasswordReset: Done!");
                    return (emailResult.success ? "success" : "email_failed", emailResult.message);
                }
                catch (Exception ex)
                {
                    string errorMsg = $"Error: {ex.Message}\n\nStack trace: {ex.StackTrace}";
                    Console.WriteLine($"[LoginController] RequestPasswordReset error: {errorMsg}");
                    return ("error", errorMsg);
                }
            }
        }

        /// <summary>
        /// Reset password using token: verify token validity, update password, mark token as used.
        /// Returns: "success" if password updated, or error message.
        /// </summary>
        public string ResetPasswordWithToken(string token, string newPassword)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();

                    // 1. Verify token exists, is not used, and has not expired
                    string checkQuery = "SELECT staff_id, expires_at, is_used FROM password_reset_tokens WHERE token = @token";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@token", token);

                    using (MySqlDataReader reader = checkCmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return "token_invalid";
                        }

                        bool isUsed = reader["is_used"] != null && Convert.ToInt32(reader["is_used"]) == 1;
                        if (isUsed)
                        {
                            return "token_used";
                        }

                        DateTime expiresAt = Convert.ToDateTime(reader["expires_at"]);
                        if (DateTime.Now > expiresAt)
                        {
                            return "token_expired";
                        }
                    }

                    // 2. Update password in staff table
                    string updatePwdQuery = "UPDATE staff SET password = @pwd WHERE staff_id = (SELECT staff_id FROM password_reset_tokens WHERE token = @token AND is_used = 0)";
                    MySqlCommand updatePwdCmd = new MySqlCommand(updatePwdQuery, conn);
                    updatePwdCmd.Parameters.AddWithValue("@pwd", newPassword);
                    updatePwdCmd.Parameters.AddWithValue("@token", token);
                    updatePwdCmd.ExecuteNonQuery();

                    // 3. Mark token as used
                    string markUsedQuery = "UPDATE password_reset_tokens SET is_used = 1 WHERE token = @token";
                    MySqlCommand markCmd = new MySqlCommand(markUsedQuery, conn);
                    markCmd.Parameters.AddWithValue("@token", token);
                    markCmd.ExecuteNonQuery();

                    return "success";
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[LoginController] ResetPasswordWithToken error: {ex.Message}");
                    return "error";
                }
            }
        }

        /// <summary>
        /// Request a customer password (phone number) reset: verify customer_id + phone + email match,
        /// generate token, store in DB, and send email.
        /// Returns: "success", "customer_not_found", "phone_mismatch", "email_mismatch", "email_failed", or "error".
        /// </summary>
        public string RequestCustomerPasswordReset(string customerId, string phone, string email)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();

                    // 1. Check if customer exists and phone + email match
                    string checkQuery = "SELECT customer_id, customer_name, contact_number, email FROM customers WHERE customer_id = @cid";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@cid", customerId);

                    string customerName = "";
                    using (MySqlDataReader reader = checkCmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return "customer_not_found";
                        }

                        string dbPhone = reader["contact_number"] != null ? reader["contact_number"].ToString() : "";
                        string dbEmail = reader["email"] != null ? reader["email"].ToString() : "";
                        customerName = reader["customer_name"].ToString();

                        if (string.IsNullOrEmpty(dbPhone) || !dbPhone.Equals(phone, StringComparison.OrdinalIgnoreCase))
                        {
                            return "phone_mismatch";
                        }

                        if (string.IsNullOrEmpty(dbEmail) || !dbEmail.Equals(email, StringComparison.OrdinalIgnoreCase))
                        {
                            return "email_mismatch";
                        }
                    }

                    // 2. Invalidate any existing tokens for this customer
                    string invalidateQuery = "UPDATE customer_password_reset_tokens SET is_used = 1 WHERE customer_id = @cid AND is_used = 0";
                    MySqlCommand invalidateCmd = new MySqlCommand(invalidateQuery, conn);
                    invalidateCmd.Parameters.AddWithValue("@cid", customerId);
                    invalidateCmd.ExecuteNonQuery();

                    // 3. Generate new token
                    string token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32)).Replace("+", "-").Replace("/", "_").Replace("=", "");

                    // 4. Insert token into database (expires in 10 minutes)
                    string insertQuery = "INSERT INTO customer_password_reset_tokens (token, customer_id, expires_at, is_used, created_at) VALUES (@token, @cid, DATE_ADD(NOW(), INTERVAL 10 MINUTE), 0, NOW())";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@token", token);
                    insertCmd.Parameters.AddWithValue("@cid", customerId);
                    insertCmd.ExecuteNonQuery();

                    // 5. Send email
                    var (sent, _) = EmailService.SendPasswordResetEmail(email, customerName, token, "en");
                    if (!sent)
                    {
                        return "email_failed";
                    }

                    return "success";
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[LoginController] RequestCustomerPasswordReset error: {ex.Message}");
                    return "error";
                }
            }
        }

        /// <summary>
        /// Reset customer password (phone number) using token: verify token validity, update contact_number, mark token as used.
        /// Returns: "success" if phone number updated, or error message.
        /// </summary>
        public string ResetCustomerPasswordWithToken(string token, string newPhoneNumber)
        {
            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    conn.Open();

                    // 1. Verify token exists, is not used, and has not expired
                    string checkQuery = "SELECT customer_id, expires_at, is_used FROM customer_password_reset_tokens WHERE token = @token";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@token", token);

                    using (MySqlDataReader reader = checkCmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return "token_invalid";
                        }

                        bool isUsed = reader["is_used"] != null && Convert.ToInt32(reader["is_used"]) == 1;
                        if (isUsed)
                        {
                            return "token_used";
                        }

                        DateTime expiresAt = Convert.ToDateTime(reader["expires_at"]);
                        if (DateTime.Now > expiresAt)
                        {
                            return "token_expired";
                        }
                    }

                    // 2. Update contact_number (used as password) in customers table
                    string updatePhoneQuery = "UPDATE customers SET contact_number = @phone WHERE customer_id = (SELECT customer_id FROM customer_password_reset_tokens WHERE token = @token AND is_used = 0)";
                    MySqlCommand updatePhoneCmd = new MySqlCommand(updatePhoneQuery, conn);
                    updatePhoneCmd.Parameters.AddWithValue("@phone", newPhoneNumber);
                    updatePhoneCmd.Parameters.AddWithValue("@token", token);
                    updatePhoneCmd.ExecuteNonQuery();

                    // 3. Mark token as used
                    string markUsedQuery = "UPDATE customer_password_reset_tokens SET is_used = 1 WHERE token = @token";
                    MySqlCommand markCmd = new MySqlCommand(markUsedQuery, conn);
                    markCmd.Parameters.AddWithValue("@token", token);
                    markCmd.ExecuteNonQuery();

                    return "success";
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[LoginController] ResetCustomerPasswordWithToken error: {ex.Message}");
                    return "error";
                }
            }
        }

        /// <summary>
        /// Register a new staff member
        /// Returns: "success" if registered, "user_exists" if username already exists, "error" on failure
        /// </summary>
        public string RegisterStaff(string staffId, string staffName, string password, string email, string role)
        {
            Console.WriteLine($"[LoginController] RegisterStaff called with:");
            Console.WriteLine($"  - staffId: '{staffId}'");
            Console.WriteLine($"  - staffName: '{staffName}'");
            Console.WriteLine($"  - password: '{password}' (length: {password?.Length ?? 0})");
            Console.WriteLine($"  - email: '{email}'");
            Console.WriteLine($"  - role: '{role}'");

            using (MySqlConnection conn = DatabaseManager.GetConnection())
            {
                try
                {
                    Console.WriteLine("[LoginController] RegisterStaff: Opening database connection...");
                    conn.Open();
                    Console.WriteLine("[LoginController] RegisterStaff: Database connection opened!");

                    // 1. Check if staff ID already exists
                    string checkQuery = "SELECT staff_id FROM staff WHERE staff_id = @staffId";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@staffId", staffId);

                    Console.WriteLine("[LoginController] RegisterStaff: Checking if staff ID exists...");
                    using (MySqlDataReader reader = checkCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine("[LoginController] RegisterStaff: Staff ID already exists!");
                            return "user_exists";
                        }
                        Console.WriteLine("[LoginController] RegisterStaff: Staff ID is available!");
                    }

                    // 2. Insert new staff member
                    string insertQuery = "INSERT INTO staff (staff_id, staff_name, password, email, role, status) " +
                                         "VALUES (@staffId, @staffName, @password, @email, @role, 'Active')";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@staffId", staffId);
                    insertCmd.Parameters.AddWithValue("@staffName", staffName);
                    insertCmd.Parameters.AddWithValue("@password", password);
                    insertCmd.Parameters.AddWithValue("@email", email);
                    insertCmd.Parameters.AddWithValue("@role", role);

                    Console.WriteLine("[LoginController] RegisterStaff: Inserting new staff into database...");
                    int rowsAffected = insertCmd.ExecuteNonQuery();
                    Console.WriteLine($"[LoginController] RegisterStaff: Inserted {rowsAffected} row(s)!");

                    // 3. Send Discord notification to IT team (optional)
                    try
                    {
                        var discordTask = DiscordNotificationService.SendPasswordResetNotification(staffId, email, "NEW_ACCOUNT");
                        discordTask.Wait();
                    }
                    catch
                    {
                        // 即使Discord通知失败，也不影响主流程
                    }

                    return "success";
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[LoginController] RegisterStaff error: {ex.Message}");
                    Console.WriteLine($"[LoginController] RegisterStaff stack trace: {ex.StackTrace}");
                    return "error";
                }
            }
        }
    }
}