using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Group2Project.Controllers;

namespace Group2Project.Views.Sub12_Shipping
{
    public partial class ShippingForm : Form
    {
        private LogisticController _controller;

        private readonly Color _primaryColor = Color.FromArgb(168, 85, 247); // Purple theme for Shipping
        private readonly Color _secondaryColor = Color.FromArgb(233, 213, 255);
        private readonly Color _backgroundColor = Color.FromArgb(245, 245, 245);

        public ShippingForm()
        {
            InitializeComponent();
            _controller = new LogisticController();

            this.Load += ShippingForm_Load;

            if (btnRefreshTracking != null) btnRefreshTracking.Click += btnRefreshTracking_Click;
            if (btnUpdateStatus != null) btnUpdateStatus.Click += btnUpdateStatus_Click;
            if (btnReturnToInventory != null) btnReturnToInventory.Click += btnReturnToInventory_Click;
            if (btnSearchDelivery != null) btnSearchDelivery.Click += btnSearchDelivery_Click;
        }

        private void ShippingForm_Load(object sender, EventArgs e)
        {
            LoadShipmentTracking();
        }

        private void btnRefreshTracking_Click(object sender, EventArgs e)
        {
            LoadShipmentTracking();
            if (txtSearchDeliveryID != null) txtSearchDeliveryID.Clear();
        }

        private void LoadShipmentTracking()
        {
            try
            {
                if (dgvTrackingList != null)
                {
                    dgvTrackingList.DataSource = _controller.GetShipmentTracking();
                    dgvTrackingList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvTrackingList.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnSearchDelivery_Click(object sender, EventArgs e)
        {
            if (txtSearchDeliveryID == null) return;

            string keyword = txtSearchDeliveryID.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadShipmentTracking();
                return;
            }

            try
            {
                if (dgvTrackingList != null)
                {
                    dgvTrackingList.DataSource = _controller.SearchShipments(keyword);
                }
            }
            catch (Exception ex) { MessageBox.Show("Search failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvTrackingList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a delivery to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string status = cmbUpdateStatus.Text;
            if (string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Please select a new status from the dropdown.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string deliveryId = dgvTrackingList.SelectedRows[0].Cells["Delivery ID"].Value.ToString();

            try
            {
                _controller.UpdateShipmentStatus(deliveryId, status);
                LoadShipmentTracking();
                MessageBox.Show($"Delivery {deliveryId} status updated to '{status}'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnReturnToInventory_Click(object sender, EventArgs e)
        {
            if (dgvTrackingList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a delivery to log failure.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string deliveryId = dgvTrackingList.SelectedRows[0].Cells["Delivery ID"].Value.ToString();
            DialogResult result = MessageBox.Show($"Are you sure you want to log Delivery {deliveryId} as FAILED and return to inventory?", "Confirm Failure", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.UpdateShipmentStatus(deliveryId, "Failed (Returned)");
                    MessageBox.Show("Delivery failure logged.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadShipmentTracking();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
    }
}
