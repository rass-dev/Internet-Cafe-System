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

namespace InternetCafe.Computers.Computer_View.Computer_Session.Saved_Time
{
    public partial class formContinueSaveTime : Form
    {
        private string connectionString = "Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_Admin;Password=1234admin;";
        private string sessionId;
        private string computerNumber;
        private string memberId;
        private string dateStart;
        private string timeIn;
        private string timeOut;
        private string timeRemaining;
        private string totalPay;
        private string statusPayment;

        private Timer timer;

        public formContinueSaveTime(string sessionId, string computerNumber, string memberId, string dateStart, string timeIn, string timeOut, string timeRemaining, string totalPay, string statusPayment)
        {
            InitializeComponent();


            this.computerNumber = computerNumber;
            this.memberId = memberId;
            this.dateStart = dateStart;
            this.timeIn = timeIn;
            this.timeOut = timeOut;
            this.totalPay = totalPay;
            this.statusPayment = statusPayment;

            this.sessionId = sessionId;
            this.timeRemaining = timeRemaining;

            timer = new Timer();
            timer.Interval = 1000; timer.Tick += Timer_Tick;
        }

        private void formContinueSaveTime_Load(object sender, EventArgs e)
        {
            StopTimer();
            LoadComputerNumbers();
            LoadClientNames();

            dataGridView_Member_Saved_Time.MultiSelect = true;

            dataGridView_Member_Saved_Time.CellContentClick += dataGridView_Member_Saved_Time_CellContentClick;

            cmbComputerNumber.KeyPress += cmbComputerNumber_KeyPress;

            cmbClientName.KeyPress += cmbClientName_KeyPress;

            if (dataGridView_Member_Saved_Time.Columns.Contains("Member ID"))
            {
                dataGridView_Member_Saved_Time.Columns["Member ID"].Visible = false;
            }

            if (dataGridView_Member_Saved_Time.Columns.Contains("Session_ID"))
            {
                dataGridView_Member_Saved_Time.Columns["Session_ID"].Visible = false;
            }

            dataGridView_Member_Saved_Time.ReadOnly = true;

            dataGridView_Member_Saved_Time.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dataGridView_Member_Saved_Time.ColumnHeadersHeightSizeModeChanged += DataGridView_Member_Saved_Time_ColumnHeadersHeightSizeModeChanged;

            SetWrapMode();

        }


        private void SetWrapMode()
        {
            foreach (DataGridViewColumn column in dataGridView_Member_Saved_Time.Columns)
            {
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                column.DefaultCellStyle.Font = new Font("Arial", 10);
                column.DefaultCellStyle.Padding = new Padding(5, 10, 5, 10);
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            }

            dataGridView_Member_Saved_Time.ColumnHeadersHeight = 50; dataGridView_Member_Saved_Time.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void DataGridView_Member_Saved_Time_ColumnHeadersHeightSizeModeChanged(object sender, EventArgs e)
        {
            dataGridView_Member_Saved_Time.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }


        private void StartTimer()
        {
            timer.Start();
        }

        private void StopTimer()
        {
            timer.Stop();
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(timeRemaining))
                {
                    TimeSpan remaining = TimeSpan.Parse(timeRemaining);
                    remaining = remaining.Subtract(TimeSpan.FromSeconds(1));
                    timeRemaining = remaining.ToString(@"hh\:mm\:ss");
                    UpdateTimeRemainingInDatabase(sessionId, timeRemaining);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating time remaining: " + ex.Message);
            }
        }


