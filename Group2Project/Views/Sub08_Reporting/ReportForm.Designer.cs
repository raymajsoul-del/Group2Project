namespace Group2Project.Views.Sub08_Reporting
{
    partial class ReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            tcReportingManager = new TabControl();
            tbExecutiveDashboard = new TabPage();
            chartTopProducts = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartSalesTrend = new System.Windows.Forms.DataVisualization.Charting.Chart();
            btnGenerateDashboard = new Button();
            dtpEndDate = new DateTimePicker();
            label2 = new Label();
            dtpStartDate = new DateTimePicker();
            label1 = new Label();
            tbOperationalReports = new TabPage();
            dgvReportSummary = new DataGridView();
            btnExportCSV = new Button();
            btnLoadReport = new Button();
            cmbReportType = new ComboBox();
            label3 = new Label();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            tcReportingManager.SuspendLayout();
            tbExecutiveDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartTopProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartSalesTrend).BeginInit();
            tbOperationalReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportSummary).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tcReportingManager
            // 
            tcReportingManager.Controls.Add(tbExecutiveDashboard);
            tcReportingManager.Controls.Add(tbOperationalReports);
            tcReportingManager.Dock = DockStyle.Fill;
            tcReportingManager.Location = new Point(0, 0);
            tcReportingManager.Name = "tcReportingManager";
            tcReportingManager.SelectedIndex = 0;
            tcReportingManager.TabIndex = 0;
            // 
            // tbExecutiveDashboard
            // 
            tbExecutiveDashboard.Controls.Add(chartTopProducts);
            tbExecutiveDashboard.Controls.Add(chartSalesTrend);
            tbExecutiveDashboard.Controls.Add(btnGenerateDashboard);
            tbExecutiveDashboard.Controls.Add(dtpEndDate);
            tbExecutiveDashboard.Controls.Add(label2);
            tbExecutiveDashboard.Controls.Add(dtpStartDate);
            tbExecutiveDashboard.Controls.Add(label1);
            tbExecutiveDashboard.Location = new Point(4, 32);
            tbExecutiveDashboard.Name = "tbExecutiveDashboard";
            tbExecutiveDashboard.Padding = new Padding(3);
            tbExecutiveDashboard.Size = new Size(920, 558);
            tbExecutiveDashboard.TabIndex = 0;
            tbExecutiveDashboard.Text = "Executive Dashboard";
            tbExecutiveDashboard.UseVisualStyleBackColor = true;
            // 
            // chartTopProducts
            // 
            chartArea1.Name = "ChartArea1";
            chartTopProducts.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartTopProducts.Legends.Add(legend1);
            chartTopProducts.Location = new Point(462, 110);
            chartTopProducts.Name = "chartTopProducts";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartTopProducts.Series.Add(series1);
            chartTopProducts.Size = new Size(421, 411);
            chartTopProducts.TabIndex = 5;
            chartTopProducts.Text = "chart1";
            // 
            // chartSalesTrend
            // 
            chartArea2.Name = "ChartArea1";
            chartSalesTrend.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartSalesTrend.Legends.Add(legend2);
            chartSalesTrend.Location = new Point(23, 110);
            chartSalesTrend.Name = "chartSalesTrend";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartSalesTrend.Series.Add(series2);
            chartSalesTrend.Size = new Size(406, 411);
            chartSalesTrend.TabIndex = 1;
            chartSalesTrend.Text = "chart1";
            // 
            // btnGenerateDashboard
            // 
            btnGenerateDashboard.BackColor = Color.SteelBlue;
            btnGenerateDashboard.Location = new Point(569, 25);
            btnGenerateDashboard.Name = "btnGenerateDashboard";
            btnGenerateDashboard.Size = new Size(205, 72);
            btnGenerateDashboard.TabIndex = 4;
            btnGenerateDashboard.Text = "Generate Dashboard";
            btnGenerateDashboard.UseVisualStyleBackColor = false;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(130, 74);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(300, 30);
            dtpEndDate.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 74);
            label2.Name = "label2";
            label2.Size = new Size(92, 23);
            label2.TabIndex = 2;
            label2.Text = "End Date:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Cursor = Cursors.Hand;
            dtpStartDate.Location = new Point(130, 25);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(300, 30);
            dtpStartDate.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 25);
            label1.Name = "label1";
            label1.Size = new Size(101, 23);
            label1.TabIndex = 0;
            label1.Text = "Start Date:";
            // 
            // tbOperationalReports
            // 
            tbOperationalReports.Controls.Add(dgvReportSummary);
            tbOperationalReports.Controls.Add(btnExportCSV);
            tbOperationalReports.Controls.Add(btnLoadReport);
            tbOperationalReports.Controls.Add(cmbReportType);
            tbOperationalReports.Controls.Add(label3);
            tbOperationalReports.Location = new Point(4, 32);
            tbOperationalReports.Name = "tbOperationalReports";
            tbOperationalReports.Padding = new Padding(3);
            tbOperationalReports.Size = new Size(920, 558);
            tbOperationalReports.TabIndex = 1;
            tbOperationalReports.Text = "Operational Reports";
            tbOperationalReports.UseVisualStyleBackColor = true;
            // 
            // dgvReportSummary
            // 
            dgvReportSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReportSummary.Location = new Point(19, 74);
            dgvReportSummary.Name = "dgvReportSummary";
            dgvReportSummary.RowHeadersWidth = 62;
            dgvReportSummary.Size = new Size(813, 435);
            dgvReportSummary.TabIndex = 4;
            // 
            // btnExportCSV
            // 
            btnExportCSV.BackColor = Color.LimeGreen;
            btnExportCSV.Cursor = Cursors.Hand;
            btnExportCSV.FlatStyle = FlatStyle.Flat;
            btnExportCSV.Location = new Point(653, 21);
            btnExportCSV.Name = "btnExportCSV";
            btnExportCSV.Size = new Size(179, 34);
            btnExportCSV.TabIndex = 3;
            btnExportCSV.Text = "Export to CSV";
            btnExportCSV.UseVisualStyleBackColor = false;
            // 
            // btnLoadReport
            // 
            btnLoadReport.BackColor = Color.Aqua;
            btnLoadReport.Cursor = Cursors.Hand;
            btnLoadReport.FlatStyle = FlatStyle.Flat;
            btnLoadReport.Location = new Point(474, 21);
            btnLoadReport.Name = "btnLoadReport";
            btnLoadReport.Size = new Size(112, 34);
            btnLoadReport.TabIndex = 2;
            btnLoadReport.Text = "Load Data";
            btnLoadReport.UseVisualStyleBackColor = false;
            // 
            // cmbReportType
            // 
            cmbReportType.Cursor = Cursors.IBeam;
            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportType.FlatStyle = FlatStyle.Flat;
            cmbReportType.FormattingEnabled = true;
            cmbReportType.Items.AddRange(new object[] { "Monthly Sales Revenue", "Inventory Shortage Alert", "Logistics Performance", "After-Sales Resolution Rate" });
            cmbReportType.Location = new Point(198, 21);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new Size(182, 31);
            cmbReportType.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 21);
            label3.Name = "label3";
            label3.Size = new Size(173, 23);
            label3.TabIndex = 0;
            label3.Text = "Select Report Type:";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 566);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(928, 28);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 21);
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(928, 594);
            Controls.Add(statusStrip1);
            Controls.Add(tcReportingManager);
            Name = "ReportForm";
            Text = "CCMS Executive Dashboard & Reports";
            tcReportingManager.ResumeLayout(false);
            tbExecutiveDashboard.ResumeLayout(false);
            tbExecutiveDashboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartTopProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartSalesTrend).EndInit();
            tbOperationalReports.ResumeLayout(false);
            tbOperationalReports.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportSummary).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tcReportingManager;
        private TabPage tbExecutiveDashboard;
        private TabPage tbOperationalReports;
        private Button btnGenerateDashboard;
        private DateTimePicker dtpEndDate;
        private Label label2;
        private DateTimePicker dtpStartDate;
        private Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSalesTrend;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopProducts;
        private ComboBox cmbReportType;
        private Label label3;
        private DataGridView dgvReportSummary;
        private Button btnExportCSV;
        private Button btnLoadReport;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
    }
}