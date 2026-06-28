using System;
using System.Data;
using System.Windows.Forms;
using Group2Project.Controllers;

namespace Group2Project.Views.Sub10_Messages
{
    public partial class NotificationForm : Form
    {
        private readonly NotificationController _notificationController;
        private string _currentUserId = "S001";
        private bool _showUnreadOnly = false;

        public NotificationForm()
        {
            InitializeComponent();
            _notificationController = new NotificationController();
            LoadNotifications();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnUnreadFilter = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnMarkAllRead = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.dgvNotifications = new System.Windows.Forms.DataGridView();
            this.btnShowTestNotification = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotifications)).BeginInit();
            this.SuspendLayout();
            
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "系統通知";
            
            this.btnUnreadFilter.Location = new System.Drawing.Point(120, 15);
            this.btnUnreadFilter.Name = "btnUnreadFilter";
            this.btnUnreadFilter.Size = new System.Drawing.Size(120, 30);
            this.btnUnreadFilter.TabIndex = 1;
            this.btnUnreadFilter.Text = "顯示未讀";
            this.btnUnreadFilter.UseVisualStyleBackColor = true;
            this.btnUnreadFilter.Click += new System.EventHandler(this.BtnUnreadFilter_Click);
            
            this.btnRefresh.Location = new System.Drawing.Point(250, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 30);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "重新整理";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            
            this.btnMarkAllRead.Location = new System.Drawing.Point(340, 15);
            this.btnMarkAllRead.Name = "btnMarkAllRead";
            this.btnMarkAllRead.Size = new System.Drawing.Size(100, 30);
            this.btnMarkAllRead.TabIndex = 3;
            this.btnMarkAllRead.Text = "標記全部已讀";
            this.btnMarkAllRead.UseVisualStyleBackColor = true;
            this.btnMarkAllRead.Click += new System.EventHandler(this.BtnMarkAllRead_Click);
            
            this.btnClearAll.Location = new System.Drawing.Point(450, 15);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(80, 30);
            this.btnClearAll.TabIndex = 4;
            this.btnClearAll.Text = "清空全部";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.BtnClearAll_Click);
            
            this.dgvNotifications.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNotifications.AllowUserToAddRows = false;
            this.dgvNotifications.AllowUserToDeleteRows = false;
            this.dgvNotifications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNotifications.Location = new System.Drawing.Point(12, 60);
            this.dgvNotifications.Name = "dgvNotifications";
            this.dgvNotifications.ReadOnly = true;
            this.dgvNotifications.Size = new System.Drawing.Size(760, 490);
            this.dgvNotifications.TabIndex = 5;
            this.dgvNotifications.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvNotifications_CellDoubleClick);
            
            this.btnShowTestNotification.Location = new System.Drawing.Point(540, 15);
            this.btnShowTestNotification.Name = "btnShowTestNotification";
            this.btnShowTestNotification.Size = new System.Drawing.Size(100, 30);
            this.btnShowTestNotification.TabIndex = 6;
            this.btnShowTestNotification.Text = "測試彈窗";
            this.btnShowTestNotification.UseVisualStyleBackColor = true;
            this.btnShowTestNotification.Click += new System.EventHandler(this.BtnShowTestNotification_Click);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.btnShowTestNotification);
            this.Controls.Add(this.dgvNotifications);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnMarkAllRead);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnUnreadFilter);
            this.Controls.Add(this.lblTitle);
            this.Name = "NotificationForm";
            this.Text = "系統通知";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotifications)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblTitle;
        private Button btnUnreadFilter;
        private Button btnRefresh;
        private Button btnMarkAllRead;
        private Button btnClearAll;
        private DataGridView dgvNotifications;
        private Button btnShowTestNotification;

        private void LoadNotifications()
        {
            var dt = _notificationController.GetNotifications(_currentUserId, _showUnreadOnly);
            dgvNotifications.DataSource = dt;
        }

        private void BtnUnreadFilter_Click(object sender, EventArgs e)
        {
            _showUnreadOnly = !_showUnreadOnly;
            btnUnreadFilter.Text = _showUnreadOnly ? "顯示全部" : "顯示未讀";
            LoadNotifications();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadNotifications();
        }

        private void DgvNotifications_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvNotifications.Rows[e.RowIndex].Cells["IsRead"].Value.ToString() == "False")
            {
                int notificationId = Convert.ToInt32(dgvNotifications.Rows[e.RowIndex].Cells["NotificationId"].Value);
                _notificationController.MarkAsRead(notificationId);
                LoadNotifications();
            }
        }

        private void BtnMarkAllRead_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvNotifications.Rows.Count; i++)
            {
                if (dgvNotifications.Rows[i].Cells["IsRead"].Value.ToString() == "False")
                {
                    int notificationId = Convert.ToInt32(dgvNotifications.Rows[i].Cells["NotificationId"].Value);
                    _notificationController.MarkAsRead(notificationId);
                }
            }
            MessageBox.Show("全部已標記為已讀！");
            LoadNotifications();
        }

        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要清空所有通知嗎？", "確認", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                while (dgvNotifications.Rows.Count > 0)
                {
                    int notificationId = Convert.ToInt32(dgvNotifications.Rows[0].Cells["NotificationId"].Value);
                    _notificationController.DeleteNotification(notificationId);
                    dgvNotifications.Rows.RemoveAt(0);
                }
                LoadNotifications();
            }
        }

        private void BtnShowTestNotification_Click(object sender, EventArgs e)
        {
            NotificationController.ShowBalloonNotification(
                "測試通知",
                "這是一個 Windows 氣泡通知的測試！",
                NotificationController.NotificationType.SystemAlert
            );
        }
    }
}
