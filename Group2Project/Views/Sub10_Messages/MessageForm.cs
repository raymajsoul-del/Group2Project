using System;
using System.Data;
using System.Windows.Forms;
using Group2Project.Controllers;
using Group2Project.Utils;

namespace Group2Project.Views.Sub10_Messages
{
    public partial class MessageForm : Form
    {
        private readonly MessageController _messageController;
        private string _currentUserId = "S002";
        private bool _showUnreadOnly = false;

        public MessageForm()
        {
            InitializeComponent();
            _messageController = new MessageController();
            LoadInbox();
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabInbox = new System.Windows.Forms.TabPage();
            this.tabOutbox = new System.Windows.Forms.TabPage();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnUnreadFilter = new System.Windows.Forms.Button();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.dgvMessages = new System.Windows.Forms.DataGridView();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnMarkRead = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReply = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessages)).BeginInit();
            this.SuspendLayout();
            
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Location = new System.Drawing.Point(12, 60);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(860, 490);
            this.tabControl.TabIndex = 0;
            this.tabControl.TabPages.AddRange(new System.Windows.Forms.TabPage[] { this.tabInbox, this.tabOutbox });
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            
            this.tabInbox.Text = "收件箱";
            this.tabInbox.UseVisualStyleBackColor = true;
            
