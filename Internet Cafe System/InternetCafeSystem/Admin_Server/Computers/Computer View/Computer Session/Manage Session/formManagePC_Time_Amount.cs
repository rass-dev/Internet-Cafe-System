using InternetCafe.Computers.Computer_View.Computer_Session;
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
    public partial class formManagePC_Time_Amount : Form
    {
        private string ipAddress;
        public Timer timer;
        public Label timeLabel;
        private string clientName;
        private string memberType; private string name; private int sessionId;
        private string memberId; public string connectionString = "Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_admin;Password=1234admin;";
        private string selectedComputerNumber;
        private string computerNumber;
        private bool isMemberClient = false;
        public formManagePC_Time_Amount(int sessionId, string computerNumber, string memberId, string dateStart, string timeIn, string timeOut, string timeRemaining, string totalPay, string statusPayment, string clientName)
        {
            InitializeComponent();
            this.timeLabel = new Label(); this.sessionId = sessionId;
            this.memberId = memberId;
            this.memberId = memberId;
            this.computerNumber = computerNumber;

            this.selectedComputerNumber = computerNumber;
        }

        private void formManagePC_time_amount_Load(object sender, EventArgs e)
        {
            ckbMemberClient.Checked = false;
            cmbComputerNumber.KeyPress += cmbComputerNumber_KeyPress;

            cmbClientName.KeyPress += cmbClientName_KeyPress;

            cmbComputerNumber.Text = computerNumber;

            for (int i = 0; i < 24; i++)
            {
                cmbHours.Items.Add(i.ToString("00"));
            }
            for (int i = 0; i < 60; i++)
            {
                cmbMinutes.Items.Add(i.ToString("00"));
            }
            cmbHours.SelectedIndex = 0; cmbMinutes.SelectedIndex = 0;
            string query = "SELECT Computer_Number FROM tbl_computer";
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string computerNumber = reader["Computer_Number"].ToString();
                        cmbComputerNumber.Items.Add(computerNumber);
                    }
                }
            }

            PopulateClientNames();

            cmbClientName.SelectedIndexChanged -= cmbClientName_SelectedIndexChanged;

            cmbClientName.Enabled = false;

            cmbClientName.SelectedItem = "Guest";

            cmbClientName.SelectedIndexChanged += cmbClientName_SelectedIndexChanged;
        }


        private void btnStartTime_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedComputerNumber))
            {
                int hours = Convert.ToInt32(cmbHours.SelectedItem);
                int minutes = Convert.ToInt32(cmbMinutes.SelectedItem);

                TimeSpan totalTime = new TimeSpan(hours, minutes, 0);

                if (cmbClientName.SelectedItem != null)
                {
                    string selectedClientName = cmbClientName.SelectedItem.ToString().Trim();


                    int memberId = GetMemberId(selectedClientName);

                    DateTime startTime = DateTime.Now;

                    CreateNewSession(selectedComputerNumber, memberId, totalTime.ToString(), totalTime, startTime);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please select a client.");
                }
            }
            else
            {
                MessageBox.Show("Please select a computer number.");
            }
        }

        private bool CheckOngoingSession(string selectedComputerNumber)
        {
            string query = "SELECT COUNT(*) FROM tbl_session WHERE Computer_Number = @ComputerNumber AND Time_Out IS NULL";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@ComputerNumber", selectedComputerNumber);

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        private void ExtendSession(string selectedComputerNumber, int memberId, TimeSpan extensionTime, string timeIn, string formattedTimeOut, decimal currentTotalPay)
        {
            TimeSpan currentRemainingTime = GetCurrentRemainingTime(selectedComputerNumber);

            TimeSpan newRemainingTime = currentRemainingTime.Add(extensionTime);

            decimal hourlyRate = GetRateFromDatabase("Hour_");
            decimal minuteRate = GetRateFromDatabase("Minute_");

            decimal additionalPay = CalculateTotalPay(hourlyRate, minuteRate, extensionTime, memberId);

            UpdateSessionRecord(selectedComputerNumber, memberId, DateTime.Now, timeIn, formattedTimeOut, newRemainingTime.ToString(), currentTotalPay + additionalPay, "UNPAID");

            timeLabel.Text = newRemainingTime.ToString(@"hh\:mm\:ss");
        }

        decimal CalculateTotalPay(decimal hourlyRate, decimal minuteRate, TimeSpan totalTime, int memberId)
        {
            decimal discount = GetRateFromDatabase("Discount");

            decimal totalPay = 0;

            if (memberType == "Member")
            {
                double totalHours = totalTime.TotalHours;
                double totalMinutes = totalTime.TotalMinutes;

                decimal totalHourlyPay = Convert.ToDecimal(totalHours * (double)hourlyRate);
                decimal totalMinutePay = Convert.ToDecimal(totalMinutes * (double)minuteRate);

                totalPay = totalHourlyPay + totalMinutePay;

                totalPay -= discount;
            }
            else if (memberType == "Guest")
            {
                double totalHours = totalTime.TotalHours;
                double totalMinutes = totalTime.TotalMinutes;

                totalPay = Convert.ToDecimal(totalHours * (double)hourlyRate) + Convert.ToDecimal(totalMinutes * (double)minuteRate);
            }
            else
            {
                double totalHours = totalTime.TotalHours;
                double totalMinutes = totalTime.TotalMinutes;

                totalPay = Convert.ToDecimal(totalHours * (double)hourlyRate) + Convert.ToDecimal(totalMinutes * (double)minuteRate);
            }

            if (memberType == "Member")
            {
                totalPay -= discount;
            }

            return totalPay;
        }


        private TimeSpan GetCurrentRemainingTime(string selectedComputerNumber)
        {
            string query = "SELECT Time_Remaining FROM tbl_session WHERE Computer_Number = @ComputerNumber AND Time_Out IS NULL";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@ComputerNumber", selectedComputerNumber);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    string remainingTimeString = result.ToString();
                    return TimeSpan.Parse(remainingTimeString);
                }
                else
                {
                    return TimeSpan.Zero;
                }
            }
        }

        private void CreateNewSession(string selectedComputerNumber, int memberId, string totalTimeString, TimeSpan totalTime, DateTime startTime)
        {
            DateTime timeOut = startTime.Add(totalTime);

            string formattedTimeOut = timeOut.ToString("HH:mm:ss");

            string timeIn = startTime.ToString("HH:mm:ss");

            string memberType = GetMemberType(memberId);

            decimal hourlyRate = GetRateFromDatabase("Hours");
            decimal minuteRate = GetRateFromDatabase("Minute");
            decimal discount = GetRateFromDatabase("Discount");
            if (memberType == "Member")
            {
                hourlyRate -= discount;

                minuteRate -= (discount / 60);
            }

            decimal totalPay = CalculateTotalPay(hourlyRate, minuteRate, totalTime, memberId);




            bool hasOngoingSession = CheckOngoingSession(selectedComputerNumber);

            if (hasOngoingSession)
            {
                ExtendSession(selectedComputerNumber, memberId, totalTime, timeIn, formattedTimeOut, totalPay);
            }
            else
            {

                TimeSpan currentRemainingTime = GetCurrentRemainingTime(selectedComputerNumber);

                if (currentRemainingTime != TimeSpan.Zero)
                {
                    totalTime += currentRemainingTime;
                }

                UpdateSessionRecord(selectedComputerNumber, memberId, startTime, timeIn, formattedTimeOut, totalTime.ToString(@"hh\:mm\:ss"), totalPay, "UNPAID");

                timeLabel.Text = totalTime.ToString(@"hh\:mm\:ss");
            }
        }

        private string GetMemberType(int memberId)
        {
            string query = "SELECT member_type FROM tbl_member WHERE ID = @MemberID";
            string memberType = "";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@MemberID", memberId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        memberType = reader["member_type"].ToString().Trim();

                    }
                }
            }

            return memberType;
        }




        private decimal GetRateFromDatabase(string rateType)
        {
            string query = "SELECT Rate FROM tbl_custom_pay_rates WHERE RateType = @RateType";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@RateType", rateType);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    string rateString = result.ToString().Trim();
                    return Convert.ToDecimal(rateString);
                }
                else
                {
                    return 0;
                }
            }
        }

        private void UpdateSessionRecord(string selectedComputerNumber, int memberId, DateTime dateStart, string timeIn, string timeOut, string timeRemaining, decimal totalPay, string statusPayment)
        {
            string updateQuery = "UPDATE tbl_session SET Member_ID = @MemberID, Date_Start = @DateStart, Time_In = @TimeIn, Time_Out = @TimeOut, Time_Remaining = @TimeRemaining, Total_Pay = @TotalPay, Payment_Status = @StatusPayment WHERE Computer_Number = @ComputerNumber";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(updateQuery, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@MemberID", memberId);
                command.Parameters.AddWithValue("@DateStart", dateStart);
                command.Parameters.AddWithValue("@TimeIn", timeIn); command.Parameters.AddWithValue("@TimeOut", timeOut); command.Parameters.AddWithValue("@TimeRemaining", timeRemaining);
                command.Parameters.AddWithValue("@TotalPay", totalPay);
                command.Parameters.AddWithValue("@StatusPayment", statusPayment);
                command.Parameters.AddWithValue("@ComputerNumber", selectedComputerNumber);

                command.ExecuteNonQuery();
            }
        }





        public void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan remainingTime = TimeSpan.Parse(timeLabel.Text).Subtract(TimeSpan.FromSeconds(1));

            timeLabel.Text = remainingTime.ToString(@"hh\:mm\:ss");

            UpdateTimeRemaining(remainingTime);

            if (remainingTime.TotalSeconds <= 0)
            {
                timer.Stop();
                MessageBox.Show($"PC {selectedComputerNumber} Time Out!");
            }
        }
        private void UpdateTimeRemaining(TimeSpan remainingTime)
        {
            string remainingTimeString = remainingTime.ToString(@"hh\:mm\:ss");

            string updateQuery = "UPDATE tbl_session SET Time_Remaining = @TimeRemaining WHERE Computer_Number = @ComputerNumber";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(updateQuery, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@TimeRemaining", remainingTimeString);
                command.Parameters.AddWithValue("@ComputerNumber", selectedComputerNumber);

                command.ExecuteNonQuery();
            }
        }

        private int GetMemberId(string selectedClientName)
        {
            string query = "SELECT ID FROM tbl_member WHERE user_name = @UserName";
            int memberId = 0;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@UserName", selectedClientName);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        memberId = Convert.ToInt32(reader["ID"]);
                    }
                }
            }

            return memberId;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cmbComputerNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbClientName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }





        private void cmbComputerNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbComputerNumber.SelectedItem != null)
            {
                selectedComputerNumber = cmbComputerNumber.SelectedItem.ToString();

                cmbComputerNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            }

        }

        private void cmbClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbClientName.SelectedIndexChanged -= cmbClientName_SelectedIndexChanged;

            string selectedItem = cmbClientName.SelectedItem.ToString();

            string trimmedItem = selectedItem.TrimEnd();

            cmbClientName.Items[cmbClientName.SelectedIndex] = trimmedItem;

            cmbClientName.SelectedIndexChanged += cmbClientName_SelectedIndexChanged;
        }

        private void ckbMemberClient_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbMemberClient.Checked)
            {

                cmbClientName.Items.Clear();

                cmbClientName.SelectedIndexChanged += cmbClientName_SelectedIndexChanged;

                isMemberClient = false;

                PopulateClientNames();
                cmbClientName.Enabled = true;
            }
            else
            {
                cmbClientName.SelectedIndexChanged -= cmbClientName_SelectedIndexChanged;

                isMemberClient = true;

                clientName = "Guest";

                cmbClientName.Items.Clear();
                cmbClientName.Items.Add(clientName);
                cmbClientName.SelectedIndex = 0;
                cmbClientName.Enabled = false;
            }
        }


        private void PopulateClientNames()
        {
            string query = "SELECT user_name FROM tbl_member WHERE ID != 1";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string clientName = reader["user_name"].ToString().Trim();

                        cmbClientName.Items.Add(clientName);
                    }
                }
            }

            cmbClientName.Items.Add("Guest");

            cmbClientName.SelectedItem = "Guest";
        }

        private void cmbHours_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbMinutes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}