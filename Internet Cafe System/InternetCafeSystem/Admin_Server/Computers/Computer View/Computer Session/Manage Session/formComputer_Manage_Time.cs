using InternetCafe.Computers.Computer_View;
using InternetCafe.Computers.Computer_View.Computer_Session.Custom_Pay_Rate;
using InternetCafe.Computers.Computer_View.Computer_Session.Saved_Time;
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
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace InternetCafe
{
    public partial class formComputer_Manage_Time : Form
    {
        private string connectionString = "Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_Admin;Password=1234admin;";
        private formMembers membersForm;
        private formManagePC managePCForm;
        private Timer timer = new Timer();

        private bool isTimerPaused = false;

        private TcpListener serverListener;

        public formComputer_Manage_Time(formMembers membersForm, formManagePC managePCForm, Dictionary<int, bool> pauseStates)
        {
            InitializeComponent();
            this.membersForm = membersForm;
            this.managePCForm = managePCForm;

            timer.Interval = 1000; timer.Tick += Timer_Tick;

            foreach (var kvp in pauseStates)
            {
                timerPauseStates[kvp.Key] = kvp.Value;
            }

            UpdateAllSessions();


        }

        private void formComputer_Manage_Time_Load(object sender, EventArgs e)
        {
            LoadData();

            timer.Start();

            UpdateTimer();

            UpdateAllSessions();


            dataGridView_New_Session.ReadOnly = true;

            dataGridView_New_Session.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dataGridView_New_Session.ColumnHeadersHeightSizeModeChanged += DataGridView_New_Session_ColumnHeadersHeightSizeModeChanged;

            SetWrapMode();
        }

        private void SetWrapMode()
        {
            foreach (DataGridViewColumn column in dataGridView_New_Session.Columns)
            {
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                column.DefaultCellStyle.Font = new Font("Arial", 10);
                column.DefaultCellStyle.Padding = new Padding(5, 10, 5, 10);
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            }

            dataGridView_New_Session.ColumnHeadersHeight = 50; dataGridView_New_Session.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void DataGridView_New_Session_ColumnHeadersHeightSizeModeChanged(object sender, EventArgs e)
        {
            dataGridView_New_Session.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        private void UpdateAllSessions()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE tbl_session
                         SET Time_In = NULL,
                             Time_Out = NULL,
                             Time_Remaining = '00:00:00',
                             Total_Pay = 0.00,
                             Payment_Status = NULL,
                             Member_ID = NULL,
                             Date_Start = NULL";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    foreach (DataGridViewRow row in dataGridView_New_Session.Rows)
                    {
                        int sessionId = Convert.ToInt32(row.Cells["Session_ID"].Value);
                        string timeRemaining = row.Cells["Time_Remaining"].Value?.ToString();
                        string memberId = row.Cells["Member_ID"].Value?.ToString();

                        if (!timerPauseStates.ContainsKey(sessionId) || !timerPauseStates[sessionId])
                        {
                            if (!string.IsNullOrEmpty(timeRemaining))
                            {
                                TimeSpan remainingTime = TimeSpan.Parse(timeRemaining);
                                if (remainingTime.TotalSeconds > 0)
                                {
                                    remainingTime = remainingTime.Subtract(TimeSpan.FromSeconds(1));
                                    string updateQuery = "UPDATE tbl_session SET Time_Remaining = @Time_Remaining WHERE Session_ID = @Session_ID";
                                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                                    updateCommand.Parameters.AddWithValue("@Time_Remaining", remainingTime.ToString(@"hh\:mm\:ss"));
                                    updateCommand.Parameters.AddWithValue("@Session_ID", sessionId);
                                    updateCommand.ExecuteNonQuery();

                                    row.Cells["Time_Remaining"].Value = remainingTime.ToString(@"hh\:mm\:ss");

                                    if (remainingTime.TotalSeconds <= 0 && !string.IsNullOrEmpty(memberId))
                                    {
                                        row.Cells["Time_Remaining"].Value = "00:00:00";

                                        string computerNumber = row.Cells["Computer_Number"].Value?.ToString();

                                        string clientIpAddress = GetComputerIPAddress(computerNumber);

                                        ExecuteCommand($"shutdown /s /m \\\\{clientIpAddress} /t 5 /c \"Time out. Thank you\" /d p:4:1");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating time remaining: " + ex.Message);
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

        private string GetComputerIPAddress(string computerNumber)
        {
            string ipAddress = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT LAN_Port_No FROM tbl_computer WHERE Computer_Number = @Computer_Number";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Computer_Number", computerNumber);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        ipAddress = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving IP address: " + ex.Message);
            }
            return ipAddress;
        }


        private void UpdateTimer()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (DataGridViewRow row in dataGridView_New_Session.Rows)
                    {
                        int sessionId = Convert.ToInt32(row.Cells["Session_ID"].Value);
                        string timeRemaining = row.Cells["Time_Remaining"].Value?.ToString();
                        if (!string.IsNullOrEmpty(timeRemaining))
                        {
                            TimeSpan remainingTime = TimeSpan.Parse(timeRemaining);
                            if (remainingTime.TotalSeconds > 0)
                            {
                                remainingTime = remainingTime.Subtract(TimeSpan.FromSeconds(1));
                                string selectQuery = "SELECT Time_Remaining FROM tbl_session WHERE Session_ID = @Session_ID";
                                SqlCommand command = new SqlCommand(selectQuery, connection);
                                command.Parameters.AddWithValue("@Session_ID", sessionId);
                                object updatedTimeRemainingObj = command.ExecuteScalar();
                                if (updatedTimeRemainingObj != null && updatedTimeRemainingObj != DBNull.Value)
                                {
                                    TimeSpan updatedTimeRemaining = TimeSpan.Parse(updatedTimeRemainingObj.ToString());

                                    string updateQuery = "UPDATE tbl_session SET Time_Remaining = @Time_Remaining WHERE Session_ID = @Session_ID";
                                    command = new SqlCommand(updateQuery, connection);
                                    command.Parameters.AddWithValue("@Time_Remaining", updatedTimeRemaining.ToString(@"hh\:mm\:ss"));
                                    command.Parameters.AddWithValue("@Session_ID", sessionId);
                                    command.ExecuteNonQuery();

                                    dataGridView_New_Session.Rows[row.Index].Cells["Time_Remaining"].Value = updatedTimeRemaining.ToString(@"hh\:mm\:ss");

                                    if (updatedTimeRemaining.TotalSeconds <= 0)
                                    {
                                        dataGridView_New_Session.Rows[row.Index].Cells["Time_Remaining"].Value = "00:00:00";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating time remaining: " + ex.Message);
            }
        }

        public void LoadData()
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
        SELECT
            s.Session_ID,
            s.Computer_Number, 
            m.user_name AS Name, 
            s.Date_Start, 
            s.Time_In, 
            s.Time_Out, 
            s.Time_Remaining, 
            s.Total_Pay, 
            s.Payment_Status,
            s.Member_ID
        FROM tbl_session s 
        LEFT JOIN tbl_member m ON s.Member_ID = m.ID
        INNER JOIN tbl_computer c ON s.Computer_Number = c.Computer_Number
        WHERE c.System_Working = 'Working'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView_New_Session.DataSource = dataTable;

                    dataGridView_New_Session.Columns["Session_ID"].Visible = false;

                    dataGridView_New_Session.Columns["Member_ID"].Visible = false;
                    dataGridView_New_Session.Columns["Session_ID"].ReadOnly = true;
                    dataGridView_New_Session.Columns["Date_Start"].ReadOnly = true;
                    dataGridView_New_Session.Columns["Time_In"].ReadOnly = true;
                    dataGridView_New_Session.Columns["Time_Out"].ReadOnly = true;
                    dataGridView_New_Session.Columns["Time_Remaining"].ReadOnly = true;
                    dataGridView_New_Session.Columns["Total_Pay"].ReadOnly = true;
                    dataGridView_New_Session.Columns["Payment_Status"].ReadOnly = true;
                    dataGridView_New_Session.Columns["Session_ID"].DefaultCellStyle.NullValue = DBNull.Value;
                    dataGridView_New_Session.Columns["Computer_Number"].HeaderText = "Computer Number";
                    dataGridView_New_Session.Columns["Name"].HeaderText = "Name";
                    dataGridView_New_Session.Columns["Date_Start"].HeaderText = "Date Start";
                    dataGridView_New_Session.Columns["Time_In"].HeaderText = "Time In";
                    dataGridView_New_Session.Columns["Time_Out"].HeaderText = "Time Out";
                    dataGridView_New_Session.Columns["Time_Remaining"].HeaderText = "Time Remaining";
                    dataGridView_New_Session.Columns["Total_Pay"].HeaderText = "Total Pay";
                    dataGridView_New_Session.Columns["Payment_Status"].HeaderText = "Status Payment";

                    foreach (DataGridViewColumn column in dataGridView_New_Session.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
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

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnExtendTimeForm_Click(object sender, EventArgs e)
        {
            if (dataGridView_New_Session.CurrentCell != null)
            {
                DataGridViewRow row = dataGridView_New_Session.Rows[dataGridView_New_Session.CurrentCell.RowIndex];
                int sessionId = Convert.ToInt32(row.Cells["Session_ID"].Value);
                string computerNumber = row.Cells["Computer_Number"].Value?.ToString();
                string memberId = row.Cells["Member_ID"].Value?.ToString();
                string timeRemainingStr = row.Cells["Time_Remaining"].Value?.ToString();
                string timeOutStr = row.Cells["Time_Out"].Value?.ToString();

                if (!string.IsNullOrEmpty(memberId))
                {

                    TimeSpan timeRemaining = TimeSpan.Parse(timeRemainingStr);
                    DateTime timeOut = DateTime.Parse(timeOutStr);

                    formComputer_Extend_Time extendTimeForm = new formComputer_Extend_Time(sessionId, computerNumber, memberId, timeRemaining, timeOut);
                    extendTimeForm.FormClosed += ExtendTimeForm_FormClosed; extendTimeForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Cannot extend the time for this session due to no client being available.");
                }
            }
            else
            {
                MessageBox.Show("Please Select PC to add time.");
            }
        }
        private void ExtendTimeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dataGridView_New_Session.CurrentCell != null)
            {
                DataGridViewRow row = dataGridView_New_Session.Rows[dataGridView_New_Session.CurrentCell.RowIndex];
                int sessionId = Convert.ToInt32(row.Cells["Session_ID"].Value);
                ToggleTimerPause(sessionId);
            }

            LoadData();

            timer.Start();

            UpdateTimer();
        }


        public Dictionary<int, bool> timerPauseStates = new Dictionary<int, bool>();

        private Dictionary<string, bool> computerPauseStates = new Dictionary<string, bool>();

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (dataGridView_New_Session.CurrentCell != null)
            {
                DataGridViewRow row = dataGridView_New_Session.Rows[dataGridView_New_Session.CurrentCell.RowIndex];
                int sessionId = Convert.ToInt32(row.Cells["Session_ID"].Value);
                string memberId = row.Cells["Member_ID"].Value?.ToString();

                ToggleTimerPause(sessionId);

                UpdatePauseButtonVisuals(sessionId);

                if (timerPauseStates[sessionId])
                {
                    string timeRemaining = GetRemainingTimeFromDatabase(sessionId);
                    row.Cells["Time_Remaining"].Value = timeRemaining;
                }
            }
            else
            {
                MessageBox.Show("Please select a session to pause/resume.");
            }

            dataGridView_New_Session.ClearSelection();
        }



        private string GetRemainingTimeFromDatabase(int sessionId)
        {
            string timeRemaining = "00:00:00";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Time_Remaining FROM tbl_session WHERE Session_ID = @Session_ID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Session_ID", sessionId);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        timeRemaining = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving remaining time: " + ex.Message);
            }

            return timeRemaining;
        }


        private void ToggleTimerPause(int sessionId)
        {
            if (timerPauseStates.ContainsKey(sessionId))
            {
                timerPauseStates[sessionId] = !timerPauseStates[sessionId];
            }
            else
            {
                timerPauseStates.Add(sessionId, true);
            }

            isTimerPaused = timerPauseStates.ContainsValue(true);
        }

        private void UpdatePauseButtonVisuals(int sessionId)
        {
            bool isPaused = timerPauseStates.ContainsKey(sessionId) ? timerPauseStates[sessionId] : false;
            if (isPaused)
            {
                btnPause.Text = "          RESUME";
                btnPause.BackColor = Color.SeaGreen;
            }
            else
            {
                btnPause.Text = "          PAUSE";
                btnPause.BackColor = Color.DarkGoldenrod;
            }
        }

        private void btnCancelSession_Click(object sender, EventArgs e)
        {
            if (dataGridView_New_Session.CurrentCell != null)
            {
                DataGridViewRow row = dataGridView_New_Session.Rows[dataGridView_New_Session.CurrentCell.RowIndex];
                int sessionId = Convert.ToInt32(row.Cells["Session_ID"].Value);
                string memberId = row.Cells["Member_ID"].Value?.ToString();

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        if (!string.IsNullOrEmpty(memberId))
                        {
                            string updateQuery = @"
                        UPDATE tbl_session 
                        SET Member_ID = NULL, 
                            Date_Start = NULL, 
                            Time_In = NULL, 
                            Time_Out = NULL, 
                            Time_Remaining = '00:00:00', 
                            Total_Pay = 0.00, 
                            Payment_Status = NULL 
                        WHERE Session_ID = @Session_ID";

                            SqlCommand command = new SqlCommand(updateQuery, connection);
                            command.Parameters.AddWithValue("@Session_ID", sessionId);
                            command.ExecuteNonQuery();

                            LoadData();

                            MessageBox.Show("Session canceled successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No session is to be Cancel.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error canceling session: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a session to cancel.");
            }
        }

        private void btnEditTime_Click(object sender, EventArgs e)
        {
            if (dataGridView_New_Session.CurrentCell != null)
            {
                DataGridViewRow row = dataGridView_New_Session.Rows[dataGridView_New_Session.CurrentCell.RowIndex];
                int sessionId = Convert.ToInt32(row.Cells["Session_ID"].Value);
                string computerNumber = row.Cells["Computer_Number"].Value?.ToString();
                string memberId = row.Cells["Member_ID"].Value?.ToString();
                string dateStart = row.Cells["Date_Start"].Value?.ToString();
                string timeIn = row.Cells["Time_In"].Value?.ToString();
                string timeOut = row.Cells["Time_Out"].Value?.ToString();
                string timeRemaining = row.Cells["Time_Remaining"].Value?.ToString();
                string totalPay = row.Cells["Total_Pay"].Value?.ToString();
                string statusPayment = row.Cells["Payment_Status"].Value?.ToString();

                formManagePC_Time_Amount editTimeForm = new formManagePC_Time_Amount(sessionId, computerNumber, memberId, dateStart, timeIn, timeOut, timeRemaining, totalPay, statusPayment, computerNumber);
                editTimeForm.FormClosed += EditTimeForm_FormClosed; editTimeForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select PC to add Client.");
            }
        }

        private void EditTimeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();

            timer?.Start();

            dataGridView_New_Session.ClearSelection();
        }

        private void btnSaveTime_Click(object sender, EventArgs e)
        {
            if (dataGridView_New_Session.CurrentCell != null)
            {
                DataGridViewRow row = dataGridView_New_Session.Rows[dataGridView_New_Session.CurrentCell.RowIndex];

                int sessionId = Convert.ToInt32(row.Cells["Session_ID"].Value);
                string computerNumber = row.Cells["Computer_Number"].Value?.ToString();
                string memberId = row.Cells["Member_ID"].Value?.ToString();
                string clientName = row.Cells["Name"].Value?.ToString();
                string dateStartStr = row.Cells["Date_Start"].Value?.ToString();
                string timeInStr = row.Cells["Time_In"].Value?.ToString();
                string timeOutStr = row.Cells["Time_Out"].Value?.ToString();
                string totalPay = row.Cells["Total_Pay"].Value?.ToString();
                string paymentStatus = row.Cells["Payment_Status"].Value?.ToString();

                if (paymentStatus != null && paymentStatus.ToLower() == "unpaid")
                {
                    MessageBox.Show("This session has an unpaid status and cannot be saved.");
                    return;
                }

                bool isMember = false;
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string checkMemberQuery = "SELECT COUNT(*) FROM tbl_member WHERE ID = @Member_ID AND Member_Type = 'Member'";
                        SqlCommand checkMemberCommand = new SqlCommand(checkMemberQuery, connection);
                        checkMemberCommand.Parameters.AddWithValue("@Member_ID", memberId);
                        isMember = (int)checkMemberCommand.ExecuteScalar() > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking member status: " + ex.Message);
                    return;
                }

                if (!isMember)
                {
                    MessageBox.Show("Only members can save time.");
                    return;
                }

                string timeRemaining = null;
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string timeRemainingQuery = "SELECT Time_Remaining FROM tbl_session WHERE Session_ID = @Session_ID";
                        SqlCommand timeRemainingCommand = new SqlCommand(timeRemainingQuery, connection);
                        timeRemainingCommand.Parameters.AddWithValue("@Session_ID", sessionId);
                        timeRemaining = timeRemainingCommand.ExecuteScalar()?.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving Time_Remaining: " + ex.Message);
                    return;
                }

                DateTime dateStart, timeIn, timeOut;
                if (!DateTime.TryParse(dateStartStr, out dateStart) ||
                    !DateTime.TryParse(timeInStr, out timeIn) ||
                    !DateTime.TryParse(timeOutStr, out timeOut))
                {
                    MessageBox.Show("Error parsing date and time values.");
                    return;
                }

                DialogResult result = MessageBox.Show($"Do you want to save the Time of {clientName} in Computer {computerNumber}?", "Save Time Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    dataGridView_New_Session.ClearSelection();

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string insertQuery = @"
     INSERT INTO tbl_saved_time (Computer_Number, Member_ID, Date_Start, Time_In, Time_Out, Time_Remaining, Total_Pay, Payment_Status)
     VALUES (@Computer_Number, @Member_ID, @Date_Start, @Time_In, @Time_Out, @Time_Remaining, @Total_Pay, @Payment_Status)";

                            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                            insertCommand.Parameters.AddWithValue("@Computer_Number", computerNumber);
                            insertCommand.Parameters.AddWithValue("@Member_ID", memberId);
                            insertCommand.Parameters.AddWithValue("@Date_Start", dateStart);
                            insertCommand.Parameters.AddWithValue("@Time_In", timeIn);
                            insertCommand.Parameters.AddWithValue("@Time_Out", timeOut);
                            insertCommand.Parameters.AddWithValue("@Time_Remaining", timeRemaining);
                            insertCommand.Parameters.AddWithValue("@Total_Pay", totalPay);
                            insertCommand.Parameters.AddWithValue("@Payment_Status", paymentStatus);
                            insertCommand.ExecuteNonQuery();

                            string clearQuery = @"
     UPDATE tbl_session
     SET Member_ID = NULL,
         Date_Start = NULL,
         Time_In = NULL,
         Time_Out = NULL,
         Time_Remaining = '00:00:00',
         Total_Pay = 0.00,
         Payment_Status = NULL
     WHERE Session_ID = @Session_ID";

                            SqlCommand clearCommand = new SqlCommand(clearQuery, connection);
                            clearCommand.Parameters.AddWithValue("@Session_ID", sessionId);
                            clearCommand.ExecuteNonQuery();

                            LoadData();

                            dataGridView_New_Session.ClearSelection();

                            MessageBox.Show("Session time saved successfully.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving session time: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a session to save its time.");
            }
        }


        private void btnPayStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_New_Session.CurrentCell != null)
                {
                    DataGridViewRow row = dataGridView_New_Session.Rows[dataGridView_New_Session.CurrentCell.RowIndex];
                    string paymentStatus = row.Cells["Payment_Status"].Value?.ToString();

                    if (!string.IsNullOrEmpty(paymentStatus))
                    {
                        formUpdatePaymentStatus updatePaymentStatusForm = new formUpdatePaymentStatus();

                        updatePaymentStatusForm.FormClosed += UpdatePaymentStatusForm_FormClosed;

                        updatePaymentStatusForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No payment status available for the selected session.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a session to update payment status.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening update payment status form: " + ex.Message);
            }
        }

        private void UpdatePaymentStatusForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();

            dataGridView_New_Session.ClearSelection();
        }

        private void btnUpdatePayRate_Click(object sender, EventArgs e)
        {
            formCustomPayRate customPayRateForm = new formCustomPayRate();

            customPayRateForm.FormClosed += CustomPayRateForm_FormClosed;

            customPayRateForm.ShowDialog();
        }

        private void CustomPayRateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();
        }

        private void btnContinueTime_Click(object sender, EventArgs e)
        {
            if (dataGridView_New_Session.CurrentCell != null)
            {
                DataGridViewRow row = dataGridView_New_Session.Rows[dataGridView_New_Session.CurrentCell.RowIndex];
                string sessionId = row.Cells["Session_ID"].Value?.ToString(); string computerNumber = row.Cells["Computer_Number"].Value?.ToString();
                string memberId = row.Cells["Member_ID"].Value?.ToString();
                string dateStart = row.Cells["Date_Start"].Value?.ToString();
                string timeIn = row.Cells["Time_In"].Value?.ToString();
                string timeOut = row.Cells["Time_Out"].Value?.ToString();
                string timeRemaining = row.Cells["Time_Remaining"].Value?.ToString();
                string totalPay = row.Cells["Total_Pay"].Value?.ToString();
                string statusPayment = row.Cells["Payment_Status"].Value?.ToString();

                if (!string.IsNullOrEmpty(sessionId))
                {
                    formContinueSaveTime continueTimeForm = new formContinueSaveTime(sessionId, computerNumber, memberId, dateStart, timeIn, timeOut, timeRemaining, totalPay, statusPayment);
                    continueTimeForm.FormClosed += ContinueTimeForm_FormClosed; continueTimeForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Session ID is not available for the selected session.");
                }
            }
            else
            {
                MessageBox.Show("Please Select PC to continue time.");
            }
        }

        private void ContinueTimeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();

            timer?.Start();

            dataGridView_New_Session.ClearSelection();
        }

        private void dataGridView_New_Session_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
