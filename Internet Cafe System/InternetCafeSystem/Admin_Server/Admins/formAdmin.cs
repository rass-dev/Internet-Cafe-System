using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace InternetCafe
{
    public partial class formAdmin : Form
    {
        private formAddAdmin addAdminForm;
        private formEditAdmin editAdminForm;

        public Dictionary<string, string> adminCredentials = new Dictionary<string, string>();

        SqlConnection connection = new SqlConnection("Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog = db_internet_cafe; User ID=svc_Admin;Password=1234admin;");


        public formAdmin()
        {
            InitializeComponent();
        }

        private void formAdmin_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            LoadAdminData();

            dataGridView_Members.Columns["ID_Admin"].HeaderText = "ID Admin";
            dataGridView_Members.Columns["admin_name"].HeaderText = "Admin Name";
            dataGridView_Members.Columns["admin_username"].HeaderText = "Username";
            dataGridView_Members.Columns["admin_email"].HeaderText = "Admin Email";
            dataGridView_Members.Columns["admin_phone_number"].HeaderText = "Phone Number";

            dataGridView_Members.Columns["admin_password"].Visible = false;

            dataGridView_Members.CellFormatting += dataGridView4_CellFormatting;

        }

        public void LoadAdminData()
        {

            try
            {
                connection.Open();
                string query = "SELECT * FROM tbl_admin";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        if (row[col] != null && row[col] != DBNull.Value)
                        {
                            row[col] = row[col].ToString().TrimEnd();
                        }
                    }
                }

                dataGridView_Members.DataSource = dataTable;

                dataGridView_Members.ReadOnly = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        public void btnAddAdmin_Click(object sender, EventArgs e)
        {
            if (addAdminForm == null || addAdminForm.IsDisposed)
            {
                addAdminForm = new formAddAdmin(this);
                addAdminForm.FormClosed += AddAdminForm_FormClosed;
                addAdminForm.MdiParent = this.MdiParent;
                addAdminForm.Dock = DockStyle.Fill;
                addAdminForm.Show();
            }
            else
            {
                addAdminForm.Activate();

                LoadAdminData();
            }
        }

        private void AddAdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            addAdminForm = null;
        }

        private void dataGridView_Members_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                dataGridView_Members.CurrentCell = dataGridView_Members.Rows[e.RowIndex].Cells[e.ColumnIndex];


                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void dataGridView4_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dataGridView_Members.Columns[e.ColumnIndex].Name == "admin_password" && e.Value != null)
            {

                e.Value = new string('*', e.Value.ToString().Length);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (dataGridView_Members.CurrentCell != null)
            {
                DataGridViewRow row = dataGridView_Members.Rows[dataGridView_Members.CurrentCell.RowIndex];
                string adminID = row.Cells["ID_Admin"].Value?.ToString();
                string adminName = row.Cells["admin_name"].Value?.ToString(); string adminUsername = row.Cells["admin_username"].Value?.ToString();
                string adminPhoneNumber = row.Cells["admin_phone_number"].Value?.ToString();
                string adminEmail = row.Cells["admin_email"].Value?.ToString();
                string adminPassword = row.Cells["admin_password"].Value?.ToString();

                editAdminForm = new formEditAdmin(this, adminID, adminName, adminUsername, adminPassword, adminEmail, adminPhoneNumber);
                editAdminForm.FormClosed += EditAdminForm_FormClosed;
                editAdminForm.MdiParent = this.MdiParent;
                editAdminForm.Dock = DockStyle.Fill;
                editAdminForm.UpdateAdminInfoRequested += EditAdminForm_UpdateAdminInfoRequested;
                editAdminForm.Show();
            }
            else
            {
                MessageBox.Show("Please select an admin to edit.");
            }
        }


        private void EditAdminForm_UpdateAdminInfoRequested(string adminID, string newAdminName, string newAdminUsername, string newPassword, string newEmail, string newPhoneNumber)
        {
            LoadAdminData();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (dataGridView_Members.CurrentCell != null)
            {
                string adminID = dataGridView_Members.Rows[dataGridView_Members.CurrentCell.RowIndex].Cells["ID_Admin"].Value?.ToString();


                if (adminID == "1")
                {
                    MessageBox.Show("The Main Admin cannot be deleted.");
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to delete this admin?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection("Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_Admin;Password=1234admin;"))
                        {
                            connection.Open();

                            string query = "DELETE FROM tbl_admin WHERE ID_Admin = @AdminID";
                            SqlCommand command = new SqlCommand(query, connection);

                            command.Parameters.AddWithValue("@AdminID", adminID);

                            command.ExecuteNonQuery();
                        }

                        dataGridView_Members.Rows.RemoveAt(dataGridView_Members.CurrentCell.RowIndex);

                        LoadAdminData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting admin: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an admin to delete.");
            }
        }

        private void EditAdminForm_UpdateAdminInfoRequested(string adminID, string newAdminName, string newPassword, string newEmail)
        {

            UpdateAdminInfo(adminID, newAdminName, newPassword, newEmail);
        }


        private void EditAdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            editAdminForm = null;
        }

        public void UpdateAdminInfo(string adminID, string newAdminName, string newPassword, string newEmail)
        {
            string connectionString = "Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_Admin;Password=1234admin;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE tbl_admin SET admin_username = @NewAdminName, admin_email = @NewEmail, admin_password = @NewPassword WHERE ID_Admin = @AdminID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NewAdminName", newAdminName);
                cmd.Parameters.AddWithValue("@NewEmail", newEmail);
                cmd.Parameters.AddWithValue("@NewPassword", newPassword);
                cmd.Parameters.AddWithValue("@AdminID", adminID);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
