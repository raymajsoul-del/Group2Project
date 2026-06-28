using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Group2Project.Controllers;

namespace Group2Project.Views.Sub06_Logistic
{
    public partial class LogisticForm : Form
    {
        private LogisticController _controller;

        private readonly Color _primaryColor = Color.FromArgb(30, 144, 255);
        private readonly Color _secondaryColor = Color.FromArgb(135, 206, 250);
        private readonly Color _backgroundColor = Color.FromArgb(245, 245, 245);

        public LogisticForm()
        {
            InitializeComponent();
            _controller = new LogisticController();

            this.Load += LogisticForm_Load;

            if (btnRefreshPending != null) btnRefreshPending.Click += btnRefreshPending_Click;
            if (btnAssignDelivery != null) btnAssignDelivery.Click += btnAssignDelivery_Click;
        }

        private void LogisticForm_Load(object sender, EventArgs e)
        {
            LoadPendingDeliveries();
        }

        private void btnRefreshPending_Click(object sender, EventArgs e)
        {
            LoadPendingDeliveries();
        }

        private void LoadPendingDeliveries()
        {
            try
            {
                if (dgvPendingDeliveries != null)
                {
                    dgvPendingDeliveries.DataSource = _controller.GetPendingDeliveries();
                    dgvPendingDeliveries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvPendingDeliveries.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnAssignDelivery_Click(object sender, EventArgs e)
        {
            if (dgvPendingDeliveries.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a pending delivery to assign.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvPendingDeliveries.SelectedRows[0].IsNewRow || dgvPendingDeliveries.SelectedRows[0].Cells["Delivery ID"].Value == null)
            {
                MessageBox.Show("Please select a valid delivery record, not the empty space.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string driver = cmbDriver.Text;
            string vehicle = cmbVehicle.Text;
            DateTime date = dtpDeliveryDate.Value;

            if (string.IsNullOrWhiteSpace(driver) || string.IsNullOrWhiteSpace(vehicle))
            {
                MessageBox.Show("Please select both a Driver and a Vehicle.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string deliveryId = dgvPendingDeliveries.SelectedRows[0].Cells["Delivery ID"].Value.ToString();

            try
            {
                _controller.AssignDriverAndVehicle(deliveryId, driver, vehicle, date);

                cmbDriver.SelectedIndex = -1;
                cmbVehicle.SelectedIndex = -1;

                LoadPendingDeliveries();

                MessageBox.Show($"Delivery {deliveryId} has been successfully dispatched to driver {driver}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
