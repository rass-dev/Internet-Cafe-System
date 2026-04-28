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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace InternetCafe.Computers.Computer_View
{
    public partial class formComputer_Extend_Time : Form
    {
        private string connectionString = "Data Source=FX505DT-AL226T\\SQLPROJECTS; Initial Catalog=db_internet_cafe; User ID=svc_Admin;Password=1234admin;";
        private string computerNumber;
        private string memberId;
        private TimeSpan extendedTime;
        private Label timeLabel;
        private string selectedComputerNumber; private TimeSpan initialTimeRemaining; private DateTime timeOut;
        private int sessionId;
        public formComputer_Extend_Time(int sessionId, string computerNumber, string memberId, TimeSpan timeRemaining, DateTime timeOut)
        {
            InitializeComponent();
            this.sessionId = sessionId;
            this.computerNumber = computerNumber;
            this.memberId = memberId;
            this.initialTimeRemaining = timeRemaining;
            this.timeOut = timeOut;


        }

        private void LoadChoices()
        {
            string query = "SELECT user_name FROM tbl_member WHERE ID != 1"; using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string clientName = reader["user_name"].ToString().Trim();

                    }
                }
            }

            query = "SELECT Computer_Number FROM tbl_computer";
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

            for (int i = 0; i < 24; i++)
            {
                cmbAdditionalHours.Items.Add(i.ToString("00"));
            }
            for (int i = 0; i < 60; i++)
            {
                cmbAdditionalMinutes.Items.Add(i.ToString("00"));
            }
            cmbAdditionalHours.SelectedIndex = 0; cmbAdditionalMinutes.SelectedIndex = 0;
        }


        private Timer timer = new Timer();

        private void btnExtendTimeForm_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(selectedComputerNumber))
                {
                    timer.Stop();
                    timer.Dispose();

                    TimeSpan oldTimeRemaining = GetCurrentTimeRemaining(selectedComputerNumber);

                    int additionalHours = Convert.ToInt32(cmbAdditionalHours.SelectedItem);
                    int additionalMinutes = Convert.ToInt32(cmbAdditionalMinutes.SelectedItem);
                    TimeSpan additionalTime = new TimeSpan(additionalHours, additionalMinutes, 0);

                    decimal additionalPay = CalculateAdditionalPay(additionalTime, memberId);

                    string paymentStatus = GetPaymentStatus(selectedComputerNumber);

                    if (paymentStatus == "PAID")
                    {
                        ClearTotalPay(selectedComputerNumber);
                        additionalPay = CalculateAdditionalPay(additionalTime, memberId);
                    }

                    DateTime currentTime = DateTime.Now;
                    DateTime newTimeOut = currentTime.Add(oldTimeRemaining + additionalTime);

                    UpdateSessionTime(oldTimeRemaining + additionalTime, newTimeOut, additionalPay, memberId, "UNPAID");

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please select a computer number.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error extending time: " + ex.Message);
            }
        }


        private string GetPaymentStatus(string computerNumber)
        {
            string query = "SELECT Payment_Status FROM tbl_session WHERE Computer_Number = @ComputerNumber";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@ComputerNumber", computerNumber);
                object paymentStatusObj = command.ExecuteScalar();

                if (paymentStatusObj != DBNull.Value)
                {
                    return paymentStatusObj.ToString();
                }
            }

            return "";
        }

        private void ClearTotalPay(string computerNumber)
        {
            string updateQuery = "UPDATE tbl_session SET Total_Pay = 0 WHERE Computer_Number = @ComputerNumber";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(updateQuery, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@ComputerNumber", computerNumber);
                command.ExecuteNonQuery();
            }
        }

        private string GetMemberType(string memberId)
        {
            string query = "SELECT TRIM(Member_Type) AS Member_Type FROM tbl_member WHERE ID = @MemberId";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@MemberId", memberId);
                object memberTypeObj = command.ExecuteScalar();

                if (memberTypeObj != DBNull.Value)
                {
                    return memberTypeObj.ToString();
                }
            }

            return "";
        }


        private decimal CalculateAdditionalPay(TimeSpan additionalTime, string memberId)
        {
            decimal hourlyRate = GetRateFromDatabase("Hour");
            decimal minuteRate = GetRateFromDatabase("Minute");
            decimal discountAmount = GetDiscountAmount();
            string memberType = GetMemberType(memberId);

            if (memberType == "Member")
            {
                if (hourlyRate != 0 && minuteRate != 0)
                {
                    double totalHours = additionalTime.TotalHours;
                    decimal totalPay = Convert.ToDecimal(totalHours * (double)hourlyRate);

                    totalPay -= discountAmount;

                    return totalPay;
                }
                else if (minuteRate != 0)
                {
                    double totalMinutes = additionalTime.TotalMinutes;
                    decimal totalPay = Convert.ToDecimal(totalMinutes * (double)minuteRate);

                    totalPay -= discountAmount;

                    return totalPay;
                }
            }
            else
            {
                if (hourlyRate != 0 && minuteRate != 0)
                {
                    double totalHours = additionalTime.TotalHours;
                    decimal totalPay = Convert.ToDecimal(totalHours * (double)hourlyRate);

                    return totalPay;
                }
                else if (minuteRate != 0)
                {
                    double totalMinutes = additionalTime.TotalMinutes;
                    decimal totalPay = Convert.ToDecimal(totalMinutes * (double)minuteRate);

                    return totalPay;
                }
            }

            return 0;
        }



        private decimal GetDiscountAmount()
        {
            string query = "SELECT Rate FROM tbl_custom_pay_rates WHERE RateType = 'Discount_E'";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                object discountAmountObj = command.ExecuteScalar();

                if (discountAmountObj != null && discountAmountObj != DBNull.Value)
                {
                    return Convert.ToDecimal(discountAmountObj);
                }
            }

            return 0;
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
                    return Convert.ToDecimal(result);
                }
                else
                {
                    return 0;
                }
            }
        }

        private TimeSpan GetCurrentTimeRemaining(string computerNumber)
        {
            string query = "SELECT Time_Remaining FROM tbl_session WHERE Computer_Number = @ComputerNumber";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@ComputerNumber", computerNumber);
                object timeRemainingObj = command.ExecuteScalar();

                if (timeRemainingObj != DBNull.Value)
                {
                    string timeRemainingStr = timeRemainingObj.ToString();
                    TimeSpan.TryParse(timeRemainingStr, out TimeSpan timeRemaining);
                    return timeRemaining;
                }
            }

            return TimeSpan.Zero;
        }

        private void UpdateSessionTime(TimeSpan updatedTimeRemaining, DateTime newTimeOut, decimal additionalPay, string newMemberId, string paymentStatus)
        {
            string formattedTimeOut = newTimeOut.ToString("HH:mm:ss");

            string updateQuery = "UPDATE tbl_session SET Time_Remaining = @TimeRemaining, Time_Out = @TimeOut, Total_Pay = Total_Pay + @AdditionalPay, Member_ID = @MemberId, Payment_Status = @PaymentStatus WHERE Session_ID = @SessionId";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(updateQuery, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@TimeRemaining", updatedTimeRemaining.ToString(@"hh\:mm\:ss"));
                command.Parameters.AddWithValue("@TimeOut", formattedTimeOut); command.Parameters.AddWithValue("@AdditionalPay", additionalPay);
                command.Parameters.AddWithValue("@MemberId", newMemberId); command.Parameters.AddWithValue("@SessionId", sessionId);
                command.Parameters.AddWithValue("@PaymentStatus", paymentStatus); command.ExecuteNonQuery();
            }
        }

        private TimeSpan GetCurrentTimeRemaining(int sessionId)
        {
            string query = "SELECT Time_Remaining FROM tbl_session WHERE Session_ID = @SessionId";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@SessionId", sessionId);
                object timeRemainingObj = command.ExecuteScalar();

                if (timeRemainingObj != DBNull.Value)
                {
                    string timeRemainingStr = timeRemainingObj.ToString();
                    TimeSpan.TryParse(timeRemainingStr, out TimeSpan timeRemaining);
                    return timeRemaining;
                }
            }

            return TimeSpan.Zero;
        }


        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbAdditionalMinutes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbAdditionalHours_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbComputerNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbComputerNumber.SelectedItem != null)
            {
                selectedComputerNumber = cmbComputerNumber.SelectedItem.ToString();

                cmbComputerNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void formComputer_Extend_Time_Load(object sender, EventArgs e)
        {
            LoadChoices();

            cmbComputerNumber.KeyPress += cmbComputerNumber_KeyPress;



        }


        private void cmbComputerNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbClientName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

    }
}
