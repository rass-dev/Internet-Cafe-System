using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternetCafe
{
    public partial class formAddMembers : Form
    {
        private formMembers membersForm;

        private Label usernameValidationLabel;
        private Label emailValidationLabel;
        private Label phoneValidationLabel;

        public formAddMembers(formMembers membersForm)
        {
            InitializeComponent();
            this.membersForm = membersForm;
        }

        private void formAddMembers_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            txtUsernameM.KeyPress += txtUsernameM_KeyPress;

                        usernameValidationLabel = new Label
            {
                AutoSize = true,
                ForeColor = Color.Red,
                Location = new Point(txtUsernameM.Location.X, txtUsernameM.Location.Y + txtUsernameM.Height + 5),
                Text = "Please enter a valid username (letters, numbers only, max length 20).",
                Visible = false
            };
            Controls.Add(usernameValidationLabel);

            emailValidationLabel = new Label
            {
                AutoSize = true,
                ForeColor = Color.Red,
                Location = new Point(txtUserEmailM.Location.X, txtUserEmailM.Location.Y + txtUserEmailM.Height + 5),
                Text = "Please enter a valid email address.",
                Visible = false
            };
            Controls.Add(emailValidationLabel);

            phoneValidationLabel = new Label
            {
                AutoSize = true,
                ForeColor = Color.Red,
                Location = new Point(txtUserPhoneNumber.Location.X, txtUserPhoneNumber.Location.Y + txtUserPhoneNumber.Height + 5),
                Text = "Please enter a valid phone number (starting with 0 and exactly 11 numbers).",
                Visible = false
            };
            Controls.Add(phoneValidationLabel);
        }

        private void btnClear_member_Click(object sender, EventArgs e)
        {
                        txtUsernameM.Text = "";
            txtUserEmailM.Text = "";
            txtUserPhoneNumber.Text = "";

                        usernameValidationLabel.Visible = false;
            emailValidationLabel.Visible = false;
            phoneValidationLabel.Visible = false;
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
                        usernameValidationLabel.Visible = false;
            emailValidationLabel.Visible = false;
            phoneValidationLabel.Visible = false;

                        string username = txtUsernameM.Text.Trim();
            string email = txtUserEmailM.Text.Trim();
            string phoneNumber = txtUserPhoneNumber.Text.Trim();
            string memberType = "Member";             string currentDate = DateTime.Now.ToString("MM/dd/yyyy"); 
                        bool isValid = true;

            if (string.IsNullOrEmpty(username))
            {
                usernameValidationLabel.Visible = true;
                isValid = false;
            }

            if (string.IsNullOrEmpty(email))
            {
                emailValidationLabel.Visible = true;
                isValid = false;
            }

            if (string.IsNullOrEmpty(phoneNumber))
            {
                phoneValidationLabel.Visible = true;
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

                        if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]{1,20}$"))
            {
                usernameValidationLabel.Visible = true;
                ClearTextAndFocus(txtUsernameM);
                return;
            }

                        if (!Regex.IsMatch(phoneNumber, @"^0\d{10}$"))
            {
                phoneValidationLabel.Visible = true;
                ClearTextAndFocus(txtUserPhoneNumber);
                return;
            }

                        string connectionString = "Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_Admin;Password=1234admin;";

                        string query = "INSERT INTO tbl_member (member_type, user_name, email, phone_number, date_of_membership) VALUES (@MemberType, @Username, @Email, @PhoneNumber, @DateOfMembership)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                                        using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MemberType", memberType);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@DateOfMembership", currentDate);

                                                int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Member added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        ClearInputFields();

                                                        this.membersForm.LoadMembersData();

                                                        this.membersForm.Show();

                            this.Hide();                         }
                        else
                        {
                            MessageBox.Show("Failed to add member.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

                private void ClearInputFields()
        {
            txtUsernameM.Text = "";
            txtUserEmailM.Text = "";
            txtUserPhoneNumber.Text = "";
        }

                private void ClearTextAndFocus(TextBox textBox)
        {
            textBox.Text = "";
            textBox.Focus();
        }

        private void txtUsernameM_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsernameM_KeyPress(object sender, KeyPressEventArgs e)
        {
                        if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                                e.Handled = true;
            }
        }

        private void txtUserEmailM_TextChanged(object sender, EventArgs e)
        {
                        string email = txtUserEmailM.Text;

                        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

                        if (Regex.IsMatch(email, pattern))
            {
                                                txtUserEmailM.BackColor = System.Drawing.Color.White;
            }
            else
            {
                                                txtUserEmailM.BackColor = System.Drawing.Color.LightPink;
            }
        }

        private void txtUserPasswordM_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserPhoneNumber_TextChanged(object sender, EventArgs e)
        {
                        string userPhoneNumber = txtUserPhoneNumber.Text;

                        userPhoneNumber = new string(userPhoneNumber.Where(char.IsDigit).ToArray());

                        if (userPhoneNumber.Length > 11)
            {
                                MessageBox.Show("Please use a valid phone number.", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                txtUserPhoneNumber.Text = "";
                return;
            }

                        txtUserPhoneNumber.Text = userPhoneNumber;
        }
    }
}
