using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace InternetCafe
{
    public partial class formManagePC : Form
    {
        private formAddComp addCompForm;
        private formEditPC editForm;
        public string connectionString = "Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_admin;Password=1234admin;";

        public string SelectedComputerNumber { get; set; }

        public string SelectedIPAddress { get; set; }

        public int GetTotalComputerCount()
        {
            return dataGridView_Manage_Computer.Rows.Count;
        }

        public formManagePC()
        {
            InitializeComponent();
        }

        private void formManagePC_Load(object sender, EventArgs e)
        {
            dataGridView_Manage_Computer.ReadOnly = true;

            this.ControlBox = false;
            LoadData();

            dataGridView_Manage_Computer.Columns["Computer_Number"].HeaderText = "Computer Number";
            dataGridView_Manage_Computer.Columns["LAN_Port_No"].HeaderText = "LAN Port No";
            dataGridView_Manage_Computer.Columns["System_Working"].HeaderText = "System Working";


            dataGridView_Manage_Computer.ReadOnly = true;

            dataGridView_Manage_Computer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dataGridView_Manage_Computer.ColumnHeadersHeightSizeModeChanged += DataGridView_Manage_Computer_ColumnHeadersHeightSizeModeChanged;

            SetWrapMode();
        }

        private void SetWrapMode()
        {
            foreach (DataGridViewColumn column in dataGridView_Manage_Computer.Columns)
            {
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                column.DefaultCellStyle.Font = new Font("Arial", 10); column.DefaultCellStyle.Padding = new Padding(5, 10, 5, 10);
            }

            dataGridView_Manage_Computer.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void DataGridView_Manage_Computer_ColumnHeadersHeightSizeModeChanged(object sender, EventArgs e)
        {
            dataGridView_Manage_Computer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        private void DataGridView_Members_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView_Manage_Computer.Columns)
            {
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            dataGridView_Manage_Computer.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView_Manage_Computer.AutoResizeColumnHeadersHeight();
        }


        public void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM tbl_computer";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView_Manage_Computer.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void btnAddComputer_Click(object sender, EventArgs e)
        {
            if (addCompForm == null || addCompForm.IsDisposed)
            {
                addCompForm = new formAddComp(this);
                addCompForm.FormClosed += AddCompForm_FormClosed;
                addCompForm.MdiParent = this.MdiParent;
                addCompForm.Dock = DockStyle.Fill;
                addCompForm.Show();
            }
            else
            {
                addCompForm.Activate();
            }
        }

        private void AddCompForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            addCompForm = null;
            LoadData();
        }

        private void dataGridView_Manage_Computer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnEdit_Computer_Click(object sender, EventArgs e)
        {
            if (dataGridView_Manage_Computer.CurrentCell != null)
            {
                DataGridViewRow row = dataGridView_Manage_Computer.Rows[dataGridView_Manage_Computer.CurrentCell.RowIndex];
                string computerNumber = row.Cells["Computer_Number"].Value?.ToString();
                string ipAddress = row.Cells["LAN_Port_No"].Value?.ToString();
                string systemWorking = row.Cells["System_Working"].Value?.ToString();

                formEditPC editForm = new formEditPC(computerNumber, ipAddress, systemWorking, this);
                editForm.FormClosed += EditForm_FormClosed;
                editForm.MdiParent = this.MdiParent;
                editForm.Dock = DockStyle.Fill;
                editForm.Show();
            }
            else
            {
                MessageBox.Show("Please select a computer to edit.");
            }
        }
        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            editForm = null;
            LoadData();
        }

        private void btnDelete_Computer_Click(object sender, EventArgs e)
        {
            if (dataGridView_Manage_Computer.CurrentCell != null)
            {
                string computerNumber = dataGridView_Manage_Computer.Rows[dataGridView_Manage_Computer.CurrentCell.RowIndex].Cells["Computer_Number"].Value?.ToString();

                if (HasAssociatedSessions(computerNumber))
                {
                    DialogResult result = MessageBox.Show("This computer has associated session records. Deleting it will also delete these sessions. Do you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                        return;
                }

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string deleteSessionsQuery = "DELETE FROM tbl_session WHERE Computer_Number = @ComputerNumber";
                        SqlCommand deleteSessionsCommand = new SqlCommand(deleteSessionsQuery, connection);
                        deleteSessionsCommand.Parameters.AddWithValue("@ComputerNumber", computerNumber);
                        deleteSessionsCommand.ExecuteNonQuery();

                        string deleteComputerQuery = "DELETE FROM tbl_computer WHERE Computer_Number = @ComputerNumber";
                        SqlCommand deleteComputerCommand = new SqlCommand(deleteComputerQuery, connection);
                        deleteComputerCommand.Parameters.AddWithValue("@ComputerNumber", computerNumber);
                        deleteComputerCommand.ExecuteNonQuery();
                    }

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting computer: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a computer to delete.");
            }
        }

        private bool HasAssociatedSessions(string computerNumber)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM tbl_session WHERE Computer_Number = @ComputerNumber";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ComputerNumber", computerNumber);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking associated sessions: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public bool ComputerNumberExists(string computerNumber)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM tbl_computer WHERE Computer_Number = @ComputerNumber";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ComputerNumber", computerNumber);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking computer number: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool IPAddressExists(string ipAddress)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM tbl_computer WHERE LAN_Port_No = @IPAddress";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IPAddress", ipAddress);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking IP address: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public string ConnectionString { get { return connectionString; } }

        public void ApplyChanges(string oldComputerNumber, string newComputerNumber, string newIPAddress, string newSystemWorking)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (ComputerNumberExists(newComputerNumber) && newComputerNumber != oldComputerNumber)
                    {
                        MessageBox.Show("Computer number already exists. Please choose a different one.");
                        return;
                    }

                    string updateQuery = "UPDATE tbl_computer SET Computer_Number = @NewComputerNumber, LAN_Port_No = @NewIPAddress, System_Working = @NewSystemWorking WHERE Computer_Number = @OldComputerNumber";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@NewComputerNumber", newComputerNumber);
                    updateCommand.Parameters.AddWithValue("@NewIPAddress", newIPAddress);
                    updateCommand.Parameters.AddWithValue("@NewSystemWorking", newSystemWorking);
                    updateCommand.Parameters.AddWithValue("@OldComputerNumber", oldComputerNumber);
                    updateCommand.ExecuteNonQuery();


                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating computer information: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {
            if (dataGridView_Manage_Computer.CurrentCell != null)
            {
                string computerNumber = dataGridView_Manage_Computer.Rows[dataGridView_Manage_Computer.CurrentCell.RowIndex].Cells["Computer_Number"].Value?.ToString();
                string ipAddress = dataGridView_Manage_Computer.Rows[dataGridView_Manage_Computer.CurrentCell.RowIndex].Cells["LAN_Port_No"].Value?.ToString();

                DialogResult result = MessageBox.Show($"Are you sure you want to shutdown computer {computerNumber}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ExecuteCommand($"shutdown /s /m \\\\{ipAddress} /t 2 /c \"Time out. Thank you\" /d p:4:1");
                }
            }
            else
            {
                MessageBox.Show("Please select a computer to shutdown.");
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            if (dataGridView_Manage_Computer.CurrentCell != null)
            {
                string computerNumber = dataGridView_Manage_Computer.Rows[dataGridView_Manage_Computer.CurrentCell.RowIndex].Cells["Computer_Number"].Value?.ToString();
                string ipAddress = dataGridView_Manage_Computer.Rows[dataGridView_Manage_Computer.CurrentCell.RowIndex].Cells["LAN_Port_No"].Value?.ToString();

                DialogResult result = MessageBox.Show($"Are you sure you want to restart computer {computerNumber}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ExecuteCommand($"shutdown /r /m \\\\{ipAddress} /t 2 /c \"Time out\" /d p:4:1");
                }
            }
            else
            {
                MessageBox.Show("Please select a computer to restart.");
            }
        }


        private void ExecuteCommand(string command)
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe")
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process proc = new Process
            {
                StartInfo = psi
            };

            proc.Start();
            proc.StandardInput.WriteLine(command);
            proc.StandardInput.Flush();
            proc.StandardInput.Close();
            proc.WaitForExit();
        }

    }
}
