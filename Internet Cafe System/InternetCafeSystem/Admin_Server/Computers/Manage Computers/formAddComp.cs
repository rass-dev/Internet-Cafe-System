using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Resources.ResXFileRef;

namespace InternetCafe
{
    public partial class formAddComp : Form
    {
        private formManagePC managePCForm;
        private Label ipaddressvalidation;

        public formAddComp(formManagePC managePCForm)
        {
            InitializeComponent();
            this.managePCForm = managePCForm;

            ipaddressvalidation = new Label
            {
                AutoSize = true,
                ForeColor = Color.Red,
                Location = new Point(txtLANIP.Location.X, txtLANIP.Location.Y + txtLANIP.Height + 5)
            };

            Controls.Add(ipaddressvalidation);
            ipaddressvalidation.BringToFront();
        }

        private void formSub2_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void txtLANIP_TextChanged(object sender, EventArgs e)
        {
            string ipAddress = txtLANIP.Text;

            ipAddress = Regex.Replace(ipAddress, @"[^\d\.]", "");
            if (ipAddress.Length > 15)
                ipAddress = ipAddress.Substring(0, 15);

            int dotCount = ipAddress.Count(c => c == '.');
            if (dotCount > 3)
                ipAddress = ipAddress.Remove(ipAddress.LastIndexOf('.'));

            string[] octets = ipAddress.Split('.');

            for (int i = 0; i < octets.Length; i++)
            {
                octets[i] = octets[i].TrimStart('0');

                if (octets[i].Length > 3)
                    octets[i] = octets[i].Substring(0, 3);

                int octetValue = 0;
                if (!string.IsNullOrEmpty(octets[i]) && !int.TryParse(octets[i], out octetValue))
                {
                    octets[i] = "";
                }
                else if (octetValue < 0 || octetValue > 255)
                {
                    octets[i] = "";
                }
            }

            ipAddress = string.Join(".", octets);

            txtLANIP.Text = ipAddress;
            txtLANIP.SelectionStart = ipAddress.Length;
            if (IsValidIPAddress(ipAddress))
            {
                if (ipAddress.Split('.').Length == 4)
                {
                    string subnetMask = CalculateSubnetMask(ipAddress);
                    txtSubnetMask.Text = subnetMask;
                }
            }
            else
            {
                txtSubnetMask.Text = "";
            }
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
                return "Invalid IP address. Please specify a value 1 and 233.";
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLANIP.Text = "";
        }

        private void btnAddComputer_Click(object sender, EventArgs e)
        {
            string ipAddress = txtLANIP.Text.Trim();

            if (string.IsNullOrEmpty(ipAddress))
            {
                ipaddressvalidation.Text = "Please enter IP Address.";
                return;
            }
            else
            {
                ipaddressvalidation.Text = "";
            }

            if (!IsValidIPAddress(ipAddress))
            {
                MessageBox.Show("Please enter a valid IP address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (managePCForm.IPAddressExists(ipAddress))
            {
                MessageBox.Show("IP address already exists. Please enter a different one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string connectionString = "Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_Admin;Password=1234admin;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string maxComputerNumberQuery = "SELECT MAX(Computer_Number) FROM tbl_computer";
                    SqlCommand getMaxComputerNumberCommand = new SqlCommand(maxComputerNumberQuery, connection);
                    object maxComputerNumberResult = getMaxComputerNumberCommand.ExecuteScalar();
                    int maxComputerNumber = maxComputerNumberResult != DBNull.Value ? Convert.ToInt32(maxComputerNumberResult) : 0;

                    int newComputerNumber = maxComputerNumber + 1;

                    string query = "INSERT INTO tbl_computer (Computer_Number, LAN_Port_No, System_Working) VALUES (@ComputerNumber, @LANPortNo, 'Working')";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ComputerNumber", newComputerNumber);
                    cmd.Parameters.AddWithValue("@LANPortNo", ipAddress);
                    cmd.ExecuteNonQuery();
                }

                this.Close();

                managePCForm.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding computer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string lastRemovedDigit = "";
        private void txtSubnetMask_TextChanged(object sender, EventArgs e)
        {

            txtSubnetMask.ReadOnly = true;

            string subnetMask = txtSubnetMask.Text;

            subnetMask = Regex.Replace(subnetMask, @"[^\d\.]", "");
            if (subnetMask.Length > 15)
                subnetMask = subnetMask.Substring(0, 15);

            int dotCount = subnetMask.Count(c => c == '.');
            if (dotCount > 3)
                subnetMask = subnetMask.Remove(subnetMask.LastIndexOf('.'));

            string[] octets = subnetMask.Split('.');

            if (octets.Length > 4)
            {
                Array.Resize(ref octets, 4);
            }


            subnetMask = string.Join(".", octets);

            txtSubnetMask.Text = subnetMask;
            txtSubnetMask.SelectionStart = subnetMask.Length;
            if (IsValidSubnetMask(subnetMask))
            {
                string ipAddress = txtLANIP.Text.Trim();
                if (IsValidIPAddress(ipAddress))
                {
                    string calculatedSubnetMask = CalculateSubnetMask(ipAddress);
                    if (subnetMask != calculatedSubnetMask)
                    {
                        MessageBox.Show("The subnet mask does not match the IP address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        int lastDotIndex = subnetMask.LastIndexOf('.');
                        if (lastDotIndex != -1)
                        {
                            int lastDigitIndex = subnetMask.LastIndexOf('.') + octets[octets.Length - 1].Length;
                            if (lastDigitIndex != -1 && subnetMask.Length > lastDigitIndex)
                            {
                                lastRemovedDigit = subnetMask.Substring(lastDigitIndex, 1); subnetMask = subnetMask.Remove(lastDigitIndex, 1); txtSubnetMask.Text = subnetMask;
                                txtSubnetMask.SelectionStart = subnetMask.Length;
                            }
                        }
                    }
                }
            }
            else
            {

                if (subnetMask.Length < txtSubnetMask.Text.Length)
                {
                    txtSubnetMask.Text = subnetMask;
                    txtSubnetMask.SelectionStart = subnetMask.Length;
                }
            }
        }

        private void txtSubnetMask_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && lastRemovedDigit != "")
            {
                txtSubnetMask.Text += lastRemovedDigit;
                txtSubnetMask.SelectionStart = txtSubnetMask.Text.Length; lastRemovedDigit = "";
            }
        }

        private bool IsValidSubnetMask(string subnetMask)
        {
            string[] octets = subnetMask.Split('.');

            if (octets.Length != 4)
                return false;

            foreach (string octet in octets)
            {
                if (!int.TryParse(octet, out int result) || result < 0 || result > 255 || octet.Length > 3)
                    return false;
            }

            if (subnetMask.Contains("..") || subnetMask.EndsWith("."))
                return false;

            return true;
        }

    }
}
