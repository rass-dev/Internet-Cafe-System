using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace InternetCafe
{
    public partial class formEditPC : Form
    {
        private string computerNumber;
        private string ipAddress;
        private string systemWorking;
        private string availability;
        private formManagePC managePCForm;
        private Label ipaddressValidation;

        public formEditPC(string computerNumber, string ipAddress, string systemWorking, formManagePC managePCForm)
        {
            InitializeComponent();
            this.computerNumber = computerNumber;
            this.ipAddress = ipAddress;
            this.systemWorking = systemWorking;
            this.managePCForm = managePCForm;

            cmbComputerNumber.Text = computerNumber;
            txtLANIP.Text = ipAddress;
            cmbSystemWorking.SelectedItem = systemWorking;

            ipaddressValidation = new Label
            {
                AutoSize = true,
                ForeColor = Color.Red,
                Location = new Point(txtLANIP.Location.X, txtLANIP.Location.Y + txtLANIP.Height + 5)
            };

            Controls.Add(ipaddressValidation);
            ipaddressValidation.BringToFront();
        }

        private void formEditPC_Load(object sender, EventArgs e)
        {
            cmbComputerNumber.KeyPress += cmbComputerNumber_KeyPress;
            cmbSystemWorking.KeyPress += cmbSystemWorking_KeyPress;
        }

        private void cmbComputerNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbSystemWorking_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbAvailability_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private bool ComputerNumberExists(string computerNumber)
        {
            return managePCForm.ComputerNumberExists(computerNumber);
        }

        private void btnUpdatePC_Click(object sender, EventArgs e)
        {
            string newComputerNumber = cmbComputerNumber.Text;
            string newIPAddress = txtLANIP.Text.Trim();
            string newSystemWorking = cmbSystemWorking.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(newComputerNumber) || string.IsNullOrWhiteSpace(newIPAddress) || string.IsNullOrWhiteSpace(newSystemWorking))
            {
                ipaddressValidation.Text = "Please assign IP Address";
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newComputerNumber != computerNumber && ComputerNumberExists(newComputerNumber))
            {
                MessageBox.Show("Computer number already exists. Please choose a different one.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IPAddressExists(newIPAddress))
            {
                ipaddressValidation.Text = "IP address already exists. Please choose a different one.";
                MessageBox.Show("IP address already exists. Please choose a different one.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                string lanPortNumber = GetLANPortNumber(newComputerNumber);
                txtLANIP.Text = lanPortNumber;

                return;
            }

            ipaddressValidation.Text = "";

            managePCForm.ApplyChanges(computerNumber, newComputerNumber, newIPAddress, newSystemWorking);

            Close();
        }

        private string GetLANPortNumber(string computerNumber)
        {
            string lanPortNumber = "";

            string connectionString = "Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_Admin;Password=1234admin;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT LAN_Port_No FROM tbl_computer WHERE Computer_Number = @ComputerNumber";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ComputerNumber", computerNumber);
                    lanPortNumber = command.ExecuteScalar()?.ToString();
                }
            }

            return lanPortNumber;
        }

        private bool IPAddressExists(string ipAddress)
        {
            string connectionString = "Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_Admin;Password=1234admin;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM tbl_computer WHERE LAN_Port_No = @IPAddress AND Computer_Number != @ComputerNumber";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IPAddress", ipAddress);
                    command.Parameters.AddWithValue("@ComputerNumber", computerNumber); int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void cmbSystemWorking_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private string CalculateSubnetMask(string ipAddress)
        {
            string[] octets = ipAddress.Split('.');
            int[] subnetMask = new int[4];
            for (int i = 0; i < octets.Length; i++)
            {
                subnetMask[i] = Convert.ToInt32(octets[i]);
            }

            if (subnetMask[0] >= 1 && subnetMask[0] <= 127)
                return "255.0.0.0";
            else if (subnetMask[0] >= 128 && subnetMask[0] <= 191)
                return "255.255.0.0";
            else if (subnetMask[0] >= 192 && subnetMask[0] <= 223)
                return "255.255.255.0";
            else
                return "Invalid IP address. Please specify a value between 1 and 233.";
        }

        private bool IsValidIPAddress(string ipAddress)
        {
            string[] octets = ipAddress.Split('.');

            if (octets.Length != 4)
                return false;

            foreach (string octet in octets)
            {
                if (!int.TryParse(octet, out int result) || result < 0 || result > 255 || octet.Length > 3)
                    return false;
            }

            if (ipAddress.Contains("..") || ipAddress.EndsWith("."))
                return false;

            return true;
        }

        private string GetSubnetMask(string ipAddress)
        {
            if (IsValidIPAddress(ipAddress))
            {
                string subnetMask = CalculateSubnetMask(ipAddress);
                return subnetMask;
            }
            else
            {
                return "";
            }
        }

        private void txtLANIP_TextChanged(object sender, EventArgs e)
        {
            string ipAddress = txtLANIP.Text.Trim();

            if (IsValidIPAddress(ipAddress))
            {
                if (ipAddress.Split('.').Length == 4)
                {
                    string subnetMask = GetSubnetMask(ipAddress);
                    txtSubnetMask.Text = subnetMask;
                }
            }
            else
            {
                txtSubnetMask.Text = "";
            }
        }

        private void cmbComputerNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbComputerNumber.Enabled = false;
        }

        private void txtSubnetMask_TextChanged(object sender, EventArgs e)
        {
            txtSubnetMask.ReadOnly = true;
        }

    }
}
