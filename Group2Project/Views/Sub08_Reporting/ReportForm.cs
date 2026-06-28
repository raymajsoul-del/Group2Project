using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Group2Project.Controllers;

namespace Group2Project.Views.Sub08_Reporting
{
    public partial class ReportForm : Form
    {
        private ReportingController _controller;

        private System.Windows.Forms.Timer _statusTimer;

        // 侧边栏和内容面板
        private Panel _sidebarPanel;
        private Panel _contentPanel;
        private Panel _panelDashboard;
        private Panel _panelReports;
        private Button _currentNavButton;

        // 颜色主题 (报告主题 - 深蓝色)
        private readonly Color _primaryColor = Color.FromArgb(26, 35, 126);
        private readonly Color _secondaryColor = Color.FromArgb(57, 73, 171);
        private readonly Color _sidebarColor = Color.FromArgb(30, 30, 30);
        private readonly Color _backgroundColor = Color.FromArgb(245, 245, 245);

        public ReportForm()
        {
            // 确保窗体在完全设置好之前不会显示
            this.Visible = false;
            this.ShowInTaskbar = false;

            InitializeComponent();
            _controller = new ReportingController();

            if (btnGenerateDashboard != null) btnGenerateDashboard.Click += btnGenerateDashboard_Click;
            if (btnLoadReport != null) btnLoadReport.Click += btnLoadReport_Click;
            if (btnExportCSV != null) btnExportCSV.Click += btnExportCSV_Click;

            try
            {
                // 先设置内容面板，再移除 TabControl
                SetupContentPanels();

                // 移除原始的 TabControl
                if (tcReportingManager != null)
                {
                    this.Controls.Remove(tcReportingManager);
                    tcReportingManager.Dispose();
                }

                // 设置侧边栏
                SetupSidebar();

                // 显示默认面板
                ShowPanel(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"初始化报表界面时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _statusTimer = new System.Windows.Forms.Timer();
            _statusTimer.Interval = 3000;
            _statusTimer.Tick += (s, e) => {
                if (lblStatus != null) lblStatus.Text = "";
                _statusTimer.Stop();
            };
        }

        private void SetupSidebar()
        {
            // 侧边栏面板
            _sidebarPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 240,
                BackColor = _sidebarColor
            };

            // 侧边栏标题
            Panel sidebarHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.FromArgb(20, 20, 20)
            };

            Label sidebarTitle = new Label
            {
                Text = "📊 Reporting",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 30),
                AutoSize = true
            };

            sidebarHeader.Controls.Add(sidebarTitle);
            _sidebarPanel.Controls.Add(sidebarHeader);

            // 创建导航按钮
            int yPosition = 110;
            CreateNavButton("Executive Dashboard", 0, ref yPosition);
            CreateNavButton("Operational Reports", 1, ref yPosition);

            this.Controls.Add(_sidebarPanel);
        }

        private void CreateNavButton(string text, int index, ref int yPosition)
        {
            Button btn = new Button
            {
                Text = text,
                Tag = index,
                Location = new Point(15, yPosition),
                Size = new Size(210, 50),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0),
                Cursor = Cursors.Hand
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 60, 60);
            btn.Click += NavButton_Click;

