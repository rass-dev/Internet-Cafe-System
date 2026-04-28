using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace InternetCafe
{
    public partial class formEditAdmin : Form
    {
        private string adminID;
        private string adminName;
        private string adminUsername;
        private string adminPassword;
        private string adminEmail;
        private string adminPhoneNumber;

        private formAdmin adminForm;

        private Label nameValidationLabel;
        private Label usernameValidationLabel;
        private Label emailValidationLabel;
        private Label phoneValidationLabel;
        private Label passwordValidationLabel;

        public formEditAdmin(formAdmin parentForm, string adminID, string adminName, string adminUsername, string adminPassword, string adminEmail, string adminPhoneNumber)
        {
            InitializeComponent();
            this.adminForm = parentForm;
            this.adminID = adminID;
            this.adminName = adminName;
            this.adminUsername = adminUsername;
            this.adminPassword = adminPassword;
            this.adminEmail = adminEmail;
            this.adminPhoneNumber = adminPhoneNumber;
            SetAdminInfo(adminID, adminName, adminUsername, adminPassword, adminEmail, adminPhoneNumber);
        }

        private void SetAdminInfo(string adminID, string adminName, string adminUsername, string adminPassword, string adminEmail, string adminPhoneNumber)
        {
            txtAdminName.Text = adminName;
            txtAdminUsername.Text = adminUsername;
            txtAdminEmail.Text = adminEmail;
            txtAdminPhoneNumber.Text = adminPhoneNumber;
            txtAdminPassword.Text = adminPassword;

            this.adminID = adminID;
            this.adminName = adminName;
            this.adminUsername = adminUsername;
            this.adminPassword = adminPassword;
            this.adminEmail = adminEmail;
            this.adminPhoneNumber = adminPhoneNumber;
        }

        private void formEditAdmin_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            txtAdminName.KeyPress += txtAdminName_KeyPress;
            txtAdminPhoneNumber.KeyPress += txtAdminPhoneNumber_KeyPress;

                        nameValidationLabel = new Label
            {
                AutoSize = true,
                ForeColor = Color.Red,
                Location = new Point(txtAdminName.Location.X, txtAdminName.Location.Y + txtAdminName.Height + 5),
                Text = "Please enter a valid admin name.",
                Visible = false
            };
            Controls.Add(nameValidationLabel);

            usernameValidationLabel = new Label
            {
                AutoSize = true,
                ForeColor = Color.Red,
                Location = new Point(txtAdminUsername.Location.X, txtAdminUsername.Location.Y + txtAdminUsername.Height + 5),
                Text = "Please enter a valid username.",
                Visible = false
            };
            Controls.Add(usernameValidationLabel);

            emailValidationLabel = new Label
            {
                AutoSize = true,
                ForeColor = Color.Red,
                Location = new Point(txtAdminEmail.Location.X, txtAdminEmail.Location.Y + txtAdminEmail.Height + 5),
                Text = "Please enter a valid email address.",
                Visible = false
            };
            Controls.Add(emailValidationLabel);

            phoneValidationLabel = new Label
            {
                AutoSize = true,
                ForeColor = Color.Red,
                Location = new Point(txtAdminPhoneNumber.Location.X, txtAdminPhoneNumber.Location.Y + txtAdminPhoneNumber.Height + 5),
                Text = "Please enter a valid phone number (starting with 0 and exactly 11 numbers).",
                Visible = false
            };
            Controls.Add(phoneValidationLabel);

            passwordValidationLabel = new Label
            {
                AutoSize = true,
                ForeColor = Color.Red,
                Location = new Point(txtAdminPassword.Location.X, txtAdminPassword.Location.Y + txtAdminPassword.Height + 5),
                Text = "Please enter a password between 8 and 20 characters long.",
                Visible = false
            };
            Controls.Add(passwordValidationLabel);
        }

        public event EventHandler AdminInfoUpdated;

        private void OnAdminInfoUpdated()
        {
            AdminInfoUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void btnUpdateAdmin_Click(object sender, EventArgs e)
        {
                        nameValidationLabel.Visible = false;
            usernameValidationLabel.Visible = false;
            emailValidationLabel.Visible = false;
            phoneValidationLabel.Visible = false;
            passwordValidationLabel.Visible = false;

            string newAdminName = txtAdminName.Text.Trim();
            string newAdminUsername = txtAdminUsername.Text.Trim();
            string newEmail = txtAdminEmail.Text.Trim();
            string newPhoneNumber = txtAdminPhoneNumber.Text.Trim();
            string newPassword = txtAdminPassword.Text;

            bool isValid = true;

            if (string.IsNullOrEmpty(newAdminName))
            {
                nameValidationLabel.Visible = true;
                isValid = false;
            }

            if (string.IsNullOrEmpty(newAdminUsername))
            {
                usernameValidationLabel.Visible = true;
                isValid = false;
            }

            if (string.IsNullOrEmpty(newEmail))
            {
                emailValidationLabel.Visible = true;
                isValid = false;
            }

            if (string.IsNullOrEmpty(newPhoneNumber))
            {
                phoneValidationLabel.Visible = true;
                isValid = false;
            }

            if (string.IsNullOrEmpty(newPassword))
            {
                passwordValidationLabel.Visible = true;
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(newAdminName, @"^[a-zA-Z0-9]{1,20}$"))
            {
                nameValidationLabel.Visible = true;
                ClearTextAndFocus(txtAdminName);
                return;
            }

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(newEmail, pattern))
            {
                emailValidationLabel.Visible = true;
                ClearTextAndFocus(txtAdminEmail);
                return;
            }

            if (!Regex.IsMatch(newPhoneNumber, @"^0\d{10}$"))
            {
                phoneValidationLabel.Visible = true;
                ClearTextAndFocus(txtAdminPhoneNumber);
                return;
            }

            if (newPassword.Length < 8 || newPassword.Length > 20)
            {
                passwordValidationLabel.Visible = true;
                ClearTextAndFocus(txtAdminPassword);
                return;
            }

            string connectionString = "Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_Admin;Password=1234admin;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE tbl_admin SET admin_name = @NewAdminName, admin_username = @NewAdminUsername, " +
                                   "admin_email = @NewEmail, admin_phone_number = @NewPhoneNumber, admin_password = @NewPassword " +
                                   "WHERE ID_Admin = @AdminID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NewAdminName", newAdminName);
                        command.Parameters.AddWithValue("@NewAdminUsername", newAdminUsername);
                        command.Parameters.AddWithValue("@NewEmail", newEmail);
                        command.Parameters.AddWithValue("@NewPhoneNumber", newPhoneNumber);
                        command.Parameters.AddWithValue("@NewPassword", newPassword);
                        command.Parameters.AddWithValue("@AdminID", adminID);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Admin information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            UpdateAdminInfoRequested?.Invoke(adminID, newAdminName, newAdminUsername, newPassword, newEmail, newPhoneNumber);
                            OnAdminInfoUpdated();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update admin information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearTextAndFocus(TextBox textBox)
        {
            textBox.Text = "";
            textBox.Focus();
        }

        private void btnClear_Admin_Click(object sender, EventArgs e)
        {
            txtAdminName.Text = "";
            txtAdminUsername.Text = "";
            txtAdminEmail.Text = "";
            txtAdminPhoneNumber.Text = "";
            txtAdminPassword.Text = "";
        }

        public delegate void UpdateAdminInfoHandler(string adminID, string newAdminName, string newAdminUsername, string newPassword, string newEmail, string newPhoneNumber);

        public event UpdateAdminInfoHandler UpdateAdminInfoRequested;

        private void txtAdminName_TextChanged(object sender, EventArgs e) { }

        private void txtAdminName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAdminEmail_TextChanged(object sender, EventArgs e) { }

        private void txtUserPassword_TextChanged(object sender, EventArgs e) { }

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

        private void txtAdminPassword_TextChanged(object sender, EventArgs e) { }

        private void txtAdminUsername_TextChanged(object sender, EventArgs e) { }
    }
}
