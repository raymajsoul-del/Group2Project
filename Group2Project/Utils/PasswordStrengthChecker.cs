using System;
using System.Text.RegularExpressions;

namespace Group2Project.Utils
{
    public enum PasswordStrength
    {
        VeryWeak,
        Weak,
        Fair,
        Good,
        Strong
    }

    public class PasswordStrengthResult
    {
        public PasswordStrength Strength { get; set; }
        public string Message { get; set; }
        public bool IsValid { get; set; }
        public bool HasMinLength { get; set; }
        public bool HasUpperCase { get; set; }
        public bool HasLowerCase { get; set; }
        public bool HasNumber { get; set; }
        public bool HasSpecialChar { get; set; }

        public PasswordStrengthResult()
        {
            Strength = PasswordStrength.VeryWeak;
            Message = "";
            IsValid = false;
            HasMinLength = false;
            HasUpperCase = false;
            HasLowerCase = false;
            HasNumber = false;
            HasSpecialChar = false;
        }
    }

    public class PasswordStrengthChecker
    {
        private const int MinLength = 8;
        private const string SpecialChars = @"!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?";

        public static PasswordStrengthResult CheckPasswordStrength(string password, string language = "en")
        {
            var result = new PasswordStrengthResult();

            if (string.IsNullOrEmpty(password))
            {
                result.Message = language == "zh" ? "請輸入密碼" : "Please enter a password";
                return result;
            }

            int score = 0;

            // 檢查長度
            if (password.Length >= MinLength)
            {
                result.HasMinLength = true;
                score += 1;
            }
            if (password.Length >= 12)
            {
                score += 1;
            }
            if (password.Length >= 16)
            {
                score += 1;
            }

            // 檢查大小寫
            if (Regex.IsMatch(password, @"[A-Z]"))
            {
                result.HasUpperCase = true;
                score += 1;
            }
            if (Regex.IsMatch(password, @"[a-z]"))
            {
                result.HasLowerCase = true;
                score += 1;
            }

            // 檢查數字
            if (Regex.IsMatch(password, @"[0-9]"))
            {
                result.HasNumber = true;
                score += 1;
            }

            // 檢查特殊字元
            if (Regex.IsMatch(password, @"[" + Regex.Escape(SpecialChars) + @"]"))
            {
                result.HasSpecialChar = true;
                score += 2;
            }

            // 確定強度等級
            if (score <= 1)
            {
                result.Strength = PasswordStrength.VeryWeak;
            }
            else if (score <= 3)
            {
                result.Strength = PasswordStrength.Weak;
            }
            else if (score <= 4)
            {
                result.Strength = PasswordStrength.Fair;
            }
            else if (score <= 5)
            {
                result.Strength = PasswordStrength.Good;
            }
            else
            {
                result.Strength = PasswordStrength.Strong;
            }

            // 設置是否有效 (至少需符合基本要求)
            result.IsValid = result.HasMinLength && 
                            result.HasUpperCase && 
                            result.HasLowerCase && 
                            result.HasNumber && 
                            result.HasSpecialChar;

            // 生成提示訊息
            result.Message = GenerateMessage(result, language);

            return result;
        }

        private static string GenerateMessage(PasswordStrengthResult result, string language)
        {
            var requirements = new System.Collections.Generic.List<string>();

            if (!result.HasMinLength)
            {
                requirements.Add(language == "zh" ? "至少 8 個字元" : "At least 8 characters");
            }
            if (!result.HasUpperCase)
            {
                requirements.Add(language == "zh" ? "至少一個大寫字母" : "At least one uppercase letter");
            }
            if (!result.HasLowerCase)
            {
                requirements.Add(language == "zh" ? "至少一個小寫字母" : "At least one lowercase letter");
            }
            if (!result.HasNumber)
            {
                requirements.Add(language == "zh" ? "至少一個數字" : "At least one number");
            }
            if (!result.HasSpecialChar)
            {
                requirements.Add(language == "zh" ? "至少一個特殊字元 (!@#$%^&*等)" : "At least one special character (!@#$%^&* etc.)");
            }

            string strengthText = "";
            switch (result.Strength)
            {
                case PasswordStrength.VeryWeak:
                    strengthText = language == "zh" ? "非常弱" : "Very Weak";
                    break;
                case PasswordStrength.Weak:
                    strengthText = language == "zh" ? "弱" : "Weak";
                    break;
                case PasswordStrength.Fair:
                    strengthText = language == "zh" ? "普通" : "Fair";
                    break;
                case PasswordStrength.Good:
                    strengthText = language == "zh" ? "良好" : "Good";
                    break;
                case PasswordStrength.Strong:
                    strengthText = language == "zh" ? "強" : "Strong";
                    break;
            }

            if (requirements.Count == 0)
            {
                return language == "zh" ? $"密碼強度: {strengthText} - 符合所有要求！" : $"Password Strength: {strengthText} - All requirements met!";
            }
            else
            {
                return language == "zh" ? 
                    $"密碼強度: {strengthText} - 仍需滿足: {string.Join(", ", requirements)}" :
                    $"Password Strength: {strengthText} - Still need: {string.Join(", ", requirements)}";
            }
        }

        public static string GetStrengthColor(PasswordStrength strength)
        {
            switch (strength)
            {
                case PasswordStrength.VeryWeak:
                    return "#ff0000"; // Red
                case PasswordStrength.Weak:
                    return "#ff6600"; // Orange
                case PasswordStrength.Fair:
                    return "#ffcc00"; // Yellow
                case PasswordStrength.Good:
                    return "#99cc00"; // Light Green
                case PasswordStrength.Strong:
                    return "#00cc00"; // Green
                default:
                    return "#888888";
            }
        }
    }
}