            _sidebarPanel.Controls.Add(btn);
            yPosition += 55;
        }

        private void NavButton_Click(object sender, EventArgs e)
        {
            Button clickedBtn = sender as Button;
            if (clickedBtn == null) return;

            int index = (int)clickedBtn.Tag;
            ShowPanel(index);
        }

        private void SetupContentPanels()
        {
            // 内容面板
            _contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor
            };

            // Dashboard 面板 - 从 tbExecutiveDashboard 移动控件
            _panelDashboard = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor
            };
            MoveControlsFromTabPage(tbExecutiveDashboard, _panelDashboard);

            // Reports 面板
            _panelReports = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _backgroundColor,
                Visible = false
            };
            MoveControlsFromTabPage(tbOperationalReports, _panelReports);

            // 添加所有面板到内容面板
            _contentPanel.Controls.Add(_panelReports);
            _contentPanel.Controls.Add(_panelDashboard);

            this.Controls.Add(_contentPanel);
            _contentPanel.BringToFront();
        }

        private void MoveControlsFromTabPage(TabPage tabPage, Panel targetPanel)
        {
            Control[] controls = new Control[tabPage.Controls.Count];
            tabPage.Controls.CopyTo(controls, 0);

            foreach (Control ctrl in controls)
            {
                tabPage.Controls.Remove(ctrl);
                targetPanel.Controls.Add(ctrl);
            }
        }

        private void ShowPanel(int index)
        {
            // 隐藏所有面板
            _panelDashboard.Visible = false;
            _panelReports.Visible = false;

            // 重置所有导航按钮
            foreach (Control ctrl in _sidebarPanel.Controls)
            {
                if (ctrl is Button btn && btn.Tag is int)
                {
                    btn.BackColor = Color.Transparent;
                    btn.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
                }
            }

            // 高亮当前按钮
            foreach (Control ctrl in _sidebarPanel.Controls)
            {
                if (ctrl is Button btn && btn.Tag is int tag && tag == index)
                {
                    _currentNavButton = btn;
                    btn.BackColor = _primaryColor;
                    btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    break;
                }
            }

            // 显示选中的面板
            switch (index)
            {
                case 0:
                    _panelDashboard.Visible = true;
                    _panelDashboard.BringToFront();
                    break;
                case 1:
                    _panelReports.Visible = true;
                    _panelReports.BringToFront();
                    break;
            }
        }

        private void ShowSuccessStatus(string message)
        {
            if (lblStatus != null)
            {
                lblStatus.Text = "✅ " + message;
                lblStatus.ForeColor = Color.Green;
                _statusTimer.Stop();
                _statusTimer.Start();
            }
        }

        private void btnGenerateDashboard_Click(object sender, EventArgs e)
        {
            LoadSalesTrendChart();
            LoadTopProductsPieChart();

            ShowSuccessStatus("Dashboard generated successfully!");
        }

        private void LoadSalesTrendChart()
        {
            if (chartSalesTrend == null) return;

            try
            {
                DataTable dt = _controller.GetSalesTrendData();

                chartSalesTrend.Series["Series1"].Points.Clear();
                chartSalesTrend.Series["Series1"].Name = "Order Count";
                foreach (DataRow row in dt.Rows)
                {
                    string status = row["order_status"].ToString();
                    int count = Convert.ToInt32(row["count"]);
                    chartSalesTrend.Series["Order Count"].Points.AddXY(status, count);
                }
            }
            catch (Exception ex) { Console.WriteLine("Chart error: " + ex.Message); }
        }

        private void LoadTopProductsPieChart()
        {
            if (chartTopProducts == null) return;

            try
            {
                DataTable dt = _controller.GetTopProductsData();

                chartTopProducts.Series["Series1"].Points.Clear();
                chartTopProducts.Series["Series1"].IsValueShownAsLabel = true;
                foreach (DataRow row in dt.Rows)
                {
                    string category = row["inv_category"].ToString();
                    int count = Convert.ToInt32(row["count"]);
                    chartTopProducts.Series["Series1"].Points.AddXY(category, count);
                }
            }
            catch (Exception ex) { Console.WriteLine("Pie chart error: " + ex.Message); }
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            if (cmbReportType.SelectedItem == null)
            {
                MessageBox.Show("Please select a report type first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedReport = cmbReportType.SelectedItem.ToString();

            try
            {
                DataTable dt = _controller.GetOperationalReport(selectedReport);

                if (dgvReportSummary != null)
                {
                    dgvReportSummary.DataSource = dt;
                    dgvReportSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load report: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            if (dgvReportSummary == null || dgvReportSummary.Rows.Count == 0 || dgvReportSummary.DataSource == null)
            {
                MessageBox.Show("No data to export. Please load a report first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV File|*.csv";
            sfd.Title = "Save Report as CSV";
            sfd.FileName = "CCMS_Report_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < dgvReportSummary.Columns.Count; i++)
                    {
                        sb.Append(dgvReportSummary.Columns[i].HeaderText);
                        if (i < dgvReportSummary.Columns.Count - 1) sb.Append(",");
                    }
                    sb.AppendLine();

                    foreach (DataGridViewRow row in dgvReportSummary.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            for (int i = 0; i < dgvReportSummary.Columns.Count; i++)
                            {
                                sb.Append(row.Cells[i].Value?.ToString().Replace(",", " "));
                                if (i < dgvReportSummary.Columns.Count - 1) sb.Append(",");
                            }
                            sb.AppendLine();
                        }
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Report exported successfully to:\n" + sfd.FileName, "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to export data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
