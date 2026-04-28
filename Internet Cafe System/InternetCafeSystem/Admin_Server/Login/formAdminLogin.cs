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
using InternetCafe.Members;
//using InternetCafe.Client_Computer;
using System.Net;

namespace InternetCafe
{
    public partial class formAdminLogin : Form
    {
                public event EventHandler LoginSuccess;
        private Label validationLabel;         private Label passwordValidationLabel; 
        public formAdminLogin()
        {
            InitializeComponent();
                        validationLabel = new Label
            {
                AutoSize = true,
                ForeColor = Color.Red,
                Location = new Point(txtAdminUsername.Location.X, txtAdminUsername.Location.Y + txtAdminUsername.Height + 5)
            };

            Controls.Add(validationLabel);
            validationLabel.BringToFront();

            passwordValidationLabel = new Label
            {
                AutoSize = true,
                ForeColor = Color.Red,
                Location = new Point(txtAdminPassword.Location.X, txtAdminPassword.Location.Y + txtAdminPassword.Height + 5)
            };
            Controls.Add(passwordValidationLabel);
            passwordValidationLabel.BringToFront();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
                        bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtAdminUsername.Text))
            {
                validationLabel.Text = "Please enter username.";
                isValid = false;
            }
            else
            {
                validationLabel.Text = "";
            }

            if (string.IsNullOrWhiteSpace(txtAdminPassword.Text))
            {
                passwordValidationLabel.Text = "Please enter password.";
                isValid = false;
            }
            else
            {
                passwordValidationLabel.Text = "";
            }

                        if (isValid && LoginIsSuccessful())
            {
                                OnLoginSuccess(EventArgs.Empty);
                this.Close();
            }
        }

        private bool LoginIsSuccessful()
        {
            string connectionString = "Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_Admin;Password=1234admin;";
            string username = txtAdminUsername.Text.Trim();
            string password = txtAdminPassword.Text.Trim();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                                string query = "SELECT COUNT(*) FROM tbl_admin WHERE admin_username COLLATE Latin1_General_CS_AS = @Username AND admin_password COLLATE Latin1_General_CS_AS = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                int count = (int)command.ExecuteScalar(); 
                                if (count > 0)
                {
                    return true;
                }
                else
                {
                                        txtAdminUsername.Clear();
                    txtAdminPassword.Clear();

                    MessageBox.Show("Incorrect username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

                protected virtual void OnLoginSuccess(EventArgs e)
        {
                        LoginSuccess?.Invoke(this, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void formAdminLogin_Load(object sender, EventArgs e)
        {
            ControlBox = false;
                        txtAdminPassword.PasswordChar = '*';
        }

        private void cbkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkShowPassword.Checked)
            {
                                txtAdminPassword.PasswordChar = '\0';             }
            else
            {
                                txtAdminPassword.PasswordChar = '*';
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtAdminUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
