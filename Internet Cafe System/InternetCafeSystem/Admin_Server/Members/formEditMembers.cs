using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternetCafe
{
    public partial class formEditMembers : Form
    {
        private string memberID;
        private string memberType = "Member";         private string name;
        private string email;
        private string phoneNumber;
        private string password;
        private string dateOfMembership;

        private formMembers membersForm;

        private Label usernameValidationLabel;
        private Label emailValidationLabel;
        private Label phoneValidationLabel;
        private Label dateValidationLabel;

        public formEditMembers(formMembers parentForm, string memberID, string memberType, string name, string email, string phoneNumber, string dateOfMembership)
        {
            InitializeComponent();
            this.membersForm = parentForm;
            this.memberID = memberID;
            this.name = name;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.dateOfMembership = dateOfMembership;
            SetMemberInfo(memberID, name, email, phoneNumber, dateOfMembership);
        }

        private void SetMemberInfo(string memberID, string name, string email, string phoneNumber, string dateOfMembership)
        {
            txtUserName.Text = name;
            txtUserEmail.Text = email;
            txtUserPhoneNumber.Text = phoneNumber;
            txtDateOfMembership.Text = dateOfMembership;

            this.memberID = memberID;
            this.name = name;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.dateOfMembership = dateOfMembership;
        }

        private void formEditMembers_Load(object sender, EventArgs e)
        {
            txtUserName.KeyPress += txtUsername_KeyPress;

                        usernameValidationLabel = new Label
            {
                AutoSize = true,
                ForeColor = Color.Red,
                Location = new Point(txtUserName.Location.X, txtUserName.Location.Y + txtUserName.Height + 5),
                Text = "Please enter a valid username (letters, numbers only, max length 20).",
                Visible = false
            };
            Controls.Add(usernameValidationLabel);

            emailValidationLabel = new Label
            {
                AutoSize = true,
                ForeColor = Color.Red,
                Location = new Point(txtUserEmail.Location.X, txtUserEmail.Location.Y + txtUserEmail.Height + 5),
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

                        dateValidationLabel = new Label
            {
                AutoSize = true,
                ForeColor = Color.Red,
                Location = new Point(txtDateOfMembership.Location.X, txtDateOfMembership.Location.Y + txtDateOfMembership.Height + 5),
                Text = "Date of Membership is not editable.",
                Visible = false
            };
            Controls.Add(dateValidationLabel);

                        txtDateOfMembership.Enabled = false;
        }

        private void btnEditMember_Click(object sender, EventArgs e)
        {
                        usernameValidationLabel.Visible = false;
            emailValidationLabel.Visible = false;
            phoneValidationLabel.Visible = false;

                        string newName = txtUserName.Text.Trim();
            string newEmail = txtUserEmail.Text.Trim();
            string newPhoneNumber = txtUserPhoneNumber.Text.Trim();
            string newDateOfMembership = txtDateOfMembership.Text.Trim();

                        bool isValid = true;

            if (string.IsNullOrEmpty(newName))
            {
                usernameValidationLabel.Visible = true;
                isValid = false;
            }

            if (string.IsNullOrEmpty(newEmail) || !IsValidEmail(newEmail))
            {
                emailValidationLabel.Visible = true;
                isValid = false;
            }

            if (string.IsNullOrEmpty(newPhoneNumber) || !IsValidPhoneNumber(newPhoneNumber))
            {
                phoneValidationLabel.Visible = true;
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show("Please correct the errors and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

                        memberType = "Member";

                        UpdateMemberInfoRequested?.Invoke(memberID, memberType, newName, newEmail, newPhoneNumber, newDateOfMembership);
            this.Close();
        }

                private void ClearTextAndFocus(TextBox textBox)
        {
            textBox.Text = "";
            textBox.Focus();
        }

                private bool IsValidEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

                private bool IsValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^0\d{10}$");
        }

        private void btnClear_member_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtUserEmail.Text = "";
            txtUserPhoneNumber.Text = "";
            txtDateOfMembership.Text = "";

                        usernameValidationLabel.Visible = false;
            emailValidationLabel.Visible = false;
            phoneValidationLabel.Visible = false;
        }

        public delegate void UpdateMemberInfoHandler(string memberID, string memberType, string name, string email, string phoneNumber, string dateOfMembership);
        public event UpdateMemberInfoHandler UpdateMemberInfoRequested;

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
                        if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                                e.Handled = true;
            }
        }

        private void txtUserEmail_TextChanged(object sender, EventArgs e)
        {
                        string userEmail = txtUserEmail.Text.Replace(" ", "");
                        txtUserEmail.Text = userEmail;
        }

        private void txtUserPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            string userPhoneNumber = txtUserPhoneNumber.Text;

                        userPhoneNumber = new string(userPhoneNumber.Where(char.IsDigit).ToArray());

                        if (userPhoneNumber.Length > 11)
            {
                MessageBox.Show("Please use a valid phone number.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserPhoneNumber.Text = "";
                return;
            }

            txtUserPhoneNumber.Text = userPhoneNumber;
        }

        private void txtUserPassword_TextChanged(object sender, EventArgs e)
        {
        }
    }
}

