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

namespace InternetCafe
{
    public partial class formMembers : Form
    {
        private formAddMembers addMembersForm;
        private formEditMembers editMembersForm;

        SqlConnection connection = new SqlConnection("Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_admin;Password=1234admin;");

        public formMembers()
        {
            InitializeComponent();
        }

        private void formMembers_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            LoadMembersData();

                        dataGridView_Members.Columns["ID"].HeaderText = "ID";
            dataGridView_Members.Columns["member_type"].HeaderText = "Member Type";
            dataGridView_Members.Columns["user_name"].HeaderText = "Name";
            dataGridView_Members.Columns["email"].HeaderText = "Email";
            dataGridView_Members.Columns["phone_number"].HeaderText = "Phone Number";
            dataGridView_Members.Columns["date_of_membership"].HeaderText = "Date of Membership";

                        dataGridView_Members.CellFormatting += dataGridView_Members_CellFormatting;

            dataGridView_Members.ReadOnly = true;

            dataGridView_Members.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        
            dataGridView_Members.ColumnHeadersHeightSizeModeChanged += DataGridView_Members_ColumnHeadersHeightSizeModeChanged;

            SetWrapMode();

        }

        private void SetWrapMode()
        {
            foreach (DataGridViewColumn column in dataGridView_Members.Columns)
            {
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                column.DefaultCellStyle.Font = new Font("Arial", 10);                 column.DefaultCellStyle.Padding = new Padding(5, 10, 5, 10);             }

            dataGridView_Members.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }


        private void DataGridView_Members_ColumnHeadersHeightSizeModeChanged(object sender, EventArgs e)
        {
            dataGridView_Members.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }


        public void LoadMembersData()
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM tbl_member";
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

                                DataRow[] rowsToDelete = dataTable.Select("ID = 1");
                foreach (DataRow rowToDelete in rowsToDelete)
                {
                    dataTable.Rows.Remove(rowToDelete);
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


        public void btnAddMembers_Click(object sender, EventArgs e)
        {
                        if (addMembersForm == null || addMembersForm.IsDisposed)
            {
                                addMembersForm = new formAddMembers(this);
                addMembersForm.FormClosed += AddMembersForm_FormClosed;
                                addMembersForm.MdiParent = this.MdiParent;
                addMembersForm.Dock = DockStyle.Fill;
                addMembersForm.Show();
            }
            else
            {
                                addMembersForm.Activate();
            }
        }

        private void AddMembersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
                        addMembersForm = null;
            LoadMembersData();         }

        private void dataGridView_Members_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

                        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                                dataGridView_Members.CurrentCell = dataGridView_Members.Rows[e.RowIndex].Cells[e.ColumnIndex];

                                btnEdit_M.Enabled = true;
                btnDelete_M.Enabled = true;
            }
        }

        private void dataGridView_Members_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
                        if (dataGridView_Members.Columns[e.ColumnIndex].Name == "ID" && e.Value != null && e.Value.ToString() == "2")
            {
                                e.Value = 1;

                                dataGridView_Members.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
            }
        }


        private void btnDelete_M_Click(object sender, EventArgs e)
        {
                        if (dataGridView_Members.CurrentCell != null)
            {
                                string memberID = dataGridView_Members.Rows[dataGridView_Members.CurrentCell.RowIndex].Cells["ID"].Value?.ToString();

                                if (memberID == "1")
                {
                    MessageBox.Show("The first guest cannot be deleted.");
                    return;                 }

                                DialogResult result = MessageBox.Show("Are you sure you want to delete this member?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                                                using (SqlConnection connection = new SqlConnection("Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_Admin;Password=1234admin;"))
                        {
                            connection.Open();

                                                        SqlTransaction transaction = connection.BeginTransaction();

                                                        string deleteTotalPayQuery = "DELETE FROM tbl_total_pay WHERE Member_ID = @MemberID";
                            SqlCommand deleteTotalPayCommand = new SqlCommand(deleteTotalPayQuery, connection);
                            deleteTotalPayCommand.Parameters.AddWithValue("@MemberID", memberID);
                            deleteTotalPayCommand.Transaction = transaction;

                                                        string deleteSavedTimeQuery = "DELETE FROM tbl_saved_time WHERE Member_ID = @MemberID";
                            SqlCommand deleteSavedTimeCommand = new SqlCommand(deleteSavedTimeQuery, connection);
                            deleteSavedTimeCommand.Parameters.AddWithValue("@MemberID", memberID);
                            deleteSavedTimeCommand.Transaction = transaction;

                                                        string deleteMemberQuery = "DELETE FROM tbl_member WHERE ID = @MemberID";
                            SqlCommand deleteMemberCommand = new SqlCommand(deleteMemberQuery, connection);
                            deleteMemberCommand.Parameters.AddWithValue("@MemberID", memberID);
                            deleteMemberCommand.Transaction = transaction;

                                                        deleteTotalPayCommand.ExecuteNonQuery();
                            deleteSavedTimeCommand.ExecuteNonQuery();
                            deleteMemberCommand.ExecuteNonQuery();

                                                        transaction.Commit();
                        }

                                                dataGridView_Members.Rows.RemoveAt(dataGridView_Members.CurrentCell.RowIndex);

                                                LoadMembersData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting member: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a member to delete.");
            }
        }

        private void btnEdit_M_Click(object sender, EventArgs e)
        {
                        if (dataGridView_Members.CurrentCell != null)
            {
                                DataGridViewRow row = dataGridView_Members.Rows[dataGridView_Members.CurrentCell.RowIndex];
                string memberID = row.Cells["ID"].Value?.ToString();
                string memberType = row.Cells["member_type"].Value?.ToString();
                string name = row.Cells["user_name"].Value?.ToString();
                string email = row.Cells["email"].Value?.ToString();
                string phoneNumber = row.Cells["phone_number"].Value?.ToString();
                string dateOfMembership = row.Cells["date_of_membership"].Value?.ToString();

                                editMembersForm = new formEditMembers(this, memberID, memberType, name, email, phoneNumber, dateOfMembership);
                editMembersForm.FormClosed += EditMembersForm_FormClosed;
                editMembersForm.MdiParent = this.MdiParent;
                editMembersForm.Dock = DockStyle.Fill;
                editMembersForm.UpdateMemberInfoRequested += EditMembersForm_UpdateMemberInfoRequested;
                editMembersForm.Show();
            }
            else
            {
                MessageBox.Show("Please select a member to edit.");
            }
        }
        private void EditMembersForm_UpdateMemberInfoRequested(string memberID, string memberType, string name, string email, string phoneNumber, string dateOfMembership)
        {
                        UpdateMemberInfo(memberID, memberType, name, email, phoneNumber, dateOfMembership);
            LoadMembersData();         }

        private void EditMembersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
                        editMembersForm = null;
            LoadMembersData();         }

        public void UpdateMemberInfo(string memberID, string memberType, string name, string email, string phoneNumber, string dateOfMembership)
        {
                        string connectionString = "Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_Admin;Password=1234admin;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE tbl_member SET member_type = @MemberType, user_name = @Name, email = @Email, phone_number = @PhoneNumber, date_of_membership = @DateOfMembership WHERE ID = @MemberID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MemberType", memberType);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@DateOfMembership", dateOfMembership);
                cmd.Parameters.AddWithValue("@MemberID", memberID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