        private void UpdateTimeRemainingInDatabase(string sessionId, string timeRemaining)
        {
            try
            {
                string query = "UPDATE tbl_saved_time SET Time_Remaining = @TimeRemaining WHERE Session_ID = @SessionId";
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@TimeRemaining", timeRemaining);
                    command.Parameters.AddWithValue("@SessionId", sessionId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating time remaining in database: " + ex.Message);
            }
        }



        private void btnReturn_Click(object sender, EventArgs e)
        {

            this.Close();
        }


        private void LoadComputerNumbers()
        {
            cmbComputerNumber.Items.Clear(); string query = "SELECT DISTINCT Computer_Number FROM tbl_session"; using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbComputerNumber.Items.Add(reader["Computer_Number"].ToString());
                    }
                }
            }
        }

        private void LoadClientNames()
        {
            string query = "SELECT DISTINCT tbl_saved_time.Member_ID, RTRIM(tbl_member.user_name) AS user_name " +
                           "FROM tbl_saved_time " +
                           "INNER JOIN tbl_member ON tbl_saved_time.Member_ID = tbl_member.ID";
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Member_ID"); dataTable.Columns.Add("user_name");
                    while (reader.Read())
                    {
                        dataTable.Rows.Add(reader["Member_ID"], reader["user_name"]);
                    }

                    cmbClientName.DataSource = dataTable;
                    cmbClientName.DisplayMember = "user_name"; cmbClientName.ValueMember = "Member_ID";
                }
            }
        }

        private void cmbClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientName.SelectedItem is DataRowView selectedRow)
            {
                memberId = selectedRow["Member_ID"].ToString(); DisplaySessionDetails(memberId);
            }
        }


        private void cmbComputerNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbClientName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void DisplaySessionDetails(string memberId)
        {
            if (!string.IsNullOrEmpty(memberId))
            {
                string query = "SELECT Session_ID, Member_ID, Date_Start, Time_Remaining, Total_Pay, Payment_Status FROM tbl_saved_time WHERE Member_ID = @MemberId";
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MemberId", memberId);
                    connection.Open();

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Session_ID");
                    dataTable.Columns.Add("Member ID");
                    dataTable.Columns.Add("Date Start");
                    dataTable.Columns.Add("Time Remaining");
                    dataTable.Columns.Add("Total Pay");
                    dataTable.Columns.Add("Payment Status");
                    dataTable.Columns.Add("Use Time Remaining", typeof(bool));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataTable.Rows.Add(reader["Session_ID"], reader["Member_ID"], reader["Date_Start"], reader["Time_Remaining"], reader["Total_Pay"], reader["Payment_Status"], false);
                        }
                    }

                    dataGridView_Member_Saved_Time.DataSource = dataTable;

                    if (dataTable.Rows.Count == 1 && (bool)dataTable.Rows[0]["Use Time Remaining"])
                    {
                        timeRemaining = dataTable.Rows[0]["Time Remaining"].ToString();
                        sessionId = dataTable.Rows[0]["Session_ID"].ToString();
                    }
                }
            }
        }


        private void dataGridView_Member_Saved_Time_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dataGridView_Member_Saved_Time.Columns[e.ColumnIndex].Name == "Use Time Remaining" && e.RowIndex >= 0)
            {
                dataGridView_Member_Saved_Time.Rows[e.RowIndex].Cells["Use Time Remaining"].Value = !(bool)dataGridView_Member_Saved_Time.Rows[e.RowIndex].Cells["Use Time Remaining"].Value;

                DataGridViewRow selectedRow = dataGridView_Member_Saved_Time.Rows[e.RowIndex];

                string selectedTimeRemaining = selectedRow.Cells["Time Remaining"].Value.ToString();

                string sessionId = selectedRow.Cells["Session_ID"].Value.ToString();

                timeRemaining = selectedTimeRemaining;

                this.sessionId = sessionId;

                selectedRow.Selected = true;
            }
        }



        private void btnStartNewSession_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbComputerNumber.Text) && !string.IsNullOrEmpty(cmbClientName.Text))
            {
                cmbComputerNumber.SelectedItem = cmbComputerNumber.SelectedItem ?? cmbComputerNumber.Items[0]; cmbClientName.SelectedItem = cmbClientName.SelectedItem ?? cmbClientName.Items[0]; StartNewSession();
                StartTimer();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a computer number and a member ID to start a new session.");
            }
        }

        private void StartNewSession()
        {
            try
            {
                if (dataGridView_Member_Saved_Time.SelectedRows.Count > 0)
                {
                    string selectedSessionId = dataGridView_Member_Saved_Time.SelectedRows[0].Cells["Session_ID"].Value.ToString();

                    GetSessionDetails(selectedSessionId, out TimeSpan timeRemaining, out string totalPay, out string paymentStatus);

                    UpdateSession(computerNumber, memberId, timeRemaining, totalPay, paymentStatus);

                    MessageBox.Show("New session started successfully.");
                }
                else
                {
                    MessageBox.Show("Please select a session to start a new session.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error starting new session: " + ex.Message);
            }
        }

        private void GetSessionDetails(string sessionId, out TimeSpan timeRemaining, out string totalPay, out string paymentStatus)
        {
            timeRemaining = TimeSpan.Zero;
            totalPay = "0";
            paymentStatus = "Unpaid";

            try
            {
                string query = "SELECT Time_Remaining, Total_Pay, Payment_Status FROM tbl_saved_time WHERE Session_ID = @SessionId";
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SessionId", sessionId);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (TimeSpan.TryParse(reader["Time_Remaining"].ToString(), out timeRemaining))
                            {
                                totalPay = reader["Total_Pay"].ToString();
                                paymentStatus = reader["Payment_Status"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving session details: " + ex.Message);
            }
        }

        private void UpdateSession(string computerNumber, string memberId, TimeSpan timeRemaining, string totalPay, string paymentStatus)
        {
            DateTime currentTime = DateTime.Now;
            DateTime timeIn = currentTime;
            DateTime timeOut = currentTime.Add(timeRemaining);

            TimeSpan remainingTime = timeOut - currentTime;

            string query = "UPDATE tbl_session SET " +
                           "Member_ID = @MemberId, " +
                           "Date_Start = @DateStart, " +
                           "Time_In = @TimeIn, " +
                           "Time_Out = @TimeOut, " +
                           "Time_Remaining = @TimeRemaining, " +
                           "Total_Pay = @TotalPay, " +
                           "Payment_Status = @PaymentStatus " +
                           "WHERE Computer_Number = @ComputerNumber";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@MemberId", memberId);
                command.Parameters.AddWithValue("@DateStart", currentTime); command.Parameters.AddWithValue("@TimeIn", timeIn.ToString("HH:mm:ss")); command.Parameters.AddWithValue("@TimeOut", timeOut.ToString("HH:mm:ss")); command.Parameters.AddWithValue("@TimeRemaining", remainingTime.ToString(@"hh\:mm\:ss")); command.Parameters.AddWithValue("@TotalPay", totalPay); command.Parameters.AddWithValue("@PaymentStatus", paymentStatus); command.Parameters.AddWithValue("@ComputerNumber", computerNumber);
                command.ExecuteNonQuery();
            }

            UpdateTimeRemainingInSavedTime(memberId, remainingTime);
        }

        private void UpdateTimeRemainingInSavedTime(string memberId, TimeSpan remainingTime)
        {
            string query = "UPDATE tbl_saved_time SET Time_Remaining = @TimeRemaining WHERE Member_ID = @MemberId";
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@TimeRemaining", remainingTime.ToString(@"hh\:mm\:ss"));
                command.Parameters.AddWithValue("@MemberId", memberId);
                command.ExecuteNonQuery();
            }
        }



    }
}