            this.tabOutbox.Text = "已發送";
            this.tabOutbox.UseVisualStyleBackColor = true;
            
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 24);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "系統信箱";
            
            this.btnUnreadFilter.Location = new System.Drawing.Point(120, 15);
            this.btnUnreadFilter.Name = "btnUnreadFilter";
            this.btnUnreadFilter.Size = new System.Drawing.Size(120, 30);
            this.btnUnreadFilter.TabIndex = 2;
            this.btnUnreadFilter.Text = "顯示未讀";
            this.btnUnreadFilter.UseVisualStyleBackColor = true;
            this.btnUnreadFilter.Click += new System.EventHandler(this.BtnUnreadFilter_Click);
            
            this.btnSendMessage.Location = new System.Drawing.Point(260, 15);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(120, 30);
            this.btnSendMessage.TabIndex = 3;
            this.btnSendMessage.Text = "發送訊息";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.BtnSendMessage_Click);
            
            this.dgvMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMessages.AllowUserToAddRows = false;
            this.dgvMessages.AllowUserToDeleteRows = false;
            this.dgvMessages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMessages.Location = new System.Drawing.Point(0, 0);
            this.dgvMessages.Name = "dgvMessages";
            this.dgvMessages.ReadOnly = true;
            this.dgvMessages.Size = new System.Drawing.Size(860, 490);
            this.dgvMessages.TabIndex = 0;
            this.dgvMessages.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMessages_CellDoubleClick);
            this.tabInbox.Controls.Add(this.dgvMessages);
            
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(12, 570);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(60, 15);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "收件人：";
            
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(80, 565);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(200, 23);
            this.cmbTo.TabIndex = 5;
            
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(290, 570);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(45, 15);
            this.lblSubject.TabIndex = 6;
            this.lblSubject.Text = "主旨：";
            
            this.txtSubject.Location = new System.Drawing.Point(340, 565);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(300, 23);
            this.txtSubject.TabIndex = 7;
            
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(12, 600);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(45, 15);
            this.lblContent.TabIndex = 8;
            this.lblContent.Text = "內容：";
            
            this.txtContent.Location = new System.Drawing.Point(80, 600);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(560, 100);
            this.txtContent.TabIndex = 9;
            
            this.btnRefresh.Location = new System.Drawing.Point(390, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 30);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "重新整理";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            
            this.btnMarkRead.Location = new System.Drawing.Point(480, 15);
            this.btnMarkRead.Name = "btnMarkRead";
            this.btnMarkRead.Size = new System.Drawing.Size(100, 30);
            this.btnMarkRead.TabIndex = 11;
            this.btnMarkRead.Text = "標記已讀";
            this.btnMarkRead.UseVisualStyleBackColor = true;
            this.btnMarkRead.Click += new System.EventHandler(this.BtnMarkRead_Click);
            
            this.btnDelete.Location = new System.Drawing.Point(590, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            
            this.btnReply.Location = new System.Drawing.Point(680, 15);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(80, 30);
            this.btnReply.TabIndex = 13;
            this.btnReply.Text = "回覆";
            this.btnReply.UseVisualStyleBackColor = true;
            this.btnReply.Click += new System.EventHandler(this.BtnReply_Click);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 712);
            this.Controls.Add(this.btnReply);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnMarkRead);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.btnUnreadFilter);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tabControl);
            this.Name = "MessageForm";
            this.Text = "系統信箱";
            this.tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private TabControl tabControl;
        private TabPage tabInbox;
        private TabPage tabOutbox;
        private Label lblTitle;
        private Button btnUnreadFilter;
        private Button btnSendMessage;
        private DataGridView dgvMessages;
        private TextBox txtSubject;
        private TextBox txtContent;
        private Label lblSubject;
        private Label lblContent;
        private Label lblTo;
        private ComboBox cmbTo;
        private Button btnRefresh;
        private Button btnMarkRead;
        private Button btnDelete;
        private Button btnReply;

        private void LoadInbox()
        {
            var dt = _messageController.GetInbox(_currentUserId, _showUnreadOnly);
            dgvMessages.DataSource = dt;
            LoadRecipientList();
        }

        private void LoadOutbox()
        {
            var dt = _messageController.GetOutbox(_currentUserId);
            dgvMessages.DataSource = dt;
        }

        private void LoadRecipientList()
        {
            cmbTo.Items.Clear();
            cmbTo.Items.Add("S001 - 張經理");
            cmbTo.Items.Add("S002 - 李助理");
            cmbTo.Items.Add("S003 - 王工程師");
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabInbox)
            {
                LoadInbox();
            }
            else if (tabControl.SelectedTab == tabOutbox)
            {
                LoadOutbox();
            }
        }

        private void BtnUnreadFilter_Click(object sender, EventArgs e)
        {
            _showUnreadOnly = !_showUnreadOnly;
            btnUnreadFilter.Text = _showUnreadOnly ? "顯示全部" : "顯示未讀";
            if (tabControl.SelectedTab == tabInbox)
            {
                LoadInbox();
            }
        }

        private void BtnSendMessage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbTo.Text) || string.IsNullOrWhiteSpace(txtSubject.Text) || string.IsNullOrWhiteSpace(txtContent.Text))
            {
                MessageBox.Show("請填寫完整資訊！");
                return;
            }
            
            string receiverId = cmbTo.Text.Split(' ')[0];
            _messageController.SendMessage(_currentUserId, receiverId, txtSubject.Text, txtContent.Text);
            
            txtSubject.Clear();
            txtContent.Clear();
            
            MessageBox.Show("訊息已發送！");
            LoadInbox();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabInbox)
            {
                LoadInbox();
            }
            else if (tabControl.SelectedTab == tabOutbox)
            {
                LoadOutbox();
            }
        }

        private void DgvMessages_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMessages.Rows[e.RowIndex].Cells["IsRead"].Value.ToString() == "False")
            {
                int messageId = Convert.ToInt32(dgvMessages.Rows[e.RowIndex].Cells["MessageId"].Value);
                _messageController.MarkAsRead(messageId);
                LoadInbox();
            }
        }

        private void BtnMarkRead_Click(object sender, EventArgs e)
        {
            if (dgvMessages.SelectedRows.Count > 0)
            {
                int messageId = Convert.ToInt32(dgvMessages.SelectedRows[0].Cells["MessageId"].Value);
                _messageController.MarkAsRead(messageId);
                LoadInbox();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMessages.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("確定要刪除這條訊息嗎？", "確認", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int messageId = Convert.ToInt32(dgvMessages.SelectedRows[0].Cells["MessageId"].Value);
                    _messageController.DeleteMessage(messageId);
                    LoadInbox();
                }
            }
        }

        private void BtnReply_Click(object sender, EventArgs e)
        {
            if (dgvMessages.SelectedRows.Count > 0)
            {
                string senderId = dgvMessages.SelectedRows[0].Cells["SenderId"].Value.ToString();
                string senderName = dgvMessages.SelectedRows[0].Cells["SenderName"].Value.ToString();
                cmbTo.Text = $"{senderId} - {senderName}";
                txtSubject.Text = "Re: " + dgvMessages.SelectedRows[0].Cells["Subject"].Value.ToString();
            }
        }
    }
}
