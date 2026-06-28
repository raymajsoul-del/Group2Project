# 邮件设置指南

## 概述

系统现在支持发送真实的密码重置邮件！默认情况下处于演示模式（不发送邮件），您可以在登录页面的设置中启用它。

## 如何启用真实邮件发送

1. 运行应用程序
2. 在登录页面点击左上角的设置按钮 ⚙️
3. 勾选 "Enable Real Email Sending (Disable for Demo Mode)"
4. 填写以下信息：
   - **SMTP Server**: 您的邮件服务器地址（如 smtp.gmail.com）
   - **SMTP Port**: 端口号（通常是 587 或 465）
   - **Sender Email**: 发送邮件的邮箱地址
   - **Sender Password / App Password**: 您的密码或应用专用密码
   - **Enable SSL / TLS**: 建议勾选
5. 点击 "Save" 保存设置

## 推荐的邮件服务配置

### Gmail
- **SMTP Server**: smtp.gmail.com
- **SMTP Port**: 587
- **Enable SSL**: Yes
- **注意**: 您需要为 Gmail 创建一个应用专用密码（App Password）

### 如何获取 Gmail 应用专用密码
1. 前往您的 Google 账户安全设置
2. 启用 2-Step Verification（两步验证）
3. 点击 "App Passwords"
4. 生成一个新的应用密码
5. 使用此密码作为 Sender Password

### Outlook / Hotmail
- **SMTP Server**: smtp.office365.com
- **SMTP Port**: 587
- **Enable SSL**: Yes

### Yahoo Mail
- **SMTP Server**: smtp.mail.yahoo.com
- **SMTP Port**: 587
- **Enable SSL**: Yes

## 测试邮件功能

1. 在设置页面保存配置后
2. 使用一个已注册的账户尝试重置密码
3. 检查控制台日志以确认邮件发送状态
4. 检查收件箱是否收到了重置邮件

## 重置邮件内容

密码重置邮件包含：
- 个人化问候语
- 重置链接（http://localhost:5233/...）
- 重置令牌（Token）
- 过期时间提醒（10分钟）

## 故障排除

### 邮件发送失败
- 检查 SMTP 配置是否正确
- 确认邮箱账户和密码有效
- 查看控制台日志了解详细错误信息

### 邮件被标记为垃圾邮件
- 检查收件人的垃圾邮件文件夹
- 确保使用官方的 SMTP 服务器

### 默认演示模式
如果不想配置 SMTP 服务器，系统会保持在演示模式，不会发送真实邮件，但仍然可以正常重置密码！

---

## 开发者信息

邮件服务代码位置：
- `Group2Project/DataAccess/EmailService.cs`
- `Group2Project/Views/EmailSettingsForm.cs`
- `Group2Project/Controllers/LoginController.cs`
