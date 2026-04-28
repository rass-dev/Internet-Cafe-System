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


namespace InternetCafe.Members
{
    public partial class formAdminRegister : Form
    {
        // Define your connection string
        private string connectionString = "Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_Admin;Password=1234admin;";

        public formAdminRegister()
        {
            InitializeComponent();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Get the reference to the login form from Application.OpenForms
            formAdminLogin adminLoginForm = Application.OpenForms.OfType<formAdminLogin>().FirstOrDefault();

            // Check if the login form instance exists
            if (adminLoginForm != null)
            {
                // Show the existing login form
                adminLoginForm.Show();

                // Close the current form (formAdminRegister)
                this.Close();
            }
            else
            {
                // If the login form instance doesn't exist, create a new instance and show it
                adminLoginForm = new formAdminLogin();
                adminLoginForm.Show();

                // Close the current form (formAdminRegister)
                this.Close();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Retrieve admin details from the text boxes
            string adminName = txtAdminName.Text.Trim();
            string adminUsername = txtAdminUserName.Text.Trim();
            string adminEmail = txtAdminEmail.Text.Trim();
            string adminPhoneNumber = txtAdminPhoneNumber.Text.Trim();
            string adminPassword = txtAdminPassword.Text;

            // Validation for admin name (letters, numbers only, max length 20)
            if (!Regex.IsMatch(adminName, @"^[a-zA-Z0-9]{1,20}$"))
            {
                MessageBox.Show("Please enter a valid admin name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearTextAndFocus(txtAdminName);
                return;
            }

            // Validation for admin username (letters, numbers only, max length 20)
            if (!Regex.IsMatch(adminUsername, @"^[a-zA-Z0-9]{1,20}$"))
            {
                MessageBox.Show("Please enter a valid admin username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearTextAndFocus(txtAdminUserName);
                return;
            }

            // Validation for phone number (starts with 0, exactly 11 numbers)
            if (!Regex.IsMatch(adminPhoneNumber, @"^0\d{10}$"))
            {
                MessageBox.Show("Please enter a valid phone number (starting with 0 and exactly 11 numbers).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearTextAndFocus(txtAdminPhoneNumber);
                return;
            }

            // Validation for email
            if (!IsValidEmail(adminEmail))
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearTextAndFocus(txtAdminEmail);
                return;
            }

            // Validation for password (min 8 characters, max 20 characters)
            if (adminPassword.Length < 8 || adminPassword.Length > 20)
            {
                MessageBox.Show("Please enter a password. (min 8 characters, max 20 characters)");
                ClearTextBoxes();
                return;
            }

            // Check if any field is empty
            if (string.IsNullOrEmpty(adminName) || string.IsNullOrEmpty(adminUsername) ||
                string.IsNullOrEmpty(adminEmail) || string.IsNullOrEmpty(adminPhoneNumber) ||
                string.IsNullOrEmpty(adminPassword))
            {
                MessageBox.Show("Please fill in all fields.");
                ClearTextBoxes();
                return;
            }

            // Create a SQL connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define the SQL query to insert admin data
                string query = "INSERT INTO tbl_admin (admin_name, admin_username, admin_email, admin_phone_number, admin_password) " +
                               "VALUES (@AdminName, @AdminUsername, @AdminEmail, @AdminPhoneNumber, @AdminPassword)";

                // Create a SQL command with parameters
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.Add("@AdminName", SqlDbType.VarChar).Value = adminName;
                    command.Parameters.Add("@AdminUsername", SqlDbType.VarChar).Value = adminUsername;
                    command.Parameters.Add("@AdminEmail", SqlDbType.VarChar).Value = adminEmail;
                    command.Parameters.Add("@AdminPhoneNumber", SqlDbType.VarChar).Value = adminPhoneNumber;
                    command.Parameters.Add("@AdminPassword", SqlDbType.VarChar).Value = adminPassword;

                    try
                    {
                        // Open the database connection
                        connection.Open();

                        // Execute the SQL command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Admin registered successfully.");
                            // Optionally, clear the text boxes after successful registration
                            ClearTextBoxes();
                        }
                        else
                        {
                            MessageBox.Show("Registration failed.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }


        // Method to validate email address
        private bool IsValidEmail(string email)
        {
            // Implement your email validation logic here
            // You can use regex or other methods to validate email format
            // For simplicity, you can check if the email contains "@" and "."
            return email.Contains("@") && email.Contains(".");
        }

        // Method to clear text in the specified textbox and set focus to it
        private void ClearTextAndFocus(TextBox textBox)
        {
            textBox.Text = "";
            textBox.Focus();
        }

        // Clear all text boxes
        private void ClearTextBoxes()
        {
            txtAdminName.Clear();
            txtAdminUserName.Clear();
            txtAdminEmail.Clear();
            txtAdminPhoneNumber.Clear();
            txtAdminPassword.Clear();
        }

        private void txtAdminPhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }


        private void txtAdminPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a digit and not a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press event
                e.Handled = true;
            }
        }


        private void lblLogin_Click(object sender, EventArgs e)
        {
            // Get the reference to the login form from Application.OpenForms
            formAdminLogin adminLoginForm = Application.OpenForms.OfType<formAdminLogin>().FirstOrDefault();

            // Check if the login form instance exists
            if (adminLoginForm != null)
            {
                // Show the existing login form
                adminLoginForm.Show();

                // Close the current form (formAdminRegister)
                this.Close();
            }
            else
            {
                // If the login form instance doesn't exist, create a new instance and show it
                adminLoginForm = new formAdminLogin();
                adminLoginForm.Show();

                // Close the current form (formAdminRegister)
                this.Close();
            }
        }

        private void cbkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkShowPassword.Checked)
            {
                // If checkbox is checked, show password as plaintext
                txtAdminPassword.PasswordChar = '\0'; // '\0' represents no masking
            }
            else
            {
                // If checkbox is unchecked, mask password with asterisks
                txtAdminPassword.PasswordChar = '*';
            }
        }

        private void formAdminRegister_Load(object sender, EventArgs e)
        {
            // Mask the password textbox with asterisks when the form loads
            txtAdminPassword.PasswordChar = '*';

            txtAdminName.KeyPress += txtAdminName_KeyPress;

            txtAdminPhoneNumber.KeyPress += txtAdminPhoneNumber_KeyPress;
        }

        private void txtAdminName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAdminName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a letter and not a control key (like backspace)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press event
                e.Handled = true;
            }
        }



    }
}

