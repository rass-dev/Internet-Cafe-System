using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternetCafe
{
    public partial class formAddAdmin : Form
    {
        private formAdmin adminForm;
        private Label validationLabel; private Dictionary<TextBox, Label> validationLabels;
        public formAddAdmin(formAdmin adminForm)
        {
            InitializeComponent();
            this.adminForm = adminForm;

            validationLabel = new Label
            {
                AutoSize = true,
                ForeColor = Color.Red,
                Location = new Point(txtAdminName.Location.X, txtAdminName.Location.Y + txtAdminName.Height + 5)
            };
            Controls.Add(validationLabel);
            validationLabel.BringToFront();

            validationLabels = new Dictionary<TextBox, Label>();

            AddValidationLabel(txtAdminUserName, "Please enter a valid username (4-20 characters, letters, numbers, or underscore only).");
            AddValidationLabel(txtAdminName, "Please enter a valid admin name (1-20 characters, letters, numbers only).");
            AddValidationLabel(txtAdminEmail, "Please enter a valid email address.");
            AddValidationLabel(txtAdminPhoneNumber, "Please enter a valid phone number (starting with 0 and exactly 11 numbers).");
            AddValidationLabel(txtAdminPassword, "Please enter a password between 8 and 20 characters long.");
        }

        private void AddValidationLabel(TextBox textBox, string message)
        {
            Label label = new Label
            {
                AutoSize = true,
                ForeColor = Color.Red,
                Location = new Point(textBox.Location.X, textBox.Location.Y + textBox.Height + 5),
                Text = message,
                Visible = false
            };
            Controls.Add(label);
            label.BringToFront();

            validationLabels.Add(textBox, label);
        }

        private void formAddAdmin_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            txtAdminName.KeyPress += txtAdminName_KeyPress;

            txtAdminPhoneNumber.KeyPress += txtAdminPhoneNumber_KeyPress;
        }

        private void txtAdminName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            validationLabel.Text = "";

            foreach (var label in validationLabels.Values)
            {
                label.Visible = false;
            }

            if (string.IsNullOrEmpty(txtAdminName.Text) ||
    string.IsNullOrEmpty(txtAdminUserName.Text) ||
    string.IsNullOrEmpty(txtAdminEmail.Text) ||
    string.IsNullOrEmpty(txtAdminPhoneNumber.Text) ||
    string.IsNullOrEmpty(txtAdminPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (string.IsNullOrEmpty(txtAdminName.Text))
                    validationLabels[txtAdminName].Visible = true;

                if (string.IsNullOrEmpty(txtAdminUserName.Text))
                    validationLabels[txtAdminUserName].Visible = true;

                if (string.IsNullOrEmpty(txtAdminEmail.Text))
                    validationLabels[txtAdminEmail].Visible = true;

                if (string.IsNullOrEmpty(txtAdminPhoneNumber.Text))
                    validationLabels[txtAdminPhoneNumber].Visible = true;

                if (string.IsNullOrEmpty(txtAdminPassword.Text))
                    validationLabels[txtAdminPassword].Visible = true;

                return;
            }

            string adminName = txtAdminName.Text.Trim();
            string adminUsername = txtAdminUserName.Text.Trim();
            string adminEmail = txtAdminEmail.Text.Trim();
            string adminPhoneNumber = txtAdminPhoneNumber.Text.Trim();
            string adminPassword = txtAdminPassword.Text;

            if (!Regex.IsMatch(adminName, @"^[a-zA-Z0-9]{1,20}$"))
            {
                validationLabels[txtAdminName].Visible = true;
                ClearTextAndFocus(txtAdminName);
                return;
            }

            if (!Regex.IsMatch(adminUsername, @"^[a-zA-Z0-9_]{4,20}$"))
            {
                validationLabels[txtAdminUserName].Visible = true;
                ClearTextAndFocus(txtAdminUserName);
                return;
            }

            if (!Regex.IsMatch(adminPhoneNumber, @"^0\d{10}$"))
            {
                validationLabels[txtAdminPhoneNumber].Visible = true;
                ClearTextAndFocus(txtAdminPhoneNumber);
                return;
            }

            if (!IsValidEmail(adminEmail))
            {
                validationLabels[txtAdminEmail].Visible = true;
                ClearTextAndFocus(txtAdminEmail);
                return;
            }

            if (adminPassword.Length < 8 || adminPassword.Length > 20)
            {
                validationLabels[txtAdminPassword].Visible = true;
                ClearTextAndFocus(txtAdminPassword);
                return;
            }

            string connectionString = "Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_Admin;Password=1234admin;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO tbl_admin (admin_username, admin_name, admin_email, admin_phone_number, admin_password) " +
                               "VALUES (@AdminUsername, @AdminName, @AdminEmail, @AdminPhoneNumber, @AdminPassword)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AdminUsername", adminUsername);
                    command.Parameters.AddWithValue("@AdminName", adminName);
                    command.Parameters.AddWithValue("@AdminEmail", adminEmail);
                    command.Parameters.AddWithValue("@AdminPhoneNumber", adminPhoneNumber);
                    command.Parameters.AddWithValue("@AdminPassword", adminPassword);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Admin added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearInputFields();

                            adminForm.LoadAdminData();

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add admin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void ClearTextAndFocus(TextBox textBox)
        {
            textBox.Text = "";
            textBox.Focus();
        }

        private void ClearInputFields()
        {
            txtAdminName.Text = "";
            txtAdminUserName.Text = "";
            txtAdminEmail.Text = "";
            txtAdminPhoneNumber.Text = "";
            txtAdminPassword.Text = "";
            txtAdminName.Focus();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnClear_Admin_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void txtAdminPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            string adminPhoneNumber = txtAdminPhoneNumber.Text;

            adminPhoneNumber = new string(adminPhoneNumber.Where(char.IsDigit).ToArray());

            if (adminPhoneNumber.Length > 11)
            {
                MessageBox.Show("Please use a valid phone number.", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAdminPhoneNumber.Text = "";
                return;
            }

            txtAdminPhoneNumber.Text = adminPhoneNumber;
        }

        private void txtAdminPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

